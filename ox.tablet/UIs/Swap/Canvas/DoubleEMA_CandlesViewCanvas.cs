using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public class DoubleEMA_CandlesViewCanvas : CommonCandlesViewCanvas<MarketIndicatorPacket, MarketIndicatorPacketBuilder>
    {
        public override string ChartName => "技术指标";
        public override void DrawIndicatorLines(MarketQuoteIndicator mqi, MarketIndicatorPacket indicatorPacket, IndicatorViewCanvasContext canvasContext)
        {
            Line(n => n.EMAFast, indicatorPacket.EMAFast, canvasContext, () =>
            {
                return YellowPen_2;
            });
            Line(n => n.EMASlow, indicatorPacket.EMASlow, canvasContext, () =>
            {
                return WhitePen_2;
            });
        }
    }
}
