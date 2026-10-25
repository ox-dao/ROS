
namespace OX.Tablet.UIs.Rothschild
{
    partial class SpaceTimeSnapshot
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
            tb_BlockIndex = new Sunny.UI.UITextBox();
            lb_BlockIndex = new Sunny.UI.UILabel();
            lb_SelfSTVol = new Sunny.UI.UILabel();
            lb_LeafSTVol = new Sunny.UI.UILabel();
            tb_SelfSTVol = new Sunny.UI.UITextBox();
            tb_LeafSTVol = new Sunny.UI.UITextBox();
            bt_pre = new Sunny.UI.UIButton();
            bt_next = new Sunny.UI.UIButton();
            bt_close = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // tb_BlockIndex
            // 
            tb_BlockIndex.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tb_BlockIndex.Location = new Point(215, 40);
            tb_BlockIndex.Margin = new Padding(4, 5, 4, 5);
            tb_BlockIndex.MinimumSize = new Size(1, 16);
            tb_BlockIndex.Name = "tb_BlockIndex";
            tb_BlockIndex.Padding = new Padding(5);
            tb_BlockIndex.ReadOnly = true;
            tb_BlockIndex.ShowText = false;
            tb_BlockIndex.Size = new Size(465, 42);
            tb_BlockIndex.TabIndex = 48;
            tb_BlockIndex.TextAlignment = ContentAlignment.MiddleLeft;
            tb_BlockIndex.Watermark = "";
            tb_BlockIndex.TextChanged += tb_targetAssetId_TextChanged;
            // 
            // lb_BlockIndex
            // 
            lb_BlockIndex.AutoSize = true;
            lb_BlockIndex.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lb_BlockIndex.ForeColor = Color.FromArgb(48, 48, 48);
            lb_BlockIndex.Location = new Point(30, 48);
            lb_BlockIndex.Name = "lb_BlockIndex";
            lb_BlockIndex.Size = new Size(130, 24);
            lb_BlockIndex.TabIndex = 47;
            lb_BlockIndex.Text = "darkLabel1";
            // 
            // lb_SelfSTVol
            // 
            lb_SelfSTVol.AutoSize = true;
            lb_SelfSTVol.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lb_SelfSTVol.ForeColor = Color.FromArgb(48, 48, 48);
            lb_SelfSTVol.Location = new Point(30, 101);
            lb_SelfSTVol.Name = "lb_SelfSTVol";
            lb_SelfSTVol.Size = new Size(130, 24);
            lb_SelfSTVol.TabIndex = 49;
            lb_SelfSTVol.Text = "darkLabel1";
            // 
            // lb_LeafSTVol
            // 
            lb_LeafSTVol.AutoSize = true;
            lb_LeafSTVol.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lb_LeafSTVol.ForeColor = Color.FromArgb(48, 48, 48);
            lb_LeafSTVol.Location = new Point(30, 154);
            lb_LeafSTVol.Name = "lb_LeafSTVol";
            lb_LeafSTVol.Size = new Size(130, 24);
            lb_LeafSTVol.TabIndex = 50;
            lb_LeafSTVol.Text = "darkLabel1";
            // 
            // tb_SelfSTVol
            // 
            tb_SelfSTVol.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tb_SelfSTVol.Location = new Point(215, 92);
            tb_SelfSTVol.Margin = new Padding(4, 5, 4, 5);
            tb_SelfSTVol.MinimumSize = new Size(1, 16);
            tb_SelfSTVol.Name = "tb_SelfSTVol";
            tb_SelfSTVol.Padding = new Padding(5);
            tb_SelfSTVol.ShowText = false;
            tb_SelfSTVol.Size = new Size(465, 44);
            tb_SelfSTVol.TabIndex = 69;
            tb_SelfSTVol.Text = "tb_LeafSTVol";
            tb_SelfSTVol.TextAlignment = ContentAlignment.MiddleLeft;
            tb_SelfSTVol.Watermark = "";
            // 
            // tb_LeafSTVol
            // 
            tb_LeafSTVol.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tb_LeafSTVol.Location = new Point(215, 151);
            tb_LeafSTVol.Margin = new Padding(4, 5, 4, 5);
            tb_LeafSTVol.MinimumSize = new Size(1, 16);
            tb_LeafSTVol.Name = "tb_LeafSTVol";
            tb_LeafSTVol.Padding = new Padding(5);
            tb_LeafSTVol.ShowText = false;
            tb_LeafSTVol.Size = new Size(465, 44);
            tb_LeafSTVol.TabIndex = 69;
            tb_LeafSTVol.Text = "tb_LeafSTVol";
            tb_LeafSTVol.TextAlignment = ContentAlignment.MiddleLeft;
            tb_LeafSTVol.Watermark = "";
            // 
            // bt_pre
            // 
            bt_pre.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_pre.Location = new Point(215, 203);
            bt_pre.MinimumSize = new Size(1, 1);
            bt_pre.Name = "bt_pre";
            bt_pre.Padding = new Padding(5);
            bt_pre.Size = new Size(227, 59);
            bt_pre.TabIndex = 66;
            bt_pre.Text = "darkButton1";
            bt_pre.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_pre.Click += bt_pre_Click;
            // 
            // bt_next
            // 
            bt_next.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_next.Location = new Point(453, 203);
            bt_next.MinimumSize = new Size(1, 1);
            bt_next.Name = "bt_next";
            bt_next.Padding = new Padding(5);
            bt_next.Size = new Size(227, 59);
            bt_next.TabIndex = 67;
            bt_next.Text = "darkButton2";
            bt_next.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_next.Click += bt_next_Click;
            // 
            // bt_close
            // 
            bt_close.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_close.Location = new Point(530, 280);
            bt_close.MinimumSize = new Size(1, 1);
            bt_close.Name = "bt_close";
            bt_close.Size = new Size(150, 52);
            bt_close.TabIndex = 68;
            bt_close.Text = "uiButton1";
            bt_close.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_close.Click += bt_close_Click;
            // 
            // SpaceTimeSnapshot
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(702, 364);
            Controls.Add(bt_close);
            Controls.Add(bt_next);
            Controls.Add(bt_pre);
            Controls.Add(tb_LeafSTVol);
            Controls.Add(tb_SelfSTVol);
            Controls.Add(lb_LeafSTVol);
            Controls.Add(lb_SelfSTVol);
            Controls.Add(tb_BlockIndex);
            Controls.Add(lb_BlockIndex);
            Name = "SpaceTimeSnapshot";
            Text = "SpaceTimeSnapshot";
            ZoomScaleRect = new Rectangle(22, 22, 752, 338);
            Load += RegMinerForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Sunny.UI.UITextBox tb_BlockIndex;
        private Sunny.UI.UILabel lb_BlockIndex;
        private Sunny.UI.UILabel lb_SelfSTVol;
        private Sunny.UI.UILabel lb_LeafSTVol;
        private Sunny.UI.UITextBox tb_SelfSTVol;
        private Sunny.UI.UITextBox tb_LeafSTVol;
        private Sunny.UI.UIButton bt_pre;
        private Sunny.UI.UIButton bt_next;
        private Sunny.UI.UIButton bt_close;
    }
}