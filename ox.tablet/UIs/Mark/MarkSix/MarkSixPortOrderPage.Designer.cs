namespace OX.Tablet.UIs.MarkSix
{
    partial class MarkSixPortOrderPage
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
            tv_inbound_orders = new System.Windows.Forms.TreeView();
            SuspendLayout();
            // 
            // tv_inbound_orders
            // 
            tv_inbound_orders.AllowDrop = true;
            tv_inbound_orders.Dock = System.Windows.Forms.DockStyle.Fill;
            tv_inbound_orders.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tv_inbound_orders.ItemHeight = 58;
            tv_inbound_orders.Location = new System.Drawing.Point(0, 0);
            tv_inbound_orders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tv_inbound_orders.MinimumSize = new System.Drawing.Size(1, 1);
            tv_inbound_orders.Name = "tv_inbound_orders";
            tv_inbound_orders.ShowLines = true;
            tv_inbound_orders.Size = new System.Drawing.Size(611, 845);
            tv_inbound_orders.TabIndex = 1;
            tv_inbound_orders.Text = "uiTreeView1";
            tv_inbound_orders.BeforeCheck += tv_inbound_orders_BeforeCheck;
            // 
            // MarkSixPlayerOrderPage
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(611, 845);
            Controls.Add(tv_inbound_orders);
            Name = "MarkSixPlayerOrderPage";
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
        private System.Windows.Forms.TreeView tv_inbound_orders;
    }
}