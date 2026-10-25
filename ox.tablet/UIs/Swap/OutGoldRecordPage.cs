using Akka.IO;
using Org.BouncyCastle.Bcpg;
using OX.BMS;
using OX.Ledger;
using OX.Mining;
using OX.Network.P2P.Payloads;
using OX.Tablet.Config;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using OX.Mining.OTC;

namespace OX.Tablet.UIs.MarkSix
{
    public partial class OutGoldRecordPage : UIPage, IBlockchainHandler
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));


        public OutGoldRecordPage()
        {
            InitializeComponent();
            this.L1.Text = UIHelper.LocalString("已完成的出金记录","Completed Withdrawal Records");
            this.bt_refresh.Text = UIHelper.LocalString("刷新", "Refresh");

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
        public void OnFlashMessage(FlashMessage message)
        {

        }
        public void OnClipboardString(ClipboardMessageType messageType, string msg) { }
        public virtual void MenuPageSelected() { ReloadRecord(); }

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

        void ReloadRecord()
        {
            this.DoInvoke(() =>
            {
                this.pn_pairs.Clear();
                if (SecureHelper.BlockIndex.IsNotNull())
                {
                    var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
                    foreach (var r in miningIndex.OutGoldRecords.OrderByDescending(m => m.Value.TimeStamp))
                    {
                        this.pn_pairs.Add(new OutGoldRecordInfo(r.Value));
                    }
                }
            });
        }

        private void OrderHistory_Initialize(object sender, EventArgs e)
        {

        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            ReloadRecord();
        }
    }
}
