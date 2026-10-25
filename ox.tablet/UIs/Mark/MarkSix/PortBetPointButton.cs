using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OX.BMS;
using OX.Tablet.Config;
using Sunny.UI;
using Sunny.UI.Win32;

namespace OX.Tablet.UIs.Mark
{
    public delegate void PortBetPointHandler(PortBetPointButton bpb);
    public class PortBetPointButton : UIButton
    {
        public static readonly Color SelectedColor = Color.FromArgb(230, 80, 80);
        public static readonly Color UnSelectedColor = Color.LightBlue;
        public BetChannel JudgeChannel { get; private set; }
        public BitMarkSixBet Bet { get; private set; }
        public event PortBetPointHandler OnBetPointClicked;
        bool _selected = false;
        public bool BetSelected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                setColor(_selected ? SelectedColor : UnSelectedColor);
            }
        }
        public PortBetPointButton(BetChannel channel, BitMarkSixBet bet,bool selected) : base()
        {
            JudgeChannel = channel;
            this.Bet = bet;
            this.BetSelected = selected;
            Text = bet.BetTarget.BetPoint.ToDisplayString(channel, bet.BetTarget.Method, UIHelper.IsChina());
            //this.TipsText = amount.ToString();
            Cursor = Cursors.Hand;
            Font = new Font("微软雅黑", 9F);
            Name = "uiButton13";
            Size = new Size(120, 50);
            Style = UIStyle.Custom;
            StyleCustomMode = true;
            Radius = 5;
            TextAlign = ContentAlignment.BottomCenter;

            this.Click += BetPointButton_Click;
        }

        private void BetPointButton_Click(object sender, EventArgs e)
        {
            this.BetSelected = !this.BetSelected;
            OnBetPointClicked?.Invoke(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var tt = this.Bet.Amount.ToString();
            e.Graphics.SetHighQuality();
            using var TempFont = new Font("黑体", 10F);
            Size sf = TextRenderer.MeasureText(tt, TempFont);
            int sfMax = Math.Max(sf.Width, sf.Height);
            int x = Width - 1 - 2 - sfMax;
            int y = 1 + 2;
            e.Graphics.FillRectangle(Color.White, x - 1, y, sfMax, sf.Height);
            e.Graphics.DrawString(tt, TempFont, Color.Red, new Rectangle(x, y, sfMax, sf.Height), ContentAlignment.MiddleCenter);
        }
        void setColor(Color color)
        {
            FillColor = color;
            FillColor2 = color;
            FillHoverColor = color;
            FillPressColor = color;
            FillSelectedColor = color;
            RectColor = color;
            RectHoverColor = color;
            RectPressColor = color;
            RectSelectedColor = color;
        }
    }
}
