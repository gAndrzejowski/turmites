using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    interface IBoard
    {
        ushort GetCellValue(uint x, uint y);
        void SetCellValue(uint x, uint y, ushort val);
        string Export();
    }
}
