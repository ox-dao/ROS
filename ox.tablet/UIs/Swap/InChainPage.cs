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
    public partial class InChainPage : BaseContentPage
    {

        ExchangePage ExchangePage = default;
       
        public InChainPage()
        {
            InitializeComponent();
            InitPages();
        }
        public static string _moduleKey => "exchange";
        public override string ModuleKey => _moduleKey;


        public override void HeartBeat(HeartBeatContext beatContext)
        {
            if (ExchangePage.IsNotNull())
                ExchangePage.HeartBeat(beatContext);
           
        }
        public override void BeforeBlock(Block block)
        {
            if (ExchangePage.IsNotNull())
                ExchangePage.BeforeBlock(block);
            
        }
        public override void OnBlock(Block block)
        {
            if (ExchangePage.IsNotNull())
                ExchangePage.OnBlock(block);
           
        }
        public override void AfterBlock(Block block)
        {
            if (ExchangePage.IsNotNull())
                ExchangePage.AfterBlock(block);
            
        }
        public override void OnClipboardString(ClipboardMessageType messageType, string msg)
        {

        }
        public override void MenuPageSelected()
        {
            if (ExchangePage.IsNotNull())
                ExchangePage.MenuPageSelected();
         
        }
        void InitPages()
        {
            ExchangePage = new ExchangePage() { Text = UIHelper.LocalString("交易", "Exchange") };
            this.tbc_sections.AddPage(ExchangePage);
             
        }
    }
}
