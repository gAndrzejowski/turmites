using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Turmity
{
    // Koordynator działań planszy i mrówki
    class Simulation
    {
        //Plansza
        private Board Grid;
        //Mrówka
        private TurmiteHead Head;
        //Maksymalna liczba kroków
        private int Limit;
        //Aktualny krok
        private int CurrentStep;
        //Kolumna, w której znajduje się mrówka
        private int X;
        //Rząd, w którym znajduje się mrówka
        private int Y;
        //Szerokość planszy
        private int Width;
        //Wysokość planszy
        private int Height;
        //Wynik symulacji
        public string Result;

        public Simulation(TurmiteHead head,int maxIterations=100000,int width = 300, int height = 300)
        {
            Width = width;
            Height = height;
            Head = head;
            Limit = maxIterations;
            CurrentStep = 0;
            X = width / 2;
            Y = height / 2;
            Grid = new Board(width,height);
        }
        /*Pojedyncza iteracja:
         * 1) Pobierz kolor aktualnej komórki
         * 2) Zapytaj mrówkę co z tym zrobi
         * 3) Jeśli mrówka wysyła sygnał stop (-1) zakończ
         * 3) Zmień kolor i przesuń mrówkę
         * 4) Sprawdź czy to koniec (za dużo kroków lub mrówka wyszła poza planszę
         */
        private bool Step()
        {
            int color = Grid.GetCellValue((uint)X,(uint)Y);
            int[] move = Head.Step(color);
            if (move[0] < 0) return false;
            Grid.SetCellValue((uint)X, (uint)Y, (ushort)move[0]);
            X += move[1];
            Y += move[2];
            if (X < 0 || Y < 0 || X >= Width || Y >= Height) return false;
            CurrentStep++;
            if (CurrentStep >= Limit) return false;
            return true;
        }
        //Działaj dopóki metoda Step zwraca true, po skończeniu wyeksportuj planszę jako string
        public void Run()
        {
            while (Step()) ;
            Result = Grid.Export();
        }
    }
}
