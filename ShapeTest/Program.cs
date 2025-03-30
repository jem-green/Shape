using System;
using System.Collections.Generic;
using ShapeLibrary;

namespace ShapeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //QuadTest();
            RectTest();
            //LineTest();
            //PolyTest();
            //BoxTest();
            //ReverseTest();
            //EndpointTest();
            //ChainTest();
            //EightTest();
        }

        public static void ChainTest()
        {
            Document sp = new Document();

            // need to create a list of points and how these are linked to lines
            /*
             * p1 
             * +
             * |
             * + p2
             * |
             * + p3
             * |
             * +
             * p4
             */

            Point p1 = sp.GetPoint(0, 0, 0);
            Point p2 = sp.GetPoint(0, 100, 0);
            Point p3 = sp.GetPoint(0, 200, 0);
            Point p4 = sp.GetPoint(0, 300, 0);

            Line l1 = new Line(p1, p2);
            Line l2 = new Line(p2, p3);
            Line l3 = new Line(p3, p4);

            sp.AddLine(l1);
            sp.AddLine(l2);
            sp.AddLine(l3);

            sp.Simplify();

        }

        public static void ReverseTest()
        {
            Document sp = new Document();

            // need to create a list of points and how these are linked to lines
            /*
             * p1  p2 
             * +---+
             * |   |
             * +---+
             * p4  p3
             * 
             */

            Point p1 = sp.GetPoint(0, 0, 0);
            Point p2 = sp.GetPoint(100, 0, 0);
            Point p3 = sp.GetPoint(100, 100, 0);
            Point p4 = sp.GetPoint(0, 100, 0);

            Line l1 = new Line(p2, p1);
            Line l2 = new Line(p4, p3);
            Line l3 = new Line(p4, p1);
            Line l4 = new Line(p3, p2);

            sp.AddLine(l1);
            sp.AddLine(l2);
            sp.AddLine(l3);
            sp.AddLine(l4);

            sp.Simplify();

        }

        public static void BoxTest()
        {
            Document sp = new Document();

            // need to create a list of points and how these are linked to lines
            /*
             * p1  p2 
             * +---+
             * |   |
             * +---+
             * p4  p3
             * 
             */

            Point p1 = sp.GetPoint(0, 0, 0);
            Point p2 = sp.GetPoint(100, 0, 0);
            Point p3 = sp.GetPoint(100, 100, 0);
            Point p4 = sp.GetPoint(0, 100, 0);

            Line l1 = new Line(p1, p2);
            Line l2 = new Line(p2, p3);
            Line l3 = new Line(p3, p4);
            Line l4 = new Line(p4, p1);

            sp.AddLine(l1);
            sp.AddLine(l2);
            sp.AddLine(l3);
            sp.AddLine(l4);

            sp.Simplify();

        }

        public static void EightTest()
        {
            Document sp = new Document();

            // need to create a list of points and how these are linked to lines
            /*
             *    p1  p2 
             *    +----+
             *    |    |
             * p4 +----+ p3
             *    |    |
             *    +----+
             *    p5  p6
             */

            Point p1 = sp.GetPoint(0, 0, 0);
            Point p2 = sp.GetPoint(100, 0, 0);
            Point p3 = sp.GetPoint(100, 100, 0);
            Point p4 = sp.GetPoint(0, 100, 0);
            Point p5 = sp.GetPoint(0, 200, 0);
            Point p6 = sp.GetPoint(100, 200, 0);

            Line l1 = new Line(p1, p2);
            Line l2 = new Line(p2, p3);
            Line l3 = new Line(p3, p4);
            Line l4 = new Line(p4, p1);
            Line l5 = new Line(p3, p6);
            Line l6 = new Line(p4, p5);
            Line l7 = new Line(p5, p6);

            sp.AddLine(l1);
            sp.AddLine(l2);
            sp.AddLine(l3);
            sp.AddLine(l4);

            sp.AddLine(l5);
            sp.AddLine(l6);
            sp.AddLine(l7);

            sp.Simplify();

        }

        public static void ConvertTest()
        {
            // Translate data and add the the shapes
            Document sp = new Document();

            // Assume that we identify from the DXF the points
            // the aim would be to round to some level of 
            // resolution then build the shape

            Point p1 = sp.GetPoint(0, 0, 0);
            Point p2 = sp.GetPoint(10, 0, 0);
            Point p3 = sp.GetPoint(10, 0, 0);
            Point p4 = sp.GetPoint(20, 0, 0);

            Line l1 = new Line(p1, p2);
        }

        public static void ItterateTest()
        {
            Document sp = new Document();
            sp.AddLine(new Line(sp.GetPoint(0, 0, 0), sp.GetPoint(10, 0, 0)));
            sp.AddShape(sp.GetPoint(1, 1, 1));
            foreach (IShape sh in sp)
            {
                Console.WriteLine(sh.ToString());
            }
        }

        /// <summary>
        /// Test merging and deleting points that nearly match
        /// </summary>
        public static void EndpointTest()
        {
            Document sp = new Document();

            // need to create points and lines and confirm that only the endpoints intersect
            /*
             *    p1  p2 
             *    +----+----+
             *         p3   p4
             */

            Point p1 = sp.GetPoint(0, 0, 0);
            Point p2 = sp.GetPoint(10, 0, 0);
            Point p3 = sp.GetPoint(10, 0, 0);
            Point p4 = sp.GetPoint(20, 0, 0);

            Line l1 = new Line(p1, p2);
            Line l2 = new Line(p3, p4);

            // Confirm that lines referncing the points
            // are updated

            p2.Z = -10;

        }

        /// <summary>
        /// Test constructing a polyline from an unordered list
        /// of lines
        /// </summary>
        public static void PolyTest()
        {
            Document sp = new Document();

            // need to create points and lines and confirm that a polygon is formed
            /*
             * p1  p2 
             * +----+
             * |    |
             * +----+
             * p4  p3    
             *    
             */

            Point p1 = sp.GetPoint(0, 0, 0);
            Point p2 = sp.GetPoint(100, 0, 0);
            Point p3 = sp.GetPoint(100, 100, 0);
            Point p4 = sp.GetPoint(0, 100, 0);

            Line l1 = new Line(p1, p2);
            Line l2 = new Line(p2, p3);
            Line l3 = new Line(p3, p4);
            Line l4 = new Line(p4, p1);

            // need to add lines to shapes

            sp.AddLine(l1);
            sp.AddLine(l2);
            sp.AddLine(l3);
            sp.AddLine(l4);

            sp.Simplify();

            foreach (IShape sh in sp)
            {
                Console.WriteLine(sh.ToString());
            }
        }

        public static void QuadTest()
        {
            QuadTree<Point> qt = new QuadTree<Point>();
            Point p1 = new Point(0, 0, 0);
            qt.Bounds = new Rectangle(p1, 100, 100);
            Point p2 = new Point(10, 10, 0);
            qt.Insert(p2, new Rectangle(p2, 1, 1));
            Point p3 = new Point(10, 90, 0);
            qt.Insert(p3, new Rectangle(p3, 1, 1));
            Point p4 = new Point(90, 90, 0);
            qt.Insert(p4, new Rectangle(p4, 1, 1));
            Point p5 = new Point(90, 10, 0);
            qt.Insert(p5, new Rectangle(p5, 1, 1));

            Point p6 = new Point(5, 5, 0);
            foreach (Point p in qt.GetNodesInside(new Rectangle(p6, 10, 10)))
            {
                Console.WriteLine(p.ToString());
            }
        }

        public static void LineTest()
        {
            // Test the SHPLine function

            /*             + p1
             *             | 
             *             | 
             *     p3 +----+----+ p4
             *            p2
             *
             *
             *             + p1
             *             |
             *             + p5
             *              
             *     p3 +---------+ p4
             *            
             *
             */

            Document sp = new Document();

            Point p1 = sp.GetPoint(50, 0, 0);
            Point p2 = sp.GetPoint(50, 100, 0);
            Point p3 = sp.GetPoint(0, 50, 0);
            Point p4 = sp.GetPoint(100, 50, 0);

            Line l1 = new Line(p1, p2);
            Line l2 = new Line(p3, p4);
            Console.WriteLine("Intersect=" + l1.IntersectsWith(l2));

            Point p5 = new Point(50, 25, 0);

            l1 = new Line(p1, p5);
            l2 = new Line(p3, p4);
            Console.WriteLine("Intersect=" + l1.IntersectsWith(l2));
        }

        public static void RectTest()
        {
            // Test the SHPRectangle function

            /*        +----+ 
             *        |    |
             *        |    |
             *    +---+    |
             *    |   |    |
             * p1 +---+    |
             *        |    |
             *     p2 +----+
             *  
             */

            Document sp = new Document();

            Point p1 = sp.GetPoint(30, 30, 0);
            Point p2 = sp.GetPoint(60, 90, 0);

            Rectangle r1 = new Rectangle(p1, 50, 50);
            Rectangle r2 = new Rectangle(p2, 20, 80);
            Console.WriteLine("contains=" + r2.Contains(r1));
            Console.WriteLine("contains=" + r1.Contains(r2));
            Console.WriteLine("intersect=" + r2.IntersectsWith(r1));
            Console.WriteLine("intersect=" + r1.IntersectsWith(r2));

            Console.WriteLine("----------");

            System.Drawing.Rectangle r3 = new System.Drawing.Rectangle(30, 30, 40, 40);
            System.Drawing.Rectangle r4 = new System.Drawing.Rectangle(40, 10, 20, 80);
            Console.WriteLine("contains=" + r4.Contains(r3));
            Console.WriteLine("contains=" + r3.Contains(r4));
            Console.WriteLine("intersect=" + r4.IntersectsWith(r3));
            Console.WriteLine("intersect=" + r3.IntersectsWith(r4));

            Console.WriteLine("----------");

            p1 = sp.GetPoint(30, 30, 0);
            r1 = new Rectangle(p1, 70, 70);
            p2 = sp.GetPoint(20, 20, 0);
            r2 = new Rectangle(p2, 60, 60);
            
            Console.WriteLine("contains=" + r2.Contains(r1));
            Console.WriteLine("contains=" + r1.Contains(r2));
            Console.WriteLine("intersect=" + r2.IntersectsWith(r1));
            Console.WriteLine("intersect=" + r1.IntersectsWith(r2));

            Console.WriteLine("----------");

            r3 = new System.Drawing.Rectangle(30, 30, 40, 40);
            r4 = new System.Drawing.Rectangle(20, 20, 60, 60);
            Console.WriteLine("contains=" + r4.Contains(r3));
            Console.WriteLine("contains=" + r3.Contains(r4));
            Console.WriteLine("intersect=" + r4.IntersectsWith(r3));
            Console.WriteLine("intersect=" + r3.IntersectsWith(r4));

            Console.WriteLine("----------");

            p1 = sp.GetPoint(30, 30, 0);
            r1 = new Rectangle(p1, 40, 40);
            p2 = sp.GetPoint(30, 30, 0);
            r2 = new Rectangle(p2, 40, 40);
            Console.WriteLine("contains=" + r2.Contains(r1));
            Console.WriteLine("contains=" + r1.Contains(r2));
            Console.WriteLine("intersect=" + r2.IntersectsWith(r1));
            Console.WriteLine("intersect=" + r1.IntersectsWith(r2));

            Console.WriteLine("----------");

            r3 = new System.Drawing.Rectangle(30, 30, 40, 40);
            r4 = new System.Drawing.Rectangle(30, 30, 40, 40);
            Console.WriteLine("contains=" + r4.Contains(r3));
            Console.WriteLine("contains=" + r3.Contains(r4));
            Console.WriteLine("intersect=" + r4.IntersectsWith(r3));
            Console.WriteLine("intersect=" + r3.IntersectsWith(r4));

            Console.WriteLine("----------");


        }
    }

    class PointComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point x, Point y)
        {
            if (x.X.Equals(y.X) != true)
            {
                return (false);
            }
            else if (x.Y.Equals(y.Y) != true)
            {
                return (false);
            }
            else if (x.Z.Equals(y.Z) != true)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        public int GetHashCode(Point SHPPoint)
        {
            return HashCode.Combine(SHPPoint.X, SHPPoint.Y, SHPPoint.Z);
        }
    }
}
