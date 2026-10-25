using OX.Mining.DEX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public abstract class IndicatorCandlesViewCanvas : CandlesViewCanvas
    {
        public override bool ShowGrid => false;

        public override bool ShowIndicators => true;
        public override void ReloadInitData(UInt160 hostSH, SwapPairMerge swapPairMerge, MarketQuote[] initDatas = null)
        {
            RwSyncRootLock.EnterReadLock();
            try
            {
                if (initDatas.Any())
                {
                    //var newDatas = initDatas.TakeLast(720);
                    var initlast = initDatas.Last();
                    //DateTime dataLastTime = DateTime.MinValue;
                    //if (this.Data.IsNotNullAndEmpty())
                    //    dataLastTime = this.Data.Last().Timestamp;
                    //if (initlast.Timestamp > dataLastTime)
                    //{
                    var indicatorBuilder = this.GetIndicatorPacketBuilder();
                    Data = indicatorBuilder.Build(hostSH, swapPairMerge, initDatas.ToList()).TimeSort();
                    //}
                    //else if (initlast.Timestamp == dataLastTime)
                    //{
                    //    var list = this.Data.TimeSort().Take(this.Data.Count() - 1).ToList();
                    //    list.Add(initlast);
                    //    this.Data = list.TimeSort();
                    //}
                    RefreshGraph(!this.ShowCrossHair);
                }
            }
            finally
            {
                RwSyncRootLock.ExitReadLock();
            }
        }
    }
}
