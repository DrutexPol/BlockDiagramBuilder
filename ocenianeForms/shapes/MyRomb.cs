using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ocenianeForms.diagram;

namespace ocenianeForms
{
    [DataContract(IsReference = true)]

    class MyRomb : Shape
    {
        [DataMember]
        private Node topNode;
        [DataMember]
        private Node rightNode;
        [DataMember]
        private Node leftNode;

        public MyRomb(int x, int y) : base(x, y)
        {
            Xsize = 110;
            Ysize = 110;
            generateNodes();
            setPosition(x, y);
            this.text = Properties.Strings.decision_block;
        }

        public override void generateNodes()
        {
            topNode = new HollowNode(x, y - Ysize / 2);
            leftNode = new FullNode(x - Xsize / 2, y);
            rightNode = new FullNode(x + Xsize / 2, y);
            fullNodes.Add(leftNode);
            fullNodes.Add(rightNode);
            hollowNodes.Add(topNode);
        }

        public override void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            points = new PointF[]
            {
                new PointF(x - Xsize / 2, y),
                new PointF(x, y + Ysize / 2),
                new PointF(x + Xsize / 2, y),
                new PointF(x, y - Ysize / 2)
            };
            topNode.setPosition(x, y - Ysize / 2);
            leftNode.setPosition(x - Xsize / 2, y);
            rightNode.setPosition(x + Xsize / 2, y);
        }

        public override void draw(Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                var pen = BasicPens.blackPen;
                if (selected) pen = BasicPens.blackDashPen;
                rectangle = new Rectangle(x - (Xsize - 40) / 2, y - (Ysize -40) / 2, Xsize-40, Ysize-40);
                g.FillPolygon(Brushes.White, points);
                g.DrawPolygon(pen, points);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, rectangle, stringFormat);
                foreach (Node node in fullNodes)
                {
                    node.draw(g);
                }
                foreach (Node node in hollowNodes)
                {
                    node.draw(g);
                }
            }
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawString("T",SystemFonts.DefaultFont,Brushes.Black, x - Xsize / 2 - 5, y - 28);
                g.DrawString("F",SystemFonts.DefaultFont,Brushes.Black, x + Xsize / 2 - 5, y - 28);
            }
        }

        public override bool isPointInside(int px, int py)
        {
            return (py <= px + y - x + Xsize / 2 && py >= px + y - Ysize / 2 - x && py >= -px + y + x - Xsize / 2 &&
                    py <= -px + y + Ysize / 2 + x);
        }
    }
}