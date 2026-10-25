using OX.Casino;
using OX.Cryptography;
using OX.Network.P2P.Payloads;
using OX.Persistence;
using OX.Tablet.Config;
using Sunny.UI;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OX.SmartContract;
using OX.BMS;
using OX.Wallets;
using OX.Tablet.Flash;

namespace OX.Tablet.FlashSupports
{
    public partial class SupportUnicastSubPage : UIPage, IBlockchainHandler
    {
        const string pattern = @"^[a-z0-9_-]+$";
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));

        UnicastChatbox currentchatbox;
        public SupportUnicastSubPage()
        {
            InitializeComponent();
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
        public void OnClipboardString(ClipboardMessageType messageType, string msg)
        {

        }
        public void OnFlashMessage(FlashMessage flashMessage)
        {
            if (currentchatbox.IsNotNull())
            {
                currentchatbox.OnFlashMessage(flashMessage);
            }
            else
            {
                if (flashMessage.Type == FlashMessageType.FlashUnicast)
                {
                    FlashUnicast fu = flashMessage as FlashUnicast;
                    if (fu.RecipientHash == SecureHelper.MasterAccount.ScriptHash.Hash)
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
            var bmsIndex = SecureHelper.BlockIndex.GetSubBlockIndex<BMSBlockIndex>();
            var msr = bmsIndex.Get<MarkSupportReply>(CasinoBizPersistencePrefixes.BMS_Support_Service, new byte[] { 0 });
            if (msr.IsNotNull() && msr.SupportHolders.IsNotNullAndEmpty())
            {
                foreach (var m in msr.SupportHolders)
                {
                    var talkLine = ECDiffieHellmanHelper.ECDHDeriveKeyHash(SecureHelper.MasterAccount.Key, m);
                    var sh = Contract.CreateSignatureRedeemScript(m).ToScriptHash();
                    var label = sh.ToAddress();
                    var dmbs = FlashMessageHelper.GetDomain(sh);
                    if (dmbs.IsNotNullAndEmpty())
                    {
                        label = System.Text.Encoding.UTF8.GetString(dmbs);
                    }
                    var utlv = new UnicastTalkLineValue { Label = label, Local = SecureHelper.MasterAccount.ScriptHash, Remote =m};
                    var box = buildBox(talkLine, utlv);
                    this.lb_contact.Items.Add(box);
                }                
            }
        }
        UnicastChatbox buildBox(UInt256 key, UnicastTalkLineValue value)
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


    }
}
