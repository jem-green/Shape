using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Shape
    {
        #region Fields
        
        private Shape.SearchStatus _search = Shape.SearchStatus.None;

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

        #endregion
    }
}
