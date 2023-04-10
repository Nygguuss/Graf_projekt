using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using graf_od_podstaw.Klasy;

namespace graf_od_podstaw.Klasy
{
    class Algorytm_Wyszukiwania_Trasy
    {
        private int[,] Macierz_odleglosci;
        private int WielkoscX;
        private int wielkosc_Y;
        private int start;
        private int koniec;

        public Algorytm_Wyszukiwania_Trasy(int[,]m, int s, int k)
        {
            Macierz_odleglosci = m;
            WielkoscX = Macierz_odleglosci.GetLength(0);
            wielkosc_Y = Macierz_odleglosci.GetLength(1);
            start = s;
            koniec = k;
        }

        public void rysuj()
        {
            for (int wiersz = 0; wiersz < Macierz_odleglosci.GetLength(0); wiersz++)
            {
                for (int kolumna = 0; kolumna < Macierz_odleglosci.GetLength(1); kolumna++)
                {
                    Console.Write("{0,3}", Macierz_odleglosci[wiersz, kolumna]);
                }
                Console.WriteLine();
            }
        }

        public static string ZnajdzTrase(int[,] macierzSasiedztwa, int Start, int Koniec)
        {

            int n = macierzSasiedztwa.GetLength(0);
            
            bool[] visited = new bool[n]; // tablica typu bool bedzie oznaczała, które pole zostało już oodwiedzone
       
          /*  parent służy do śledzenia "rodziców" każdego wierzchołka.
           Oznacza to, że dla każdego wierzchołka w grafie parent[i] przechowuje wierzchołek, z którego przyszliśmy do i.
            */
            int[] parent = new int[n]; 
            
            Queue<int> queue = new Queue<int>(); // stworzenie kolejki

            visited[Start] = true;
            queue.Enqueue(Start);

            while (queue.Count > 0)
            {
                int obecnyWierzcholek = queue.Dequeue();

                for (int i = 0; i < n; i++)
                {
                    if (macierzSasiedztwa[obecnyWierzcholek, i] != 0 && !visited[i])
                    {
                        visited[i] = true;
                        parent[i] = obecnyWierzcholek;
                        queue.Enqueue(i);

                        if (i == Koniec)
                        {
                            //tutaj tworzymy stringa ktorego zwrocimy jako trase
                            StringBuilder sciezka = new StringBuilder();
                            int v = i;
                            while (v != Start)
                            {
                                if(v!=Koniec) sciezka.Insert(0, $"{v} -> ");
                                else sciezka.Insert(0, $"{v}  ");

                                //tutaj cofamy sie do rodzica danego wierzchołka, żeby wypisac trase
                                v = parent[v];
                            }
                            sciezka.Insert(0, $"{Start} -> ");
                            return sciezka.ToString();
                        }
                    }
                }
            }

            // No path found
            return "Nie znleziono ścieżki.";
        }

    }
}
