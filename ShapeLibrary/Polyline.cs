using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Polyline : Shape, IShape
    {
        #region Fields

        private bool _closed = false;
        private List<Point> _points;
        private bool _visited = false;

        #endregion
        #region Constructor

        public Polyline()
        {
            _points = new List<Point>();
        }

        public Polyline(List<Point> points)
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

        public void Add(Point line)
        {
            _points.Add(line);
        }

        #endregion
    }
}
