using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            System.Console.WriteLine("Wyświetlić wynik? t/n");
            char key;
            do
            {
                key = System.Console.ReadKey().KeyChar;
            } while (key != 't' && key != 'n');
            if (key == 't') System.Console.WriteLine(sim.Result);
            System.Console.WriteLine("Zapis do pliku? t/n");
            do
            {
                key = System.Console.ReadKey().KeyChar;
            } while (key != 't' && key != 'n');
            if (key=='t')
            {
                System.Console.Write("Podaj nazwę pliku");
                string filename = System.Console.ReadLine();
                string path = System.Environment.CurrentDirectory;
                File.WriteAllText("output\\" + filename + ".txt", sim.Result);
                System.Console.WriteLine("Zapisano: " + path + "\\output\\" + filename);
            }
            System.Console.ReadKey();
        }
    }
}
