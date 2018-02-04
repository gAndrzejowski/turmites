using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    class Simulation
    {
        private Board Grid;
        private TurmiteHead Head;
        private int Limit;
        private int CurrentStep;
        private int X;
        private int Y;
        private int Width;
        private int Height;
        public string Result;

        public Simulation(TurmiteHead head,int maxIterations=100000,int width = 300, int height = 300,ushort colors = 2)
        {
            Width = width;
            Height = height;
            Head = head;
            Limit = maxIterations;
            CurrentStep = 0;
            X = width / 2;
            Y = height / 2;
            Grid = new Board(colors,width,height);
        }
        private bool Step()
        {
            int color = Grid.GetCellValue((uint)X,(uint)Y);
            int[] move = Head.Step(color);
            if (move[0] == -1) return false;
            Grid.SetCellValue((uint)X, (uint)Y, (ushort)move[0]);
            X += move[1];
            Y += move[2];
            if (X < 0 || Y < 0 || X >= Width || Y >= Height) return false;
            CurrentStep++;
            if (CurrentStep >= Limit) return false;
            return true;
        }
        public void Run()
        {
            while (Step()) ;
            Result = Grid.Export();
        }
    }
}
