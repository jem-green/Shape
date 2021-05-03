using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Line : Shape, IShape
    {
        #region Field

        Point _from;
        Point _to;

        #endregion
        #region Constructor

        public Line(Point from, Point to)
        {
            _from = from;
            _to = to;
        }

        #endregion
        #region Properties

        public Point From
        {
            get
            {
                return (_from);
            }
            set
            {
                _from = value;
            }
        }
        public Point To
        {
            get
            {
                return (_to);
            }
            set
            {
                _to = value;
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

        public override string ToString()
        {
            return ("from={" + _from + "},to={" + _to + "}");
        }
        public string ToJSON()
        {
            return ("[{\"from\":" + _from + "},{\"to\":" + _to + "}]");
        }
        #endregion
    }
}
