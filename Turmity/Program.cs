using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    class Program
    {
        static void Main(string[] args)
        {
            TurmiteHeadLangtonAnt head = new TurmiteHeadLangtonAnt();
            for (int i=0;i<10;i++)
            {
                int col = i - 5 > 0 ? 0 : 1;
                int[] output = head.Step(col);
                System.Console.WriteLine(""+output[0] +" "+ output[1] + " " + output[2]);
            }
            System.Console.ReadKey();
        }
    }
}
