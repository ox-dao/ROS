using OX.Mining.DEX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public abstract class ViewCanvas : ContainerControl, IViewCanvas
    {
        public abstract string ChartName { get; }
        public abstract bool ShowIndicators { get; }
        public abstract bool ShowGrid { get; }
        
        private object refresh_lock = new object();
        public readonly ReaderWriterLockSlim RwSyncRootLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        public ViewCanvas()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Paint += ViewCanvas_Paint;
        }

        private void ViewCanvas_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph();
        }
        public void DrawGraph()
        {
            PaintGraph(this.DisplayRectangle);
        }
        public void PaintGraph(Rectangle drawRectangle)
        {
            lock (refresh_lock)
            {
                BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
                BufferedGraphics myBuffer = currentContext.Allocate(this.CreateGraphics(), drawRectangle);
                Graphics g = myBuffer.Graphics;
                Draw(g, drawRectangle);
                myBuffer.Render();
                myBuffer.Dispose();
            }
        }
        public abstract void Draw(Graphics g, Rectangle drawRectangle);
        public abstract void ReloadInitData(UInt160 hostSH, SwapPairMerge swapPairMerge, MarketQuote[] initDatas = null);
    }
}
