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
using OX.Wallets;
using OX.Tablet.Config;
using OX.Mining.OTC;
using OX.BMS;

namespace OX.Tablet
{

    public partial class InGoldRecordInfo : UserControl
    {
        InGoldRecord inGoldRecord;
        public InGoldRecordInfo(InGoldRecord inGoldRecord)
        {
            this.inGoldRecord = inGoldRecord;
            InitializeComponent();
            this.uiGroupBox1.RectColor = Color.LightSkyBlue;
            this.uiGroupBox1.Text = inGoldRecord.TimeStamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss");
            this.bt_transfer.Enabled = inGoldRecord.State == InOutGoldStatus.Inited;
            this.bt_transfer.Text = UIHelper.LocalString("重提交", "Re-Submit");
            this.lb_eth_txid.Text = UIHelper.LocalString($"以太坊交易哈希 :{inGoldRecord.EthTxId.ToString()}", $"Ethereum TxId:{inGoldRecord.EthTxId.ToString()}");
            this.lb_state.Text = UIHelper.LocalString($"状态:{inGoldRecord.State.GetName().Name}", $"State:{inGoldRecord.State.GetName().EngName}");
            this.lb_amt.Text = UIHelper.LocalString($"金额:{inGoldRecord.Amount}", $"Amount:{inGoldRecord.Amount}");

        }

        private void bt_transfer_Click(object sender, EventArgs e)
        {
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            if (!miningIndex.InGoldRecords.TryGetValue(inGoldRecord.EthTxId, out var r) || r.State == InOutGoldStatus.Inited)
            {
                if (OTCDealerHelper.DoSimpleDeposit(inGoldRecord.EthTxId.ToString(), out var tx) && tx.IsNotNull())
                {
                    TabletBlockHandler.Instance.Tell(tx);
                    foreach (var coin in tx.Inputs)
                    {
                        SecureHelper.BlockIndex.UnconfirmCoins[coin] = Blockchain.Singleton.Height + 100;
                    }
                }
            }
        }





        private void lb_master_balance_Click(object sender, EventArgs e)
        {

        }

        private void bt_transfer_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void lb_eth_txid_DoubleClick(object sender, EventArgs e)
        {
           var txid= this.inGoldRecord.EthTxId.ToString();
            Clipboard.SetText(txid);
            string msg = txid + UIHelper.LocalString("  已复制", "  copied");
            UIMessageBox.Show(msg, "");
        }
    }
}
