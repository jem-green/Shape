using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Polygon : Shape, IShape
    {
        #region Fields

        private bool _closed = true;
        private List<Point> _points;
        private bool _visited = false;

        #endregion
        #region Constructor

        public Polygon()
        {
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

        public void Add(Point point)
        {
            _points.Add(point);
        }

        #endregion
    }
}
