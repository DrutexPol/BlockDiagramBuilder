using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ocenianeForms.diagram
{
    [DataContract(IsReference = true)]
    class Edge
    {
        public Edge(Node node1, Node node2)
        {
            this.node1 = node1;
            this.node2 = node2;
        }
        [DataMember]
        public Node node1 { get; private set; }
        [DataMember]
        public Node node2 { get; private set; }
        public void draw(Graphics graphics)
        {
            using (Pen p = new Pen(Color.Black,2))
            using (GraphicsPath capPath = new GraphicsPath())
            {
                p.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(7, 7, true);
                graphics.DrawLine(p, node1.x, node1.y, node2.x, node2.y);

            }
        }
    }
}
