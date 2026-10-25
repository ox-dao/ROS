using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Model;
using Nethereum.Signer;
using OX.Bapps;
using OX.Tablet.Config;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OX.Cryptography.ECC;

namespace OX.Tablet.FlashMessages
{
    public partial class NewMulticastLine : Form
    {
        EthAccount ExchangeAccount;
        OXAccount MasterAccount;
        bool allowClose = false;
        public NewMulticastLine()
        {
            InitializeComponent();
            this.Text = UIHelper.LocalString("新建群聊", "New Group");
            this.lb_remote.Text = UIHelper.LocalString("共享密钥:", "Share Key:");
            this.lb_lineName.Text = UIHelper.LocalString("群聊名称:", "Group Name:");
            this.bt_register.Text = UIHelper.LocalString("新建", "New");
            this.bt_exit.Text = UIHelper.LocalString("取消", "Cancel");
            this.bt_register.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }


        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        public (string sharekey, string lineName) GetLineInfo()
        {
            return (this.tb_remotePubkey.Text,this.tb_lineName.Text);
        }
        private void bt_register_Click(object sender, EventArgs e)
        {
           
        }

        private void NewAccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
