using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    class Config
    {
        public TurmiteHead Head;
        public int Steps;
        public int Width;
        public int Height;
        private DirectionList Directions;
        private int Colors;
        private int States;
        private int[][][] Instructions;

        private void GatherSteps()
        {
            System.Console.WriteLine("Podaj maksymalną liczbę kroków (100 000)");
            string input = System.Console.ReadLine();
            int output;
            Int32.TryParse(input, out output);
            if (output <= 0) output = 100000;
            Steps = output;
        }
        private void GatherDimensions()
        {
            System.Console.WriteLine("Podaj szerokość planszy:");
            string input = System.Console.ReadLine();
            int output;
            Int32.TryParse(input, out output);
            if (output <= 0) output = 300;
            Width = output;

            System.Console.WriteLine("Podaj wysokość planszy:");
            input = System.Console.ReadLine();
            Int32.TryParse(input, out output);
            if (output <= 0) output = 300;
            Height = output;
        }
        private CustomDirectionList CreateCustomDirections()
        {
            string input;
            int dirs, dx,dy;
            int[][] customlist;

            System.Console.WriteLine("Ile możliwych kierunków? (co najmniej 1)");
            
            do
            {
                input = System.Console.ReadLine();
                Int32.TryParse(input, out dirs);
            } while (dirs < 1);

            customlist = new int[dirs][];
            System.Console.WriteLine("Teraz podaj kierunki w kolejności zgodnej z ruchem wskazówek zegara, zaczynając od początkowego:");
            for (int i=0;i<dirs;i++)
            {
                System.Console.WriteLine("Kierunek " + (i + 1)+":");
                System.Console.WriteLine("\tZmień X o:");
                Int32.TryParse(System.Console.ReadLine(),out dx);
                System.Console.WriteLine("\tZmień Y o:");
                Int32.TryParse(System.Console.ReadLine(),out dy);
                customlist[i] = new int[2] { dx, dy };
            }
            return new CustomDirectionList(customlist);
        }
        private TurmiteHeadCustom CreateCustomHead()
        {
            System.Console.WriteLine("Wybierz zbiór kierunków: \n\ta) Von Neumanna (4kierunki)\n\tb) Moore'a (8kierunków)\n\tz) Stwórz własne");
            char dirType;
            do
            {
                dirType = System.Console.ReadKey().KeyChar;
            } while (dirType != 'a' && dirType != 'b' && dirType != 'z');

            if (dirType == 'a') Directions = new VonNeumannDirections();
            if (dirType == 'b') Directions = new MooreDirections();
            if (dirType == 'z') Directions = CreateCustomDirections();

            System.Console.WriteLine("Podaj liczbę możliwych stanów turmita (co najmniej 1)");
            int output;
            string input;
            input = System.Console.ReadLine();
            Int32.TryParse(input, out output);
            if (output < 1) output = 1;
            States = output;
            System.Console.WriteLine("Podaj liczbę możliwych kolorów pola (co najmniej 1)");
            input = System.Console.ReadLine();
            Int32.TryParse(input, out output);
            if (output < 1) output = 1;
            Colors = output;
            Instructions = new int[States][][];
            for (int state = 1; state<=States;state++)
            {
                
                Instructions[state - 1] = new int[Colors][];

                System.Console.WriteLine("Jeżeli turmit jest w stanie nr "+state);
                for (int color=1;color<=Colors;color++)
                {
                    Instructions[state - 1][color - 1] = new int[3];
                    System.Console.WriteLine("\t...i trafi na pole o kolorze nr " + color);
                    System.Console.Write("\t\tZmień kolor pola na (liczba ujemna - zakończ ruch turmita):");
                    do
                    {
                        input = System.Console.ReadLine();
                        Int32.TryParse(input, out output);
                    } while (output == 0 || output>Colors);
                    Instructions[state - 1][color - 1][0] = output-1;
              
                    System.Console.Write("\t\t, skręć o tyle jednostek w prawo (liczba ujemna - skręć w lewo):");
                    
                    input = System.Console.ReadLine();
                    Int32.TryParse(input, out output);       
                    Instructions[state - 1][color - 1][1] = output;

                    System.Console.Write("\t\t... i zmień stan na:");
                    do
                    {
                        input = System.Console.ReadLine();
                        Int32.TryParse(input, out output);
                    } while (output <= 0 || output > States);
                    Instructions[state - 1][color - 1][2] = output-1;
                }
            }
            return new TurmiteHeadCustom(Directions, Instructions);
        }
        private void ChooseHead()
        {
            System.Console.WriteLine("Wybierz typ turmita: \n\ta) Mrówka Langtona\n\tz) Zrób to sam");
            char headType;
            do
            {
                headType = System.Console.ReadKey().KeyChar;
            } while (headType != 'a' && headType != 'z');

            if (headType == 'a') Head = new TurmiteHeadLangtonAnt();
            if (headType == 'z') Head = CreateCustomHead();
        }
        public void Run()
        {
            GatherSteps();
            GatherDimensions();
            ChooseHead();
        }
    }
}
