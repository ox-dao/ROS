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
using OX.Tablet.UIs.Mark.MarkSix;

namespace OX.Tablet.UIs.MarkSix
{
    public partial class MarkSixPlayerOrderPage : BaseBoundView
    {

        MarkPlayerPlaza ParentPage;
        public MarkSixPlayerOrderPage(MarkPlayerPlaza parentPage)
        {
            this.ParentPage = parentPage;
            InitializeComponent();
            this.Text = UIHelper.LocalString("下注订单", "Outbound Orders");
        }



        public override void HeartBeat(HeartBeatContext beatContext)
        {

        }
        public override void BeforeBlock(Block block)
        {

        }
        public override void OnBlock(Block block)
        {

        }
        public override void AfterBlock(Block block)
        {

        }
        public override void OnClipboardString(ClipboardMessageType messageType, string msg)
        {
            if (messageType == ClipboardMessageType.MarkOrder)
                ReloadOrders();
        }
        public override void ReloadOrders()
        {
            this.tv_inbound_orders.Nodes.Clear();
            var bmsIndex = SecureHelper.BlockIndex.GetSubBlockIndex<BMSBlockIndex>();
            GuessAnswer unionAnswer = default;
            GuessAnswer macauAnswer = default;
            var member = SecureHelper.GetMarkMember();
            if (member.IsNotNull())
            {
                GuessAnswerKey uniongak = new GuessAnswerKey
                {
                    ChannelRound = new MarkChannelRound(BetChannel.MarkSix, (byte)MarkSixRound.MarkUnion),
                    Term = this.ParentPage.CurrentSelectedTerm
                };
                if (bmsIndex.GuessAnswers.TryGetValue(uniongak.ToString(), out unionAnswer))
                {

                }
                GuessAnswerKey macaugak = new GuessAnswerKey
                {
                    ChannelRound = new MarkChannelRound(BetChannel.MarkSix, (byte)MarkSixRound.MarkMacau),
                    Term = this.ParentPage.CurrentSelectedTerm
                };
                if (bmsIndex.GuessAnswers.TryGetValue(macaugak.ToString(), out macauAnswer))
                {

                }
            }

            var orderPairs = bmsIndex.GetAll<PlayerMarkOrderTermKey, MarkBetOrder>(CasinoBizPersistencePrefixes.BMS_Player_MarkOrder, this.ParentPage.CurrentSelectedTerm);
            if (orderPairs.IsNotNullAndEmpty())
            {
                foreach (var rs in orderPairs.GroupBy(m => m.Value.ChannelRound.Round))
                {
                    MarkSixRound msr = (MarkSixRound)rs.Key;
                    var names = msr.GetName();
                    TreeNode roundNode = new TreeNode { Text = UIHelper.LocalString(names.Name, names.EngName) };
                    foreach (var g in rs.GroupBy(m => m.Key.PortMemberId).OrderBy(m => m.Key))
                    {

                        TreeNode portNode = new TreeNode { Text = $"{g.Key}" };
                        foreach (var pair in g.OrderByDescending(m => m.Value.Amount))
                        {
                            GuessAnswer answer = default;
                            if (pair.Value.ChannelRound.Round == (byte)MarkSixRound.MarkUnion)
                            {
                                answer = unionAnswer;
                            }
                            else if (pair.Value.ChannelRound.Round == (byte)MarkSixRound.MarkUnion)
                            {
                                answer = macauAnswer;
                            }
                            //uint prize = 0;
                            //if (member.IsNotNull() && answer.IsNotNull())
                            //    prize = member.MarkSetting.CheckBet(answer, order.Value.BetItems);
                            TreeNode orderNode = new TreeNode { Text = $"{pair.Key.Timestamp.ToDateTime().ToLocalTime()}#{pair.Value.Amount}" };
                            //if (prize > 0)
                            //    orderNode.ForeColor = Color.Red;
                            foreach (var betItem in pair.Value.BetItems)
                            {
                                MarkSixBetMethod m = (MarkSixBetMethod)betItem.BetTarget.Method;
                                var methodSetting = m.GetMethodSetting();
                                if (methodSetting.IsNotNull())
                                {
                                    var name = UIHelper.LocalString(methodSetting.Name, methodSetting.EngName);
                                    var str = betItem.BetTarget.BetPoint.ToDisplayString(BetChannel.MarkSix, betItem.BetTarget.Method, UIHelper.IsChina());
                                    var texstr = $"{name}[{str}]:{betItem.Amount}";
                                    TreeNode subnode = new TreeNode { Text = texstr };
                                    if (answer.IsNotNull() && answer.VerifyBet(betItem.BetTarget))
                                    {
                                        subnode.ForeColor = Color.Red;
                                    }
                                    orderNode.Nodes.Add(subnode);
                                }
                            }
                            portNode.Nodes.Add(orderNode);
                        }
                        roundNode.Nodes.Add(portNode);
                    }
                    this.tv_inbound_orders.Nodes.Add(roundNode);
                }
            }
        }
        public override void MenuPageSelected()
        {
            ReloadOrders();
        }



        private void OrderHistory_Initialize(object sender, EventArgs e)
        {

        }



        private void tv_inbound_orders_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!BetUIHelper.AllowOrderSwitchCheck)
                e.Cancel = true;
        }



    }
}
