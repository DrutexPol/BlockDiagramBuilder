using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ocenianeForms.diagram;
using ocenianeForms.Properties;

namespace ocenianeForms
{
    [DataContract(IsReference = true)]
    class MyRect : Shape
    {
        [DataMember]
        private Node topNode;
        [DataMember]
        private Node bottomNode;
        public MyRect(int x, int y) : base(x,y)
        {
            this.text = Properties.Strings.operation_block;
            generateNodes();
            setPosition(x, y);
        }

        public override void generateNodes()
        {
            topNode = new HollowNode(x, y - Ysize / 2);
            hollowNodes.Add(topNode);
            bottomNode = new FullNode(x, y + Ysize / 2);
            fullNodes.Add(bottomNode);
        }

        public override void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            points = new PointF[]
            {
                new PointF(x - Xsize / 2, y - Ysize / 2),
                new PointF(x - Xsize / 2, y + Ysize / 2),
                new PointF(x + Xsize / 2, y + Ysize / 2),
                new PointF(x + Xsize / 2, y - Ysize / 2)
            };
            topNode.setPosition(x, y - Ysize / 2);
            bottomNode.setPosition(x, y + Ysize / 2);
        }

        public override bool isPointInside(int px, int py)
        {
            return (px >= points[0].X && px <= points[2].X && py >= points[0].Y && py <= points[2].Y);
        }
    }
}
