using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    class MooreDirections : DirectionList
    {
        public MooreDirections()
        {
            Vectors = new int[8][];
            Vectors[0] = new int[] { 0, -1 };
            Vectors[1] = new int[] { 1, -1 };
            Vectors[2] = new int[] { 1, 0 };
            Vectors[3] = new int[] { 1, 1 };
            Vectors[4] = new int[] { 0, 1 };
            Vectors[5] = new int[] { -1, 1 };
            Vectors[6] = new int[] { -1, 0 };
            Vectors[7] = new int[] { -1, -1 };
  
        }
    }
}
