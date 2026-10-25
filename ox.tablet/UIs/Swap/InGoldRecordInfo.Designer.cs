namespace OX.Tablet
{
    partial class InGoldRecordInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            lb_amt = new Sunny.UI.UILabel();
            bt_transfer = new Sunny.UI.UIButton();
            lb_state = new Sunny.UI.UILabel();
            lb_eth_txid = new Sunny.UI.UILabel();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.AutoSize = true;
            uiGroupBox1.BackColor = Color.Transparent;
            uiGroupBox1.Controls.Add(lb_amt);
            uiGroupBox1.Controls.Add(bt_transfer);
            uiGroupBox1.Controls.Add(lb_state);
            uiGroupBox1.Controls.Add(lb_eth_txid);
            uiGroupBox1.Dock = DockStyle.Fill;
            uiGroupBox1.FillColor = Color.Transparent;
            uiGroupBox1.FillColor2 = Color.Transparent;
            uiGroupBox1.Font = new Font("微软雅黑", 9F);
            uiGroupBox1.Location = new Point(0, 0);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(864, 146);
            uiGroupBox1.TabIndex = 0;
            uiGroupBox1.Text = "uiGroupBox1";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiGroupBox1.Click += lb_master_balance_Click;
            // 
            // lb_amt
            // 
            lb_amt.AutoSize = true;
            lb_amt.Font = new Font("微软雅黑", 9F);
            lb_amt.ForeColor = Color.FromArgb(56, 56, 56);
            lb_amt.Location = new Point(15, 96);
            lb_amt.Name = "lb_amt";
            lb_amt.Size = new Size(83, 24);
            lb_amt.TabIndex = 20;
            lb_amt.Text = "uiLabel1";
            lb_amt.TextAlign = ContentAlignment.MiddleLeft;
            lb_amt.Click += lb_master_balance_Click;
            // 
            // bt_transfer
            // 
            bt_transfer.Font = new Font("微软雅黑", 12F);
            bt_transfer.Location = new Point(654, 80);
            bt_transfer.MinimumSize = new Size(1, 1);
            bt_transfer.Name = "bt_transfer";
            bt_transfer.Radius = 50;
            bt_transfer.Size = new Size(191, 52);
            bt_transfer.TabIndex = 19;
            bt_transfer.Text = "uiButton1";
            bt_transfer.TipsFont = new Font("微软雅黑", 9F);
            bt_transfer.ClientSizeChanged += bt_transfer_ClientSizeChanged;
            bt_transfer.Click += bt_transfer_Click;
            // 
            // lb_state
            // 
            lb_state.AutoSize = true;
            lb_state.Font = new Font("微软雅黑", 9F);
            lb_state.ForeColor = Color.FromArgb(56, 56, 56);
            lb_state.Location = new Point(389, 96);
            lb_state.Name = "lb_state";
            lb_state.Size = new Size(83, 24);
            lb_state.TabIndex = 10;
            lb_state.Text = "uiLabel1";
            lb_state.TextAlign = ContentAlignment.MiddleLeft;
            lb_state.Click += lb_master_balance_Click;
            // 
            // lb_eth_txid
            // 
            lb_eth_txid.AutoSize = true;
            lb_eth_txid.Font = new Font("微软雅黑", 9F);
            lb_eth_txid.ForeColor = Color.FromArgb(56, 56, 56);
            lb_eth_txid.Location = new Point(15, 39);
            lb_eth_txid.Name = "lb_eth_txid";
            lb_eth_txid.Size = new Size(83, 24);
            lb_eth_txid.TabIndex = 9;
            lb_eth_txid.Text = "uiLabel1";
            lb_eth_txid.TextAlign = ContentAlignment.MiddleLeft;
            lb_eth_txid.Click += lb_master_balance_Click;
            lb_eth_txid.DoubleClick += lb_eth_txid_DoubleClick;
            // 
            // InGoldRecordInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(uiGroupBox1);
            Name = "InGoldRecordInfo";
            Size = new Size(864, 146);
            Click += lb_master_balance_Click;
            uiGroupBox1.ResumeLayout(false);
            uiGroupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel lb_assetName;
        private Sunny.UI.UILabel lb_state;
        private Sunny.UI.UILabel lb_eth_txid;
        private Sunny.UI.UIButton bt_transfer;
        private Sunny.UI.UILabel lb_amt;
    }
}
