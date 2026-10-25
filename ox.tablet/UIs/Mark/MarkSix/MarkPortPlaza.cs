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
    public partial class MarkPortPlaza : UIPage, IBlockchainHandler, ICurrentTerm
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));

        MethodButton CurrentMethodButton = default;
        public BaseBoundView InboundPage { get; private set; }

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
        BitMarkSixBet[] Bets;
        Dictionary<BitMarkSixBetTarget, uint> SelectedBets = new Dictionary<BitMarkSixBetTarget, uint>();
        public MarkPortPlaza()
        {
            InitializeComponent();
            this.setColor(bt_newBet, FocusColor);
            this.setColor(this.bt_today, FocusColor);

            this.Text = UIHelper.LocalString("庄家", "Banker");
            this.bt_next_day.Text = UIHelper.LocalString("后一天", "Next Day");
            this.bt_pre_day.Text = UIHelper.LocalString("前一天", "Pre Day");
            this.bt_newBet.Text = UIHelper.LocalString("双击下单", "2-hit Order");
            this.bt_newBet.UseDoubleClick = true;
            this.bt_newBet.DoubleClick += Bt_newBet_DoubleClick;
            this.L1.Text = UIHelper.LocalString("明细", "Details");

            InitMethods();
            CurrentSelectedTerm = System.DateTime.Now.GetBetTermForPlayer(SecureHelper.GetMarkSixOpenSeconds());
        }

        private void Bt_newBet_DoubleClick(object sender, EventArgs e)
        {
            if (SecureHelper.IsPlayer() || SecureHelper.IsBanker())
            {
                if (this.SelectedBets.IsNotNullAndEmpty())
                {
                    new MarkSixOrderDefenseForm(this.CurrentSelectedTerm, this.SelectedBets).ShowDialog();
                }
            }
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
        }

        void RefreshReaTimeTerms()
        {
            this.RealTimeTerm = System.DateTime.Now.GetBetTermForPlayer(SecureHelper.GetMarkSixOpenSeconds());
            this.DoInvoke(() =>
            {
                var enable = this.RealTimeTerm == this.CurrentSelectedTerm;
                this.bt_newBet.Enabled = enable;
                if (this.InboundPage.IsNotNull())
                    this.InboundPage.AllowEdit = enable;
            });
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
            this.InboundPage = new MarkSixPortOrderPage(this);
            this.tbc_order.AddPage(this.InboundPage);
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
            showMethodBettings();
        }
        void showMethodBettings()
        {
            this.pn_bettings.Controls.Clear();
            if (this.CurrentMethodButton.IsNotNull() && this.Bets.IsNotNull())
            {
                foreach (var betting in this.Bets.Where(m => m.BetTarget.Method == this.CurrentMethodButton.Method).OrderByDescending(m => m.Amount))
                {
                    var selected = this.SelectedBets.ContainsKey(betting.BetTarget);
                    var bpb = new PortBetPointButton(BetChannel.MarkSix, betting, selected);
                    bpb.OnBetPointClicked += Bpb_OnBetPointClicked;
                    this.pn_bettings.Controls.Add(bpb);
                }
            }
        }
        private void Bpb_OnBetPointClicked(PortBetPointButton bpb)
        {
            if (bpb.BetSelected)
            {
                this.SelectedBets[bpb.Bet.BetTarget] = bpb.Bet.Amount;
            }
            else
            {
                this.SelectedBets.Remove(bpb.Bet.BetTarget);
            }
            var total = this.SelectedBets.Sum(m => m.Value);
            this.lb_amount.Text = UIHelper.LocalString($"合计选择下注额:{total}", $"Total bet amount:{total}");
        }
        void ReloadBettings()
        {
            this.lb_amount.Text = string.Empty;
            this.pn_bettings.Controls.Clear();
            Bets = default;
            var bmsIndex = SecureHelper.BlockIndex.GetSubBlockIndex<BMSBlockIndex>();
            var orderPairs = bmsIndex.GetAll<PortMarkOrderTermKey, MarkBetOrder>(CasinoBizPersistencePrefixes.BMS_Port_MarkOrder, this.CurrentSelectedTerm);
            if (orderPairs.IsNotNull())
            {
                Bets = BitSixAgentHelper.CombineMarkOrders(orderPairs.Select(m => m.Value).ToArray());
            }
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
        }

        private void bt_next_day_Click(object sender, EventArgs e)
        {
            this.CurrentSelectedTerm = this.CurrentSelectedTerm.ToDateTime(12).AddDays(1).GetBetTermForPlayer(SecureHelper.GetMarkSixOpenSeconds());
            ReloadBettings();
            if (this.InboundPage.IsNotNull())
                this.InboundPage.ReloadOrders();
        }

        private void bt_today_Click(object sender, EventArgs e)
        {
            this.CurrentSelectedTerm = System.DateTime.Now.GetBetTermForPlayer(SecureHelper.GetMarkSixOpenSeconds());
            ReloadBettings();
            if (this.InboundPage.IsNotNull())
                this.InboundPage.ReloadOrders();
        }


    }
}
