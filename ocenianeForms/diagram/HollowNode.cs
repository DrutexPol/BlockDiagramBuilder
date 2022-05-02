using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ocenianeForms.diagram
{
    [DataContract]
    class HollowNode : Node
    {
        public HollowNode(int x, int y) : base(x, y)
        {
        }

        public override void draw(Graphics g)
        {
            if (hidden) return;
            g.FillEllipse(Brushes.White, x - radius, y - radius, 2 * radius, 2 * radius);
            g.DrawEllipse(BasicPens.blackPen,x-radius,y-radius,2*radius,2*radius);
        }
    }
}
