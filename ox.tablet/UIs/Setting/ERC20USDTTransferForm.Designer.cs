using Sunny.UI;
namespace OX.Tablet.UIs.Setting
{
    partial class ERC20USDTTransferForm
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
            tb_usdt_balance = new UITextBox();
            lb_usdt_balance = new UILabel();
            lb_amount = new UILabel();
            lb_address = new UILabel();
            cb_contacts = new UIComboBox();
            tb_amount = new UINumPadTextBox();
            tb_ether_balance = new UITextBox();
            lb_ether_balance = new UILabel();
            bt_query_balance = new UIButton();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 325);
            pnlBtm.Size = new Size(956, 88);
            pnlBtm.TabIndex = 7;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(828, 12);
            btnCancel.Size = new Size(100, 60);
            // 
            // btnOK
            // 
            btnOK.Location = new Point(713, 12);
            btnOK.Size = new Size(100, 60);
            btnOK.Click += btnOK_Click;
            // 
            // tb_usdt_balance
            // 
            tb_usdt_balance.Cursor = Cursors.IBeam;
            tb_usdt_balance.EnterAsTab = true;
            tb_usdt_balance.Font = new Font("微软雅黑", 12F);
            tb_usdt_balance.Location = new Point(194, 198);
            tb_usdt_balance.Margin = new Padding(4, 5, 4, 5);
            tb_usdt_balance.MinimumSize = new Size(1, 16);
            tb_usdt_balance.Name = "tb_usdt_balance";
            tb_usdt_balance.Padding = new Padding(5);
            tb_usdt_balance.ReadOnly = true;
            tb_usdt_balance.ShowText = false;
            tb_usdt_balance.Size = new Size(256, 43);
            tb_usdt_balance.TabIndex = 0;
            tb_usdt_balance.TextAlignment = ContentAlignment.MiddleLeft;
            tb_usdt_balance.Watermark = "";
            // 
            // lb_usdt_balance
            // 
            lb_usdt_balance.AutoSize = true;
            lb_usdt_balance.Font = new Font("微软雅黑", 12F);
            lb_usdt_balance.ForeColor = Color.FromArgb(48, 48, 48);
            lb_usdt_balance.Location = new Point(42, 198);
            lb_usdt_balance.Name = "lb_usdt_balance";
            lb_usdt_balance.Size = new Size(62, 31);
            lb_usdt_balance.TabIndex = 4;
            lb_usdt_balance.Text = "姓名";
            lb_usdt_balance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Font = new Font("微软雅黑", 12F);
            lb_amount.ForeColor = Color.FromArgb(48, 48, 48);
            lb_amount.Location = new Point(42, 136);
            lb_amount.Name = "lb_amount";
            lb_amount.Size = new Size(62, 31);
            lb_amount.TabIndex = 15;
            lb_amount.Text = "住址";
            lb_amount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_address
            // 
            lb_address.AutoSize = true;
            lb_address.Font = new Font("微软雅黑", 12F);
            lb_address.ForeColor = Color.FromArgb(48, 48, 48);
            lb_address.Location = new Point(42, 63);
            lb_address.Name = "lb_address";
            lb_address.Size = new Size(62, 31);
            lb_address.TabIndex = 16;
            lb_address.Text = "住址";
            lb_address.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_contacts
            // 
            cb_contacts.DataSource = null;
            cb_contacts.FillColor = Color.White;
            cb_contacts.Font = new Font("微软雅黑", 12F);
            cb_contacts.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cb_contacts.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cb_contacts.Location = new Point(194, 58);
            cb_contacts.Margin = new Padding(4, 5, 4, 5);
            cb_contacts.MinimumSize = new Size(63, 0);
            cb_contacts.Name = "cb_contacts";
            cb_contacts.Padding = new Padding(0, 0, 30, 2);
            cb_contacts.Size = new Size(735, 44);
            cb_contacts.SymbolSize = 24;
            cb_contacts.TabIndex = 17;
            cb_contacts.TextAlignment = ContentAlignment.MiddleLeft;
            cb_contacts.Watermark = "";
            // 
            // tb_amount
            // 
            tb_amount.FillColor = Color.White;
            tb_amount.Font = new Font("宋体", 12F);
            tb_amount.Location = new Point(194, 128);
            tb_amount.Margin = new Padding(4, 5, 4, 5);
            tb_amount.Maximum = 100000000D;
            tb_amount.Minimum = 0D;
            tb_amount.MinimumSize = new Size(63, 0);
            tb_amount.Name = "tb_amount";
            tb_amount.NumPadType = NumPadType.Double;
            tb_amount.Padding = new Padding(0, 0, 30, 2);
            tb_amount.Size = new Size(256, 44);
            tb_amount.SymbolSize = 24;
            tb_amount.TabIndex = 39;
            tb_amount.TextAlignment = ContentAlignment.MiddleLeft;
            tb_amount.Watermark = "";
            // 
            // tb_ether_balance
            // 
            tb_ether_balance.Cursor = Cursors.IBeam;
            tb_ether_balance.EnterAsTab = true;
            tb_ether_balance.Font = new Font("微软雅黑", 12F);
            tb_ether_balance.Location = new Point(194, 272);
            tb_ether_balance.Margin = new Padding(4, 5, 4, 5);
            tb_ether_balance.MinimumSize = new Size(1, 16);
            tb_ether_balance.Name = "tb_ether_balance";
            tb_ether_balance.Padding = new Padding(5);
            tb_ether_balance.ReadOnly = true;
            tb_ether_balance.ShowText = false;
            tb_ether_balance.Size = new Size(256, 43);
            tb_ether_balance.TabIndex = 40;
            tb_ether_balance.TextAlignment = ContentAlignment.MiddleLeft;
            tb_ether_balance.Watermark = "";
            // 
            // lb_ether_balance
            // 
            lb_ether_balance.AutoSize = true;
            lb_ether_balance.Font = new Font("微软雅黑", 12F);
            lb_ether_balance.ForeColor = Color.FromArgb(48, 48, 48);
            lb_ether_balance.Location = new Point(42, 272);
            lb_ether_balance.Name = "lb_ether_balance";
            lb_ether_balance.Size = new Size(62, 31);
            lb_ether_balance.TabIndex = 41;
            lb_ether_balance.Text = "姓名";
            lb_ether_balance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bt_query_balance
            // 
            bt_query_balance.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_query_balance.Location = new Point(488, 227);
            bt_query_balance.MinimumSize = new Size(1, 1);
            bt_query_balance.Name = "bt_query_balance";
            bt_query_balance.Size = new Size(150, 52);
            bt_query_balance.TabIndex = 42;
            bt_query_balance.Text = "uiButton1";
            bt_query_balance.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_query_balance.Click += bt_query_balance_Click;
            // 
            // ERC20USDTTransferForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(958, 416);
            Controls.Add(bt_query_balance);
            Controls.Add(tb_ether_balance);
            Controls.Add(lb_ether_balance);
            Controls.Add(tb_amount);
            Controls.Add(cb_contacts);
            Controls.Add(lb_address);
            Controls.Add(lb_amount);
            Controls.Add(tb_usdt_balance);
            Controls.Add(lb_usdt_balance);
            Name = "ERC20USDTTransferForm";
            Text = "UIEditFrom";
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(lb_usdt_balance, 0);
            Controls.SetChildIndex(tb_usdt_balance, 0);
            Controls.SetChildIndex(lb_amount, 0);
            Controls.SetChildIndex(lb_address, 0);
            Controls.SetChildIndex(cb_contacts, 0);
            Controls.SetChildIndex(tb_amount, 0);
            Controls.SetChildIndex(lb_ether_balance, 0);
            Controls.SetChildIndex(tb_ether_balance, 0);
            Controls.SetChildIndex(bt_query_balance, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private UITextBox tb_usdt_balance;
        private UILabel lb_usdt_balance;
        private UILabel uiLabel3;
        private UIRadioButton rbMale;
        private UIRadioButton rbFemale;
        private UITextBox edtAge;
        private UILabel uiLabel4;
        private UIComboBox cbDepartment;
        private UILabel uiLabel5;
        private UILabel uiLabel6;
        private UIDatePicker edtDate;
        private UILabel lb_amount;
        private UILabel lb_address;
        private UIComboBox cb_contacts;
        private UINumPadTextBox tb_amount;
        private UITextBox tb_ether_balance;
        private UILabel lb_ether_balance;
        private UIButton bt_query_balance;
    }
}