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
using Nethereum.Model;
using OX.Persistence;

namespace OX.Tablet.FlashMessages
{
    public partial class FlashMessagePage : BaseContentPage
    {

         
        UnicastSubPage UnicastSubPage = default;
        MulticastSubPage MulticastSubPage = default;
        OX.Tablet.FlashSupports.SetSemanticSubPage SetSemanticSubPage = default;
        public FlashMessagePage()
        {
            InitializeComponent();
            InitPages();
        }
        public static string _moduleKey => "flashmessage";
        public override string ModuleKey => _moduleKey;


        public override void HeartBeat(HeartBeatContext beatContext)
        {
            if (UnicastSubPage.IsNotNull())
                UnicastSubPage.HeartBeat(beatContext);
            if (MulticastSubPage.IsNotNull())
                MulticastSubPage.HeartBeat(beatContext);

        }
        public override void BeforeBlock(Block block)
        {
            if (UnicastSubPage.IsNotNull())
                UnicastSubPage.BeforeBlock(block);
            if (MulticastSubPage.IsNotNull())
                MulticastSubPage.BeforeBlock(block);

        }
        public override void OnBlock(Block block)
        {
            if (UnicastSubPage.IsNotNull())
                UnicastSubPage.OnBlock(block);
            if (MulticastSubPage.IsNotNull())
                MulticastSubPage.OnBlock(block);

        }
        public override void AfterBlock(Block block)
        {
            if (UnicastSubPage.IsNotNull())
                UnicastSubPage.AfterBlock(block);
            if (MulticastSubPage.IsNotNull())
                MulticastSubPage.AfterBlock(block);

        }
        public override void OnFlashMessage(FlashMessage message)
        {
         
            if (UnicastSubPage.IsNotNull())
                UnicastSubPage.OnFlashMessage(message);
            if (MulticastSubPage.IsNotNull())
                MulticastSubPage.OnFlashMessage(message);
        }
        public override void OnClipboardString(ClipboardMessageType messageType, string msg)
        {
            
            if (UnicastSubPage.IsNotNull())
                UnicastSubPage.OnClipboardString(messageType, msg);
            if (MulticastSubPage.IsNotNull())
                MulticastSubPage.OnClipboardString(messageType, msg);

        }
        public override void MenuPageSelected()
        {
            
            if (UnicastSubPage.IsNotNull())
                UnicastSubPage.MenuPageSelected();
            if (MulticastSubPage.IsNotNull())
                MulticastSubPage.MenuPageSelected();

        }
        void InitPages()
        {
          
            var dmbs = FlashMessageHelper.GetDomain(SecureHelper.MasterAccount.ScriptHash);
            if (dmbs.IsNotNullAndEmpty())
            {
                UnicastSubPage = UnicastSubPage.Instance;
                MulticastSubPage = MulticastSubPage.Instance;
                this.tbc_sections.AddPage(UnicastSubPage);
                this.tbc_sections.AddPage(MulticastSubPage);
            }
            else
            {
                SetSemanticSubPage = new OX.Tablet.FlashSupports.SetSemanticSubPage() { Text = UIHelper.LocalString("设置名称", "Set Name") };
                this.tbc_sections.AddPage(SetSemanticSubPage);
            }
        }
    }
}
