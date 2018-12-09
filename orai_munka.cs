using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kiralynok
{
    //1 - osztályt Tábla azonosítóval létrehozni!
    class Tabla
    {
        private const int SOROK = 8; //Sorok száma 8 darab, nem változik
        private const int OSZLOPOK = 8; //Oszlopok száma 8 darab, nem változik
        private const char KIRÁLYNŐ = 'K'; //Királynő esetén megjelenítendő karakter!

        //2 - Az osztály tagjaként deklaráljon két privát mezőt! Az egyik karaktertípusú mátrix 
        //(kétdimenziós tömb) T azonosítóval, a másik karaktertípusú változó ÜresCella azonosítóval.
        private char[,] T;
        private char ÜresCella;
        //3 - Készítse el az osztály konstruktorát, amely a következő feladatokat látja el!
        public Tabla(char üresCella)//Konstruktor neve ugyanaz mint a classnak, típusa NINCS!
        {            
            T = new char[SOROK, OSZLOPOK];//Létrehozni a T mátrixot 8x8-as mérettel!
            //Az ÜresCella mező értékét a konstruktor paraméterében átadott, karaktertípusú változó értékével tölti fel.
            ÜresCella = üresCella;
            //A T mátrix minden celláját az ÜresCella változó értékével tölti fel.
            for (int sor = 0; sor < SOROK; sor++)//Végimegyünk a sorokon
            {
                for (int oszlop = 0; oszlop < OSZLOPOK; oszlop++)//Végigmegyünk az oszlopokon
                {
                    T[sor, oszlop] = ÜresCella;//Összes értéket beállítjuk ÜresCella értékére
                }
            }
        }
        //4. Feladathoz, Megjelenít() metódus!
        public void Megjelenít()//Létrehozunk egy void típusú metódust Megjelenít néven
        {
            for (int sor = 0; sor<SOROK; sor++)//Végimegyünk a sorokon
            {
                for (int oszlop = 0; oszlop<OSZLOPOK; oszlop++)//Végigmegyünk az oszlopokon
                {
                    Console.Write(T[sor, oszlop]);//Kiíratjuk az aktuális mátrix elemének értékét
                }
            Console.WriteLine();//Sortörés minden egyes sor kirajzolása után!
            }
        }
        //5. Feladat - Készítsen metódust Elhelyez() azonosítóval, amely a T mátrixban 
        //N darab királynőt helyez el véletlenszerű pozícióban! Az N a metódus paramétere legyen,
        //a királynőket a „K” karakter jelölje a mátrixban! 
        //Ügyeljen arra, hogy csak üres helyre(cellába) tegyen királynőt!
        public void Elhelyez(int N) //Paraméter -N darab királynőt helyez el véletlenszerű pozícióban
        {
            Random rnd = new Random();//Random függvény meghívása
            while (N > 0)//Addig futtatjuk a ciklus amíg el nem fogyott az összes elhelyezendő királynő
            {
                int sor = rnd.Next(0, SOROK);//Generálunk egy random értéket 0-8 között sor-nak
                int oszlop = rnd.Next(0, OSZLOPOK);//Generálunk egy random értéket 0-8 között oszlop-nak

                if (T[sor, oszlop] == ÜresCella)//Ha azon a helyen üres cella van
                {
                    T[sor, oszlop] = KIRÁLYNŐ;//Beleillesszük a 'K' karaktert a királynőt
                    N--;//Majd csökkentjük az elhelyezendő elemek számát eggyel
                }
            }
        }

        //7. feladat - logikai típussal visszatérő metódusok készítése ÜresOszlop(), ÜresSor() azonosítókkal,
        //melyek felhasználásával eldönthető, hogy a metódus paraméterében megadott 
        //oszlopban [0−7]/sorban [0−7] található-e legalább egy királynő a T mátrixban!
        public bool ÜresOszlop(int oszlop)//készítünk egy metódust amely kap egy oszlop sorszámot paraméterként
        {
            for (int sor = 0; sor < SOROK; sor++)//Végigmegyünk az adottsorszámú oszlopon
            {
                if (T[sor, oszlop] == KIRÁLYNŐ)//Ha találunk benne egy elemet aminek értéke királynő
                {
                    return false;//Hamis értékkel térünk vissza
                }
            }
            return true;//Különben igaz értékkel térünk vissza, hisz nemtaláltunk semmit!
        }

        public bool ÜresSor(int sor)//készítünk egy metódust amely kap egy oszlop sorszámot paraméterként
        {
            for (int oszlop = 0; oszlop < OSZLOPOK; oszlop++)//Végigmegyünk az adottsorszámú soron
            {
                if (T[sor, oszlop] == KIRÁLYNŐ)//Ha találunk benne egy elemet aminek értéke királynő
                {
                    return false;//Hamis értékkel térünk vissza
                }
            }
            return true;//Különben igaz értékkel térünk vissza, hisz nemtaláltunk semmit!
        }

        //8. feladat - Készítsen jellemzőket/property (ÜresOszlopokSzáma, ÜresSorokSzáma) 
        //melyekkel a T mátrixban lévő teljesen üres sorok és oszlopok számát lehet lekérdezni!
        public int ÜresSorokSzáma
        {
            get//Létrehozzuk a get részt, ezzel olvastatjuk ki az adatokat
            {
                int üresSorok = 0;//Megszámlálás tételét alkalmazzuk, kell egy változó aminek az értéke 0
                for (int sor = 0; sor < SOROK; sor++)//Végig megyünk a mátrix sorain
                {
                    if (ÜresSor(sor))//Az ÜresSor metódussal ellenőrizzük van-e királynő az adott sorban
                    {
                        üresSorok++;//Ha találunk, növeljük a változó értékét eggyel
                    }
                }
                return üresSorok;//Miután végignéztük a mátrixot visszatérünk a sorok mennyiségével
            }
            //Nincs szükség set részre, mert nem kéri a feladat
        }

        public int ÜresOszlopokSzáma
        {
            get//Létrehozzuk a get részt, ezzel olvastatjuk ki az adatokat
            {
                int üresOszlopok = 0;//Megszámlálás tételét alkalmazzuk, kell egy változó aminek az értéke 0
                for (int oszlop = 0; oszlop < OSZLOPOK; oszlop++)//Végig megyünk a mátrix oszlopain
                {
                    if (ÜresOszlop(oszlop))//Az ÜresOszlop metódussal ellenőrizzük van-e királynő az adott oszlopban
                    {
                        üresOszlopok++;//Ha találunk, növeljük a változó értékét eggyel
                    }
                }
                return üresOszlopok;//Miután végignéztük a mátrixot visszatérünk a sorok mennyiségével
            }
            
        }
        public void Fajlba_iras()
        {   
            // 64 darab Tábla típusú osztálypéldányt létrehozása és tárolja a tablak64.txt állományban
            //a T mátrix karaktereit a következők szerint!
            StreamWriter iro = new StreamWriter("tablak64.txt", true, Encoding.Default);
            //A program indulásakor ellenőrizze, hogy létezik-e a tablak64.txt állomány!
            for (int sor = 0; sor < SOROK; sor++)//Végimegyünk a sorokon
            {
                for (int oszlop = 0; oszlop < OSZLOPOK; oszlop++)//Végigmegyünk az oszlopokon
                {
                    iro.Write(T[sor, oszlop]);//Kiíratjuk az aktuális mátrix elemének értékét
                }
                iro.WriteLine();//Sortörés minden egyes sor kirajzolása után!
            }
            iro.WriteLine();//Sortörés minden egyes tábla kirajzolása után!
            iro.Close();//Lezárjuk az írási folyamatot
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //4. feladat - Hozzon létre egy Tábla típusú osztálypéldányt (objektumot), 
            //majd jelenítse meg a mátrixban lévő, üres cellákat jelölő karaktereket!
            //A tábla megjelenítését a Megjelenít() metódussal végezze! 
            Tabla tabla_peldany = new Tabla('#');//példányosítás, meg kell adni egy karaktert is konstruktor miatt!
            Console.WriteLine("\n4. feladat: Az üres tábla:");//Feladat szövegének kiírása
            tabla_peldany.Megjelenít();//Adott példány megjelenítése
            

            //6. feladat - Helyezzen el az osztálypéldány T mátrixában 8 darab királynőt 
            //az Elhelyez() metódus meghívásával, majd jelenítse meg a képernyőn
            //a királynőkkel feltöltött táblát !
            Console.WriteLine("\n6. feladat: A feltöltött tábla:");
            tabla_peldany.Elhelyez(8);
            tabla_peldany.Megjelenít();


            //9. feladat - Jelenítse meg a képernyőn a T mátrix üres sorainak és oszlopainak 
            //darabszámát!
            Console.WriteLine("\n9. feladat: Üres oszlopok és sorok száma:");
            Console.WriteLine("Oszlopok: " + tabla_peldany.ÜresOszlopokSzáma);
            Console.WriteLine("Sorok: " + tabla_peldany.ÜresSorokSzáma);
            //Ha az állomány ("tablak64.txt") létezik, akkor törölje le!
            if (File.Exists("tablak64.txt"))
            {
                File.Delete("tablak64.txt");
            }
            for (int kiralyno_szama = 1; kiralyno_szama <= 64; kiralyno_szama++)
            {
                Az üres cellákat a csillag(„*”) karakter jelölje! 
                Tabla fajlba_tabla = new Tabla('*');
                
                //Ez 1.táblában egy, a 2.táblában kettő, … a 64.táblában hatvannégy királynőt helyezzen el az Elhelyez() metódus hívásával!
                fajlba_tabla.Elhelyez(kiralyno_szama);
                fajlba_tabla.Fajlba_iras();
            }
            Console.ReadLine();//Szünetelteti a program futását enter leütéséig!


        }
    }
}
