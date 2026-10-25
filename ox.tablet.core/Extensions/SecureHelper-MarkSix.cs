using OX.BMS;
using OX.Casino;
using OX.Ledger;
using OX.Network.P2P.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OX.Cryptography.ECC;

namespace OX.Tablet
{
    public static partial class SecureHelper
    {
        public static uint GetMarkSixOpenSeconds()
        {
            var casinoIndex = SecureHelper.BlockIndex.GetSubBlockIndex<CasinoBlockIndex>();
            var v = casinoIndex.GetCasinoSetting(CasinoSettingTypes.MarkSixOpenSeconds);
            if (v.IsNotNullAndEmpty())
            {
                return uint.Parse(v);
            }
            return 0;
        }
        public static uint GetMarkSixLastBetSeconds()
        {
            var casinoIndex = SecureHelper.BlockIndex.GetSubBlockIndex<CasinoBlockIndex>();
            var v = casinoIndex.GetCasinoSetting(CasinoSettingTypes.MarkSixLastBetSeconds);
            if (v.IsNotNullAndEmpty())
            {
                return uint.Parse(v);
            }
            return 0;
        }
        public static Fixed8 GetBasicBankerMinBond()
        {
            var casinoIndex = SecureHelper.BlockIndex.GetSubBlockIndex<CasinoBlockIndex>();
            var v = casinoIndex.GetCasinoSetting(CasinoSettingTypes.BasicBankerBond);
            if (v.IsNotNullAndEmpty())
            {
                return Fixed8.One * uint.Parse(v);
            }
            return Fixed8.Zero;
        }
        public static Fixed8 GetSeniorBankerMinBond()
        {
            var casinoIndex = SecureHelper.BlockIndex.GetSubBlockIndex<CasinoBlockIndex>();
            var v = casinoIndex.GetCasinoSetting(CasinoSettingTypes.SeniorBankerBond);
            if (v.IsNotNullAndEmpty())
            {
                return Fixed8.One * uint.Parse(v);
            }
            return Fixed8.Zero;
        }
        public static uint GetBasicBankerBetPercent()
        {
            var casinoIndex = SecureHelper.BlockIndex.GetSubBlockIndex<CasinoBlockIndex>();
            var v = casinoIndex.GetCasinoSetting(CasinoSettingTypes.BasicBankerBetPercent);
            if (v.IsNotNullAndEmpty())
            {
                return uint.Parse(v);
            }
            return 0;
        }
        public static MixMarkMember GetMarkMember()
        {
            if (SecureHelper.BlockIndex.IsNull()) return default;
            var bmsIndex = SecureHelper.BlockIndex.GetSubBlockIndex<BMSBlockIndex>();
            if (bmsIndex.IsNull()) return default;
            if (!bmsIndex.MarkMembers.TryGetValue(SecureHelper.MasterAccount.ScriptHash, out var member)) return default;
            return member;
        }
        public static MixMarkMember GetMarkMember(UInt160 MemberHodler)
        {
            if (SecureHelper.BlockIndex.IsNull()) return default;
            var bmsIndex = SecureHelper.BlockIndex.GetSubBlockIndex<BMSBlockIndex>();
            if (bmsIndex.IsNull()) return default;
            if (!bmsIndex.MarkMembers.TryGetValue(MemberHodler, out var member)) return default;
            return member;
        }
        public static MixMarkMember GetMarkAdminMember()
        {
            if (SecureHelper.BlockIndex.IsNull()) return default;
            var bmsIndex = SecureHelper.BlockIndex.GetSubBlockIndex<BMSBlockIndex>();
            if (bmsIndex.IsNull()) return default;
            if (!bmsIndex.MarkMembers.TryGetValue(MarkBetAddressHelper.Instance.MarkAdmin, out var member)) return default;
            return member;
        }
        public static bool IsPlayer(this MixMarkMember member)
        {
            if (member.IsNull()) return false;
            if (member.Request.MemberType != MarkMemberType.Player) return false;
            return true;
        }
        public static bool IsPlayer()
        {
            var member = GetMarkMember();
            if (member.IsNull()) return false;
            return member.IsPlayer();
        }

        public static bool IsBanker(this MixMarkMember member)
        {
            if (member.IsNull()) return false;
            if (member.Request.MemberType != MarkMemberType.Banker) return false;
            return true;
        }
        public static Fixed8 MemberBond(this MixMarkMember member)
        {
            var act = Blockchain.Singleton.CurrentSnapshot.Accounts.TryGet(member.PoolAddress);
            if (act.IsNotNull())
            {
                return act.GetBalance(Blockchain.OXC);
            }
            return Fixed8.Zero;
        }
        public static Fixed8 MemberBetBalance(this MixMarkMember member)
        {
            var act = Blockchain.Singleton.CurrentSnapshot.Accounts.TryGet(member.BetAddress);
            if (act.IsNotNull())
            {
                return act.GetBalance(Blockchain.OXC);
            }
            return Fixed8.Zero;
        }
        public static bool AllowBet(this MixMarkMember member, List<BitMarkSixBet> bets, out Fixed8 betRemaind)
        {
            betRemaind = Fixed8.Zero;
            var bond = member.MemberBond();
            var basicBankerMinBond = SecureHelper.GetBasicBankerMinBond();
            if (basicBankerMinBond > bond) return false;
            var seniorBankerMinBond = SecureHelper.GetSeniorBankerMinBond();
            Fixed8 MaxBet = Fixed8.Zero;
            if (bond >= seniorBankerMinBond)
            {
                MaxBet = bond;
            }
            else
            {
                var percent = SecureHelper.GetBasicBankerBetPercent();
                var d = (bond.GetInternalValue() * percent) / 100;
                MaxBet = new Fixed8(d);
            }
            var betBalance = member.MemberBetBalance();
            if (betBalance >= MaxBet) return false;
            var bizshs = new UInt160[] { casino.CasinoMasterAccountAddress };
            Fixed8 memoryPoolBet = Fixed8.Zero;
            foreach (var tx in Blockchain.Singleton.MemPool.GetVerifiedTransactions())
            {
                if (tx is AskTransaction at)
                {
                    if (at.GetDataModel<MarkBetOrder>(bizshs, (byte)CasinoType.MarkBet, out MarkBetOrder markorder))
                    {
                        if (member.Holder == markorder.PortHolder)
                        {
                            var output = at.Outputs.FirstOrDefault(m => m.ScriptHash == member.BetAddress && m.AssetId == Blockchain.OXC);
                            if (output.IsNotNull() && output.Value >= Fixed8.One * markorder.Amount)
                            {
                                memoryPoolBet += output.Value;
                            }
                        }
                    }
                }
            }
            if (betBalance + memoryPoolBet >= MaxBet) return false;
            betRemaind = MaxBet - (betBalance + memoryPoolBet);
            var betAmount = Fixed8.One * bets.Sum(m => m.Amount);
            if (betBalance + betAmount + memoryPoolBet >= MaxBet) return false;
            return true;
        }
        public static bool IsBanker()
        {
            var member = GetMarkMember();
            if (member.IsNull()) return false;
            return member.IsBanker();
        }
        public static bool IsCasinoSlot()
        {
            return SecureHelper.MasterAccount.ScriptHash == casino.CasinoMasterAccountAddress;
        }
        public static bool IsMarkAdmin()
        {
            return SecureHelper.MasterAccount.ScriptHash == MarkBetAddressHelper.Instance.MarkAdmin;
        }
    }
}
