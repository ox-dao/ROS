namespace OX.Tablet
{
    partial class PortBox
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
            lb_balance = new Sunny.UI.UILabel();
            lb_deposit = new Sunny.UI.UILabel();
            lb_total_term = new Sunny.UI.UILabel();
            lb_total_bet = new Sunny.UI.UILabel();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(lb_balance);
            uiGroupBox1.Controls.Add(lb_deposit);
            uiGroupBox1.Controls.Add(lb_total_term);
            uiGroupBox1.Controls.Add(lb_total_bet);
            uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new System.Drawing.Size(289, 186);
            uiGroupBox1.TabIndex = 0;
            uiGroupBox1.Text = "uiGroupBox1";
            uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiGroupBox1.Click += lb_master_balance_Click;
            // 
            // lb_balance
            // 
            lb_balance.AutoSize = true;
            lb_balance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_balance.ForeColor = System.Drawing.Color.FromArgb(56, 56, 56);
            lb_balance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lb_balance.Location = new System.Drawing.Point(13, 144);
            lb_balance.Name = "lb_balance";
            lb_balance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lb_balance.Size = new System.Drawing.Size(83, 24);
            lb_balance.TabIndex = 11;
            lb_balance.Text = "uiLabel1";
            lb_balance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_deposit
            // 
            lb_deposit.AutoSize = true;
            lb_deposit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_deposit.ForeColor = System.Drawing.Color.FromArgb(56, 56, 56);
            lb_deposit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lb_deposit.Location = new System.Drawing.Point(13, 110);
            lb_deposit.Name = "lb_deposit";
            lb_deposit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lb_deposit.Size = new System.Drawing.Size(83, 24);
            lb_deposit.TabIndex = 10;
            lb_deposit.Text = "uiLabel1";
            lb_deposit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_total_prize
            // 
            lb_total_term.AutoSize = true;
            lb_total_term.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_total_term.ForeColor = System.Drawing.Color.FromArgb(56, 56, 56);
            lb_total_term.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lb_total_term.Location = new System.Drawing.Point(13, 76);
            lb_total_term.Name = "lb_total_prize";
            lb_total_term.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lb_total_term.Size = new System.Drawing.Size(83, 24);
            lb_total_term.TabIndex = 9;
            lb_total_term.Text = "uiLabel1";
            lb_total_term.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lb_total_term.Click += lb_master_balance_Click;
            lb_total_term.DoubleClick += BankerInfo_DoubleClick;
            // 
            // lb_total_bet
            // 
            lb_total_bet.AutoSize = true;
            lb_total_bet.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_total_bet.ForeColor = System.Drawing.Color.FromArgb(56, 56, 56);
            lb_total_bet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lb_total_bet.Location = new System.Drawing.Point(13, 42);
            lb_total_bet.Name = "lb_total_bet";
            lb_total_bet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lb_total_bet.Size = new System.Drawing.Size(83, 24);
            lb_total_bet.TabIndex = 8;
            lb_total_bet.Text = "uiLabel1";
            lb_total_bet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lb_total_bet.Click += lb_master_balance_Click;
            lb_total_bet.DoubleClick += BankerInfo_DoubleClick;
            // 
            // PortBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(uiGroupBox1);
            Name = "PortBox";
            Size = new System.Drawing.Size(289, 186);
            Click += lb_master_balance_Click;
            uiGroupBox1.ResumeLayout(false);
            uiGroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel lb_total_bet;
        private Sunny.UI.UILabel lb_total_term;
        private Sunny.UI.UILabel lb_balance;
        private Sunny.UI.UILabel lb_deposit;
    }
}
