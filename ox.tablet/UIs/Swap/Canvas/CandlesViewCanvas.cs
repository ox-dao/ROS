using OX.Mining.DEX;
using Sunny.UI.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace OX.Tablet.UIs.Swap.Canvas
{
    public abstract class CandlesViewCanvas : ViewCanvas
    {

        public virtual Func<IndicatorPacketBuilder> GetIndicatorPacketBuilder => () => new MarketIndicatorPacketBuilder();
        protected IEnumerable<MarketQuote> Data = new List<MarketQuote>();
        protected IEnumerable<MarketQuote> displayData = new List<MarketQuote>();
        protected Dictionary<int, MarketQuote> CrosshairXs = new Dictionary<int, MarketQuote>();
        //Queue<MarketQuoteIndicator> queue = new Queue<MarketQuoteIndicator>();
        [Browsable(true)]
        public int RightPixSpace { get; set; }
        [Browsable(true)]
        public int AxisSpace { get; set; } = 8;
        [Browsable(true)]
        public int AreaSplit { get; set; } = 60;

        [Browsable(false)]
        public bool ShowCrossHair { get; set; } = false;

        public int FirstRecord { get; set; }
        private DateTime lastMouseMoveTime = DateTime.Now;
        public Color GridColor { get; set; } = Color.Gray;
        public Color YanColor { get; set; } = Color.Green;
        public Color YinColor { get; set; } = Color.Red;
        public Color CrossHairColor { get; set; } = Color.White;


        public Brush YanBrush = new SolidBrush(Color.Green);
        public Brush YinBrush = new SolidBrush(Color.Red);
        public Brush GridBrush = new SolidBrush(Color.Gray);
        public Brush CrossHairBrush = new SolidBrush(Color.White);
        public Brush Xtip_Brush { get; set; } = new SolidBrush(Color.FromArgb(100, Color.Red));

        #region pens
        public Pen GrayPen { get; set; } = new Pen(Color.Gray);
        public Pen GreenPen { get; set; } = new Pen(Color.Green);
        public Pen OrangePen { get; set; } = new Pen(Color.Orange);
        public Pen BluePen { get; set; } = new Pen(Color.Blue);
        public Pen PurplePen { get; set; } = new Pen(Color.Purple);
        public Pen RedPen { get; set; } = new Pen(Color.Red);
        public Pen YellowPen { get; set; } = new Pen(Color.Yellow);
        public Pen WhitePen { get; set; } = new Pen(Color.White);

        public Pen GrayPen_2 { get; set; } = new Pen(Color.Gray, 2);
        public Pen GreenPen_2 { get; set; } = new Pen(Color.Green, 2);
        public Pen OrangePen_2 { get; set; } = new Pen(Color.Orange, 2);
        public Pen BluePen_2 { get; set; } = new Pen(Color.Blue, 2);
        public Pen PurplePen_2 { get; set; } = new Pen(Color.Purple, 2);
        public Pen RedPen_2 { get; set; } = new Pen(Color.Red, 2);
        public Pen YellowPen_2 { get; set; } = new Pen(Color.Yellow, 2);
        public Pen WhitePen_2 { get; set; } = new Pen(Color.White, 2);

        public Pen GrayPen_3 { get; set; } = new Pen(Color.Gray, 3);
        public Pen GreenPen_3 { get; set; } = new Pen(Color.Green, 3);
        public Pen OrangePen_3 { get; set; } = new Pen(Color.Orange, 3);
        public Pen BluePen_3 { get; set; } = new Pen(Color.Blue, 3);
        public Pen PurplePen_3 { get; set; } = new Pen(Color.Purple, 3);
        public Pen RedPen_3 { get; set; } = new Pen(Color.Red, 3);
        public Pen YellowPen_3 { get; set; } = new Pen(Color.Yellow, 3);
        public Pen WhitePen_3 { get; set; } = new Pen(Color.White, 3);

        #endregion
        public Font StockFont { get; set; } = new Font("New Times Roman", 9);
        public CandlesViewCanvas()
        {
            this.SizeChanged += StockControl_SizeChanged;
            this.PreviewKeyDown += StockControl_PreviewKeyDown;
            this.MouseMove += StockControl_MouseMove;
            this.MouseDown += StockControl_MouseDown;
            this.MouseWheel += StockControl_MouseWheel;
            this.Disposed += StockTradingView_Disposed;
        }
        ~CandlesViewCanvas()
        {
            if (this.GrayPen != default) this.GrayPen.Dispose();
            if (this.GreenPen != default) this.GreenPen.Dispose();
            if (this.RedPen != default) this.RedPen.Dispose();
            if (this.WhitePen != default) this.WhitePen.Dispose();
            if (this.YanBrush != default) this.YanBrush.Dispose();
            if (this.YinBrush != default) this.YinBrush.Dispose();
            if (this.StockFont != default) this.StockFont.Dispose();
            if (this.GridBrush != default) this.GridBrush.Dispose();
            if (this.Xtip_Brush != default) this.Xtip_Brush.Dispose();
            if (this.WhitePen != default) this.WhitePen.Dispose();
        }
        #region events
        private void StockControl_SizeChanged(object? sender, EventArgs e)
        {
            if (this.Size.Width != 0 && this.Size.Height != 0)
            {
                RefreshGraph(false);
            }
        }
        private void StockControl_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyData == Keys.Left)//正常左移动为1步长
            {
                if (this.FirstRecord > 0)
                    this.FirstRecord--;
            }
            if (e.KeyData == Keys.Right)//正常右移动为1步长
            {
                var w = this.DisplayRectangle.Width - this.RightPixSpace;
                var count = w / this.AxisSpace;
                if (count <= this.displayData.Count())
                {
                    if (this.FirstRecord < this.Data.Count() - 1)
                        this.FirstRecord++;
                }
            }

            if (e.Control && e.KeyCode == Keys.Left)//组合Ctrl左移动为50步长
            {
                if (this.FirstRecord >= 50)
                    this.FirstRecord -= 50;
                else
                    this.FirstRecord = 0;
            }

            if (e.Control && e.KeyCode == Keys.Right)//组合Ctrl右移动为50步长
            {
                var w = this.DisplayRectangle.Width - this.RightPixSpace;
                var count = w / this.AxisSpace;
                if (count <= this.displayData.Count())
                {
                    if (this.FirstRecord + 50 < this.Data.Count() - 1)
                        this.FirstRecord += 50;
                    else
                        this.FirstRecord = this.Data.Count() - 1;
                }
            }
            if (e.KeyData == Keys.Up)
            {
                this.ZoomIn(1);
            }
            if (e.KeyData == Keys.Down)
            {
                this.ZoomOut(1);
            }
            RefreshGraph(false);
            this.Focus();
        }
        private void StockControl_MouseMove(object? sender, MouseEventArgs e)
        {
            if (lastMouseMoveTime.AddTicks(100000) < DateTime.Now)
            {
                RefreshGraph(false);
            }
            lastMouseMoveTime = DateTime.Now;
        }
        private void StockControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1)
                {

                }
                else if (e.Clicks == 2)
                {
                    //双击显示或隐藏十字线
                    this.ShowCrossHair = !this.ShowCrossHair;
                    RefreshGraph(false);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                //DarkContextMenu menu = new DarkContextMenu();
                //var sm = new ToolStripMenuItem(UIHelper.LocalString("我的交易记录", "My exchange records"));
                //sm.Click += Sm_Click;
                //menu.Items.Add(sm);
                //var mc = IsHour ? "日K线" : "时K线";
                //var me = IsHour ? "Daily K Line" : "Hour K Line";
                //sm = new ToolStripMenuItem(UIHelper.LocalString($"转为{mc}", $"Change to {me}"));
                //sm.Click += Sm_Click1;
                //menu.Items.Add(sm);
                //if (menu.Items.Count > 0)
                //    menu.Show(this, e.Location);
            }
        }
        private void StockControl_MouseWheel(object? sender, MouseEventArgs e)
        {
            bool controlPressed = (ModifierKeys & Keys.Control) == Keys.Control;
            bool altPressed = (ModifierKeys & Keys.Alt) == Keys.Alt;
            if (controlPressed)
            {
                if (altPressed)
                {
                    if (e.Delta > 0)
                    {
                        if (this.FirstRecord >= 50)
                            this.FirstRecord -= 50;
                        else
                            this.FirstRecord = 0;
                    }
                    else
                    {
                        var w = this.DisplayRectangle.Width - this.RightPixSpace;
                        var count = w / this.AxisSpace;
                        if (count <= this.displayData.Count())
                        {
                            if (this.FirstRecord + 50 < this.Data.Count() - 1)
                                this.FirstRecord += 50;
                            else
                                this.FirstRecord = this.Data.Count() - 1;
                        }
                    }
                }
                else
                {
                    if (e.Delta > 0)
                    {
                        if (this.FirstRecord > 0)
                            this.FirstRecord--;
                    }
                    else
                    {
                        var w = this.DisplayRectangle.Width - this.RightPixSpace;
                        var count = w / this.AxisSpace;
                        if (count <= this.displayData.Count())
                        {
                            if (this.FirstRecord < this.Data.Count() - 1)
                                this.FirstRecord++;
                        }
                    }
                }
            }
            else
            {
                if (e.Delta > 0)
                {
                    ZoomIn(2);
                }
                else
                {
                    ZoomOut(2);
                }
            }
            this.RefreshGraph(false);
            this.Focus();
        }
        private void StockTradingView_Disposed(object? sender, EventArgs e)
        {
            this.RwSyncRootLock.Dispose();
        }
        #endregion
        /// <summary>
        /// 蜡烛元素
        /// </summary>
        List<CandlesViewElement> candlesElements = new List<CandlesViewElement>();
        /// <summary>
        /// 全屏元素
        /// </summary>
        List<ViewElement> fullElements = new List<ViewElement>();
        public override void Draw(Graphics g, Rectangle drawRectangle)
        {
            DrawScale(g, out int klbottom, out decimal? mp, out decimal? lp);
            if (klbottom != 0 && mp != 0)
                DrawCrossHair(g, klbottom, mp, lp);
            foreach (var element in candlesElements)
            {
                element.Draw(g, drawRectangle);
            }
        }
        public void ClearData()
        {
            this.Data = new List<MarketQuote>();
        }
        public void DrawScale(Graphics g, out int klbottom, out decimal? mp, out decimal? lp)
        {
            klbottom = 0;
            mp = 0;
            lp = 0;
            StringFormat sf = new StringFormat();
            var H = this.DisplayRectangle.Height - AreaSplit * 3;
            var H1 = (int)(0.9 * H);
            var H2 = (int)(0.1 * H);
            var hp = this.displayData.OrderByDescending(m => m.High).FirstOrDefault()?.High;
            lp = this.displayData.OrderBy(m => m.Low).FirstOrDefault()?.Low;
            var sp = hp - lp;//框内最大值跟最小值之间的差值
            if (sp == 0) return;
            //计算每个差值分配的高值
            mp = H1 / sp;
            var pt = this.displayData.OrderByDescending(m => m.Volume).FirstOrDefault()?.Volume;
            var mpt = pt != 0 ? H2 / pt : 0;

            klbottom = this.DisplayRectangle.Y + this.AreaSplit + H1;
            var gridHeight = H1 / 5;
            Brush bBrush = new SolidBrush(this.GridColor);
            for (int i = 0; i <= 5; i++)
            {
                var y = this.DisplayRectangle.Y + this.AreaSplit + gridHeight * i;
                if (ShowGrid)
                {
                    g.DrawLine(this.GrayPen, 0, y, this.DisplayRectangle.Width, y);
                }
                var gmp = gridHeight * (5 - i) / mp + lp;
                var sgmp = string.Empty;
                if (gmp.HasValue)
                    sgmp = gmp.Value.ToString("f2");
                SizeF bsFontSize = g.MeasureString(sgmp, this.StockFont, 1000, sf);
                //g.DrawString(sgmp, this.StockFont, bBrush, new PointF(this.DisplayRectangle.Width - this.RightOrderSpace - bsFontSize.Width,
                //y - 20));
                g.DrawString(sgmp, this.StockFont, bBrush, new PointF(0, y - 20));
            }
            var gridWidth = (this.DisplayRectangle.Width) / 5;
            List<int> xl = new List<int>();
            for (int i = 0; i <= 5; i++)
            {
                var x = this.DisplayRectangle.X + gridWidth * i;
                if (ShowGrid)
                {
                    g.DrawLine(this.GrayPen, x, this.DisplayRectangle.Y + this.AreaSplit, x, klbottom - 5);
                }
                if (i > 0 && i < 5) xl.Add(x);
            }
            int top = this.DisplayRectangle.Y + AreaSplit * 2 + H1;
            int top2 = this.DisplayRectangle.Y + AreaSplit * 3 + H1 + H2;
            int panelBottm2 = this.DisplayRectangle.Y + H1 + AreaSplit * 2 + H2;
            g.DrawLine(this.GrayPen, 0, top, this.DisplayRectangle.Width, top);
            g.DrawLine(this.GrayPen, 0, panelBottm2, this.DisplayRectangle.Width, panelBottm2);
            g.DrawLine(this.GrayPen, 0, top2, this.DisplayRectangle.Width, top2);
            if (ShowGrid)
            {
                for (int i = 0; i <= 5; i++)
                {
                    var x = this.DisplayRectangle.X + gridWidth * i;
                    g.DrawLine(this.GrayPen, x, this.DisplayRectangle.Y + H1 + AreaSplit * 2, x, panelBottm2 - 5);
                }
            }

            int k = 0;
            this.CrosshairXs.Clear();
            foreach (var d in this.displayData)
            {
                DrawKLine(g, d, k, this.AreaSplit + H1, mp, lp, xl);
                DrawPriceVolume(g, d, k, this.AreaSplit * 2 + H1 + H2, mpt, d.Volume, xl);
                k++;
            }
            if (ShowIndicators)
            {
                RwSyncRootLock.EnterReadLock();
                try
                {
                    DrawIndicators(g, this.displayData, this.AreaSplit + H1, mp, lp);
                }
                finally
                {
                    RwSyncRootLock.ExitReadLock();
                }
            }
            bBrush.Dispose();
        }
        void DrawKLine(Graphics g, MarketQuote data, int index, int H1, decimal? mp, decimal? lp, List<int> xl)
        {

            StringFormat sf = new StringFormat();
            var x = this.DisplayRectangle.X + this.AxisSpace * index + this.AxisSpace / 2;

            this.CrosshairXs[this.DisplayRectangle.X + this.AxisSpace * index] = data;
            var bottom = this.DisplayRectangle.Y + H1;
            var ly = bottom - (data.Low - lp.Value) * mp;
            var hy = bottom - (data.High - lp.Value) * mp;
            var by = bottom - (data.Open - lp.Value) * mp;
            var ey = bottom - (data.Close - lp.Value) * mp;
            Pen pen = this.GreenPen;
            Brush brush = this.YanBrush;
            if (data.Open > data.Close)
            {
                pen = this.RedPen;
                brush = this.YinBrush;
            }


            //if (this.Strategy.IsNotNull() && this.Strategy.StorageState.IsNotNull() && this.Strategy.StorageState.TestPositionOrders.IsNotNullAndEmpty())
            //{
            //    var ts = DateUtil.GetTimestampMS(data.Timestamp);
            //    var orderQ = this.StrategyMode == StrategyMode.BackTest ? this.Strategy.StorageState.TestPositionOrders.FirstOrDefault(m => m.QuoteDate == ts && m.InstId == this.Strategy.Key.InstId) : this.Strategy.StorageState.LivePositionOrders.FirstOrDefault(m => m.QuoteDate == ts && m.InstId == this.Strategy.Key.InstId);
            //    if (orderQ.IsNotNull())
            //    {
            //        pen = this.CrossHair_Pen;
            //        brush = this.CrossHairBrush;
            //    }
            //}

            var y = by;
            decimal? sy = 0;
            sy = ey - by;
            if (ey < by)
            {
                sy = by - ey;
                y = ey;
            }

            g.DrawLine(pen, x, (int)(ly.Value), x, (int)(hy.Value));
            var x1 = x - this.AxisSpace / 2 + 2;
            data.X = x;
            if (sy.Value > 0)
            {
                var rect = new Rectangle(x1, (int)(y.Value), this.AxisSpace - 4, (int)(sy.Value));
                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);
            }
            else
            {
                g.DrawLine(pen, x1, (int)(ly.Value), x1 + this.AxisSpace - 4, (int)(ly.Value));
            }
            foreach (var x2 in xl)
            {
                if (x2 > x1 - 2 && x2 < x1 + this.AxisSpace)
                {
                    var str = data.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");
                    SizeF bsFontSize = g.MeasureString(str, this.StockFont, 1000, sf);
                    Brush bBrush = new SolidBrush(this.GridColor);
                    g.DrawString(str, this.StockFont, bBrush, new PointF(x2 - 40,
                   bottom + 2));
                    bBrush.Dispose();
                }
            }
        }
        void DrawPriceVolume(Graphics g, MarketQuote data, int index, int H2, decimal? mpt, decimal PriceTotal, List<int> xl)
        {
            StringFormat sf = new StringFormat();
            var x = this.DisplayRectangle.X + this.AxisSpace * index + this.AxisSpace / 2;
            var bottom = this.DisplayRectangle.Y + H2;
            var p = PriceTotal * mpt;
            Pen pen = this.GreenPen;
            Brush brush = this.YanBrush;
            if (data.Open > data.Close)
            {
                pen = this.RedPen;
                brush = this.YinBrush;
            }
            var b2 = (int)(p.Value);
            var x1 = x - this.AxisSpace / 2 + 2;
            var rect = new Rectangle(x1, bottom - b2, this.AxisSpace - 4, b2);
            g.FillRectangle(brush, rect);
            g.DrawRectangle(pen, rect);
            foreach (var x2 in xl)
            {
                if (x2 > x1 - 2 && x2 < x1 + this.AxisSpace)
                {
                    var str = data.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");
                    SizeF bsFontSize = g.MeasureString(str, this.StockFont, 1000, sf);
                    Brush bBrush = new SolidBrush(this.GridColor);
                    g.DrawString(str, this.StockFont, bBrush, new PointF(x2 - 40,
                   bottom + 2));
                    bBrush.Dispose();
                }
            }
        }
       
        #region indicators
        public virtual void DrawIndicators(Graphics g, IEnumerable<MarketQuote> displayQuotes, int H1, decimal? mp, decimal? lp)
        {
            if (displayQuotes.IsNullOrEmpty()) return;
            // 计算 EMA
            EMA(g, displayQuotes, WhitePen, RedPen, GreenPen, H1, mp, lp);
            //// 生成交叉信号
            //var signals = GenerateCrossSignals(displayQuotes);
            //// 显示结果
            //if (signals.Count > 0)
            //{
            //    var crossoverSignals = signals
            //      .Where(s => s.Crossover.HasValue)
            //      .ToList();
            //    if (crossoverSignals.Any())
            //    {
            //        foreach (var signal in crossoverSignals)
            //        {
            //            var bottom = this.DisplayRectangle.Y + H1;
            //            var y = (int)(bottom - ((decimal)((signal.SlowEma + signal.FastEma) / 2) - lp.Value) * mp);
            //            string crossoverType = signal.Crossover == CrossoverType.Golden ? "金叉(买入)" : "死叉(卖出)";
            //            Console.WriteLine($"{signal.Date:yyyy-MM-dd}\t{signal.Close:F2}\t{signal.FastEma:F2}\t{signal.SlowEma:F2}\t{crossoverType}");
            //            Pen yellowPen = signal.Crossover == CrossoverType.Golden ? new Pen(Color.Green, 2) : new Pen(Color.Yellow, 2);
            //            g.DrawEllipse(yellowPen, signal.X - 10, y - 10, 20, 20);
            //        }
            //    }
            //}
        }
        protected void EMA(Graphics g, IEnumerable<MarketQuote> quotes, Pen closePen, Pen fastPen, Pen slowPen, int H1, decimal? mp, decimal? lp)
        {
            if (quotes.IsNullOrEmpty()) return;
            int k = 0;
            double lastResultClose = 0;
            int lastXClose = 0, lastYClose = 0;

            double lastResultFast = 0;
            int lastXFast = 0, lastYFast = 0;

            double lastResultSlow = 0;
            int lastXSlow = 0, lastYSlow = 0;
            foreach (var quote in quotes)
            {
                if (quote is MarketQuoteIndicator mq && mq.Indicator is MarketIndicatorPacket mip)
                {
                    if (mip.Close != 0)
                    {
                        var bottom = this.DisplayRectangle.Y + H1;
                        var y = (int)(bottom - ((decimal)mip.Close - lp.Value) * mp);
                        var x = quote.X;
                        if (lastResultClose != 0)
                        {
                            g.DrawLine(closePen, lastXClose, lastYClose, x, y);
                        }
                        lastXClose = x;
                        lastYClose = y;
                        lastResultClose = mip.Close;
                    }

                    if (mip.EMAFast != 0)
                    {
                        var bottom = this.DisplayRectangle.Y + H1;
                        var y = (int)(bottom - ((decimal)mip.EMAFast - lp.Value) * mp);
                        var x = quote.X;
                        if (lastResultFast != 0)
                        {
                            g.DrawLine(fastPen, lastXFast, lastYFast, x, y);
                        }
                        lastXFast = x;
                        lastYFast = y;
                        lastResultFast = mip.EMAFast;
                    }

                    if (mip.EMASlow != 0)
                    {
                        var bottom = this.DisplayRectangle.Y + H1;
                        var y = (int)(bottom - ((decimal)mip.EMASlow - lp.Value) * mp);
                        var x = quote.X;
                        if (lastResultSlow != 0)
                        {
                            g.DrawLine(slowPen, lastXSlow, lastYSlow, x, y);
                        }
                        lastXSlow = x;
                        lastYSlow = y;
                        lastResultSlow = mip.EMASlow;
                    }
                }

                k++;
            }
        }
       
        #endregion
        public void DrawCrossHair(Graphics g, int klbottom, decimal? mp, decimal? lp)
        {
            if (this.ShowCrossHair)
            {
                using (Pen customPen = new Pen(Color.Yellow, 3))
                {
                    customPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawRectangle(customPen, 0, 0, this.DisplayRectangle.Width - 3, this.DisplayRectangle.Height - 3);
                }
            }
            if (this.ShowCrossHair && GetCrossHairPoint(out Point mousePoint, out MarketQuote data))
            {
                if (mousePoint.Y > this.AreaSplit && mousePoint.Y < klbottom)
                    g.DrawLine(this.WhitePen, 0, mousePoint.Y, this.DisplayRectangle.Width, mousePoint.Y);
                g.DrawLine(this.WhitePen, mousePoint.X, this.AreaSplit, mousePoint.X, this.DisplayRectangle.Height);
                var k = (klbottom - mousePoint.Y) / mp + lp;
                Brush bBrush = new SolidBrush(this.GridColor);
                g.DrawString(data.Timestamp.ToString("yyyy-MM-dd HH:mm"), this.StockFont, bBrush, new PointF(100, 10));
            }
        }
        public bool GetCrossHairPoint(out Point p, out MarketQuote data)
        {
            p = default;
            data = default;
            int x = this.PointToClient(MousePosition).X;
            int y = this.PointToClient(MousePosition).Y;
            foreach (var cx in this.CrosshairXs)
            {
                if (x >= cx.Key && x <= cx.Key + this.AxisSpace)
                {
                    x = cx.Key + this.AxisSpace / 2;
                    p = new Point(x, y);
                    data = cx.Value;
                    return true;
                }
            }
            return false;
        }



        public override void ReloadInitData(UInt160 hostSH, SwapPairMerge swapPairMerge, MarketQuote[] initDatas = default)
        {
            RwSyncRootLock.EnterReadLock();
            try
            {
                Data = initDatas;
                RefreshGraph(!this.ShowCrossHair);
            }
            finally
            {
                RwSyncRootLock.ExitReadLock();
            }
        }
        public void RefreshGraph(bool InitFirst)
        {
            ResetFirstRecord(InitFirst);
            DrawGraph();
        }
        public void ResetFirstRecord(bool InitFirst)
        {
            var dc = Data.Count();
            if (dc == 0) return;
            if (dc < this.FirstRecord)
            {
                this.FirstRecord = dc - 1;
            }
        ;
            var w = this.DisplayRectangle.Width - this.RightPixSpace;
            if (w <= 0) return;
            var count = w / this.AxisSpace;
            //var indicatorBuilder = this.GetIndicatorPacketBuilder();
            if (InitFirst)
            {
                if (count > dc)
                {
                    this.FirstRecord = 0;
                    //displayData = indicatorBuilder.Build(Data.Take(new Range(new Index(this.FirstRecord), new Index(dc))).OrderBy(m => m.Timestamp).ToList()).ToList();
                    displayData = Data.Take(new Range(new Index(this.FirstRecord), new Index(dc))).OrderBy(m => m.Timestamp);
                }
                else
                {
                    this.FirstRecord = dc - count;
                    //displayData = indicatorBuilder.Build(Data.Take(new Range(new Index(this.FirstRecord), new Index(dc))).OrderBy(m => m.Timestamp).ToList()).ToList();
                    displayData = Data.Take(new Range(new Index(this.FirstRecord), new Index(dc))).OrderBy(m => m.Timestamp);
                }
            }
            else
            {
                var c = count + this.FirstRecord;
                if (c > dc) c = dc;
                //displayData = indicatorBuilder.Build(Data.Take(new Range(new Index(this.FirstRecord), new Index(c))).OrderBy(m => m.Timestamp).ToList()).ToList();
                displayData = Data.Take(new Range(new Index(this.FirstRecord), new Index(c))).OrderBy(m => m.Timestamp);
            }
        }
        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="step"></param>
        private void ZoomIn(int step)
        {
            if (this.AxisSpace < 50)
            {
                this.AxisSpace += step;
                this.ResetFirstRecord(false);
            }
        }

        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="step"></param>
        private void ZoomOut(int step)
        {
            if (this.AxisSpace > 5)
            {
                this.AxisSpace -= step;
                this.ResetFirstRecord(false);
            }
        }
    }
}
