using Sunny.UI;
namespace OX.Tablet
{
    partial class RegMinerForm
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
            tb_balance = new UITextBox();
            lb_assetName_balance = new UILabel();
            tb_amount = new UITextBox();
            lb_amount = new UILabel();
            lb_address = new UILabel();
            cb_contacts = new UIComboBox();
            lb_badge_address = new UILabel();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 283);
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
            // 
            // tb_balance
            // 
            tb_balance.Cursor = Cursors.IBeam;
            tb_balance.EnterAsTab = true;
            tb_balance.Font = new Font("微软雅黑", 12F);
            tb_balance.Location = new Point(642, 74);
            tb_balance.Margin = new Padding(4, 5, 4, 5);
            tb_balance.MinimumSize = new Size(1, 16);
            tb_balance.Name = "tb_balance";
            tb_balance.Padding = new Padding(5);
            tb_balance.ReadOnly = true;
            tb_balance.ShowText = false;
            tb_balance.Size = new Size(284, 43);
            tb_balance.TabIndex = 0;
            tb_balance.TextAlignment = ContentAlignment.MiddleLeft;
            tb_balance.Watermark = "";
            // 
            // lb_assetName_balance
            // 
            lb_assetName_balance.AutoSize = true;
            lb_assetName_balance.Font = new Font("微软雅黑", 12F);
            lb_assetName_balance.ForeColor = Color.FromArgb(48, 48, 48);
            lb_assetName_balance.Location = new Point(489, 79);
            lb_assetName_balance.Name = "lb_assetName_balance";
            lb_assetName_balance.Size = new Size(62, 31);
            lb_assetName_balance.TabIndex = 4;
            lb_assetName_balance.Text = "姓名";
            lb_assetName_balance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_amount
            // 
            tb_amount.Cursor = Cursors.IBeam;
            tb_amount.DoubleValue = 100D;
            tb_amount.Font = new Font("微软雅黑", 12F);
            tb_amount.IntValue = 100;
            tb_amount.Location = new Point(194, 74);
            tb_amount.Margin = new Padding(4, 5, 4, 5);
            tb_amount.Maximum = 100000000D;
            tb_amount.Minimum = 0D;
            tb_amount.MinimumSize = new Size(1, 16);
            tb_amount.Name = "tb_amount";
            tb_amount.Padding = new Padding(5);
            tb_amount.ReadOnly = true;
            tb_amount.ShowText = false;
            tb_amount.Size = new Size(284, 40);
            tb_amount.TabIndex = 6;
            tb_amount.Text = "100";
            tb_amount.TextAlignment = ContentAlignment.MiddleLeft;
            tb_amount.Type = UITextBox.UIEditType.Integer;
            tb_amount.Watermark = "";
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Font = new Font("微软雅黑", 12F);
            lb_amount.ForeColor = Color.FromArgb(48, 48, 48);
            lb_amount.Location = new Point(42, 81);
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
            lb_address.Location = new Point(42, 158);
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
            cb_contacts.Location = new Point(194, 153);
            cb_contacts.Margin = new Padding(4, 5, 4, 5);
            cb_contacts.MinimumSize = new Size(63, 0);
            cb_contacts.Name = "cb_contacts";
            cb_contacts.Padding = new Padding(0, 0, 30, 2);
            cb_contacts.Size = new Size(735, 44);
            cb_contacts.SymbolSize = 24;
            cb_contacts.TabIndex = 17;
            cb_contacts.TextAlignment = ContentAlignment.MiddleLeft;
            cb_contacts.Watermark = "";
            cb_contacts.TextChanged += cb_contacts_TextChanged;
            // 
            // lb_badge_address
            // 
            lb_badge_address.AutoSize = true;
            lb_badge_address.Font = new Font("微软雅黑", 12F);
            lb_badge_address.ForeColor = Color.FromArgb(48, 48, 48);
            lb_badge_address.Location = new Point(194, 225);
            lb_badge_address.Name = "lb_badge_address";
            lb_badge_address.Size = new Size(62, 31);
            lb_badge_address.TabIndex = 18;
            lb_badge_address.Text = "住址";
            lb_badge_address.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RegMinerForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(958, 374);
            Controls.Add(lb_badge_address);
            Controls.Add(cb_contacts);
            Controls.Add(lb_address);
            Controls.Add(tb_amount);
            Controls.Add(lb_amount);
            Controls.Add(tb_balance);
            Controls.Add(lb_assetName_balance);
            Name = "RegMinerForm";
            Text = "UIEditFrom";
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(lb_assetName_balance, 0);
            Controls.SetChildIndex(tb_balance, 0);
            Controls.SetChildIndex(lb_amount, 0);
            Controls.SetChildIndex(tb_amount, 0);
            Controls.SetChildIndex(lb_address, 0);
            Controls.SetChildIndex(cb_contacts, 0);
            Controls.SetChildIndex(lb_badge_address, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private UITextBox tb_balance;
        private UILabel lb_assetName_balance;
        private UILabel uiLabel3;
        private UIRadioButton rbMale;
        private UIRadioButton rbFemale;
        private UITextBox edtAge;
        private UILabel uiLabel4;
        private UIComboBox cbDepartment;
        private UILabel uiLabel5;
        private UILabel uiLabel6;
        private UIDatePicker edtDate;
        private UITextBox tb_amount;
        private UILabel lb_amount;
        private UILabel lb_address;
        private UIComboBox cb_contacts;
        private UILabel lb_badge_address;
    }
}