using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class SHPPolyline : SHPShape, IShape
    {
        #region Fields

        private List<SHPPoint> _points;
        private bool _visited = false;

        #endregion
        #region Constructor

        public SHPPolyline()
        {
            _type = ShapeType.Polyline;
            _points = new List<SHPPoint>();
        }

        public SHPPolyline(List<SHPPoint> points)
        {
            _type = ShapeType.Polyline;
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

        public void Add(SHPPoint line)
        {
            _points.Add(line);
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
            string data = "";
            foreach (SHPPoint point in _points)
            {
                data = data + "{point\":" + point + "},";
            }
            return (data);
        }

        #endregion
    }
}
