using System.Drawing;
using System.Runtime.Serialization;
using ocenianeForms.diagram;

namespace ocenianeForms.shapes
{
    [DataContract(IsReference = true)]
    abstract class Elipsa : Shape
    {
        public Elipsa(int x, int y) : base(x, y)
        {
            generateNodes();
            setPosition(x, y);
        }

        protected abstract Pen getPen(bool dashed);

        public override void draw(Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                var pen = getPen(selected);
                rectangle = new Rectangle(x - Xsize / 2, y - Ysize / 2, Xsize, Ysize);
                g.FillEllipse(Brushes.White, x - Xsize / 2, y - Ysize / 2, Xsize, Ysize);
                g.DrawEllipse(pen, x - Xsize / 2, y - Ysize / 2, Xsize, Ysize);
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

        public override bool isPointInside(int px, int py)
        {
            return (((px - (double)x) * (px - (double)x)) / (Xsize * (double)Xsize / 4d) + ((py - (double)y) * (py - (double)y)) / (Ysize * (double)Ysize / 4d) <= 1d);
        }

        public override bool isTextEditable()
        {
            return false;
        }
    }
}
