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
            Config settings = new Config();
            settings.Run();
            System.Console.Clear();
            Simulation sim = new Simulation(settings.Head, settings.Steps, settings.Width, settings.Height);
            sim.Run();
            System.Console.Write(sim.Result);
            System.Console.ReadKey();
        }
    }
}
