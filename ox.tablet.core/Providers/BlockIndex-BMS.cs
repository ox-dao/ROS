using Akka.Util;
using OX.Bapps;
using OX.IO;
using OX.IO.Data.LevelDB;
using OX.IO.Wrappers;
using OX.Ledger;
using OX.Network.P2P.Payloads;
using OX.Wallets;
using OX.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using OX.Tablet.Models;
using OX.Cryptography.ECC;
using OX.BMS;
using OX.Casino;
using Akka.Actor;
using OX.SmartContract;


namespace OX.Tablet
{
    public class BMSBlockIndex : BaseSubBlockIndex
    {
        public const string IndexKey = "Data_BMSIndex";
        public override bool CanRebuild => true;
        public BMSBlockIndex(BlockIndex blockIndex, OXAccount oxAccount, EthAccount ethAccount) : base(blockIndex, oxAccount, ethAccount, IndexKey)
        {
            var LBS = this.Get<LastBitSixBankerId>(CasinoBizPersistencePrefixes.BMS_Last_BankerId, casino.CasinoMasterAccountAddress);
            if (LBS.IsNull())
            {
                LBS = new LastBitSixBankerId { BitSixBankerId = 8000 };
            }
            this.LastBitSixBankerId = LBS;
            this.MarkMembers = new Dictionary<UInt160, MixMarkMember>(this.GetAll<UInt160, MixMarkMember>(CasinoBizPersistencePrefixes.Mark_Member));


            foreach (var ga in this.GetAll<GuessAnswerKey, GuessAnswerValue>(CasinoBizPersistencePrefixes.BMS_GuessAnswer))
            {
                this.GuessAnswers[ga.Key.ToString()] = new GuessAnswer { Term = ga.Key.Term, Answer = ga.Value };
            }
            foreach (var ga in this.GetAll<Web3Node, UInt32Wrapper>(CasinoBizPersistencePrefixes.Casino_Web3Node_Publish).GroupBy(m => m.Key.Catalog))
            {
                if (!Web3Nodes.TryGetValue(ga.Key, out var dic))
                {
                    dic = new Dictionary<string, uint>();
                    Web3Nodes[ga.Key] = dic;
                }
                foreach (var node in ga)
                {
                    dic[$"{node.Key.NodeAddress}:{node.Key.Port}"] = node.Value;
                }
            }
        }
        public LastBitSixBankerId LastBitSixBankerId { get; private set; } = new LastBitSixBankerId { BitSixBankerId = 8000 };

        /// <summary>
        /// key is  member holder address
        /// </summary>
        public Dictionary<UInt160, MixMarkMember> MarkMembers { get; private set; } = new Dictionary<UInt160, MixMarkMember>();
        public MixMarkMember[] AllMarkMembers
        {
            get
            {
                return MarkMembers.Values.ToArray();
            }
        }
        
        public Dictionary<string, GuessAnswer> GuessAnswers { get; private set; } = new Dictionary<string, GuessAnswer>();
        public Dictionary<ushort, Dictionary<string, uint>> Web3Nodes = new Dictionary<ushort, Dictionary<string, uint>>();
        public override void Rebuild()
        {
            this.MarkMembers.Clear();
            this.GuessAnswers.Clear();
            this.Web3Nodes.Clear();
            base.Rebuild();
            this.LastBitSixBankerId = new LastBitSixBankerId { BitSixBankerId = 8000 };
        }
        public override void HandleBlock(Block block)
        {
            WriteBatch batch = new WriteBatch();
            BlockContext context = new BlockContext();
            for (ushort i = 0; i < block.Transactions.Length; i++)
            {
                var tx = block.Transactions[i];
                if (this.IsBizTransaction(tx, casino.CasinoMasterAccountAddress, out BizTransaction biztx))
                {
                    ushort? n = null;
                    if (biztx is BillTransaction bt)
                    {

                    }
                    else if (biztx is ReplyTransaction rt)
                    {
                        this.OnMarkReplayTransaction(batch, context, block, rt, i);
                    }
                    else if (biztx is AskTransaction at)
                    {
                        this.OnMarkAskTransaction(batch, context, block, at, i, out n);
                    }
                }
                else if (tx is LockAssetTransaction lat)
                {
                }
                else if (tx is IssueTransaction ist)
                {
                }
                else if (tx is SlotSideTransaction st)
                {
                    OnSlotSideTransaction(batch, block, st);
                }
                else if (tx is RangeTransaction rgt)
                {

                }
                //WatchBitMarkSixBanker(batch, block, tx);
            }
            this.Db.Write(WriteOptions.Default, batch);
        }

