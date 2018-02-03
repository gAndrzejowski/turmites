using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    class CustomDirectionList : DirectionList
    {
        public CustomDirectionList(int[][] customList) => Vectors = customList;
    }
}
