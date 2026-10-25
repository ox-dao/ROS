using Akka.IO;
using OX;
using OX.BMS;
using OX.Casino;
using OX.IO;
using OX.IO.Data.LevelDB;
using OX.Ledger;
using OX.Mining;
using OX.Mining.DEX;
using OX.Mining.StakingMining;
using OX.Network.P2P;
using OX.Network.P2P.Payloads;
using OX.SmartContract;
using OX.VM;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace OX.Tablet
{
    public static partial class CasinoPersistenceHelper
    {
        public static void Save_LockMiningInterestRecordsForEth(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, EthereumMapTransaction emt, ushort k, TransactionOutput output)
        {
            if (emt.IsNotNull())
            {
                var recipient = emt.EthereumAddress.BuildMapAddress();
                if (miningProvider.MutualLockNodes.TryGetValue(recipient.GetMutualLockSeed(), out MutualNode miner))
                {
                    SelfLockKey key = new SelfLockKey { AssetId = output.AssetId, Holder = recipient, TxId = emt.Hash };
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.LockMiningInterestRecords).Add(key), SliceBuilder.Begin().Add(new LockMiningRecordMerge { AssetId = output.AssetId, TransactionType = emt.Type, TxId = emt.Hash, K = k, Index = block.Index, Timestamp = block.Timestamp, LockExpiration = emt.LockExpirationIndex, Output = output }));
                }
            }
        }
        public static void Save_LockMiningRecordsForEth(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, EthereumMapTransaction emt, ushort k, TransactionOutput output)
        {
            if (emt.IsNotNull())
            {
                var recipient = emt.EthereumAddress.BuildMapAddress();
                if (miningProvider.MutualLockNodes.TryGetValue(recipient.GetMutualLockSeed(), out MutualNode miner))
                {
                    SelfLockKey key = new SelfLockKey { AssetId = output.AssetId, Holder = recipient, TxId = emt.Hash };
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.LockMiningRecords).Add(key), SliceBuilder.Begin().Add(new LockMiningRecordMerge { AssetId = output.AssetId, TransactionType = emt.Type, TxId = emt.Hash, K = k, Index = block.Index, Timestamp = block.Timestamp, LockExpiration = emt.LockExpirationIndex, Output = output }));
                    batch.Save_TotalLockVolume(miningProvider, output.AssetId, recipient, output.Value, block.Index, emt.LockExpirationIndex);
                }
            }
        }
        public static void Save_MutualLockInterestRecordForEth(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, EthereumMapTransaction emt, TransactionOutput output)
        {
            if (emt.IsNotNull())
            {
                var recipient = emt.EthereumAddress.BuildMapAddress();
                if (miningProvider.MutualLockNodes.TryGetValue(recipient.GetMutualLockSeed(), out MutualNode miner))
                {
                    MutualLockInterestKey key = new MutualLockInterestKey { Owner = miner.HolderAddress, ParentOwner = miner.ParentHolder, AssetId = output.AssetId, Amount = output.Value, LockAddress = output.ScriptHash, StartIndex = block.Index, EndIndex = emt.LockExpirationIndex, Timestamp = block.Timestamp, TxId = emt.Hash };
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.MutualLockInterestRecords).Add(key), SliceBuilder.Begin().Add(new MutualLockValue { TransactionType = emt.Type, TxId = emt.Hash }));
                }
            }
        }
        public static void Save_MutualLockRecordForEth(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, EthereumMapTransaction emt, TransactionOutput output)
        {
            if (emt.IsNotNull())
            {
                var recipient = emt.EthereumAddress.BuildMapAddress();
                if (miningProvider.MutualLockNodes.TryGetValue(recipient.GetMutualLockSeed(), out MutualNode miner))
                {
                    MutualLockKey key = new MutualLockKey { Owner = recipient, ParentOwner = miner.ParentHolder, AssetId = output.AssetId, Amount = output.Value, LockAddress = output.ScriptHash, StartIndex = block.Index, EndIndex = emt.LockExpirationIndex, Timestamp = block.Timestamp, TxId = emt.Hash };
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.MutualLockRecords).Add(key), SliceBuilder.Begin().Add(new MutualLockValue { TransactionType = emt.Type, TxId = emt.Hash }));
                    batch.Save_TotalLockVolume(miningProvider, output.AssetId, recipient, output.Value, block.Index, emt.LockExpirationIndex);
                }
            }
        }
        public static void Save_MutualLockInterestRecord(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, IssueTransaction ist, TransactionOutput output)
        {
            if (ist.IsNotNull())
            {
                if (miningProvider.MutualLockNodes.TryGetValue(output.ScriptHash.GetMutualLockSeed(), out MutualNode miner))
                {
                    MutualLockInterestKey key = new MutualLockInterestKey { Owner = miner.HolderAddress, ParentOwner = miner.ParentHolder, AssetId = output.AssetId, Amount = output.Value, LockAddress = output.ScriptHash, StartIndex = block.Index, EndIndex = 0, Timestamp = block.Timestamp, TxId = ist.Hash };
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.MutualLockInterestRecords).Add(key), SliceBuilder.Begin().Add(new MutualLockValue { TransactionType = ist.Type, TxId = ist.Hash }));
                }
            }
        }
        public static void Save_MutualLockMiningAssetReply(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, ReplyTransaction rt, MutualLockMiningAssetReply reply)
        {
            if (reply.IsNotNull())
            {
                batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.MutualLockMiningAssetReply).Add(new MutualLockMiningAssetKey { AssetId = reply.AssetId, IssueIndex = block.Index }), SliceBuilder.Begin().Add(reply));
                miningProvider.MutualLockAssets[reply.AssetId] = reply;
            }
        }
        public static void Save_TotalLockVolume(this WriteBatch batch, MiningBlockIndex miningProvider, UInt256 assetId, UInt160 holder, Fixed8 value, uint startIndex, uint endIndex)
        {
            TotalLockVolumeKey key = new TotalLockVolumeKey { AssetId = assetId, Holder = holder };
            var lw = miningProvider.Get<LongWrapper>(InvestBizPersistencePrefixes.TotalMutualLockSpaceTimeLockVolume, key);
            if (lw.IsNull())
            {
                lw = new LongWrapper();
            }
            lw.Value += MutualLockMiningHelper.CalculateValidSpaceTimeVolume(value, startIndex, endIndex);
            batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.TotalMutualLockSpaceTimeLockVolume).Add(key), SliceBuilder.Begin().Add(lw));
        }
        public static void Save_LockMiningRecords(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, LockAssetTransaction lat, ushort k, TransactionOutput output, UInt160 recipient)
        {
            if (lat.IsNotNull())
            {
                if (miningProvider.MutualLockNodes.TryGetValue(recipient.GetMutualLockSeed(), out MutualNode miner))
                {
                    SelfLockKey key = new SelfLockKey { AssetId = output.AssetId, Holder = recipient, TxId = lat.Hash };
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.LockMiningRecords).Add(key), SliceBuilder.Begin().Add(new LockMiningRecordMerge { AssetId = output.AssetId, TransactionType = lat.Type, TxId = lat.Hash, K = k, Index = block.Index, Timestamp = block.Timestamp, LockExpiration = lat.LockExpiration, Output = output }));
                    batch.Save_TotalLockVolume(miningProvider, output.AssetId, recipient, output.Value, block.Index, lat.LockExpiration);
                }
            }
        }
        public static void Save_LockMiningOXSTotal(this WriteBatch batch, MiningBlockIndex miningProvider, UInt160 Holder, Block block, LockAssetTransaction lat, ushort k, TransactionOutput output)
        {
            if (lat.IsNotNull())
            {
                var amount = miningProvider.Get<Fixed8>(InvestBizPersistencePrefixes.LockMiningOXSTotal, Holder);
                if (amount == default)
                    amount = Fixed8.Zero;
                var l = (output.Value.GetInternalValue() / Fixed8.D) * (lat.LockExpiration - block.Index);
                var amt = amount + new Fixed8(l);
                batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.LockMiningOXSTotal).Add(Holder), SliceBuilder.Begin().Add(amt));
            }
        }
        public static void Save_LockMiningInterestRecords(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, LockAssetTransaction lat, ushort k, TransactionOutput output, UInt160 recipient)
        {
            if (lat.IsNotNull())
            {

                if (miningProvider.MutualLockNodes.TryGetValue(recipient.GetMutualLockSeed(), out MutualNode miner))
                {
                    SelfLockKey key = new SelfLockKey { AssetId = output.AssetId, Holder = recipient, TxId = lat.Hash };
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.LockMiningInterestRecords).Add(key), SliceBuilder.Begin().Add(new LockMiningRecordMerge { AssetId = output.AssetId, TransactionType = lat.Type, TxId = lat.Hash, K = k, Index = block.Index, Timestamp = block.Timestamp, LockExpiration = lat.LockExpiration, Output = output }));
                }
            }
        }
        public static void Save_MutualLockRecord(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, LockAssetTransaction lat, TransactionOutput output, UInt160 recipient)
        {
            if (lat.IsNotNull())
            {
                if (miningProvider.MutualLockNodes.TryGetValue(recipient.GetMutualLockSeed(), out MutualNode miner))
                {
                    MutualLockKey key = new MutualLockKey { Owner = recipient, ParentOwner = miner.ParentHolder, AssetId = output.AssetId, Amount = output.Value, LockAddress = output.ScriptHash, StartIndex = block.Index, EndIndex = lat.LockExpiration, Timestamp = block.Timestamp, TxId = lat.Hash };
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.MutualLockRecords).Add(key), SliceBuilder.Begin().Add(new MutualLockValue { TransactionType = lat.Type, TxId = lat.Hash }));
                    batch.Save_TotalLockVolume(miningProvider, output.AssetId, recipient, output.Value, block.Index, lat.LockExpiration);
                }
            }
        }

        public static void Save_MutualLockNodeForEth(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, Transaction tx, TransactionOutput output, MutualNode parentNode, string ethAddress)
        {
            var from = ethAddress.BuildMapAddress();
            var seedSH = from.GetMutualLockSeed();
            if (!miningProvider.MutualLockNodes.ContainsKey(seedSH))
            {
                byte nodeType = (byte)(output.ScriptHash.Equals(MutualLockMiningHelper.GenesisSeed()) ? 1 : 0);
                var node = new MutualNode { HolderAddress = from, RegIndex = block.Index, NodeType = nodeType, RootSeedAddress = parentNode.IsNotNull() ? parentNode.RootSeedAddress : seedSH, ParentHolder = parentNode.IsNotNull() ? parentNode.HolderAddress : invest.MasterAccountAddress, IsEthMap = true };
                batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.MutualLockNode).Add(seedSH), SliceBuilder.Begin().Add(node));
                miningProvider.MutualLockNodes[seedSH] = node;

            }
        }
        public static void Save_MutualLockNode(this WriteBatch batch, MiningBlockIndex miningProvider, Block block, Transaction tx, TransactionOutput output, MutualNode parentNode)
        {
            var fromPubKey = tx.GetBestWitnessPublicKey();
            if (fromPubKey.IsNotNull())
            {
                var from = Contract.CreateSignatureRedeemScript(fromPubKey).ToScriptHash();
                var seedSH = from.GetMutualLockSeed();
                if (!miningProvider.MutualLockNodes.ContainsKey(seedSH))
                {
                    byte nodeType = (byte)(output.ScriptHash.Equals(MutualLockMiningHelper.GenesisSeed()) ? 1 : 0);
                    var node = new MutualNode { HolderAddress = from, RegIndex = block.Index, NodeType = nodeType, RootSeedAddress = parentNode.IsNotNull() ? parentNode.RootSeedAddress : seedSH, ParentHolder = parentNode.IsNotNull() ? parentNode.HolderAddress : invest.MasterAccountAddress, IsEthMap = false };
                    batch.Put(SliceBuilder.Begin(InvestBizPersistencePrefixes.MutualLockNode).Add(seedSH), SliceBuilder.Begin().Add(node));
                    miningProvider.MutualLockNodes[seedSH] = node;
                }
            }
        }
    
    }
}
