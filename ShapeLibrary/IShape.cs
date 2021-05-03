using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public interface IShape
    {
        #region Fields

        #endregion
        #region Constructors
        #endregion
        #region Properties
        public Shape.SearchStatus Status { get; set; }
        #endregion
        #region Methods
        public bool IntersectsWith(IShape shape);
        #endregion
    }
}
