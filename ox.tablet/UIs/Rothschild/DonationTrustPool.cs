using OX.Bapps;
using OX.Cryptography;
using OX.IO;
using OX.Ledger;
using OX.Mining;
using OX.Mining.StakingMining;
using OX.Network.P2P.Payloads;
using OX.SmartContract;
using OX.Tablet;
using OX.Tablet.Config;
using OX.Wallets;
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

namespace OX.Tablet.UIs.Rothschild
{
    public partial class DonationTrustPool : UIPage, IBlockchainHandler
    {

        public DonationTrustPool()
        {
            InitializeComponent();
            this.Text = UIHelper.LocalString("捐赠信托池", "Donation Trust Pool");
            this.lb_roths_OXS.Text = UIHelper.LocalString("捐赠账户OXS余额:", "Donation OXS balance:");
            this.lb_roths_OXC.Text = UIHelper.LocalString("捐赠账户OXC余额:", "Donation OXC balance:");
            this.lb_trust_address.Text = UIHelper.LocalString("信托地址:", "Trust Address:");
            this.lb_trust_balance.Text = UIHelper.LocalString("信托余额:", "Trust Balance:");
            this.lb_trust_scope.Text = UIHelper.LocalString("信托范围:", "Trust Scope:");
            this.lb_truster_pubkey.Text = UIHelper.LocalString("委托人公钥", "Truster Public Key");
            this.lb_truster_address.Text = UIHelper.LocalString("委托人地址", "Truster Address");
            this.lb_trustee_pubkey.Text = UIHelper.LocalString("受托人公钥", "Trustee Public Key");
            this.lb_trustee_address.Text = UIHelper.LocalString("受托人地址", "Trustee Address");
        }
        #region IBlockChainTrigger
        public virtual void MenuPageSelected()
        {
            this.load();
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
        #endregion
        private void RegMinerForm_Load(object sender, EventArgs e)
        {
            this.load();
        }
        private void load()
        {
            this.lv_trust_scope.Nodes.Clear();
            this.lv_trust_assets.Nodes.Clear();
            var oxc_balance = string.Empty;
            var oxs_balance = string.Empty;
            var acts = Blockchain.Singleton.CurrentSnapshot.Accounts.GetAndChange(invest.MiningBuyBackFundAccountAddress, () => null);
            if (acts.IsNotNull())
            {
                oxc_balance = acts.GetBalance(Blockchain.OXC).ToString();
                oxs_balance = acts.GetBalance(Blockchain.OXS).ToString();
            }
            this.tb_roths_oxs.Text = oxs_balance.ToString();
            this.tb_roths_oxc.Text = oxc_balance.ToString();
            this.tb_truster_pubkey.Text = MiningTrustPoolHelper.Truster.ToString();
            this.tb_truster_address.Text = Contract.CreateSignatureRedeemScript(MiningTrustPoolHelper.Truster).ToScriptHash().ToAddress();
            this.tb_trustee_pubkey.Text = MiningTrustPoolHelper.Trustee.ToString();
            this.tb_trustee_address.Text = Contract.CreateSignatureRedeemScript(MiningTrustPoolHelper.Trustee).ToScriptHash().ToAddress();

            var TrustPoolAddress = MiningTrustPoolHelper.TrustPoolAddress;
            var accountState = Blockchain.Singleton.CurrentSnapshot.Accounts.GetAndChange(TrustPoolAddress, () => null);
            this.tb_trust_address.Text = TrustPoolAddress.ToAddress();
            foreach (var s in MiningTrustPoolHelper.AssetTargets)
            {
                this.lv_trust_scope.Nodes.Add(new TreeNode(UIHelper.LocalString($"{s.Key} 交易池地址:{s.Value}", $"{s.Key} Exchange Pool Address:{s.Value}")));
            }
            foreach (var asset in MiningTrustPoolHelper.TargetAssets)
            {
                if (accountState != default && accountState.Balances.TryGetValue(asset.Value, out Fixed8 balance))
                {
                    this.lv_trust_assets.Nodes.Add(new TreeNode(UIHelper.LocalString($"{asset.Key} 余额:{balance}", $"{asset.Key} Balance:{balance}")));
                }
            }
        }
    }
}
