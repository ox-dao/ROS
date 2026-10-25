namespace OX.Tablet.UIs.MarkSix
{
    partial class OutGoldPage
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
            lb_amount = new Sunny.UI.UILabel();
            tb_balance = new Sunny.UI.UITextBox();
            lb_usdt_balance = new Sunny.UI.UILabel();
            rbg_ratio_out = new Sunny.UI.UIRadioButtonGroup();
            st_state = new Sunny.UI.UISwitch();
            btn_do_sale = new Sunny.UI.UIButton();
            lb_pool_address = new Sunny.UI.UILabel();
            lb_pool_balance = new Sunny.UI.UILabel();
            tb_amount = new Sunny.UI.UINumPadTextBox();
            uiTrackBar1 = new Sunny.UI.UITrackBar();
            uiRuler1 = new Sunny.UI.UIRuler();
            rbg_ratio_in = new Sunny.UI.UIRadioButtonGroup();
            st_autoDeposit = new Sunny.UI.UISwitch();
            L1 = new Sunny.UI.UILine();
            L2 = new Sunny.UI.UILine();
            tb_max_deposit_amt = new Sunny.UI.UINumPadTextBox();
            lb_max_deposit_amt = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Font = new Font("微软雅黑", 12F);
            lb_amount.ForeColor = Color.FromArgb(48, 48, 48);
            lb_amount.Location = new Point(49, 153);
            lb_amount.Name = "lb_amount";
            lb_amount.Size = new Size(62, 31);
            lb_amount.TabIndex = 19;
            lb_amount.Text = "住址";
            lb_amount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_balance
            // 
            tb_balance.Cursor = Cursors.IBeam;
            tb_balance.EnterAsTab = true;
            tb_balance.Font = new Font("微软雅黑", 12F);
            tb_balance.Location = new Point(841, 147);
            tb_balance.Margin = new Padding(4, 5, 4, 5);
            tb_balance.MinimumSize = new Size(1, 16);
            tb_balance.Name = "tb_balance";
            tb_balance.Padding = new Padding(5);
            tb_balance.ReadOnly = true;
            tb_balance.ShowText = false;
            tb_balance.Size = new Size(256, 43);
            tb_balance.TabIndex = 16;
            tb_balance.TextAlignment = ContentAlignment.MiddleLeft;
            tb_balance.Watermark = "";
            // 
            // lb_usdt_balance
            // 
            lb_usdt_balance.AutoSize = true;
            lb_usdt_balance.Font = new Font("微软雅黑", 12F);
            lb_usdt_balance.ForeColor = Color.FromArgb(48, 48, 48);
            lb_usdt_balance.Location = new Point(609, 151);
            lb_usdt_balance.Name = "lb_usdt_balance";
            lb_usdt_balance.Size = new Size(62, 31);
            lb_usdt_balance.TabIndex = 17;
            lb_usdt_balance.Text = "姓名";
            lb_usdt_balance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rbg_ratio_out
            // 
            rbg_ratio_out.ColumnCount = 5;
            rbg_ratio_out.ColumnInterval = 50;
            rbg_ratio_out.Font = new Font("宋体", 12F);
            rbg_ratio_out.Items.AddRange(new object[] { "0", "1%", "2%", "3%", "4%", "5%", "6%", "7%", "8%", "9%", "10%", "11%", "12%", "13%", "14%" });
            rbg_ratio_out.ItemSize = new Size(150, 30);
            rbg_ratio_out.Location = new Point(52, 313);
            rbg_ratio_out.Margin = new Padding(4, 5, 4, 5);
            rbg_ratio_out.MinimumSize = new Size(1, 1);
            rbg_ratio_out.Name = "rbg_ratio_out";
            rbg_ratio_out.Padding = new Padding(0, 32, 0, 0);
            rbg_ratio_out.RowInterval = 30;
            rbg_ratio_out.Size = new Size(1045, 190);
            rbg_ratio_out.TabIndex = 20;
            rbg_ratio_out.Text = "uiRadioButtonGroup1";
            rbg_ratio_out.TextAlignment = ContentAlignment.MiddleLeft;
            rbg_ratio_out.ValueChanged += rbg_ratio_ratio_ValueChanged;
            // 
            // st_state
            // 
            st_state.Font = new Font("宋体", 12F);
            st_state.Location = new Point(52, 518);
            st_state.MinimumSize = new Size(1, 1);
            st_state.Name = "st_state";
            st_state.Size = new Size(161, 44);
            st_state.SwitchShape = Sunny.UI.UISwitch.UISwitchShape.Square;
            st_state.TabIndex = 23;
            st_state.Text = "uiSwitch1";
            // 
            // btn_do_sale
            // 
            btn_do_sale.Font = new Font("宋体", 12F);
            btn_do_sale.Location = new Point(282, 513);
            btn_do_sale.MinimumSize = new Size(1, 1);
            btn_do_sale.Name = "btn_do_sale";
            btn_do_sale.Size = new Size(266, 52);
            btn_do_sale.TabIndex = 24;
            btn_do_sale.Text = "uiButton1";
            btn_do_sale.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_do_sale.Click += btn_do_sale_Click;
            // 
            // lb_pool_address
            // 
            lb_pool_address.AutoSize = true;
            lb_pool_address.Font = new Font("微软雅黑", 12F);
            lb_pool_address.ForeColor = Color.FromArgb(48, 48, 48);
            lb_pool_address.Location = new Point(52, 14);
            lb_pool_address.Name = "lb_pool_address";
            lb_pool_address.Size = new Size(62, 31);
            lb_pool_address.TabIndex = 25;
            lb_pool_address.Text = "住址";
            lb_pool_address.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_pool_balance
            // 
            lb_pool_balance.AutoSize = true;
            lb_pool_balance.Font = new Font("微软雅黑", 12F);
            lb_pool_balance.ForeColor = Color.FromArgb(48, 48, 48);
            lb_pool_balance.Location = new Point(52, 59);
            lb_pool_balance.Name = "lb_pool_balance";
            lb_pool_balance.Size = new Size(62, 31);
            lb_pool_balance.TabIndex = 26;
            lb_pool_balance.Text = "住址";
            lb_pool_balance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_amount
            // 
            tb_amount.FillColor = Color.White;
            tb_amount.Font = new Font("宋体", 12F);
            tb_amount.Location = new Point(272, 146);
            tb_amount.Margin = new Padding(4, 5, 4, 5);
            tb_amount.Maximum = 10000000D;
            tb_amount.Minimum = 1D;
            tb_amount.MinimumSize = new Size(63, 0);
            tb_amount.Name = "tb_amount";
            tb_amount.NumPadType = Sunny.UI.NumPadType.Integer;
            tb_amount.Padding = new Padding(0, 0, 30, 2);
            tb_amount.Size = new Size(276, 44);
            tb_amount.SymbolSize = 24;
            tb_amount.TabIndex = 28;
            tb_amount.Text = "100";
            tb_amount.TextAlignment = ContentAlignment.MiddleLeft;
            tb_amount.Watermark = "";
            // 
            // uiTrackBar1
            // 
            uiTrackBar1.BarSize = 50;
            uiTrackBar1.Font = new Font("宋体", 12F);
            uiTrackBar1.Location = new Point(52, 198);
            uiTrackBar1.MinimumSize = new Size(1, 1);
            uiTrackBar1.Name = "uiTrackBar1";
            uiTrackBar1.Size = new Size(1045, 44);
            uiTrackBar1.TabIndex = 31;
            uiTrackBar1.Text = "uiTrackBar1";
            uiTrackBar1.ValueChanged += uiTrackBar1_ValueChanged;
            // 
            // uiRuler1
            // 
            uiRuler1.BackColor = Color.Transparent;
            uiRuler1.Font = new Font("宋体", 12F);
            uiRuler1.Location = new Point(49, 242);
            uiRuler1.MinimumSize = new Size(1, 1);
            uiRuler1.Name = "uiRuler1";
            uiRuler1.Size = new Size(1045, 44);
            uiRuler1.TabIndex = 30;
            uiRuler1.Text = "uiRuler1";
            // 
            // rbg_ratio_in
            // 
            rbg_ratio_in.ColumnCount = 5;
            rbg_ratio_in.ColumnInterval = 50;
            rbg_ratio_in.Font = new Font("宋体", 12F);
            rbg_ratio_in.Items.AddRange(new object[] { "0", "1%", "2%", "3%", "4%", "5%", "6%", "7%", "8%", "9%" });
            rbg_ratio_in.ItemSize = new Size(150, 30);
            rbg_ratio_in.Location = new Point(49, 620);
            rbg_ratio_in.Margin = new Padding(4, 5, 4, 5);
            rbg_ratio_in.MinimumSize = new Size(1, 1);
            rbg_ratio_in.Name = "rbg_ratio_in";
            rbg_ratio_in.Padding = new Padding(0, 32, 0, 0);
            rbg_ratio_in.RowInterval = 30;
            rbg_ratio_in.Size = new Size(1045, 123);
            rbg_ratio_in.TabIndex = 32;
            rbg_ratio_in.Text = "uiRadioButtonGroup1";
            rbg_ratio_in.TextAlignment = ContentAlignment.MiddleLeft;
            rbg_ratio_in.ValueChanged += rbg_ratio_in_ValueChanged;
            // 
            // st_autoDeposit
            // 
            st_autoDeposit.Font = new Font("宋体", 12F);
            st_autoDeposit.Location = new Point(49, 815);
            st_autoDeposit.MinimumSize = new Size(1, 1);
            st_autoDeposit.Name = "st_autoDeposit";
            st_autoDeposit.Size = new Size(291, 44);
            st_autoDeposit.SwitchShape = Sunny.UI.UISwitch.UISwitchShape.Square;
            st_autoDeposit.TabIndex = 33;
            st_autoDeposit.Text = "uiSwitch1";
            st_autoDeposit.ValueChanged += st_autoDeposit_ValueChanged;
            // 
            // L1
            // 
            L1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            L1.BackColor = Color.Transparent;
            L1.Font = new Font("宋体", 12F);
            L1.ForeColor = Color.FromArgb(48, 48, 48);
            L1.Location = new Point(52, 101);
            L1.MinimumSize = new Size(1, 1);
            L1.Name = "L1";
            L1.Size = new Size(1315, 26);
            L1.TabIndex = 34;
            L1.Text = "uiLine1";
            // 
            // L2
            // 
            L2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            L2.BackColor = Color.Transparent;
            L2.Font = new Font("宋体", 12F);
            L2.ForeColor = Color.FromArgb(48, 48, 48);
            L2.Location = new Point(49, 586);
            L2.MinimumSize = new Size(1, 1);
            L2.Name = "L2";
            L2.Size = new Size(1315, 26);
            L2.TabIndex = 35;
            L2.Text = "uiLine1";
            // 
            // tb_max_deposit_amt
            // 
            tb_max_deposit_amt.FillColor = Color.White;
            tb_max_deposit_amt.Font = new Font("宋体", 12F);
            tb_max_deposit_amt.Location = new Point(280, 754);
            tb_max_deposit_amt.Margin = new Padding(4, 5, 4, 5);
            tb_max_deposit_amt.Maximum = 10000000D;
            tb_max_deposit_amt.Minimum = 100D;
            tb_max_deposit_amt.MinimumSize = new Size(63, 0);
            tb_max_deposit_amt.Name = "tb_max_deposit_amt";
            tb_max_deposit_amt.NumPadType = Sunny.UI.NumPadType.Integer;
            tb_max_deposit_amt.Padding = new Padding(0, 0, 30, 2);
            tb_max_deposit_amt.Size = new Size(276, 44);
            tb_max_deposit_amt.SymbolSize = 24;
            tb_max_deposit_amt.TabIndex = 37;
            tb_max_deposit_amt.Text = "1000";
            tb_max_deposit_amt.TextAlignment = ContentAlignment.MiddleLeft;
            tb_max_deposit_amt.Watermark = "";
            // 
            // lb_max_deposit_amt
            // 
            lb_max_deposit_amt.AutoSize = true;
            lb_max_deposit_amt.Font = new Font("微软雅黑", 12F);
            lb_max_deposit_amt.ForeColor = Color.FromArgb(48, 48, 48);
            lb_max_deposit_amt.Location = new Point(49, 761);
            lb_max_deposit_amt.Name = "lb_max_deposit_amt";
            lb_max_deposit_amt.Size = new Size(62, 31);
            lb_max_deposit_amt.TabIndex = 36;
            lb_max_deposit_amt.Text = "住址";
            lb_max_deposit_amt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OutGoldPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1445, 971);
            Controls.Add(tb_max_deposit_amt);
            Controls.Add(lb_max_deposit_amt);
            Controls.Add(L2);
            Controls.Add(L1);
            Controls.Add(st_autoDeposit);
            Controls.Add(rbg_ratio_in);
            Controls.Add(uiTrackBar1);
            Controls.Add(uiRuler1);
            Controls.Add(tb_amount);
            Controls.Add(lb_pool_balance);
            Controls.Add(lb_pool_address);
            Controls.Add(btn_do_sale);
            Controls.Add(st_state);
            Controls.Add(rbg_ratio_out);
            Controls.Add(lb_amount);
            Controls.Add(tb_balance);
            Controls.Add(lb_usdt_balance);
            Name = "OutGoldPage";
            Text = "PlazaForm";
            Initialize += OrderHistory_Initialize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UILabel lb_amount;
        private Sunny.UI.UITextBox tb_balance;
        private Sunny.UI.UILabel lb_usdt_balance;
        private Sunny.UI.UIRadioButtonGroup rbg_ratio_out;
        private Sunny.UI.UISwitch st_state;
        private Sunny.UI.UIButton btn_do_sale;
        private Sunny.UI.UILabel lb_pool_address;
        private Sunny.UI.UILabel lb_pool_balance;
        private Sunny.UI.UINumPadTextBox tb_amount;
        private Sunny.UI.UITrackBar uiTrackBar1;
        private Sunny.UI.UIRuler uiRuler1;
        private Sunny.UI.UIRadioButtonGroup rbg_ratio_in;
        private Sunny.UI.UISwitch st_autoDeposit;
        private Sunny.UI.UILine L1;
        private Sunny.UI.UILine L2;
        private Sunny.UI.UINumPadTextBox tb_max_deposit_amt;
        private Sunny.UI.UILabel lb_max_deposit_amt;
    }
}