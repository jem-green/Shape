using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Rectangle : Shape, IShape
    {
        #region Field

        double _x;
        double _y;
        double _width;
        double _height;
        bool _visited = false;

        #endregion
        #region Constructor

        public Rectangle(double left, double top, double width, double height)
        {
            _x = left;
            _y = top;
            _width = width;
            _height = height;
        }

        #endregion
        #region Properties

        public double Left
        {
            get
            {
                return (_x);
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

        public double Top
        {
            get
            {
                return (_y);
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

        public double Width
        {
            get
            {
                return (_width);
            }
            set
            {
                _width = value;
            }
        }

        public double Height
        {
            get
            {
                return (_height);
            }
            set
            {
                _height = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                bool empty = true;
                empty = (_x == 0) & (_y == 0) & (_width == 0) & (_height == 0);  
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
            bool overlap = true;
            overlap = overlap & (rectangle._x >= _x);
            overlap = overlap & ((rectangle._x + rectangle._width) <= (_x + _width));
            overlap = overlap & (rectangle._y >= _y);
            overlap = overlap & ((rectangle._y + rectangle._height) <= (_y + _height));
            return (overlap);
        }

        public bool IntersectsWith(Rectangle rectangle)
        {
            bool overlap = true;
            overlap = overlap & (rectangle._x < (_x+_width));
            overlap = overlap & ((rectangle._x + rectangle._width) > _x);
            overlap = overlap & (rectangle._y < (_y+_height));
            overlap = overlap & ((rectangle._y + rectangle._height) > _y);
            return (overlap);
        }

        #endregion
    }
}
