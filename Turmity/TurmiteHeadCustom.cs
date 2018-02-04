using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    class TurmiteHeadCustom : TurmiteHead
    {
        public TurmiteHeadCustom(DirectionList directions,int[][][] instructions)
        {
            Directions = directions;
            States = instructions;
        }
    }
}
