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
using Sunny.UI.Win32;

namespace OX.Tablet
{
    public partial class MarkSixMainPage : BaseContentPage
    {
        MarkPlayerPlaza MarkPlayerPlaza;
        MarkPortPlaza MarkPortPlaza;
        MarkMemberPlaza MarkMemberPlaza;
        public MarkSixMainPage()
        {
            InitializeComponent();
            InitPages();
        }
        public static string _moduleKey => "marksix";
        public override string ModuleKey => _moduleKey;


        public override void HeartBeat(HeartBeatContext beatContext)
        {
            if (MarkPlayerPlaza.IsNotNull())
                MarkPlayerPlaza.HeartBeat(beatContext);
            if (MarkPortPlaza.IsNotNull())
                MarkPortPlaza.HeartBeat(beatContext);
            if (MarkMemberPlaza.IsNotNull())
                MarkMemberPlaza.HeartBeat(beatContext);
        }
        public override void BeforeBlock(Block block)
        {
            if (MarkPlayerPlaza.IsNotNull())
                MarkPlayerPlaza.BeforeBlock(block);
            if (MarkPortPlaza.IsNotNull())
                MarkPortPlaza.BeforeBlock(block);
            if (MarkMemberPlaza.IsNotNull())
                MarkMemberPlaza.BeforeBlock(block);
        }
        public override void OnBlock(Block block)
        {
            if (MarkPlayerPlaza.IsNotNull())
                MarkPlayerPlaza.OnBlock(block);
            if (MarkPortPlaza.IsNotNull())
                MarkPortPlaza.OnBlock(block);
            if (MarkMemberPlaza.IsNotNull())
                MarkMemberPlaza.OnBlock(block);
        }
        public override void AfterBlock(Block block)
        {
            if (MarkPlayerPlaza.IsNotNull())
                MarkPlayerPlaza.AfterBlock(block);
            if (MarkPortPlaza.IsNotNull())
                MarkPortPlaza.AfterBlock(block);
            if (MarkMemberPlaza.IsNotNull())
                MarkMemberPlaza.AfterBlock(block);
        }
        public override void OnClipboardString(ClipboardMessageType messageType, string msg)
        {
            if (MarkPlayerPlaza.IsNotNull())
                MarkPlayerPlaza.OnClipboardString(messageType, msg);
            if (MarkPortPlaza.IsNotNull())
                MarkPortPlaza.OnClipboardString(messageType, msg);
            if (MarkMemberPlaza.IsNotNull())
                MarkMemberPlaza.OnClipboardString(messageType, msg);
        }
        public override void MenuPageSelected()
        {
            if (MarkPlayerPlaza.IsNotNull())
                MarkPlayerPlaza.MenuPageSelected();
            if (MarkPortPlaza.IsNotNull())
                MarkPortPlaza.MenuPageSelected();
            if (MarkMemberPlaza.IsNotNull())
                MarkMemberPlaza.MenuPageSelected();
        }
        void InitPages()
        {
            this.MarkPlayerPlaza = new MarkPlayerPlaza();
            this.tbc_sections.AddPage(MarkPlayerPlaza);

            MarkPortPlaza = new MarkPortPlaza();
            this.tbc_sections.AddPage(MarkPortPlaza);

            MarkMemberPlaza = new MarkMemberPlaza();
            this.tbc_sections.AddPage(MarkMemberPlaza);
        }
    }
}
