namespace OX.Tablet
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            uiPanel1 = new Sunny.UI.UIPanel();
            lb_msg = new Sunny.UI.UIMarkLabel();
            lb_accountIndex = new Sunny.UI.UIMarkLabel();
            lb_blockchain_nodes = new Sunny.UI.UIMarkLabel();
            lb_blockchain_state = new Sunny.UI.UIMarkLabel();
            uiPanel2 = new Sunny.UI.UIPanel();
            Box = new Sunny.UI.UISplitContainer();
            MainMenu = new Sunny.UI.UINavMenu();
            ContentPanel = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            uiPanel1.SuspendLayout();
            uiPanel2.SuspendLayout();
            (Box).BeginInit();
            Box.Panel1.SuspendLayout();
            Box.Panel2.SuspendLayout();
            Box.SuspendLayout();
            SuspendLayout();
            // 
            // uiPanel1
            // 
            uiPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPanel1.Controls.Add(lb_msg);
            uiPanel1.Controls.Add(lb_accountIndex);
            uiPanel1.Controls.Add(lb_blockchain_nodes);
            uiPanel1.Controls.Add(lb_blockchain_state);
            uiPanel1.Font = new Font("微软雅黑", 12F);
            uiPanel1.Location = new Point(0, 905);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.RectColor = Color.Transparent;
            uiPanel1.Size = new Size(1511, 40);
            uiPanel1.TabIndex = 0;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lb_msg
            // 
            lb_msg.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lb_msg.Font = new Font("微软雅黑", 11F);
            lb_msg.ForeColor = Color.FromArgb(56, 56, 56);
            lb_msg.Location = new Point(786, 6);
            lb_msg.Name = "lb_msg";
            lb_msg.Padding = new Padding(5, 0, 0, 0);
            lb_msg.RightToLeft = RightToLeft.No;
            lb_msg.Size = new Size(722, 34);
            lb_msg.TabIndex = 14;
            lb_msg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_accountIndex
            // 
            lb_accountIndex.Font = new Font("微软雅黑", 11F);
            lb_accountIndex.ForeColor = Color.FromArgb(48, 48, 48);
            lb_accountIndex.Location = new Point(480, 6);
            lb_accountIndex.Name = "lb_accountIndex";
            lb_accountIndex.Padding = new Padding(5, 0, 0, 0);
            lb_accountIndex.Size = new Size(251, 34);
            lb_accountIndex.TabIndex = 2;
            // 
            // lb_blockchain_nodes
            // 
            lb_blockchain_nodes.Font = new Font("微软雅黑", 11F);
            lb_blockchain_nodes.ForeColor = Color.FromArgb(48, 48, 48);
            lb_blockchain_nodes.Location = new Point(10, 6);
            lb_blockchain_nodes.Name = "lb_blockchain_nodes";
            lb_blockchain_nodes.Padding = new Padding(5, 0, 0, 0);
            lb_blockchain_nodes.Size = new Size(163, 34);
            lb_blockchain_nodes.TabIndex = 1;
            // 
            // lb_blockchain_state
            // 
            lb_blockchain_state.Font = new Font("微软雅黑", 11F);
            lb_blockchain_state.ForeColor = Color.FromArgb(48, 48, 48);
            lb_blockchain_state.Location = new Point(206, 6);
            lb_blockchain_state.Name = "lb_blockchain_state";
            lb_blockchain_state.Padding = new Padding(5, 0, 0, 0);
            lb_blockchain_state.Size = new Size(251, 34);
            lb_blockchain_state.TabIndex = 0;
            // 
            // uiPanel2
            // 
            uiPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPanel2.Controls.Add(Box);
            uiPanel2.Font = new Font("微软雅黑", 12F);
            uiPanel2.Location = new Point(0, 36);
            uiPanel2.Margin = new Padding(4, 5, 4, 5);
            uiPanel2.MinimumSize = new Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.Size = new Size(1511, 869);
            uiPanel2.TabIndex = 1;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // Box
            // 
            Box.Dock = DockStyle.Fill;
            Box.Location = new Point(0, 0);
            Box.MinimumSize = new Size(20, 20);
            Box.Name = "Box";
            // 
            // Box.Panel1
            // 
            Box.Panel1.Controls.Add(MainMenu);
            // 
            // Box.Panel2
            // 
            Box.Panel2.Controls.Add(ContentPanel);
            Box.Size = new Size(1511, 869);
            Box.SplitterDistance = 189;
            Box.SplitterWidth = 30;
            Box.TabIndex = 0;
            // 
            // MainMenu
            // 
            MainMenu.BorderStyle = BorderStyle.None;
            MainMenu.Dock = DockStyle.Fill;
            MainMenu.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            MainMenu.Font = new Font("微软雅黑", 16F);
            MainMenu.FullRowSelect = true;
            MainMenu.HotTracking = true;
            MainMenu.HoverColor = Color.FromArgb(80, 160, 255);
            MainMenu.ItemHeight = 100;
            MainMenu.Location = new Point(0, 0);
            MainMenu.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            MainMenu.Name = "MainMenu";
            MainMenu.ShowLines = false;
            MainMenu.ShowPlusMinus = false;
            MainMenu.ShowRootLines = false;
            MainMenu.Size = new Size(189, 869);
            MainMenu.TabIndex = 0;
            MainMenu.TipsFont = new Font("微软雅黑", 9F);
            MainMenu.MenuItemClick += MainMenu_MenuItemClick;
            // 
            // ContentPanel
            // 
            ContentPanel.Dock = DockStyle.Fill;
            ContentPanel.Location = new Point(0, 0);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Size = new Size(1292, 869);
            ContentPanel.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.Click += notifyIcon1_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1515, 947);
            ControlBox = false;
            Controls.Add(uiPanel2);
            Controls.Add(uiPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(2160, 1380);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            ZoomScaleRect = new Rectangle(22, 22, 800, 450);
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            uiPanel1.ResumeLayout(false);
            uiPanel2.ResumeLayout(false);
            Box.Panel1.ResumeLayout(false);
            Box.Panel2.ResumeLayout(false);
            (Box).EndInit();
            Box.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UISplitContainer Box;
        private Sunny.UI.UINavMenu MainMenu;
        private Sunny.UI.UIMarkLabel lb_blockchain_state;
        private Sunny.UI.UIMarkLabel lb_blockchain_nodes;
        private System.Windows.Forms.Panel ContentPanel;
        private Sunny.UI.UIMarkLabel lb_accountIndex;
        private System.Windows.Forms.Timer timer1;
        public Sunny.UI.UIMarkLabel lb_msg;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}