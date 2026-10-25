using System.Windows.Forms;
namespace OX.Tablet.UIs.Setting
{
    partial class NewFlashState
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
            bt_cancel = new Button();
            bt_ok = new Button();
            pb = new PictureBox();
            ofd = new OpenFileDialog();
            tb_tag = new Sunny.UI.UITextBox();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            SuspendLayout();
            // 
            // bt_cancel
            // 
            bt_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_cancel.Location = new System.Drawing.Point(114, 546);
            bt_cancel.Name = "bt_cancel";
            bt_cancel.Padding = new Padding(5);
            bt_cancel.Size = new System.Drawing.Size(145, 46);
            bt_cancel.TabIndex = 5;
            bt_cancel.Text = "darkButton1";
            bt_cancel.Click += bt_cancel_Click;
            // 
            // bt_ok
            // 
            bt_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_ok.Location = new System.Drawing.Point(303, 546);
            bt_ok.Name = "bt_ok";
            bt_ok.Padding = new Padding(5);
            bt_ok.Size = new System.Drawing.Size(145, 46);
            bt_ok.TabIndex = 6;
            bt_ok.Text = "darkButton2";
            bt_ok.Click += bt_ok_Click;
            // 
            // pb
            // 
            pb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pb.BorderStyle = BorderStyle.FixedSingle;
            pb.Location = new System.Drawing.Point(25, 57);
            pb.Name = "pb";
            pb.Size = new System.Drawing.Size(423, 396);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.TabIndex = 37;
            pb.TabStop = false;
            pb.Click += pb_Click;
            pb.Paint += pb_Paint;
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            // 
            // tb_tag
            // 
            tb_tag.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tb_tag.Location = new System.Drawing.Point(34, 474);
            tb_tag.Margin = new Padding(4, 5, 4, 5);
            tb_tag.MinimumSize = new System.Drawing.Size(1, 16);
            tb_tag.Name = "tb_tag";
            tb_tag.Padding = new Padding(5);
            tb_tag.ShowText = false;
            tb_tag.Size = new System.Drawing.Size(414, 44);
            tb_tag.TabIndex = 38;
            tb_tag.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tb_tag.Watermark = "";
            // 
            // NewFlashState
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(479, 604);
            Controls.Add(tb_tag);
            Controls.Add(pb);
            Controls.Add(bt_ok);
            Controls.Add(bt_cancel);
            Name = "NewFlashState";
            Text = "NewLetter";
            ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 479, 582);
            Load += NewLetter_Load;
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private Button bt_cancel;
        private Button bt_ok;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.OpenFileDialog ofd;
        private Sunny.UI.UITextBox tb_tag;
    }
}