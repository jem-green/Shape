using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Space : IEnumerable<IShape>
    {
        #region Fields
        
        private List<IShape> _shapes;
        private List<Point> _points;
        
        #endregion
        #region Constructors

        public Space()
        {
            _shapes = new List<IShape>();
            _points = new List<Point>();
        }

        #endregion
        #region Properties
        #endregion
        #region Methods

        public void AddLine(Line line)
        {
            // Need to link the edge to a point
            // i dont want to necessarily add this
            // to the point structure perhaps another
            // linking structure

            line.From.AddShape(line);
            line.To.AddShape(line);
            _shapes.Add(line);
            // Assume that the points have already been added
            // so we can avoid adding twice
        }

        public void AddShape(IShape shape)
        {
            foreach
            _shapes.Add(shape);
        }

        public Point GetPoint(double x, double y, double z)
        {
            Point point = new Point(x, y, z);
            int pos = _points.BinarySearch(point);
            if (pos < 0)
            {
                _points.Add(point);
            }
            else
            {
                point = _points[pos];
            }
            return (point);
        }

        /// <summary>
        /// Convert unordered line, args to polygons and polylines
        /// </summary>
        public void Simplify()
        {
            // Carry out a depthfirst search on line segments
            // the problem here is that we need to build the connected
            // list of points by constructing a graph or we take
            // the same approach which is to build it as we go.

            // Might also be worth using the graph library
            // and copy the points

            Console.WriteLine("Reset");
            foreach(Point point in _points)
            {
                point.Status = Shape.SearchStatus.None;
            }

            // Now check through the points

            Console.WriteLine("Check which points are connected");
            foreach (Point point in _points)
            {
                if (point.Status == Shape.SearchStatus.Linked)
                {
                    Console.WriteLine("Try to link");

                }
                else if (point.Status == Shape.SearchStatus.None)
                {
                    Console.WriteLine("Try to simplify");

                    // Find all the points that are connected

                    List<Point> connected = new List<Point>();
                    DepthFirstSearch(connected, point);

                    // Sort the list by degree

                    Console.WriteLine("Sort points by degree");
                    connected.Sort(
                        delegate (Point p1, Point p2)
                        {
                            return p1.Degree.CompareTo(p2.Degree);
                        }
                    );

                    foreach (Point newPoint in connected)
                    {
                        if ((newPoint.Status & Shape.SearchStatus.Linked) == 0)
                        {
                            Console.WriteLine("Link shapes");
                            List<IShape> chain = new List<IShape>();
                            LinkSearch(chain, newPoint);

                            Console.WriteLine("List chain");
                            foreach (IShape shape in chain)
                            {
                                Console.WriteLine("shape=" + shape);
                            }
                        }
                    }
                }
            }
        }

        IEnumerator<IShape> IEnumerable<IShape>.GetEnumerator()
        {
            return (_shapes.GetEnumerator());
        }

        #endregion
        #region Private

        private void LinkSearch(List<IShape> chain, Point newPoint)
        {
            // This search aims to link the points together into long chains
            // only want to choose points from the connected list
            // Need to return a chain of shapes. The starting point should be any
            // line endings

            bool searching = true;
            newPoint.Status |= Shape.SearchStatus.Start;
            Point point;
            do
            {
                point = newPoint;
                // Get one of the shapes
                if (point.Shapes.Count > 0)
                {
                    foreach (IShape shape in point.Shapes)
                    {
                        if (shape.GetType() == typeof(Point))
                        {
                            // check if we enter here
                            searching = false;
                            break;
                        }
                        else if (shape.GetType() == typeof(Line))
                        {
                            Line line = (Line)shape;

                            if (line.Status == Shape.SearchStatus.None)
                            {
                                line.Status |= Shape.SearchStatus.Visited;
                                if (point == line.To)
                                {
                                    // Swap ends
                                    Point temp = line.To;
                                    line.To = line.From;
                                    line.From = temp;
                                }
                                Console.WriteLine("Add=" + line);
                                chain.Add(line);

                                newPoint = line.To;
                                newPoint.Status |= Shape.SearchStatus.Linked;

                                if (newPoint.Degree == 1)
                                {
                                    newPoint.Status |= Shape.SearchStatus.End;
                                    searching = false;
                                }
                                else if ((newPoint.Status & Shape.SearchStatus.Start) == Shape.SearchStatus.Start)
                                {
                                    searching = false;
                                }
                                break;
                            }
                            else
                            {
                                // Nothing to search for
                            }
                        }
                    }
                }
                else
                {
                    searching = false;
                }
                
                // should have a new point

            }
            while (searching == true);

        }

        private void DepthFirstSearch(List<Point> connected, Point point)
        {
            Console.WriteLine("point=" + point);
            point.Status = Shape.SearchStatus.Visited;
            if (point.Degree > 0)
            {
                // Trap the case where points are isolated
                connected.Add(point);

                foreach (IShape shape in point.Shapes)
                {

                    if (shape.GetType() == typeof(Line))
                    {
                        Line line = (Line)shape;

                        // May have ends reversed but would
                        // be good to assume that there is
                        // a directon when the shapes are added

                        if (point == line.From)
                        {
                            if (line.To.Status == Shape.SearchStatus.None)
                            {
                                Console.WriteLine("line=" + line);
                                DepthFirstSearch(connected, line.To);
                            }
                        }
                        else
                        {
                            if (line.From.Status == Shape.SearchStatus.None)
                            {
                                Console.WriteLine("line=" + line);
                                DepthFirstSearch(connected, line.From);
                            }
                        }
                    }
                }
            }
        }

        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
