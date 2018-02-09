using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmity
{
    // "Świat" badanego turmita
    class Board : IBoard
    {
        // Tablica dwuwymiarowa zawierająca stan świata, tj. wartości wszystkich komórek
        protected ushort[,] Cells;
        
        // Konstruktor tworzy planszę o zadanych parametrach i wypełnia ją zerami
        // Domyślna liczba kolorów to najprostszy sensowny przypadek
        public Board(int width=300, int height=300)
        {
            Cells = new ushort[height, width];
            for (int column = 0; column < width; column++)
            {
                for (int row = 0; row < height; row++)
                {
                    //Zaczynamy zawsze z pustą planszą
                    Cells[row, column] = 0;
                }
            }
        }

        // Eksport stanu planszy jako łancuch znaków, np. do wydruku
        public string Export()
        {
            string cellsAsString = "";
            int counter = 0;
            int width = Cells.GetLength(1);
            foreach (ushort cellValue in Cells)
            {
                if (counter % width == 0 && counter != 0) cellsAsString += '\n';
                counter++;
                cellsAsString += cellValue.ToString();
            }
            return cellsAsString;
        }
        //Eksport do tablicy Javascript
        public string ExportJS()
        {
            string cellsAsString = "let grid = [";
            foreach (ushort cellValue in Cells)
            {
                cellsAsString +=(cellValue.ToString()+',');
            }
            return (cellsAsString + "null],gridWidth="+Cells.GetLength(1));
        }

        // Pobierz wartość komórki o wskazanych współrzędnych;
        public ushort GetCellValue(uint x, uint y)
        {
            return Cells[x, y]; 
        }

        // Zmień wartość komórki o wskazanych współrzędnych
        public void SetCellValue(uint x, uint y, ushort val)
        {
            Cells[x, y] = val;
        }
        
    }
}
