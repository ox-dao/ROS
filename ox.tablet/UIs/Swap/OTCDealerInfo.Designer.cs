namespace OX.Tablet
{
    partial class OTCDealerInfo
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
            lb_fee = new Sunny.UI.UILabel();
            bt_transfer = new Sunny.UI.UIButton();
            lb_state = new Sunny.UI.UILabel();
            lb_usdt_balance = new Sunny.UI.UILabel();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.AutoSize = true;
            uiGroupBox1.BackColor = Color.Transparent;
            uiGroupBox1.Controls.Add(lb_fee);
            uiGroupBox1.Controls.Add(bt_transfer);
            uiGroupBox1.Controls.Add(lb_state);
            uiGroupBox1.Controls.Add(lb_usdt_balance);
            uiGroupBox1.Dock = DockStyle.Fill;
            uiGroupBox1.FillColor = Color.Transparent;
            uiGroupBox1.FillColor2 = Color.Transparent;
            uiGroupBox1.Font = new Font("微软雅黑", 9F);
            uiGroupBox1.Location = new Point(0, 0);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(759, 111);
            uiGroupBox1.TabIndex = 0;
            uiGroupBox1.Text = "uiGroupBox1";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiGroupBox1.Click += lb_master_balance_Click;
            // 
            // lb_fee
            // 
            lb_fee.Font = new Font("微软雅黑", 9F);
            lb_fee.ForeColor = Color.FromArgb(56, 56, 56);
            lb_fee.Location = new Point(241, 42);
            lb_fee.Name = "lb_fee";
            lb_fee.Size = new Size(122, 34);
            lb_fee.TabIndex = 20;
            lb_fee.Text = "uiLabel1";
            lb_fee.TextAlign = ContentAlignment.MiddleLeft;
            lb_fee.Click += lb_master_balance_Click;
            // 
            // bt_transfer
            // 
            bt_transfer.Font = new Font("微软雅黑", 12F);
            bt_transfer.Location = new Point(554, 35);
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
            lb_state.Font = new Font("微软雅黑", 9F);
            lb_state.ForeColor = Color.FromArgb(56, 56, 56);
            lb_state.Location = new Point(382, 42);
            lb_state.Name = "lb_state";
            lb_state.Size = new Size(112, 34);
            lb_state.TabIndex = 10;
            lb_state.Text = "uiLabel1";
            lb_state.TextAlign = ContentAlignment.MiddleLeft;
            lb_state.Click += lb_master_balance_Click;
            // 
            // lb_usdt_balance
            // 
            lb_usdt_balance.Font = new Font("微软雅黑", 9F);
            lb_usdt_balance.ForeColor = Color.FromArgb(56, 56, 56);
            lb_usdt_balance.Location = new Point(15, 42);
            lb_usdt_balance.Name = "lb_usdt_balance";
            lb_usdt_balance.Size = new Size(212, 34);
            lb_usdt_balance.TabIndex = 9;
            lb_usdt_balance.Text = "uiLabel1";
            lb_usdt_balance.TextAlign = ContentAlignment.MiddleLeft;
            lb_usdt_balance.Click += lb_master_balance_Click;
            // 
            // OTCDealerInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Transparent;
            Controls.Add(uiGroupBox1);
            Name = "OTCDealerInfo";
            Size = new Size(759, 111);
            Click += lb_master_balance_Click;
            uiGroupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel lb_assetName;
        private Sunny.UI.UILabel lb_state;
        private Sunny.UI.UILabel lb_usdt_balance;
        private Sunny.UI.UIButton bt_transfer;
        private Sunny.UI.UILabel lb_fee;
    }
}
