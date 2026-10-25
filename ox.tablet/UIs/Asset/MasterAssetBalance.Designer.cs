namespace OX.Tablet
{
    partial class MasterAssetBalance
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
            bt_claim = new Sunny.UI.UIButton();
            bt_self_lock = new Sunny.UI.UIButton();
            bt_reg_miner = new Sunny.UI.UIButton();
            lb_total_balance = new Sunny.UI.UILabel();
            bt_transfer = new Sunny.UI.UIButton();
            lb_master_balance = new Sunny.UI.UILabel();
            lb_available_balance = new Sunny.UI.UILabel();
            lb_assetName = new Sunny.UI.UILabel();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.AutoSize = true;
            uiGroupBox1.BackColor = Color.Transparent;
            uiGroupBox1.Controls.Add(bt_claim);
            uiGroupBox1.Controls.Add(bt_self_lock);
            uiGroupBox1.Controls.Add(bt_reg_miner);
            uiGroupBox1.Controls.Add(lb_total_balance);
            uiGroupBox1.Controls.Add(bt_transfer);
            uiGroupBox1.Controls.Add(lb_master_balance);
            uiGroupBox1.Controls.Add(lb_available_balance);
            uiGroupBox1.Controls.Add(lb_assetName);
            uiGroupBox1.Dock = DockStyle.Fill;
            uiGroupBox1.FillColor = Color.Transparent;
            uiGroupBox1.FillColor2 = Color.Transparent;
            uiGroupBox1.Font = new Font("微软雅黑", 9F);
            uiGroupBox1.Location = new Point(0, 0);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 38, 0, 0);
            uiGroupBox1.Size = new Size(1291, 193);
            uiGroupBox1.TabIndex = 0;
            uiGroupBox1.Text = "uiGroupBox1";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiGroupBox1.Click += lb_master_balance_Click;
            // 
            // bt_claim
            // 
            bt_claim.Font = new Font("微软雅黑", 12F);
            bt_claim.Location = new Point(564, 90);
            bt_claim.MinimumSize = new Size(1, 1);
            bt_claim.Name = "bt_claim";
            bt_claim.Radius = 50;
            bt_claim.Size = new Size(191, 52);
            bt_claim.TabIndex = 23;
            bt_claim.Text = "uiButton1";
            bt_claim.TipsFont = new Font("微软雅黑", 9F);
            bt_claim.Click += bt_claim_Click;
            // 
            // bt_self_lock
            // 
            bt_self_lock.Font = new Font("微软雅黑", 12F);
            bt_self_lock.Location = new Point(294, 90);
            bt_self_lock.MinimumSize = new Size(1, 1);
            bt_self_lock.Name = "bt_self_lock";
            bt_self_lock.Radius = 50;
            bt_self_lock.Size = new Size(191, 52);
            bt_self_lock.TabIndex = 22;
            bt_self_lock.Text = "uiButton1";
            bt_self_lock.TipsFont = new Font("微软雅黑", 9F);
            bt_self_lock.Click += bt_self_lock_Click;
            // 
            // bt_reg_miner
            // 
            bt_reg_miner.Font = new Font("微软雅黑", 12F);
            bt_reg_miner.Location = new Point(22, 90);
            bt_reg_miner.MinimumSize = new Size(1, 1);
            bt_reg_miner.Name = "bt_reg_miner";
            bt_reg_miner.Radius = 50;
            bt_reg_miner.Size = new Size(191, 52);
            bt_reg_miner.TabIndex = 21;
            bt_reg_miner.Text = "uiButton1";
            bt_reg_miner.TipsFont = new Font("微软雅黑", 9F);
            bt_reg_miner.Click += bt_reg_miner_Click;
            // 
            // lb_total_balance
            // 
            lb_total_balance.Font = new Font("微软雅黑", 9F);
            lb_total_balance.ForeColor = Color.FromArgb(56, 56, 56);
            lb_total_balance.Location = new Point(517, 42);
            lb_total_balance.Name = "lb_total_balance";
            lb_total_balance.Size = new Size(291, 34);
            lb_total_balance.TabIndex = 20;
            lb_total_balance.Text = "uiLabel1";
            lb_total_balance.TextAlign = ContentAlignment.MiddleLeft;
            lb_total_balance.Click += lb_master_balance_Click;
            // 
            // bt_transfer
            // 
            bt_transfer.Font = new Font("微软雅黑", 12F);
            bt_transfer.Location = new Point(817, 90);
            bt_transfer.MinimumSize = new Size(1, 1);
            bt_transfer.Name = "bt_transfer";
            bt_transfer.Radius = 50;
            bt_transfer.Size = new Size(191, 52);
            bt_transfer.TabIndex = 19;
            bt_transfer.Text = "uiButton1";
            bt_transfer.TipsFont = new Font("微软雅黑", 9F);
            bt_transfer.Click += bt_transfer_Click;
            // 
            // lb_master_balance
            // 
            lb_master_balance.Font = new Font("微软雅黑", 9F);
            lb_master_balance.ForeColor = Color.FromArgb(56, 56, 56);
            lb_master_balance.Location = new Point(826, 42);
            lb_master_balance.Name = "lb_master_balance";
            lb_master_balance.Size = new Size(312, 34);
            lb_master_balance.TabIndex = 10;
            lb_master_balance.Text = "uiLabel1";
            lb_master_balance.TextAlign = ContentAlignment.MiddleLeft;
            lb_master_balance.Click += lb_master_balance_Click;
            // 
            // lb_available_balance
            // 
            lb_available_balance.Font = new Font("微软雅黑", 9F);
            lb_available_balance.ForeColor = Color.FromArgb(56, 56, 56);
            lb_available_balance.Location = new Point(195, 42);
            lb_available_balance.Name = "lb_available_balance";
            lb_available_balance.Size = new Size(305, 34);
            lb_available_balance.TabIndex = 9;
            lb_available_balance.Text = "uiLabel1";
            lb_available_balance.TextAlign = ContentAlignment.MiddleLeft;
            lb_available_balance.Click += lb_master_balance_Click;
            // 
            // lb_assetName
            // 
            lb_assetName.Font = new Font("微软雅黑", 9F);
            lb_assetName.ForeColor = Color.FromArgb(56, 56, 56);
            lb_assetName.Location = new Point(13, 42);
            lb_assetName.Name = "lb_assetName";
            lb_assetName.Size = new Size(169, 34);
            lb_assetName.TabIndex = 8;
            lb_assetName.Text = "uiLabel1";
            lb_assetName.TextAlign = ContentAlignment.MiddleLeft;
            lb_assetName.Click += lb_master_balance_Click;
            // 
            // MasterAssetBalance
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Transparent;
            Controls.Add(uiGroupBox1);
            Margin = new Padding(2);
            Name = "MasterAssetBalance";
            Size = new Size(1291, 193);
            Click += lb_master_balance_Click;
            uiGroupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel lb_assetName;
        private Sunny.UI.UILabel lb_master_balance;
        private Sunny.UI.UILabel lb_available_balance;
        private Sunny.UI.UIButton bt_transfer;
        private Sunny.UI.UILabel lb_total_balance;
        private Sunny.UI.UIButton bt_reg_miner;
        private Sunny.UI.UIButton bt_self_lock;
        private Sunny.UI.UIButton bt_claim;
    }
}
