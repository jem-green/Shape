using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ShapeLibrary
{
    public class Point : Shape, IShape, IComparable, IComparable<Point>
    {
        #region Fields

        private double _x;
        private double _y;
        private double _z;
        private List<IShape> _shapes;


        #endregion
        #region Constructor
        public Point()
        {
            _type = ShapeType.Point;
            _shapes = new List<IShape>();
        }

        public Point(double x, double y, double z)
        {
            _type = ShapeType.Point;
            _shapes = new List<IShape>();
            _x = x;
            _y = y;
            _z = z;
        }

        #endregion
        #region Properties

        public int Degree
        {
            get
            {
                return (_shapes.Count);
            }
        }
        public double X
        {
            get
            {
                return (_x);
            }
            set
            {
                _x = value;
            }
        }

        public double Y
        {
            get
            {
                return (_y);
            }
            set
            {
                _y = value;
            }
        }

        public double Z
        {
            get
            {
                return (_z);
            }
            set
            {
                _z = value;
            }
        }

        public List<IShape> Shapes
        {
            get
            {
                return (_shapes);
            }
        }

        #endregion
        #region Methods

        public void AddShape(IShape shape)
        {
            _shapes.Add(shape);
        }

        public bool IntersectsWith(IShape shape)
        {
            bool intersect = true;

            if (shape.GetType() == typeof(Point))
            {
                
            }
            else
            {
                throw new NotImplementedException();
            }
            return (intersect);
        }

        public override string ToString()
        {
            return ("x=" + _x + ",y=" + _y + ",z=" + _z);
        }
        public string ToJSON()
        {
            return ("[{\"x\":" + _x + "},{\"y\":" + _y + "},{\"z\":" + _z + "}]");
        }

        public override bool Equals(object obj)
        {
            Point point = (Point)obj;

            if (_x.Equals(point.X) != true)
            {
                return (false);
            }
            else if (_y.Equals(point.Y) != true)
            {
                return (false);
            }
            else if (_z.Equals(point.Z) != true)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        public override int GetHashCode()
        {
            return (HashCode.Combine(_x, _y, _z));
        }

        int IComparable<Point>.CompareTo(Point other)
        {
            if (_x.CompareTo(other.X) != 0)
            {
                return (_x.CompareTo(other.X));
            }
            else if (_y.CompareTo(other.Y) != 0)
            {
                return (_y.CompareTo(other.Y));
            }
            else if (_z.CompareTo(other.Z) != 0)
            {
                return (_z.CompareTo(other.Z));
            }
            else
            {
                return (0);
            }
        }

        public int CompareTo(object obj)
        {
            Point other = (Point)obj;

            if (_x.CompareTo(other.X) != 0)
            {
                return (_x.CompareTo(other.X));
            }
            else if (_y.CompareTo(other.Y) != 0)
            {
                return (_y.CompareTo(other.Y));
            }
            else if (_z.CompareTo(other.Z) != 0)
            {
                return (_z.CompareTo(other.Z));
            }
            else
            {
                return (0);
            }
        }
        #endregion
    }
}
