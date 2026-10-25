namespace OX.Tablet.UIs.OutChain
{
    partial class DirectSalePublishInfo
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
            bt_make_order_send = new Sunny.UI.UIButton();
            bt_make_order_copy = new Sunny.UI.UIButton();
            lb_timestamp = new Sunny.UI.UILabel();
            lb_contact = new Sunny.UI.UILabel();
            bt_copy_contact = new Sunny.UI.UIButton();
            bt_show_balance = new Sunny.UI.UIButton();
            lb_remarks = new Sunny.UI.UILabel();
            lb_seller = new Sunny.UI.UILabel();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.AutoSize = true;
            uiGroupBox1.BackColor = Color.Transparent;
            uiGroupBox1.Controls.Add(bt_make_order_send);
            uiGroupBox1.Controls.Add(bt_make_order_copy);
            uiGroupBox1.Controls.Add(lb_timestamp);
            uiGroupBox1.Controls.Add(lb_contact);
            uiGroupBox1.Controls.Add(bt_copy_contact);
            uiGroupBox1.Controls.Add(bt_show_balance);
            uiGroupBox1.Controls.Add(lb_remarks);
            uiGroupBox1.Controls.Add(lb_seller);
            uiGroupBox1.Dock = DockStyle.Fill;
            uiGroupBox1.FillColor = Color.Transparent;
            uiGroupBox1.FillColor2 = Color.Transparent;
            uiGroupBox1.Font = new Font("微软雅黑", 9F);
            uiGroupBox1.Location = new Point(0, 0);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 38, 0, 0);
            uiGroupBox1.Size = new Size(1151, 267);
            uiGroupBox1.TabIndex = 0;
            uiGroupBox1.Text = "uiGroupBox1";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiGroupBox1.Click += lb_master_balance_Click;
            // 
            // bt_make_order_send
            // 
            bt_make_order_send.Font = new Font("微软雅黑", 12F);
            bt_make_order_send.Location = new Point(786, 165);
            bt_make_order_send.MinimumSize = new Size(1, 1);
            bt_make_order_send.Name = "bt_make_order_send";
            bt_make_order_send.Radius = 50;
            bt_make_order_send.Size = new Size(220, 52);
            bt_make_order_send.TabIndex = 27;
            bt_make_order_send.Text = "uiButton1";
            bt_make_order_send.TipsFont = new Font("微软雅黑", 9F);
            bt_make_order_send.Click += bt_make_order_send_Click;
            // 
            // bt_make_order_copy
            // 
            bt_make_order_copy.Font = new Font("微软雅黑", 12F);
            bt_make_order_copy.Location = new Point(547, 165);
            bt_make_order_copy.MinimumSize = new Size(1, 1);
            bt_make_order_copy.Name = "bt_make_order_copy";
            bt_make_order_copy.Radius = 50;
            bt_make_order_copy.Size = new Size(220, 52);
            bt_make_order_copy.TabIndex = 26;
            bt_make_order_copy.Text = "uiButton1";
            bt_make_order_copy.TipsFont = new Font("微软雅黑", 9F);
            bt_make_order_copy.Click += bt_make_order_copy_Click;
            // 
            // lb_timestamp
            // 
            lb_timestamp.AutoSize = true;
            lb_timestamp.Font = new Font("微软雅黑", 8F);
            lb_timestamp.ForeColor = Color.FromArgb(56, 56, 56);
            lb_timestamp.Location = new Point(23, 186);
            lb_timestamp.Name = "lb_timestamp";
            lb_timestamp.Size = new Size(73, 21);
            lb_timestamp.TabIndex = 25;
            lb_timestamp.Text = "uiLabel1";
            lb_timestamp.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_contact
            // 
            lb_contact.AutoSize = true;
            lb_contact.Font = new Font("微软雅黑", 9F);
            lb_contact.ForeColor = Color.FromArgb(56, 56, 56);
            lb_contact.Location = new Point(13, 77);
            lb_contact.Name = "lb_contact";
            lb_contact.Size = new Size(83, 24);
            lb_contact.TabIndex = 24;
            lb_contact.Text = "uiLabel1";
            lb_contact.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bt_copy_contact
            // 
            bt_copy_contact.Font = new Font("微软雅黑", 12F);
            bt_copy_contact.Location = new Point(365, 165);
            bt_copy_contact.MinimumSize = new Size(1, 1);
            bt_copy_contact.Name = "bt_copy_contact";
            bt_copy_contact.Radius = 50;
            bt_copy_contact.Size = new Size(163, 52);
            bt_copy_contact.TabIndex = 22;
            bt_copy_contact.Text = "uiButton1";
            bt_copy_contact.TipsFont = new Font("微软雅黑", 9F);
            bt_copy_contact.Click += bt_self_lock_Click;
            // 
            // bt_show_balance
            // 
            bt_show_balance.Font = new Font("微软雅黑", 12F);
            bt_show_balance.Location = new Point(200, 165);
            bt_show_balance.MinimumSize = new Size(1, 1);
            bt_show_balance.Name = "bt_show_balance";
            bt_show_balance.Radius = 50;
            bt_show_balance.Size = new Size(139, 52);
            bt_show_balance.TabIndex = 21;
            bt_show_balance.Text = "uiButton1";
            bt_show_balance.TipsFont = new Font("微软雅黑", 9F);
            bt_show_balance.Click += bt_reg_miner_Click;
            // 
            // lb_remarks
            // 
            lb_remarks.AutoSize = true;
            lb_remarks.Font = new Font("微软雅黑", 9F);
            lb_remarks.ForeColor = Color.FromArgb(56, 56, 56);
            lb_remarks.Location = new Point(13, 110);
            lb_remarks.Name = "lb_remarks";
            lb_remarks.Size = new Size(83, 24);
            lb_remarks.TabIndex = 20;
            lb_remarks.Text = "uiLabel1";
            lb_remarks.TextAlign = ContentAlignment.MiddleLeft;
            lb_remarks.Click += lb_master_balance_Click;
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
            // DirectSalePublishInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(uiGroupBox1);
            Margin = new Padding(2);
            Name = "DirectSalePublishInfo";
            Size = new Size(1151, 267);
            Click += lb_master_balance_Click;
            uiGroupBox1.ResumeLayout(false);
            uiGroupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel lb_seller;
        private Sunny.UI.UILabel lb_remarks;
        private Sunny.UI.UIButton bt_show_balance;
        private Sunny.UI.UIButton bt_copy_contact;
        private Sunny.UI.UILabel lb_contact;
        private Sunny.UI.UILabel lb_timestamp;
        private Sunny.UI.UIButton bt_make_order_copy;
        private Sunny.UI.UIButton bt_make_order_send;
    }
}
