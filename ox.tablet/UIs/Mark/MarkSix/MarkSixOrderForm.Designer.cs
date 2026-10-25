namespace OX.Tablet.UIs.Mark.MarkSix
{
    partial class MarkSixOrderForm
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
            tb_rounds = new Sunny.UI.UITabControl();
            bt_close = new Sunny.UI.UIButton();
            bt_order = new Sunny.UI.UIButton();
            lb_amount = new Sunny.UI.UILabel();
            lb_msg = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // tb_rounds
            // 
            tb_rounds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_rounds.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            tb_rounds.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tb_rounds.ItemSize = new System.Drawing.Size(150, 40);
            tb_rounds.Location = new System.Drawing.Point(0, 35);
            tb_rounds.MainPage = "";
            tb_rounds.Name = "tb_rounds";
            tb_rounds.SelectedIndex = 0;
            tb_rounds.Size = new System.Drawing.Size(1249, 719);
            tb_rounds.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tb_rounds.TabIndex = 0;
            tb_rounds.TabUnSelectedForeColor = System.Drawing.Color.FromArgb(240, 240, 240);
            tb_rounds.SelectedIndexChanged += tb_rounds_SelectedIndexChanged;
            // 
            // bt_close
            // 
            bt_close.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            bt_close.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            bt_close.Location = new System.Drawing.Point(1092, 776);
            bt_close.MinimumSize = new System.Drawing.Size(1, 1);
            bt_close.Name = "bt_close";
            bt_close.Size = new System.Drawing.Size(128, 52);
            bt_close.TabIndex = 15;
            bt_close.Text = " ";
            bt_close.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            bt_close.Click += bt_close_Click;
            // 
            // bt_order
            // 
            bt_order.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            bt_order.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            bt_order.Location = new System.Drawing.Point(901, 776);
            bt_order.MinimumSize = new System.Drawing.Size(1, 1);
            bt_order.Name = "bt_order";
            bt_order.Size = new System.Drawing.Size(128, 52);
            bt_order.TabIndex = 16;
            bt_order.Text = " ";
            bt_order.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            bt_order.Click += bt_order_Click;
            // 
            // lb_amount
            // 
            lb_amount.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lb_amount.AutoSize = true;
            lb_amount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_amount.ForeColor = System.Drawing.Color.FromArgb(56, 56, 56);
            lb_amount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lb_amount.Location = new System.Drawing.Point(46, 768);
            lb_amount.Name = "lb_amount";
            lb_amount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lb_amount.Size = new System.Drawing.Size(0, 24);
            lb_amount.TabIndex = 17;
            lb_amount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_msg
            // 
            lb_msg.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lb_msg.AutoSize = true;
            lb_msg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_msg.ForeColor = System.Drawing.Color.FromArgb(56, 56, 56);
            lb_msg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lb_msg.Location = new System.Drawing.Point(46, 805);
            lb_msg.Name = "lb_msg";
            lb_msg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lb_msg.Size = new System.Drawing.Size(0, 24);
            lb_msg.TabIndex = 18;
            lb_msg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lb_msg.Click += uiLabel1_Click;
            // 
            // MarkSixOrderForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1249, 846);
            ControlBox = false;
            Controls.Add(lb_msg);
            Controls.Add(lb_amount);
            Controls.Add(bt_order);
            Controls.Add(bt_close);
            Controls.Add(tb_rounds);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MarkSixOrderForm";
            Text = "MarkSixOrderForm";
            ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 800, 450);
            Load += MarkSixOrderForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UITabControl tb_rounds;
        private Sunny.UI.UIButton bt_close;
        private Sunny.UI.UIButton bt_order;
        private Sunny.UI.UILabel lb_amount;
        private Sunny.UI.UILabel lb_msg;
    }
}