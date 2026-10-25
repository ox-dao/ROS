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

    public partial class OutGoldRecordInfo : UserControl
    {
        OutGoldRecord outGoldRecord;
        public OutGoldRecordInfo(OutGoldRecord outGoldRecord)
        {
            this.outGoldRecord = outGoldRecord;
            InitializeComponent();
            this.uiGroupBox1.RectColor = Color.LightSkyBlue;
            this.uiGroupBox1.Text = outGoldRecord.TimeStamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss");
            this.lb_eth_txid.Text = UIHelper.LocalString($"以太坊交易哈希 :{outGoldRecord.EthTxId.ToString()}", $"Ethereum TxId:{outGoldRecord.EthTxId.ToString()}");
            this.lb_amt.Text = UIHelper.LocalString($"金额:{outGoldRecord.Amount}", $"Amount:{outGoldRecord.Amount}");

        }

       





        private void lb_master_balance_Click(object sender, EventArgs e)
        {

        }

        private void bt_transfer_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void lb_eth_txid_DoubleClick(object sender, EventArgs e)
        {
            var txid = this.outGoldRecord.EthTxId.ToString();
            Clipboard.SetText(txid);
            string msg = txid + UIHelper.LocalString("  已复制", "  copied");
            UIMessageBox.Show(msg, "");
        }
    }
}
