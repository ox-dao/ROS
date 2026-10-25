using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public record EMAResult
    {
        public DateTime Timestamp { get; set; }
        public double EMA { get; set; }
    }
    public class MarketIndicatorPacket : IndicatorPacket
    {
        public double Close { get; set; }
        public double EMAFast { get; set; }
        public double EMASlow { get; set; }
    }
}
