using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using OX.Wallets;
using OX.Bapps;
using OX.Network.P2P.Payloads;
using OX.Mining;
using OX.Ledger;
using OX.IO;
using OX.SmartContract;
using OX.Cryptography;
using OX.Cryptography.ECC;
using OX.Mining.StakingMining;
using OX.Tablet.Config;

namespace OX.Tablet.UIs.Rothschild
{
    public partial class SpaceTimeSnapshot : UIForm2
    {
        MutualLockSnapshotData Data;
        uint settleHeight;
        public SpaceTimeSnapshot(MutualLockSnapshotData data)
        {
            this.Data = data;
            InitializeComponent();
            this.Text = UIHelper.LocalString("时空量快照", "Space-Time volume snapshot");
            this.bt_close.Text = UIHelper.LocalString("关闭", "Close");
            this.lb_BlockIndex.Text = UIHelper.LocalString("结算高度:", "Settle Height:");
            this.lb_SelfSTVol.Text = UIHelper.LocalString("本徽章收益:", "Current Badge Income:");
            this.lb_LeafSTVol.Text = UIHelper.LocalString("叶子徽章收益:", "Leaf Badge Income:");
            this.bt_pre.Text = UIHelper.LocalString("上一结算点:", "Pre Settle Point:");
            this.bt_next.Text = UIHelper.LocalString("下一结算点:", "Next Settle Point:");

        }


        private void RegMinerForm_Load(object sender, EventArgs e)
        {
            var rem = Blockchain.Singleton.HeaderHeight % 100000;
            var rem2 = Data.Node.RegIndex % 100000;
            settleHeight = Blockchain.Singleton.HeaderHeight - rem + rem2;
            show();
        }

        private void tb_targetAssetId_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        void show()
        {
            var selfNum = this.Data.Self.Calculate(this.settleHeight) * this.Data.MutualLockMiningAssetReply.AirdropAmount;
            var leafNum = this.Data.Leaf.Calculate(this.settleHeight) * this.Data.MutualLockMiningAssetReply.AirdropAmount;
            this.tb_SelfSTVol.Text = selfNum.ToString();
            this.tb_LeafSTVol.Text = leafNum.ToString();
            this.tb_BlockIndex.Text = this.settleHeight.ToString();
        }

        private void bt_pre_Click(object sender, EventArgs e)
        {
            if (settleHeight > 100000)
                settleHeight -= 100000;
            show();
        }

        private void bt_next_Click(object sender, EventArgs e)
        {
            settleHeight += 100000;
            show();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
