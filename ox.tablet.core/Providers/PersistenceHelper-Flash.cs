using OX;
using OX.Bapps;
using OX.BMS;
using OX.Casino;
using OX.Cryptography;
using OX.DirectSales;
using OX.IO;
using OX.IO.Data.LevelDB;
using OX.IO.Wrappers;
using OX.Ledger;
using OX.Network.P2P;
using OX.Network.P2P.Payloads;
using OX.Persistence;
using OX.SmartContract;
using OX.Tablet.Flash;
using OX.VM;
using OX.Wallets;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using static Akka.Actor.ProviderSelection;

namespace OX.Tablet
{
    public static partial class FlashPersistenceHelper
    {
        public static void Save_FlashState(this WriteBatch batch, FlashBlockIndex provider, FlashState fs)
        {
            if (fs.IsNotNull())
            {
                var sh = fs.Author;
                if (!provider.FlashStateCount.TryGetValue(sh, out UInt32Wrapper count))
                {
                    count = (UInt32Wrapper)0;
                    provider.FlashStateCount[sh] = count;
                }
                var c = (uint)count;
                c++;
                count = (UInt32Wrapper)c;
                batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashState_LatestCount).Add(sh), SliceBuilder.Begin().Add(count as ISerializable));
                if (!provider.FlashStateCount.TryGetValue(UInt160.Zero, out UInt32Wrapper zerocount))
                {
                    zerocount = (UInt32Wrapper)0;
                    provider.FlashStateCount[UInt160.Zero] = zerocount;
                }
                var zc = (uint)zerocount;
                zc++;
                zerocount = (UInt32Wrapper)zc;
                batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashState_LatestCount).Add(UInt160.Zero), SliceBuilder.Begin().Add(zerocount as ISerializable));

                SenderFlashStateKey fsk = new SenderFlashStateKey { FSHash = fs.Hash, Range = (uint)count / FlashMemoryHelper.RangeSize, Sender = sh };
                GlobalFlashStateKey gfsk = new GlobalFlashStateKey { FSHash = fs.Hash, Range = (uint)zerocount / FlashMemoryHelper.RangeSize };
                var fsr = new FlashStateRecord { FlashState = fs, Timestamp = DateTime.Now.ToTimestamp(), CommentCount = 0 };
                batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashState_Record).Add(fs.Hash), SliceBuilder.Begin().Add(fsr));
                batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashState_SenderRecord).Add(fsk), SliceBuilder.Begin().Add(fs.Hash));
                batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashState_GlobalRecord).Add(gfsk), SliceBuilder.Begin().Add(fs.Hash));
                foreach (var tag in fs.Tags)
                {
                    if (!provider.FlashStateTagCount.TryGetValue(tag, out UInt32Wrapper tagcount))
                    {
                        tagcount = (UInt32Wrapper)0;
                        provider.FlashStateTagCount[tag] = tagcount;
                    }
                    var tc = (uint)tagcount;
                    tc++;
                    tagcount = (UInt32Wrapper)tc;
                    batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashState_TagCount).Add(tag), SliceBuilder.Begin().Add(tagcount as ISerializable));
                    TagFlashStateKey tfsk = new TagFlashStateKey { FSHash = fs.Hash, Range = (uint)tagcount / FlashMemoryHelper.RangeSize, Tag = tag };
                    batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashState_TagRecord).Add(tfsk), SliceBuilder.Begin().Add(fs.Hash));
                }
            }
        }
        public static void Save_FlashStateComment(this WriteBatch batch, FlashBlockIndex provider, FlashStateComment fsc)
        {
            if (fsc.IsNotNull())
            {
                var sh = fsc.Author;
                foreach (var comment in fsc.Comments)
                {
                    var fs = provider.Get<FlashStateRecord>(FlashStatePersistencePrefixes.FlashState_Record, comment.StateHash);
                    if (fs.IsNotNull())
                    {
                        var ts = DateTime.Now.ToTimestamp();
                        FlashStateCommentKey fsck = new FlashStateCommentKey { FSHash = comment.StateHash, ParentCommentHash = comment.ParentCommentHash, CommentHash = comment.Hash };
                        FlashStateCommentValue fscv = new FlashStateCommentValue { Sender = sh, Data = comment.Data, Timestamp = ts };
                        batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashStateComment_Record).Add(fsck), SliceBuilder.Begin().Add(fscv));
                        var fsr = provider.GetFlashStatRecord(comment.StateHash);
                        if (fsr.IsNotNull())
                        {
                            fsr.CommentCount++;
                            provider.FlashStateCommentCount[comment.StateHash] = new CommentCountValue { Count = (UInt32Wrapper)fsr.CommentCount, Timestamp = ts };
                            batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashState_Record).Add(comment.StateHash), SliceBuilder.Begin().Add(fsr));
                            provider.CropCommentCount();
                        }
                    }
                }
            }
        }
        public static void Save_FlashMulticast(this WriteBatch batch, FlashBlockIndex provider, FlashMulticast fm, TalkKind TalkKind)
        {
            if (fm.IsNotNull())
            {
                if (!provider.TalkCount.TryGetValue(fm.TalkLine, out UInt32Wrapper count))
                {
                    count = (UInt32Wrapper)0;
                    provider.TalkCount[fm.TalkLine] = count;
                }
                var c = (uint)count;
                c++;
                count = (UInt32Wrapper)c;
                batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashTalk_Count).Add(fm.TalkLine), SliceBuilder.Begin().Add(count as ISerializable));

                TalkLineKey tlk = new TalkLineKey { FMHash = fm.Hash, Range = (uint)count / FlashMemoryHelper.RangeSize, TalkKind = TalkKind, TalkLine = fm.TalkLine };
                var fmr = new FlashMulticastRecord { FlashMulticast = fm, Timestamp = DateTime.Now.ToTimestamp(), RecordIndex = (uint)count };
                batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashMulticast_Record).Add(tlk), SliceBuilder.Begin().Add(fmr));
                FlashMemoryHelper.MulticastQueue.Enqueue(new Tuple<TalkLineKey, FlashMulticastRecord>(tlk, fmr));
            }
        }
        public static void Clear_FlashMulticast(this FlashBlockIndex provider, UInt256 talkLine)
        {
            if (talkLine.IsNotNull())
            {
                provider.Do(batch =>
                {
                    var rs = provider.GetAllMulticastRecords(talkLine);
                    if (rs.IsNotNullAndEmpty())
                    {
                        foreach (var r in rs)
                            batch.Delete(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashMulticast_Record).Add(r.Key));
                    }
                });
            }
        }
        public static void Clear_FlashUnicast(this FlashBlockIndex provider, UInt256 talkLine)
        {
            if (talkLine.IsNotNull())
            {
                provider.Do(batch =>
                {
                    var rs = provider.GetAllUnicastRecords(talkLine);
                    if (rs.IsNotNullAndEmpty())
                    {
                        foreach (var r in rs)
                            batch.Delete(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashUnicast_Record).Add(r.Key));
                    }
                });
            }
        }
        public static void Save_FlashUnicast(this WriteBatch batch, FlashBlockIndex provider, UInt160 myScriptHash, FlashUnicast fu, TalkKind TalkKind)
        {
            if (fu.IsNotNull())
            {
                if (!provider.TalkCount.TryGetValue(fu.TalkLine, out UInt32Wrapper count))
                {
                    count = (UInt32Wrapper)0;
                    provider.TalkCount[fu.TalkLine] = count;
                }
                var c = (uint)count;
                c++;
                count = (UInt32Wrapper)c;
                batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashTalk_Count).Add(fu.TalkLine), SliceBuilder.Begin().Add(count as ISerializable));

                TalkLineKey tlk = new TalkLineKey { FMHash = fu.Hash, Range = (uint)count / FlashMemoryHelper.RangeSize, TalkKind = TalkKind, TalkLine = fu.TalkLine };
                var fur = new FlashUnicastRecord { FlashUnicast = fu, Timestamp = DateTime.Now.ToTimestamp(), RecordIndex = (uint)count };
                batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashUnicast_Record).Add(tlk), SliceBuilder.Begin().Add(fur));
                FlashMemoryHelper.UnicastQueue.Enqueue(new Tuple<TalkLineKey, FlashUnicastRecord>(tlk, fur));
                if (TalkKind == TalkKind.Inbox)
                {
                    //if (!provider.UnicastTalkLines.TryGetValue(fu.TalkLine, out UnicastTalkLineValue utlv))
                    //{
                    string label = string.Empty;
                    var remoteSh = Contract.CreateSignatureRedeemScript(fu.Sender).ToScriptHash();
                    var dmbs = FlashMessageHelper.GetDomain(remoteSh);
                    if (dmbs.IsNotNullAndEmpty())
                    {
                        label = System.Text.Encoding.UTF8.GetString(dmbs);
                    }
                    var utlv = new UnicastTalkLineValue { Local = myScriptHash, Remote = fu.Sender, Label = label };
                    batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashUnicast_TalkLine).Add(fu.TalkLine), SliceBuilder.Begin().Add(utlv));
                    provider.UnicastTalkLines[fu.TalkLine] = utlv;
                    //}
                }
            }
        }
        public static (UInt256 talkLine, MulticastTalkLineValue utlv) Save_MulticastTalkLine(this WriteBatch batch, FlashBlockIndex provider, UInt160 localAddress, byte[] shareKey, string msg, uint level = 0)
        {
            var talkLine = new UInt256(Crypto.Default.Hash256(Crypto.Default.Hash256(shareKey)));
            MulticastTalkLineValue baw = new MulticastTalkLineValue { Local = localAddress, Key = shareKey, Label = msg, Level = level };
            batch.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashMulticast_TalkLine).Add(talkLine), SliceBuilder.Begin().Add(baw));
            provider.MulticastTalkLines[talkLine] = baw;
            return (talkLine, baw);
        }
    }
}
