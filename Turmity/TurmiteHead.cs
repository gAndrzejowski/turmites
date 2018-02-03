using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    // Szablon dla konkretnych typów głowicy turmita
    abstract class TurmiteHead : ITurmiteHead
    {   
        //Aktualny stan turmita
        protected int State;
        //Lista dozwolonych kierunków razem z interfejsem
        protected DirectionList Directions;
        //Instrukcje dla poszczególnych warunków [stan][kolor pola] => [nowy kolor,zmiana kierunku,nowy stan]
        protected int[][][] States;


        //Oblicza krok i zwraca tablicę: pokoloruj pole na tab[0] i zmień pozycję o [[tab1],[tab2]]
        public int[] Step(int color)
        {
            
            int[] instructions = States[State][color];
            State = instructions[2];

            if (instructions[1]>=0)
            {
                for (int i = 0; i < instructions[1]; i++) Directions.Right();
            }
            else
            {
                for (int i = 0; i > instructions[1]; i--) Directions.Left();
            }
            int[] nextDir = Directions.GetCurrentVector();

            return new int[] { instructions[0], nextDir[0], nextDir[1] };

        }
    }
}
