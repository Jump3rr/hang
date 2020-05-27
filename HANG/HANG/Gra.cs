using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HANG;
using System.IO;

namespace HANG
{
    public class Gra
    {
        int bl;
        int sp;
        int zycia = 7;
        int sukces = 0;
        public static string slowo;
        //char[] litery = slowo.ToCharArray();
        char[] odpowiedz = { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
        private string v;

        public Gra(string v)
        {
            this.v = v;
        }

        public void Rozgrywka()
        {
            var logFile = File.ReadAllLines(@"slowa.txt");
            var logList = new List<string>(logFile);
            Random rnd = new Random();

            slowo = logList[rnd.Next(logList.Count())];
            char[] litery = slowo.ToCharArray();

            zycia = 7;
            sukces = 0;
            for (int i = 0; i < litery.Length; i++)
            {
                Console.Write("_ ");
            }
            Console.WriteLine("");
            do
            {
                string traf = Console.ReadLine();
                bl = 0;
                sp = 0;
                char[] a = traf.ToCharArray();
                for (int j = 0; j < litery.Length; j++)
                {
                    if (litery[j] == a[0])
                    {
                        odpowiedz[j] = a[0];
                    }
                    else
                    {
                        bl = bl + 1;
                        if (bl == litery.Length)
                        {
                            zycia = zycia - 1;
                            Console.WriteLine("Hasło nie zawiera tej literki. Pozostałe życia: " + zycia);
                        }
                    }
                }
                for (int b = 0; b < litery.Length; b++)
                {
                    Console.Write(odpowiedz[b] + " ");
                }
                Console.WriteLine("");
                for (int y = 0; y < litery.Length; y++)
                {
                    if (odpowiedz[y] == litery[y])
                    {
                        sp = sp + 1;
                        if (sp == litery.Length)
                            sukces = 1;
                    }
                }
            } while (zycia > 0 && sukces == 0);

            if (zycia == 0)
            {
                Console.WriteLine("Przykro mi, przegrałeś! Hasło to: " + slowo);
            }
            if (sukces == 1)
            {
                Console.WriteLine("Gratulacje! Zgadłeś hasło!");
            }
            Array.Clear(odpowiedz, 0, 12);
            odpowiedz = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
        }
        public void Zasady()
        {
            Console.WriteLine("ZASADY GRY:");
            Console.WriteLine(@"Po rozpoczęciu rozgrywki na ekranie pojawią się pauzy (''_'').");
            Console.WriteLine("Każda pauza symbolizuje jedną literkę składającą się na losowy wyraz z polskiego słownika.");
            Console.WriteLine("Hasła nie zawierają cyfr, znaków specjalnych oraz polskich znaków diakrytycznych!");
            Console.WriteLine("Zadaniem gracza jest odgadnięcie hasła wpisując do konsoli pojedyncze litery.");
            Console.WriteLine("Gracz na początku każdej rozgrywki ma 7 żyć.");
            Console.WriteLine("Za każdym razem, gdy gracz wpisze literkę, która nie znajduje się w haśle traci jedno życie.");
            Console.WriteLine("Gra kończy się na dwa sposoby - zwycięstwo gracza, lub jego przegrana.");
            Console.WriteLine("Gracz przegrywa, gdy liczba jego żyć spadnie do zera.");
            Console.WriteLine("Gracz wygrywa, gdy uda mu się odgadnąć hasło, zanim straci wszystkie życia.");
            Console.WriteLine("POWODZENIA!");
        }
        public void Informacje()
        {
            Console.WriteLine("INFORMACJE O GRZE:");
            Console.WriteLine("Autor gry: Patryk Kamusiński");
            Console.WriteLine("Słownik do gry został pobrany ze strony: https://sjp.pl/slownik/growy/");
            Console.WriteLine(@"W celu optymalizacji gry, zmniejszenia rozmiaru plików oraz ułatwienia rozgrywki autor postanowił:");
            Console.WriteLine(@"   1. Zredukować liczbę wyrazów o wszystkie słowa zawierające polskie znaki diakrytyczne");
            Console.WriteLine(@"         (ą, ć, ę, ł, ń, ó, ś, ź, ż)");
            Console.WriteLine(@"   2. Usunąć wszystkie słowa, na które składa się mniej niż 8 liter");
            Console.WriteLine(@"   3. Usunąć wszystkie słowa, na które składa się więcej niż 12 liter");
            Console.WriteLine("Dokładna liczba słów możliwych do wylosowania wynosi: 808981");

        }
    }
}