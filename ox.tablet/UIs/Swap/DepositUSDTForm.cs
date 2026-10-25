using Akka.Actor;
using Akka.Actor.Dsl;
using Akka.Util;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities.Net;
using OX.Bapps;
using OX.Casino;
using OX.IO.Actors;
using OX.Ledger;
using OX.Mining.OTC;
using OX.Network.P2P;
using OX.Network.P2P.Payloads;
using OX.Persistence;
using OX.Tablet.Config;
using OX.Wallets;
using QRCoder;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OX.Tablet
{
    public partial class DepositUSDTForm : UIForm
    {
        OTCDealerMerge OTCDealerMerge;

        public DepositUSDTForm(OTCDealerMerge dealerMerge)
        {
            this.OTCDealerMerge = dealerMerge;
            InitializeComponent();
        }

        private void ClaimForm_Load(object sender, EventArgs e)
        {
            this.btnCancel.Text = UIHelper.LocalString("取消", "Close");
            this.btOK.Text = UIHelper.LocalString("支付", "Pay");
            this.lb_amount.Text = UIHelper.LocalString("金额:", "Amount:");
            this.lb_usdt_balance.Text = UIHelper.LocalString("USDT 余额:", "USDT Balance:");
            this.lb_ether_balance.Text = UIHelper.LocalString("ETH 余额:", "ETH Balance:");
            this.bt_query_balance.Text = UIHelper.LocalString("查询余额", "Query Balance");
        }


        private void ClaimForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }






        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btOK_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(this.tb_amount.Text, out var amt))
            {
                var st = this.OTCDealerMerge.EthAddress.BuildOTCDealerTransaction();
                var OTCDealerOXPoolScriptHash = st.GetContract().ScriptHash;
                var ts = DateTime.Now.ToTimestamp();
                string stringToSign = $"{OTCDealerOXPoolScriptHash.ToAddress()}--{ts}";
                var marks = System.Text.Encoding.UTF8.GetBytes(stringToSign);
                var transferUsdtResult = await EthereumTransactionHelper.GetEthereumBuilder().TransferUSDTWithMark(this.OTCDealerMerge.EthAddress, amt, marks);
                if (transferUsdtResult.result)
                {
                    var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
                    miningIndex.SaveInGoldRecord(new InGoldRecord()
                    {
                        EthTxId = UInt256.Parse(transferUsdtResult.txid),
                        State = InOutGoldStatus.Inited,
                        TimeStamp = DateTime.Now.ToTimestamp(),
                    });
                    if (OTCDealerHelper.DoSimpleDeposit(transferUsdtResult.txid, out var tx) && tx.IsNotNull())
                    {
                        TabletBlockHandler.Instance.Tell(tx);
                        foreach (var coin in tx.Inputs)
                        {
                            SecureHelper.BlockIndex.UnconfirmCoins[coin] = Blockchain.Singleton.Height + 100;
                        }
                    }
                }
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
