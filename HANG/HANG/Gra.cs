using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HANG;

namespace HANG
{
    public class Gra
    {
        public int zycia = 7;
        int sukces = 0;
        int bl;
        int sp;
        public static string slowo = "starocie";
        char[] litery = slowo.ToCharArray();
        char[] odpowiedz = { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
        private string v;

        public Gra(string v)
        {
            this.v = v;
        }

        public void Rozgrywka()
        {
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
                Console.WriteLine("Przykro mi, przegrałeś!");
            }
            if (sukces == 1)
            {
                Console.WriteLine("Gratulacje! Zgadłeś hasło!");
            }

            //Console.WriteLine(odpowiedz);
        }
    }
}