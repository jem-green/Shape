using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Polygon : Shape, IShape
    {
        #region Fields

        private List<Point> _points;
        private bool _visited = false;

        #endregion
        #region Constructor

        public Polygon()
        {
            _type = ShapeType.Polygon;
            _closed = true;
            _points = new List<Point>();
        }

        public Polygon(List<Point> points)
        {
            _points = points;
        }

        #endregion
        #region Properties

        public int Count
        {
            get
            {
                return (_points.Count);
            }
        }

        public Point this[int index]
        {
            get
            {
                return (_points[index]);
            }
            set
            {
                if ((index < 0) || (index > _points.Count))
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    _points[index] = value;
                }
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

            if (shape.GetType() == typeof(Point))
            {

            }
            else
            {
                throw new NotImplementedException();
            }
            return (intersect);
        }

        /// <summary>
        /// Add points in sequence
        /// </summary>
        /// <param name="point"></param>
        public void Add(Point point)
        {
            _points.Add(point);
        }

        public override string ToString()
        {
            string data = "";
            foreach (Point point in _points)
            {
                data = data + ("point=" + point + ",");
            }
            data = data.TrimEnd(',');
            return (data);
        }

        public string ToJSON()
        {
            string data;
            data = "[";
            foreach (Point point in _points)
            {
                data = data + "{point\":" + point + "},";
            }
            data = data.TrimEnd(',');
            data = data + "]";
            return (data);
        }

        #endregion
    }
}
