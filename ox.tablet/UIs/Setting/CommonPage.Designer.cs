namespace OX.Tablet.UIs.Setting
{
    partial class CommonPage
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
            bt_lock = new Sunny.UI.UIButton();
            bt_exit = new Sunny.UI.UIButton();
            bt_rebuild = new Sunny.UI.UIButton();
            bt_switch = new Sunny.UI.UIButton();
            bt_collapse = new Sunny.UI.UIButton();
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiTextBox2 = new Sunny.UI.UITextBox();
            bt_queryName = new Sunny.UI.UIButton();
            bt_copy_dms = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // L1
            // 
            L1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            L1.BackColor = Color.Transparent;
            L1.Font = new Font("宋体", 12F);
            L1.ForeColor = Color.FromArgb(48, 48, 48);
            L1.Location = new Point(12, 370);
            L1.MinimumSize = new Size(1, 1);
            L1.Name = "L1";
            L1.Size = new Size(1421, 26);
            L1.TabIndex = 15;
            // 
            // bt_lock
            // 
            bt_lock.Font = new Font("微软雅黑", 12F);
            bt_lock.Location = new Point(115, 96);
            bt_lock.MinimumSize = new Size(1, 1);
            bt_lock.Name = "bt_lock";
            bt_lock.Radius = 50;
            bt_lock.Size = new Size(196, 52);
            bt_lock.TabIndex = 16;
            bt_lock.Text = "uiButton1";
            bt_lock.TipsFont = new Font("微软雅黑", 9F);
            bt_lock.Click += bt_lock_Click;
            // 
            // bt_exit
            // 
            bt_exit.Font = new Font("微软雅黑", 12F);
            bt_exit.Location = new Point(115, 212);
            bt_exit.MinimumSize = new Size(1, 1);
            bt_exit.Name = "bt_exit";
            bt_exit.Radius = 50;
            bt_exit.Size = new Size(196, 52);
            bt_exit.TabIndex = 17;
            bt_exit.Text = "uiButton1";
            bt_exit.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_exit.Click += bt_exit_Click;
            // 
            // bt_rebuild
            // 
            bt_rebuild.Font = new Font("微软雅黑", 12F);
            bt_rebuild.Location = new Point(587, 96);
            bt_rebuild.MinimumSize = new Size(1, 1);
            bt_rebuild.Name = "bt_rebuild";
            bt_rebuild.Radius = 50;
            bt_rebuild.Size = new Size(196, 52);
            bt_rebuild.TabIndex = 18;
            bt_rebuild.Text = "uiButton1";
            bt_rebuild.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_rebuild.Click += bt_rebuild_Click;
            // 
            // bt_switch
            // 
            bt_switch.Font = new Font("微软雅黑", 12F);
            bt_switch.Location = new Point(587, 212);
            bt_switch.MinimumSize = new Size(1, 1);
            bt_switch.Name = "bt_switch";
            bt_switch.Radius = 50;
            bt_switch.Size = new Size(196, 52);
            bt_switch.TabIndex = 19;
            bt_switch.Text = "uiButton1";
            bt_switch.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_switch.Click += bt_switch_Click;
            // 
            // bt_collapse
            // 
            bt_collapse.Font = new Font("微软雅黑", 14F);
            bt_collapse.Location = new Point(17, 701);
            bt_collapse.MinimumSize = new Size(1, 1);
            bt_collapse.Name = "bt_collapse";
            bt_collapse.Size = new Size(294, 112);
            bt_collapse.TabIndex = 22;
            bt_collapse.Text = "uiButton1";
            bt_collapse.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_collapse.Visible = false;
            bt_collapse.Click += bt_collapse_Click;
            // 
            // uiTextBox1
            // 
            uiTextBox1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox1.Location = new Point(17, 404);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new Padding(5);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(501, 44);
            uiTextBox1.TabIndex = 23;
            uiTextBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "";
            // 
            // uiTextBox2
            // 
            uiTextBox2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox2.Location = new Point(17, 475);
            uiTextBox2.Margin = new Padding(4, 5, 4, 5);
            uiTextBox2.MinimumSize = new Size(1, 16);
            uiTextBox2.Name = "uiTextBox2";
            uiTextBox2.Padding = new Padding(5);
            uiTextBox2.ReadOnly = true;
            uiTextBox2.ShowText = false;
            uiTextBox2.Size = new Size(501, 44);
            uiTextBox2.TabIndex = 24;
            uiTextBox2.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox2.Watermark = "";
            // 
            // bt_queryName
            // 
            bt_queryName.Font = new Font("微软雅黑", 12F);
            bt_queryName.Location = new Point(558, 396);
            bt_queryName.MinimumSize = new Size(1, 1);
            bt_queryName.Name = "bt_queryName";
            bt_queryName.Radius = 50;
            bt_queryName.Size = new Size(196, 52);
            bt_queryName.TabIndex = 25;
            bt_queryName.Text = "uiButton1";
            bt_queryName.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_queryName.Click += bt_queryName_Click;
            // 
            // bt_copy_dms
            // 
            bt_copy_dms.Font = new Font("微软雅黑", 12F);
            bt_copy_dms.Location = new Point(558, 467);
            bt_copy_dms.MinimumSize = new Size(1, 1);
            bt_copy_dms.Name = "bt_copy_dms";
            bt_copy_dms.Radius = 50;
            bt_copy_dms.Size = new Size(196, 52);
            bt_copy_dms.TabIndex = 26;
            bt_copy_dms.Text = "uiButton1";
            bt_copy_dms.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_copy_dms.Click += bt_copy_dms_Click;
            // 
            // CommonPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1445, 845);
            Controls.Add(bt_copy_dms);
            Controls.Add(bt_queryName);
            Controls.Add(uiTextBox2);
            Controls.Add(uiTextBox1);
            Controls.Add(bt_collapse);
            Controls.Add(bt_lock);
            Controls.Add(bt_exit);
            Controls.Add(bt_rebuild);
            Controls.Add(bt_switch);
            Controls.Add(L1);
            Name = "CommonPage";
            Text = "PlazaForm";
            Initialize += OrderHistory_Initialize;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIButton bt_queryName;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UILine L1;
        private Sunny.UI.UIButton bt_lock;
        private Sunny.UI.UIButton bt_exit;
        private Sunny.UI.UIButton bt_rebuild;
        private Sunny.UI.UIButton bt_switch;
        private Sunny.UI.UIButton bt_collapse;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UITextBox uiTextBox2;
        private Sunny.UI.UIButton bt_copy_dms;
    }
}