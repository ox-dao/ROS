using OX.Bapps;
using OX.IO;
using OX.Ledger;
using OX.Network.P2P.Payloads;
using OX.SmartContract;
using OX.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OX.BMS;
using Sunny.UI;
using Akka.Actor;
using OX.Network.P2P;
using NBitcoin.Secp256k1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using OX.Tablet.Config;

namespace OX.Tablet.UIs.MarkSix
{
    public partial class AdminRechargeMemberForm : UIForm
    {
        MixMarkMember MyMember;
        Fixed8 AvailableBalance = Fixed8.Zero;
        public AdminRechargeMemberForm()
        {
            InitializeComponent();

        }


        private void ClaimForm_Load(object sender, EventArgs e)
        {
            this.lb_leaderHolder.Text = UIHelper.LocalString("带单人ID:", "Leader ID:");
            this.Text = UIHelper.LocalString("注册会员", "Register Member");
            this.lb_kind.Text = UIHelper.LocalString("会员类型:", "Member Kind:");
            this.bt_NewRoom.Text = UIHelper.LocalString("马上注册", "Reg Now");
            this.lb_balance.Text = UIHelper.LocalString("可用余额:", "Available Balance:");
            this.bt_close.Text = UIHelper.LocalString("关闭", "Close");
            var bmsIndex = SecureHelper.BlockIndex.GetSubBlockIndex<BMSBlockIndex>();
            if (bmsIndex.MarkMembers.TryGetValue(SecureHelper.MasterAccount.ScriptHash, out var member))
            {
                this.MyMember = member;
                if (bmsIndex.MarkMembers.TryGetValue(member.Request.LeaderHolder, out var pMember))
                {
                    this.tb_leaderHolder.Text = pMember.MarkMemberId.ToString();
                    this.tb_leaderHolder.ReadOnly = true;
                }
            }
            var agentNames = MarkMemberType.Player.GetName();
            var portNames = MarkMemberType.Banker.GetName();
            this.st_kind.ActiveText = UIHelper.LocalString(portNames.Name, portNames.EngName);
            this.st_kind.InActiveText = UIHelper.LocalString(agentNames.Name, agentNames.EngName);
            if (MyMember.IsNotNull())
            {
                this.st_kind.Active = this.MyMember.Request.MemberType == MarkMemberType.Banker;
                this.st_kind.Enabled = false;
                this.agentSetting1.LoadSetting(MyMember.MarkSetting);
                //this.cb_minBond.Text = (MyMember.Request.MinBondBalance.GetInternalValue() / Fixed8.D).ToString();
            }
            this.AvailableBalance = SecureHelper.GetMasterAvailableBalance(Blockchain.OXC);
            this.tb_balance.Text = AvailableBalance.ToString();

            //this.rtb_msg.Text = UIHelper.LocalString("只有每个月1号0点-12点之间才可以修改联合庄池的参数，所以在新建联合庄池之前务必要确认好参数", "The parameters of the joint pool can only be modified between 0:00 and 12:00 on the 1st of each month, so it is necessary to confirm the parameters before creating a new joint pool");
        }

        private void ClaimForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        public void OnBappEvent(BappEvent be) { }

        public void OnCrossBappMessage(CrossBappMessage message)
        {
        }
        public void HeartBeat(HeartBeatContext context)
        {

        }
        public void OnFlashMessage(FlashMessage flashMessage)
        {

        }
        public void OnBlock(Block block)
        {
        }
        public void BeforeOnBlock(Block block) { }
        public void AfterOnBlock(Block block) { }

        public void OnRebuild() { }

        UInt160 BuildAddress(byte flag)
        {
            var tx = new SlotSideTransaction()
            {
                Channel = 0x02,
                Slot = casino.CasinoMasterAccountPubKey,
                SideType = SideType.PublicKey,
                Data = SecureHelper.MasterAccount.Key.PublicKey.ToArray(),
                Flag = flag,
                AuthContract = Blockchain.SideAssetContractScriptHash,
                Attributes = new TransactionAttribute[0],
                Outputs = new TransactionOutput[0],
                Inputs = new CoinReference[0]
            };
            return tx.GetContract().ScriptHash;
        }

