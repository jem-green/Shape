using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Arc : Shape, IShape
    {
        // Assue that the axis is defined as 0,0 is bottom left
        // as this fits better with plotter and paper based
        // geometry

        #region Field

        Point _from;
        Point _to;
        Point _center;
        double _radius;
        double _start;
        double _end;
        bool _visited = false;

        #endregion
        #region Constructor

        public Arc(Point from, Point to, double radius)
        {
            _from = from;
            _to = to;
            _radius = radius;

            // Calculate the centre and start and finish as the accuracy is challenging
        }

        public Arc(Point center, double radius, double start, double end)
        {
            // Need to calculate the from and to points
            _center = center;
            _radius = radius;
            _start = start;
            _end = end;

            // calculate the start and end points
        }

        #endregion
        #region Properties

        public bool Visited
        {
            get
            {
                return (_visited);
            }
            set
            {
                _visited = value;
            }
        }

        #endregion
        #region Methods

        public bool IntersectsWith(IShape shape)
        {
            bool intersect = true;

            if (shape.GetType() == typeof(Line))
            {
                Line line = (Line)shape;

                Point p1 = _from;
                Point p2 = _to;
                Point p3 = line.From;
                Point p4 = line.To;

                // Get the segments' parameters.

                double dx12 = p2.X - p1.X;
                double dy12 = p2.Y - p1.Y;
                double dx34 = p4.X - p3.X;
                double dy34 = p4.Y - p3.Y;

                // Solve for t1 and t2

                double denominator = (dy12 * dx34 - dx12 * dy34);

                double t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;

                if (double.IsInfinity(t1))
                {
                    // The lines are parallel (or close enough to it).
                    intersect = false;
                }
                else
                {
                    double t2 = ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12) / -denominator;

                    // The segments intersect if t1 and t2 are between 0 and 1.
                    intersect = ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));

                }
            }
            else
            {
                throw new NotImplementedException();
            }
            return (intersect);
        }

        #endregion
    }
}
