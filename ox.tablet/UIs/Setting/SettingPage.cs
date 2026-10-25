using OX.Network.P2P.Payloads;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OX.BMS;
using OX.Cryptography.ECC;
using OX.Casino;
using OX.Ledger;
using Sunny.UI;
using OX.Tablet.UIs.MarkSix;
using OX.Tablet.Config;
using Sunny.UI.Win32;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.IO;
using Nethereum.Util;
using OX.Persistence;

namespace OX.Tablet.UIs.Setting
{
    public partial class SettingPage : BaseContentPage
    {

        CommonPage CommonPage = default;
        AccountPage AccountPage = default;
        GlobalAssetsPage GlobalAssetsPage = default;
        AdminPage AdminPage = default;
        PortPage PortPage = default;
        MessagePage MessagePage = default;
        Dictionary<string, ITabletPluginUI> Plugins = new Dictionary<string, ITabletPluginUI>();
        public SettingPage()
        {
            InitializeComponent();
            InitPages();
        }
        public static string _moduleKey => "setting";
        public override string ModuleKey => _moduleKey;


        public override void HeartBeat(HeartBeatContext beatContext)
        {
            if (CommonPage.IsNotNull())
                CommonPage.HeartBeat(beatContext);
            if (AccountPage.IsNotNull())
                AccountPage.HeartBeat(beatContext);
            if (AdminPage.IsNotNull())
                AdminPage.HeartBeat(beatContext);
            if (PortPage.IsNotNull())
                PortPage.HeartBeat(beatContext);
            if (MessagePage.IsNotNull())
                MessagePage.HeartBeat(beatContext);
            if (GlobalAssetsPage.IsNotNull())
                GlobalAssetsPage.HeartBeat(beatContext);
            foreach (var plugin in Plugins.Values)
            {
                plugin.HeartBeat(beatContext);
            }
        }
        public override void BeforeBlock(Block block)
        {
            if (CommonPage.IsNotNull())
                CommonPage.BeforeBlock(block);
            if (AccountPage.IsNotNull())
                AccountPage.BeforeBlock(block);
            if (AdminPage.IsNotNull())
                AdminPage.BeforeBlock(block);
            if (PortPage.IsNotNull())
                PortPage.BeforeBlock(block);
            if (MessagePage.IsNotNull())
                MessagePage.BeforeBlock(block);
            if (GlobalAssetsPage.IsNotNull())
                GlobalAssetsPage.BeforeBlock(block);
            foreach (var plugin in Plugins.Values)
            {
                plugin.BeforeBlock(block);
            }
        }
        public override void OnBlock(Block block)
        {
            if (CommonPage.IsNotNull())
                CommonPage.OnBlock(block);
            if (AccountPage.IsNotNull())
                AccountPage.OnBlock(block);
            if (AdminPage.IsNotNull())
                AdminPage.OnBlock(block);
            if (PortPage.IsNotNull())
                PortPage.OnBlock(block);
            if (MessagePage.IsNotNull())
                MessagePage.OnBlock(block);
            if (GlobalAssetsPage.IsNotNull())
                GlobalAssetsPage.OnBlock(block);
            foreach (var plugin in Plugins.Values)
            {
                plugin.OnBlock(block);
            }
        }
        public override void AfterBlock(Block block)
        {
            if (CommonPage.IsNotNull())
                CommonPage.AfterBlock(block);
            if (AccountPage.IsNotNull())
                AccountPage.AfterBlock(block);
            if (AdminPage.IsNotNull())
                AdminPage.AfterBlock(block);
            if (PortPage.IsNotNull())
                PortPage.AfterBlock(block);
            if (MessagePage.IsNotNull())
                MessagePage.AfterBlock(block);
            if (GlobalAssetsPage.IsNotNull())
                GlobalAssetsPage.AfterBlock(block);
            foreach (var plugin in Plugins.Values)
            {
                plugin.AfterBlock(block);
            }
        }
        public override void OnClipboardString(ClipboardMessageType messageType, string msg)
        {
            if (CommonPage.IsNotNull())
                CommonPage.OnClipboardString(messageType, msg);
            if (AccountPage.IsNotNull())
                AccountPage.OnClipboardString(messageType, msg);
            if (AdminPage.IsNotNull())
                AdminPage.OnClipboardString(messageType, msg);
            if (PortPage.IsNotNull())
                PortPage.OnClipboardString(messageType, msg);
            if (MessagePage.IsNotNull())
                MessagePage.OnClipboardString(messageType, msg);
            if (GlobalAssetsPage.IsNotNull())
                GlobalAssetsPage.OnClipboardString(messageType, msg);
            foreach (var plugin in Plugins.Values)
            {
                plugin.OnClipboardString(messageType, msg);
            }
        }
        public override void MenuPageSelected()
        {
            if (CommonPage.IsNotNull())
                CommonPage.MenuPageSelected();
            if (AccountPage.IsNotNull())
                AccountPage.MenuPageSelected();
            if (AdminPage.IsNotNull())
                AdminPage.MenuPageSelected();
            if (PortPage.IsNotNull())
                PortPage.MenuPageSelected();
            if (MessagePage.IsNotNull())
                MessagePage.MenuPageSelected();
            if (GlobalAssetsPage.IsNotNull())
                GlobalAssetsPage.MenuPageSelected();
            foreach (var plugin in Plugins.Values)
            {
                plugin.MenuPageSelected();
            }
        }
        void InitPages()
        {
            CommonPage = new CommonPage() { Text = UIHelper.LocalString("通用", "General") };
            this.tbc_sections.AddPage(CommonPage);
            AccountPage = new AccountPage() { Text = UIHelper.LocalString("账户", "Account") };
            this.tbc_sections.AddPage(AccountPage);
            GlobalAssetsPage = new GlobalAssetsPage() { Text = UIHelper.LocalString("全局资产", "Global Assets") };
            this.tbc_sections.AddPage(GlobalAssetsPage);    
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            var validScope = miningIndex.GetValidScope();
            if (validScope.IsNotNullAndEmpty() && validScope != "0")
            {
                MessagePage = new MessagePage() { Text = UIHelper.LocalString("公告", "Messages") };
                this.tbc_sections.AddPage(MessagePage);
            }
            if (SecureHelper.IsCasinoSlot())
            {
                AdminPage = new AdminPage() { Text = UIHelper.LocalString("管理", "Admin") };
                this.tbc_sections.AddPage(AdminPage);
            }
            //if (SecureHelper.IsBanker())
            //{
            //    PortPage = new PortPage() { Text = UIHelper.LocalString("庄家", "Banker") };
            //    this.tbc_sections.AddPage(PortPage);
            //}
            if (SecureHelper.IsMarkAdmin())
            {
                if (TabletPlugin.Plugins.Any())
                {
                    foreach (var plugin in TabletPlugin.Plugins.Values)
                    {
                        var pluginUI = plugin.Build();
                        if (pluginUI.IsNotNull() && pluginUI is UIPage up)
                        {
                            pluginUI.SetConfigHandler(SendFlashState,
                                (string key) =>
                                {
                                    return NodeConfig.Instance.MarkPredicts.FirstOrDefault(m => m.PredictId == key)?.LatestDate;
                                },
                                (string key, string date) =>
                                {
                                    var Node = NodeConfig.Instance.MarkPredicts.FirstOrDefault(m => m.PredictId == key);
                                    if (Node.IsNull())
                                    {
                                        Node = new MarkPredictNode(key, date);
                                        NodeConfig.Instance.MarkPredicts.Add(Node);
                                        NodeConfig.Instance.Save();
                                    }
                                    else
                                    {
                                        Node.LatestDate = date;
                                        NodeConfig.Instance.Save();
                                    }
                                }
                                );
                            this.Plugins[pluginUI.PluginName] = pluginUI;
                            this.tbc_sections.AddPage(up);
                        }
                    }
                }
            }

        }
        bool SendFlashState(string key, Image image)
        {
            var accountState = Blockchain.Singleton.CurrentSnapshot.Accounts.TryGet(SecureHelper.MasterAccount.ScriptHash);
            if (accountState.IsNotNull() && Blockchain.Singleton.AllowFlashMessage(accountState, out uint _))
            {
                if (ImageCompressHelper.CompressImage(image, FlashState.MaxImageDataSize, out byte[] bs))
                {
                    try
                    {
                        if (SecureHelper.IsBanker() && SecureHelper.MasterAccount.ScriptHash == MarkBetAddressHelper.Instance.MarkAdmin)
                        {

                            byte[] textData = new byte[0];
                            var text = string.Empty;
                            if (text.IsNotAnEmptyAddress())
                                textData = System.Text.Encoding.UTF8.GetBytes(text);
                            var fs = new FlashState(SecureHelper.MasterAccount.ScriptHash, Blockchain.Singleton.HeaderHeight, textData, bs, new FlashStateTag[] { new FlashStateTag(key) });
                            LockAssetHelper.BuildAndSendFlashMessage(fs);
                            return true;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            return false;
        }
    }
}
