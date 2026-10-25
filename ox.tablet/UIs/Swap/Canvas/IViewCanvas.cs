using OX.Mining.DEX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public interface IViewCanvas
    {
       string ChartName { get; }
       bool ShowIndicators { get; }
        bool ShowGrid { get;  } 
         
        void ReloadInitData(UInt160 hostSH, SwapPairMerge swapPairMerge, MarketQuote[] initDatas = null);
    }
}
