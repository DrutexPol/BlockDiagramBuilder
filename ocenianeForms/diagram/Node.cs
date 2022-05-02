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
    abstract class Node
    {
        [DataMember] public int x { get; private set; }
        [DataMember] public int y { get; private set; }
        [DataMember] public bool hidden { get; set; }

        [DataMember] protected int radius = 5;

        public Node(int x, int y)
        {
            setPosition(x, y);
        }

        public virtual void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual bool isPointInside(int px, int py)
        {
            return ((px - x) * (px - x) + (py - y) * (py - y) <= radius);
        }
        public abstract void draw(Graphics g);
    }
}