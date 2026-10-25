using Akka.IO;
using Akka.Actor;
using Org.BouncyCastle.Bcpg;
using OX.BMS;
using OX.DirectSales;
using OX.Ledger;
using OX.Network.P2P.Payloads;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Sunny.UI.Win32;
using OX.Tablet.UIs.Mark;
using OX.Tablet.Config;
using OX.IO;
using OX.Tablet.UIs.Mark.MarkSix;

namespace OX.Tablet.UIs.MarkSix
{
    public partial class MarkSixOrderPage : UIPage, IBlockchainHandler
    {
        MarkTerm Term;
        MarkSixRound Round;
        protected Dictionary<UInt160, PortBox> BankerBriefs = new Dictionary<UInt160, PortBox>();
        public PortBox SelectedBox { get; private set; }
        public MarkSixOrderPage(MarkTerm term, MarkSixRound round)
        {
            this.Term = term;
            this.Round = round;
            InitializeComponent();
            var names = round.GetName();
            this.Text = UIHelper.LocalString(names.Name, names.EngName);
            InitPorts();
        }
        void InitPorts()
        {
            this.DoInvoke(() =>
            {
                if (SecureHelper.IsPlayer() || SecureHelper.IsBanker())
                {
                    var basicBankerMinBond = SecureHelper.GetBasicBankerMinBond();
                    var seniorBankerMinBond = SecureHelper.GetSeniorBankerMinBond();
                    var bmsIndex = SecureHelper.BlockIndex.GetSubBlockIndex<BMSBlockIndex>();
                    this.pn_ports.Clear();
                    this.BankerBriefs.Clear();
                    int bbIndex = 1;
                    foreach (var member in bmsIndex.AllMarkMembers.Where(m => m.Request.MemberType == MarkMemberType.Banker))
                    {
                        if (member.MarkSetting.IsNotNull()&& member.MarkSetting.MergedMarkSixRound.Contains(this.Round))
                        {
                            Fixed8 bondBalance = member.MemberBond();
                            var myBondBalance = SecureHelper.GetMarkMember().MemberBond();
                            bool ok = bondBalance >= basicBankerMinBond && bondBalance < seniorBankerMinBond;
                            if (myBondBalance >= basicBankerMinBond)
                            {
                                ok = bondBalance >= basicBankerMinBond;
                            }
                            if (ok)
                            {
                                var bb = new PortBox(this.Term, member, this.Round);
                                bb.TabIndex = bbIndex++;
                                this.BankerBriefs[member.PoolAddress] = bb;
                                bb.PortBoxSelected += Bb_BoxSelected;
                            }
                        }
                    }
                    foreach (var b in this.BankerBriefs.Values.OrderByDescending(m => m.Member.TotalPrizeAmount))
                    {
                        this.pn_ports.Add(b);
                    }
                }
            });
        }
        private void Bb_BoxSelected(PortBox bb)
        {
            this.SelectedBox = bb;
            foreach (var c in this.pn_ports.GetAllControls())
            {
                if (c is PortBox bi)
                {
                    if (bi != bb)
                    {
                        bi.SetSelectState(false);
                    }
                }
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

        }





        private void OrderHistory_Initialize(object sender, EventArgs e)
        {

        }





        private void tv_inbound_orders_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {

        }

    }
}
