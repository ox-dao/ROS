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
            lb_msg = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // lb_msg
            // 
            lb_msg.Font = new Font("微软雅黑", 12F);
            lb_msg.ForeColor = Color.White;
            lb_msg.Location = new Point(100, 100);
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
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "RefreshGithubSeedForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UnlockAccountForm";
            TopMost = true;
            FormClosing += UnlockAccountForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel lb_msg;
    }
}