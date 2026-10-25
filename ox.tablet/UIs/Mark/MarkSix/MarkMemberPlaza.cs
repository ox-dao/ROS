using Akka.Actor;
using Org.BouncyCastle.Bcpg;
using OX.BMS;
using OX.Ledger;
using OX.Network.P2P.Payloads;
using OX.Tablet.Config;
using OX.Tablet.UIs.Mark;
using OX.Tablet.UIs.Mark.MarkSix;
using OX.Wallets;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OX.Tablet.UIs.MarkSix
{
    public partial class MarkMemberPlaza : UIPage, IBlockchainHandler
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));

        MethodButton CurrentMethodButton = default;
        MixMarkMember MyMember;
        public MarkMemberPlaza()
        {
            InitializeComponent();


            this.Text = UIHelper.LocalString("会员", "Member");
            this.bt_member_recharge.Text = UIHelper.LocalString("注册会员", "Reg Member");
            this.bt_show_unionsetting.Text = UIHelper.LocalString("公共赔率", "Public Odds");
            this.st_auto_cut.ActiveText = UIHelper.LocalString("自动平仓", "Auto Cut");
            this.st_auto_cut.InActiveText = UIHelper.LocalString("不平仓", "None Cut");
            this.bt_recharge.Text = UIHelper.LocalString("加保证金", "Recharge");

        }

        void InitMemberInfo()
        {
            this.MyMember = SecureHelper.GetMarkMember();
            this.lb_MemberId.Text = string.Empty;
            this.slb_memberType.Text = string.Empty;
            this.slb_memberType.Visible = false;
            if (MyMember.IsNotNull())
            {
                var bmsIndex = SecureHelper.BlockIndex.GetSubBlockIndex<BMSBlockIndex>();
                uint seniorBond = 0;
                uint basicBond = 0;
                var seniorSetting = SecureHelper.BlockIndex.GetSubBlockIndex<CasinoBlockIndex>().GetCasinoSetting(CasinoSettingTypes.SeniorBankerBond);
                if (seniorSetting.IsNotNullAndEmpty())
                {
                    seniorBond = uint.Parse(seniorSetting);
                }
                var basicSetting = SecureHelper.BlockIndex.GetSubBlockIndex<CasinoBlockIndex>().GetCasinoSetting(CasinoSettingTypes.BasicBankerBond);
                if (basicSetting.IsNotNullAndEmpty())
                {
                    basicBond = uint.Parse(basicSetting);
                }
                this.lb_msg.Text = UIHelper.LocalString($"基础庄家保证金门槛:{basicBond} OXC,高级庄家保证金门槛：{seniorBond} OXC", $"basic banker min bond:{basicBond} OXC,senior banker min bond：{seniorBond} OXC");
                Fixed8 depositBalance = MyMember.MemberBond();
                this.lb_deposit.Text = UIHelper.LocalString($"保证金:{depositBalance.ToString("f2")} OXC", $"Bond:{depositBalance.ToString("f2")} OXC");

                this.slb_memberType.Visible = true;
                this.lb_MemberId.Text = UIHelper.LocalString($"会员ID: {MyMember.MarkMemberId}", $"Member ID: {MyMember.MarkMemberId}");

                var memberTypeNames = MyMember.Request.MemberType.GetName();
                this.slb_memberType.Text = UIHelper.LocalString("会员过期", "Member lapse");
                bool ok = false;
                this.lb_port_asset.Text = string.Empty;
                if (MyMember.Request.MemberType == MarkMemberType.Banker)
                {
                    ok = MyMember.IsBanker();
                    var deposit = SecureHelper.GetBasicBankerMinBond();
                    this.slb_memberType.Symbol = depositBalance >= deposit ? 361452 : 361453;
                }
                else
                {
                    ok = MyMember.IsPlayer();
                    this.slb_memberType.Symbol = ok ? 361452 : 361453;
                }

                if (bmsIndex.MarkMembers.TryGetValue(this.MyMember.Request.LeaderHolder, out var pm))
                {
                    this.lb_port_asset.Text = UIHelper.LocalString($"带单人:{pm.MarkMemberId}", $"Leader:{pm.MarkMemberId}");
                }
                if (ok)
                {
                    this.slb_memberType.Text = UIHelper.LocalString(memberTypeNames.Name, memberTypeNames.EngName);
                }

                this.st_auto_cut.Active = NodeConfig.Instance.MarkAutoCut.ToLower() == "true";
            }
        }

        public void HeartBeat(HeartBeatContext beatContext)
        {

        }
        public void BeforeBlock(Block block)
        {

        }
        public void OnBlock(Block block)
        {

        }
        public void AfterBlock(Block block)
        {

        }
        public void OnFlashMessage(FlashMessage message)
        {

        }
        public void OnClipboardString(ClipboardMessageType messageType, string msg)
        {

        }
        public void MenuPageSelected()
        {
            if (SecureHelper.IsAuthenticated)
            {
                InitMemberInfo();
            }
        }



        void setColor(UIButton control, Color color)
        {
            control.FillColor = color;
            control.FillColor2 = color;
            control.FillHoverColor = color;
            control.FillPressColor = color;
            control.FillSelectedColor = color;
            control.RectColor = color;
            control.RectHoverColor = color;
            control.RectPressColor = color;
            control.RectSelectedColor = color;
        }

        private void st_auto_cut_ValueChanged(object sender, bool value)
        {
            NodeConfig.Instance.MarkAutoCut = value.ToString();
            NodeConfig.Instance.Save();
        }

        private void bt_recharge_Click(object sender, EventArgs e)
        {
            if (MyMember.IsNotNull())
            {
                var balance = SecureHelper.GetMasterAvailableBalance(Blockchain.OXC);
                var frm = new MemberDepositForm(balance, MyMember.PoolAddress);
                frm.Render();
                frm.ShowDialog();
                if (frm.IsOK)
                {
                    var tx = frm.BuildTx();
                    if (tx.IsNotNull() && tx.Verify(Blockchain.Singleton.CurrentSnapshot, Blockchain.Singleton.MemPool.GetVerifiedTransactions()))
                    {
                        TabletBlockHandler.Instance.Tell(tx);
                        foreach (var coin in tx.Inputs)
                        {
                            SecureHelper.BlockIndex.UnconfirmCoins[coin] = Blockchain.Singleton.Height + 100;
                        }
                        new WaitTxForm(tx, UIHelper.LocalString("等待交易确认...", "Waiting  confirm transaction")).ShowDialog();
                    }
                }
                frm.Dispose();
            }
        }

        private void bt_show_unionsetting_Click(object sender, EventArgs e)
        {
            new ShowBankerSettingForm(SecureHelper.GetMarkAdminMember()).ShowDialog();
        }

        private void bt_member_recharge_Click(object sender, EventArgs e)
        {
            if (SecureHelper.IsMarkAdmin())
                new AdminRechargeMemberForm().ShowDialog();
            else
                new RechargeMemberForm().ShowDialog();
        }
    }
}
