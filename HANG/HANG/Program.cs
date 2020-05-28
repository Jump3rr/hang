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
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("WITAJ W GRZE WISIELEC!");
            Console.ResetColor();

            Gra runda = new Gra("123456789");

            do
            {
                PrintActions();                                         //pętla kończąca się dopiero po wybraniu wyjścia przez użytkownika

                int action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wyłączanie aplikacji ...");
                        Environment.Exit(0);
                        break;
                    case 1:
                        runda.Rozgrywka();                              //właściwa rozgrywka
                        break;
                    case 2:
                        runda.Zasady();                                 //wyświetlenie zasad
                        break;
                    case 3:
                        runda.Informacje();                             //wyświetlenie informacji
                        break;
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
    }

}
