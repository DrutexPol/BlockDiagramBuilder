using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ocenianeForms
{
    class BasicPens
    {
        public static readonly Pen blackPen = new Pen(Color.Black,2);
        public static readonly Pen redPen = new Pen(Color.Red,2);
        public static readonly Pen greenPen = new Pen(Color.LawnGreen,2);

        public static readonly Pen blackDashPen = new Pen(Color.Black,2);
        public static readonly Pen redDasPen = new Pen(Color.Red,2);
        public static readonly Pen greenDasPen = new Pen(Color.LawnGreen,2);

        static BasicPens()
        {
            blackDashPen.DashPattern = new float[] { 2f, 1f };
            greenDasPen.DashPattern = new float[] { 2f, 1f };
            redDasPen.DashPattern = new float[] { 2f, 1f };
        }
    }
}
