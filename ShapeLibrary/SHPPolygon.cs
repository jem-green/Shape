using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class SHPPolygon : SHPShape, IShape
    {
        #region Fields

        private List<SHPPoint> _points;
        private bool _visited = false;

        #endregion
        #region Constructor

        public SHPPolygon()
        {
            _type = ShapeType.Polygon;
            _closed = true;
            _points = new List<SHPPoint>();
        }

        public SHPPolygon(List<SHPPoint> points)
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

        public SHPPoint this[int index]
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

            if (shape.GetType() == typeof(SHPPoint))
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
        public void Add(SHPPoint point)
        {
            _points.Add(point);
        }

        public override string ToString()
        {
            string data = "";
            foreach (SHPPoint point in _points)
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
            foreach (SHPPoint point in _points)
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
