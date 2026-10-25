using OX.Mining.DEX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public class MarketIndicatorPacketBuilder : IndicatorPacketBuilder
    {
        /// <summary>
        /// 计算EMA 指数移动平均
        /// </summary>
        /// <param name="quotes">原始价格序列(收盘价)</param>
        /// <param name="period">EMA周期 N</param>
        /// <returns>EMA结果数组，前面period‑1个为NaN，和输入等长</returns>
        public static (bool success, EMAResult[] ema) CalcEma(IList<MarketQuote> quotes, int period)
        {
            if (quotes == null || quotes.Count == 0)
                return (false, null);
            if (period < 1|| period > quotes.Count)
                return (false, null);

            int len = quotes.Count;
            EMAResult[] ema = new EMAResult[len];
            double alpha = 2.0 / (period + 1);

            // 前 period‑1 位置填充NaN
            for (int i = 0; i < period - 1; i++)
            {
                ema[i] = new EMAResult { EMA = 0, Timestamp = quotes[i].Timestamp };
            }

            // 初始值：前N个价格简单平均 SMA
            double initialSma = quotes.Take(period).Select(q => (double)q.Close).Average();
            ema[period - 1] = new EMAResult { EMA = initialSma, Timestamp = quotes[period - 1].Timestamp };

            // 迭代计算后续 EMA
            for (int i = period; i < len; i++)
            {
                ema[i] = new EMAResult
                {
                    EMA = quotes[i].Close_Double * alpha + ema[i - 1].EMA * (1 - alpha),
                    Timestamp = quotes[i].Timestamp
                };
            }
            return (true, ema);
        }
        public override IEnumerable<MarketQuoteIndicator> Build(UInt160 hostSH, SwapPairMerge swapPairMerge, List<MarketQuote> quotes)
        {
            var fastResults = CalcEma(quotes, 6);
            var slowResults = CalcEma(quotes, 12);
            return quotes.ToArray().ExtensionAs<MarketQuoteIndicator>((input, index, output) =>
              {
                  MarketIndicatorPacket mip = new MarketIndicatorPacket
                  {
                      Close = (double)input.Close,
                      EMAFast = fastResults.success? fastResults.ema.FirstOrDefault(m => m.Timestamp == input.Timestamp).EMA: 0,
                      EMASlow = slowResults.success? slowResults.ema.FirstOrDefault(m => m.Timestamp == input.Timestamp).EMA: 0,
                  };
                  output.Indicator = mip;
              });

        }
    }
}
