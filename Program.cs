using graf_od_podstaw.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graf_od_podstaw
{
    class Program
    {
        static int Main(string[] args)
        {
            int[,] macierz_miejscowosci = new int[,]
            {
                {0, 1, 0, 0, 0},
                {1, 0, 1, 1, 0},
                {0, 1, 0, 1, 1},
                {0, 1, 0, 0, 1},
                {0, 0, 1, 1, 0}
            };
            int[,] Macierz_odleglosci = new int[,]
            {
                { 0, 1, 2, 2, 3 },
                { 1, 0, 1, 1, 2 },
                { 2, 1, 0, 1, 1 },
                { 2, 1, 2, 0, 1 },
                { 3, 2, 1, 1, 0 }

            };

            Console.WriteLine("Podaj punkt startowy: ");
            int start = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Podaj punkt końcowy: ");
            int koniec = Convert.ToInt16(Console.ReadLine());

            Graf graf = new Graf(macierz_miejscowosci);
            graf.rysuj();
            Algorytm_Wyszukiwania_Trasy algorytm_wyszukiwania_trasy = new Algorytm_Wyszukiwania_Trasy(Macierz_odleglosci,start,koniec);
            algorytm_wyszukiwania_trasy.rysuj();
            //miejscowosci
            Miejscowosci miejcowosci = new Miejscowosci();
            miejcowosci.dodaj_miejscowosci(0, "Otmuchów");
            miejcowosci.dodaj_miejscowosci(1, "Nysa");
            miejcowosci.dodaj_miejscowosci(2, "Biała nyska");
            miejcowosci.dodaj_miejscowosci(3, "Podkamień");
            miejcowosci.dodaj_miejscowosci(4, "Przełęk");

            miejcowosci.wyswietl_miejscowosci();
            Trasy_i_Polaczenia trasy_i_polaczenia = new Trasy_i_Polaczenia(graf,miejcowosci);
            trasy_i_polaczenia.WszystkieDostepneTrasy();
            var droga = Algorytm_Wyszukiwania_Trasy.ZnajdzTrase(graf.macierz, start, koniec);
            Console.WriteLine(droga); 
            //Console.ReadLine();
            return 0;
        }
    }
}
