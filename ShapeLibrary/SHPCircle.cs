using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    /// <summary>
    /// Rectangle primative
    /// </summary>
    public class SHPCircle : SHPShape, IShape
    {
        #region Field

        private SHPPoint _center;
        private double _radius;
        private bool _visited = false;

        #endregion
        #region Constructor

        public SHPCircle()
        {
            _type = ShapeType.Circle;
        }


        /// <summary>
        /// Defned as center and radius
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public SHPCircle(SHPPoint center, double radius)
        {
            base._type = ShapeType.Circle;
            _center = center;
            _radius = radius;
        }

        #endregion
        #region Properties

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

        public bool IsEmpty
        {
            get
            {
                bool empty = true;
                empty = (_center.X == 0) & (_center.Y == 0) & (_radius == 0);  
                return (empty);
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

            if (shape.GetType() == typeof(SHPRectangle))
            {

            }
            else
            {
                throw new NotImplementedException();
            }
            return (intersect);
        }

        public bool Contains(SHPRectangle rectangle)
        {
            bool contains = false;
            return (contains);
        }

        public bool IntersectsWith(SHPRectangle rectangle)
        {
            bool overlap = false;
            return (overlap);
        }

        public override string ToString()
        {
            return ("from={" + _center + "},radius={" + _radius + "}");
        }
        public string ToJSON()
        {
            return ("[{\"from\":" + _center + "},{\"to\":" + _radius + "}]");
        }

        #endregion
    }
}
