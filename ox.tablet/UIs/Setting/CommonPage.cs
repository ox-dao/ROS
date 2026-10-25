using Akka.Actor;
using Akka.IO;
using Org.BouncyCastle.Bcpg;
using OX.BMS;
using OX.DirectSales;
using OX.Ledger;
using OX.Network.P2P.Payloads;
using OX.Persistence;
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

namespace OX.Tablet.UIs.Setting
{
    public partial class CommonPage : UIPage, IBlockchainHandler
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));


        public CommonPage()
        {
            InitializeComponent();
            this.bt_lock.Text = UIHelper.LocalString("锁定账户", "Lock Account");
            this.bt_exit.Text = UIHelper.LocalString("退出", "Exit");
            this.bt_rebuild.Text = UIHelper.LocalString("重建索引", "Rebuild Index");
            this.bt_collapse.Text = UIHelper.LocalString("缩略到通知", "Collapse");
            this.L1.Text = UIHelper.LocalString("查询账户名", "Query Account Name");
            this.bt_queryName.Text = UIHelper.LocalString("查询", "Qeury");
            this.bt_copy_dms.Text = UIHelper.LocalString("复制", "Copy");
            this.setColor(bt_collapse, FocusColor);
            this.bt_collapse.Enabled = SecureHelper.IsPlayer();
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

        public virtual void MenuPageSelected() { ShowSwitchText(); }
        void ShowSwitchText()
        {
            string switchText = string.Empty;
            if (SecureHelper.IsSeniorRunMode)
            {
                switchText = UIHelper.LocalString("切换简易版", "Switch Simple");
            }
            else
            {
                switchText = UIHelper.LocalString("切换高级版", "Switch Senior");
            }
            this.bt_switch.Text = switchText;
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

        private void bt_lock_Click(object sender, EventArgs e)
        {
            new UnlockAppForm().ShowDialog();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_switch_Click(object sender, EventArgs e)
        {
            SecureHelper.SwitchRunMode();
            ShowSwitchText();
        }

        private void bt_rebuild_Click(object sender, EventArgs e)
        {
            if (SecureHelper.BlockIndex.IsNotNull())
            {
                SecureHelper.NeedExit = true;
                SecureHelper.BlockIndex.Rebuild();
            }
        }

        private void bt_collapse_Click(object sender, EventArgs e)
        {
            MainForm.Instance.Hide();
            NoticeForm.Instance.Show();
        }

        private void bt_queryName_Click(object sender, EventArgs e)
        {
            var s = this.uiTextBox1.Text;
            bool ok = false;
            try
            {
                var sh = s.ToScriptHash();
                var dmbs = FlashMessageHelper.GetDomain(sh);
                if (dmbs.IsNotNullAndEmpty())
                {
                    this.uiTextBox2.Text = System.Text.Encoding.UTF8.GetString(dmbs);
                }
                ok = true;
            }
            catch
            {
                ok = false;
            }
            if (!ok)
            {
                var sh = FlashMessageHelper.GetAddressByDomain(s);
                if (sh.IsNotNull()&& sh != UInt160.Zero)
                {
                    this.uiTextBox2.Text =sh.ToAddress();
                }
            }
        }

        private void bt_copy_dms_Click(object sender, EventArgs e)
        {
            var s = this.uiTextBox2.Text;
            if (s.IsNotNullAndEmpty())
            {
                Clipboard.SetText(s);
                var msg = UIHelper.LocalString($"{s} 已复制", $"{s} copied");
                this.ShowSuccessTip(msg);
            }
        }
    }
}
