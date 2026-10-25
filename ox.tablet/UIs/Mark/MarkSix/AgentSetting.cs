using OX.Wallets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OX.BMS;
using OX.Tablet.Config;

namespace OX.Tablet.UIs.MarkSix
{
    public partial class AgentSetting : UserControl
    {
        MarkSetting BitSixSetting;
        public AgentSetting()
        {
            InitializeComponent();
            this.BackColor = Color.Gray;
            this.LoadSetting(new MarkSetting());
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.lb_name.Text = UIHelper.LocalString("玩法", "Method");
            this.lb_odds.Text = UIHelper.LocalString("赔率", "Odds");
            //this.lb_fee.Text = UIHelper.LocalString("佣金:", "Commission:");
            //this.lb_fc.Text = UIHelper.LocalString("带单佣金分成:", "Commission Share:");
            this.st_union.ActiveText = UIHelper.LocalString("开放港澳联合彩", "Open Mark Six Union");
            this.st_union.InActiveText = UIHelper.LocalString("关闭港澳联合彩", "Closse Mark Six Union");
            this.st_macau.ActiveText = UIHelper.LocalString("开放新澳门六合彩", "Open Mark Six Macau");
            this.st_macau.InActiveText = UIHelper.LocalString("关闭新澳门六合彩", "Closse Mark Six Macau");
        }
        public void LoadSetting(MarkSetting setting,bool showOnly=false)
        {
            if (showOnly)
            {
                this.st_union.ReadOnly = true;
                this.st_macau.ReadOnly = true;
            }
            if (setting.IsNotNull())
            {
                this.BitSixSetting = setting;
                this.pfull.Controls.Clear();
                this.BitSixSetting = setting;
                //this.nd_fee.Value = this.BitSixSetting.Flag;
                this.st_union.Active = setting.MergedMarkSixRound.Contains(MarkSixRound.MarkUnion);
                this.st_macau.Active = setting.MergedMarkSixRound.Contains(MarkSixRound.MarkMacau);
                List<MarkSixBetMethod> methods = new List<MarkSixBetMethod>();
                foreach (var fs in this.BitSixSetting.MarkSixMethods)
                {
                    MarkSixBetMethod m = (MarkSixBetMethod)fs.Method;
                    methods.Add(m);
                    this.pfull.Controls.Add(new MarkSixMethodSettingControl(m, fs));
                }
                foreach (var m in NoneFlagEnumHelper.All<MarkSixBetMethod>())
                {
                    if (!methods.Contains(m))
                    {
                        var methodsetting = m.GetMethodSetting();
                        if (methodsetting.IsNotNull())
                        {
                            this.pfull.Controls.Add(new MarkSixMethodSettingControl(m, new BMSPlayMethod { Method = (byte)m, Odds = methodsetting.DefaultOdds, Fee = methodsetting.DefaultCommission }));
                        }
                    }
                }
            }
        }
        public MarkSetting GetSetting()
        {
            List<BMSPlayMethod> l1 = new List<BMSPlayMethod>();
            List<BMSPlayMethod> l2 = new List<BMSPlayMethod>();
            foreach (MarkSixMethodSettingControl f in this.pfull.Controls)
            {
                l1.Add(f.GetMethodSetting());
            }
            MarkSixRound msr = default;
            if (this.st_union.Active)
                msr |= MarkSixRound.MarkUnion;
            if (this.st_macau.Active)
                msr |= MarkSixRound.MarkMacau;
            return new MarkSetting { MarkSixMethods = l1.ToArray(), MarkOneMethods = l2.ToArray(), Flag = 0, MergedMarkSixRound = msr };
        }
    }
}
