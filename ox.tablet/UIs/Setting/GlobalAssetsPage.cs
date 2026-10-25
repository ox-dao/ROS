using Akka.Actor;
using Akka.IO;
using Org.BouncyCastle.Bcpg;
using OX.BMS;
using OX.DirectSales;
using OX.Ledger;
using OX.Network.P2P.Payloads;
using OX.Tablet.Config;
using OX.Wallets;
using OX.SmartContract;
using OX.Cryptography.ECC;
using Sunny.UI;
using Sunny.UI.Win32;
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

namespace OX.Tablet.UIs.Setting
{
    public partial class GlobalAssetsPage : UIPage, IBlockchainHandler
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));


        public GlobalAssetsPage()
        {
            InitializeComponent();
            this.showAssets();
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

        public virtual void MenuPageSelected() { showAssets(); }
        void showAssets()
        {
            var blockIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            this.tv_nativeAssets.Nodes.Clear();
            this.tv_tokenAssets.Nodes.Clear();
            var oxsNode = new TreeNode($"OXS ({Blockchain.OXS.ToString()})");
            var oxcNode = new TreeNode($"OXC ({Blockchain.OXC.ToString()})");
            var oxsIssued = Blockchain.Singleton.CurrentSnapshot.Assets.TryGet(Blockchain.OXS).Available;
            oxsNode.Nodes.Add(new TreeNode(UIHelper.LocalString($"已发行： {oxsIssued}", $"Issued: {oxsIssued}")));
            var oxcIssued = blockIndex.TotalIssuedOXC;
            oxcNode.Nodes.Add(new TreeNode(UIHelper.LocalString($"已发行： {oxcIssued}", $"Issued: {oxcIssued}")));
            this.tv_nativeAssets.Nodes.Add(oxsNode);
            this.tv_nativeAssets.Nodes.Add(oxcNode);

            this.tv_tokenAssets.Nodes.Clear();
            foreach (var asset in Blockchain.Singleton.Store.GetAssets().Find().Where(m => !m.Key.Equals(Blockchain.OXS) && !m.Key.Equals(Blockchain.OXC)))
            {
                var node = new TreeNode(asset.Value.GetName());
                var subnode = new TreeNode(UIHelper.LocalString($"资产Id:{asset.Key.ToString()}", $"Asset Id:{asset.Key.ToString()}"));
                subnode.Tag = asset.Value;
                node.Nodes.Add(subnode);
                var owner =Contract.CreateSignatureRedeemScript(asset.Value.Owner).ToScriptHash().ToAddress();
                subnode = new TreeNode(UIHelper.LocalString($"资产所有者:{owner}", $"Asset Owner:{owner}"));
                subnode.Tag = asset.Value;
                node.Nodes.Add(subnode);
                subnode = new TreeNode(UIHelper.LocalString($"资产管理者:{asset.Value.Admin.ToAddress()}", $"Asset Admin:{asset.Value.Admin.ToAddress()}"));
                subnode.Tag = asset.Value;
                node.Nodes.Add(subnode);
                subnode = new TreeNode(UIHelper.LocalString($"资产分发者:{asset.Value.Issuer.ToAddress()}", $"Asset Issuer:{asset.Value.Issuer.ToAddress()}"));
                subnode.Tag = asset.Value;
                node.Nodes.Add(subnode);
                subnode = new TreeNode { Text = UIHelper.LocalString($"精度:{asset.Value.Precision}", $"Precision:{asset.Value.Precision}") };
                subnode.Tag = asset.Value;
                node.Nodes.Add(subnode);
                var cap = asset.Value.Amount == -Fixed8.Satoshi ? UIHelper.LocalString("无限", "unlimited") : asset.Value.Amount.ToString();
                subnode = new TreeNode { Text = UIHelper.LocalString($"总量:{cap}", $"Cap:{cap}") };
                subnode.Tag = asset.Value;
                node.Nodes.Add(subnode);
                var Available = asset.Value.Available.ToString();
                subnode = new TreeNode { Text = UIHelper.LocalString($"已发行:{Available}", $"Issued:{Available}") };
                subnode.Tag = asset.Value;
                node.Nodes.Add(subnode);

                this.tv_tokenAssets.Nodes.Add(node);
            }

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



        private void OrderHistory_Initialize(object sender, EventArgs e)
        {

        }




    }
}
