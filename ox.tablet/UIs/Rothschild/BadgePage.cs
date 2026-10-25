using Akka.Actor;
using Akka.IO;
using Org.BouncyCastle.Bcpg;
using OX.Bapps;
using OX.BMS;
using OX.DirectSales;
using OX.Ledger;
using OX.Mining;
using OX.Network.P2P.Payloads;
using OX.Tablet.Config;
using OX.Wallets;
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

namespace OX.Tablet.UIs.Rothschild
{
    public partial class BadgePage : UIPage, IBlockchainHandler
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));


        public BadgePage()
        {
            InitializeComponent();
            this.line_rosKing.Text = UIHelper.LocalString("玫瑰王徽章", "ROS King Badge");
            this.lb_badgeWitnessAddress.Text = UIHelper.LocalString($"玫瑰王徽章见证地址:{MutualLockMiningHelper.GenesisSeed().ToAddress()}", $"ROS King Badge Witness Address:{MutualLockMiningHelper.GenesisSeed().ToAddress()}");
            this.bt_copyRosKingWitnessAddr.Text = UIHelper.LocalString("复制", "Copy");
            this.line_viewSpaceTimeVolume.Text = UIHelper.LocalString("查看有效时空锁仓总量", "View Space-time Volume");
            this.lb_assetId.Text = UIHelper.LocalString("资产ID:", "Asset ID:");
            this.lb_badgeAddr.Text = UIHelper.LocalString("徽章地址:", "Badge Address:");
            this.lb_lockVolume.Text = UIHelper.LocalString("锁仓量:", "Space-time Volume:");
            this.bt_queryVolume.Text = UIHelper.LocalString("查询", "Query");
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            string s = string.Empty;
            var badgeWitnessAddressSH = SecureHelper.MasterAccount.ScriptHash.GetMutualLockSeed();
            if (miningIndex.MutualLockNodes.TryGetValue(badgeWitnessAddressSH, out var miner))
            {
                s = invest.MasterAccountAddress.Equals(miner.ParentHolder) ? UIHelper.LocalString("(骑士)", "(Knight) ") : string.Empty;
                var badgeWitnessAddress = badgeWitnessAddressSH.ToAddress();
                this.lb_myBadgeWitnessAddr.Text = UIHelper.LocalString($"见证地址:{badgeWitnessAddress}", $"Witness Address:{badgeWitnessAddress}");
                this.lb_myBadgeSeedAddr.Text = UIHelper.LocalString($"种子徽章:{miner.ParentHolder.ToAddress()}", $"Seed Badge:{miner.ParentHolder.ToAddress()}");
            }
            this.line_myBadge.Text = UIHelper.LocalString($"我的徽章{s}", $"My Badge{s}");
            this.bt_copyMyWitnessAddress.Text = UIHelper.LocalString("复制", "Copy");
            this.line_leafBadge.Text = UIHelper.LocalString($"叶子徽章", $"Leaf Badge");
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

        public virtual void MenuPageSelected()
        {
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            var badgeWitnessAddressSH = SecureHelper.MasterAccount.ScriptHash.GetMutualLockSeed();
            if (miningIndex.MutualLockNodes.TryGetValue(badgeWitnessAddressSH, out var miner))
            {
                var rem = miner.RegIndex % 100000;
                var rem2 = Blockchain.Singleton.Height % 100000;
                if (rem2 > rem) rem += 100000;
                var sub = rem - rem2;
                this.lb_discount.Text = UIHelper.LocalString($"收益倒计时:{sub}", $"Income Countdown:{sub}");

                this.panel_leaf.Controls.Clear();
                var lfs = miningIndex.MutualLockNodes.Values.Where(m => m.ParentHolder == miner.HolderAddress);
                foreach (var LeafHolder in lfs)
                {
                    var leafrem = LeafHolder.RegIndex % 100000;
                    var leafString = UIHelper.LocalString($"叶子徽章({leafrem}):{LeafHolder.HolderAddress.ToAddress()}", $"Leaf Badge({leafrem}):{LeafHolder.HolderAddress.ToAddress()}");
                    this.panel_leaf.Controls.Add(new UILabel() { Text = leafString,AutoSize=true });
                }
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

        private void bt_copyRosKingWitnessAddr_Click(object sender, EventArgs e)
        {
            try
            {
                var s = MutualLockMiningHelper.GenesisSeed().ToAddress();
                Clipboard.SetText(s);
                string msg = s + UIHelper.LocalString("  已复制", "  copied");
                //Bapp.PushCrossBappMessage(new CrossBappMessage() { Content = msg, From = this.Module.Bapp });
                UIMessageBox.Show(msg, "");
            }
            catch (Exception) { }
        }

        private void bt_queryVolume_Click(object sender, EventArgs e)
        {
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            if (miningIndex != default)
            {
                if (UInt256.TryParse(this.tb_assetId.Text, out UInt256 assetID))
                {
                    try
                    {
                        var sh = this.tb_badgeAddress.Text.ToScriptHash();
                        var lw = miningIndex.GetTotalValidLockVolume(assetID, sh);
                        if (lw.IsNotNull())
                        {
                            this.tb_lockVolume.Text = lw.Value.ToString();
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void bt_copyMyWitnessAddress_Click(object sender, EventArgs e)
        {
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            var badgeWitnessAddressSH = SecureHelper.MasterAccount.ScriptHash.GetMutualLockSeed();
            if (miningIndex.MutualLockNodes.TryGetValue(badgeWitnessAddressSH, out var miner))
            {

                var s = badgeWitnessAddressSH.ToAddress();
                try
                {
                    Clipboard.SetText(s);
                    string msg = s + UIHelper.LocalString("  已复制", "  copied");
                    //Bapp.PushCrossBappMessage(new CrossBappMessage() { Content = msg, From = this.Module.Bapp });
                    UIMessageBox.Show(msg, "");
                }
                catch (Exception) { }
            }
        }
    }
}
