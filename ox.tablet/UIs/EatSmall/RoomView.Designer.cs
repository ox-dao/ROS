namespace OX.Tablet.UIs.MarkSix
{
    partial class RoomView
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
            Box = new Sunny.UI.UITableLayoutPanel();
            L1 = new Sunny.UI.UILine();
            lb_prize = new Sunny.UI.UIFlowLayoutPanel();
            bt_pre = new Sunny.UI.UIButton();
            bt_next = new Sunny.UI.UIButton();
            lb_bet_info = new Sunny.UI.UILabel();
            bt_go_current = new RoundButton();
            lb_pool_info = new Sunny.UI.UILabel();
            bt_verify_riddles = new Sunny.UI.UIButton();
            lb_riddles_hash = new Sunny.UI.UILabel();
            bt_Export = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // Box
            // 
            Box.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Box.AutoSize = true;
            Box.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            Box.ColumnCount = 3;
            Box.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.61867F));
            Box.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.38133F));
            Box.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 469F));
            Box.Location = new Point(12, 83);
            Box.Name = "Box";
            Box.RowCount = 3;
            Box.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            Box.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            Box.RowStyles.Add(new RowStyle(SizeType.Absolute, 242F));
            Box.Size = new Size(1215, 750);
            Box.TabIndex = 0;
            Box.TagString = null;
            // 
            // L1
            // 
            L1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            L1.BackColor = Color.Transparent;
            L1.Font = new Font("宋体", 12F);
            L1.ForeColor = Color.FromArgb(48, 48, 48);
            L1.Location = new Point(1234, 71);
            L1.MinimumSize = new Size(1, 1);
            L1.Name = "L1";
            L1.Size = new Size(201, 26);
            L1.TabIndex = 16;
            L1.Text = "uiLine1";
            // 
            // lb_prize
            // 
            lb_prize.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lb_prize.Font = new Font("宋体", 12F);
            lb_prize.Location = new Point(1235, 105);
            lb_prize.Margin = new Padding(4, 5, 4, 5);
            lb_prize.MinimumSize = new Size(1, 1);
            lb_prize.Name = "lb_prize";
            lb_prize.Padding = new Padding(2, 10, 2, 2);
            lb_prize.Radius = 1;
            lb_prize.RectColor = Color.Transparent;
            lb_prize.RightToLeft = RightToLeft.No;
            lb_prize.ScrollBarHandleWidth = 100;
            lb_prize.ShowText = false;
            lb_prize.Size = new Size(201, 726);
            lb_prize.TabIndex = 15;
            lb_prize.Text = "uiFlowLayoutPanel1";
            lb_prize.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // bt_pre
            // 
            bt_pre.Font = new Font("微软雅黑", 12F);
            bt_pre.Location = new Point(13, 16);
            bt_pre.MinimumSize = new Size(1, 1);
            bt_pre.Name = "bt_pre";
            bt_pre.Radius = 50;
            bt_pre.Size = new Size(135, 52);
            bt_pre.TabIndex = 17;
            bt_pre.Text = "uiButton1";
            bt_pre.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_pre.Click += bt_pre_Click;
            // 
            // bt_next
            // 
            bt_next.Font = new Font("微软雅黑", 12F);
            bt_next.Location = new Point(379, 16);
            bt_next.MinimumSize = new Size(1, 1);
            bt_next.Name = "bt_next";
            bt_next.Radius = 50;
            bt_next.Size = new Size(135, 52);
            bt_next.TabIndex = 18;
            bt_next.Text = "uiButton1";
            bt_next.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_next.Click += bt_next_Click;
            // 
            // lb_bet_info
            // 
            lb_bet_info.AutoSize = true;
            lb_bet_info.Font = new Font("宋体", 12F);
            lb_bet_info.ForeColor = Color.FromArgb(48, 48, 48);
            lb_bet_info.Location = new Point(562, 6);
            lb_bet_info.Name = "lb_bet_info";
            lb_bet_info.Size = new Size(106, 24);
            lb_bet_info.TabIndex = 20;
            lb_bet_info.Text = "uiLabel1";
            // 
            // bt_go_current
            // 
            bt_go_current.FillColor = Color.DarkOrange;
            bt_go_current.FillColor2 = Color.DarkOrange;
            bt_go_current.FillHoverColor = Color.DarkOrange;
            bt_go_current.FillPressColor = Color.DarkOrange;
            bt_go_current.FillSelectedColor = Color.DarkOrange;
            bt_go_current.Font = new Font("微软雅黑", 10F);
            bt_go_current.Location = new Point(184, 16);
            bt_go_current.MinimumSize = new Size(1, 1);
            bt_go_current.Name = "bt_go_current";
            bt_go_current.RectColor = Color.DarkOrange;
            bt_go_current.RectHoverColor = Color.DarkOrange;
            bt_go_current.RectPressColor = Color.DarkOrange;
            bt_go_current.RectSelectedColor = Color.DarkOrange;
            bt_go_current.Size = new Size(158, 52);
            bt_go_current.Style = Sunny.UI.UIStyle.Custom;
            bt_go_current.StyleCustomMode = true;
            bt_go_current.TabIndex = 21;
            bt_go_current.Text = "uiButton1";
            bt_go_current.TextAlign = ContentAlignment.BottomCenter;
            bt_go_current.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_go_current.UseDoubleClick = true;
            bt_go_current.Click += bt_go_current_Click;
            // 
            // lb_pool_info
            // 
            lb_pool_info.AutoSize = true;
            lb_pool_info.Font = new Font("宋体", 12F);
            lb_pool_info.ForeColor = Color.FromArgb(48, 48, 48);
            lb_pool_info.Location = new Point(562, 32);
            lb_pool_info.Name = "lb_pool_info";
            lb_pool_info.Size = new Size(106, 24);
            lb_pool_info.TabIndex = 22;
            lb_pool_info.Text = "uiLabel1";
            // 
            // bt_verify_riddles
            // 
            bt_verify_riddles.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_verify_riddles.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_verify_riddles.Location = new Point(1348, 14);
            bt_verify_riddles.MinimumSize = new Size(1, 1);
            bt_verify_riddles.Name = "bt_verify_riddles";
            bt_verify_riddles.Size = new Size(85, 52);
            bt_verify_riddles.TabIndex = 23;
            bt_verify_riddles.Text = "uiButton1";
            bt_verify_riddles.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_verify_riddles.Click += bt_verify_riddles_Click_1;
            // 
            // lb_riddles_hash
            // 
            lb_riddles_hash.AutoSize = true;
            lb_riddles_hash.Font = new Font("宋体", 12F);
            lb_riddles_hash.ForeColor = Color.FromArgb(48, 48, 48);
            lb_riddles_hash.Location = new Point(562, 56);
            lb_riddles_hash.Name = "lb_riddles_hash";
            lb_riddles_hash.RightToLeft = RightToLeft.Yes;
            lb_riddles_hash.Size = new Size(106, 24);
            lb_riddles_hash.TabIndex = 24;
            lb_riddles_hash.Text = "uiLabel1";
            lb_riddles_hash.Click += lb_riddles_hash_Click;
            lb_riddles_hash.DoubleClick += lb_riddles_hash_DoubleClick;
            // 
            // bt_Export
            // 
            bt_Export.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_Export.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_Export.Location = new Point(1247, 14);
            bt_Export.MinimumSize = new Size(1, 1);
            bt_Export.Name = "bt_Export";
            bt_Export.Size = new Size(85, 52);
            bt_Export.TabIndex = 25;
            bt_Export.Text = "uiButton1";
            bt_Export.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_Export.Click += bt_Export_Click;
            // 
            // RoomView
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1445, 845);
            Controls.Add(bt_Export);
            Controls.Add(lb_riddles_hash);
            Controls.Add(bt_verify_riddles);
            Controls.Add(lb_pool_info);
            Controls.Add(bt_go_current);
            Controls.Add(lb_bet_info);
            Controls.Add(bt_next);
            Controls.Add(bt_pre);
            Controls.Add(lb_prize);
            Controls.Add(L1);
            Controls.Add(Box);
            Name = "RoomView";
            Text = "PlazaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Sunny.UI.UIButton bt_next;
        private Sunny.UI.UITableLayoutPanel Box;
        private Sunny.UI.UILine L1;
        private Sunny.UI.UIFlowLayoutPanel lb_prize;
        private Sunny.UI.UIButton bt_pre;
        private Sunny.UI.UILabel lb_bet_info;
        private RoundButton bt_go_current;
        private Sunny.UI.UILabel lb_pool_info;
        private Sunny.UI.UIButton bt_verify_riddles;
        private Sunny.UI.UILabel lb_riddles_hash;
        private Sunny.UI.UIButton bt_Export;
    }
}