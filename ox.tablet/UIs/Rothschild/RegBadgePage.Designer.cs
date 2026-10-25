namespace OX.Tablet.UIs.Rothschild
{
    partial class RegBadgePage
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
            lb_seedBadge = new Sunny.UI.UILabel();
            cb_rothBadge = new Sunny.UI.UICheckBox();
            tb_seedBadge = new Sunny.UI.UITextBox();
            bt_reg = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // lb_seedBadge
            // 
            lb_seedBadge.AutoSize = true;
            lb_seedBadge.Font = new System.Drawing.Font("宋体", 12F);
            lb_seedBadge.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lb_seedBadge.Location = new System.Drawing.Point(71, 85);
            lb_seedBadge.Name = "lb_seedBadge";
            lb_seedBadge.Size = new System.Drawing.Size(106, 24);
            lb_seedBadge.TabIndex = 0;
            lb_seedBadge.Text = "uiLabel1";
            // 
            // cb_rothBadge
            // 
            cb_rothBadge.Font = new System.Drawing.Font("宋体", 12F);
            cb_rothBadge.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            cb_rothBadge.Location = new System.Drawing.Point(71, 151);
            cb_rothBadge.MinimumSize = new System.Drawing.Size(1, 1);
            cb_rothBadge.Name = "cb_rothBadge";
            cb_rothBadge.Size = new System.Drawing.Size(225, 44);
            cb_rothBadge.TabIndex = 1;
            cb_rothBadge.Text = "uiCheckBox1";
            cb_rothBadge.CheckedChanged += cb_rothBadge_CheckedChanged;
            // 
            // tb_seedBadge
            // 
            tb_seedBadge.Font = new System.Drawing.Font("宋体", 12F);
            tb_seedBadge.Location = new System.Drawing.Point(326, 75);
            tb_seedBadge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tb_seedBadge.MinimumSize = new System.Drawing.Size(1, 16);
            tb_seedBadge.Name = "tb_seedBadge";
            tb_seedBadge.Padding = new System.Windows.Forms.Padding(5);
            tb_seedBadge.ShowText = false;
            tb_seedBadge.Size = new System.Drawing.Size(587, 44);
            tb_seedBadge.TabIndex = 2;
            tb_seedBadge.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tb_seedBadge.Watermark = "";
            // 
            // bt_reg
            // 
            bt_reg.Font = new System.Drawing.Font("微软雅黑", 12F);
            bt_reg.Location = new System.Drawing.Point(765, 143);
            bt_reg.MinimumSize = new System.Drawing.Size(1, 1);
            bt_reg.Name = "bt_reg";
            bt_reg.Size = new System.Drawing.Size(148, 52);
            bt_reg.TabIndex = 8;
            bt_reg.Text = "uiButton2";
            bt_reg.TipsFont = new System.Drawing.Font("微软雅黑", 9F);
            bt_reg.Click += bt_reg_Click;
            // 
            // RegBadgePage
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1445, 845);
            Controls.Add(bt_reg);
            Controls.Add(tb_seedBadge);
            Controls.Add(cb_rothBadge);
            Controls.Add(lb_seedBadge);
            Name = "RegBadgePage";
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
        private Sunny.UI.UILabel lb_seedBadge;
        private Sunny.UI.UICheckBox cb_rothBadge;
        private Sunny.UI.UITextBox tb_seedBadge;
        private Sunny.UI.UIButton bt_reg;
    }
}