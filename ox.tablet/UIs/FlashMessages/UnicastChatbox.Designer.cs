
namespace OX.Tablet.FlashMessages
{
	partial class UnicastChatbox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnicastChatbox));
            topPanel = new Panel();
            talkLabel = new Label();
            bottomPanel = new Panel();
            chatTextbox = new TextBox();
            attachButton = new Button();
            sendButton = new Button();
            itemsPanel = new Panel();
            topPanel.SuspendLayout();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.RoyalBlue;
            topPanel.Controls.Add(talkLabel);
            topPanel.Dock = DockStyle.Top;
            topPanel.ForeColor = SystemColors.ButtonHighlight;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(6, 5, 6, 5);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(10, 5, 5, 10);
            topPanel.Size = new Size(1324, 63);
            topPanel.TabIndex = 0;
            topPanel.Paint += topPanel_Paint;
            // 
            // talkLabel
            // 
            talkLabel.AutoSize = true;
            talkLabel.Dock = DockStyle.Top;
            talkLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            talkLabel.ForeColor = SystemColors.ControlLightLight;
            talkLabel.Location = new Point(10, 5);
            talkLabel.Margin = new Padding(6, 0, 6, 0);
            talkLabel.Name = "talkLabel";
            talkLabel.Size = new Size(149, 32);
            talkLabel.TabIndex = 0;
            talkLabel.Text = "Client Name";
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = Color.RoyalBlue;
            bottomPanel.Controls.Add(chatTextbox);
            bottomPanel.Controls.Add(attachButton);
            bottomPanel.Controls.Add(sendButton);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.ForeColor = SystemColors.ControlLightLight;
            bottomPanel.Location = new Point(0, 1013);
            bottomPanel.Margin = new Padding(6, 5, 6, 5);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(28, 19, 28, 19);
            bottomPanel.Size = new Size(1324, 99);
            bottomPanel.TabIndex = 1;
            // 
            // chatTextbox
            // 
            chatTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chatTextbox.Location = new Point(10, 19);
            chatTextbox.Margin = new Padding(6, 5, 6, 5);
            chatTextbox.Multiline = true;
            chatTextbox.Name = "chatTextbox";
            chatTextbox.Size = new Size(1041, 61);
            chatTextbox.TabIndex = 7;
            // 
            // attachButton
            // 
            attachButton.BackColor = Color.GhostWhite;
            attachButton.BackgroundImage = (Image)resources.GetObject("attachButton.BackgroundImage");
            attachButton.BackgroundImageLayout = ImageLayout.Center;
            attachButton.Dock = DockStyle.Right;
            attachButton.FlatStyle = FlatStyle.Flat;
            attachButton.ForeColor = SystemColors.ControlText;
            attachButton.ImageAlign = ContentAlignment.MiddleLeft;
            attachButton.Location = new Point(1051, 19);
            attachButton.Margin = new Padding(6, 5, 6, 5);
            attachButton.Name = "attachButton";
            attachButton.Size = new Size(64, 61);
            attachButton.TabIndex = 6;
            attachButton.TextAlign = ContentAlignment.MiddleRight;
            attachButton.UseVisualStyleBackColor = false;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.RoyalBlue;
            sendButton.Dock = DockStyle.Right;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            sendButton.Location = new Point(1115, 19);
            sendButton.Margin = new Padding(6, 5, 6, 5);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(181, 61);
            sendButton.TabIndex = 1;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = false;
            // 
            // itemsPanel
            // 
            itemsPanel.AutoScroll = true;
            itemsPanel.Dock = DockStyle.Fill;
            itemsPanel.Location = new Point(0, 63);
            itemsPanel.Margin = new Padding(6, 5, 6, 5);
            itemsPanel.Name = "itemsPanel";
            itemsPanel.Size = new Size(1324, 950);
            itemsPanel.TabIndex = 2;
            // 
            // UnicastChatbox
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(itemsPanel);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
            Margin = new Padding(6, 5, 6, 5);
            Name = "UnicastChatbox";
            Size = new Size(1324, 1112);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Label talkLabel;
		private System.Windows.Forms.Panel bottomPanel;
		private System.Windows.Forms.Button sendButton;
		private System.Windows.Forms.Button attachButton;
		private System.Windows.Forms.TextBox chatTextbox;
        private System.Windows.Forms.Panel itemsPanel;
	}
}
