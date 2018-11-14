using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    //1 -
    class Tabla
    {
        private const int SOROK = 8;
        private const int OSZLOPOK = 8;
        private const char KIRÁLYNŐ = 'K';

        //2 - 
        private char[,] T;
        private char ÜresCella;
        //3 - 
        public Tabla(char üresCella)
        {
            T = new char[SOROK, OSZLOPOK];
            ÜresCella = üresCella;

            for (int sor = 0; sor < SOROK; sor++)//
            {
                for (int oszlop = 0; oszlop < OSZLOPOK; oszlop++)
                {
                    T[sor, oszlop] = ÜresCella;
                }
            }
        }
        //4. Feladathoz
        public void Megjelenít()
        {
            for (int sor = 0; sor < SOROK; sor++)
            {
                for (int oszlop = 0; oszlop < OSZLOPOK; oszlop++)
                {
                    Console.Write(T[sor, oszlop]);
                }
                Console.WriteLine();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Tabla tabla_peldany = new Tabla('#');
                Console.WriteLine("\n4. feladat: Az üres tábla:");
                tabla_peldany.Megjelenít();
                Console.ReadLine();
            }
        }
    }
}
