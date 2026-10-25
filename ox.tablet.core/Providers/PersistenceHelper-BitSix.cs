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
using System.ComponentModel;
using System.Collections.Generic;
using OX.IO.Wrappers;

namespace OX.Tablet
{
    public static partial class CasinoPersistenceHelper
    {
        public static void Save_Web3Node(this WriteBatch batch, BMSBlockIndex provider, Block block, ReplyTransaction rt, Web3NodeSet web3NodeSet)
        {
            if (web3NodeSet.IsNotNull() && web3NodeSet.Nodes.IsNotNullAndEmpty())
            {
                foreach (var node in web3NodeSet.Nodes)
                {
                    var ts = (UInt32Wrapper)block.Timestamp;
                    batch.Put(SliceBuilder.Begin(CasinoBizPersistencePrefixes.Casino_Web3Node_Publish).Add(node), SliceBuilder.Begin().Add(ts.ToArray()));
                    if (!provider.Web3Nodes.TryGetValue(node.Catalog, out var dic))
                    {
                        dic = new Dictionary<string, uint>();
                        provider.Web3Nodes[node.Catalog] = dic;
                    }
                    dic[$"{node.NodeAddress}:{node.Port}"] = block.Timestamp;
                }
            }
        }
        public static void Save_MarkMember(this WriteBatch batch, BMSBlockIndex provider, MixMarkMember member)
        {
            batch.Put(SliceBuilder.Begin(CasinoBizPersistencePrefixes.Mark_Member).Add(member.Holder), SliceBuilder.Begin().Add(member));
            provider.MarkMembers[member.Holder] = member;

        }

        public static void Save_LastBitSixBankerId(this WriteBatch batch, LastBitSixBankerId lastBitSixBankerId)
        {
            batch.Put(SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_Last_BankerId).Add(casino.CasinoMasterAccountAddress), SliceBuilder.Begin().Add(lastBitSixBankerId));
        }
        public static void Save_LastBitSixMemberId(this WriteBatch batch, LastBitSixMemberId lastBitSixMemberId)
        {
            batch.Put(SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_Last_MemberId).Add(casino.CasinoMasterAccountAddress), SliceBuilder.Begin().Add(lastBitSixMemberId));
        }

        public static void Save_GuessAnswer(this WriteBatch batch, BMSBlockIndex provider, Block block, GuessAnswerReply guessAnswerReply)
        {
            GuessAnswerKey macauKey = new GuessAnswerKey { Term = guessAnswerReply.MacauAnswer.Term, ChannelRound = new MarkChannelRound { Channel = BetChannel.MarkSix, Round = (byte)MarkSixRound.MarkMacau } };
            batch.Put(SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_GuessAnswer).Add(macauKey), SliceBuilder.Begin().Add(guessAnswerReply.MacauAnswer.Answer));
            provider.GuessAnswers[macauKey.ToString()] = new GuessAnswer { Term = guessAnswerReply.MacauAnswer.Term, Answer = guessAnswerReply.MacauAnswer.Answer };

            var unionAnswerValue = guessAnswerReply.GetUnionAnswer(block.ConsensusData);
            GuessAnswerKey unionKey = new GuessAnswerKey { Term = guessAnswerReply.Term, ChannelRound = new MarkChannelRound { Channel = BetChannel.MarkSix, Round = (byte)MarkSixRound.MarkUnion } };
            batch.Put(SliceBuilder.Begin(CasinoBizPersistencePrefixes.BMS_GuessAnswer).Add(unionKey), SliceBuilder.Begin().Add(unionAnswerValue));
            provider.GuessAnswers[unionKey.ToString()] = new GuessAnswer { Term = guessAnswerReply.Term, Answer = unionAnswerValue };
        }
         
    }
}
