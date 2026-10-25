namespace OX.Tablet.UIs.MarkSix
{
    partial class USDTCastPage
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
            lb_Details = new Sunny.UI.UIListBox();
            bt_cast_record = new Sunny.UI.UIButton();
            L_cast = new Sunny.UI.UILine();
            bt_destroy_record = new Sunny.UI.UIButton();
            L_destroy = new Sunny.UI.UILine();
            img_cast = new PictureBox();
            bt_do_destroy = new Sunny.UI.UIButton();
            lb_pledge_address = new Sunny.UI.UILabel();
            rtb_msg = new RichTextBox();
            tb_amount = new Sunny.UI.UINumPadTextBox();
            uiTrackBar1 = new Sunny.UI.UITrackBar();
            uiRuler1 = new Sunny.UI.UIRuler();
            bt_copy_eth = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)img_cast).BeginInit();
            SuspendLayout();
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Font = new Font("微软雅黑", 12F);
            lb_amount.ForeColor = Color.FromArgb(48, 48, 48);
            lb_amount.Location = new Point(19, 629);
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
            tb_balance.Location = new Point(260, 558);
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
            lb_usdt_balance.Location = new Point(19, 565);
            lb_usdt_balance.Name = "lb_usdt_balance";
            lb_usdt_balance.Size = new Size(62, 31);
            lb_usdt_balance.TabIndex = 17;
            lb_usdt_balance.Text = "姓名";
            lb_usdt_balance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_Details
            // 
            lb_Details.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lb_Details.Font = new Font("微软雅黑", 12F);
            lb_Details.HoverColor = Color.FromArgb(155, 200, 255);
            lb_Details.ItemSelectForeColor = Color.White;
            lb_Details.Location = new Point(972, 14);
            lb_Details.Margin = new Padding(4, 5, 4, 5);
            lb_Details.MinimumSize = new Size(1, 1);
            lb_Details.Name = "lb_Details";
            lb_Details.Padding = new Padding(2);
            lb_Details.ShowText = false;
            lb_Details.Size = new Size(460, 974);
            lb_Details.TabIndex = 27;
            lb_Details.Text = "uiListBox1";
            // 
            // bt_cast_record
            // 
            bt_cast_record.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_cast_record.Font = new Font("微软雅黑", 12F);
            bt_cast_record.Location = new Point(764, 14);
            bt_cast_record.MinimumSize = new Size(1, 1);
            bt_cast_record.Name = "bt_cast_record";
            bt_cast_record.Size = new Size(196, 52);
            bt_cast_record.TabIndex = 28;
            bt_cast_record.Text = "uiButton1";
            bt_cast_record.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_cast_record.Click += bt_cast_record_Click;
            // 
            // L_cast
            // 
            L_cast.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            L_cast.BackColor = Color.Transparent;
            L_cast.Font = new Font("宋体", 12F);
            L_cast.ForeColor = Color.FromArgb(48, 48, 48);
            L_cast.Location = new Point(12, 30);
            L_cast.MinimumSize = new Size(1, 1);
            L_cast.Name = "L_cast";
            L_cast.Size = new Size(737, 26);
            L_cast.TabIndex = 29;
            L_cast.Text = "uiLine1";
            // 
            // bt_destroy_record
            // 
            bt_destroy_record.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_destroy_record.Font = new Font("微软雅黑", 12F);
            bt_destroy_record.Location = new Point(764, 494);
            bt_destroy_record.MinimumSize = new Size(1, 1);
            bt_destroy_record.Name = "bt_destroy_record";
            bt_destroy_record.Size = new Size(196, 51);
            bt_destroy_record.TabIndex = 30;
            bt_destroy_record.Text = "uiButton1";
            bt_destroy_record.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_destroy_record.Click += bt_destroy_record_Click;
            // 
            // L_destroy
            // 
            L_destroy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            L_destroy.BackColor = Color.Transparent;
            L_destroy.Font = new Font("宋体", 12F);
            L_destroy.ForeColor = Color.FromArgb(48, 48, 48);
            L_destroy.Location = new Point(12, 510);
            L_destroy.MinimumSize = new Size(1, 1);
            L_destroy.Name = "L_destroy";
            L_destroy.Size = new Size(737, 25);
            L_destroy.TabIndex = 31;
            L_destroy.Text = "uiLine1";
            // 
            // img_cast
            // 
            img_cast.ImeMode = ImeMode.NoControl;
            img_cast.Location = new Point(166, 142);
            img_cast.Name = "img_cast";
            img_cast.Size = new Size(350, 350);
            img_cast.SizeMode = PictureBoxSizeMode.StretchImage;
            img_cast.TabIndex = 32;
            img_cast.TabStop = false;
            img_cast.Click += img_cast_Click;
            // 
            // bt_do_destroy
            // 
            bt_do_destroy.Font = new Font("微软雅黑", 12F);
            bt_do_destroy.Location = new Point(553, 583);
            bt_do_destroy.MinimumSize = new Size(1, 1);
            bt_do_destroy.Name = "bt_do_destroy";
            bt_do_destroy.Radius = 50;
            bt_do_destroy.Size = new Size(196, 51);
            bt_do_destroy.TabIndex = 33;
            bt_do_destroy.Text = "uiButton1";
            bt_do_destroy.Click += bt_do_destroy_Click;
            // 
            // lb_pledge_address
            // 
            lb_pledge_address.AutoSize = true;
            lb_pledge_address.Font = new Font("微软雅黑", 12F);
            lb_pledge_address.ForeColor = Color.FromArgb(48, 48, 48);
            lb_pledge_address.Location = new Point(12, 83);
            lb_pledge_address.Name = "lb_pledge_address";
            lb_pledge_address.Size = new Size(62, 31);
            lb_pledge_address.TabIndex = 34;
            lb_pledge_address.Text = "住址";
            lb_pledge_address.TextAlign = ContentAlignment.MiddleLeft;
            lb_pledge_address.Click += img_cast_Click;
            // 
            // rtb_msg
            // 
            rtb_msg.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtb_msg.BorderStyle = BorderStyle.None;
            rtb_msg.Location = new Point(12, 785);
            rtb_msg.Name = "rtb_msg";
            rtb_msg.ReadOnly = true;
            rtb_msg.Size = new Size(948, 203);
            rtb_msg.TabIndex = 36;
            rtb_msg.Text = "";
            // 
            // tb_amount
            // 
            tb_amount.FillColor = Color.White;
            tb_amount.Font = new Font("宋体", 12F);
            tb_amount.Location = new Point(260, 616);
            tb_amount.Margin = new Padding(4, 5, 4, 5);
            tb_amount.Maximum = 10000000D;
            tb_amount.Minimum = 0D;
            tb_amount.MinimumSize = new Size(63, 0);
            tb_amount.Name = "tb_amount";
            tb_amount.NumPadType = Sunny.UI.NumPadType.Integer;
            tb_amount.Padding = new Padding(0, 0, 30, 2);
            tb_amount.Size = new Size(256, 44);
            tb_amount.SymbolSize = 24;
            tb_amount.TabIndex = 37;
            tb_amount.TextAlignment = ContentAlignment.MiddleLeft;
            tb_amount.Watermark = "";
            // 
            // uiTrackBar1
            // 
            uiTrackBar1.BarSize = 50;
            uiTrackBar1.Font = new Font("宋体", 12F);
            uiTrackBar1.Location = new Point(28, 679);
            uiTrackBar1.MinimumSize = new Size(1, 1);
            uiTrackBar1.Name = "uiTrackBar1";
            uiTrackBar1.Size = new Size(672, 44);
            uiTrackBar1.TabIndex = 39;
            uiTrackBar1.Text = "uiTrackBar1";
            uiTrackBar1.ValueChanged += uiTrackBar1_ValueChanged;
            // 
            // uiRuler1
            // 
            uiRuler1.BackColor = Color.Transparent;
            uiRuler1.Font = new Font("宋体", 12F);
            uiRuler1.Location = new Point(25, 723);
            uiRuler1.MinimumSize = new Size(1, 1);
            uiRuler1.Name = "uiRuler1";
            uiRuler1.Size = new Size(672, 44);
            uiRuler1.TabIndex = 38;
            uiRuler1.Text = "uiRuler1";
            // 
            // bt_copy_eth
            // 
            bt_copy_eth.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_copy_eth.Font = new Font("微软雅黑", 12F);
            bt_copy_eth.Location = new Point(764, 101);
            bt_copy_eth.MinimumSize = new Size(1, 1);
            bt_copy_eth.Name = "bt_copy_eth";
            bt_copy_eth.Size = new Size(196, 52);
            bt_copy_eth.TabIndex = 40;
            bt_copy_eth.Text = "uiButton1";
            bt_copy_eth.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_copy_eth.Click += bt_copy_eth_Click;
            // 
            // USDTCastPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1445, 1002);
            Controls.Add(bt_copy_eth);
            Controls.Add(uiTrackBar1);
            Controls.Add(uiRuler1);
            Controls.Add(tb_amount);
            Controls.Add(rtb_msg);
            Controls.Add(lb_pledge_address);
            Controls.Add(bt_do_destroy);
            Controls.Add(img_cast);
            Controls.Add(bt_destroy_record);
            Controls.Add(L_destroy);
            Controls.Add(bt_cast_record);
            Controls.Add(L_cast);
            Controls.Add(lb_Details);
            Controls.Add(lb_amount);
            Controls.Add(tb_balance);
            Controls.Add(lb_usdt_balance);
            Name = "USDTCastPage";
            Text = "PlazaForm";
            Initialize += OrderHistory_Initialize;
            ((System.ComponentModel.ISupportInitialize)img_cast).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Sunny.UI.UIButton bt_destroy_record;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UILabel lb_amount;
        private Sunny.UI.UITextBox tb_balance;
        private Sunny.UI.UILabel lb_usdt_balance;
        private Sunny.UI.UIListBox lb_Details;
        private Sunny.UI.UIButton bt_cast_record;
        private Sunny.UI.UILine L_cast;
        private Sunny.UI.UILine L_destroy;
        private System.Windows.Forms.PictureBox img_cast;
        private Sunny.UI.UIButton bt_do_destroy;
        private Sunny.UI.UILabel lb_pledge_address;
        private System.Windows.Forms.RichTextBox rtb_msg;
        private Sunny.UI.UINumPadTextBox tb_amount;
        private Sunny.UI.UITrackBar uiTrackBar1;
        private Sunny.UI.UIRuler uiRuler1;
        private Sunny.UI.UIButton bt_copy_eth;
    }
}