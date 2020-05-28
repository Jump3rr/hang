using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HANG;
using System.IO;
using System.Runtime;

namespace HANG
{
    public class Gra
    {
        int bl;                                                                                                     //deklaracje
        int sp;
        int zycia;
        int sukces = 0;
        public static string slowo;
        char[] odpowiedz = { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
        List<char> wpisane = new List<char>();
        private string v;

        public Gra(string v)
        {
            this.v = v;
        }

        public void Rozgrywka()
        {
            Console.Clear();

            WyborPoziomu();
            int wybor = int.Parse(Console.ReadLine());
            switch(wybor)
            {
                case 1:
                    zycia = (int)poziom.Easy;
                    break;
                case 2:
                    zycia = (int)poziom.Medium;
                    break;
                case 3:
                    zycia = (int)poziom.Hard;
                    break;
                default:
                    zycia = (int)poziom.Medium;
                    break;
            }
            Console.Clear();


            var logFile = File.ReadAllLines(@"slowa.txt");                                              //wczytanie słownika
            var logList = new List<string>(logFile);                                                    //dodanie wszystkich słów do listy

            Random rnd = new Random();
            //losowanie słowa
            slowo = logList[rnd.Next(logList.Count())];
            char[] litery = slowo.ToCharArray();

            //zycia = 7;
            sukces = 0;

            for (int i = 0; i < litery.Length; i++)                                                     //początkowe wyświetlenie pauz w miejscach liter
            {
                Console.Write("_ ");
            }

            Console.WriteLine("");

            do
            {
                int iloscWpisanych = 0;
                bl = 0;
                sp = 0;
                string traf = Console.ReadLine().ToLower();
                char[] a = traf.ToCharArray();

                if (char.IsLetter(a[0]))
                {
                    wpisane.Add(a[0]);
                    wpisane.Add(',');
                    wpisane.Add(' ');
                    Console.Clear();

                    for (int j = 0; j < litery.Length; j++)
                    {
                        if (litery[j] == a[0])                                                              //sprawdzenie czy wpisana litera zgadza się z literą w wylosowanym słowie
                        {
                            odpowiedz[j] = a[0];                                                            //przypisanie prawidłowej litery zamiast pauzy
                        }
                        else
                        {
                            bl = bl + 1;                                                                    //sprawdzanie czy wpisana litera pojawia się w wyrazie przynajmiej raz
                            if (bl == litery.Length)
                            {
                                zycia = zycia - 1;                                                                  //jeśli nie ma danej litery w wyrazie - odejmuje życie
                                Console.WriteLine("Hasło nie zawiera tej literki. Pozostałe życia: " + zycia);
                            }
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Miały być tylko litery!");
                }

                for (int b = 0; b < litery.Length; b++)                                                 //wypisanie aktualnego stanu (pauzy + litery już odgadnięte)
                {
                    Console.Write(odpowiedz[b] + " ");
                }

                    //Console.WriteLine("");

                for (int y = 0; y < litery.Length; y++)                                                 //sprawdzenie czy gracz odgadł już wszystkie litery
                {
                    if (odpowiedz[y] == litery[y])
                    {
                        sp = sp + 1;                                                                    //policzenie ile liter się zgadza
                        if (sp == litery.Length)                                                        //sprawdzenie czy liczba odgadniętych liter jest równa liczbie liter w haśle
                            sukces = 1;
                    }
                }
                    Console.Write("              Użyte litery: ");
                    wpisane.ForEach(Console.Write);
                    Console.WriteLine(" ");

            } while (zycia > 0 && sukces == 0);

            if (zycia == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Przykro mi, przegrałeś! Hasło to: " + slowo);
                Console.ResetColor();
            }

            if (sukces == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Gratulacje! Zgadłeś hasło!");
                Console.ResetColor();
            }
            wpisane.Clear();
            Array.Clear(odpowiedz, 0, 12);                                                              //wyczyszczenie tablicy i przypisanie jej pauz na nowo w celu umożliwienia następnej rozgrywki
            odpowiedz = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
        }

        public void Zasady()                                                                                        //wyświetlenie zasad
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            Console.WriteLine("");
            Console.ResetColor();
        }

        public void Informacje()                                                                                    //wyświetlenie informacji 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("INFORMACJE O GRZE:");
            Console.WriteLine("Autor gry: Patryk Kamusiński");
            Console.WriteLine("Słownik do gry został pobrany ze strony: https://sjp.pl/slownik/growy/");
            Console.WriteLine(@"W celu optymalizacji gry, zmniejszenia rozmiaru plików oraz ułatwienia rozgrywki autor postanowił:");
            Console.WriteLine(@"   1. Zredukować liczbę wyrazów o wszystkie słowa zawierające polskie znaki diakrytyczne");
            Console.WriteLine(@"         (ą, ć, ę, ł, ń, ó, ś, ź, ż)");
            Console.WriteLine(@"   2. Usunąć wszystkie słowa, na które składa się mniej niż 8 liter");
            Console.WriteLine(@"   3. Usunąć wszystkie słowa, na które składa się więcej niż 12 liter");
            Console.WriteLine("Dokładna liczba słów możliwych do wylosowania wynosi: 808981");
            Console.WriteLine("");
            Console.ResetColor();
        }

        enum poziom
        {
            Easy = 10,
            Medium = 8,
            Hard = 6
        }
        private static void WyborPoziomu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Wybierz poziom trudności:");
            Console.WriteLine("1 - Łatwy");
            Console.WriteLine("2 - Średni");
            Console.WriteLine("3 - Trudny");
            Console.Write("Wybierz: ");
            Console.ResetColor();
        }
    }
}