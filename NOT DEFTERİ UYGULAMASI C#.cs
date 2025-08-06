/* Not Defteri Uygulaması
 Bu C# konsol uygulaması, kullanıcıya basit bir şekilde not yazma ve notları okuma imkanı sağlar.
 - Kullanıcı yeni not yazabilir.
 - Notlar tarih ve saat bilgisiyle birlikte kaydedilir.
 - Kaydedilen notlar dosyadan okunarak numaralandırılmış şekilde görüntülenir.
   
    Notlar, uygulama dizininde "notlar.txt" adlı bir dosyada saklanır.

Hazırlayan: Ceyda Gökkaya
Tarih:06.08.2025
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace NotDefteriUygulaması
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== NOT DEFTERİ UYGULAMASI===");
                Console.WriteLine("1 - Yeni not yaz");
                Console.WriteLine("2 - Notları oku");
                Console.WriteLine("3 - Çıkış");
                Console.Write("Seçiminiz: ");
                string seçim = Console.ReadLine();

                if (seçim == "1")
                    
                YeniNotYaz();
                else if (seçim == "2")
                    NotlarıOku();
                else if (seçim == "3")
                    break;
                else
                {
                    Console.WriteLine("Geçersiz seçim.");
                    Console.ReadLine();
                }
            }
        }

        static void YeniNotYaz()
        {
            Console.Clear();
            Console.WriteLine("Yeni notunuzu girin:");
            string not = Console.ReadLine();

            string tarihliNot = DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " - " + not;
            
            File.AppendAllText("notlar.txt", tarihliNot + Environment.NewLine);
            Console.WriteLine("Not kaydedildi");
            Console.ReadLine();
        }

        static void NotlarıOku()
        {
            Console.Clear();
            if (File.Exists("notlar.txt"))
            {
                string[] notlar = File.ReadAllLines("notlar.txt");
                Console.WriteLine("=== KAYITLI NOTLAR ===");

                int sayac = 1;
                foreach (string not in notlar)
                {
                    Console.WriteLine($"{sayac}. {not}");
                    sayac++;
                }
            }
            else
            {
                Console.WriteLine("Henüz hiç not yok.");
            }
            Console.ReadLine();
        }

       
    }
}
