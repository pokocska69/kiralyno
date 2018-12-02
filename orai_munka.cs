using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project
{
    //1.Feladat
    class Tabla
    {
        private const int SOROK = 8;
        private const int OSZLOPOK = 8;
        private const char KIRÁLYNŐ = 'K';
        //2.Feladat 
        private char[,] T;
        private char ÜresCella;
        //3.Feladat
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
        //4.Feladat
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
        //5.Feladat
        public void Elhelyez(int N)
        {
            Random rnd = new Random();
            while (N > 0)
            {
                int sor = rnd.Next(0, SOROK);
                int oszlop = rnd.Next(0, OSZLOPOK);
                if (T[sor, oszlop] == ÜresCella)
                {
                    T[sor, oszlop] = KIRÁLYNŐ;
                    N--;
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }
        //6.Feladat
        public bool ÜresOszlop(int oszlop)
        {
            for (int sor=0; sor<SOROK; sor++)
            {
                if (T[sor, oszlop] == KIRÁLYNŐ )
                {
                    return false;      
                }

            }
            return true;
        }
        public bool ÜresSor(int sor)
        {
            for (int oszlop = 0; oszlop < OSZLOPOK; oszlop++)
            {
                if (T[sor, oszlop] == KIRÁLYNŐ)
                {
                    return false;
                }
                                
            }
            return true;
        }
        //7.Feladat
        public int ÜresSorokSzáma
        {
            get
            {
                int ÜresSorok = 0;

                for (int sor = 0; sor < SOROK; sor++)
                {
                    if (ÜresSor(sor))
                    {
                        ÜresSorok++;

                    }
                }
                return ÜresSorok;
            }
        }
        public int ÜresOszlopokSzáma
        {
            get
            {
                int ÜresOszlopok = 0;

                for (int oszlop = 0; oszlop < OSZLOPOK; oszlop++)
                {
                    if (ÜresOszlop(oszlop))
                    {
                        ÜresOszlopok++;

                    }
                }
                return ÜresOszlopok;
            }
        }
        public void Fajlba_iras()
        {   
            
            StreamWriter iro = new StreamWriter("tablak64.txt", true, Encoding.Default);
            for (int sor = 0; sor < SOROK; sor++)
            {
                for (int oszlop = 0; oszlop < OSZLOPOK; oszlop++)
                {
                    iro.Write(T[sor, oszlop]);
                }
                iro.WriteLine();
            }
            iro.WriteLine();
            iro.Close();
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                Tabla tabla_peldany = new Tabla('+');
                Console.WriteLine("4. feladat: Az üres tábla:");
                tabla_peldany.Megjelenít();
                Console.WriteLine("5.feladat: A királynők megjelenítése:");
                tabla_peldany.Elhelyez(8);
                tabla_peldany.Megjelenít();
               
                Console.WriteLine("\n6. feladat: Üres oszlopok és sorok száma:");
                Console.WriteLine("Oszlopok: " + tabla_peldany.ÜresOszlopokSzáma);
                Console.WriteLine("Sorok: " + tabla_peldany.ÜresSorokSzáma);
                if (File.Exists("tablak64.txt"))
                {
                    File.Delete("tablak64.txt");
                }
                for (int kiralyno_szama = 1; kiralyno_szama <= 64; kiralyno_szama++)
                {

                    Tabla fajlba_tabla = new Tabla('*');
                    fajlba_tabla.Elhelyez(kiralyno_szama);
                    fajlba_tabla.Fajlba_iras();
                }
                    Console.ReadLine();
                
            }
        }
    }
}
