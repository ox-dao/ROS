using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OX.Tablet.UIs.Swap.Canvas
{
    /// <summary>
    /// 视图元素
    /// </summary>
    public abstract class ViewElement
    {
        public abstract void Draw(Graphics g, Rectangle drawRectangle);
    }
}
