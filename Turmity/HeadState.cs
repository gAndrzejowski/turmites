using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    class HeadState
    {
        protected int[][] Instructions;

        public HeadState(int[][] instructions) => Instructions = instructions;

        public int[] GetInstructionsForColor(int color)
        {
            return Instructions[color];
        }
    }
}
