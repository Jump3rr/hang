using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANG
{
    class Program
    {
        static void Main(string[] args)
        {
            //int action;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("WITAJ W GRZE WISIELEC!");
            Console.ResetColor();

            Gra runda = new Gra("123456789");

            do
            {
                PrintActions();                                         //pętla kończąca się dopiero po wybraniu wyjścia przez użytkownika
                string input = Console.ReadLine();
                try
                {
                    int action = int.Parse(input);
                    switch (action)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wyłączanie aplikacji ...");
                            Environment.Exit(0);
                            break;
                        case 1:
                            WyborPoziomu();
                            runda.Rozgrywka();                              //właściwa rozgrywka
                            break;
                        case 2:
                            Zasady();                                 //wyświetlenie zasad
                            break;
                        case 3:
                            Informacje();                             //wyświetlenie informacji
                            break;
                    }
                }
                catch(FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowa wartość! Musisz wpisać cyfrę, do której przypisane jest polecenie!");
                }
                
            } while (true);

        }

        private static void PrintActions()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Wybierz co chcesz zrobić:");
            Console.WriteLine("1 - Graj");
            Console.WriteLine("2 - Zasady gry");
            Console.WriteLine("3 - Informacje");
            Console.WriteLine("0 - Wyjście");
            Console.Write("Wybierz: ");
            Console.ResetColor();
        }

        private static void Zasady()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("ZASADY GRY:");
            Console.WriteLine(@"Po rozpoczęciu rozgrywki na ekranie pojawią się pauzy (''_'').");
            Console.WriteLine("Każda pauza symbolizuje jedną literkę składającą się na losowy wyraz z polskiego słownika.");
            Console.WriteLine("Hasła nie zawierają cyfr, znaków specjalnych oraz polskich znaków diakrytycznych!");
            Console.WriteLine("Zadaniem gracza jest odgadnięcie hasła wpisując do konsoli pojedyncze litery.");
            Console.WriteLine("Gracz na początku każdej rozgrywki ma określoną liczbę żyć.");
            Console.WriteLine("Liczba żyć zależna jest od wybranego poziomu trudności.");
            Console.WriteLine("Łatwy - 10 żyć, Średni - 8 żyć, Trudny - 6 żyć");
            Console.WriteLine("Przy wpisaniu innej cyfry niż ta, która jest przypisana do poziomu gra zacznie się na poziomie Średnim");
            Console.WriteLine("Za każdym razem, gdy gracz wpisze literkę, która nie znajduje się w haśle traci jedno życie.");
            Console.WriteLine("Gra kończy się na dwa sposoby - zwycięstwo gracza, lub jego przegrana.");
            Console.WriteLine("Gracz przegrywa, gdy liczba jego żyć spadnie do zera.");
            Console.WriteLine("Gracz wygrywa, gdy uda mu się odgadnąć hasło, zanim straci wszystkie życia.");
            Console.WriteLine("POWODZENIA!");
            Console.WriteLine("");
            Console.ResetColor();
        }

        private static void Informacje()
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

        private static void WyborPoziomu()
        {
            Console.Clear();
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
