using OX.IO;
using OX.IO.Data.LevelDB;
using OX.Network.P2P;
using OX.Network.P2P.Payloads;
using OX.SmartContract;
using OX;
using OX.VM;
using OX.Ledger;
using System.Linq;
using System;
using System.Runtime.CompilerServices;
using OX.BMS;
using System.Net.Http.Headers;
using OX.Casino;
using OX.Mining;
using OX.Mining.DEX;
using OX.Mining.OTC;
using OX.Mining.AMI;

namespace OX.Tablet
{
    public static partial class CasinoPersistenceHelper
    {
        public static void Save_AnchorMortgageIssueRecord(this WriteBatch batch, MiningBlockIndex provider, Block block, EthereumMapTransaction emt, TransactionOutput output)
        {
            AnchorMortgageIssueKey key = new AnchorMortgageIssueKey
            {
                EthereumAddress = emt.EthereumAddress.ToLower(),
                TxHash = emt.Hash,
                Timestamp = block.Timestamp
            };
            batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.AMI_USDTCastRecord).Add(key), SliceBuilder.Begin().Add(output));
        }
        public static void Save_AnchorMortgageDestroyRecord(this WriteBatch batch, MiningBlockIndex provider, Block block, Transaction tx, TransactionOutput output, string ethAddress)
        {
            AnchorMortgageIssueKey key = new AnchorMortgageIssueKey
            {
                EthereumAddress = ethAddress.ToLower(),
                TxHash = tx.Hash,
                Timestamp = block.Timestamp
            };
            batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.AMI_USDTDestroyRecord).Add(key), SliceBuilder.Begin().Add(output));
        }
        public static void Save_InvestSettingRecord(this WriteBatch batch, BizRecordModel model, InvestSettingRecord record)
        {
            if (record != default && record.Value != default)
                batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.Invest_Setting).Add(model.Key), SliceBuilder.Begin().Add(record));
        }
        public static void Save_RosIdentityRecord(this WriteBatch batch, MiningBlockIndex provider, BizRecordModel model, RosIdentityRecord record)
        {
            if (record != default)
            {
                var seedSH = model.Key.AsSerializable<UInt160>().GetMutualLockSeed();
                if (provider.MutualLockNodes.TryGetValue(seedSH, out var miner))
                {
                    miner.Crest = record.Crest;
                    miner.Medal = record.Medal;
                    miner.KYC = record.KYC;
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.MutualLockNode).Add(seedSH), SliceBuilder.Begin().Add(miner));
                }
            }
        }
        public static void Save_MainSwapPair(this WriteBatch batch, MiningBlockIndex provider, Block block, SlotSideTransaction st, SwapPairReply reply)
        {
            if (reply.IsNotNull())
            {
                var sh = st.GetContract().ScriptHash;
                var TargetAssetState = Blockchain.Singleton.Store.GetAssets().TryGet(reply.TargetAssetId);
                var merge = new SwapPairMerge { PoolAddress = sh, TxId = st.Hash, SwapPairReply = reply, TargetAssetState = TargetAssetState, Index = block.Index };
                batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.SwapPair).Add(sh), SliceBuilder.Begin().Add(merge));
                provider.SwapPairs[sh] = merge;
            }
        }
        public static void Save_SwapPairStateReply(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, ReplyTransaction rt, SwapPairStateReply reply)
        {
            if (reply.IsNotNull())
            {
                var hostSH = reply.PoolAddress;
                batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.SwapPairState).Add(hostSH), SliceBuilder.Begin().Add(reply));
                miningProvider.SwapPairStates[hostSH] = reply;
            }
        }
        public static void Save_SwapPairExchange(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, ushort TxN, Transaction tx)
        {
            if (tx.References.IsNotNullAndEmpty())
            {
                foreach (var reference in tx.References)
                {
                    if (miningProvider.SwapPairs.TryGetValue(reference.Value.ScriptHash, out SwapPairMerge spm))
                    {
                        if (spm.TargetAssetState.AssetId.Equals(reference.Value.AssetId) || Blockchain.OXC.Equals(reference.Value.AssetId))
                        {
                            var attr = tx.Attributes.FirstOrDefault(m => m.Usage == TransactionAttributeUsage.Remark2);
                            if (attr.IsNotNull())
                            {
                                try
                                {
                                    var sop = attr.Data.AsSerializable<SwapVolume>();
                                    if (sop.IsNotNull())
                                    {
                                        SwapPairExchangeKey key = new SwapPairExchangeKey { SH = reference.Value.ScriptHash, Payee = sop.Payee, Timestamp = block.Timestamp, Index = block.Index, TxN = TxN, TxId = tx.Hash };
                                        var vom = new SwapVolumeMerge { Volume = sop, Price = (decimal)sop.PricingAssetVolume.GetInternalValue() / (decimal)sop.TargetAssetVolume.GetInternalValue() };
                                        batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.SwapPairExchange).Add(key), SliceBuilder.Begin().Add(vom));
                                        var swapvolumemerge = miningProvider.Get<SwapVolumeMerge>(InvestBizPersistencePrefixes.SwapPairLastExchange, reference.Value.ScriptHash);
                                        long sortIndex = 0;
                                        if (swapvolumemerge.IsNotNull())
                                        {
                                            sortIndex = (long)swapvolumemerge.Volume.BlockIndex * 10000 + (long)swapvolumemerge.Volume.TxN;
                                        }
                                        long newsortIndex = (long)sop.BlockIndex * 10000 + (long)sop.TxN;
                                        if (newsortIndex > sortIndex)
                                            batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.SwapPairLastExchange).Add(reference.Value.ScriptHash), SliceBuilder.Begin().Add(vom));
                                        //SwapBeforeExchangeKey sbekey = new SwapBeforeExchangeKey { SH = reference.Value.ScriptHash, BlockIndex = sop.BlockIndex, TxN = sop.TxN };
                                        batch.Delete(SliceBuilder.Begin(InvestBizPersistencePrefixes.SwapPairBeforeExchange).Add(key));
                                    }
                                }
                                catch { }
                            }
                            var attr3 = tx.Attributes.FirstOrDefault(m => m.Usage == TransactionAttributeUsage.Remark3);
                            if (attr3.IsNotNull())
                            {
                                try
                                {
                                    var idor = attr3.Data.AsSerializable<IDORecord>();
                                    if (idor.IsNotNull())
                                    {
                                        SwapIDOKey key = new SwapIDOKey { PoolAddress = idor.PoolAddress, IDOOwner = idor.IdoOwner, TxId = tx.Hash };
                                        batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.SwapPairIDORecord).Add(key), SliceBuilder.Begin().Add(idor));
                                    }
                                }
                                catch { }
                            }

                            break;
                        }
                    }
                }
            }
            var sh = tx.Witnesses.FirstOrDefault(m => miningProvider.SwapPairs.ContainsKey(m.ScriptHash) || invest.MasterAccountAddress == m.ScriptHash);

            if (sh.IsNull())
            {
                for (ushort i = 0; i < tx.Outputs.Length; i++)
                {
                    var output = tx.Outputs[i];
                    var v = output.Value;
                    if (miningProvider.SwapPairs.TryGetValue(output.ScriptHash, out SwapPairMerge spm))
                    {
                        if (block.Index >= spm.SwapPairReply.Stamp)
                        {
                            SwapBeforeExchangeKey key = new SwapBeforeExchangeKey { SH = output.ScriptHash, BlockIndex = block.Index, TxN = TxN };
                            batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.SwapPairBeforeExchange).Add(key), SliceBuilder.Begin().Add(output));
                        }
                    }
                }
            }
        }
        public static void Save_OTCDealer(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, SlotSideTransaction st, string ethAddress, OTCSetting setting)
        {
            var sh = st.GetContract().ScriptHash;
            if (miningProvider.OTCDealers.TryGetValue(sh, out OTCDealerMerge dealerMerge))
            {
                dealerMerge.Setting = setting;
            }
            else
            {
                dealerMerge = new OTCDealerMerge { EthAddress = ethAddress, InPoolAddress = sh, Setting = setting };
                miningProvider.OTCDealers[sh] = dealerMerge;
            }
            batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.OTC_Dealer).Add(sh), SliceBuilder.Begin().Add(dealerMerge));
        }
    }
}
