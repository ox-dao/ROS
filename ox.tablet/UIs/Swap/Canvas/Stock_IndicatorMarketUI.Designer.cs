
namespace OX.Tablet.UIs.Swap.Canvas
{
    partial class Stock_IndicatorMarketUI
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
            doubleemA_CandlesViewCanvas1 = new DoubleEMA_CandlesViewCanvas();
            SuspendLayout();
            // 
            // doubleemA_CandlesViewCanvas1
            // 
            doubleemA_CandlesViewCanvas1.AreaSplit = 60;
            doubleemA_CandlesViewCanvas1.AxisSpace = 8;
            doubleemA_CandlesViewCanvas1.CrossHairColor = Color.White;
            doubleemA_CandlesViewCanvas1.Dock = DockStyle.Fill;
            doubleemA_CandlesViewCanvas1.FirstRecord = 0;
            doubleemA_CandlesViewCanvas1.GridColor = Color.Gray;
            doubleemA_CandlesViewCanvas1.Location = new Point(0, 0);
            doubleemA_CandlesViewCanvas1.Name = "doubleemA_CandlesViewCanvas1";
            doubleemA_CandlesViewCanvas1.RightPixSpace = 0;
            doubleemA_CandlesViewCanvas1.ShowCrossHair = false;
            doubleemA_CandlesViewCanvas1.Size = new Size(800, 450);
            doubleemA_CandlesViewCanvas1.StockFont = new Font("Microsoft Sans Serif", 9F);
            doubleemA_CandlesViewCanvas1.TabIndex = 0;
            doubleemA_CandlesViewCanvas1.Text = "doubleemA_CandlesViewCanvas1";
            doubleemA_CandlesViewCanvas1.YanColor = Color.Green;
            doubleemA_CandlesViewCanvas1.YinColor = Color.Red;
            // 
            // CTAGridAdapter_Max_IndicatorMarketUI
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(doubleemA_CandlesViewCanvas1);
            Name = "CTAGridAdapter_Max_IndicatorMarketUI";
            Size = new Size(800, 450);
            ResumeLayout(false);
        }

        #endregion

        private DoubleEMA_CandlesViewCanvas doubleemA_CandlesViewCanvas1;
    }
}