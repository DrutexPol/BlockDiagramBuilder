using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using ocenianeForms.shapes;

namespace ocenianeForms.diagram
{
    [KnownType(typeof(MyRect))]
    [KnownType(typeof(MyRomb))]
    [KnownType(typeof(StartShape))]
    [KnownType(typeof(EndShape))]
    [KnownType(typeof(Shape))]
    [KnownType(typeof(Elipsa))]
    [KnownType(typeof(Node))]
    [KnownType(typeof(FullNode))]
    [KnownType(typeof(HollowNode))]
    [DataContract]
    class Diagram
    {
        [DataMember] private LinkedList<Shape> shapes = new LinkedList<Shape>();

        // [DataMember]
        private Bitmap bitmap;
        [DataMember] private int width;
        [DataMember] private int height;
        [DataMember] public Shape Selected { get; private set; }
        [DataMember] public HashSet<Edge> edges = new HashSet<Edge>();
        [DataMember] private StartShape startBlock;

        public Diagram(int width, int height)
        {
            this.width = width;
            this.height = height;
            bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, 0, 0, width, height);
            }
        }

        private Diagram()
        {
        }

        public void addShape(Shape shape)
        {
            if (shape is StartShape)
            {
                if (startBlock != null) throw new IOException(Properties.Strings.only_one_possible);
                startBlock = (StartShape) shape;
            } 
            shapes.AddFirst(shape);
            shape.draw(bitmap);
        }

        public Bitmap GetBitmap() => bitmap;

        public static Diagram Read(Stream stream)
        {
            // var deserializedUser = new Diagram();
            // var ser = new DataContractJsonSerializer(typeof(Diagram));
            // deserializedUser = (Diagram) ser.ReadObject(stream);
            // return null;
            var settings = new DataContractSerializerSettings();
            settings.PreserveObjectReferences = true;
            var ser = new DataContractSerializer(typeof(Diagram),settings);
            Diagram diagram = ser.ReadObject(stream) as Diagram;
            return diagram;
        }

        public void Save(Stream stream)
        {
            var settings = new DataContractSerializerSettings();
            settings.PreserveObjectReferences = true;
            var ser = new DataContractSerializer(typeof(Diagram), settings);
            ser.WriteObject(stream, this);
        }

        public void refresh()
        {
            if (bitmap == null) bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, 0, 0, width, height);
            }

            var el = shapes.Last;
            while (el != null)
            {
                if (el.Value.selected) Selected = el.Value;
                el.Value.draw(bitmap);
                el = el.Previous;
            }

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (Edge edge in edges)
                {
                    edge.draw(g);
                }
            }
        }

        public void moveSelected(int x, int y)
        {
            if (Selected == null) return;
            int nx = Selected.x;
            int ny = Selected.y;
            if (nx + x > 0 && nx + x < width) nx += x;
            if (ny + y > 0 && ny + y < height) ny += y;
            Selected.setPosition(nx, ny);
        }

        public Shape select(int x, int y)
        {
            Selected = null;
            bool already_selected = false;
            foreach (var shape in shapes)
            {
                if (shape.isPointInside(x, y))
                {
                    if (!already_selected)
                    {
                        shape.selected = true;
                        Selected = shape;
                        already_selected = true;
                    }
                    else
                    {
                        shape.selected = false;
                    }
                }
                else
                {
                    shape.selected = false;
                }
            }

            refresh();
            return Selected;
        }

        public bool selectFullNode(int x, int y)
        {
            foreach (Shape shape in shapes)
            {
                foreach (Node node in shape.fullNodes)
                {
                    if (node.isPointInside(x, y)) return true;
                }
            }

            return false;
        }

        public void createNode(int x1, int y1, int x2, int y2)
        {
            Node n1 = null;
            Node n2 = null;
            foreach (Shape shape in shapes)
            {
                foreach (Node node in shape.fullNodes)
                {
                    if (node.isPointInside(x1, y1))
                    {
                        if (n1 == null)
                        {
                            n1 = node;
                        }
                    }
                }

                foreach (Node node in shape.hollowNodes)
                {
                    if (node.isPointInside(x2, y2))
                    {
                        if (n2 == null)
                        {
                            n2 = node;
                        }
                    }
                }

                if (n1 != null && n2 != null) break;
            }

            if (n1 != null && n2 != null)
            {
                n1.hidden = true;
                n2.hidden = true;
                edges.Add(new Edge(n1, n2));
            }
        }

        public void delete(int x, int y)
        {
            foreach (var shape in shapes)
            {
                if (shape.isPointInside(x, y))
                {
                    shapes.Remove(shape);
                    if (shape.Equals(startBlock)) startBlock = null;
                    foreach (Edge edge in edges)
                    {
                        foreach (Node node in shape.fullNodes)
                        {
                            if (edge.node1.Equals(node))
                            {
                                edges.Remove(edge);
                                edge.node2.hidden = false;
                            }
                        }

                        foreach (Node node in shape.hollowNodes)
                        {
                            if (edge.node2.Equals(node))
                            {
                                edges.Remove(edge);
                                edge.node1.hidden = false;
                            }
                        }
                    }
                    break;
                }
            }

            refresh();
        }

        public void drawLine(int x1, int y1, int x2, int y2)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(BasicPens.blackPen, x1, y1, x2, y2);
            }
        }
    }
}