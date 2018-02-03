using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    interface IDirectionList
    {
        int[] GetCurrentVector();
        int[] Left();
        int[] Right();
    }
}
