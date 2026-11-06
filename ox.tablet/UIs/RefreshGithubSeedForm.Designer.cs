namespace OX.Tablet
{
    partial class RefreshGithubSeedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefreshGithubSeedForm));
            bt_exit = new Sunny.UI.UIButton();
            lb_msg = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // bt_exit
            // 
            bt_exit.Font = new Font("微软雅黑", 12F);
            bt_exit.Location = new Point(301, 165);
            bt_exit.MinimumSize = new Size(1, 1);
            bt_exit.Name = "bt_exit";
            bt_exit.Size = new Size(196, 52);
            bt_exit.TabIndex = 3;
            bt_exit.Text = "uiButton1";
            bt_exit.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_exit.Click += bt_exit_Click;
            // 
            // lb_msg
            // 
            lb_msg.Font = new Font("微软雅黑", 12F);
            lb_msg.ForeColor = Color.White;
            lb_msg.Location = new Point(113, 89);
            lb_msg.Name = "lb_msg";
            lb_msg.Size = new Size(328, 34);
            lb_msg.TabIndex = 5;
            // 
            // RefreshGithubSeedForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.FromArgb(56, 56, 56);
            ClientSize = new Size(533, 239);
            ControlBox = false;
            Controls.Add(lb_msg);
            Controls.Add(bt_exit);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "RefreshGithubSeedForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "UnlockAccountForm";
            TopMost = true;
            FormClosing += UnlockAccountForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIButton bt_exit;
        private Sunny.UI.UILabel lb_msg;
    }
}