namespace OX.Tablet.UIs.Setting
{
    partial class GlobalAssetsPage
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tv_nativeAssets = new Sunny.UI.UITreeView();
            tv_tokenAssets = new Sunny.UI.UITreeView();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tv_tokenAssets, 1, 0);
            tableLayoutPanel1.Controls.Add(tv_nativeAssets, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1445, 845);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tv_nativeAssets
            // 
            tv_nativeAssets.Dock = DockStyle.Fill;
            tv_nativeAssets.FillColor = Color.White;
            tv_nativeAssets.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tv_nativeAssets.Location = new Point(4, 5);
            tv_nativeAssets.Margin = new Padding(4, 5, 4, 5);
            tv_nativeAssets.MinimumSize = new Size(1, 1);
            tv_nativeAssets.Name = "tv_nativeAssets";
            tv_nativeAssets.ScrollBarStyleInherited = false;
            tv_nativeAssets.ShowText = false;
            tv_nativeAssets.Size = new Size(714, 835);
            tv_nativeAssets.TabIndex = 1;
            tv_nativeAssets.Text = "uiTreeView1";
            tv_nativeAssets.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // tv_tokenAssets
            // 
            tv_tokenAssets.Dock = DockStyle.Fill;
            tv_tokenAssets.FillColor = Color.White;
            tv_tokenAssets.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tv_tokenAssets.Location = new Point(726, 5);
            tv_tokenAssets.Margin = new Padding(4, 5, 4, 5);
            tv_tokenAssets.MinimumSize = new Size(1, 1);
            tv_tokenAssets.Name = "tv_tokenAssets";
            tv_tokenAssets.ScrollBarStyleInherited = false;
            tv_tokenAssets.ShowText = false;
            tv_tokenAssets.Size = new Size(715, 835);
            tv_tokenAssets.TabIndex = 2;
            tv_tokenAssets.Text = "uiTreeView1";
            tv_tokenAssets.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // GlobalAssetsPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1445, 845);
            Controls.Add(tableLayoutPanel1);
            Name = "GlobalAssetsPage";
            Text = "PlazaForm";
            Initialize += OrderHistory_Initialize;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UITreeView tv_tokenAssets;
        private Sunny.UI.UITreeView tv_nativeAssets;
    }
}