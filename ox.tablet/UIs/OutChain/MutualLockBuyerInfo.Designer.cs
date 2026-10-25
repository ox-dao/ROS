namespace OX.Tablet.UIs.OutChain
{
    partial class MutualLockBuyerInfo
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
            bt_copy_seller_eth = new Sunny.UI.UIButton();
            lb_seller_eth = new Sunny.UI.UILabel();
            lb_lock_state = new Sunny.UI.UILabel();
            lb_delivery_expire = new Sunny.UI.UILabel();
            lb_assetName = new Sunny.UI.UILabel();
            lb_amount = new Sunny.UI.UILabel();
            bt_do_lock = new Sunny.UI.UIButton();
            lb_seller = new Sunny.UI.UILabel();
            bt_pay_usdt = new Sunny.UI.UIButton();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.BackColor = Color.Transparent;
            uiGroupBox1.Controls.Add(bt_pay_usdt);
            uiGroupBox1.Controls.Add(bt_copy_seller_eth);
            uiGroupBox1.Controls.Add(lb_seller_eth);
            uiGroupBox1.Controls.Add(lb_lock_state);
            uiGroupBox1.Controls.Add(lb_delivery_expire);
            uiGroupBox1.Controls.Add(lb_assetName);
            uiGroupBox1.Controls.Add(lb_amount);
            uiGroupBox1.Controls.Add(bt_do_lock);
            uiGroupBox1.Controls.Add(lb_seller);
            uiGroupBox1.Dock = DockStyle.Fill;
            uiGroupBox1.FillColor = Color.Transparent;
            uiGroupBox1.FillColor2 = Color.Transparent;
            uiGroupBox1.Font = new Font("微软雅黑", 9F);
            uiGroupBox1.Location = new Point(0, 0);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(1200, 343);
            uiGroupBox1.TabIndex = 0;
            uiGroupBox1.Text = "uiGroupBox1";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiGroupBox1.Click += lb_master_balance_Click;
            // 
            // bt_copy_seller_eth
            // 
            bt_copy_seller_eth.Font = new Font("微软雅黑", 12F);
            bt_copy_seller_eth.Location = new Point(519, 110);
            bt_copy_seller_eth.MinimumSize = new Size(1, 1);
            bt_copy_seller_eth.Name = "bt_copy_seller_eth";
            bt_copy_seller_eth.Radius = 50;
            bt_copy_seller_eth.Size = new Size(226, 52);
            bt_copy_seller_eth.TabIndex = 28;
            bt_copy_seller_eth.Text = "uiButton1";
            bt_copy_seller_eth.TipsFont = new Font("微软雅黑", 9F);
            bt_copy_seller_eth.Click += bt_copy_seller_eth_Click;
            // 
            // lb_seller_eth
            // 
            lb_seller_eth.AutoSize = true;
            lb_seller_eth.Font = new Font("微软雅黑", 9F);
            lb_seller_eth.ForeColor = Color.FromArgb(56, 56, 56);
            lb_seller_eth.Location = new Point(13, 77);
            lb_seller_eth.Name = "lb_seller_eth";
            lb_seller_eth.Size = new Size(83, 24);
            lb_seller_eth.TabIndex = 27;
            lb_seller_eth.Text = "uiLabel1";
            lb_seller_eth.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_lock_state
            // 
            lb_lock_state.AutoSize = true;
            lb_lock_state.Font = new Font("微软雅黑", 9F);
            lb_lock_state.ForeColor = Color.FromArgb(56, 56, 56);
            lb_lock_state.Location = new Point(13, 219);
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
            lb_delivery_expire.Location = new Point(13, 179);
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
            lb_assetName.Location = new Point(13, 109);
            lb_assetName.Name = "lb_assetName";
            lb_assetName.Size = new Size(83, 24);
            lb_assetName.TabIndex = 24;
            lb_assetName.Text = "uiLabel1";
            lb_assetName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Font = new Font("微软雅黑", 9F);
            lb_amount.ForeColor = Color.FromArgb(56, 56, 56);
            lb_amount.Location = new Point(13, 142);
            lb_amount.Name = "lb_amount";
            lb_amount.Size = new Size(83, 24);
            lb_amount.TabIndex = 20;
            lb_amount.Text = "uiLabel1";
            lb_amount.TextAlign = ContentAlignment.MiddleLeft;
            lb_amount.Click += lb_master_balance_Click;
            // 
            // bt_do_lock
            // 
            bt_do_lock.Font = new Font("微软雅黑", 12F);
            bt_do_lock.Location = new Point(519, 225);
            bt_do_lock.MinimumSize = new Size(1, 1);
            bt_do_lock.Name = "bt_do_lock";
            bt_do_lock.Radius = 50;
            bt_do_lock.Size = new Size(226, 52);
            bt_do_lock.TabIndex = 19;
            bt_do_lock.Text = "uiButton1";
            bt_do_lock.TipsFont = new Font("微软雅黑", 9F);
            bt_do_lock.Click += bt_do_lock_Click;
            // 
            // lb_seller
            // 
            lb_seller.AutoSize = true;
            lb_seller.Font = new Font("微软雅黑", 9F);
            lb_seller.ForeColor = Color.FromArgb(56, 56, 56);
            lb_seller.Location = new Point(13, 42);
            lb_seller.Name = "lb_seller";
            lb_seller.Size = new Size(83, 24);
            lb_seller.TabIndex = 8;
            lb_seller.Text = "uiLabel1";
            lb_seller.TextAlign = ContentAlignment.MiddleLeft;
            lb_seller.Click += lb_master_balance_Click;
            // 
            // bt_pay_usdt
            // 
            bt_pay_usdt.Font = new Font("微软雅黑", 12F);
            bt_pay_usdt.Location = new Point(519, 168);
            bt_pay_usdt.MinimumSize = new Size(1, 1);
            bt_pay_usdt.Name = "bt_pay_usdt";
            bt_pay_usdt.Radius = 50;
            bt_pay_usdt.Size = new Size(226, 52);
            bt_pay_usdt.TabIndex = 29;
            bt_pay_usdt.Text = "uiButton1";
            bt_pay_usdt.TipsFont = new Font("微软雅黑", 9F);
            bt_pay_usdt.Click += bt_pay_usdt_Click;
            // 
            // MutualLockBuyerInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(uiGroupBox1);
            Name = "MutualLockBuyerInfo";
            Size = new Size(1200, 343);
            Click += lb_master_balance_Click;
            uiGroupBox1.ResumeLayout(false);
            uiGroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel lb_seller;
       
        private Sunny.UI.UIButton bt_do_lock;
        private Sunny.UI.UILabel lb_amount;
        private Sunny.UI.UILabel lb_assetName;
        private Sunny.UI.UILabel lb_delivery_expire;
        private Sunny.UI.UILabel lb_lock_state;
        private Sunny.UI.UILabel lb_seller_eth;
        private Sunny.UI.UIButton bt_copy_seller_eth;
        private Sunny.UI.UIButton bt_pay_usdt;
    }
}
