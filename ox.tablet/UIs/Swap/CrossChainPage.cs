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

namespace OX.Tablet
{
    public partial class CrossChainPage : BaseContentPage
    {

        InGoldPage InGoldPage = default;
        OutGoldPage OutGoldPage = default;
        InGoldRecordPage InGoldRecordPage = default;
        OutGoldRecordPage OutGoldRecordPage = default;
        USDTCastPage USDTCastPage = default;
        public CrossChainPage()
        {
            InitializeComponent();
            InitPages();
        }
        public static string _moduleKey => "CrossChainPage";
        public override string ModuleKey => _moduleKey;


        public override void HeartBeat(HeartBeatContext beatContext)
        {
            if (InGoldPage.IsNotNull())
                InGoldPage.HeartBeat(beatContext);
            if (OutGoldPage.IsNotNull())
                OutGoldPage.HeartBeat(beatContext);
            if (InGoldRecordPage.IsNotNull())
                InGoldRecordPage.HeartBeat(beatContext);
            if (OutGoldRecordPage.IsNotNull())
                OutGoldRecordPage.HeartBeat(beatContext);
            if (USDTCastPage.IsNotNull())
                USDTCastPage.HeartBeat(beatContext);
        }
        public override void BeforeBlock(Block block)
        {
            if (InGoldPage.IsNotNull())
                InGoldPage.BeforeBlock(block);
            if (OutGoldPage.IsNotNull())
                OutGoldPage.BeforeBlock(block);
            if (InGoldRecordPage.IsNotNull())
                InGoldRecordPage.BeforeBlock(block);
            if (OutGoldRecordPage.IsNotNull())
                OutGoldRecordPage.BeforeBlock(block);
            if (USDTCastPage.IsNotNull())
                USDTCastPage.BeforeBlock(block);
        }
        public override void OnBlock(Block block)
        {
            if (InGoldPage.IsNotNull())
                InGoldPage.OnBlock(block);
            if (OutGoldPage.IsNotNull())
                OutGoldPage.OnBlock(block);
            if (InGoldRecordPage.IsNotNull())
                InGoldRecordPage.OnBlock(block);
            if (OutGoldRecordPage.IsNotNull())
                OutGoldRecordPage.OnBlock(block);
            if (USDTCastPage.IsNotNull())
                USDTCastPage.OnBlock(block);
        }
        public override void AfterBlock(Block block)
        {
            if (InGoldPage.IsNotNull())
                InGoldPage.AfterBlock(block);
            if (OutGoldPage.IsNotNull())
                OutGoldPage.AfterBlock(block);
            if (InGoldRecordPage.IsNotNull())
                InGoldRecordPage.AfterBlock(block);
            if (OutGoldRecordPage.IsNotNull())
                OutGoldRecordPage.AfterBlock(block);
            if (USDTCastPage.IsNotNull())
                USDTCastPage.AfterBlock(block);
        }
        public override void OnClipboardString(ClipboardMessageType messageType, string msg)
        {

        }
        public override void MenuPageSelected()
        {
            if (InGoldPage.IsNotNull())
                InGoldPage.MenuPageSelected();
            if (OutGoldPage.IsNotNull())
                OutGoldPage.MenuPageSelected();
            if (InGoldRecordPage.IsNotNull())
                InGoldRecordPage.MenuPageSelected();
            if(OutGoldRecordPage.IsNotNull())
                OutGoldRecordPage.MenuPageSelected();
            if (USDTCastPage.IsNotNull())
                USDTCastPage.MenuPageSelected();
        }
        void InitPages()
        {
            InGoldPage = new InGoldPage() { Text = UIHelper.LocalString("跨链入金", "OTC Deposit") };
            this.tbc_sections.AddPage(InGoldPage);
            OutGoldPage = new OutGoldPage() { Text = UIHelper.LocalString("跨链出金", "OTC Withdrawal") };
            this.tbc_sections.AddPage(OutGoldPage);
            InGoldRecordPage = new InGoldRecordPage() { Text = UIHelper.LocalString("入金记录", "Deposit Record") };
            this.tbc_sections.AddPage(InGoldRecordPage);
            OutGoldRecordPage = new OutGoldRecordPage() { Text = UIHelper.LocalString("出金记录", "Withdrawal Record") };
            this.tbc_sections.AddPage(OutGoldRecordPage);

            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            var validScope = miningIndex.GetValidScope();
            if (validScope.IsNotNullAndEmpty() && validScope != "0")
            {
                USDTCastPage = new USDTCastPage() { Text = UIHelper.LocalString("USDT铸造", "USDT Casting") };
                this.tbc_sections.AddPage(USDTCastPage);
            }
        }
    }
}
