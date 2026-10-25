namespace OX.Tablet.UIs.Setting
{
    partial class AccountPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lb_master_address = new Sunny.UI.UILabel();
            tb_master_address = new TextBox();
            panel1 = new Sunny.UI.UIPanel();
            bt_query_usdt_balance = new Sunny.UI.UIButton();
            bt_newAccount = new Sunny.UI.UIButton();
            L0 = new Sunny.UI.UILine();
            lb_exchange_address = new Sunny.UI.UILabel();
            lb_master_pubkey = new Sunny.UI.UILabel();
            bt_copy_ethaddress = new Sunny.UI.UIButton();
            bt_copy_masteraddress = new Sunny.UI.UIButton();
            tb_exchange_address = new TextBox();
            bt_delete_account = new Sunny.UI.UIButton();
            tb_master_pubkey = new TextBox();
            bt_backup_prikey = new Sunny.UI.UIButton();
            bt_copy_masterpubkey = new Sunny.UI.UIButton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lb_master_address
            // 
            lb_master_address.AutoSize = true;
            lb_master_address.Font = new Font("宋体", 12F);
            lb_master_address.ForeColor = Color.FromArgb(48, 48, 48);
            lb_master_address.Location = new Point(23, 68);
            lb_master_address.Name = "lb_master_address";
            lb_master_address.Size = new Size(106, 24);
            lb_master_address.TabIndex = 18;
            lb_master_address.Text = "uiLabel1";
            // 
            // tb_master_address
            // 
            tb_master_address.Font = new Font("宋体", 12F);
            tb_master_address.Location = new Point(277, 64);
            tb_master_address.Margin = new Padding(4, 5, 4, 5);
            tb_master_address.MinimumSize = new Size(1, 16);
            tb_master_address.Name = "tb_master_address";
            tb_master_address.ReadOnly = true;
            tb_master_address.Size = new Size(777, 35);
            tb_master_address.TabIndex = 15;
            tb_master_address.Text = "uiTextBox1";
            // 
            // panel1
            // 
            panel1.Controls.Add(bt_query_usdt_balance);
            panel1.Controls.Add(bt_newAccount);
            panel1.Controls.Add(L0);
            panel1.Controls.Add(lb_master_address);
            panel1.Controls.Add(lb_exchange_address);
            panel1.Controls.Add(lb_master_pubkey);
            panel1.Controls.Add(bt_copy_ethaddress);
            panel1.Controls.Add(bt_copy_masteraddress);
            panel1.Controls.Add(tb_exchange_address);
            panel1.Controls.Add(bt_delete_account);
            panel1.Controls.Add(tb_master_pubkey);
            panel1.Controls.Add(tb_master_address);
            panel1.Controls.Add(bt_backup_prikey);
            panel1.Controls.Add(bt_copy_masterpubkey);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("宋体", 12F);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.MinimumSize = new Size(1, 1);
            panel1.Name = "panel1";
            panel1.Radius = 1;
            panel1.Size = new Size(1445, 966);
            panel1.TabIndex = 22;
            panel1.Text = null;
            panel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // bt_query_usdt_balance
            // 
            bt_query_usdt_balance.Font = new Font("微软雅黑", 12F);
            bt_query_usdt_balance.Location = new Point(277, 274);
            bt_query_usdt_balance.MinimumSize = new Size(1, 1);
            bt_query_usdt_balance.Name = "bt_query_usdt_balance";
            bt_query_usdt_balance.Size = new Size(336, 52);
            bt_query_usdt_balance.TabIndex = 41;
            bt_query_usdt_balance.Text = "uiButton1";
            bt_query_usdt_balance.TipsFont = new Font("微软雅黑", 9F);
            bt_query_usdt_balance.Click += bt_query_usdt_balance_Click;
            // 
            // bt_newAccount
            // 
            bt_newAccount.Font = new Font("微软雅黑", 12F);
            bt_newAccount.Location = new Point(346, 521);
            bt_newAccount.MinimumSize = new Size(1, 1);
            bt_newAccount.Name = "bt_newAccount";
            bt_newAccount.Radius = 50;
            bt_newAccount.Size = new Size(196, 52);
            bt_newAccount.TabIndex = 40;
            bt_newAccount.Text = "uiButton1";
            bt_newAccount.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_newAccount.Click += bt_newAccount_Click;
            // 
            // L0
            // 
            L0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            L0.BackColor = Color.Transparent;
            L0.Font = new Font("宋体", 12F);
            L0.ForeColor = Color.FromArgb(48, 48, 48);
            L0.Location = new Point(12, 3);
            L0.MinimumSize = new Size(1, 1);
            L0.Name = "L0";
            L0.Size = new Size(1409, 44);
            L0.TabIndex = 24;
            L0.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_exchange_address
            // 
            lb_exchange_address.AutoSize = true;
            lb_exchange_address.Font = new Font("宋体", 12F);
            lb_exchange_address.ForeColor = Color.FromArgb(48, 48, 48);
            lb_exchange_address.Location = new Point(19, 223);
            lb_exchange_address.Name = "lb_exchange_address";
            lb_exchange_address.Size = new Size(106, 24);
            lb_exchange_address.TabIndex = 20;
            lb_exchange_address.Text = "uiLabel3";
            // 
            // lb_master_pubkey
            // 
            lb_master_pubkey.AutoSize = true;
            lb_master_pubkey.Font = new Font("宋体", 12F);
            lb_master_pubkey.ForeColor = Color.FromArgb(48, 48, 48);
            lb_master_pubkey.Location = new Point(23, 146);
            lb_master_pubkey.Name = "lb_master_pubkey";
            lb_master_pubkey.Size = new Size(106, 24);
            lb_master_pubkey.TabIndex = 19;
            lb_master_pubkey.Text = "uiLabel2";
            // 
            // bt_copy_ethaddress
            // 
            bt_copy_ethaddress.Font = new Font("微软雅黑", 12F);
            bt_copy_ethaddress.Location = new Point(1112, 212);
            bt_copy_ethaddress.MinimumSize = new Size(1, 1);
            bt_copy_ethaddress.Name = "bt_copy_ethaddress";
            bt_copy_ethaddress.Size = new Size(101, 52);
            bt_copy_ethaddress.TabIndex = 6;
            bt_copy_ethaddress.Text = "uiButton1";
            bt_copy_ethaddress.TipsFont = new Font("微软雅黑", 9F);
            bt_copy_ethaddress.Click += bt_copy_ethaddress_Click;
            // 
            // bt_copy_masteraddress
            // 
            bt_copy_masteraddress.Font = new Font("微软雅黑", 12F);
            bt_copy_masteraddress.Location = new Point(1112, 57);
            bt_copy_masteraddress.MinimumSize = new Size(1, 1);
            bt_copy_masteraddress.Name = "bt_copy_masteraddress";
            bt_copy_masteraddress.Size = new Size(101, 52);
            bt_copy_masteraddress.TabIndex = 7;
            bt_copy_masteraddress.Text = "uiButton2";
            bt_copy_masteraddress.TipsFont = new Font("微软雅黑", 9F);
            bt_copy_masteraddress.Click += bt_copy_masteraddress_Click;
            // 
            // tb_exchange_address
            // 
            tb_exchange_address.Font = new Font("宋体", 12F);
            tb_exchange_address.Location = new Point(277, 222);
            tb_exchange_address.Margin = new Padding(4, 5, 4, 5);
            tb_exchange_address.MinimumSize = new Size(1, 16);
            tb_exchange_address.Name = "tb_exchange_address";
            tb_exchange_address.ReadOnly = true;
            tb_exchange_address.Size = new Size(777, 35);
            tb_exchange_address.TabIndex = 17;
            tb_exchange_address.Text = "uiTextBox3";
            // 
            // bt_delete_account
            // 
            bt_delete_account.Font = new Font("微软雅黑", 12F);
            bt_delete_account.Location = new Point(38, 521);
            bt_delete_account.MinimumSize = new Size(1, 1);
            bt_delete_account.Name = "bt_delete_account";
            bt_delete_account.Radius = 50;
            bt_delete_account.Size = new Size(196, 52);
            bt_delete_account.TabIndex = 8;
            bt_delete_account.Text = "uiButton1";
            bt_delete_account.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_delete_account.Click += bt_delete_account_Click;
            // 
            // tb_master_pubkey
            // 
            tb_master_pubkey.Font = new Font("宋体", 12F);
            tb_master_pubkey.Location = new Point(277, 124);
            tb_master_pubkey.Margin = new Padding(4, 5, 4, 5);
            tb_master_pubkey.MinimumSize = new Size(1, 16);
            tb_master_pubkey.Multiline = true;
            tb_master_pubkey.Name = "tb_master_pubkey";
            tb_master_pubkey.ReadOnly = true;
            tb_master_pubkey.Size = new Size(777, 79);
            tb_master_pubkey.TabIndex = 16;
            tb_master_pubkey.Text = "uiTextBox2";
            // 
            // bt_backup_prikey
            // 
            bt_backup_prikey.Font = new Font("微软雅黑", 12F);
            bt_backup_prikey.Location = new Point(639, 521);
            bt_backup_prikey.MinimumSize = new Size(1, 1);
            bt_backup_prikey.Name = "bt_backup_prikey";
            bt_backup_prikey.Radius = 50;
            bt_backup_prikey.Size = new Size(196, 52);
            bt_backup_prikey.TabIndex = 10;
            bt_backup_prikey.Text = "uiButton1";
            bt_backup_prikey.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_backup_prikey.Click += bt_backup_prikey_Click;
            // 
            // bt_copy_masterpubkey
            // 
            bt_copy_masterpubkey.Font = new Font("微软雅黑", 12F);
            bt_copy_masterpubkey.Location = new Point(1112, 134);
            bt_copy_masterpubkey.MinimumSize = new Size(1, 1);
            bt_copy_masterpubkey.Name = "bt_copy_masterpubkey";
            bt_copy_masterpubkey.Size = new Size(101, 52);
            bt_copy_masterpubkey.TabIndex = 14;
            bt_copy_masterpubkey.Text = "uiButton1";
            bt_copy_masterpubkey.TipsFont = new Font("微软雅黑", 9F);
            bt_copy_masterpubkey.Click += bt_copy_masterpubkey_Click;
            // 
            // AccountPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1445, 966);
            Controls.Add(panel1);
            Name = "AccountPage";
            Text = "PlazaForm";
            Initialize += OrderHistory_Initialize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
       
        private Sunny.UI.UILabel lb_master_address;
        private System.Windows.Forms.TextBox tb_master_address;
        private Sunny.UI.UIPanel panel1;
        private Sunny.UI.UILabel lb_exchange_address;
        private Sunny.UI.UILabel lb_master_pubkey;
        private Sunny.UI.UIButton bt_copy_ethaddress;
        private Sunny.UI.UIButton bt_copy_masteraddress;
        private System.Windows.Forms.TextBox tb_exchange_address;
        private Sunny.UI.UIButton bt_delete_account;
        private System.Windows.Forms.TextBox tb_master_pubkey;
        private Sunny.UI.UIButton bt_backup_prikey;
        private Sunny.UI.UIButton bt_copy_masterpubkey;
        private Sunny.UI.UILine L0;
        private Sunny.UI.UIButton bt_newAccount;
        private Sunny.UI.UIButton bt_query_usdt_balance;
    }
}