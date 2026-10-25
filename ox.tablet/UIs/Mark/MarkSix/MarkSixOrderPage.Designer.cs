namespace OX.Tablet.UIs.MarkSix
{
    partial class MarkSixOrderPage
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
            pn_ports = new Sunny.UI.UIFlowLayoutPanel();
            SuspendLayout();
            // 
            // pn_ports
            // 
            pn_ports.Dock = System.Windows.Forms.DockStyle.Fill;
            pn_ports.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pn_ports.Location = new System.Drawing.Point(0, 0);
            pn_ports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pn_ports.MinimumSize = new System.Drawing.Size(1, 1);
            pn_ports.Name = "pn_ports";
            pn_ports.Padding = new System.Windows.Forms.Padding(2);
            pn_ports.ShowText = false;
            pn_ports.Size = new System.Drawing.Size(611, 845);
            pn_ports.TabIndex = 0;
            pn_ports.Text = "uiFlowLayoutPanel1";
            pn_ports.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MarkSixOrderPage
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(611, 845);
            Controls.Add(pn_ports);
            Name = "MarkSixOrderPage";
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
        private Sunny.UI.UIFlowLayoutPanel pn_ports;
    }
}