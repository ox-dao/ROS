using System.Linq.Expressions;
using System.Reflection;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public abstract class CommonCandlesViewCanvas<Packet, PacketBuilder> : IndicatorCandlesViewCanvas where Packet : IndicatorPacket, new() where PacketBuilder : IndicatorPacketBuilder, new()
    {
        public class IndicatorViewCanvasContext
        {
            public Graphics g;
            public int LastX;
            public int X;
            public int H1;
            public decimal? mp;
            public decimal? lp;
        }
        public class PenY
        {
            public Pen Pen;
            public int Y;
        }
        int LastX = 0;
        Dictionary<string, PenY> ys = new Dictionary<string, PenY>();
        public override Func<IndicatorPacketBuilder> GetIndicatorPacketBuilder => () => new PacketBuilder();
        public override void DrawIndicators(Graphics g, IEnumerable<MarketQuote> displayQuotes, int H1, decimal? mp, decimal? lp)
        {
            if (displayQuotes.IsNullOrEmpty()) return;
            LastX = 0;
            ys.Clear();

            foreach (var quote in displayQuotes)
            {
                if (quote is MarketQuoteIndicator mq && mq.Indicator is Packet mip)
                {
                    var canvasContext = new IndicatorViewCanvasContext
                    {
                        g = g,
                        LastX = LastX,
                        X = quote.X,
                        H1 = H1,
                        mp = mp,
                        lp = lp
                    };
                    //Col(n => n.Size, indicator, g, LastX, quote.X, H1, mp, lp);
                    DrawIndicatorLines( mq, mip, canvasContext);
                    LastX = quote.X;
                }
            }
        }
        public void Line(Expression<Func<Packet, object>> expression, double indicatorValue, IndicatorViewCanvasContext context, Func<Pen> getPen)
        {
            if (indicatorValue != double.NaN && indicatorValue != 0)
            {
                var pen = getPen();
                PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;
                string Name = propertyInfo.Name;

                if (!ys.TryGetValue(Name, out PenY LastPenyY))
                {
                    LastPenyY = new PenY { Y = 0, Pen = pen };
                    ys[Name] = LastPenyY;
                }
                var bottom = DisplayRectangle.Y + context.H1;
                var y = (int)(bottom - (indicatorValue - (double)context.lp.Value) * (double)context.mp);
                if (y < 0) y = 0;

                if (LastPenyY.Y != 0)
                    context.g.DrawLine(LastPenyY.Pen, context.LastX, LastPenyY.Y, context.X, y);
                LastPenyY.Y = y;
                LastPenyY.Pen = pen;
            }
        }
       
        public void FlagText(MarketQuoteIndicator mqi, string text, int heightSpace, IndicatorViewCanvasContext context, Func<Color> getColor)
        {
            Brush brush = new SolidBrush(getColor());
            var bottom = DisplayRectangle.Y + context.H1;
            var hy = (int)(bottom - (mqi.High - context.lp.Value) * context.mp - 20);
            var halfSpace = AxisSpace / 2;
            context.g.DrawString(text, this.StockFont, brush, new PointF(context.X - halfSpace, hy - heightSpace));
        }
        public abstract void DrawIndicatorLines(MarketQuoteIndicator mqi, Packet indicatorPacket, IndicatorViewCanvasContext canvasContext);
    }
}
