using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Akka.Actor;
using OX.BMS;
using OX.Ledger;
using OX.Network.P2P.Payloads;
using OX.Tablet.Config;
using OX.Tablet.UIs.MarkSix;
using Sunny.UI;
using OX.IO;

namespace OX.Tablet.UIs.Mark.MarkSix
{
    public partial class MarkSixOrderForm : UIForm
    {
        MarkTerm Term;
        Action Action;
        public MarkSixOrderForm(MarkTerm term, Action action)
        {
            Term = term;
            InitializeComponent();
            this.Text = UIHelper.LocalString("六合彩下单", "Mark Six Order");
            this.bt_close.Text = UIHelper.LocalString("关闭", "Close");
            this.bt_order.Text = UIHelper.LocalString("下单", "Order");
            this.Action = action;
        }

        private void MarkSixOrderForm_Load(object sender, EventArgs e)
        {
            foreach (var r in NoneFlagEnumHelper.All<MarkSixRound>())
            {
                var page = new MarkSixOrderPage(Term, r);
                page.PageIndex = r.Value();
                this.tb_rounds.AddPage(page);
            }
            var builder = new SimpleMarkSixBoundBuilder();
            var total = builder.GetMemoryOrderSet().Amount;
            var balance = SecureHelper.GetMasterAvailableBalance(Blockchain.OXC);
            this.lb_amount.Text = UIHelper.LocalString($"总投注额:{total}   /  账户余额:{balance}", $"total amount:{total}  /  account balance:{balance}");
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_order_Click(object sender, EventArgs e)
        {
            var pp = this.tb_rounds.SelectedTab.GetControls<MarkSixOrderPage>().FirstOrDefault();
            if (pp.IsNotNull() && pp.SelectedBox.IsNotNull())
            {
                List<BitMarkSixBet> bets = new List<BitMarkSixBet>();
                var builder = new SimpleMarkSixBoundBuilder();
                foreach (var set in builder.GetMemoryOrderSet().BetSets)
                {
                    foreach (var item in set.Value.BetItems)
                    {
                        bets.Add(new BitMarkSixBet { Amount = item.Value, BetTarget = item.Key });
                    }
                }
                if (bets.IsNotNull())
                {
                    if (pp.SelectedBox.Member.AllowBet(bets, out var betRemaind))
                    {
                        var latest = this.Term.ToDateTime().AddSeconds(SecureHelper.GetMarkSixLastBetSeconds());
                        var UTCLatest = latest.ToTimestamp();
                        var UTCEarliest = latest.AddHours(-24).AddMinutes(2).ToTimestamp();

                        MarkBetOrder order = new MarkBetOrder
                        {
                            ChannelRound = new MarkChannelRound { Channel = BetChannel.MarkSix, Round = (byte)pp.SelectedBox.Round },
                            PortHolder = pp.SelectedBox.Member.Holder,
                            Player = SecureHelper.MasterAccount.ScriptHash,
                            Term = this.Term,
                            BetItems = bets.ToArray()
                        };
                        var balance = SecureHelper.GetMasterAvailableBalance(Blockchain.OXC);
                        if (balance >= Fixed8.One * (order.Amount + 2))
                        {
                            TransactionOutput output = new TransactionOutput()
                            {
                                AssetId = Blockchain.OXC,
                                ScriptHash = pp.SelectedBox.Member.BetAddress,
                                Value = Fixed8.One * order.Amount
                            };
                            var tx = new AskTransaction
                            {
                                Flag = 1,
                                MaxIndex = UTCLatest,
                                MinIndex = UTCEarliest,
                                From = SecureHelper.MasterAccount.Key.PublicKey,
                                Outputs = new[] { output },
                                DataType = (byte)CasinoType.MarkBet,
                                Data = order.ToArray(),
                                BizScriptHash = casino.CasinoMasterAccountAddress,
                                Inputs = new CoinReference[0],
                            };
                            var newTx = tx.BuildAndSignOneOXCOutput(Fixed8.One * 2);
                            if (newTx.IsNotNull() && newTx.Verify(Blockchain.Singleton.CurrentSnapshot, Blockchain.Singleton.MemPool.GetVerifiedTransactions()))
                            {
                                TabletBlockHandler.Instance.Tell(newTx);
                                foreach (var coin in newTx.Inputs)
                                {
                                    SecureHelper.BlockIndex.UnconfirmCoins[coin] = Blockchain.Singleton.Height + 100;
                                }
                                builder.GetMemoryOrderSet().ClearAll();
                                new WaitTxForm(newTx, UIHelper.LocalString("等待确认下单...", "Waiting  confirm order...")).ShowDialog();
                                this.Close();
                                if (this.Action.IsNotNull())
                                    this.Action.Invoke();
                            }
                        }
                    }
                    else
                    {
                        this.lb_msg.Text = UIHelper.LocalString($"该庄家最大受注额仅剩：{betRemaind}", $"The banker maximum bet amount left for you is only {betRemaind}");
                    }
                }
            }
        }

        private void tb_rounds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
