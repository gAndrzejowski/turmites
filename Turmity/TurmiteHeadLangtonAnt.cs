using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    class TurmiteHeadLangtonAnt : TurmiteHead
    {
        public TurmiteHeadLangtonAnt()
        {
            State = 0;
            Directions = new VonNeumannDirections();
            States = new int[1][][];
            States[0] = new int[2][];
            States[0][0] = new int[3] { 1, 1, 0};
            States[0][1] = new int[3] { 0, -1, 0 };
        }
    }
}
