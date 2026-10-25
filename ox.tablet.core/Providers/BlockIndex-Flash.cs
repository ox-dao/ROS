using Akka.Actor;
using Akka.Util;
using OX.Bapps;
using OX.BMS;
using OX.Casino;
using OX.Cryptography;
using OX.Cryptography.ECC;
using OX.DirectSales;
using OX.IO;
using OX.IO.Data.LevelDB;
using OX.IO.Wrappers;
using OX.Ledger;
using OX.Mining;
using OX.Network.P2P.Payloads;
using OX.Persistence;
using OX.SmartContract;
using OX.Tablet.Flash;
using OX.Tablet.Models;
using OX.Wallets;
using Sunny.UI.Win32;
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
    public class FlashBlockIndex : BaseSubBlockIndex
    {
        public const string IndexKey = "Data_FlashIndex";
        public override bool CanRebuild => false;
        public IFlashStateFilter LogFilter { get; private set; }
        public IFlashUnicastFilter UniFilter { get; private set; }
        public IFlashMulticastFilter MultiFilter { get; private set; }
        public Dictionary<UInt256, UnicastTalkLineValue> UnicastTalkLines = new Dictionary<UInt256, UnicastTalkLineValue>();
        public Dictionary<UInt256, MulticastTalkLineValue> MulticastTalkLines = new Dictionary<UInt256, MulticastTalkLineValue>();
        public Dictionary<UInt256, UInt32Wrapper> TalkCount = new Dictionary<UInt256, UInt32Wrapper>();
        public Dictionary<UInt160, UInt32Wrapper> FlashStateCount = new Dictionary<UInt160, UInt32Wrapper>();
        public Dictionary<FlashStateTag, UInt32Wrapper> FlashStateTagCount = new Dictionary<FlashStateTag, UInt32Wrapper>();
        public Dictionary<UInt256, CommentCountValue> FlashStateCommentCount = new Dictionary<UInt256, CommentCountValue>();
        //public Dictionary<StringWrapper, NFTPendingRecord> NFTPendings = new Dictionary<StringWrapper, NFTPendingRecord>();
        public FlashBlockIndex(BlockIndex blockIndex, OXAccount oxAccount, EthAccount ethAccount) : base(blockIndex, oxAccount, ethAccount, IndexKey)
        {
            UnicastTalkLines = new Dictionary<UInt256, UnicastTalkLineValue>(this.GetAll<UInt256, UnicastTalkLineValue>(FlashStatePersistencePrefixes.FlashUnicast_TalkLine));
            MulticastTalkLines = new Dictionary<UInt256, MulticastTalkLineValue>(this.GetAll<UInt256, MulticastTalkLineValue>(FlashStatePersistencePrefixes.FlashMulticast_TalkLine));
            TalkCount = new Dictionary<UInt256, UInt32Wrapper>(this.GetAll<UInt256, UInt32Wrapper>(FlashStatePersistencePrefixes.FlashTalk_Count));
            FlashStateCount = new Dictionary<UInt160, UInt32Wrapper>(this.GetAll<UInt160, UInt32Wrapper>(FlashStatePersistencePrefixes.FlashState_LatestCount));
            FlashStateTagCount = new Dictionary<FlashStateTag, UInt32Wrapper>(this.GetAll<FlashStateTag, UInt32Wrapper>(FlashStatePersistencePrefixes.FlashState_TagCount));
            //NFTPendings = new Dictionary<StringWrapper, NFTPendingRecord>(this.GetAll<StringWrapper, NFTPendingRecord>(FlashStatePersistencePrefixes.Flash_NFTPendingRecord));


            var rothschild_talkLine = ECDiffieHellmanHelper.ECDHDeriveKeyHash(SecureHelper.MasterAccount.Key, invest.RothschildAccountPubKey);
            if (!UnicastTalkLines.ContainsKey(rothschild_talkLine))
            {
                Do(wb =>
                {
                    var rothschild = new UnicastTalkLineValue { Local = SecureHelper.MasterAccount.ScriptHash, Remote = invest.RothschildAccountPubKey, Label = "rothschild" };
                    wb.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashUnicast_TalkLine).Add(rothschild_talkLine), SliceBuilder.Begin().Add(rothschild));
                    this.UnicastTalkLines[rothschild_talkLine] = rothschild;
                });
            }
          

        }

        public override void Rebuild()
        {
            base.Rebuild();
        }
        public override void HandleBlock(Block block)
        {

        }
        public bool OnFlashMessage(FlashMessage flashMessage)
        {
            bool ret = false;
            if (!FlashMemoryHelper.FlashHashs.Contains(flashMessage.Hash))
            {
                FlashMemoryHelper.FlashHashs.Enqueue(flashMessage.Hash);
                switch (flashMessage.Type)
                {
                    case FlashMessageType.FlashState:
                        FlashState fs = flashMessage as FlashState;
                        if (fs.IsNotNull() && (this.LogFilter.IsNull() || this.LogFilter.StateInputFilter(fs)))
                            Do(wb =>
                            {
                                wb.Save_FlashState(this, fs);
                            });
                        break;
                    case FlashMessageType.FlashStateComment:
                        FlashStateComment fsc = flashMessage as FlashStateComment;
                        if (fsc.IsNotNull() && (this.LogFilter.IsNull() || this.LogFilter.CommentInputFilter(fsc)))
                            Do(wb =>
                            {
                                wb.Save_FlashStateComment(this, fsc);
                            });
                        break;
                    case FlashMessageType.FlashUnicast:
                        FlashUnicast fu = flashMessage as FlashUnicast;
                        if (fu.IsNotNull() && (this.UniFilter.IsNull() || this.UniFilter.Filter(fu)))
                            Do(wb =>
                            {
                                var senderHash = Contract.CreateSignatureRedeemScript(fu.Sender).ToScriptHash().Hash;
                                var RecipientHash = fu.RecipientHash;
                                if (SecureHelper.MasterAccount.ScriptHash.Hash == senderHash)
                                {
                                    wb.Save_FlashUnicast(this, SecureHelper.MasterAccount.ScriptHash, fu, TalkKind.OutBox);
                                }
                                else if (SecureHelper.MasterAccount.ScriptHash.Hash == RecipientHash)
                                {
                                    ret = true;
                                    wb.Save_FlashUnicast(this, SecureHelper.MasterAccount.ScriptHash, fu, TalkKind.Inbox);
                                }
                            });
                        break;
                    case FlashMessageType.FlashMulticast:
                        FlashMulticast fm = flashMessage as FlashMulticast;
                        if (fm.IsNotNull() && (this.MultiFilter.IsNull() || this.MultiFilter.Filter(fm)))
                            Do(wb =>
                            {
                                bool findFM = false;
                                TalkKind tk = default;
                                foreach (var m in this.MulticastTalkLines)
                                {
                                    if (m.Key == fm.TalkLine)
                                    {
                                        tk = Contract.CreateSignatureRedeemScript(fm.Sender).ToScriptHash() == m.Value.Local ? TalkKind.OutBox : TalkKind.Inbox;
                                        findFM = true;
                                        if (tk == TalkKind.OutBox) break;
                                    }
                                }
                                if (findFM)
                                    wb.Save_FlashMulticast(this, fm, tk);
                            });
                        break;
                    case FlashMessageType.FlashMulticastNotice:
                        FlashMulticastNotice fmn = flashMessage as FlashMulticastNotice;
                        byte[] shareKey = default;
                        string msg = string.Empty;
                        foreach (var dest in fmn.Destinations)
                        {
                            if (SecureHelper.MasterAccount.ScriptHash.Hash == dest.RecipientHash)
                            {
                                try
                                {
                                    var suffix = BitConverter.GetBytes(fmn.MinIndex);
                                    shareKey = dest.Data.Decrypt(SecureHelper.MasterAccount.Key, fmn.Sender, suffix);
                                    msg = System.Text.Encoding.UTF8.GetString(fmn.Msg.Decrypt(shareKey, suffix));
                                    break;
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                        if (shareKey != default)
                        {
                            var talkLine = new UInt256(Crypto.Default.Hash256(Crypto.Default.Hash256(shareKey)));
                            if (!this.MulticastTalkLines.ContainsKey(talkLine))
                            {
                                Do(wb =>
                                {
                                    wb.Save_MulticastTalkLine(this, SecureHelper.MasterAccount.ScriptHash, shareKey, msg, 0);
                                });
                            }
                        }
                        break;
                    case FlashMessageType.FlashNFTPending:
                        //FlashNFTPending fnp = flashMessage as FlashNFTPending;
                        //foreach (var pending in fnp.Pendings)
                        //{
                        //    this.AppendNFTPending(pending);
                        //}
                        break;
                }
            }
            return ret;
        }
        public void Do(Action<WriteBatch> action)
        {
            WriteBatch batch = new WriteBatch();
            if (action != default)
                action(batch);
            this.Db.Write(WriteOptions.Default, batch);
        }

        #region
        public (UInt256 talkline, MulticastTalkLineValue utlv) SaveMulticastTalkLine(UInt160 localAddress, byte[] shareKey, string msg, uint level = 0)
        {
            UInt256 talkline = default;
            MulticastTalkLineValue utlv = default;
            Do(wb =>
            {
                var result = wb.Save_MulticastTalkLine(this, localAddress, shareKey, msg, level);
                talkline = result.talkLine;
                utlv = result.utlv;
            });
            return (talkline, utlv);
        }
        public (UInt256 talkLine, UnicastTalkLineValue utlv) SaveUnicastTalkLine(ECPoint remote, uint level = 0)
        {
            UnicastTalkLineValue UnicastTalkLineValue = default;
            UInt256 talkLine = default;
            Do(wb =>
            {
                talkLine = ECDiffieHellmanHelper.ECDHDeriveKeyHash(SecureHelper.MasterAccount.Key, remote);
                //if (!this.UnicastTalkLines.TryGetValue(talkLine, out UnicastTalkLineValue utlv))
                //{
                string label = string.Empty;
                var remoteSh = Contract.CreateSignatureRedeemScript(remote).ToScriptHash();
                var dmbs = FlashMessageHelper.GetDomain(remoteSh);
                if (dmbs.IsNotNullAndEmpty())
                {
                    label = System.Text.Encoding.UTF8.GetString(dmbs);
                }

                var utlv = new UnicastTalkLineValue { Local = SecureHelper.MasterAccount.ScriptHash, Remote = remote, Label = label, Level = level };
                wb.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashUnicast_TalkLine).Add(talkLine), SliceBuilder.Begin().Add(utlv));
                this.UnicastTalkLines[talkLine] = utlv;
                UnicastTalkLineValue = utlv;
                //}
            });
            return (talkLine, UnicastTalkLineValue);
        }
        public void DeleteUnicastTalkLine(UInt256 talkline)
        {
            Do(wb =>
            {
                if (this.UnicastTalkLines.Remove(talkline, out UnicastTalkLineValue utlv))
                {
                    wb.Delete(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashUnicast_TalkLine).Add(talkline));
                }
            });
        }
        public void DeleteMulticastTalkLine(UInt256 talkline)
        {
            Do(wb =>
            {
                if (this.MulticastTalkLines.Remove(talkline, out MulticastTalkLineValue utlv))
                {
                    wb.Delete(SliceBuilder.Begin(FlashStatePersistencePrefixes.FlashMulticast_TalkLine).Add(talkline));
                }
            });
        }
        public IEnumerable<KeyValuePair<TalkLineKey, FlashUnicastRecord>> GetLastUnicastRecords(UInt256 talkLine, out uint range)
        {
            range = 0;
            if (this.TalkCount.TryGetValue(talkLine, out UInt32Wrapper w))
            {
                range = (uint)w / FlashMemoryHelper.RangeSize;
                return GetUnicastRecords(talkLine, range);
            }
            return default;
        }
        public IEnumerable<KeyValuePair<TalkLineKey, FlashUnicastRecord>> GetUnicastRecords(UInt256 talkLine, uint range)
        {
            var builder = SliceBuilder.Begin().Add(talkLine).Add(range);
            return this.GetAll<TalkLineKey, FlashUnicastRecord>(FlashStatePersistencePrefixes.FlashUnicast_Record, builder.ToArray()).OrderBy(m=>m.Value.Timestamp);
        }
        public IEnumerable<KeyValuePair<TalkLineKey, FlashUnicastRecord>> GetAllUnicastRecords(UInt256 talkLine)
        {
            var builder = SliceBuilder.Begin().Add(talkLine);
            return this.GetAll<TalkLineKey, FlashUnicastRecord>(FlashStatePersistencePrefixes.FlashUnicast_Record, builder.ToArray()).OrderBy(m => m.Value.Timestamp);
        }
        public IEnumerable<KeyValuePair<TalkLineKey, FlashMulticastRecord>> GetLastMulticastRecords(UInt256 talkLine, out uint range)
        {
            range = 0;
            if (this.TalkCount.TryGetValue(talkLine, out UInt32Wrapper w))
            {
                range = (uint)w / FlashMemoryHelper.RangeSize;
                return GetMulticastRecords(talkLine, range);
            }
            return default;
        }
        public IEnumerable<KeyValuePair<TalkLineKey, FlashMulticastRecord>> GetMulticastRecords(UInt256 talkLine, uint range)
        {
            var builder = SliceBuilder.Begin().Add(talkLine).Add(range);
            return this.GetAll<TalkLineKey, FlashMulticastRecord>(FlashStatePersistencePrefixes.FlashMulticast_Record, builder.ToArray()).OrderBy(m=>m.Value.Timestamp);
        }
        public IEnumerable<KeyValuePair<TalkLineKey, FlashMulticastRecord>> GetAllMulticastRecords(UInt256 talkLine)
        {
            var builder = SliceBuilder.Begin().Add(talkLine);
            return this.GetAll<TalkLineKey, FlashMulticastRecord>(FlashStatePersistencePrefixes.FlashMulticast_Record, builder.ToArray()).OrderBy(m => m.Value.Timestamp);
        }
        public FlashStateRecord GetFlashStatRecord(UInt256 flashStateHash)
        {
            return this.Get<FlashStateRecord>(FlashStatePersistencePrefixes.FlashState_Record, flashStateHash);
        }

        public IEnumerable<KeyValuePair<FlashStateCommentKey, FlashStateCommentValue>> GetFlashStateComments(UInt256 flashStateHash)
        {
            var builder = SliceBuilder.Begin().Add(flashStateHash);
            return this.GetAll<FlashStateCommentKey, FlashStateCommentValue>(FlashStatePersistencePrefixes.FlashStateComment_Record, builder.ToArray());
        }
        public void CropCommentCount()
        {
            if (this.FlashStateCommentCount.Count > 10000)
            {
                Dictionary<UInt256, CommentCountValue> dic = new Dictionary<UInt256, CommentCountValue>();
                foreach (var k in this.FlashStateCommentCount.OrderByDescending(m => m.Value.Timestamp).Take(10000))
                {
                    dic[k.Key] = k.Value;
                }
                this.FlashStateCommentCount = dic;
            }
        }

        public IOrderedEnumerable<FlashStateRecord> GetCachedHotFlashStateRecords(uint pageIndex = 0)
        {
            var list = RangeCacheHelper<IEnumerable<FlashStateRecord>>.GetCachePool("mostpop_flashstaterecord").Get(pageIndex, r =>
            {
                var records = this.FlashStateCommentCount.OrderByDescending(m => (uint)m.Value.Count).Skip((int)pageIndex * 100).Take(100);
                if (records.IsNullOrEmpty()) return default;
                List<FlashStateRecord> list = new List<FlashStateRecord>();
                foreach (var rhash in records)
                {
                    var record = GetFlashStatRecord(rhash.Key);
                    if (record.IsNotNull()) list.Add(record);
                }
                return list;
            });
            if (list.IsNullOrEmpty()) return default;
            return list.OrderByDescending(m => m.CommentCount);
        }
        public uint GetLastRangeForTag(FlashStateTag tag)
        {
            uint range = uint.MaxValue;
            if (this.FlashStateTagCount.TryGetValue(tag, out UInt32Wrapper w))
            {
                range = (uint)w / FlashMemoryHelper.RangeSize;
            }
            return range;
        }
        public uint GetLastRangeForSender(UInt160 sender)
        {
            uint range = uint.MaxValue;
            if (this.FlashStateCount.TryGetValue(sender, out UInt32Wrapper w))
            {
                range = (uint)w / FlashMemoryHelper.RangeSize;
            }
            return range;
        }
        public IOrderedEnumerable<FlashStateRecord> GetCachedFlashStateRecordsForTag(FlashStateTag tag, uint pageIndex)
        {
            var list = RangeCacheHelper<IEnumerable<FlashStateRecord>>.GetCachePool($"tag_flashstaterecord_{tag.ToString()}").Get(pageIndex, r =>
            {
                var rs = GetFlashStateRecordsForTag(tag, r);
                if (rs.IsNullOrEmpty()) return default;
                List<FlashStateRecord> list = new List<FlashStateRecord>();
                foreach (var rhash in rs)
                {
                    var record = GetFlashStatRecord(rhash.Value);
                    if (record.IsNotNull()) list.Add(record);
                }
                return list;
            });
            if (list.IsNullOrEmpty()) return default;
            return list.OrderByDescending(m => m.Timestamp);
        }
        public IEnumerable<KeyValuePair<TagFlashStateKey, UInt256>> GetFlashStateRecordsForTag(FlashStateTag tag, uint range)
        {
            var builder = SliceBuilder.Begin().Add(tag).Add(range);
            return this.GetAll<TagFlashStateKey, UInt256>(FlashStatePersistencePrefixes.FlashState_TagRecord, builder.ToArray());
        }
        public IOrderedEnumerable<FlashStateRecord> GetCachedFlashStateRecordsForLatest(uint pageIndex)
        {
            var list = RangeCacheHelper<IEnumerable<FlashStateRecord>>.GetCachePool("latest_flashstaterecord").Get(pageIndex, r =>
            {
                var rs = GetFlashStateRecordsForLatest(r);
                if (rs.IsNullOrEmpty()) return default;
                List<FlashStateRecord> list = new List<FlashStateRecord>();
                foreach (var rhash in rs)
                {
                    var record = GetFlashStatRecord(rhash.Value);
                    if (record.IsNotNull()) list.Add(record);
                }
                return list;
            });
            if (list.IsNullOrEmpty()) return default;
            return list.OrderByDescending(m => m.Timestamp);
        }
        public IEnumerable<KeyValuePair<GlobalFlashStateKey, UInt256>> GetFlashStateRecordsForLatest(uint range)
        {
            var builder = SliceBuilder.Begin().Add(range);
            return this.GetAll<GlobalFlashStateKey, UInt256>(FlashStatePersistencePrefixes.FlashState_GlobalRecord, builder.ToArray());
        }
        public IOrderedEnumerable<FlashStateRecord> GetCachedFlashStateRecordsForSender(UInt160 sender, uint pageIndex)
        {
            var list = RangeCacheHelper<IEnumerable<FlashStateRecord>>.GetCachePool($"sender_flashstaterecord_{sender.ToAddress()}").Get(pageIndex, r =>
            {
                var rs = GetFlashStateRecordsForSender(sender, r);
                if (rs.IsNullOrEmpty()) return default;
                List<FlashStateRecord> list = new List<FlashStateRecord>();
                foreach (var rhash in rs)
                {
                    var record = GetFlashStatRecord(rhash.Value);
                    if (record.IsNotNull()) list.Add(record);
                }
                return list;
            });
            if (list.IsNullOrEmpty()) return default;
            return list.OrderByDescending(m => m.Timestamp);
        }
        public IEnumerable<KeyValuePair<GlobalFlashStateKey, UInt256>> GetFlashStateRecordsForSender(UInt160 sender, uint range)
        {
            var builder = SliceBuilder.Begin().Add(sender).Add(range);
            return this.GetAll<GlobalFlashStateKey, UInt256>(FlashStatePersistencePrefixes.FlashState_SenderRecord, builder.ToArray());
        }
        //public void CheckNFTPending()
        //{
        //    if (this.NFTPendings.IsNotNullAndEmpty())
        //    {
        //        Do(wb =>
        //        {
        //            var ks = this.NFTPendings.Keys.ToArray();
        //            foreach (var k in ks)
        //            {
        //                var ndv = this.NFTPendings[k].Pending;
        //                var snapshot = Blockchain.Singleton.CurrentSnapshot;
        //                var nfsState = snapshot.GetNftTransfer(ndv.Key);
        //                bool needRemove = false;
        //                if (nfsState.IsNull())
        //                {
        //                    needRemove = true;
        //                }
        //                else
        //                {
        //                    if (!nfsState.LastNFS.Hash.Equals(ndv.Validator.Target.PreHash))
        //                    {
        //                        needRemove = true;
        //                    }
        //                }
        //                if ((ndv.Validator.Target.MaxIndex > 0 && ndv.Validator.Target.MaxIndex < Blockchain.Singleton.Height) || ndv.Validator.Target.Amount <= Fixed8.Zero)
        //                    needRemove = true;
        //                if (needRemove)
        //                {
        //                    if (this.NFTPendings.Remove(k))
        //                    {
        //                        wb.Delete(SliceBuilder.Begin(FlashStatePersistencePrefixes.Flash_NFTPendingRecord).Add(k));
        //                    }
        //                }
        //            }
        //        });
        //    }
        //}
        //public static StringWrapper GetNFTIssueID(NFSStateKey key)
        //{
        //    return new StringWrapper($"{key.NFCID.CID}-{key.IssueBlockIndex}-{key.IssueN}");
        //}
        //public bool AppendNFTPending(NFTPending ndv)
        //{

        //    NFTPendingRecord record = new NFTPendingRecord
        //    {
        //        IssueId = GetNFTIssueID(ndv.Key),
        //        Pending = ndv
        //    };
        //    this.NFTPendings[record.IssueId] = record;
        //    Do(wb =>
        //    {
        //        wb.Put(SliceBuilder.Begin(FlashStatePersistencePrefixes.Flash_NFTPendingRecord).Add(record.IssueId), SliceBuilder.Begin().Add(record));
        //    });
        //    return true;
        //}
        #endregion
    }
}
