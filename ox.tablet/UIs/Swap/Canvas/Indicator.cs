using OX.Mining.DEX;
using Sunny.UI;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public interface IQuoteIndicator
    {
        IndicatorPacket Indicator { get; }
    }
    /// <summary>
    /// 技术指标包
    /// </summary>
    public abstract class IndicatorPacket
    {
        public string IndicatorPacketName;
        public IndicatorPacket()
        {
            IndicatorPacketName = this.GetType().FullName;
        }
    }
    /// <summary>
    /// 指标包构建器基类
    /// </summary>
    public abstract class IndicatorPacketBuilder
    {
        public abstract IEnumerable<MarketQuoteIndicator> Build(UInt160 hostSH, SwapPairMerge swapPairMerge, List<MarketQuote> quotes);
    
    }
    public record SingleIndicator 
    {
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
    public record MarketQuote 
    {
        public DateTime Timestamp { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public int Index { get; set; }
        public int X { get; set; }
        #region binance
        /// <summary>
        /// 收盘时间
        /// </summary>
        public DateTime CloseTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 成交额
        /// </summary>
        public decimal QuoteAssetVolume { get; set; } = 0;

        /// <summary>
        /// 成交笔数
        /// </summary>
        public int TradeCount { get; set; } = 0;

        /// <summary>
        /// 主动买入成交量
        /// </summary>
        public decimal BuyBaseAssetVolume { get; set; } = 0;

        /// <summary>
        /// 主动买入成交额
        /// </summary>
        public decimal BuyQuoteAssetVolume { get; set; } = 0;
        #endregion

        // 中位价 (High+Low)/2
        public decimal MidPrice => (High + Low) / 2;
        //实体中位价 (Open+Close)/2（仅判定K线实体穿越，过滤影线）
        public decimal BodyMidPrice => (Open + Close) / 2;
        public float Close_Float => (float)Close;
        public double Close_Double => (double)Close;
        public double Open_Double => (double)Open;
        public double High_Double => (double)High;
        public double Low_Double => (double)Low;
        public decimal Typical_Price => (High + Low + Close) / 3;
        public decimal WeightClose_Price => (High + Low + Close * 2) / 4;
        public decimal HLCA_Price => (Open + High + Low + Close) / 4;
    }
    public record MarketQuoteIndicator : MarketQuote, IQuoteIndicator
    {
        public decimal AveragePrice => (Open + High + Low + Close) / 4;
        public decimal OrderPrice => Close;
        public IndicatorPacket Indicator { get; set; }
        public bool IndicatorAs<T>(out T indicator) where T : IndicatorPacket
        {
            indicator = default;
            if (this.Indicator is T)
            {
                indicator = this.Indicator as T;
                return true;
            }
            return false;
        }

    }

}
