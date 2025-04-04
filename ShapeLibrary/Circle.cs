﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    /// <summary>
    /// Rectangle primitive
    /// </summary>
    public class Circle : Shape, IShape
    {
        #region Field

        private Point _center;
        private double _radius;
        private bool _visited = false;

        #endregion
        #region Constructor

        public Circle()
        {
            _type = ShapeType.Circle;
        }


        /// <summary>
        /// Defned as center and radius
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public Circle(Point center, double radius)
        {
            base._type = ShapeType.Circle;
            _center = center;
            _radius = radius;
        }

        #endregion
        #region Properties

        public Point Center
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

            if (shape.GetType() == typeof(Rectangle))
            {

            }
            else
            {
                throw new NotImplementedException();
            }
            return (intersect);
        }

        public bool Contains(Rectangle rectangle)
        {
            bool contains = false;
            return (contains);
        }

        public bool IntersectsWith(Rectangle rectangle)
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
