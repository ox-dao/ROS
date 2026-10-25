namespace OX.Tablet.FlashMessages
{
    partial class MulticastSubPage
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
            CastPanel = new Sunny.UI.UIPanel();
            lb_contact = new Sunny.UI.UIListBox();
            bt_add_unicast = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // CastPanel
            // 
            CastPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CastPanel.Font = new Font("宋体", 12F);
            CastPanel.Location = new Point(3, 1);
            CastPanel.Margin = new Padding(4, 5, 4, 5);
            CastPanel.MinimumSize = new Size(1, 1);
            CastPanel.Name = "CastPanel";
            CastPanel.Size = new Size(1114, 842);
            CastPanel.TabIndex = 0;
            CastPanel.Text = null;
            CastPanel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lb_contact
            // 
            lb_contact.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lb_contact.Font = new Font("宋体", 12F);
            lb_contact.HoverColor = Color.FromArgb(155, 200, 255);
            lb_contact.ItemSelectForeColor = Color.White;
            lb_contact.Location = new Point(1125, 87);
            lb_contact.Margin = new Padding(4, 5, 4, 5);
            lb_contact.MinimumSize = new Size(1, 1);
            lb_contact.Name = "lb_contact";
            lb_contact.Padding = new Padding(2);
            lb_contact.ShowText = false;
            lb_contact.Size = new Size(314, 756);
            lb_contact.TabIndex = 0;
            lb_contact.Text = "uiListBox1";
            lb_contact.MouseDown += lb_contact_MouseDown;
            lb_contact.SelectedIndexChanged += lb_contact_SelectedIndexChanged;
            // 
            // bt_add_unicast
            // 
            bt_add_unicast.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_add_unicast.Font = new Font("微软雅黑", 12F);
            bt_add_unicast.Location = new Point(1125, 18);
            bt_add_unicast.MinimumSize = new Size(1, 1);
            bt_add_unicast.Name = "bt_add_unicast";
            bt_add_unicast.Size = new Size(308, 52);
            bt_add_unicast.TabIndex = 17;
            bt_add_unicast.Text = "uiButton1";
            bt_add_unicast.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_add_unicast.Click += bt_add_unicast_Click;
            // 
            // MulticastSubPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1445, 845);
            Controls.Add(bt_add_unicast);
            Controls.Add(lb_contact);
            Controls.Add(CastPanel);
            Name = "MulticastSubPage";
            Text = "PlazaForm";
            Initialize += OrderHistory_Initialize;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UIPanel CastPanel;
        private Sunny.UI.UIListBox lb_contact;
        private Sunny.UI.UIButton bt_add_unicast;
    }
}