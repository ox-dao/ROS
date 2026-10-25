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
using OX.Tablet.UIs.Rothschild;
using OX.Mining;

namespace OX.Tablet.UIs.Rothschild
{
    public partial class RothschildPage : BaseContentPage
    {

        RegBadgePage RegBadgePage = default;
        BadgePage BadgePage = default;
        WitnessPage WitnessPage = default;
        GreenlandPage GreenlandPage = default;
        GovernancePage GovernancePage = default;
        DonationTrustPool DonationTrustPool = default;
        public RothschildPage()
        {
            InitializeComponent();
            InitPages();
        }
        public static string _moduleKey => "rothschild";
        public override string ModuleKey => _moduleKey;


        public override void HeartBeat(HeartBeatContext beatContext)
        {
            if (RegBadgePage.IsNotNull())
                RegBadgePage.HeartBeat(beatContext);
            if (BadgePage.IsNotNull())
                BadgePage.HeartBeat(beatContext);
            if (WitnessPage.IsNotNull())
                WitnessPage.HeartBeat(beatContext);
            if (GreenlandPage.IsNotNull())
                GreenlandPage.HeartBeat(beatContext);
            if (GovernancePage.IsNotNull())
                GovernancePage.HeartBeat(beatContext);
            if (DonationTrustPool.IsNotNull())
                DonationTrustPool.HeartBeat(beatContext);
        }
        public override void BeforeBlock(Block block)
        {
            if (RegBadgePage.IsNotNull())
                RegBadgePage.BeforeBlock(block);
            if (BadgePage.IsNotNull())
                BadgePage.BeforeBlock(block);
            if (WitnessPage.IsNotNull())
                WitnessPage.BeforeBlock(block);
            if (GreenlandPage.IsNotNull())
                GreenlandPage.BeforeBlock(block);
            if (GovernancePage.IsNotNull())
                GovernancePage.BeforeBlock(block);
            if (DonationTrustPool.IsNotNull())
                DonationTrustPool.BeforeBlock(block);
        }
        public override void OnBlock(Block block)
        {
            if (RegBadgePage.IsNotNull())
                RegBadgePage.OnBlock(block);
            if (BadgePage.IsNotNull())
                BadgePage.OnBlock(block);
            if (WitnessPage.IsNotNull())
                WitnessPage.OnBlock(block);
            if (GreenlandPage.IsNotNull())
                GreenlandPage.OnBlock(block);
            if (GovernancePage.IsNotNull())
                GovernancePage.OnBlock(block);
            if (DonationTrustPool.IsNotNull())
                DonationTrustPool.OnBlock(block);
        }
        public override void AfterBlock(Block block)
        {
            if (RegBadgePage.IsNotNull())
                RegBadgePage.AfterBlock(block);
            if (BadgePage.IsNotNull())
                BadgePage.AfterBlock(block);
            if (WitnessPage.IsNotNull())
                WitnessPage.AfterBlock(block);
            if (GreenlandPage.IsNotNull())
                GreenlandPage.AfterBlock(block);
            if (GovernancePage.IsNotNull())
                GovernancePage.AfterBlock(block);
            if (DonationTrustPool.IsNotNull())
                DonationTrustPool.AfterBlock(block);
        }
        public override void OnClipboardString(ClipboardMessageType messageType, string msg)
        {
            if (RegBadgePage.IsNotNull())
                RegBadgePage.OnClipboardString(messageType, msg);
            if (BadgePage.IsNotNull())
                BadgePage.OnClipboardString(messageType, msg);
            if (WitnessPage.IsNotNull())
                WitnessPage.OnClipboardString(messageType, msg);
            if (GreenlandPage.IsNotNull())
                GreenlandPage.OnClipboardString(messageType, msg);
            if (GovernancePage.IsNotNull())
                GovernancePage.OnClipboardString(messageType, msg);
            if (DonationTrustPool.IsNotNull())
                DonationTrustPool.OnClipboardString(messageType, msg);
        }
        public override void MenuPageSelected()
        {
            if (RegBadgePage.IsNotNull())
                RegBadgePage.MenuPageSelected();
            if (BadgePage.IsNotNull())
                BadgePage.MenuPageSelected();
            if (WitnessPage.IsNotNull())
                WitnessPage.MenuPageSelected();
            if (GreenlandPage.IsNotNull())
                GreenlandPage.MenuPageSelected();
            if (GovernancePage.IsNotNull())
                GovernancePage.MenuPageSelected();
            if (DonationTrustPool.IsNotNull())
                DonationTrustPool.MenuPageSelected();
        }
        void InitPages()
        {
            if (SecureHelper.IsAuthenticated)
            {
                if (SecureHelper.BlockIndex.IsNotNull())
                {
                    var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
                    if (miningIndex.MutualLockNodes.TryGetValue(SecureHelper.MasterAccount.ScriptHash.GetMutualLockSeed(), out var miner))
                    {
                        var rm = miner.RegIndex % 100000;
                        var rem = rm;
                        var rem2 = Blockchain.Singleton.Height % 100000;
                        if (rem2 > rem) rem += 100000;
                        var sub = rem - rem2;
                        var s = invest.MasterAccountAddress.Equals(miner.ParentHolder) ? UIHelper.LocalString("骑士", "Knight ") : string.Empty;
                      
                        BadgePage = new BadgePage() { Text =s+ UIHelper.LocalString("徽章", "Badge") };
                        this.tbc_sections.AddPage(BadgePage);
                        WitnessPage = new WitnessPage() { Text = UIHelper.LocalString("时空见证", "Space-time Witness") };
                        this.tbc_sections.AddPage(WitnessPage);
                        DonationTrustPool = new DonationTrustPool() { Text = UIHelper.LocalString("捐赠信托池", "Donation Trust Pool") };
                        this.tbc_sections.AddPage(DonationTrustPool);
                        //GovernancePage = new GovernancePage() { Text = UIHelper.LocalString("社区共治", "Community co governance") };
                        //this.tbc_sections.AddPage(GovernancePage);

                        //GreenlandPage = new GreenlandPage() { Text = UIHelper.LocalString("格陵兰国", "Greenland State") };
                        //this.tbc_sections.AddPage(GreenlandPage);
                    }
                    else
                    {
                        //RegBadgePage = new RegBadgePage() { Text = UIHelper.LocalString("注册徽章", "Register Badge") };
                        //this.tbc_sections.AddPage(RegBadgePage);
                    }
                }
            }
        }
    }
}
