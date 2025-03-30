using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Shape
    {
        #region Fields

        private Shape.SearchStatus _search = Shape.SearchStatus.None;
        private protected ShapeType _type = ShapeType.None;
        private protected bool _closed = false;

        public enum ShapeType : byte
        {
            None = 0,
            Arc = 1,
            Circle = 2,
            Line = 3,
            Point = 4,
            Polygon = 5,
            Polyline = 6,
            Rectangle = 7
        }

        [Flags]
        public enum SearchStatus : byte
        {
            None = 0,
            Visited = 1,
            Start = 2,
            End = 4,
            Linked = 8
        }

        #endregion
        #region Properties

        public ShapeType Type
        {
            get
            {
                return (_type);
            }
        }

        public SearchStatus Status
        {
            get
            {
                return (_search);
            }
            set
            {
                _search = value;
            }
        }

        public bool IsClosed
        {
            get
            {
                return (_closed);
            }
        }

        #endregion
    }
}
