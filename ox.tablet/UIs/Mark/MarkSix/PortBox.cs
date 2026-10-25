using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OX.Network.P2P;
using Sunny.UI;
using Akka.Actor;
using OX.Ledger;
using OX.BMS;
using OX.Network.P2P.Payloads;
using OX.Bapps;
using OX.Tablet.UIs.MarkSix;
using System.Runtime;
using OX.Tablet.Config;

namespace OX.Tablet
{
    public delegate void PortBoxSelected(PortBox portBox);
    public partial class PortBox : UserControl, IBlockchainHandler
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
        bool _selected = false;
        public bool Selected
        {
            get { return _selected; }
            private set
            {
                _selected = value;
                this.uiGroupBox1.RectColor = _selected ? Color.Red : Color.LightSkyBlue;
                this.PortBoxSelected?.Invoke(this);
            }
        }
        MarkTerm Term;
        public MarkSixRound Round {  get; private set; }
        public MixMarkMember Member { get; private set; }
        public event PortBoxSelected PortBoxSelected;
        public PortBox(MarkTerm term, MixMarkMember member, MarkSixRound round)
        {
            this.Term = term;
            this.Member = member;
            Round = round;
            InitializeComponent();
            this.uiGroupBox1.Text = member.MarkMemberId.ToString();
            this.uiGroupBox1.RectColor = Color.LightSkyBlue;
            this.DoubleClick += BankerInfo_DoubleClick;
            this.uiGroupBox1.DoubleClick += BankerInfo_DoubleClick;
            RefreshState();
        }

        private void BankerInfo_DoubleClick(object sender, EventArgs e)
        {
        }

        private void lb_master_balance_Click(object sender, EventArgs e)
        {
            this.Selected = !this.Selected;
        }

        public void HeartBeat(HeartBeatContext beatContext)
        {

        }
        public void BeforeBlock(Block block) { }
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
            RefreshState();
        }
        public void RefreshState()
        {
            this.lb_total_bet.Text = UIHelper.LocalString($"累计投注:{Member.TotalBetAmount}", $"Total Bet:{Member.TotalBetAmount}");
           ulong currentAmount= Member.TermBetAmount;
            if (this.Term != Member.LastTerm)
                currentAmount = 0;
            this.lb_total_term.Text = UIHelper.LocalString($"本期投注:{currentAmount}", $"Current Bet:{currentAmount}");
            this.lb_deposit.Text = string.Empty;
            var act = Blockchain.Singleton.CurrentSnapshot.Accounts.TryGet(Member.PoolAddress);
            if (act.IsNotNull())
            {
                var balance = act.GetBalance(Blockchain.OXC);
                this.lb_deposit.Text = UIHelper.LocalString($"保证金:{balance.ToString("f0")} OXC", $"Bond:{balance.ToString("f0")} OXC");
            }
            act = Blockchain.Singleton.CurrentSnapshot.Accounts.TryGet(Member.Holder);
            if (act.IsNotNull())
            {
                var balance = act.GetBalance(Blockchain.OXC);
                this.lb_balance.Text = UIHelper.LocalString($"主余额:{balance.ToString("f0")} OXC", $"Balance:{balance.ToString("f0")} OXC");
            }
        }


        public void SetSelectState(bool selected)
        {
            _selected = selected;
            this.uiGroupBox1.RectColor = _selected ? Color.Red : Color.LightSkyBlue;
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
    }
}
