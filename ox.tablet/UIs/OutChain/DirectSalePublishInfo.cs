using Akka.Actor;
using OX.DirectSales;
using OX.IO;
using OX.Ledger;
using OX.Network.P2P;
using OX.Network.P2P.Payloads;
using OX.Persistence;
using OX.SmartContract;
using OX.Tablet.Config;
using OX.Tablet.FlashMessages;
using OX.Tablet.UIs.MarkSix;
using OX.Wallets;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OX.Tablet.UIs.OutChain
{

    public partial class DirectSalePublishInfo : UserControl
    {
        MarketPlacePage ParentPage;
        DirectSalePublishMerge DirectSalePublishMerge;
        string AssetName;

        public DirectSalePublishInfo(MarketPlacePage parentPage, DirectSalePublishMerge dspMerger, string assetName)
        {
            this.ParentPage = parentPage;
            this.DirectSalePublishMerge = dspMerger;
            this.AssetName = assetName;
            InitializeComponent();
            this.uiGroupBox1.Text = $"{assetName}  /   {DirectSalePublishMerge.Publish.Amount}"; ;
            var fromSH = Contract.CreateSignatureRedeemScript(dspMerger.Tx.From).ToScriptHash();
            var from = fromSH.ToAddress();
            var dmbs = FlashMessageHelper.GetDomain(fromSH);
            if (dmbs.IsNotNullAndEmpty())
            {
                from = $"{from}  ({System.Text.Encoding.UTF8.GetString(dmbs)})";
            }
            this.lb_seller.Text = UIHelper.LocalString($"卖家:{from}", $"Seller:{from}");
            this.lb_timestamp.Text = dspMerger.TimeStamp.ToDateTime().ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            this.lb_contact.Text = dspMerger.Publish.Contact;
            this.lb_remarks.Text = dspMerger.Publish.Remarks;
            this.bt_show_balance.Text = UIHelper.LocalString("查看余额", "Balance");
            this.bt_copy_contact.Text = UIHelper.LocalString("复制联系方式", "Copy Contact");
            this.bt_make_order_copy.Text = UIHelper.LocalString("买家制单并复制", "Create Order & Copy");
            this.bt_make_order_send.Enabled = FlashMessageHelper.GetDomain(SecureHelper.MasterAccount.ScriptHash).IsNotNullAndEmpty();
            this.bt_make_order_send.Text = UIHelper.LocalString("买家制单并发送", "Create Order & Send");
        }

        private void bt_make_order_copy_Click(object sender, EventArgs e)
        {
            var request = new DirectSaleRequest(DirectSalePublishMerge.Publish.AssetId, DirectSalePublishMerge.Tx.From, SecureHelper.MasterAccount.Key, DirectSalePublishMerge.Publish.Amount);
            var hex = "??" + request.ToArray().ToHexString();
            Clipboard.SetText(hex);
            var msg = UIHelper.LocalString("买单已生成并复制，请粘贴并发送给卖家", "Order generated and copied. Please paste and send it to the seller");
            this.ParentPage.ShowSuccessTip(msg);
        }





        private void lb_master_balance_Click(object sender, EventArgs e)
        {

        }


        private void bt_reg_miner_Click(object sender, EventArgs e)
        {
            Fixed8 balance = Fixed8.Zero;
            var sh = Contract.CreateSignatureRedeemScript(DirectSalePublishMerge.Tx.From).ToScriptHash();
            var act = Blockchain.Singleton.CurrentSnapshot.Accounts.TryGet(sh);
            if (act.IsNotNull())
            {
                balance = act.GetBalance(DirectSalePublishMerge.Publish.AssetId);
            }
            var msg = $"{AssetName} : {balance}";
            this.ParentPage.ShowSuccessTip(msg);
        }

        private void bt_self_lock_Click(object sender, EventArgs e)
        {
            if (DirectSalePublishMerge.Publish.IsNotNull() && DirectSalePublishMerge.Publish.Contact.IsNotNullAndEmpty())
            {
                Clipboard.SetText(DirectSalePublishMerge.Publish.Contact);
                var msg = UIHelper.LocalString("卖家联系方式已复制", "Seller contact copied");
                this.ParentPage.ShowSuccessTip(msg);
            }
        }

        private void bt_make_order_send_Click(object sender, EventArgs e)
        {
            var request = new DirectSaleRequest(DirectSalePublishMerge.Publish.AssetId, DirectSalePublishMerge.Tx.From, SecureHelper.MasterAccount.Key, DirectSalePublishMerge.Publish.Amount);
            var hex = "??" + request.ToArray().ToHexString();

            var subBlockIndex = SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>();
            var utlvResult = subBlockIndex.SaveUnicastTalkLine(DirectSalePublishMerge.Tx.From, 0);
            var usp = UnicastSubPage.Instance;
            UnicastChatbox box = default;
            foreach (UnicastChatbox item in usp.ContactList.Items)
            {
                if (item.chatbox_info.TP.Item1 == utlvResult.talkLine)
                {
                    box = item;
                }
            }
            if (box.IsNull())
            {
                box = usp.buildBox(utlvResult.talkLine, utlvResult.utlv);
                usp.ContactList.Items.Add(box);
            }
            if (usp.currentchatbox.IsNotNull())
                usp.chatboxes[usp.currentchatbox.chatbox_info.TP.Item1] = usp.currentchatbox;
            usp.currentchatbox = box;
            usp.Cast_Panel.Controls.Clear();
            usp.Cast_Panel.Controls.Add(usp.currentchatbox);
            usp.currentchatbox.ReloadOldRecords();

            var accountState = Blockchain.Singleton.CurrentSnapshot.Accounts.TryGet(SecureHelper.MasterAccount.ScriptHash);
            if (accountState.IsNotNull() && Blockchain.Singleton.AllowFlashMessage(accountState, out uint _))
            {
                var bs = System.Text.Encoding.UTF8.GetBytes(hex);
                var fu = new FlashUnicast(SecureHelper.MasterAccount.Key, DirectSalePublishMerge.Tx.From, Blockchain.Singleton.HeaderHeight, bs);
                fu.ContentType = FlashMessageContentType.Text;
                LockAssetHelper.BuildAndSendFlashMessage(fu);
                var msg = UIHelper.LocalString("买单已生成并发送给卖家", "Order generated and sent to the seller");
                this.ParentPage.ShowSuccessTip(msg);
            }
        }
    }
}
