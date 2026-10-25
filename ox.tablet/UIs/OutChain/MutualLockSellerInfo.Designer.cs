namespace OX.Tablet.UIs.OutChain
{
    partial class MutualLockSellerInfo
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
            bt_copyBuyerAddr = new Sunny.UI.UIButton();
            lb_lock_state = new Sunny.UI.UILabel();
            lb_delivery_expire = new Sunny.UI.UILabel();
            lb_assetName = new Sunny.UI.UILabel();
            bt_delivery = new Sunny.UI.UIButton();
            lb_amount = new Sunny.UI.UILabel();
            bt_redeem = new Sunny.UI.UIButton();
            lb_buyer = new Sunny.UI.UILabel();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.AutoSize = true;
            uiGroupBox1.BackColor = Color.Transparent;
            uiGroupBox1.Controls.Add(bt_copyBuyerAddr);
            uiGroupBox1.Controls.Add(lb_lock_state);
            uiGroupBox1.Controls.Add(lb_delivery_expire);
            uiGroupBox1.Controls.Add(lb_assetName);
            uiGroupBox1.Controls.Add(bt_delivery);
            uiGroupBox1.Controls.Add(lb_amount);
            uiGroupBox1.Controls.Add(bt_redeem);
            uiGroupBox1.Controls.Add(lb_buyer);
            uiGroupBox1.Dock = DockStyle.Fill;
            uiGroupBox1.FillColor = Color.Transparent;
            uiGroupBox1.FillColor2 = Color.Transparent;
            uiGroupBox1.Font = new Font("微软雅黑", 9F);
            uiGroupBox1.Location = new Point(0, 0);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(1133, 319);
            uiGroupBox1.TabIndex = 0;
            uiGroupBox1.Text = "uiGroupBox1";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiGroupBox1.Click += lb_master_balance_Click;
            // 
            // bt_copyBuyerAddr
            // 
            bt_copyBuyerAddr.Font = new Font("微软雅黑", 12F);
            bt_copyBuyerAddr.Location = new Point(487, 29);
            bt_copyBuyerAddr.MinimumSize = new Size(1, 1);
            bt_copyBuyerAddr.Name = "bt_copyBuyerAddr";
            bt_copyBuyerAddr.Radius = 50;
            bt_copyBuyerAddr.Size = new Size(232, 52);
            bt_copyBuyerAddr.TabIndex = 27;
            bt_copyBuyerAddr.Text = "uiButton1";
            bt_copyBuyerAddr.TipsFont = new Font("微软雅黑", 9F);
            bt_copyBuyerAddr.Click += bt_copyBuyerAddr_Click;
            // 
            // lb_lock_state
            // 
            lb_lock_state.AutoSize = true;
            lb_lock_state.Font = new Font("微软雅黑", 9F);
            lb_lock_state.ForeColor = Color.FromArgb(56, 56, 56);
            lb_lock_state.Location = new Point(13, 187);
            lb_lock_state.Name = "lb_lock_state";
            lb_lock_state.Size = new Size(83, 24);
            lb_lock_state.TabIndex = 26;
            lb_lock_state.Text = "uiLabel1";
            lb_lock_state.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_delivery_expire
            // 
            lb_delivery_expire.AutoSize = true;
            lb_delivery_expire.Font = new Font("微软雅黑", 9F);
            lb_delivery_expire.ForeColor = Color.FromArgb(56, 56, 56);
            lb_delivery_expire.Location = new Point(13, 147);
            lb_delivery_expire.Name = "lb_delivery_expire";
            lb_delivery_expire.Size = new Size(83, 24);
            lb_delivery_expire.TabIndex = 25;
            lb_delivery_expire.Text = "uiLabel1";
            lb_delivery_expire.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_assetName
            // 
            lb_assetName.AutoSize = true;
            lb_assetName.Font = new Font("微软雅黑", 9F);
            lb_assetName.ForeColor = Color.FromArgb(56, 56, 56);
            lb_assetName.Location = new Point(13, 77);
            lb_assetName.Name = "lb_assetName";
            lb_assetName.Size = new Size(83, 24);
            lb_assetName.TabIndex = 24;
            lb_assetName.Text = "uiLabel1";
            lb_assetName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bt_delivery
            // 
            bt_delivery.Font = new Font("微软雅黑", 12F);
            bt_delivery.Location = new Point(487, 94);
            bt_delivery.MinimumSize = new Size(1, 1);
            bt_delivery.Name = "bt_delivery";
            bt_delivery.Radius = 50;
            bt_delivery.Size = new Size(232, 52);
            bt_delivery.TabIndex = 23;
            bt_delivery.Text = "uiButton1";
            bt_delivery.TipsFont = new Font("微软雅黑", 9F);
            bt_delivery.Click += bt_delivery_Click;
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Font = new Font("微软雅黑", 9F);
            lb_amount.ForeColor = Color.FromArgb(56, 56, 56);
            lb_amount.Location = new Point(13, 110);
            lb_amount.Name = "lb_amount";
            lb_amount.Size = new Size(83, 24);
            lb_amount.TabIndex = 20;
            lb_amount.Text = "uiLabel1";
            lb_amount.TextAlign = ContentAlignment.MiddleLeft;
            lb_amount.Click += lb_master_balance_Click;
            // 
            // bt_redeem
            // 
            bt_redeem.Font = new Font("微软雅黑", 12F);
            bt_redeem.Location = new Point(487, 159);
            bt_redeem.MinimumSize = new Size(1, 1);
            bt_redeem.Name = "bt_redeem";
            bt_redeem.Radius = 50;
            bt_redeem.Size = new Size(232, 52);
            bt_redeem.TabIndex = 19;
            bt_redeem.Text = "uiButton1";
            bt_redeem.TipsFont = new Font("微软雅黑", 9F);
            bt_redeem.Click += bt_redeem_Click;
            // 
            // lb_buyer
            // 
            lb_buyer.AutoSize = true;
            lb_buyer.Font = new Font("微软雅黑", 9F);
            lb_buyer.ForeColor = Color.FromArgb(56, 56, 56);
            lb_buyer.Location = new Point(13, 42);
            lb_buyer.Name = "lb_buyer";
            lb_buyer.Size = new Size(83, 24);
            lb_buyer.TabIndex = 8;
            lb_buyer.Text = "uiLabel1";
            lb_buyer.TextAlign = ContentAlignment.MiddleLeft;
            lb_buyer.Click += lb_master_balance_Click;
            // 
            // MutualLockSellerInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(uiGroupBox1);
            Name = "MutualLockSellerInfo";
            Size = new Size(1133, 319);
            Click += lb_master_balance_Click;
            uiGroupBox1.ResumeLayout(false);
            uiGroupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel lb_buyer;
       
        private Sunny.UI.UIButton bt_redeem;
        private Sunny.UI.UILabel lb_amount;
        private Sunny.UI.UIButton bt_delivery;
        private Sunny.UI.UILabel lb_assetName;
        private Sunny.UI.UILabel lb_delivery_expire;
        private Sunny.UI.UILabel lb_lock_state;
        private Sunny.UI.UIButton bt_copyBuyerAddr;
    }
}
