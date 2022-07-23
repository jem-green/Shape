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
        SHPShape.SearchStatus Status { get; set; }
        #endregion
        #region Methods
        bool IntersectsWith(IShape shape);
        string ToString();
        string ToJSON();
        #endregion
    }
}
