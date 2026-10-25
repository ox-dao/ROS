using Org.BouncyCastle.Bcpg;
using OX.BMS;
using OX.Network.P2P.Payloads;
using OX.Tablet.Config;
using OX.Tablet.UIs.Mark;
using OX.Tablet.UIs.Mark.MarkSix;
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
    public partial class MarkPlayerPlaza : UIPage, IBlockchainHandler, ICurrentTerm
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));

        MethodButton CurrentMethodButton = default;
        public BaseBoundView InboundPage { get; private set; }
        public BaseBoundView AwardSubPage { get; private set; }
        public MarkTerm RealTimeTerm { get; private set; }
        MarkTerm _term;
        public MarkTerm CurrentSelectedTerm
        {
            get { return _term; }
            set
            {
                _term = value;
                this.bt_today.Text = _term.ToString();
            }
        }

        public MarkPlayerPlaza()
        {
            InitializeComponent();
            this.setColor(bt_newBet, FocusColor);
            this.setColor(bt_new_order, FocusColor);
            this.setColor(this.bt_today, FocusColor);

            this.Text = UIHelper.LocalString("玩家", "Player");
            this.bt_next_day.Text = UIHelper.LocalString("后一天", "Next Day");
            this.bt_pre_day.Text = UIHelper.LocalString("前一天", "Pre Day");
            this.L1.Text = UIHelper.LocalString("明细", "Details");
            this.bt_clear.Text = UIHelper.LocalString("清除全部", "Clear All");
            this.bt_clear_page.Text = UIHelper.LocalString("清除本项", "Clear Item");
            this.bt_new_order.Text = UIHelper.LocalString("双击下单", "2-hit Order");
            this.bt_newBet.Text = UIHelper.LocalString("下注", "Bet");
            this.bt_new_order.UseDoubleClick = true;
            this.bt_new_order.DoubleClick += Bt_new_inbound_DoubleClick;
            //this.bt_new_inbound.Enabled = SecureHelper.IsAgent();

            CurrentSelectedTerm = System.DateTime.Now.GetBetTermForPlayer(SecureHelper.GetMarkSixOpenSeconds());
            InitMethods();
        }
        public void HeartBeat(HeartBeatContext beatContext)
        {
            RefreshReaTimeTerms();
            if (this.InboundPage.IsNotNull())
                this.InboundPage.HeartBeat(beatContext);
        }
        public void BeforeBlock(Block block)
        {
            if (this.InboundPage.IsNotNull())
                this.InboundPage.BeforeBlock(block);
        }
        public void OnBlock(Block block)
        {
            if (this.InboundPage.IsNotNull())
                this.InboundPage.OnBlock(block);
        }
        public void AfterBlock(Block block)
        {
            if (this.InboundPage.IsNotNull())
                this.InboundPage.AfterBlock(block);
        }
        public void OnFlashMessage(FlashMessage message)
        {

        }
        public void OnClipboardString(ClipboardMessageType messageType, string msg)
        {
            if (this.InboundPage.IsNotNull())
                this.InboundPage.OnClipboardString(messageType, msg);
        }
        public void MenuPageSelected()
        {
            ReloadBettings();
            if (this.InboundPage.IsNotNull())
                this.InboundPage.MenuPageSelected();
            this.AwardSubPage.MenuPageSelected();
        }
        private void Bt_new_inbound_DoubleClick(object sender, EventArgs e)
        {
            if (SecureHelper.IsPlayer() || SecureHelper.IsBanker())
                new MarkSixOrderForm(this.CurrentSelectedTerm, () => this.ReloadBettings()).ShowDialog();
        }

        void InitMethods()
        {
            foreach (var m in NoneFlagEnumHelper.All<MarkSixBetMethod>())
            {
                var mb = new FullMethodButton(m);
                var setting = m.GetMethodSetting();
                if (setting.IsNotNull())
                {
                    mb.Text = UIHelper.LocalString(setting.Name, setting.EngName);
                    mb.OnMethodSelected += Mb_OnMethodSelected;
                    this.pn_methods.Controls.Add(mb);
                }
            }
            this.InboundPage = new MarkSixPlayerOrderPage(this);
            this.tbc_order.AddPage(this.InboundPage);
            this.AwardSubPage = new MarkSixAwardSubPage(this);
            this.tbc_order.AddPage(this.AwardSubPage);
        }
        void RefreshReaTimeTerms()
        {
            this.RealTimeTerm = System.DateTime.Now.GetBetTermForPlayer(SecureHelper.GetMarkSixOpenSeconds());
            this.DoInvoke(() =>
            {
                var enable = this.RealTimeTerm == this.CurrentSelectedTerm;
                this.pn_betmanage.Enabled = enable;
                this.pn_methods.Enabled = enable;
                this.pn_bettings.Enabled = enable;
                this.bt_newBet.Enabled = enable;
                this.bt_new_order.Enabled = enable;
                if (this.InboundPage.IsNotNull())
                    this.InboundPage.AllowEdit = enable;
            });
        }
        private void Mb_OnMethodSelected(MethodButton methodButton)
        {
            this.CurrentMethodButton = methodButton;
            foreach (var c in this.pn_methods.Controls)
            {
                if (c is MethodButton mb)
                {
                    if (mb != methodButton)
                    {
                        mb.MethodSelected = false;
                    }
                }
            }
            ReloadBettings();
        }

        void ReloadBettings()
        {
            if (this.CurrentMethodButton.IsNotNull())
            {
                this.pn_bettings.Controls.Clear();
                if (this.CurrentSelectedTerm == this.RealTimeTerm)
                {
                    var builder = new SimpleMarkSixBoundBuilder();
                    var total = builder.GetMemoryOrderSet().Amount;
                    var betSet = builder.GetMemoryBetSet(this.CurrentMethodButton.Method);
                    this.lb_amount.Text = $"{betSet.Amount}/{total}";
                    foreach (var item in betSet.BetItems)
                    {
                        var bpb = new BetPointButton(BetChannel.MarkSix, item.Key, item.Value);
                        bpb.OnBetPointRemoved += Bpb_OnBetPointRemoved;
                        this.pn_bettings.Controls.Add(bpb);
                    }
                }
            }
        }

        private void Bpb_OnBetPointRemoved(BetPointButton bpb)
        {
            var builder = new SimpleMarkSixBoundBuilder();
            var betSet = builder.GetMemoryBetSet(this.CurrentMethodButton.Method);
            betSet.RemoveBetTarget(bpb.Target);
            ReloadBettings();
        }

        private void pn_methods_SizeChanged(object sender, EventArgs e)
        {
            this.L1.Top = this.pn_methods.Bottom + 10;
            this.L1.Width = this.pn_methods.Width - 20;
            this.pn_bettings.Top = this.pn_methods.Bottom + 50;
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            var builder = new SimpleMarkSixBoundBuilder();
            var memoryOrderSet = builder.GetMemoryOrderSet();
            memoryOrderSet.ClearAll();
            ReloadBettings();
        }

        private void bt_clear_page_Click(object sender, EventArgs e)
        {
            var builder = new SimpleMarkSixBoundBuilder();
            var betSet = builder.GetMemoryBetSet(this.CurrentMethodButton.Method);
            betSet.ClearAll();
            ReloadBettings();
        }


        private void bt_newPoint_Click(object sender, EventArgs e)
        {
            if (this.CurrentMethodButton.IsNotNull())
            {
                MarkSixBetMethod method = (MarkSixBetMethod)this.CurrentMethodButton.Method;
                var form = method.GetBetForm();
                if (form.IsNotNull())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var amt = (int)form.GetAmount();
                        var targets = form.GetBetTargets();
                        var builder = new SimpleMarkSixBoundBuilder();
                        var memoryOrderSet = builder.GetMemoryBetSet(this.CurrentMethodButton.Method);
                        foreach (var t in targets)
                        {
                            memoryOrderSet.PlusBetTargetAmount(t, amt);
                        }
                        ReloadBettings();
                    }
                }

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








        private void uiTabControl1_SizeChanged(object sender, EventArgs e)
        {
            var size = this.tbc_order.ItemSize;
            size.Width = (this.tbc_order.Width / 3) - 3;
            this.tbc_order.ItemSize = size;
        }

        private void bt_pre_day_Click(object sender, EventArgs e)
        {
            this.CurrentSelectedTerm = this.CurrentSelectedTerm.ToDateTime(12).AddDays(-1).GetBetTermForPlayer(SecureHelper.GetMarkSixOpenSeconds());
            ReloadBettings();
            if (this.InboundPage.IsNotNull())
                this.InboundPage.ReloadOrders();
            this.AwardSubPage.ReloadOrders();
        }

        private void bt_next_day_Click(object sender, EventArgs e)
        {
            this.CurrentSelectedTerm = this.CurrentSelectedTerm.ToDateTime(12).AddDays(1).GetBetTermForPlayer(SecureHelper.GetMarkSixOpenSeconds());
            ReloadBettings();
            if (this.InboundPage.IsNotNull())
                this.InboundPage.ReloadOrders();
            this.AwardSubPage.ReloadOrders();
        }

        private void bt_today_Click(object sender, EventArgs e)
        {
            this.CurrentSelectedTerm = System.DateTime.Now.GetBetTermForPlayer(SecureHelper.GetMarkSixOpenSeconds());
            ReloadBettings();
            if (this.InboundPage.IsNotNull())
                this.InboundPage.ReloadOrders();
            this.AwardSubPage.ReloadOrders();
        }
    }
}
