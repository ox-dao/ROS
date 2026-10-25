namespace OX.Tablet.UIs.MarkSix
{
    partial class ExchangePage
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
            StockChart = new OX.Tablet.UIs.Swap.Canvas.Stock_IndicatorMarketUI();
            SuspendLayout();
            // 
            // L1
            // 
            L1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            L1.BackColor = Color.Transparent;
            L1.Font = new Font("宋体", 12F);
            L1.ForeColor = Color.FromArgb(48, 48, 48);
            L1.Location = new Point(13, 25);
            L1.MinimumSize = new Size(1, 1);
            L1.Name = "L1";
            L1.Size = new Size(1201, 26);
            L1.TabIndex = 13;
            L1.Text = "uiLine1";
            // 
            // pn_pairs
            // 
            pn_pairs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pn_pairs.Font = new Font("宋体", 12F);
            pn_pairs.Location = new Point(13, 72);
            pn_pairs.Margin = new Padding(4, 5, 4, 5);
            pn_pairs.MinimumSize = new Size(1, 1);
            pn_pairs.Name = "pn_pairs";
            pn_pairs.Padding = new Padding(2, 10, 2, 2);
            pn_pairs.RectColor = Color.Transparent;
            pn_pairs.RightToLeft = RightToLeft.No;
            pn_pairs.ScrollBarHandleWidth = 100;
            pn_pairs.ShowText = false;
            pn_pairs.Size = new Size(1419, 393);
            pn_pairs.TabIndex = 12;
            pn_pairs.Text = "uiFlowLayoutPanel1";
            pn_pairs.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // bt_refresh
            // 
            bt_refresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_refresh.Font = new Font("微软雅黑", 12F);
            bt_refresh.Location = new Point(1237, 12);
            bt_refresh.MinimumSize = new Size(1, 1);
            bt_refresh.Name = "bt_refresh";
            bt_refresh.Size = new Size(196, 52);
            bt_refresh.TabIndex = 5;
            bt_refresh.Text = "uiButton1";
            bt_refresh.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_refresh.Click += bt_refresh_Click;
            // 
            // StockChart
            // 
            StockChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StockChart.Location = new Point(0, 473);
            StockChart.Name = "StockChart";
            StockChart.Size = new Size(1445, 372);
            StockChart.TabIndex = 14;
            // 
            // ExchangePage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1445, 845);
            Controls.Add(StockChart);
            Controls.Add(bt_refresh);
            Controls.Add(L1);
            Controls.Add(pn_pairs);
            Name = "ExchangePage";
            Text = "PlazaForm";
            Initialize += OrderHistory_Initialize;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILine L1;
        private Sunny.UI.UIFlowLayoutPanel pn_pairs;
        private Sunny.UI.UIButton bt_refresh;
        private Swap.Canvas.Stock_IndicatorMarketUI StockChart;
    }
}