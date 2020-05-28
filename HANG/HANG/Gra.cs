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
        int bl;
        int sp;
        int zycia;
        int sukces = 0;
        public static string slowo;
        char[] odpowiedz = { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
        List<char> wpisane = new List<char>();
        private readonly string v;

        public Gra(string v)
        {
            this.v = v;
        }

        public void Rozgrywka()
        {
            try
            {
                int wybor = int.Parse(Console.ReadLine());
                PoziomTrudnosci(wybor);
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("Nieprawidłowa wartość! Musisz wpisać cyfrę, do której przypisany jest poziom trudności!");
                Rozgrywka();
            }

            var logFile = File.ReadAllLines(@"slowa.txt");                                              //wczytanie słownika
            var logList = new List<string>(logFile);                                                    //dodanie wszystkich słów do listy

            Random rnd = new Random();
            slowo = logList[rnd.Next(logList.Count())];

            char[] litery = slowo.ToCharArray();

            sukces = 0;

            for (int i = 0; i < litery.Length; i++)                                                     //początkowe wyświetlenie pauz w miejscach liter
            {
                Console.Write("_ ");
            }

            Console.WriteLine("");

            Petla(litery);

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

        private void PoziomTrudnosci(int wybor)
        {
            switch (wybor)
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
        }

        private void Petla(char[] litery)
        {
            do
            {
                bl = 0;
                sp = 0;
                string traf = Console.ReadLine().ToLower();
                char[] a = traf.ToCharArray();
                if (a.Length == 1)
                {
                    if (char.IsLetter(a[0]))
                    {
                        wpisane.Add(a[0]);
                        wpisane.Add(',');
                        wpisane.Add(' ');
                        Console.Clear();

                        PetlaSprawdzajaca(litery, a);

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Hasło zawiera tylko litery!");
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Musisz wpisać jedną literę!");
                }

                for (int b = 0; b < litery.Length; b++)                                                 //wypisanie aktualnego stanu (pauzy + litery już odgadnięte)
                {
                    Console.Write(odpowiedz[b] + " ");
                }

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
        }

        private void PetlaSprawdzajaca(char[] litery, char[] a)
        {
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
                        zycia = zycia - 1;
                        Console.WriteLine("Hasło nie zawiera tej literki. Pozostałe życia: " + zycia);
                    }
                }
            }
        }

        enum poziom
        {
            Easy = 10,
            Medium = 8,
            Hard = 6
        }

    }
}