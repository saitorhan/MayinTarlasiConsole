using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayinTarlasiConsole
{
    class Program
    {
        private static int satir, sutun, puan;
        static char[,] Tarla = new Char[30,30];
        static bool[,] TarlaSecimi = new bool[30,30];
        static Random Random = new Random();
        private static string Secim;
        static void Main(string[] args)
        {
            oyunsifirla:
            TarlaSifirla();
            tarlabasi:
            TarlaGoster();
            Information();
            Console.WriteLine($"Seçim Sayısı: {puan / 10}\nPuan: {puan}");
            Default();
            Console.Write("Seçtiğiniz satır ve sutunu seçiniz (satır, sutun formatında yazınız Ör: 3,5): ");
            Secim = Console.ReadLine();
            string[] secilenler = Secim.Split(',');
            if (secilenler.Length != 2)
            {
                Error();
                Console.WriteLine("Satır ve sütun seçimi yanlış formatta girildi.");
                Console.ReadLine();
                goto tarlabasi;
            }

            if (!Int32.TryParse(secilenler[0], out satir) || (satir < 0 || satir >= 30))
            {
                Error();
                Console.WriteLine("Satır değeri yanlış formatta girildi veya geçersiz değer girildi. Satır değeri  0 - 29 arasında bir değerdir (dahil)");
                Console.ReadLine();
                goto tarlabasi;
            }
            if (!Int32.TryParse(secilenler[1], out sutun) || (sutun < 0 || sutun >= 30))
            {
                Error();
                Console.WriteLine("Sutun değeri yanlış formatta girildi veya geçersiz değer girildi. Sutun değeri  0 - 29 arasında bir değerdir (dahil)");
                Console.ReadLine();
                goto tarlabasi;
            }

            if (TarlaSecimi[satir, sutun])
            {
                Error();
                Console.WriteLine($"({satir},{sutun}) daha önce seçildi. Yeni değer giriniz.");
                Console.ReadLine();
                goto tarlabasi;
            }

            if (Tarla[satir, sutun] == '*')
            {
                Information();
                Console.WriteLine($"Oyun bitti. Puanınız: {puan}");
                Console.ReadLine();
                goto oyunsifirla;

            }

            TarlaSecimi[satir, sutun] = true;
            puan += 10;
            TarlaGoster();
            goto tarlabasi;
            Console.ReadLine();
        }

        private static void TarlaGoster()
        {
            Default();
            Console.Clear();
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (TarlaSecimi[i, j])
                    {
                        SelectedItem();
                    }
                    else
                    {
                        Default();
                    }
                   Console.Write(TarlaSecimi[i,j] ? Tarla[i,j] : '#');
                }

                Console.WriteLine();
            }

            Console.WriteLine("-----------------------------------");
        }

        private static void TarlaSifirla()
        {
            Default();
            puan = 0;
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Tarla[i, j] = Random.Next() % 7 == 0 ? '*' : '#';
                    TarlaSecimi[i, j] = false;
                }
            }
            
        }

        static void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
        }
        static void Information()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.White;
        }
        static void Default()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void SelectedItem()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
