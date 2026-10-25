using Sunny.UI;
using System.Windows.Forms;
namespace OX.Tablet.UIs.MarkSix
{
    partial class AdminRechargeMemberForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminRechargeMemberForm));
            panel = new Panel();
            agentSetting1 = new AgentSetting();
            st_kind = new UISwitch();
            lb_kind = new UILabel();
            lb_leaderHolder = new UILabel();
            tb_leaderHolder = new UINumPadTextBox();
            bt_close = new UIButton();
            darkLabel5 = new UILabel();
            tb_balance = new UITextBox();
            lb_balance = new UILabel();
            bt_NewRoom = new UIButton();
            darkLabel1 = new UILabel();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(agentSetting1);
            panel.Controls.Add(st_kind);
            panel.Controls.Add(lb_kind);
            panel.Controls.Add(lb_leaderHolder);
            panel.Controls.Add(tb_leaderHolder);
            panel.Controls.Add(bt_close);
            panel.Controls.Add(darkLabel5);
            panel.Controls.Add(tb_balance);
            panel.Controls.Add(lb_balance);
            panel.Controls.Add(bt_NewRoom);
            resources.ApplyResources(panel, "panel");
            panel.Name = "panel";
            panel.Paint += panel_Paint;
            // 
            // agentSetting1
            // 
            agentSetting1.BackColor = System.Drawing.Color.Gray;
            agentSetting1.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(agentSetting1, "agentSetting1");
            agentSetting1.Name = "agentSetting1";
            // 
            // st_kind
            // 
            resources.ApplyResources(st_kind, "st_kind");
            st_kind.Name = "st_kind";
            st_kind.SwitchShape = UISwitch.UISwitchShape.Square;
            st_kind.ValueChanged += st_kind_ValueChanged;
            // 
            // lb_kind
            // 
            resources.ApplyResources(lb_kind, "lb_kind");
            lb_kind.ForeColor = System.Drawing.Color.Black;
            lb_kind.Name = "lb_kind";
            // 
            // lb_leaderHolder
            // 
            resources.ApplyResources(lb_leaderHolder, "lb_leaderHolder");
            lb_leaderHolder.ForeColor = System.Drawing.Color.Black;
            lb_leaderHolder.Name = "lb_leaderHolder";
            // 
            // tb_leaderHolder
            // 
            tb_leaderHolder.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(tb_leaderHolder, "tb_leaderHolder");
            tb_leaderHolder.Maximum = 9999D;
            tb_leaderHolder.Minimum = 8000D;
            tb_leaderHolder.Name = "tb_leaderHolder";
            tb_leaderHolder.NumPadType = NumPadType.Integer;
            tb_leaderHolder.SymbolSize = 24;
            tb_leaderHolder.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tb_leaderHolder.Watermark = "";
            // 
            // bt_close
            // 
            resources.ApplyResources(bt_close, "bt_close");
            bt_close.Name = "bt_close";
            bt_close.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            bt_close.Click += bt_close_Click;
            // 
            // darkLabel5
            // 
            resources.ApplyResources(darkLabel5, "darkLabel5");
            darkLabel5.ForeColor = System.Drawing.Color.Black;
            darkLabel5.Name = "darkLabel5";
            // 
            // tb_balance
            // 
            tb_balance.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
            resources.ApplyResources(tb_balance, "tb_balance");
            tb_balance.ForeColor = System.Drawing.Color.Black;
            tb_balance.MaxLength = 20;
            tb_balance.Name = "tb_balance";
            tb_balance.ReadOnly = true;
            tb_balance.ShowText = false;
            tb_balance.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tb_balance.Watermark = "";
            // 
            // lb_balance
            // 
            resources.ApplyResources(lb_balance, "lb_balance");
            lb_balance.ForeColor = System.Drawing.Color.Black;
            lb_balance.Name = "lb_balance";
            // 
            // bt_NewRoom
            // 
            resources.ApplyResources(bt_NewRoom, "bt_NewRoom");
            bt_NewRoom.Name = "bt_NewRoom";
            bt_NewRoom.Click += bt_NewRoom_Click;
            // 
            // darkLabel1
            // 
            resources.ApplyResources(darkLabel1, "darkLabel1");
            darkLabel1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel1.Name = "darkLabel1";
            // 
            // AdminRechargeMemberForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            ControlBox = false;
            Controls.Add(panel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminRechargeMemberForm";
            ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 1247, 878);
            FormClosing += ClaimForm_FormClosing;
            Load += ClaimForm_Load;
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private UIButton bt_NewRoom;
        private UILabel darkLabel1;
        private UILabel lb_balance;
        private UITextBox tb_balance;
        private UILabel darkLabel5;
        private UIButton bt_close;
        private UINumPadTextBox tb_leaderHolder;
        private UILabel lb_leaderHolder;
        private UILabel lb_kind;
        private UISwitch st_kind;
        private AgentSetting agentSetting1;
    }
}