namespace OX.Tablet.UIs.Rothschild
{
    partial class RothschildPage
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
            tbc_sections = new Sunny.UI.UITabControl();
            SuspendLayout();
            // 
            // tbc_sections
            // 
            tbc_sections.Dock = DockStyle.Fill;
            tbc_sections.DrawMode = TabDrawMode.OwnerDrawFixed;
            tbc_sections.Font = new Font("微软雅黑", 12F);
            tbc_sections.ItemSize = new Size(200, 40);
            tbc_sections.Location = new Point(0, 0);
            tbc_sections.MainPage = "";
            tbc_sections.Margin = new Padding(2);
            tbc_sections.Name = "tbc_sections";
            tbc_sections.SelectedIndex = 0;
            tbc_sections.Size = new Size(1539, 738);
            tbc_sections.SizeMode = TabSizeMode.Fixed;
            tbc_sections.TabIndex = 1;
            tbc_sections.TabUnSelectedForeColor = Color.FromArgb(240, 240, 240);
            tbc_sections.TipsFont = new Font("微软雅黑", 9F);
            // 
            // RothschildPage
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbc_sections);
            Margin = new Padding(2);
            Name = "RothschildPage";
            Size = new Size(1539, 738);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITabControl tbc_sections;
    }
}