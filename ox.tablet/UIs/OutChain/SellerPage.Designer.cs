namespace OX.Tablet.UIs.OutChain
{
    partial class SellerPage
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
            L1 = new Sunny.UI.UILine();
            pn_pairs = new Sunny.UI.UIFlowLayoutPanel();
            bt_refresh = new Sunny.UI.UIButton();
            bt_advance = new Sunny.UI.UIButton();
            L_bottom = new Sunny.UI.UILine();
            bt_tokenview = new Sunny.UI.UIButton();
            bt_ethscan = new Sunny.UI.UIButton();
            bt_blockchair = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // L1
            // 
            L1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            L1.BackColor = Color.Transparent;
            L1.Font = new Font("宋体", 12F);
            L1.ForeColor = Color.FromArgb(48, 48, 48);
            L1.Location = new Point(230, 26);
            L1.MinimumSize = new Size(1, 1);
            L1.Name = "L1";
            L1.Size = new Size(988, 26);
            L1.TabIndex = 15;
            L1.Text = "uiLine1";
            // 
            // pn_pairs
            // 
            pn_pairs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pn_pairs.Font = new Font("宋体", 12F);
            pn_pairs.Location = new Point(13, 81);
            pn_pairs.Margin = new Padding(4, 5, 4, 5);
            pn_pairs.MinimumSize = new Size(1, 1);
            pn_pairs.Name = "pn_pairs";
            pn_pairs.Padding = new Padding(2, 10, 2, 2);
            pn_pairs.RectColor = Color.Transparent;
            pn_pairs.RightToLeft = RightToLeft.No;
            pn_pairs.ScrollBarHandleWidth = 100;
            pn_pairs.ShowText = false;
            pn_pairs.Size = new Size(1418, 646);
            pn_pairs.TabIndex = 14;
            pn_pairs.Text = "uiFlowLayoutPanel1";
            pn_pairs.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // bt_refresh
            // 
            bt_refresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_refresh.Font = new Font("微软雅黑", 12F);
            bt_refresh.Location = new Point(1235, 12);
            bt_refresh.MinimumSize = new Size(1, 1);
            bt_refresh.Name = "bt_refresh";
            bt_refresh.Size = new Size(196, 52);
            bt_refresh.TabIndex = 4;
            bt_refresh.Text = "uiButton1";
            bt_refresh.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_refresh.Click += bt_refresh_Click;
            // 
            // bt_advance
            // 
            bt_advance.Font = new Font("微软雅黑", 12F);
            bt_advance.Location = new Point(12, 12);
            bt_advance.MinimumSize = new Size(1, 1);
            bt_advance.Name = "bt_advance";
            bt_advance.Size = new Size(196, 52);
            bt_advance.TabIndex = 5;
            bt_advance.Text = "uiButton1";
            bt_advance.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_advance.Click += bt_advance_Click;
            // 
            // L_bottom
            // 
            L_bottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            L_bottom.BackColor = Color.Transparent;
            L_bottom.Font = new Font("宋体", 12F);
            L_bottom.ForeColor = Color.FromArgb(48, 48, 48);
            L_bottom.Location = new Point(12, 745);
            L_bottom.MinimumSize = new Size(1, 1);
            L_bottom.Name = "L_bottom";
            L_bottom.Size = new Size(1419, 26);
            L_bottom.TabIndex = 16;
            L_bottom.Text = "uiLine1";
            // 
            // bt_tokenview
            // 
            bt_tokenview.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bt_tokenview.Font = new Font("微软雅黑", 12F);
            bt_tokenview.Location = new Point(13, 777);
            bt_tokenview.MinimumSize = new Size(1, 1);
            bt_tokenview.Name = "bt_tokenview";
            bt_tokenview.Size = new Size(196, 52);
            bt_tokenview.TabIndex = 17;
            bt_tokenview.Text = "uiButton1";
            bt_tokenview.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_tokenview.Click += bt_tokenview_Click;
            // 
            // bt_ethscan
            // 
            bt_ethscan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bt_ethscan.Font = new Font("微软雅黑", 12F);
            bt_ethscan.Location = new Point(230, 777);
            bt_ethscan.MinimumSize = new Size(1, 1);
            bt_ethscan.Name = "bt_ethscan";
            bt_ethscan.Size = new Size(196, 52);
            bt_ethscan.TabIndex = 18;
            bt_ethscan.Text = "uiButton2";
            bt_ethscan.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_ethscan.Click += bt_ethscan_Click;
            // 
            // bt_blockchair
            // 
            bt_blockchair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bt_blockchair.Font = new Font("微软雅黑", 12F);
            bt_blockchair.Location = new Point(447, 777);
            bt_blockchair.MinimumSize = new Size(1, 1);
            bt_blockchair.Name = "bt_blockchair";
            bt_blockchair.Size = new Size(196, 52);
            bt_blockchair.TabIndex = 18;
            bt_blockchair.Text = "uiButton3";
            bt_blockchair.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_blockchair.Click += bt_blockchair_Click;
            // 
            // SellerPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1445, 845);
            Controls.Add(bt_blockchair);
            Controls.Add(bt_ethscan);
            Controls.Add(bt_tokenview);
            Controls.Add(L_bottom);
            Controls.Add(bt_advance);
            Controls.Add(bt_refresh);
            Controls.Add(L1);
            Controls.Add(pn_pairs);
            Name = "SellerPage";
            Text = "PlazaForm";
            Initialize += OrderHistory_Initialize;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIButton bt_tokenview;
        private Sunny.UI.UIButton bt_ethscan;
        private Sunny.UI.UIButton bt_blockchair;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UILine L1;
        private Sunny.UI.UIFlowLayoutPanel pn_pairs;
        private Sunny.UI.UIButton bt_refresh;
        private Sunny.UI.UIButton bt_advance;
        private Sunny.UI.UILine L_bottom;
    }
}