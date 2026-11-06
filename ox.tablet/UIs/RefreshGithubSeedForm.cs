using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OX.Ledger;
using OX.Tablet.Config;
using Sunny.UI;

namespace OX.Tablet
{
    public partial class RefreshGithubSeedForm : Form
    {
        public RefreshGithubSeedForm()
        {
            InitializeComponent();
            this.Text = UIHelper.LocalString("正在获取种子节点", "Fetching seed nodes");
            this.lb_msg.Text = UIHelper.LocalString("获取种子节点...", "Fetching seed...");
        }
 

        private void UnlockAccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        
    }
}
