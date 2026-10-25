using Sunny.UI;
namespace OX.Tablet
{
    partial class MasterSeniorTransferForm
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
            lb_amount = new UILabel();
            lb_ox_address = new UILabel();
            cb_ox_targetAddress = new UIComboBox();
            uiTabControl1 = new UITabControl();
            tb_ox_transfer = new TabPage();
            tb_lock_transfer = new TabPage();
            tb_lock_index = new UINumPadTextBox();
            dp_lock_time = new UIDatetimePicker();
            st_timelock = new UISwitch();
            lb_lock_expire = new UILabel();
            st_self = new UISwitch();
            tb_lock_pubkey = new UITextBox();
            lb_lock_pubkey = new UILabel();
            tb_eth_transfer = new TabPage();
            st_self_exchange = new UISwitch();
            tb_eth_lockindex = new UINumPadTextBox();
            lb_eth_lockindex = new UILabel();
            cb_eth_address = new UIComboBox();
            lb_eth_address = new UILabel();
            tb_amount = new UINumPadTextBox();
            uiTrackBar1 = new UITrackBar();
            uiRuler1 = new UIRuler();
            pnlBtm.SuspendLayout();
            uiTabControl1.SuspendLayout();
            tb_ox_transfer.SuspendLayout();
            tb_lock_transfer.SuspendLayout();
            tb_eth_transfer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 613);
            pnlBtm.Size = new Size(956, 83);
            pnlBtm.TabIndex = 7;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(828, 12);
            btnCancel.Size = new Size(100, 59);
            // 
            // btnOK
            // 
            btnOK.Location = new Point(713, 12);
            btnOK.Size = new Size(100, 59);
            // 
            // tb_balance
            // 
            tb_balance.Cursor = Cursors.IBeam;
            tb_balance.EnterAsTab = true;
            tb_balance.Font = new Font("微软雅黑", 12F);
            tb_balance.Location = new Point(673, 58);
            tb_balance.Margin = new Padding(4, 5, 4, 5);
            tb_balance.MinimumSize = new Size(1, 16);
            tb_balance.Name = "tb_balance";
            tb_balance.Padding = new Padding(5);
            tb_balance.ReadOnly = true;
            tb_balance.ShowText = false;
            tb_balance.Size = new Size(256, 43);
            tb_balance.TabIndex = 0;
            tb_balance.TextAlignment = ContentAlignment.MiddleLeft;
            tb_balance.Watermark = "";
            // 
            // lb_assetName_balance
            // 
            lb_assetName_balance.AutoSize = true;
            lb_assetName_balance.Font = new Font("微软雅黑", 12F);
            lb_assetName_balance.ForeColor = Color.FromArgb(48, 48, 48);
            lb_assetName_balance.Location = new Point(521, 62);
            lb_assetName_balance.Name = "lb_assetName_balance";
            lb_assetName_balance.Size = new Size(62, 31);
            lb_assetName_balance.TabIndex = 4;
            lb_assetName_balance.Text = "姓名";
            lb_assetName_balance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Font = new Font("微软雅黑", 12F);
            lb_amount.ForeColor = Color.FromArgb(48, 48, 48);
            lb_amount.Location = new Point(42, 63);
            lb_amount.Name = "lb_amount";
            lb_amount.Size = new Size(62, 31);
            lb_amount.TabIndex = 15;
            lb_amount.Text = "住址";
            lb_amount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_ox_address
            // 
            lb_ox_address.AutoSize = true;
            lb_ox_address.Font = new Font("微软雅黑", 12F);
            lb_ox_address.ForeColor = Color.FromArgb(48, 48, 48);
            lb_ox_address.Location = new Point(17, 53);
            lb_ox_address.Name = "lb_ox_address";
            lb_ox_address.Size = new Size(62, 31);
            lb_ox_address.TabIndex = 16;
            lb_ox_address.Text = "住址";
            lb_ox_address.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_ox_targetAddress
            // 
            cb_ox_targetAddress.DataSource = null;
            cb_ox_targetAddress.FillColor = Color.White;
            cb_ox_targetAddress.Font = new Font("微软雅黑", 12F);
            cb_ox_targetAddress.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cb_ox_targetAddress.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cb_ox_targetAddress.Location = new Point(169, 48);
            cb_ox_targetAddress.Margin = new Padding(4, 5, 4, 5);
            cb_ox_targetAddress.MinimumSize = new Size(63, 0);
            cb_ox_targetAddress.Name = "cb_ox_targetAddress";
            cb_ox_targetAddress.Padding = new Padding(0, 0, 30, 2);
            cb_ox_targetAddress.Size = new Size(735, 44);
            cb_ox_targetAddress.SymbolSize = 24;
            cb_ox_targetAddress.TabIndex = 17;
            cb_ox_targetAddress.TextAlignment = ContentAlignment.MiddleLeft;
            cb_ox_targetAddress.Watermark = "";
            // 
            // uiTabControl1
            // 
            uiTabControl1.Controls.Add(tb_ox_transfer);
            uiTabControl1.Controls.Add(tb_lock_transfer);
            uiTabControl1.Controls.Add(tb_eth_transfer);
            uiTabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            uiTabControl1.Font = new Font("宋体", 12F);
            uiTabControl1.ItemSize = new Size(250, 40);
            uiTabControl1.Location = new Point(1, 232);
            uiTabControl1.MainPage = "";
            uiTabControl1.Name = "uiTabControl1";
            uiTabControl1.SelectedIndex = 0;
            uiTabControl1.Size = new Size(956, 373);
            uiTabControl1.SizeMode = TabSizeMode.Fixed;
            uiTabControl1.TabIndex = 18;
            uiTabControl1.TabUnSelectedForeColor = Color.FromArgb(240, 240, 240);
            uiTabControl1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTabControl1.SelectedIndexChanged += uiTabControl1_SelectedIndexChanged;
            // 
            // tb_ox_transfer
            // 
            tb_ox_transfer.Controls.Add(cb_ox_targetAddress);
            tb_ox_transfer.Controls.Add(lb_ox_address);
            tb_ox_transfer.Location = new Point(0, 40);
            tb_ox_transfer.Name = "tb_ox_transfer";
            tb_ox_transfer.Size = new Size(956, 333);
            tb_ox_transfer.TabIndex = 0;
            tb_ox_transfer.Text = "tabPage1";
            tb_ox_transfer.UseVisualStyleBackColor = true;
            // 
            // tb_lock_transfer
            // 
            tb_lock_transfer.Controls.Add(tb_lock_index);
            tb_lock_transfer.Controls.Add(dp_lock_time);
            tb_lock_transfer.Controls.Add(st_timelock);
            tb_lock_transfer.Controls.Add(lb_lock_expire);
            tb_lock_transfer.Controls.Add(st_self);
            tb_lock_transfer.Controls.Add(tb_lock_pubkey);
            tb_lock_transfer.Controls.Add(lb_lock_pubkey);
            tb_lock_transfer.Location = new Point(0, 40);
            tb_lock_transfer.Name = "tb_lock_transfer";
            tb_lock_transfer.Size = new Size(200, 60);
            tb_lock_transfer.TabIndex = 1;
            tb_lock_transfer.Text = "tabPage2";
            tb_lock_transfer.UseVisualStyleBackColor = true;
            // 
            // tb_lock_index
            // 
            tb_lock_index.FillColor = Color.White;
            tb_lock_index.Font = new Font("宋体", 12F);
            tb_lock_index.Location = new Point(184, 226);
            tb_lock_index.Margin = new Padding(4, 5, 4, 5);
            tb_lock_index.Maximum = 100000000D;
            tb_lock_index.Minimum = 10D;
            tb_lock_index.MinimumSize = new Size(63, 0);
            tb_lock_index.Name = "tb_lock_index";
            tb_lock_index.NumPadType = NumPadType.Integer;
            tb_lock_index.Padding = new Padding(0, 0, 30, 2);
            tb_lock_index.Size = new Size(256, 44);
            tb_lock_index.SymbolSize = 24;
            tb_lock_index.TabIndex = 39;
            tb_lock_index.Text = "10";
            tb_lock_index.TextAlignment = ContentAlignment.MiddleLeft;
            tb_lock_index.Watermark = "";
            // 
            // dp_lock_time
            // 
            dp_lock_time.DateCultureInfo = new System.Globalization.CultureInfo("zh-CN");
            dp_lock_time.FillColor = Color.White;
            dp_lock_time.Font = new Font("宋体", 12F);
            dp_lock_time.Location = new Point(562, 225);
            dp_lock_time.Margin = new Padding(4, 5, 4, 5);
            dp_lock_time.MaxLength = 19;
            dp_lock_time.MinimumSize = new Size(63, 0);
            dp_lock_time.Name = "dp_lock_time";
            dp_lock_time.Padding = new Padding(0, 0, 30, 2);
            dp_lock_time.Size = new Size(300, 44);
            dp_lock_time.SymbolDropDown = 61555;
            dp_lock_time.SymbolNormal = 61555;
            dp_lock_time.SymbolSize = 24;
            dp_lock_time.TabIndex = 23;
            dp_lock_time.Text = "2024-09-14 09:20:46";
            dp_lock_time.TextAlignment = ContentAlignment.MiddleLeft;
            dp_lock_time.Value = new DateTime(2024, 9, 14, 9, 20, 46, 69);
            dp_lock_time.Watermark = "";
            // 
            // st_timelock
            // 
            st_timelock.Font = new Font("宋体", 12F);
            st_timelock.Location = new Point(410, 147);
            st_timelock.MinimumSize = new Size(1, 1);
            st_timelock.Name = "st_timelock";
            st_timelock.Size = new Size(161, 44);
            st_timelock.SwitchShape = UISwitch.UISwitchShape.Square;
            st_timelock.TabIndex = 22;
            st_timelock.Text = "uiSwitch1";
            st_timelock.ValueChanged += st_timelock_ValueChanged;
            // 
            // lb_lock_expire
            // 
            lb_lock_expire.AutoSize = true;
            lb_lock_expire.Font = new Font("微软雅黑", 12F);
            lb_lock_expire.ForeColor = Color.FromArgb(48, 48, 48);
            lb_lock_expire.Location = new Point(14, 231);
            lb_lock_expire.Name = "lb_lock_expire";
            lb_lock_expire.Size = new Size(62, 31);
            lb_lock_expire.TabIndex = 21;
            lb_lock_expire.Text = "住址";
            lb_lock_expire.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // st_self
            // 
            st_self.Font = new Font("宋体", 12F);
            st_self.Location = new Point(184, 147);
            st_self.MinimumSize = new Size(1, 1);
            st_self.Name = "st_self";
            st_self.Size = new Size(161, 44);
            st_self.SwitchShape = UISwitch.UISwitchShape.Square;
            st_self.TabIndex = 19;
            st_self.Text = "uiSwitch1";
            st_self.ValueChanged += st_self_ValueChanged;
            // 
            // tb_lock_pubkey
            // 
            tb_lock_pubkey.Cursor = Cursors.IBeam;
            tb_lock_pubkey.Font = new Font("微软雅黑", 12F);
            tb_lock_pubkey.Location = new Point(184, 29);
            tb_lock_pubkey.Margin = new Padding(4, 5, 4, 5);
            tb_lock_pubkey.MinimumSize = new Size(1, 16);
            tb_lock_pubkey.Multiline = true;
            tb_lock_pubkey.Name = "tb_lock_pubkey";
            tb_lock_pubkey.Padding = new Padding(5);
            tb_lock_pubkey.ShowText = false;
            tb_lock_pubkey.Size = new Size(743, 93);
            tb_lock_pubkey.TabIndex = 16;
            tb_lock_pubkey.TextAlignment = ContentAlignment.MiddleLeft;
            tb_lock_pubkey.Watermark = "";
            // 
            // lb_lock_pubkey
            // 
            lb_lock_pubkey.AutoSize = true;
            lb_lock_pubkey.Font = new Font("微软雅黑", 12F);
            lb_lock_pubkey.ForeColor = Color.FromArgb(48, 48, 48);
            lb_lock_pubkey.Location = new Point(14, 59);
            lb_lock_pubkey.Name = "lb_lock_pubkey";
            lb_lock_pubkey.Size = new Size(62, 31);
            lb_lock_pubkey.TabIndex = 17;
            lb_lock_pubkey.Text = "住址";
            lb_lock_pubkey.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_eth_transfer
            // 
            tb_eth_transfer.Controls.Add(st_self_exchange);
            tb_eth_transfer.Controls.Add(tb_eth_lockindex);
            tb_eth_transfer.Controls.Add(lb_eth_lockindex);
            tb_eth_transfer.Controls.Add(cb_eth_address);
            tb_eth_transfer.Controls.Add(lb_eth_address);
            tb_eth_transfer.Location = new Point(0, 40);
            tb_eth_transfer.Name = "tb_eth_transfer";
            tb_eth_transfer.Size = new Size(956, 333);
            tb_eth_transfer.TabIndex = 2;
            tb_eth_transfer.Text = "tabPage1";
            tb_eth_transfer.UseVisualStyleBackColor = true;
            // 
            // st_self_exchange
            // 
            st_self_exchange.Font = new Font("宋体", 12F);
            st_self_exchange.Location = new Point(181, 145);
            st_self_exchange.MinimumSize = new Size(1, 1);
            st_self_exchange.Name = "st_self_exchange";
            st_self_exchange.Size = new Size(256, 44);
            st_self_exchange.SwitchShape = UISwitch.UISwitchShape.Square;
            st_self_exchange.TabIndex = 41;
            st_self_exchange.Text = "uiSwitch1";
            st_self_exchange.ValueChanged += st_self_exchange_ValueChanged;
            // 
            // tb_eth_lockindex
            // 
            tb_eth_lockindex.FillColor = Color.White;
            tb_eth_lockindex.Font = new Font("宋体", 12F);
            tb_eth_lockindex.Location = new Point(181, 210);
            tb_eth_lockindex.Margin = new Padding(4, 5, 4, 5);
            tb_eth_lockindex.Maximum = 100000000D;
            tb_eth_lockindex.Minimum = 0D;
            tb_eth_lockindex.MinimumSize = new Size(63, 0);
            tb_eth_lockindex.Name = "tb_eth_lockindex";
            tb_eth_lockindex.NumPadType = NumPadType.Integer;
            tb_eth_lockindex.Padding = new Padding(0, 0, 30, 2);
            tb_eth_lockindex.Size = new Size(256, 44);
            tb_eth_lockindex.SymbolSize = 24;
            tb_eth_lockindex.TabIndex = 40;
            tb_eth_lockindex.Text = "0";
            tb_eth_lockindex.TextAlignment = ContentAlignment.MiddleLeft;
            tb_eth_lockindex.Watermark = "";
            // 
            // lb_eth_lockindex
            // 
            lb_eth_lockindex.AutoSize = true;
            lb_eth_lockindex.Font = new Font("微软雅黑", 12F);
            lb_eth_lockindex.ForeColor = Color.FromArgb(48, 48, 48);
            lb_eth_lockindex.Location = new Point(29, 223);
            lb_eth_lockindex.Name = "lb_eth_lockindex";
            lb_eth_lockindex.Size = new Size(62, 31);
            lb_eth_lockindex.TabIndex = 23;
            lb_eth_lockindex.Text = "住址";
            lb_eth_lockindex.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_eth_address
            // 
            cb_eth_address.DataSource = null;
            cb_eth_address.FillColor = Color.White;
            cb_eth_address.Font = new Font("微软雅黑", 12F);
            cb_eth_address.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cb_eth_address.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cb_eth_address.Location = new Point(181, 82);
            cb_eth_address.Margin = new Padding(4, 5, 4, 5);
            cb_eth_address.MinimumSize = new Size(63, 0);
            cb_eth_address.Name = "cb_eth_address";
            cb_eth_address.Padding = new Padding(0, 0, 30, 2);
            cb_eth_address.Size = new Size(735, 44);
            cb_eth_address.SymbolSize = 24;
            cb_eth_address.TabIndex = 19;
            cb_eth_address.TextAlignment = ContentAlignment.MiddleLeft;
            cb_eth_address.Watermark = "";
            // 
            // lb_eth_address
            // 
            lb_eth_address.AutoSize = true;
            lb_eth_address.Font = new Font("微软雅黑", 12F);
            lb_eth_address.ForeColor = Color.FromArgb(48, 48, 48);
            lb_eth_address.Location = new Point(29, 87);
            lb_eth_address.Name = "lb_eth_address";
            lb_eth_address.Size = new Size(62, 31);
            lb_eth_address.TabIndex = 18;
            lb_eth_address.Text = "住址";
            lb_eth_address.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_amount
            // 
            tb_amount.FillColor = Color.White;
            tb_amount.Font = new Font("宋体", 12F);
            tb_amount.Location = new Point(182, 62);
            tb_amount.Margin = new Padding(4, 5, 4, 5);
            tb_amount.Maximum = 100000000D;
            tb_amount.Minimum = 0D;
            tb_amount.MinimumSize = new Size(63, 0);
            tb_amount.Name = "tb_amount";
            tb_amount.NumPadType = NumPadType.Integer;
            tb_amount.Padding = new Padding(0, 0, 30, 2);
            tb_amount.Size = new Size(256, 44);
            tb_amount.SymbolSize = 24;
            tb_amount.TabIndex = 38;
            tb_amount.TextAlignment = ContentAlignment.MiddleLeft;
            tb_amount.Watermark = "";
            // 
            // uiTrackBar1
            // 
            uiTrackBar1.BarSize = 50;
            uiTrackBar1.Font = new Font("宋体", 12F);
            uiTrackBar1.Location = new Point(42, 114);
            uiTrackBar1.MinimumSize = new Size(1, 1);
            uiTrackBar1.Name = "uiTrackBar1";
            uiTrackBar1.Size = new Size(887, 44);
            uiTrackBar1.TabIndex = 41;
            uiTrackBar1.Text = "uiTrackBar1";
            uiTrackBar1.ValueChanged += uiTrackBar1_ValueChanged;
            // 
            // uiRuler1
            // 
            uiRuler1.BackColor = Color.Transparent;
            uiRuler1.Font = new Font("宋体", 12F);
            uiRuler1.Location = new Point(39, 158);
            uiRuler1.MinimumSize = new Size(1, 1);
            uiRuler1.Name = "uiRuler1";
            uiRuler1.Size = new Size(887, 44);
            uiRuler1.TabIndex = 40;
            uiRuler1.Text = "uiRuler1";
            // 
            // MasterSeniorTransferForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(958, 699);
            Controls.Add(uiTrackBar1);
            Controls.Add(uiRuler1);
            Controls.Add(tb_amount);
            Controls.Add(uiTabControl1);
            Controls.Add(lb_amount);
            Controls.Add(tb_balance);
            Controls.Add(lb_assetName_balance);
            Name = "MasterSeniorTransferForm";
            Text = "UIEditFrom";
            Controls.SetChildIndex(lb_assetName_balance, 0);
            Controls.SetChildIndex(tb_balance, 0);
            Controls.SetChildIndex(lb_amount, 0);
            Controls.SetChildIndex(uiTabControl1, 0);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(tb_amount, 0);
            Controls.SetChildIndex(uiRuler1, 0);
            Controls.SetChildIndex(uiTrackBar1, 0);
            pnlBtm.ResumeLayout(false);
            uiTabControl1.ResumeLayout(false);
            tb_ox_transfer.ResumeLayout(false);
            tb_ox_transfer.PerformLayout();
            tb_lock_transfer.ResumeLayout(false);
            tb_lock_transfer.PerformLayout();
            tb_eth_transfer.ResumeLayout(false);
            tb_eth_transfer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private UITextBox tb_balance;
        private UILabel lb_assetName_balance;
        private UIRadioButton rbMale;
        private UIRadioButton rbFemale;
        private UITextBox edtAge;
        private UILabel lb_eth_lockindex;
        private UIComboBox cbDepartment;
        private UILabel uiLabel5;
        private UILabel uiLabel6;
        private UIDatePicker edtDate;
        private UILabel lb_amount;
        private UILabel lb_ox_address;
        private UIComboBox cb_ox_targetAddress;
        private UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tb_ox_transfer;
        private System.Windows.Forms.TabPage tb_lock_transfer;
        private System.Windows.Forms.TabPage tb_eth_transfer;
        private UITextBox tb_lock_pubkey;
        private UILabel lb_lock_pubkey;
        private UISwitch st_self;
        private UILabel lb_lock_expire;
        private UIDatetimePicker dp_lock_time;
        private UISwitch st_timelock;
        private UIComboBox cb_eth_address;
        private UILabel lb_eth_address;
        private UINumPadTextBox tb_lock_index;
        private UINumPadTextBox tb_eth_lockindex;
        private UINumPadTextBox tb_amount;
        private UITrackBar uiTrackBar1;
        private UIRuler uiRuler1;
        private UISwitch st_self_exchange;
    }
}