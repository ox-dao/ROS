using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OX.Cryptography;
using OX.Cryptography.ECC;
using OX.Network.P2P.Payloads;
using System.Diagnostics;
using OX.Ledger;
using OX.Persistence;
using System.IO;
using Nethereum.Util;
using Akka.Pattern;
using OX.Tablet.Config;
using OX.Casino;
using Sunny.UI;

namespace OX.Tablet.UIs.Setting
{
    public partial class NewFlashState : UIForm
    {
        byte[] ImageData = new byte[0];
        public NewFlashState()
        {
            InitializeComponent();
            ofd.Filter = UIHelper.LocalString("图片|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;", "Image|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void NewLetter_Load(object sender, EventArgs e)
        {
            this.Text = UIHelper.LocalString("发布六合资料", "Publish Mark Six Predict");
            this.bt_ok.Text = UIHelper.LocalString("发布", "Publish");
            this.bt_cancel.Text = UIHelper.LocalString("关闭", "Close");
        }
        void initAccounts()
        {

        }
        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bt_ok_Click(object sender, EventArgs e)
        {
            try
            {

                if (SecureHelper.IsBanker() && SecureHelper.MasterAccount.ScriptHash == MarkBetAddressHelper.Instance.MarkAdmin)
                {
                    var accountState = Blockchain.Singleton.CurrentSnapshot.Accounts.TryGet(SecureHelper.MasterAccount.ScriptHash);
                    if (accountState.IsNotNull() && Blockchain.Singleton.AllowFlashMessage(accountState, out uint _))
                    {
                        byte[] textData = new byte[0];
                        var text = string.Empty;
                        if (text.IsNotAnEmptyAddress())
                            textData = System.Text.Encoding.UTF8.GetBytes(text);
                        var fs = new FlashState(SecureHelper.MasterAccount.ScriptHash, Blockchain.Singleton.HeaderHeight, textData, this.ImageData, new FlashStateTag[] { new FlashStateTag(this.tb_tag.Text) });
                        LockAssetHelper.BuildAndSendFlashMessage(fs);
                        this.Close();
                    }
                }
            }
            catch
            {

            }
        }

        private void pb_Paint(object sender, PaintEventArgs e)
        {
            if (sender is PictureBox box && box.Image.IsNull())
            {
                string text = UIHelper.LocalString("点击添加图片", "Click to add image");
                Font font = new Font("Arial", 12);
                Brush brush = new SolidBrush(Color.White);
                e.Graphics.DrawString(text, font, brush, new PointF(50, 50));
            }
        }

        private void pb_Click(object sender, EventArgs e)
        {
            ofd.Reset();
            ofd.Multiselect = false;
            ofd.Filter = UIHelper.LocalString("图片|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;", "Image|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;");
            var result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selected = ofd.FileName;
                if (ImageCompressHelper.CompressImage(selected, FlashState.MaxImageDataSize, out byte[] bs))
                {
                    this.ImageData = bs;
                    this.pb.Image = Bitmap.FromStream(new MemoryStream(bs));
                }
            }
        }

    }
}
