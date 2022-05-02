using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ocenianeForms.diagram;

namespace ocenianeForms.shapes
{
    [DataContract(IsReference = true)]
    class StartShape : Elipsa
    {
        [DataMember]
        private Node bottomNode;
        public StartShape(int x, int y) : base(x, y)
        {
            this.text = "START";
        }

        protected override Pen getPen(bool dashed)
        {
            if (dashed) return BasicPens.greenDasPen;
            return BasicPens.greenPen;
        }

        public override void generateNodes()
        {
            bottomNode = new FullNode(x, y + Ysize / 2);
            fullNodes.Add(bottomNode);
        }

        public override void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            bottomNode.setPosition(x, y + Ysize / 2);
        }
    }
}