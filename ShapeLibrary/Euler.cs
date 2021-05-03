using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Euler
    {
        #region Fields
        private List<Point> _connected;


        #endregion
        #region Constructors
        public Euler(List<Point> connected, Point point)
        {
            _connected = connected;

        }

        #endregion
        #region Properties
        #endregion
        #region Methods

        //findRoot() will return 0 if euler path/circuit not possible
        //otherwise it will return array index of any node as root
        private int FindRoot()
        {
            int root = 1; //Assume root as 1
            count = 0;
            for (int i = 0; i < total; i++)
            {
                if (GetDegree(i) % 2 != 0)
                {
                    count++;
                    root = i;//Store the node which has odd degree to root variable
                }
            }
            //If count is not exactly 2 then euler path/circuit not possible so return 0
            if (count != 0 && count != 2)
            {
                return 0;
            }
            else return root;// if exactly 2 nodes have odd degree, 
            //it will return one of those node as root otherwise return 1 as root  as assumed
        }

        #endregion
    }
}
