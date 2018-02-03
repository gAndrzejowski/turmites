using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    // Szablon zbioru możliwych kierunków w których może się poruszać turmit
    abstract class DirectionList : IDirectionList
    {
        // Lista kierunków
        protected int[][] Vectors;
        // Indeks aktualnie wybranego kierunku
        protected int CurrentIndex;

        // Zwraca aktualny kierunek
        public int[] GetCurrentVector()
        {
            return Vectors[CurrentIndex];
        }

        //Skręca w lewo (przeciwnie do ruchu wskazówek zegara) i zwraca nowy kierunek
        public int[] Left()
        {
            if (CurrentIndex > 0) CurrentIndex--;
            else CurrentIndex = Vectors.GetLength(0)-1;
            return GetCurrentVector();
        }

        //Skręca w lewo (zgodnie z ruchem wskazówek zegara) i zwraca nowy kierunek
        public int[] Right()
        {
            if (CurrentIndex < Vectors.GetLength(0) - 1) CurrentIndex++;
            else CurrentIndex = 0;
            return GetCurrentVector();
        }
    }
}
