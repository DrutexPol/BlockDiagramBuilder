using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ocenianeForms.diagram;

namespace ocenianeForms
{
    [DataContract(IsReference = true)]
    abstract class Shape
    {
        [DataMember]
        protected int Xsize = 110;
        [DataMember]
        protected int Ysize = 80;
        [DataMember]
        public PointF[] points;
        [DataMember]
        public string text { set; get; }
        [DataMember]
        public Rectangle rectangle { set; get; }
        [DataMember]
        public int x { get; protected set; }
        [DataMember]
        public int y { get; protected set; }
        [DataMember] 
        public bool selected { get; set; }

        [DataMember] public List<Node> fullNodes { get; protected set; } = new List<Node>();
        [DataMember] public List<Node> hollowNodes { get; protected set; } = new List<Node>();
        public virtual void draw(Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                var pen = BasicPens.blackPen;
                if (selected) pen = BasicPens.blackDashPen;
                rectangle = new Rectangle(x - Xsize / 2, y - Ysize / 2, Xsize, Ysize);
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
        }
        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract void generateNodes();
        public abstract void setPosition(int x, int y);
        public abstract bool isPointInside(int px, int py);

        public virtual bool isTextEditable()
        {
            return true;
        }
    }
}
