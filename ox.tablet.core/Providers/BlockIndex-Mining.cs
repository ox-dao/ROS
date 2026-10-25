using Akka.Actor;
using Akka.IO;
using Akka.Util;
using Nethereum.ABI.CompilationMetadata;
using Nethereum.Model;
using Org.BouncyCastle.Asn1.Ocsp;
using OX.Bapps;
using OX.BMS;
using OX.Casino;
using OX.Cryptography.ECC;
using OX.IO;
using OX.IO.Data.LevelDB;
using OX.IO.Wrappers;
using OX.Ledger;
using OX.Mining;
using OX.Mining.DEX;
using OX.Mining.OTC;
using OX.Mining.StakingMining;
using OX.Network.P2P.Payloads;
using OX.Persistence;
using OX.SmartContract;
using OX.Tablet.Models;
using OX.Wallets;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OX.Tablet
{
    public class MiningBlockIndex : BaseSubBlockIndex
    {
        public const string IndexKey = "Data_MiningIndex";
        public override bool CanRebuild => true;
        public Fixed8 TotalIssuedOXC { get; private set; }
        public Dictionary<UInt160, SwapPairMerge> SwapPairs { get; set; } = new Dictionary<UInt160, SwapPairMerge>();
        public Dictionary<UInt160, SwapPairStateReply> SwapPairStates { get; set; } = new Dictionary<UInt160, SwapPairStateReply>();
        public Dictionary<UInt160, OTCDealerMerge> OTCDealers { get; set; } = new Dictionary<UInt160, OTCDealerMerge>();
        /// <summary>
        /// key is node seed address,value is node private address
        /// </summary>
        public Dictionary<UInt160, MutualNode> MutualLockNodes { get; set; } = new Dictionary<UInt160, MutualNode>();
        public Dictionary<UInt256, MutualLockMiningAssetReply> MutualLockAssets { get; set; } = new Dictionary<UInt256, MutualLockMiningAssetReply>();
        public Dictionary<UInt256, InGoldRecord> InGoldRecords { get; set; } = new Dictionary<UInt256, InGoldRecord>();
        public Dictionary<UInt256, OutGoldRecord> OutGoldRecords { get; set; } = new Dictionary<UInt256, OutGoldRecord>();
        UInt160 _masterOTCPoolAddress;
        public UInt160 MasterOTCPoolAddress
        {
            get
            {
                if (_masterOTCPoolAddress == default)
                {
                    _masterOTCPoolAddress = SecureHelper.ExchangeAccount.EthAddress.BuildOTCDealerTransaction().GetContract().ScriptHash;
                }
                return _masterOTCPoolAddress;
            }
        }
        public MiningBlockIndex(BlockIndex blockIndex, OXAccount oxAccount, EthAccount ethAccount) : base(blockIndex, oxAccount, ethAccount, IndexKey)
        {
            this.TotalIssuedOXC = this.Get<Fixed8>(InvestBizPersistencePrefixes.OXC_ALL_Issued, Blockchain.OXC);
            SwapPairs = new Dictionary<UInt160, SwapPairMerge>(this.GetAll<UInt160, SwapPairMerge>(InvestBizPersistencePrefixes.SwapPair));
            SwapPairStates = new Dictionary<UInt160, SwapPairStateReply>(this.GetAll<UInt160, SwapPairStateReply>(InvestBizPersistencePrefixes.SwapPairState));
            OTCDealers = new Dictionary<UInt160, OTCDealerMerge>(this.GetAll<UInt160, OTCDealerMerge>(InvestBizPersistencePrefixes.OTC_Dealer));
            InGoldRecords = new Dictionary<UInt256, InGoldRecord>(this.GetAll<UInt256, InGoldRecord>(InvestBizPersistencePrefixes.OTC_InGoldRecord));
            OutGoldRecords = new Dictionary<UInt256, OutGoldRecord>(this.GetAll<UInt256, OutGoldRecord>(InvestBizPersistencePrefixes.OTC_OutGoldRecord));

            MutualLockNodes = new Dictionary<UInt160, MutualNode>(this.GetAll<UInt160, MutualNode>(InvestBizPersistencePrefixes.MutualLockNode));
            var mutualLockAssetRecords = this.GetAll<MutualLockMiningAssetKey, MutualLockMiningAssetReply>(InvestBizPersistencePrefixes.MutualLockMiningAssetReply);
            if (mutualLockAssetRecords.IsNotNullAndEmpty())
            {
                foreach (var g in mutualLockAssetRecords.GroupBy(m => m.Key.AssetId))
                {
                    var r = g.OrderByDescending(m => m.Key.IssueIndex).FirstOrDefault();
                    MutualLockAssets[g.Key] = r.Value;
                }
            }

        }

        public override void Rebuild()
        {
            this.SwapPairs.Clear();
            this.SwapPairStates.Clear();
            this.OTCDealers.Clear();
            this.MutualLockNodes.Clear();
            base.Rebuild();
        }
        public override void HandleBlock(Block block)
        {
            WriteBatch batch = new WriteBatch();
            BlockContext context = new BlockContext();
            for (ushort i = 0; i < block.Transactions.Length; i++)
            {
                var tx = block.Transactions[i];
                if (this.IsBizTransaction(tx, invest.MasterAccountAddress, out BizTransaction biztx))
                {
                    ushort? n = null;
                    if (biztx is BillTransaction bt)
                    {
                        foreach (var record in bt.Records)
                        {
                            var bizModel = InvestBizRecordHelper.BuildModel(record);
                            if (bizModel.Model is InvestSettingRecord InvestSettingRecord)
                                batch.Save_InvestSettingRecord(bizModel, InvestSettingRecord);
                            else if (bizModel.Model is RosIdentityRecord rosIdentityRecord)
                            {
                                batch.Save_RosIdentityRecord(this, bizModel, rosIdentityRecord);
                            }
                        }
                    }
                    else if (biztx is ReplyTransaction rt)
                    {
                        OnMiningReplayTransaction(batch, block, rt);
                    }
                    else if (biztx is AskTransaction at)
                    {
                        OnMiningAskTransaction(batch, block, at, i, out n);
                    }
                }
                else if (tx is LockAssetTransaction lat)
                {
                    OnLockAssetTransaction(batch, block, lat);
                }
                else if (tx is IssueTransaction ist)
                {
                    OnIssueTransaction(batch, block, ist);
                }
                else if (tx is EthereumMapTransaction emt)
                {
                    OnEthereumMapTransaction(batch, block, emt, i);
                }
                else if (tx is SlotSideTransaction st)
                {
                    OnSideTransaction(batch, block, st);
                }
                else if (tx is ClaimTransaction clmTx)
                {
                    TransactionResult result = clmTx.GetTransactionResults().FirstOrDefault(p => p.AssetId == Blockchain.OXC);
                    this.TotalIssuedOXC -= result.Amount;
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.OXC_ALL_Issued).Add(Blockchain.OXC), SliceBuilder.Begin().Add(this.TotalIssuedOXC));
                }
                else if (tx is RangeTransaction rgt)
                {
                }
                else if (tx is ContractTransaction ct)
                {
                    var attrib = ct.Attributes.FirstOrDefault(m => m.Usage == TransactionAttributeUsage.RelatedTransactionHash);
                    if (attrib.IsNotNull())
                    {
                        try
                        {
                            var ethTxId = new UInt256(attrib!.Data);
                            var reference = ct.References.Select(m => m.Value).Where(m => m.AssetId == invest.USDT_Asset).FirstOrDefault();
                            if (this.InGoldRecords.TryGetValue(ethTxId, out var inGoldReord))
                            {
                                inGoldReord.State = InOutGoldStatus.Settled;
                                inGoldReord.TimeStamp = block.Timestamp;
                                if (reference.IsNotNull())
                                {
                                    var buyerOutput = ct.Outputs.Where(m => m.AssetId == invest.USDT_Asset && m.ScriptHash != reference!.ScriptHash).FirstOrDefault();
                                    if (buyerOutput.IsNotNull())
                                    {
                                        inGoldReord.Amount = buyerOutput.Value;
                                        batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.OTC_InGoldRecord).Add(ethTxId), SliceBuilder.Begin().Add(inGoldReord));
                                    }
                                }
                            }
                            if (reference.IsNotNull() && reference!.ScriptHash == this.MasterOTCPoolAddress)
                            {
                                var outGoldRecord = new OutGoldRecord
                                {
                                    EthTxId = ethTxId,
                                    TimeStamp = block.Timestamp,
                                };
                                var buyerOutput = ct.Outputs.Where(m => m.AssetId == invest.USDT_Asset && m.ScriptHash != reference!.ScriptHash).FirstOrDefault();
                                if (buyerOutput.IsNotNull())
                                {
                                    outGoldRecord.Amount = buyerOutput.Value;
                                }
                                batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.OTC_OutGoldRecord).Add(ethTxId), SliceBuilder.Begin().Add(outGoldRecord));
                                this.OutGoldRecords[ethTxId] = outGoldRecord;
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                if (tx.Outputs.IsNotNullAndEmpty())
                {
                    for (ushort k = 0; k < tx.Outputs.Length; k++)
                    {
                        TransactionOutput output = tx.Outputs[k];
                        OnPledgeMiningTransaction(batch, this, block, tx, output, k);
                        CheckUSDTBlackHoleDestroy(batch, block, output, tx);
                    }
                }
                batch.Save_SwapPairExchange(this, block, i, tx);
            }
            this.Db.Write(WriteOptions.Default, batch);
        }
        public void OnMiningAskTransaction(WriteBatch batch, Block block, AskTransaction at, ushort txindex, out ushort? n)
        {

            n = null;
            IReadOnlyDictionary<CoinReference, TransactionOutput> rfs = at.References;
            var bizshs = new UInt160[] { invest.MasterAccountAddress };
            //1.验证Tip标签的真实性,不真实则返回不做后续处理
            switch (at.DataType)
            {
                case (byte)InvestType.OTCExchangeRequest:
                    if (at.GetDataModel<OTCExchangeRequest>(bizshs, (byte)InvestType.OTCExchangeRequest, out OTCExchangeRequest request))
                    {
                        if (at.From.Equals(SecureHelper.MasterAccount.Key.PublicKey))
                        {
                            if (this.InGoldRecords.TryGetValue(request.EthTxHash, out var inGoldReord))
                            {
                                inGoldReord.TimeStamp = block.Timestamp;
                                inGoldReord.State = InOutGoldStatus.Submitted;
                                batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.OTC_InGoldRecord).Add(request.EthTxHash), SliceBuilder.Begin().Add(inGoldReord));
                            }
                            else
                            {
                                inGoldReord = new InGoldRecord
                                {
                                    EthTxId = request.EthTxHash,
                                    State = InOutGoldStatus.Submitted,
                                    TimeStamp = block.Timestamp
                                };
                                batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.OTC_InGoldRecord).Add(request.EthTxHash), SliceBuilder.Begin().Add(inGoldReord));
                                this.InGoldRecords[request.EthTxHash] = inGoldReord;
                            }
                        }
                    }
                    break;
            }

        }
        public void OnIssueTransaction(WriteBatch batch, Block block, IssueTransaction ist)
        {
            foreach (var output in ist.Outputs)
            {
                if (this.MutualLockAssets.TryGetValue(output.AssetId, out MutualLockMiningAssetReply MAR))
                {
                    batch.Save_MutualLockInterestRecord(this, block, ist, output);
                }
                //if (this.LevelLockAsset.IsNotNull() && this.LevelLockAsset.AssetId.Equals(output.AssetId))
                //{
                //    batch.Save_LevelLockInterestRecord(this, block, ist, output);
                //}
            }
        }
        public void OnLockAssetTransaction(WriteBatch batch, Block block, LockAssetTransaction lat)
        {
            if (lat.LockContract.Equals(Blockchain.LockAssetContractScriptHash))
            {
                OnLockAssetTransactionForSelfLock(batch, block, lat);
                OnLockAssetTransactionForMutualLock(batch, block, lat);
                //OnLockAssetTransactionForLevelLock(batch, block, lat);
            }
        }
        public void OnLockAssetTransactionForMutualLock(WriteBatch batch, Block block, LockAssetTransaction lat)
        {
            if (!lat.IsTimeLock)
            {
                if (lat.IsSelfLock(out UInt160 sh))
                {
                    var contractSH = lat.GetContract().ScriptHash;
                    var output = lat.Outputs.FirstOrDefault(m => m.ScriptHash.Equals(contractSH));
                    if (output.IsNotNull() && this.MutualLockAssets.TryGetValue(output.AssetId, out MutualLockMiningAssetReply MAR))
                    {
                        if (output.Value >= MAR.MinAmount && output.Value <= MAR.MaxAmount)
                        {
                            if (lat.LockExpiration - block.Index >= 100000)
                                batch.Save_MutualLockRecord(this, block, lat, output, sh);
                        }
                    }
                }

            }
        }
        public void OnEthereumMapTransactionForMutualLock(WriteBatch batch, Block block, EthereumMapTransaction emt)
        {

            var contractSH = emt.GetContract().ScriptHash;
            var output = emt.Outputs.FirstOrDefault(m => m.ScriptHash.Equals(contractSH));
            if (output.IsNotNull() && this.MutualLockAssets.TryGetValue(output.AssetId, out MutualLockMiningAssetReply MAR))
            {
                if (emt.IsSelfLock())
                {
                    if (output.Value >= MAR.MinAmount && output.Value <= MAR.MaxAmount)
                    {
                        if (emt.LockExpirationIndex - block.Index >= 100000)
                            batch.Save_MutualLockRecordForEth(this, block, emt, output);
                    }
                }
                if (emt.IsIssue && emt.LockExpirationIndex == 0)
                {
                    batch.Save_MutualLockInterestRecordForEth(this, block, emt, output);
                }
            }

        }
        public void OnEthereumMapTransactionForSelfLock(WriteBatch batch, Block block, EthereumMapTransaction emt)
        {
            var contractSH = emt.GetContract().ScriptHash;
            if (emt.IsSelfLock())
            {
                for (ushort k = 0; k < emt.Outputs.Length; k++)
                {
                    TransactionOutput output = emt.Outputs[k];
                    if (output.ScriptHash.Equals(contractSH))
                    {
                        if (this.MutualLockAssets.IsNotNullAndEmpty())
                        {
                            var asset = this.MutualLockAssets.Select(m => m.Value)?.FirstOrDefault(m => m.AssetId.Equals(output.AssetId));
                            if (asset.IsNotNull() && output.Value >= asset.MinAmount && output.Value <= asset.MaxAmount)
                            {
                                batch.Save_LockMiningRecordsForEth(this, block, emt, k, output);
                            }
                        }
                    }
                }
            }
            if (emt.IsIssue && emt.LockExpirationIndex > 0)
            {
                for (ushort k = 0; k < emt.Outputs.Length; k++)
                {
                    TransactionOutput output = emt.Outputs[k];
                    if (output.ScriptHash.Equals(contractSH))
                    {
                        if (this.MutualLockAssets.IsNotNullAndEmpty() && this.MutualLockAssets.Select(m => m.Key).Contains(output.AssetId))
                        {
                            batch.Save_LockMiningInterestRecordsForEth(this, block, emt, k, output);
                        }
                    }
                }
            }
        }
        public void OnLockAssetTransactionForSelfLock(WriteBatch batch, Block block, LockAssetTransaction lat)
        {
            if (!lat.IsTimeLock)
            {
                if (lat.IsSelfLock(out UInt160 sh))
                {
                    var contractSH = lat.GetContract().ScriptHash;
                    for (ushort k = 0; k < lat.Outputs.Length; k++)
                    {
                        TransactionOutput output = lat.Outputs[k];
                        if (output.ScriptHash.Equals(contractSH))
                        {
                            if (this.MutualLockAssets.IsNotNullAndEmpty())
                            {
                                var asset = this.MutualLockAssets.Select(m => m.Value)?.FirstOrDefault(m => m.AssetId.Equals(output.AssetId));
                                if (asset.IsNotNull() && output.Value >= asset.MinAmount && output.Value <= asset.MaxAmount)
                                    batch.Save_LockMiningRecords(this, block, lat, k, output, sh);
                            }
                            if (output.AssetId.Equals(Blockchain.OXS))
                            {
                                batch.Save_LockMiningOXSTotal(this, sh, block, lat, k, output);
                            }
                        }
                    }
                }
                if (lat.IsIssue)
                {
                    var addr = Contract.CreateSignatureRedeemScript(lat.Recipient).ToScriptHash();

                    var contractSH = lat.GetContract().ScriptHash;
                    for (ushort k = 0; k < lat.Outputs.Length; k++)
                    {
                        TransactionOutput output = lat.Outputs[k];
                        if (output.ScriptHash.Equals(contractSH))
                        {
                            if (this.MutualLockAssets.IsNotNullAndEmpty() && this.MutualLockAssets.Select(m => m.Key).Contains(output.AssetId))
                            {
                                batch.Save_LockMiningInterestRecords(this, block, lat, k, output, addr);
                            }
                        }
                    }
                }
            }
        }
        public void CheckUSDTBlackHoleDestroy(WriteBatch batch, Block block, TransactionOutput output, Transaction tx)
        {
            if (output.ScriptHash.Equals(UInt160.Zero) && output.AssetId.Equals(invest.USDT_Asset))
            {
                if (tx.EthSignatures.IsNotNullAndEmpty() && tx.EthSignatures.Count() <= 2)
                {
                    foreach (var sig in tx.EthSignatures)
                    {
                        try
                        {
                            var stringToSign = tx.InputOutputHash.ToArray().ToHexString();
                            var signer = new Nethereum.Signer.EthereumMessageSigner();
                            var ethAddr = signer.EncodeUTF8AndEcRecover(stringToSign, sig.CreateStringSignature());
                            if (ethAddr.IsNotNullAndEmpty() && ethAddr.ToLower() == SecureHelper.ExchangeAccount.EthAddress.ToLower())
                            {
                                batch.Save_AnchorMortgageDestroyRecord(this, block, tx, output, ethAddr);
                                break;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        public void OnEthereumMapTransaction(WriteBatch batch, Block block, EthereumMapTransaction emt, ushort TxN)
        {
            if (emt.EthMapContract.Equals(Blockchain.EthereumMapContractScriptHash))
            {
                OnEthereumMapTransactionForSelfLock(batch, block, emt);
                OnEthereumMapTransactionForMutualLock(batch, block, emt);
                OnEthereumMapTransactionForAnchorMortgageIssue(batch, block, emt, TxN);
            }
        }
        public void OnEthereumMapTransactionForAnchorMortgageIssue(WriteBatch batch, Block block, EthereumMapTransaction emt, ushort TxN)
        {
            if (emt.VerifyAnchorMortgageIssue_tablet(out TransactionOutput output))
            {
                batch.Save_AnchorMortgageIssueRecord(this, block, emt, output);
            }
        }
        public void OnSideTransaction(WriteBatch batch, Block block, SlotSideTransaction st)
        {
            UInt256 AssetId = default;
            if (st.VerifyRegMainSwap(out AssetId, out SwapPairReply swapPairReply))
            {
                batch.Save_MainSwapPair(this, block, st, swapPairReply);
            }
            else if (st.VerifyRegSideSwap(out AssetId))
            {
                //var settings = this.GetAllInvestSettings();
                //var feesetting = settings.FirstOrDefault(m => Enumerable.SequenceEqual(m.Key, new[] { InvestSettingTypes.SidePairRegFee }));
                //if (feesetting.Equals(new KeyValuePair<byte[], InvestSettingRecord>())) return;
                //var fee = Fixed8.FromDecimal(decimal.Parse(feesetting.Value.Value));
                //if (st.VerifyRegSideSwapFee(fee))
                //{
                //    batch.Save_SideSwapPair(this, block, st, AssetId);
                //}
            }
            else if (st.VerifyOTCDealerTx(out string ethAddress, out OTCSetting setting))
            {
                batch.Save_OTCDealer(this, block, st, ethAddress, setting);
            }
        }
        public void OnMiningReplayTransaction(WriteBatch batch, Block block, ReplyTransaction rt)
        {
            var bizshs = new UInt160[] { invest.MasterAccountAddress };
            IReadOnlyDictionary<CoinReference, TransactionOutput> rfs = rt.References;
            switch (rt.DataType)
            {
                case (byte)InvestType.SwapPairStateReply:
                    if (rt.GetDataModel<SwapPairStateReply>(bizshs, (byte)InvestType.SwapPairStateReply, out SwapPairStateReply SwapPairStateReply))
                    {
                        batch.Save_SwapPairStateReply(this, block, rt, SwapPairStateReply);
                    }
                    break;
                case (byte)InvestType.MutualLockMiningAssetReply:
                    if (rt.GetDataModel<MutualLockMiningAssetReply>(bizshs, (byte)InvestType.MutualLockMiningAssetReply, out MutualLockMiningAssetReply MutualLockMiningAssetReply))
                    {
                        batch.Save_MutualLockMiningAssetReply(this, block, rt, MutualLockMiningAssetReply);
                    }
                    break;
            }

        }
        public IEnumerable<KeyValuePair<byte[], InvestSettingRecord>> GetAllInvestSettings()
        {
            return this.Db.Find(ReadOptions.Default, SliceBuilder.Begin(InvestBizPersistencePrefixes.Invest_Setting), (k, v) =>
            {
                var ks = k.ToArray();
                var length = ks.Length - sizeof(byte);
                ks = ks.TakeLast(length).ToArray();
                byte[] data = v.ToArray();
                return new KeyValuePair<byte[], InvestSettingRecord>(ks, data.AsSerializable<InvestSettingRecord>());
            });
        }
        public string GetAnchorMortgageIssuePoolAddress()
        {
            var setting = this.GetAllInvestSettings().FirstOrDefault(m => Enumerable.SequenceEqual(m.Key, new[] { InvestSettingTypes.AnchorIssuePool }));
            if (setting.Equals(new KeyValuePair<byte[], InvestSettingRecord>()))
                return string.Empty;
            return setting.Value.Value;
        }
        public string GetValidScope()
        {
            var setting = this.GetAllInvestSettings().FirstOrDefault(m => Enumerable.SequenceEqual(m.Key, new[] { InvestSettingTypes.ValidScope }));
            if (setting.Equals(new KeyValuePair<byte[], InvestSettingRecord>()))
                return string.Empty;
            return setting.Value.Value;
        }
        public LongWrapper GetTotalValidLockVolume(UInt256 assetId, UInt160 holder)
        {
            TotalLockVolumeKey key = new TotalLockVolumeKey { AssetId = assetId, Holder = holder };
            var lw = this.Get<LongWrapper>(InvestBizPersistencePrefixes.TotalMutualLockSpaceTimeLockVolume, key);
            if (lw.IsNull())
            {
                lw = new LongWrapper();
            }
            return lw;
        }
        public void OnPledgeMiningTransaction(WriteBatch batch, MiningBlockIndex miningProvider, Block block, Transaction tx, TransactionOutput output, ushort k)
        {
            MutualNode parentNode = default;
            var isRootReg = output.ScriptHash.Equals(MutualLockMiningHelper.GenesisSeed());
            var isCommonReg = this.MutualLockNodes.TryGetValue(output.ScriptHash, out parentNode);
            if (isRootReg || isCommonReg)
            {

                //reg miner
                if (output.VerifyMutualLockNodeRegister())
                {
                    if (tx.IsOnlyFromEthereumMapAddress(out string ethAddress))
                    {
                        batch.Save_MutualLockNodeForEth(this, block, tx, output, parentNode, ethAddress);
                    }
                    else
                        batch.Save_MutualLockNode(this, block, tx, output, parentNode);
                }
            }
        }

        public void SaveInGoldRecord(InGoldRecord inGoldRecord)
        {
            if (!this.InGoldRecords.ContainsKey(inGoldRecord.EthTxId))
            {
                WriteBatch batch = new WriteBatch();
                batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.OTC_InGoldRecord).Add(inGoldRecord.EthTxId), SliceBuilder.Begin().Add(inGoldRecord));
                this.InGoldRecords[inGoldRecord.EthTxId] = inGoldRecord;
                this.Db.Write(WriteOptions.Default, batch);
            }
        }

    }
}
