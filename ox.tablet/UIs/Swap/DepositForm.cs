using Akka.Actor;
using Akka.Actor.Dsl;
using Akka.Util;
using Org.BouncyCastle.Asn1.X509;
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
    public partial class DepositForm : UIForm
    {
        OTCDealerMerge OTCDealerMerge;
        string SSID;
        string PWD;
        string apiurl;
        CancellationTokenSource tokenSouce = new CancellationTokenSource();
        public DepositForm(OTCDealerMerge dealerMerge)
        {
            this.OTCDealerMerge = dealerMerge;
            InitializeComponent();
        }

        private void ClaimForm_Load(object sender, EventArgs e)
        {
            this.btnCancel.Text = UIHelper.LocalString("取消", "Close");
            this.lb_step1.Text = UIHelper.LocalString("第一步，手机连接本机同一网络", "Step 1, connect WIFI as PC");
            this.lb_step2.Text = UIHelper.LocalString("第二步，Web3钱包扫码支付以太币", "Step 2，Web3 Wallet Scan Code to Pay Ethereum");
            this.bt_copy_url.Text = UIHelper.LocalString("打开", "Open");
            var isChina = UIHelper.IsChina();
            WiFiHelper.Reg936(isChina);
            SSID = WiFiHelper.GetConnectedWifi(isChina);
            if (SSID.IsNotNullAndEmpty())
            {
                PWD = WiFiHelper.GetWifiPassword(SSID, isChina);
            }
            this.lb_wifi_ssid.Text = UIHelper.LocalString($"WIFI 名称:{SSID}", $"SSID:{SSID}");
            this.lb_wifi_pwd.Text = UIHelper.LocalString($"WIFI 密码:{PWD}", $"Password:{PWD}");
            var qrString = WiFiHelper.GetQRString(SSID, PWD);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            this.img_wifi.Image = qrCode.GetGraphic(20);
            
            //var ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(p => p.AddressFamily.ToString() == "InterNetwork" && !p.IsIPv6LinkLocal).FirstOrDefault();
            var ip = GetLocalPrivateIpByNic();
            var hex = System.Text.Encoding.UTF8.GetBytes(OTCDealerMerge.EthAddress).ToHexString();
            apiurl = $"https://{ip.ToString()}/deposit/{hex}";
            QRCodeData qrapiData = qrGenerator.CreateQrCode(apiurl, QRCodeGenerator.ECCLevel.Q);
            QRCode qrApi = new QRCode(qrapiData);
            this.img_wallet.Image = qrApi.GetGraphic(20);
            WebHostHelper.StartWeb(tokenSouce.Token);
        }
        public static IPAddress? GetLocalPrivateIpByNic()
        {
            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // 跳过未启用、回环、隧道网卡
                if (nic.OperationalStatus != OperationalStatus.Up)
                    continue;
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    continue;
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                    continue;

                // 重点：先调用 GetIPProperties()，再拿 UnicastAddresses
                var ipProps = nic.GetIPProperties();
                foreach (var addrInfo in ipProps.UnicastAddresses)
                {
                    IPAddress ip = addrInfo.Address;
                    if (ip.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    byte[] b = ip.GetAddressBytes();
                    bool isPrivate =
                        b[0] == 10 ||
                        (b[0] == 172 && b[1] >= 16 && b[1] <= 31) ||
                        (b[0] == 192 && b[1] == 168);

                    if (isPrivate)
                    {
                        return ip;
                    }
                }
            }
            return null;
        }

        private void ClaimForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.tokenSouce.Cancel();
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_copy_url_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(apiurl) { UseShellExecute = true });
        }
    }
}
