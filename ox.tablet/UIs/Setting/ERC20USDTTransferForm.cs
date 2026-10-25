using Akka.Event;
using OX.Ledger;
using Sunny.UI;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using OX.IO;
using OX.Network.P2P.Payloads;
using Nethereum.Util;
using OX.Wallets;
using Nethereum.Signer.Crypto;
using OX.SmartContract;
using OX.Tablet.Config;
using System.Linq;
using Akka.Util;
namespace OX.Tablet.UIs.Setting
{
    public partial class ERC20USDTTransferForm : BaseTransferForm
    {
        string EthAddress;
        public ERC20USDTTransferForm(string ethAddress)
        {
            this.EthAddress = ethAddress;
            InitializeComponent();

            this.cb_contacts.Text = this.EthAddress;
            this.Text = UIHelper.LocalString("支付 ERC20 USDT", "Transfer ERC20 USDT");
            this.lb_amount.Text = UIHelper.LocalString("金额:", "Amount:");
            this.lb_address.Text = UIHelper.LocalString("收款地址:", "Recipient Address:");
            this.lb_usdt_balance.Text = UIHelper.LocalString("USDT 余额:", "USDT Balance:");
            this.lb_ether_balance.Text = UIHelper.LocalString("ETH 余额:", "ETH Balance:");
            this.btnOK.Text = UIHelper.LocalString("转账", "Transfer");
            this.btnCancel.Text = UIHelper.LocalString("取消", "Cancel");
            this.bt_query_balance.Text = UIHelper.LocalString("查询余额", "Query Balance");
        }
        public override Transaction BuildTx()
        {
            return default;
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            var balanceResult = await EthereumTransactionHelper.GetEthereumBuilder().TransferUSDT(this.cb_contacts.Text, decimal.Parse(this.tb_amount.Text));
            if (balanceResult.result)
            {
                var m1 = balanceResult.result ? "成功" : "失败";
                var m2 = balanceResult.result ? "success" : "failed";
                this.ShowSuccessTip(UIHelper.LocalString($"转账{m1},{balanceResult.txid}", $"transfer {m2}, {balanceResult.txid}"), 5000);
            }
            else
            {
                if (balanceResult.code == int.MinValue)
                    this.ShowSuccessTip(UIHelper.LocalString($"转账失败，可能是Ethereum节点问题,建议稍后重试," + balanceResult.txid, "Failed to transfer, please try again later," + balanceResult.txid), 10000);
                else
                    this.ShowSuccessTip(UIHelper.LocalString($"转账失败,请检查USDT跟Ether余额", "Failed to transfer, please check USDT and ETH balances"), 10000);
            }
        }

        private async void bt_query_balance_Click(object sender, EventArgs e)
        {
            var balanceResult = await EthereumTransactionHelper.GetEthereumBuilder().GetEthAndUSDTBalance();
            if (balanceResult.result)
            {
                this.tb_ether_balance.Text = balanceResult.ether_balance.ToString();
                this.tb_usdt_balance.Text = balanceResult.usdt_balance.ToString();
            }
             
        }
    }
}