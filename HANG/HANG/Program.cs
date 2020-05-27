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
            Console.WriteLine("Witaj w grze Wisielec!");
            Gra runda = new Gra("123456789");
            do
            {
                PrintActions();
                int action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 0:
                        Console.WriteLine("Wyłączanie aplikacji ...");
                        Environment.Exit(0);
                        break;
                    case 1:
                        runda.Rozgrywka();
                        break;
                    case 2:
                        runda.Zasady();
                        break;
                    case 3:
                        runda.Informacje();
                        break;
                }
            }
            while (true);

        }
        private static void PrintActions()
        {
            Console.WriteLine("Wybierz co chcesz zrobić:");
            Console.WriteLine("1 - Graj");
            Console.WriteLine("2 - Zasady gry");
            Console.WriteLine("3 - Informacje");
            Console.WriteLine("0 - Wyjście");
            Console.Write("Wybierz: ");
        }
    }

}
