using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    /// <summary>
    /// Rectangle comprising 4 lines
    /// </summary>
    public class Rectangle : Shape, IShape
    {
        #region Field

        private Point _topLeft;
        private double _width;
        private double _height;
        private bool _visited = false;

        #endregion
        #region Constructor

        public Rectangle()
        {
            _type = ShapeType.Rectangle;
        }

        public Rectangle(Point topLeft, double width, double height)
        {
            _type = ShapeType.Rectangle;

            // Assumes top left corner and width
            // and height are positive and forces this

            _topLeft = topLeft;
            _width = width;
            _height = height;

        }

        #endregion
        #region Properties

        public Point TopLeft
        {
            get
            {
                return (_topLeft);
            }
            set
            {
                _topLeft = value;
            }
        }

        public double Left
        {
            get
            {
                return (_topLeft.X);
            }
        }

        public double X
        {
            get
            {
                return (_topLeft.X);
            }
        }

        public double Top
        {
            get
            {
                return (_topLeft.Y);
            }
        }

        public double Y
        {
            get
            {
                return (_topLeft.Y);
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
                empty = (_topLeft.X == 0) & (_topLeft.Y == 0) & (_width == 0) & (_height == 0);  
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
            overlap = overlap & (rectangle.X >= _topLeft.X);
            //overlap = overlap & ((rectangle.X + rectangle.Width) <= (_to.X));
            overlap = overlap & (rectangle.Y >= _topLeft.Y);
            //overlap = overlap & ((rectangle.Y + rectangle.Height) <= (_to.Y));
            return (overlap);
        }

        public bool IntersectsWith(Rectangle rectangle)
        {
            bool overlap = true;
            //overlap = overlap & (rectangle.X < (_to.X));
            overlap = overlap & ((rectangle.X + rectangle.Width) > _topLeft.X);
            //overlap = overlap & (rectangle.Y < (_to.Y));
            overlap = overlap & ((rectangle.Y + rectangle.Height) > _topLeft.Y);
            return (overlap);
        }

        public override string ToString()
        {
            return ("topleft={" + _topLeft + "},with={" + _width + "},height={" + _height + "}");
        }
        public string ToJSON()
        {
            return ("[{\"from\":" + _topLeft + "},{\"width\":" + _width + "},{\"height\":" + _height + "}]");
        }

        #endregion
    }
}