        private void bt_NewRoom_Click(object sender, EventArgs e)
        {

            Register();

        }
        void Register()
        {
            var setting = SecureHelper.BlockIndex.GetSubBlockIndex<CasinoBlockIndex>().GetCasinoSetting(CasinoSettingTypes.MemberRegFee);
            if (setting.IsNullOrEmpty()) return;
            var regFee = uint.Parse(setting);
            Fixed8 fee = Fixed8.One * regFee;
            var assetId = Blockchain.OXC;

            if (this.AvailableBalance >= fee + Fixed8.One * 2)
            {
                RegMarkMemberRequest request = default;
                if (this.MyMember.IsNotNull())
                {
                    request = this.MyMember.Request;
                }
                else
                {
                    request = new RegMarkMemberRequest { Flag = 0 };
                    request.MemberType = this.st_kind.Active ? MarkMemberType.Banker : MarkMemberType.Player;
                    if (this.st_kind.Active)
                    {
                        request.LeaderHolder = SecureHelper.MasterAccount.ScriptHash;
                    }
                    else
                    {
                        if (!uint.TryParse(this.tb_leaderHolder.Text, out var mid)) return;
                        var bmsIndex = SecureHelper.BlockIndex.GetSubBlockIndex<BMSBlockIndex>();
                        var pMember = bmsIndex.MarkMembers.Values?.Where(m => m.MarkMemberId == mid).FirstOrDefault();
                        if (pMember.IsNull()) return;
                        //if (pMember.Request.MemberType != MarkMemberType.Port) return;
                        request.LeaderHolder = pMember.Holder;
                    }
                }
                request.MinBondBalance = Fixed8.Zero; //Fixed8.One * uint.Parse(cb_minBond.Text);
                request.Data = this.agentSetting1.GetSetting().ToArray();
                var tx = new SlotSideTransaction()
                {
                    Channel = 0x02,
                    Slot = casino.CasinoMasterAccountPubKey,
                    SideType = SideType.PublicKey,
                    Data = SecureHelper.MasterAccount.Key.PublicKey.ToArray(),
                    Flag = 0x00,
                    AuthContract = Blockchain.SideAssetContractScriptHash,
                    Attributes = new TransactionAttribute[0],
                    Outputs = new TransactionOutput[0],
                    Inputs = new CoinReference[0],
                    Attach = request.ToArray()
                };
                var addr = tx.GetContract().ScriptHash;

                List<TransactionOutput> outputs = new List<TransactionOutput>();

                outputs.Add(new TransactionOutput
                {
                    ScriptHash = casino.CasinoMasterAccountAddress,
                    AssetId = Blockchain.OXC,
                    Value = fee
                });
                outputs.Add(new TransactionOutput
                {
                    ScriptHash = addr,
                    AssetId = Blockchain.OXC,
                    Value = Fixed8.One
                });
                tx.Outputs = outputs.ToArray();
                if (tx.IsNotNull())
                {
                    var newTx = tx.BuildAndSignMultiOXCOutput(Fixed8.Zero);
                    if (newTx.IsNotNull()&& newTx.Verify(Blockchain.Singleton.CurrentSnapshot, Blockchain.Singleton.MemPool.GetVerifiedTransactions()))
                    {
                        TabletBlockHandler.Instance.Tell(newTx);
                        foreach (var coin in newTx.Inputs)
                        {
                            SecureHelper.BlockIndex.UnconfirmCoins[coin] = Blockchain.Singleton.Height + 100;
                        }
                        this.Close();
                        new WaitTxForm(newTx, UIHelper.LocalString("会员充值", "Recharge Member")).ShowDialog();
                    }
                }
            }
            else
            {
                string msg = UIHelper.LocalString($"至少需要{fee} OXC余额", $"At least {fee} OXC  balance is required ");
                this.ShowErrorTip(msg);
            }

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void st_kind_ValueChanged(object sender, bool value)
        {
            this.tb_leaderHolder.ReadOnly = this.st_kind.Active;
            if (this.st_kind.Active)
            {
                this.tb_leaderHolder.Text = string.Empty;
            }
        }
    }
}
