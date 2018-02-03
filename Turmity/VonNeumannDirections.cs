using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    class VonNeumannDirections : DirectionList
    {
        public VonNeumannDirections()
        {
            Vectors = new int[4][];
            Vectors[0] = new int[] {0,-1};
            Vectors[1] = new int[] { 1, 0 };
            Vectors[2] = new int[] { 0, 1 };
            Vectors[3] = new int[] { -1, 0 };
        }
    }
}
