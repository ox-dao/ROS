using OX.Mining.DEX;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public partial class Stock_IndicatorMarketUI : UserControl
    {
        public UInt160 HostSH;
        public SwapPairMerge SwapPairMerge;


        public string Title { get; private set; }
        public Stock_IndicatorMarketUI()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.doubleemA_CandlesViewCanvas1.Margin = new Padding(2);
            this.doubleemA_CandlesViewCanvas1.RightPixSpace = 85;
        }
        public void OnHeart(DateTime heartTime)
        {

        }
        IEnumerable<KeyValuePair<SwapPairExchangeKey, SwapVolumeMerge>> LoadData;
        public void Init(UInt160 hostSH, SwapPairMerge swapPairMerge, IEnumerable<KeyValuePair<SwapPairExchangeKey, SwapVolumeMerge>> loaddata, bool isHour)
        {
            this.HostSH = hostSH;
            this.SwapPairMerge = swapPairMerge;
            this.LoadData = loaddata;
            var initDatas = ReloadInitData(isHour);
            this.doubleemA_CandlesViewCanvas1.ReloadInitData(this.HostSH, this.SwapPairMerge, initDatas);
        }
        MarketQuote[] ReloadInitData(bool isHour)
        {
            List<MarketQuote> datas = new List<MarketQuote>();
            var last = this.LoadData.OrderByDescending(m => m.Key.Timestamp).FirstOrDefault();
            foreach (var g in this.LoadData.GroupBy(m => isHour ? this.GetHourDateTime(m.Key.Timestamp.ToDateTime()) : this.GetDayDateTime(m.Key.Timestamp.ToDateTime())).OrderBy(m => m.Key))
            {

                var gs = g.OrderBy(m => m.Key.Timestamp);
                var volume = g.Sum(m => m.Value.Volume.TargetAssetVolume);
                var quote = new MarketQuote
                {
                    Timestamp = g.Key,
                    Open = gs.First().Value.Price,
                    Close = gs.Last().Value.Price,
                    High = gs.Max(m => m.Value.Price),
                    Low = gs.Min(m => m.Value.Price),
                    Volume = (Decimal)volume,
                };
                datas.Add(quote);
            }
            return datas.TimeSort();
        }

        #region 时间处理
        /// <summary>
        /// 获取当前时间对应的双数整点DateTime
        /// </summary>
        /// <param name="currentTime">当前时间</param>
        /// <returns>双数整点时间</returns>
        public DateTime GetHourDateTime(DateTime currentTime)
        {
            // 构造双数整点时间（分/秒/毫秒置0）
            return new DateTime(
                currentTime.Year,
                currentTime.Month,
                currentTime.Day,
                currentTime.Hour,
                0,
                0,
                0
            );
        }

        public DateTime GetDayDateTime(DateTime currentTime)
        {
            // 构造双数整点时间（分/秒/毫秒置0）
            return new DateTime(
                currentTime.Year,
                currentTime.Month,
                currentTime.Day,
                0,
                0,
                0,
                0
            );
        }
        #endregion
    }
}
