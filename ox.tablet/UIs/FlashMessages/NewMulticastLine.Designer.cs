namespace OX.Tablet.FlashMessages
{
    partial class NewMulticastLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMulticastLine));
            bt_register = new Sunny.UI.UIButton();
            lb_remote = new Sunny.UI.UILabel();
            bt_exit = new Sunny.UI.UIButton();
            tb_remotePubkey = new Sunny.UI.UITextBox();
            tb_lineName = new Sunny.UI.UITextBox();
            lb_lineName = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // bt_register
            // 
            bt_register.Font = new Font("微软雅黑", 12F);
            bt_register.Location = new Point(550, 169);
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
            bt_exit.Location = new Point(780, 169);
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
            // tb_lineName
            // 
            tb_lineName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tb_lineName.Location = new Point(223, 98);
            tb_lineName.Margin = new Padding(4, 5, 4, 5);
            tb_lineName.MinimumSize = new Size(1, 16);
            tb_lineName.Name = "tb_lineName";
            tb_lineName.Padding = new Padding(5);
            tb_lineName.ShowText = false;
            tb_lineName.Size = new Size(749, 44);
            tb_lineName.TabIndex = 20;
            tb_lineName.TextAlignment = ContentAlignment.MiddleLeft;
            tb_lineName.Watermark = "";
            // 
            // lb_lineName
            // 
            lb_lineName.AutoSize = true;
            lb_lineName.Font = new Font("微软雅黑", 12F);
            lb_lineName.ForeColor = Color.White;
            lb_lineName.Location = new Point(13, 98);
            lb_lineName.Name = "lb_lineName";
            lb_lineName.Size = new Size(109, 31);
            lb_lineName.TabIndex = 19;
            lb_lineName.Text = "uiLabel1";
            // 
            // NewMulticastLine
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.FromArgb(56, 56, 56);
            ClientSize = new Size(992, 241);
            ControlBox = false;
            Controls.Add(tb_lineName);
            Controls.Add(lb_lineName);
            Controls.Add(tb_remotePubkey);
            Controls.Add(bt_exit);
            Controls.Add(bt_register);
            Controls.Add(lb_remote);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "NewMulticastLine";
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
        private Sunny.UI.UITextBox tb_lineName;
        private Sunny.UI.UILabel lb_lineName;
    }
}