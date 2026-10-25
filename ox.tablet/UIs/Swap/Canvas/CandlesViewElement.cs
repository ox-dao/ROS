using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public class CandlesViewElement : ViewElement
    {
        public CandlesViewElement PreElement { get; set; }
        public List<ViewElement> Elements { get; private set; } = new List<ViewElement>();
        public override void Draw(Graphics g, Rectangle drawRectangle)
        {
            foreach(var element in Elements)
            {
                element.Draw(g, drawRectangle);
            }
        }
    }
}
