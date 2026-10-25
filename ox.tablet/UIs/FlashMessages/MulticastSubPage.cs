using Nethereum.ABI.EIP712;
using OX.BMS;
using OX.Casino;
using OX.Cryptography;
using OX.Cryptography.ECC;
using OX.Network.P2P.Payloads;
using OX.Persistence;
using OX.SmartContract;
using OX.Tablet.Config;
using OX.Tablet.Flash;
using OX.Wallets;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OX.Tablet.FlashMessages
{
    public partial class MulticastSubPage : UIPage, IBlockchainHandler
    {
        const string pattern = @"^[a-z0-9_-]+$";
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
        static MulticastSubPage _instance;
        public static MulticastSubPage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MulticastSubPage();
                return _instance;
            }
        }
        MulticastChatbox currentchatbox;
        Dictionary<UInt256, MulticastChatbox> chatboxes = new Dictionary<UInt256, MulticastChatbox>();
        MulticastSubPage()
        {
            InitializeComponent();
            this.Text = UIHelper.LocalString("群聊", "Group Chat");
            this.bt_add_unicast.Text = UIHelper.LocalString("新建群聊", "New Group");
        }
        public void HeartBeat(HeartBeatContext beatContext)
        {
            if (currentchatbox.IsNotNull())
                currentchatbox.HeartBeat(beatContext);
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
        public void OnClipboardString(ClipboardMessageType messageType, string msg)
        {

        }
        public void OnFlashMessage(FlashMessage flashMessage)
        {
            if (flashMessage.Type == FlashMessageType.FlashMulticast)
            {
                FlashMulticast fu = flashMessage as FlashMulticast;
                if (this.chatboxes.TryGetValue(fu.TalkLine, out var oldbox))
                {
                    oldbox.OnFlashMessage(flashMessage);
                }
                else if (fu.TalkLine == this.currentchatbox?.chatbox_info.TP.Item1)
                {
                    this.currentchatbox.OnFlashMessage(flashMessage);
                }
                else
                {
                    if (SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>().MulticastTalkLines.TryGetValue(fu.TalkLine, out var utlv))
                    {
                        MulticastChatbox box = default;
                        foreach (MulticastChatbox item in this.lb_contact.Items)
                        {
                            if (item.chatbox_info.TP.Item1 == fu.TalkLine)
                            {
                                box = item;
                            }
                        }
                        if (box.IsNull())
                        {
                            box = buildBox(fu.TalkLine, this.currentchatbox?.chatbox_info.TP.Item2);
                            this.lb_contact.Items.Insert(0, box);
                        }
                    }
                }
            }
        }
        public virtual void MenuPageSelected()
        {
            reloadTalkLines();
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
        void reloadTalkLines()
        {
            this.lb_contact.Items.Clear();

            foreach (var talkline in SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>().MulticastTalkLines.OrderByDescending(m => m.Value.Level))
            {

                var box = buildBox(talkline.Key, talkline.Value);
                this.lb_contact.Items.Add(box);
            }
        }
        MulticastChatbox buildBox(UInt256 key, MulticastTalkLineValue value)
        {
            var localAccount = SecureHelper.MasterAccount;
            var cbi = new MulticastChatboxInfo();
            cbi.TP = new Tuple<UInt256, MulticastTalkLineValue>(key, value);
            cbi.LocalAccount = localAccount;
            cbi.Keys = value.Key;
            cbi.TalkLabel = value.Label;
            cbi.LocalAddress = localAccount?.Address;
            cbi.ChatPlaceholder = UIHelper.LocalString("请输入信息...", "Please enter a message...");
            var chatbox = new MulticastChatbox(cbi);
            chatbox.Name = "chat_box";
            chatbox.Dock = DockStyle.Fill;
            return chatbox;
        }

        private void lb_contact_SelectedIndexChanged(object sender, EventArgs e)
        {
            MulticastChatbox box = this.lb_contact.SelectedItem as MulticastChatbox;
            if (box.IsNotNull())
            {
                if (this.currentchatbox.IsNotNull())
                    this.chatboxes[this.currentchatbox.chatbox_info.TP.Item1] = this.currentchatbox;
                this.currentchatbox = box;
                this.CastPanel.Controls.Clear();
                this.CastPanel.Controls.Add(box);
                box.ReloadOldRecords();
            }
        }

        bool Match(string s)
        {
            return Regex.IsMatch(s, pattern);
        }


        private void bt_add_unicast_Click(object sender, EventArgs e)
        {
            using (var dialog = new NewMulticastLine())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var infoResult = dialog.GetLineInfo();
                    var subBlockIndex = SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>();
                    var keys = infoResult.sharekey.HexToBytes();
                    var utlvResult = subBlockIndex.SaveMulticastTalkLine(SecureHelper.MasterAccount.ScriptHash, keys!, infoResult.lineName, 0);

                    MulticastChatbox box = default;
                    foreach (MulticastChatbox item in this.lb_contact.Items)
                    {
                        if (item.chatbox_info.TP.Item1 == utlvResult.talkline)
                        {
                            box = item;
                        }
                    }
                    if (box.IsNull())
                    {
                        box = buildBox(utlvResult.talkline, utlvResult.utlv);
                        this.lb_contact.Items.Add(box);
                    }
                    if (this.currentchatbox.IsNotNull())
                        this.chatboxes[this.currentchatbox.chatbox_info.TP.Item1] = this.currentchatbox;
                    this.currentchatbox = box;
                    this.CastPanel.Controls.Clear();
                    this.CastPanel.Controls.Add(currentchatbox);
                    currentchatbox.ReloadOldRecords();

                }
            }

        }

        private void lb_contact_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                UIContextMenuStrip menu = new UIContextMenuStrip();
                if (this.lb_contact.SelectedItem is MulticastChatbox box)
                {
                    ToolStripMenuItem sm;
                    sm = new ToolStripMenuItem(UIHelper.LocalString("清空聊天", "Clear Chat"));
                    sm.Click += Sm_Click2;
                    sm.Tag = box;
                    menu.Items.Add(sm);
                    sm = new ToolStripMenuItem(UIHelper.LocalString("星标", "Mark Star"));
                    sm.Click += Sm_Click;
                    sm.Tag = box;
                    menu.Items.Add(sm);
                    sm = new ToolStripMenuItem(UIHelper.LocalString("删除", "Remove"));
                    sm.Click += Sm_Click1;
                    sm.Tag = box;
                    menu.Items.Add(sm);
                    if (menu.Items.Count > 0)
                        menu.Show(this.lb_contact, e.Location);
                }

            }
        }

        private void Sm_Click2(object? sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            var box = ToolStripMenuItem.Tag as MulticastChatbox;
            if (box.IsNotNull()&&box.chatbox_info.IsNotNull())
            {
                var talkline = box.chatbox_info.TP.Item1;
                //var utlv = box.chatbox_info.TP.Item2;
                var subBlockIndex = SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>();
                subBlockIndex.Clear_FlashMulticast(talkline);
                box.ClearRecords();
                box.ReloadOldRecords();
            }
        }

        private void Sm_Click1(object? sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            var box = ToolStripMenuItem.Tag as MulticastChatbox;
            if (box.IsNotNull() && box.chatbox_info.IsNotNull())
            {
                var talkline = box.chatbox_info.TP.Item1;
                var utlv = box.chatbox_info.TP.Item2;
                var subBlockIndex = SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>();
                subBlockIndex.DeleteMulticastTalkLine(talkline);
                reloadTalkLines();
            }
        }

        private void Sm_Click(object? sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            var box = ToolStripMenuItem.Tag as MulticastChatbox;
            if (box.IsNotNull() && box.chatbox_info.IsNotNull())
            {
                var talkline = box.chatbox_info.TP.Item1;
                var utlv = box.chatbox_info.TP.Item2;
                var subBlockIndex = SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>();
                subBlockIndex.SaveMulticastTalkLine(SecureHelper.MasterAccount.ScriptHash, utlv.Key, utlv.Label, (uint)(utlv.Level == 0 ? 1 : 0));
                reloadTalkLines();
            }
        }
    }
}
