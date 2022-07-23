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
            SHPDocument sp = new SHPDocument();

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

            SHPPoint p1 = sp.GetPoint(0, 0, 0);
            SHPPoint p2 = sp.GetPoint(0, 100, 0);
            SHPPoint p3 = sp.GetPoint(0, 200, 0);
            SHPPoint p4 = sp.GetPoint(0, 300, 0);

            SHPLine l1 = new SHPLine(p1, p2);
            SHPLine l2 = new SHPLine(p2, p3);
            SHPLine l3 = new SHPLine(p3, p4);

            sp.AddLine(l1);
            sp.AddLine(l2);
            sp.AddLine(l3);

            sp.Simplify();

        }

        public static void ReverseTest()
        {
            SHPDocument sp = new SHPDocument();

            // need to create a list of points and how these are linked to lines
            /*
             * p1  p2 
             * +---+
             * |   |
             * +---+
             * p4  p3
             * 
             */

            SHPPoint p1 = sp.GetPoint(0, 0, 0);
            SHPPoint p2 = sp.GetPoint(100, 0, 0);
            SHPPoint p3 = sp.GetPoint(100, 100, 0);
            SHPPoint p4 = sp.GetPoint(0, 100, 0);

            SHPLine l1 = new SHPLine(p2, p1);
            SHPLine l2 = new SHPLine(p4, p3);
            SHPLine l3 = new SHPLine(p4, p1);
            SHPLine l4 = new SHPLine(p3, p2);

            sp.AddLine(l1);
            sp.AddLine(l2);
            sp.AddLine(l3);
            sp.AddLine(l4);

            sp.Simplify();

        }

        public static void BoxTest()
        {
            SHPDocument sp = new SHPDocument();

            // need to create a list of points and how these are linked to lines
            /*
             * p1  p2 
             * +---+
             * |   |
             * +---+
             * p4  p3
             * 
             */

            SHPPoint p1 = sp.GetPoint(0, 0, 0);
            SHPPoint p2 = sp.GetPoint(100, 0, 0);
            SHPPoint p3 = sp.GetPoint(100, 100, 0);
            SHPPoint p4 = sp.GetPoint(0, 100, 0);

            SHPLine l1 = new SHPLine(p1, p2);
            SHPLine l2 = new SHPLine(p2, p3);
            SHPLine l3 = new SHPLine(p3, p4);
            SHPLine l4 = new SHPLine(p4, p1);

            sp.AddLine(l1);
            sp.AddLine(l2);
            sp.AddLine(l3);
            sp.AddLine(l4);

            sp.Simplify();

        }

        public static void EightTest()
        {
            SHPDocument sp = new SHPDocument();

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

            SHPPoint p1 = sp.GetPoint(0, 0, 0);
            SHPPoint p2 = sp.GetPoint(100, 0, 0);
            SHPPoint p3 = sp.GetPoint(100, 100, 0);
            SHPPoint p4 = sp.GetPoint(0, 100, 0);
            SHPPoint p5 = sp.GetPoint(0, 200, 0);
            SHPPoint p6 = sp.GetPoint(100, 200, 0);

            SHPLine l1 = new SHPLine(p1, p2);
            SHPLine l2 = new SHPLine(p2, p3);
            SHPLine l3 = new SHPLine(p3, p4);
            SHPLine l4 = new SHPLine(p4, p1);
            SHPLine l5 = new SHPLine(p3, p6);
            SHPLine l6 = new SHPLine(p4, p5);
            SHPLine l7 = new SHPLine(p5, p6);

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
            SHPDocument sp = new SHPDocument();

            // Assume that we identify from the DXF the points
            // the aim would be to round to some level of 
            // resolution then build the shape

            SHPPoint p1 = sp.GetPoint(0, 0, 0);
            SHPPoint p2 = sp.GetPoint(10, 0, 0);
            SHPPoint p3 = sp.GetPoint(10, 0, 0);
            SHPPoint p4 = sp.GetPoint(20, 0, 0);

            SHPLine l1 = new SHPLine(p1, p2);
        }

        public static void ItterateTest()
        {
            SHPDocument sp = new SHPDocument();
            sp.AddLine(new SHPLine(sp.GetPoint(0, 0, 0), sp.GetPoint(10, 0, 0)));
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
            // Translate data and add the the shapes
            SHPDocument sp = new SHPDocument();

            SHPPoint p1 = sp.GetPoint(0, 0, 0);
            SHPPoint p2 = sp.GetPoint(10, 0, 0);
            SHPPoint p3 = sp.GetPoint(10, 0, 0);
            SHPPoint p4 = sp.GetPoint(20, 0, 0);

            SHPLine l1 = new SHPLine(p1, p2);
            SHPLine l2 = new SHPLine(p3, p4);

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
            SHPDocument sp = new SHPDocument();

            SHPPoint p1 = sp.GetPoint(0, 0, 0);
            SHPPoint p2 = sp.GetPoint(100, 0, 0);
            SHPPoint p3 = sp.GetPoint(100, 100, 0);
            SHPPoint p4 = sp.GetPoint(0, 100, 0);

            SHPLine l1 = new SHPLine(p1, p2);
            SHPLine l2 = new SHPLine(p2, p3);
            SHPLine l3 = new SHPLine(p3, p4);
            SHPLine l4 = new SHPLine(p4, p1);

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
            QuadTree<SHPPoint> qt = new QuadTree<SHPPoint>();
            SHPPoint p1 = new SHPPoint(0, 0, 0);
            qt.Bounds = new SHPRectangle(p1, 100, 100);
            SHPPoint p2 = new SHPPoint(10, 10, 0);
            qt.Insert(p2, new SHPRectangle(p2, 1, 1));
            SHPPoint p3 = new SHPPoint(10, 90, 0);
            qt.Insert(p3, new SHPRectangle(p3, 1, 1));
            SHPPoint p4 = new SHPPoint(90, 90, 0);
            qt.Insert(p4, new SHPRectangle(p4, 1, 1));
            SHPPoint p5 = new SHPPoint(90, 10, 0);
            qt.Insert(p5, new SHPRectangle(p5, 1, 1));

            SHPPoint p6 = new SHPPoint(5, 5, 0);
            foreach (SHPPoint p in qt.GetNodesInside(new SHPRectangle(p6, 10, 10)))
            {
                Console.WriteLine(p.ToString());
            }
        }

        public static void LineTest()
        {
            // Test the SHPLine function

            /*     p2 +----+ p4
             *        |    |
             *        |    |
             *        | p2 |
             *        |    |
             *        |
             *        | p1 |
             *     p1 +----+
             *             |
             *             | 
             *  p3 +-------+ 
             */

            SHPDocument sp = new SHPDocument();

            SHPPoint p1 = sp.GetPoint(50, 0, 0);
            SHPPoint p2 = sp.GetPoint(50, 100, 0);
            SHPPoint p3 = sp.GetPoint(0, 50, 0);
            SHPPoint p4 = sp.GetPoint(100, 50, 0);

            SHPLine l1 = new SHPLine(p1, p2);
            SHPLine l2 = new SHPLine(p3, p4);
            Console.WriteLine("Intersect=" + l1.IntersectsWith(l2));

            SHPPoint p5 = new SHPPoint(50, 25, 0);

            l1 = new SHPLine(p1, p5);
            l2 = new SHPLine(p3, p4);
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

            SHPDocument sp = new SHPDocument();

            SHPPoint p1 = sp.GetPoint(30, 30, 0);
            SHPPoint p2 = sp.GetPoint(60, 90, 0);

            SHPRectangle r1 = new SHPRectangle(p1, 50, 50);
            SHPRectangle r2 = new SHPRectangle(p2, 20, 80);
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
            r1 = new SHPRectangle(p1, 70, 70);
            p2 = sp.GetPoint(20, 20, 0);
            r2 = new SHPRectangle(p2, 60, 60);
            
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
            r1 = new SHPRectangle(p1, 40, 40);
            p2 = sp.GetPoint(30, 30, 0);
            r2 = new SHPRectangle(p2, 40, 40);
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

    class PointComparer : IEqualityComparer<SHPPoint>
    {
        public bool Equals(SHPPoint x, SHPPoint y)
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

        public int GetHashCode(SHPPoint SHPPoint)
        {
            return HashCode.Combine(SHPPoint.X, SHPPoint.Y, SHPPoint.Z);
        }
    }
}
