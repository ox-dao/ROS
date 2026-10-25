namespace OX.Tablet.UIs.Rothschild
{
    partial class WitnessPage
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
            tv_mutualWitnessRecords = new Sunny.UI.UITreeView();
            tv_selfWitnessRecords = new Sunny.UI.UITreeView();
            tv_witnessRecord = new Sunny.UI.UITreeView();
            tv_asset = new Sunny.UI.UITreeView();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(tv_mutualWitnessRecords, 2, 0);
            tableLayoutPanel1.Controls.Add(tv_selfWitnessRecords, 1, 0);
            tableLayoutPanel1.Controls.Add(tv_witnessRecord, 0, 0);
            tableLayoutPanel1.Location = new Point(4, 152);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1438, 689);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tv_mutualWitnessRecords
            // 
            tv_mutualWitnessRecords.Dock = DockStyle.Fill;
            tv_mutualWitnessRecords.FillColor = Color.White;
            tv_mutualWitnessRecords.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tv_mutualWitnessRecords.Location = new Point(962, 5);
            tv_mutualWitnessRecords.Margin = new Padding(4, 5, 4, 5);
            tv_mutualWitnessRecords.MinimumSize = new Size(1, 1);
            tv_mutualWitnessRecords.Name = "tv_mutualWitnessRecords";
            tv_mutualWitnessRecords.ScrollBarStyleInherited = false;
            tv_mutualWitnessRecords.ShowText = false;
            tv_mutualWitnessRecords.Size = new Size(472, 679);
            tv_mutualWitnessRecords.TabIndex = 2;
            tv_mutualWitnessRecords.Text = "uiTreeView3";
            tv_mutualWitnessRecords.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // tv_selfWitnessRecords
            // 
            tv_selfWitnessRecords.Dock = DockStyle.Fill;
            tv_selfWitnessRecords.FillColor = Color.White;
            tv_selfWitnessRecords.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tv_selfWitnessRecords.Location = new Point(483, 5);
            tv_selfWitnessRecords.Margin = new Padding(4, 5, 4, 5);
            tv_selfWitnessRecords.MinimumSize = new Size(1, 1);
            tv_selfWitnessRecords.Name = "tv_selfWitnessRecords";
            tv_selfWitnessRecords.ScrollBarStyleInherited = false;
            tv_selfWitnessRecords.ShowText = false;
            tv_selfWitnessRecords.Size = new Size(471, 679);
            tv_selfWitnessRecords.TabIndex = 1;
            tv_selfWitnessRecords.Text = "uiTreeView2";
            tv_selfWitnessRecords.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // tv_witnessRecord
            // 
            tv_witnessRecord.Dock = DockStyle.Fill;
            tv_witnessRecord.FillColor = Color.White;
            tv_witnessRecord.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tv_witnessRecord.Location = new Point(4, 5);
            tv_witnessRecord.Margin = new Padding(4, 5, 4, 5);
            tv_witnessRecord.MinimumSize = new Size(1, 1);
            tv_witnessRecord.Name = "tv_witnessRecord";
            tv_witnessRecord.ScrollBarStyleInherited = false;
            tv_witnessRecord.ShowText = false;
            tv_witnessRecord.Size = new Size(471, 679);
            tv_witnessRecord.TabIndex = 0;
            tv_witnessRecord.Text = "uiTreeView1";
            tv_witnessRecord.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // tv_asset
            // 
            tv_asset.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tv_asset.FillColor = Color.White;
            tv_asset.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tv_asset.Location = new Point(8, 8);
            tv_asset.Margin = new Padding(4, 5, 4, 5);
            tv_asset.MinimumSize = new Size(1, 1);
            tv_asset.Name = "tv_asset";
            tv_asset.ScrollBarStyleInherited = false;
            tv_asset.ShowText = false;
            tv_asset.Size = new Size(1430, 139);
            tv_asset.TabIndex = 1;
            tv_asset.Text = "uiTreeView1";
            tv_asset.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // WitnessPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1445, 845);
            Controls.Add(tv_asset);
            Controls.Add(tableLayoutPanel1);
            Name = "WitnessPage";
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
        private Sunny.UI.UITreeView tv_mutualWitnessRecords;
        private Sunny.UI.UITreeView tv_selfWitnessRecords;
        private Sunny.UI.UITreeView tv_witnessRecord;
        private Sunny.UI.UITreeView tv_asset;
    }
}