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
    class EndShape : Elipsa
    {
        [DataMember]
        private Node topNode;
        public EndShape(int x, int y) : base(x, y)
        {
            this.text = "END";
        }

        protected override Pen getPen(bool dashed)
        {
            if (dashed) return BasicPens.redDasPen;
            return BasicPens.redPen;
        }

        public override void generateNodes()
        {
            topNode = new HollowNode(x, y - Ysize / 2);
            hollowNodes.Add(topNode);
        }

        public override void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            topNode.setPosition(x, y - Ysize / 2);
        }
    }
}