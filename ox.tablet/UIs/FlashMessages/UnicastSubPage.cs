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
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OX.Tablet.FlashMessages
{
    public partial class UnicastSubPage : UIPage, IBlockchainHandler
    {
        const string pattern = @"^[a-z0-9_-]+$";
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
        static UnicastSubPage _instance;
        public static UnicastSubPage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UnicastSubPage();
                return _instance;
            }
        }
        UInt256 admintalkLine;
        public UnicastChatbox currentchatbox { get; set; }
        public UIListBox ContactList => this.lb_contact;
        public UIPanel Cast_Panel => this.CastPanel;
        public Dictionary<UInt256, UnicastChatbox> chatboxes = new Dictionary<UInt256, UnicastChatbox>();
        private UnicastSubPage()
        {
            admintalkLine = ECDiffieHellmanHelper.ECDHDeriveKeyHash(SecureHelper.MasterAccount.Key, MarkBetAddressHelper.Instance.MarkAdminPublicKey);
            InitializeComponent();
            this.Text = UIHelper.LocalString("私聊", "Chat");
            this.bt_add_unicast.Text = UIHelper.LocalString("新建私聊", "New Chat");
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

            if (flashMessage.Type == FlashMessageType.FlashUnicast)
            {
                FlashUnicast fu = flashMessage as FlashUnicast;
                if (this.chatboxes.TryGetValue(fu.TalkLine, out var oldbox))
                {
                    oldbox.OnFlashMessage(flashMessage);
                }
                else if (this.currentchatbox.IsNotNull() && fu.TalkLine == this.currentchatbox.chatbox_info.TP.Item1)
                {
                    this.currentchatbox.OnFlashMessage(flashMessage);
                }
                else if (fu.RecipientHash == SecureHelper.MasterAccount.ScriptHash.Hash)
                {
                    if (SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>().UnicastTalkLines.TryGetValue(fu.TalkLine, out var utlv))
                    {
                        UnicastChatbox box = default;
                        foreach (UnicastChatbox item in this.lb_contact.Items)
                        {
                            if (item.chatbox_info.TP.Item1 == fu.TalkLine)
                            {
                                box = item;
                            }
                        }
                        if (box.IsNull())
                        {
                            string label = string.Empty;
                            var sendSh = Contract.CreateSignatureRedeemScript(fu.Sender).ToScriptHash();
                            var dmbs = FlashMessageHelper.GetDomain(sendSh);
                            if (dmbs.IsNotNullAndEmpty())
                            {
                                label = System.Text.Encoding.UTF8.GetString(dmbs);
                            }
                            utlv = new UnicastTalkLineValue { Label = label, Local = SecureHelper.MasterAccount.ScriptHash, Remote = fu.Sender };
                            box = buildBox(fu.TalkLine, utlv);
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

            foreach (var talkline in SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>().UnicastTalkLines.OrderByDescending(m => m.Value.Level))
            {
                var box = buildBox(talkline.Key, talkline.Value);
                this.lb_contact.Items.Add(box);
            }
        }
        public UnicastChatbox buildBox(UInt256 key, UnicastTalkLineValue value)
        {
            var localAccount = SecureHelper.MasterAccount;
            var cbi = new UnicastChatboxInfo();
            cbi.TP = new Tuple<UInt256, UnicastTalkLineValue>(key, value);
            cbi.LocalAccount = localAccount;

            cbi.ChatPlaceholder = UIHelper.LocalString("请输入信息...", "Please enter a message...");
            var chatbox = new UnicastChatbox(cbi);
            chatbox.Name = "chat_box";
            chatbox.Dock = DockStyle.Fill;
            return chatbox;
        }

        private void lb_contact_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnicastChatbox box = this.lb_contact.SelectedItem as UnicastChatbox;
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
            using (var dialog = new NewUnicastLine())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (ECPoint.TryParse(dialog.GetRemotePubkey(), ECCurve.Secp256r1, out var remote))
                    {
                        var subBlockIndex = SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>();
                        var utlvResult = subBlockIndex.SaveUnicastTalkLine(remote, 0);

                        UnicastChatbox box = default;
                        foreach (UnicastChatbox item in this.lb_contact.Items)
                        {
                            if (item.chatbox_info.TP.Item1 == utlvResult.talkLine)
                            {
                                box = item;
                            }
                        }
                        if (box.IsNull())
                        {
                            box = buildBox(utlvResult.talkLine, utlvResult.utlv);
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

        }

        private void lb_contact_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                UIContextMenuStrip menu = new UIContextMenuStrip();
                if (this.lb_contact.SelectedItem is UnicastChatbox box)
                {
                    ToolStripMenuItem sm;
                    sm = new ToolStripMenuItem(UIHelper.LocalString("清空聊天", "Clear Chat"));
                    sm.Click += Sm_Click4;
                    sm.Tag = box;
                    menu.Items.Add(sm);
                    sm = new ToolStripMenuItem(UIHelper.LocalString("星标", "Mark Star"));
                    sm.Click += Sm_Click;
                    sm.Tag = box.chatbox_info;
                    menu.Items.Add(sm);
                    sm = new ToolStripMenuItem(UIHelper.LocalString("复制地址", "Copy Address"));
                    sm.Click += Sm_Click2;
                    sm.Tag = box.chatbox_info;
                    menu.Items.Add(sm);
                    sm = new ToolStripMenuItem(UIHelper.LocalString("复制公钥", "Copy Public Key"));
                    sm.Click += Sm_Click3;
                    sm.Tag = box.chatbox_info;
                    menu.Items.Add(sm);
                    sm = new ToolStripMenuItem(UIHelper.LocalString("删除", "Remove"));
                    sm.Click += Sm_Click1;
                    sm.Tag = box.chatbox_info;
                    menu.Items.Add(sm);
                    if (menu.Items.Count > 0)
                        menu.Show(this.lb_contact, e.Location);
                }

            }
        }

        private void Sm_Click4(object? sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            var box = ToolStripMenuItem.Tag as UnicastChatbox;
            if (box.IsNotNull() && box.chatbox_info.IsNotNull())
            {
                var talkline = box.chatbox_info.TP.Item1;
                //var utlv = box.chatbox_info.TP.Item2;
                var subBlockIndex = SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>();
                subBlockIndex.Clear_FlashUnicast(talkline);
                box.ClearRecords();
                box.ReloadOldRecords();
            }
        }

        private void Sm_Click1(object? sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            UnicastChatboxInfo boxInfo = ToolStripMenuItem.Tag as UnicastChatboxInfo;
            if (boxInfo.IsNotNull())
            {
                var talkline = boxInfo.TP.Item1;
                var utlv = boxInfo.TP.Item2;
                var subBlockIndex = SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>();
                subBlockIndex.DeleteUnicastTalkLine(talkline);
                reloadTalkLines();
            }
        }
        private void Sm_Click2(object? sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            UnicastChatboxInfo boxInfo = ToolStripMenuItem.Tag as UnicastChatboxInfo;
            if (boxInfo.IsNotNull())
            {
                var utlv = boxInfo.TP.Item2;
                var address = Contract.CreateSignatureRedeemScript(utlv.Remote).ToScriptHash().ToAddress();
                Clipboard.SetText(address);
                string msg = address + UIHelper.LocalString("  已复制", "  copied");
                UIMessageBox.Show(msg, "");
            }
        }
        private void Sm_Click3(object? sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            UnicastChatboxInfo boxInfo = ToolStripMenuItem.Tag as UnicastChatboxInfo;
            if (boxInfo.IsNotNull())
            {
                var utlv = boxInfo.TP.Item2;
                var pubkey = utlv.Remote.ToString();
                Clipboard.SetText(pubkey);
                string msg = pubkey + UIHelper.LocalString("  已复制", "  copied");
                UIMessageBox.Show(msg, "");
            }
        }

        private void Sm_Click(object? sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            UnicastChatboxInfo boxInfo = ToolStripMenuItem.Tag as UnicastChatboxInfo;
            if (boxInfo.IsNotNull())
            {
                var talkline = boxInfo.TP.Item1;
                var utlv = boxInfo.TP.Item2;
                var subBlockIndex = SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>();
                subBlockIndex.SaveUnicastTalkLine(utlv.Remote, (uint)(utlv.Level == 0 ? 1 : 0));
                reloadTalkLines();
            }
        }
    }
}
