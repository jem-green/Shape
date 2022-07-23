using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class SHPArc : SHPShape, IShape
    {
        // Assue that the axis is defined as 0,0 is bottom left
        // as this fits better with plotter and paper based
        // geometry

        #region Field

        SHPPoint _from;
        SHPPoint _center;
        SHPPoint _to;

        double _radius;
        double _start;
        double _end;
        bool _visited = false;

        #endregion
        #region Constructor

        public SHPArc()
        {
            _type = ShapeType.Arc;
        }

        public SHPArc(SHPPoint from, SHPPoint to, double radius)
        {
            _type = ShapeType.Arc;
            _from = from;
            _to = to;
            _radius = radius;

            // Calculate the centre and start and finish as the accuracy is challenging

            _center.X = CenterX(from.X, from.Y, to.X, to.Y, radius);
            _center.Y = CenterY(from.X, from.Y, to.X, to.Y, radius);

        }

        public SHPArc(SHPPoint center, double radius, double start, double end)
        {
            _type = ShapeType.Arc;

            // Need to calculate the from and to points
            _center = center;
            _radius = radius;
            _start = start;
            _end = end;

            // calculate the start and end points


        }

        public SHPArc(SHPPoint from, SHPPoint center, SHPPoint to)
        {
            _type = ShapeType.Arc;

            // Need to calculate the 

            _from = from;
            _center = center;
            _to = to;

            // Problem here is that the points might not be part of a circle
            // proably better to just speciy any points on to circle


        }


        #endregion
        #region Properties

        public SHPPoint From
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
        public SHPPoint To
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

        public SHPPoint Center
        {
            get
            {
                return (_center);
            }
            set
            {
                _center = value;
            }
        }

        public double Left
        {
            get
            {
                return (_center.X);
            }
        }

        public double X
        {
            get
            {
                return (_center.X);
            }
            set
            {
                _center.X = value;
            }
        }

        public double Top
        {
            get
            {
                return (_center.Y);
            }
        }

        public double Y
        {
            get
            {
                return (_center.Y);
            }
            set
            {
                _center.Y = value;
            }
        }

        public double Radius
        {
            get
            {
                return (_radius);
            }
            set
            {
                _radius = value;
            }
        }

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

            if (shape.GetType() == typeof(SHPLine))
            {
                SHPLine line = (SHPLine)shape;

                SHPPoint p1 = _from;
                SHPPoint p2 = _to;
                SHPPoint p3 = line.From;
                SHPPoint p4 = line.To;

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
            return ("from={" + _from + "},center={" + _center + "}, to={" + _to + "}");
        }
        public string ToJSON()
        {
            return ("[{\"from\":" + _from + "},{\"center\":" + _center + "},{\"to\":" + _to + "}]");
        }

        #endregion
        #region Private

        private double CenterX(double x1, double y1, double x2, double y2, double r)
        {
            double q = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            double x3 = (x1 + x2) / 2;
            return (x3 + Math.Sqrt((r * r) - ((q / 2) * (q / 2))) * ((y1 - y2) / q));
        }

        private double CenterY(double x1, double y1, double x2, double y2, double r)
        {
            double q = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            double y3 = (y1 + y2) / 2;
            return (y3 + Math.Sqrt((r * r) - ((q / 2) * (q / 2))) * ((x2 - x1) / q));
        }

        static double RadiusR(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double x12 = x1 - x2;
            double x13 = x1 - x3;

            double y12 = y1 - y2;
            double y13 = y1 - y3;

            double y31 = y3 - y1;
            double y21 = y2 - y1;

            double x31 = x3 - x1;
            double x21 = x2 - x1;

            // x1^2 - x3^2
            double sx13 = (double)(Math.Pow(x1, 2) - Math.Pow(x3, 2));

            // y1^2 - y3^2
            double sy13 = (double)(Math.Pow(y1, 2) - Math.Pow(y3, 2));

            double sx21 = (double)(Math.Pow(x2, 2) - Math.Pow(x1, 2));

            double sy21 = (double)(Math.Pow(y2, 2) - Math.Pow(y1, 2));

            double f = ((sx13) * (x12) + (sy13) * (x12) + (sx21) * (x13) + (sy21) * (x13)) / (2 * ((y31) * (x12) - (y21) * (x13)));
            double g = ((sx13) * (y12) + (sy13) * (y12) + (sx21) * (y13) + (sy21) * (y13)) / (2 * ((x31) * (y12) - (x21) * (y13)));

            double c = -(double)Math.Pow(x1, 2) - (double)Math.Pow(y1, 2) - 2 * g * x1 - 2 * f * y1;

            // eqn of circle be x^2 + y^2 + 2*g*x + 2*f*y + c = 0
            // where centre is (h = -g, k = -f) and radius r
            // as r^2 = h^2 + k^2 - c

            double h = -g;
            double k = -f;
            double sqr_of_r = h * h + k * k - c;

            // r is the radius
            double r = Math.Round(Math.Sqrt(sqr_of_r), 5);

            return (r);

        }

        #endregion
    }
}
