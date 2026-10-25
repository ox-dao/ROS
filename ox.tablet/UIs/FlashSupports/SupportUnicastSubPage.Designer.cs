namespace OX.Tablet.FlashSupports
{
    partial class SupportUnicastSubPage
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
            SuspendLayout();
            // 
            // CastPanel
            // 
            CastPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CastPanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CastPanel.Location = new System.Drawing.Point(3, 1);
            CastPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            CastPanel.MinimumSize = new System.Drawing.Size(1, 1);
            CastPanel.Name = "CastPanel";
            CastPanel.Size = new System.Drawing.Size(1027, 842);
            CastPanel.TabIndex = 0;
            CastPanel.Text = null;
            CastPanel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_contact
            // 
            lb_contact.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lb_contact.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_contact.HoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            lb_contact.ItemSelectForeColor = System.Drawing.Color.White;
            lb_contact.Location = new System.Drawing.Point(1038, 14);
            lb_contact.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            lb_contact.MinimumSize = new System.Drawing.Size(1, 1);
            lb_contact.Name = "lb_contact";
            lb_contact.Padding = new System.Windows.Forms.Padding(2);
            lb_contact.ShowText = false;
            lb_contact.Size = new System.Drawing.Size(401, 829);
            lb_contact.TabIndex = 0;
            lb_contact.Text = "uiListBox1";
            lb_contact.SelectedIndexChanged += lb_contact_SelectedIndexChanged;
            // 
            // SupportUnicastSubPage
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1445, 845);
            Controls.Add(lb_contact);
            Controls.Add(CastPanel);
            Name = "SupportUnicastSubPage";
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
    }
}