        public void OnMarkReplayTransaction(WriteBatch batch, BlockContext context, Block block, ReplyTransaction rt, ushort txindex)
        {
            IReadOnlyDictionary<CoinReference, TransactionOutput> rfs = rt.References;
            var shs = rfs.Values.GroupBy(m => m.ScriptHash).Select(n => n.Key.ToAddress());
            var bizshs = new UInt160[] { casino.CasinoMasterAccountAddress };

            //1.验证Tip标签的真实性,不真实则返回不做后续处理
            switch (rt.DataType)
            {
                case (byte)CasinoType.MarkSupportService:
                    if (rt.GetDataModel<MarkSupportReply>(bizshs, (byte)CasinoType.MarkSupportService, out MarkSupportReply msr))
                    {
                        batch.Put(SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_Support_Service).Add(0), SliceBuilder.Begin().Add(msr));
                    }
                    break;
             
                case (byte)CasinoType.MarkGuessAnswer:
                    if (rt.GetDataModel<GuessAnswerReply>(bizshs, (byte)CasinoType.MarkGuessAnswer, out GuessAnswerReply guessAnswerReply))
                    {
                        batch.Save_GuessAnswer(this, block, guessAnswerReply);
                    }
                    break;
                case (byte)CasinoType.CasinoWeb3NodePublish:
                    if (rt.GetDataModel<Web3NodeSet>(bizshs, (byte)CasinoType.CasinoWeb3NodePublish, out Web3NodeSet web3NodeSet))
                    {
                        batch.Save_Web3Node(this, block, rt, web3NodeSet);
                    }
                    break;
                case (byte)CasinoType.MarkPortTermClear:
                    if (rt.GetDataModel<MarkPortTermClear>(bizshs, (byte)CasinoType.MarkPortTermClear, out MarkPortTermClear portTermClear))
                    {
                        foreach (var output in rt.Outputs)
                        {
                            if (output.AssetId == Blockchain.OXC)
                            {
                                if (this.MarkMembers.TryGetValue(output.ScriptHash, out var playMember))
                                {
                                    var amt = output.Value.GetInternalValue() / Fixed8.D;
                                    playMember.TotalPrizeAmount += (ulong)amt;
                                    batch.Save_MarkMember(this, playMember);
                                }
                            }
                        }
                    }
                    break;
            }

        }
        public void OnSlotSideTransaction(WriteBatch batch, Block block, SlotSideTransaction st)
        {
            if (st.VerifyRegMarkMember(out ECPoint bankerholderPubKey))
            {
                if (st.VerifyRegBitSixBankerRequest(out RegMarkMemberRequest request))
                {
                    var feesetting = this.MasterBlockIndex.GetSubBlockIndex<CasinoBlockIndex>().GetCasinoSetting(CasinoSettingTypes.MemberRegFee);
                    if (feesetting.IsNullOrEmpty()) return;

                    var fee = uint.Parse(feesetting);

                    if (st.VerifyRegMarkMemberFee(request, fee))
                    {
                        var betSH = st.GetContract().ScriptHash;
                        var addr = Contract.CreateSignatureRedeemScript(bankerholderPubKey).ToScriptHash();
                        if (!this.MarkMembers.TryGetValue(addr, out MixMarkMember member))
                        {
                            if ((this.MarkMembers.TryGetValue(request.LeaderHolder, out var leadMember) && leadMember.Request.MemberType == MarkMemberType.Banker)||addr == MarkBetAddressHelper.Instance.MarkAdmin)
                            {
                                this.LastBitSixBankerId.BitSixBankerId++;
                                batch.Save_LastBitSixBankerId(this.LastBitSixBankerId);
                                member = new MixMarkMember
                                {
                                    MarkMemberId = this.LastBitSixBankerId.BitSixBankerId,
                                    BetAddress = betSH,
                                    PoolAddress = st.GetContractForOtherFlag(0x02, 0x01).ScriptHash,
                                    FeeAddress = st.GetContractForOtherFlag(0x02, 0x02).ScriptHash,
                                    PledgeAddress = st.GetContractForOtherFlag(0x02, 0x03).ScriptHash,
                                    DepositAddress = MarkBetAddressHelper.Instance.GetMemberDepositAddress(bankerholderPubKey, out _),
                                    Holder = addr,
                                    HolderPubkey = bankerholderPubKey,
                                    Request = request,
                                    LastTerm = block.Timestamp.GetBetTerm(),
                                    LastUpdateTimestamp = block.Timestamp
                                };

                                if (request.Data.TryAsSerializable<MarkSetting>(out var rms) && rms.Verify())
                                    member.MarkSetting = rms;
                                batch.Save_MarkMember(this, member);
                            }
                        }
                        else
                        {
                            member.Request = request;
                            if (request.Data.TryAsSerializable<MarkSetting>(out var rms) && rms.Verify())
                                member.MarkSetting = rms;
                            member.LastUpdateTimestamp = block.Timestamp;
                            batch.Save_MarkMember(this, member);
                        }
                    }
                }
            }
        }
        public void OnMarkAskTransaction(WriteBatch batch, BlockContext context, Block block, AskTransaction at, ushort txindex, out ushort? n)
        {

            n = null;
            IReadOnlyDictionary<CoinReference, TransactionOutput> rfs = at.References;
            var shs = rfs.Values.GroupBy(m => m.ScriptHash).Select(n => n.Key.ToAddress());
            var bizshs = new UInt160[] { casino.CasinoMasterAccountAddress };

            switch (at.DataType)
            {
                case (byte)CasinoType.PortMessage:
                    if (at.GetDataModel<PortMessage>(bizshs, (byte)CasinoType.PortMessage, out PortMessage portMessage))
                    {
                        if (at.From.Equals(this.OXAccount.Key.PublicKey))
                        {
                            PortMessageMix message = new PortMessageMix { Message = portMessage, BlockIndex = block.Index, TimeStamp = block.Timestamp };
                            batch.Put(SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_Port_Message).Add(at.Hash), SliceBuilder.Begin().Add(message));
                        }
                    }
                    break;

                case (byte)CasinoType.MarkBet:
                    if (at.GetDataModel<MarkBetOrder>(bizshs, (byte)CasinoType.MarkBet, out MarkBetOrder markorder))
                    {
                        var dt = markorder.Term.ToDateTime().AddSeconds(SecureHelper.GetMarkSixLastBetSeconds());
                        if (block.Timestamp > dt.AddDays(-1).ToTimestamp() && block.Timestamp < dt.ToTimestamp())
                        {
                            if (this.MarkMembers.TryGetValue(markorder.PortHolder, out var portMember))
                            {
                                var output = at.Outputs.FirstOrDefault(m => m.ScriptHash == portMember.BetAddress && m.AssetId == Blockchain.OXC);
                                if (output.IsNotNull() && output.Value >= Fixed8.One * markorder.Amount)
                                {
                                    var from = Contract.CreateSignatureRedeemScript(at.From).ToScriptHash();
                                    if (from == markorder.Player)
                                    {
                                        if (this.MarkMembers.TryGetValue(markorder.Player, out var playerMember))
                                        {
                                            var leaderHolder = playerMember.Request.LeaderHolder;
                                            //var leaderOk = leaderHolder == this.OXAccount.ScriptHash;
                                            var portOk = markorder.PortHolder == this.OXAccount.ScriptHash;
                                            var playerOk = markorder.Player == this.OXAccount.ScriptHash;
                                            if (markorder.PortHolder != markorder.Player)
                                            {
                                                if (portOk)
                                                {
                                                    PortMarkOrderTermKey key = new PortMarkOrderTermKey
                                                    {
                                                        Term = markorder.Term,
                                                        PlayerMemberId = playerMember.MarkMemberId,
                                                        PortHolder = markorder.Player,
                                                        TxId = at.Hash,
                                                        Timestamp = block.Timestamp
                                                    };
                                                    batch.Put(SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_Port_MarkOrder).Add(key), SliceBuilder.Begin().Add(markorder));
                                                }
                                                if (playerOk)
                                                {
                                                    PlayerMarkOrderTermKey key = new PlayerMarkOrderTermKey
                                                    {
                                                        Term = markorder.Term,
                                                        PortMemberId = portMember.MarkMemberId,
                                                        PortHolder = markorder.PortHolder,
                                                        TxId = at.Hash,
                                                        Timestamp = block.Timestamp
                                                    };
                                                    batch.Put(SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_Player_MarkOrder).Add(key), SliceBuilder.Begin().Add(markorder));
                                                }


                                                var amt = output.Value.GetInternalValue() / Fixed8.D;
                                                portMember.TotalBetAmount += markorder.Amount;
                                                if (portMember.LastTerm != markorder.Term)
                                                {
                                                    portMember.LastTerm = markorder.Term;
                                                    portMember.TermBetAmount = 0;
                                                }
                                                portMember.TermBetAmount += markorder.Amount;
                                                batch.Save_MarkMember(this, portMember);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }
        //public IEnumerable<KeyValuePair<MarkPortPlayerTermKey, MarkPortPlayerTermValue>> MarkPortPlayerTermRecords(MarkTerm Term, MarkChannelRound channelRouond, UInt160 PortHolder, UInt160 Leader = default, UInt160 Player = default)
        //{
        //    var builder = SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_PortPlayerTerm_Record).Add(Term).Add(channelRouond).Add(PortHolder);
        //    if (Leader.IsNotNull())
        //    {
        //        builder = builder.Add(Leader);
        //        if (Player.IsNotNull())
        //        {
        //            builder = builder.Add(Player);
        //        }
        //    }
        //    return this.Db.Find(ReadOptions.Default, builder, (k, v) =>
        //    {
        //        var ks = k.ToArray();
        //        var length = ks.Length - sizeof(byte);
        //        ks = ks.TakeLast(length).ToArray();
        //        byte[] data = v.ToArray();
        //        return new KeyValuePair<MarkPortPlayerTermKey, MarkPortPlayerTermValue>(ks.AsSerializable<MarkPortPlayerTermKey>(), data.AsSerializable<MarkPortPlayerTermValue>());
        //    });
        //}
        //public IEnumerable<KeyValuePair<MarkPortPlayerTermKey, MarkPortPlayerTermValue>> MarkTermAllRecords(MarkTerm Term, MarkChannelRound channelRouond)
        //{
        //    var builder = SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_PortPlayerTerm_Record).Add(Term).Add(channelRouond);

        //    return this.Db.Find(ReadOptions.Default, builder, (k, v) =>
        //    {
        //        var ks = k.ToArray();
        //        var length = ks.Length - sizeof(byte);
        //        ks = ks.TakeLast(length).ToArray();
        //        byte[] data = v.ToArray();
        //        return new KeyValuePair<MarkPortPlayerTermKey, MarkPortPlayerTermValue>(ks.AsSerializable<MarkPortPlayerTermKey>(), data.AsSerializable<MarkPortPlayerTermValue>());
        //    });
        //}

        //public IEnumerable<KeyValuePair<MarkDirectOrderTermKey, MarkDirectBetOrderMix>> MarkPlayerDirectOrderTermRecords(MarkTerm Term, UInt160 rivalHolder = default)
        //{
        //    var builder = SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_Player_DirectOrder).Add(Term);
        //    if (rivalHolder.IsNotNull())
        //    {
        //        builder = builder.Add(rivalHolder);
        //    }
        //    return this.Db.Find(ReadOptions.Default, builder, (k, v) =>
        //    {
        //        var ks = k.ToArray();
        //        var length = ks.Length - sizeof(byte);
        //        ks = ks.TakeLast(length).ToArray();
        //        byte[] data = v.ToArray();
        //        return new KeyValuePair<MarkDirectOrderTermKey, MarkDirectBetOrderMix>(ks.AsSerializable<MarkDirectOrderTermKey>(), data.AsSerializable<MarkDirectBetOrderMix>());
        //    });
        //}
        //public IEnumerable<KeyValuePair<MarkDirectOrderTermKey, MarkDirectBetOrderMix>> MarkPortDirectOrderTermRecords(MarkTerm Term, UInt160 rivalHolder = default)
        //{
        //    var builder = SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_Port_DirectOrder).Add(Term);
        //    if (rivalHolder.IsNotNull())
        //    {
        //        builder = builder.Add(rivalHolder);
        //    }
        //    return this.Db.Find(ReadOptions.Default, builder, (k, v) =>
        //    {
        //        var ks = k.ToArray();
        //        var length = ks.Length - sizeof(byte);
        //        ks = ks.TakeLast(length).ToArray();
        //        byte[] data = v.ToArray();
        //        return new KeyValuePair<MarkDirectOrderTermKey, MarkDirectBetOrderMix>(ks.AsSerializable<MarkDirectOrderTermKey>(), data.AsSerializable<MarkDirectBetOrderMix>());
        //    });
        //}
        //public IEnumerable<KeyValuePair<DirectPortPayRequesst, TransactionOutput>> MarkPortDirectPayRecords(MarkTerm Term, MarkChannelRound channelRound, UInt160 player = default)
        //{
        //    var builder = SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_Port_DirectPay).Add(Term).Add(channelRound);
        //    if (player.IsNotNull())
        //    {
        //        builder = builder.Add(player);
        //    }
        //    return this.Db.Find(ReadOptions.Default, builder, (k, v) =>
        //    {
        //        var ks = k.ToArray();
        //        var length = ks.Length - sizeof(byte);
        //        ks = ks.TakeLast(length).ToArray();
        //        byte[] data = v.ToArray();
        //        return new KeyValuePair<DirectPortPayRequesst, TransactionOutput>(ks.AsSerializable<DirectPortPayRequesst>(), data.AsSerializable<TransactionOutput>());
        //    });
        //}
        //public IEnumerable<KeyValuePair<DirectPortPayRequesst, TransactionOutput>> MarkPlayerDirectPayRecords(MarkTerm Term, MarkChannelRound channelRound = default)
        //{
        //    var builder = SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_Player_DirectPay).Add(Term);
        //    if (channelRound.IsNotNull())
        //    {
        //        builder = builder.Add(channelRound);
        //    }
        //    return this.Db.Find(ReadOptions.Default, builder, (k, v) =>
        //    {
        //        var ks = k.ToArray();
        //        var length = ks.Length - sizeof(byte);
        //        ks = ks.TakeLast(length).ToArray();
        //        byte[] data = v.ToArray();
        //        return new KeyValuePair<DirectPortPayRequesst, TransactionOutput>(ks.AsSerializable<DirectPortPayRequesst>(), data.AsSerializable<TransactionOutput>());
        //    });
        //}


    }
}
