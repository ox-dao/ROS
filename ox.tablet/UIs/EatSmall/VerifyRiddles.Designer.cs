namespace OX.Tablet.UIs.MarkSix
{
    partial class VerifyRiddles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyRiddles));
            panel = new Panel();
            tb_mineNonce = new Sunny.UI.UITextBox();
            lb_mineNonce = new Sunny.UI.UILabel();
            tb_riddles_items = new Sunny.UI.UITextBox();
            cb_txhasList = new Sunny.UI.UIComboBox();
            lb_txhash = new Sunny.UI.UILabel();
            lb_index_v = new Sunny.UI.UILabel();
            tb_riddles_hash = new Sunny.UI.UITextBox();
            bt_verify = new Sunny.UI.UIButton();
            tb_riddles = new Sunny.UI.UITextBox();
            lb_riddles_hash = new Sunny.UI.UILabel();
            lb_riddles = new Sunny.UI.UILabel();
            lb_index = new Sunny.UI.UILabel();
            bt_close = new Sunny.UI.UIButton();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(bt_close);
            panel.Controls.Add(tb_mineNonce);
            panel.Controls.Add(lb_mineNonce);
            panel.Controls.Add(tb_riddles_items);
            panel.Controls.Add(cb_txhasList);
            panel.Controls.Add(lb_txhash);
            panel.Controls.Add(lb_index_v);
            panel.Controls.Add(tb_riddles_hash);
            panel.Controls.Add(bt_verify);
            panel.Controls.Add(tb_riddles);
            panel.Controls.Add(lb_riddles_hash);
            panel.Controls.Add(lb_riddles);
            panel.Controls.Add(lb_index);
            resources.ApplyResources(panel, "panel");
            panel.Name = "panel";
            // 
            // tb_mineNonce
            // 
            tb_mineNonce.BackColor = Color.FromArgb(69, 73, 74);
            resources.ApplyResources(tb_mineNonce, "tb_mineNonce");
            tb_mineNonce.Multiline = true;
            tb_mineNonce.Name = "tb_mineNonce";
            tb_mineNonce.ReadOnly = true;
            tb_mineNonce.ShowText = false;
            tb_mineNonce.TextAlignment = ContentAlignment.MiddleLeft;
            tb_mineNonce.Watermark = "";
            // 
            // lb_mineNonce
            // 
            resources.ApplyResources(lb_mineNonce, "lb_mineNonce");
            lb_mineNonce.ForeColor = Color.FromArgb(48, 48, 48);
            lb_mineNonce.Name = "lb_mineNonce";
            // 
            // tb_riddles_items
            // 
            tb_riddles_items.BackColor = Color.FromArgb(69, 73, 74);
            resources.ApplyResources(tb_riddles_items, "tb_riddles_items");
            tb_riddles_items.Multiline = true;
            tb_riddles_items.Name = "tb_riddles_items";
            tb_riddles_items.ReadOnly = true;
            tb_riddles_items.ShowText = false;
            tb_riddles_items.TextAlignment = ContentAlignment.MiddleLeft;
            tb_riddles_items.Watermark = "";
            // 
            // cb_txhasList
            // 
            cb_txhasList.DataSource = null;
            cb_txhasList.FillColor = Color.White;
            resources.ApplyResources(cb_txhasList, "cb_txhasList");
            cb_txhasList.FormattingEnabled = true;
            cb_txhasList.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cb_txhasList.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cb_txhasList.Name = "cb_txhasList";
            cb_txhasList.SymbolSize = 24;
            cb_txhasList.TextAlignment = ContentAlignment.MiddleLeft;
            cb_txhasList.Watermark = "";
            cb_txhasList.SelectedIndexChanged += cb_txhasList_SelectedIndexChanged;
            // 
            // lb_txhash
            // 
            resources.ApplyResources(lb_txhash, "lb_txhash");
            lb_txhash.ForeColor = Color.FromArgb(48, 48, 48);
            lb_txhash.Name = "lb_txhash";
            // 
            // lb_index_v
            // 
            resources.ApplyResources(lb_index_v, "lb_index_v");
            lb_index_v.ForeColor = Color.FromArgb(48, 48, 48);
            lb_index_v.Name = "lb_index_v";
            // 
            // tb_riddles_hash
            // 
            tb_riddles_hash.BackColor = Color.FromArgb(69, 73, 74);
            resources.ApplyResources(tb_riddles_hash, "tb_riddles_hash");
            tb_riddles_hash.Multiline = true;
            tb_riddles_hash.Name = "tb_riddles_hash";
            tb_riddles_hash.ShowText = false;
            tb_riddles_hash.TextAlignment = ContentAlignment.MiddleLeft;
            tb_riddles_hash.Watermark = "";
            // 
            // bt_verify
            // 
            resources.ApplyResources(bt_verify, "bt_verify");
            bt_verify.Name = "bt_verify";
            bt_verify.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_verify.Click += bt_copy_Click;
            // 
            // tb_riddles
            // 
            tb_riddles.BackColor = Color.FromArgb(69, 73, 74);
            resources.ApplyResources(tb_riddles, "tb_riddles");
            tb_riddles.Multiline = true;
            tb_riddles.Name = "tb_riddles";
            tb_riddles.ReadOnly = true;
            tb_riddles.ShowText = false;
            tb_riddles.TextAlignment = ContentAlignment.MiddleLeft;
            tb_riddles.Watermark = "";
            // 
            // lb_riddles_hash
            // 
            resources.ApplyResources(lb_riddles_hash, "lb_riddles_hash");
            lb_riddles_hash.ForeColor = Color.FromArgb(48, 48, 48);
            lb_riddles_hash.Name = "lb_riddles_hash";
            // 
            // lb_riddles
            // 
            resources.ApplyResources(lb_riddles, "lb_riddles");
            lb_riddles.ForeColor = Color.FromArgb(48, 48, 48);
            lb_riddles.Name = "lb_riddles";
            // 
            // lb_index
            // 
            resources.ApplyResources(lb_index, "lb_index");
            lb_index.ForeColor = Color.FromArgb(48, 48, 48);
            lb_index.Name = "lb_index";
            // 
            // bt_close
            // 
            resources.ApplyResources(bt_close, "bt_close");
            bt_close.Name = "bt_close";
            bt_close.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            bt_close.Click += bt_close_Click;
            // 
            // VerifyRiddles
            // 
            AutoScaleMode = AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            Controls.Add(panel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VerifyRiddles";
            ZoomScaleRect = new Rectangle(22, 22, 1242, 679);
            FormClosing += ClaimForm_FormClosing;
            Load += ClaimForm_Load;
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private Sunny.UI.UILabel lb_index;
        private Sunny.UI.UILabel lb_riddles;
        private Sunny.UI.UILabel lb_riddles_hash;
        private Sunny.UI.UITextBox tb_riddles;
        private Sunny.UI.UIButton bt_verify;
        private Sunny.UI.UITextBox tb_riddles_hash;
        private Sunny.UI.UILabel lb_index_v;
        private Sunny.UI.UIComboBox cb_txhasList;
        private Sunny.UI.UILabel lb_txhash;
        private Sunny.UI.UITextBox tb_riddles_items;
        private Sunny.UI.UITextBox tb_mineNonce;
        private Sunny.UI.UILabel lb_mineNonce;
        private Sunny.UI.UIButton bt_close;
    }
}