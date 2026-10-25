using Sunny.UI;
namespace OX.Tablet
{
    partial class DepositUSDTForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepositUSDTForm));
            btnCancel = new UIButton();
            btOK = new UIButton();
            tb_amount = new UINumPadTextBox();
            lb_amount = new UILabel();
            bt_query_balance = new UIButton();
            tb_ether_balance = new UITextBox();
            lb_ether_balance = new UILabel();
            tb_usdt_balance = new UITextBox();
            lb_usdt_balance = new UILabel();
            SuspendLayout();
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btOK
            // 
            resources.ApplyResources(btOK, "btOK");
            btOK.Name = "btOK";
            btOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btOK.Click += btOK_Click;
            // 
            // tb_amount
            // 
            tb_amount.FillColor = Color.White;
            resources.ApplyResources(tb_amount, "tb_amount");
            tb_amount.Maximum = 100000000D;
            tb_amount.Minimum = 100D;
            tb_amount.Name = "tb_amount";
            tb_amount.NumPadType = NumPadType.Double;
            tb_amount.SymbolSize = 24;
            tb_amount.TextAlignment = ContentAlignment.MiddleLeft;
            tb_amount.Watermark = "";
            // 
            // lb_amount
            // 
            resources.ApplyResources(lb_amount, "lb_amount");
            lb_amount.ForeColor = Color.FromArgb(48, 48, 48);
            lb_amount.Name = "lb_amount";
            // 
            // bt_query_balance
            // 
            resources.ApplyResources(bt_query_balance, "bt_query_balance");
            bt_query_balance.Name = "bt_query_balance";
            bt_query_balance.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_query_balance.Click += bt_query_balance_Click;
            // 
            // tb_ether_balance
            // 
            tb_ether_balance.Cursor = Cursors.IBeam;
            tb_ether_balance.EnterAsTab = true;
            resources.ApplyResources(tb_ether_balance, "tb_ether_balance");
            tb_ether_balance.Name = "tb_ether_balance";
            tb_ether_balance.ReadOnly = true;
            tb_ether_balance.ShowText = false;
            tb_ether_balance.TextAlignment = ContentAlignment.MiddleLeft;
            tb_ether_balance.Watermark = "";
            // 
            // lb_ether_balance
            // 
            resources.ApplyResources(lb_ether_balance, "lb_ether_balance");
            lb_ether_balance.ForeColor = Color.FromArgb(48, 48, 48);
            lb_ether_balance.Name = "lb_ether_balance";
            // 
            // tb_usdt_balance
            // 
            tb_usdt_balance.Cursor = Cursors.IBeam;
            tb_usdt_balance.EnterAsTab = true;
            resources.ApplyResources(tb_usdt_balance, "tb_usdt_balance");
            tb_usdt_balance.Name = "tb_usdt_balance";
            tb_usdt_balance.ReadOnly = true;
            tb_usdt_balance.ShowText = false;
            tb_usdt_balance.TextAlignment = ContentAlignment.MiddleLeft;
            tb_usdt_balance.Watermark = "";
            // 
            // lb_usdt_balance
            // 
            resources.ApplyResources(lb_usdt_balance, "lb_usdt_balance");
            lb_usdt_balance.ForeColor = Color.FromArgb(48, 48, 48);
            lb_usdt_balance.Name = "lb_usdt_balance";
            // 
            // DepositUSDTForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            ControlBox = false;
            Controls.Add(bt_query_balance);
            Controls.Add(tb_ether_balance);
            Controls.Add(lb_ether_balance);
            Controls.Add(tb_usdt_balance);
            Controls.Add(lb_usdt_balance);
            Controls.Add(tb_amount);
            Controls.Add(lb_amount);
            Controls.Add(btOK);
            Controls.Add(btnCancel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DepositUSDTForm";
            ZoomScaleRect = new Rectangle(22, 22, 528, 290);
            FormClosing += ClaimForm_FormClosing;
            Load += ClaimForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UIButton btnCancel;
        private UIButton btOK;
        private UINumPadTextBox tb_amount;
        private UILabel lb_amount;
        private UIButton bt_query_balance;
        private UITextBox tb_ether_balance;
        private UILabel lb_ether_balance;
        private UITextBox tb_usdt_balance;
        private UILabel lb_usdt_balance;
    }
}