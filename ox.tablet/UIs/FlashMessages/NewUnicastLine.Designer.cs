namespace OX.Tablet.FlashMessages
{
    partial class NewUnicastLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUnicastLine));
            bt_register = new Sunny.UI.UIButton();
            lb_remote = new Sunny.UI.UILabel();
            bt_exit = new Sunny.UI.UIButton();
            tb_remotePubkey = new Sunny.UI.UITextBox();
            SuspendLayout();
            // 
            // bt_register
            // 
            bt_register.Font = new Font("微软雅黑", 12F);
            bt_register.Location = new Point(550, 95);
            bt_register.MinimumSize = new Size(1, 1);
            bt_register.Name = "bt_register";
            bt_register.Size = new Size(191, 52);
            bt_register.TabIndex = 5;
            bt_register.Text = "uiButton1";
            bt_register.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_register.Click += bt_register_Click;
            // 
            // lb_remote
            // 
            lb_remote.AutoSize = true;
            lb_remote.Font = new Font("微软雅黑", 12F);
            lb_remote.ForeColor = Color.White;
            lb_remote.Location = new Point(12, 26);
            lb_remote.Name = "lb_remote";
            lb_remote.Size = new Size(109, 31);
            lb_remote.TabIndex = 4;
            lb_remote.Text = "uiLabel1";
            // 
            // bt_exit
            // 
            bt_exit.Font = new Font("微软雅黑", 12F);
            bt_exit.Location = new Point(780, 95);
            bt_exit.MinimumSize = new Size(1, 1);
            bt_exit.Name = "bt_exit";
            bt_exit.Size = new Size(191, 52);
            bt_exit.TabIndex = 17;
            bt_exit.Text = "uiButton1";
            bt_exit.TipsFont = new Font("微软雅黑", 9F);
            bt_exit.Click += bt_exit_Click;
            // 
            // tb_remotePubkey
            // 
            tb_remotePubkey.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tb_remotePubkey.Location = new Point(222, 26);
            tb_remotePubkey.Margin = new Padding(4, 5, 4, 5);
            tb_remotePubkey.MinimumSize = new Size(1, 16);
            tb_remotePubkey.Name = "tb_remotePubkey";
            tb_remotePubkey.Padding = new Padding(5);
            tb_remotePubkey.ShowText = false;
            tb_remotePubkey.Size = new Size(749, 44);
            tb_remotePubkey.TabIndex = 18;
            tb_remotePubkey.TextAlignment = ContentAlignment.MiddleLeft;
            tb_remotePubkey.Watermark = "";
            // 
            // NewUnicastLine
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.FromArgb(56, 56, 56);
            ClientSize = new Size(992, 188);
            ControlBox = false;
            Controls.Add(tb_remotePubkey);
            Controls.Add(bt_exit);
            Controls.Add(bt_register);
            Controls.Add(lb_remote);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "NewUnicastLine";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "UnlockAccountForm";
            TopMost = true;
            FormClosing += NewAccountForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIButton bt_register;
        private Sunny.UI.UILabel lb_remote;
        private Sunny.UI.UIButton bt_exit;
        private Sunny.UI.UITextBox tb_remotePubkey;
    }
}