using OX.Bapps;
using OX.IO;
using OX.Tablet.Config;
using OX.Wallets;
using Sunny.UI;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OX.Tablet.UIs.MarkSix
{
    public partial class VerifyRiddles : UIForm
    {
        public UInt160 BetAddress;
        Riddles RiddlesRecord;
        RiddlesHash RiddlesHash;
        ulong MineNonce;
        public VerifyRiddles(UInt160 betAddres, RiddlesHash riddlesHash, Riddles riddlesRecord, ulong mineNonce)
        {
            InitializeComponent();
            this.BetAddress = betAddres;
            this.RiddlesHash = riddlesHash;
            this.MineNonce = mineNonce;
            this.RiddlesRecord = riddlesRecord;
            this.lb_index_v.Text = riddlesRecord.Index.ToString();
            this.tb_riddles.Text = riddlesRecord.ToArray().ToHexString();
            this.tb_riddles_hash.Text = riddlesHash.VerifyHash.ToString();
            StringBuilder sb = new StringBuilder();
            foreach (var g in riddlesRecord.GuessKeys)
            {
                var riddlesName = UIHelper.LocalString(g.RiddlesKind.StringValue(), g.RiddlesKind.EngStringValue());
                sb.AppendLine($"{riddlesName} : {g.SpecialPosition}/{g.SpecialChar}/{g.ReRandomSanGongOrLottoInnerString(riddlesRecord.Index, mineNonce)} \n");
            }
            this.tb_riddles_items.Text = sb.ToString();
            var casinoIndex = SecureHelper.BlockIndex.GetSubBlockIndex<CasinoBlockIndex>();
            if (casinoIndex.IsNotNull())
            {
                var results = casinoIndex.GetRoundClearResults(BetAddress, riddlesRecord.Index);
                this.cb_txhasList.Items.Clear();
                foreach (var result in results)
                {
                    this.cb_txhasList.Items.Add(result.Value.TxHash.ToString());
                }
            }
        }


        private void ClaimForm_Load(object sender, EventArgs e)
        {
            this.Text = UIHelper.LocalString("验证底牌", "Verify Riddles");
            //this.btnOk.Text = UIHelper.LocalString("确定", "OK");
            this.lb_index.Text = UIHelper.LocalString("区块链高度:", "Blockchain Height:");
            this.lb_riddles.Text = UIHelper.LocalString("底牌数据:", "Riddles Data:");
            this.lb_riddles_hash.Text = UIHelper.LocalString("底牌哈希:", "Riddles Hash:");
            this.bt_verify.Text = UIHelper.LocalString("验证", "Verify");
            this.bt_close.Text = UIHelper.LocalString("关闭", "Close");
            this.lb_txhash.Text = UIHelper.LocalString("开奖哈希:", "Prize Hashs:");
            this.lb_mineNonce.Text = UIHelper.LocalString("区块随机数:", "Block Random:");
            this.tb_mineNonce.Text = GuessKey.BuildRiddlesSeed(this.RiddlesRecord.Index, this.MineNonce).ToString();
        }

        private void ClaimForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        private void darkComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bt_NewRoom_Click(object sender, EventArgs e)
        {

        }

        private void cb_period_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_commissionkind_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_copy_Click(object sender, EventArgs e)
        {
            var proof = this.tb_riddles.Text;
            if (proof.IsNotNullAndEmpty())
            {
                try
                {
                    var riddles = proof.HexToBytes().AsSerializable<Riddles>();
                    if (riddles.Hash.ToString() == this.tb_riddles_hash.Text.Trim())
                    {
                        UIMessageBox.Show(UIHelper.LocalString("验证成功", "Validation  Success"), "");
                    }
                    else
                    {
                        UIMessageBox.Show(UIHelper.LocalString("验证失败", "Validation  Failed"), "");
                    }
                }
                catch (Exception) { UIMessageBox.Show(UIHelper.LocalString("验证失败", "Validation Failed"), ""); }
            }
        }

        private void cb_txhasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var txid = this.cb_txhasList.SelectedItem as string;
            Clipboard.SetText(txid);
            string msg = txid + UIHelper.LocalString("  已复制", "  copied");
            UIMessageBox.Show(msg);
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
