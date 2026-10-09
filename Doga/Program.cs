using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Feladat
            {
                Random rnd = new Random();

                int uzemanyag = 50;
                int osszesFogyasztas = 0;
                int tankolasok = 0;
                for (int nap = 1; nap <= 7; ++nap)
                {
                    int fogyasztas = rnd.Next(3, 13);

                    uzemanyag -= fogyasztas;
                    osszesFogyasztas += fogyasztas;
                    string uzenet;

                    if (uzemanyag < 15)
                    {
                        uzenet = "FIGYELEM: Üzemanyagszint kritikus! Újratankolva 50 literre.";
                        uzemanyag = 50;
                        ++tankolasok;
                    }
                    else if (fogyasztas >= 8)
                    {
                        uzenet = "Hosszú út volt!";
                    }
                    else
                    {
                        uzenet = "Sima utazás.";
                    }
                    Console.WriteLine("Nap: {0}", nap);
                    Console.WriteLine("Napi fogyasztás: {0} liter", fogyasztas);
                    Console.WriteLine("Üzenet: {0}", uzenet);
                    Console.WriteLine("Tartályban maradt: {0} liter", uzemanyag);
                    Console.WriteLine();
                }

                Console.WriteLine("Összes fogyasztás: {0} liter", osszesFogyasztas);
                Console.WriteLine("Tankolások száma: {0}", tankolasok);
            }

            Console.WriteLine();

            // 2. Feladat
            {
                int probalkozasok = 0;
                bool elfogadva = false;
                int azonosito = 0;

                do
                {
                    Console.Write("Adj meg egy 4 jegyű, páros azonosítót: \n");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out azonosito))
                    {
                        if (azonosito >= 1000 && azonosito <= 9999 && (azonosito % 2) == 0)
                        {
                            elfogadva = true;
                            break;
                        }
                    }

                    Console.Write("Nem 4 jegyű vagy nem páros számot adtál meg!\n");
                    ++probalkozasok;
                }
                while (!elfogadva && probalkozasok < 4);

                if (elfogadva)
                {
                    Console.Write("Azonosító elfogadva! Fiók sikeresen aktiválva.\n");
                }
                else
                {
                    Console.Write("Túl sok hibás kísérlet! A regisztráció megszakadt.\n");
                }
            }

            Console.WriteLine();

            // 3. Feladat
            {
                int keszlet = 20;
                int korok = 0;
                Random rnd2 = new Random();

                while (keszlet > 0 && keszlet < 30)
                {
                    int d1 = rnd2.Next(1, 7);
                    int d2 = rnd2.Next(1, 7);
                    int osszeg = d1 + d2;
                    string esemeny;

                    if (d1 == 6 && d2 == 6)
                    {
                        keszlet += 2;
                        esemeny = "Elhagyott raktár! +2 hordó szerzett.";
                    }
                    else if ((osszeg % 2) == 1)
                    {
                        keszlet -= 1;
                        esemeny = "Baleset! 1 hordó felrobbant!";
                    }
                    else
                    {
                        esemeny = "Biztonságos áthaladás.";
                    }

                    ++korok;

                    Console.WriteLine("Dobás: {0} és {1} (Összeg: {2}) - {3}", d1, d2, osszeg, esemeny);
                    Console.WriteLine("Aktuális készlet: {0} hordó", keszlet);
                }

                if (keszlet >= 30)
                {
                    Console.WriteLine("Megérkeztek.");
                }
                else
                {
                    Console.WriteLine("Megsemmisültek.");
                }

                Console.WriteLine("Megtett fordulók száma: {0}", korok);
            }

            Console.WriteLine();

            // 4. A) Sakktábla
            {
                Console.WriteLine("Sakktábla:");
                for (int i = 0; i < 4; ++i)
                {
                    if ((i % 2) == 0)
                    {
                        Console.WriteLine("*.*.*.*.");
                    }
                    else
                    {
                        Console.WriteLine(".*.*.*.*");
                    }
                }

                Console.WriteLine();

                // B) X alakzat
                int n;
                do
                {
                    Console.Write("Adj meg egy páratlan számot az X méretéhez: ");
                    string s = Console.ReadLine();
                    if (!int.TryParse(s, out n)) n = 0;
                }
                while ((n % 2) == 0 || n <= 0);

                Console.WriteLine("X alakzat (n={0}):", n);
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (j == i || j == (n - 1 - i))
                        {
                            Console.Write('*');
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();

                // C) Karácsonyfa
                Console.Write("Adj meg egy N értéket a karácsonyfához (pozitív egész): ");
                int N;
                if (!int.TryParse(Console.ReadLine(), out N) || N <= 0) N = 5;

                int width = 2 * N - 1;
                for (int i = 1; i <= N; ++i)
                {
                    int stars = 2 * i - 1;
                    int spaces = (width - stars) / 2;
                    Console.Write(new string(' ', spaces));
                    Console.Write(new string('*', stars));
                    Console.WriteLine();
                }
                // törzs
                Console.Write(new string(' ', N - 1));
                Console.WriteLine("*");

                Console.WriteLine();

                // D) Paralelogramma
                Console.Write("Adj meg N (sorok) értéket: ");
                int Pn;
                if (!int.TryParse(Console.ReadLine(), out Pn) || Pn <= 0) Pn = 3;
                Console.Write("Adj meg M (oszlopok) értéket: ");
                int Pm;
                if (!int.TryParse(Console.ReadLine(), out Pm) || Pm <= 0) Pm = 8;

                for (int i = 1; i <= Pn; ++i)
                {
                    int indent = (Pn - i) * 2;
                    Console.Write(new string(' ', indent));
                    Console.WriteLine(new string('*', Pm));
                }
            }
        }
    }
}
