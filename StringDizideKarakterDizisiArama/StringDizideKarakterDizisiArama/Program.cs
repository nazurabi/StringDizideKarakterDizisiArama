using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDizideKarakterDizisiArama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bir kelime girin=");
            string kelime = Console.ReadLine();
            Console.Write("Aranacak kelimeyi giriniz=");
            string aranan = Console.ReadLine();
            string[] gecicibulunanlar = new string[kelime.Length];
            byte bulunanlarinsayaci = 0; // Bulunanların sayacı ile sadece dolu index sayısı kadar bulunanlar dizisi oluşturduk. 56.Satır
            for (int i = 0; i < kelime.Length; i++)
            {
                string[] aranankontrol = new string[aranan.Length];
                int sayac = -1;
                for (int j = 0; j < aranan.Length; j++)
                {
                    if ((i + j) < kelime.Length && i <= (kelime.Length - aranan.Length))
                    {
                        if (kelime[i + j] != aranan[j])
                        {
                            break;
                        }
                        sayac++;
                        aranankontrol[sayac] = (i + j).ToString();
                    }
                }

                if (aranankontrol[aranan.Length - 1] != null) // Bu kontrol ile sadece aranan karakter dizisi ile alakalı olan kısımları buldurduk. Aranan dizinin son index i null ise demek ki tam olarak eşleşme sağlanmamış demektir. Örneğin Eskişehir Eskrim Klübü kelimesi içerisinde Eskr kelimesini ararken bu şartı koymaz isek bize 'E' yide 'Esk' i de arananmış gibi gösterir.
                {
                    for (int k = 0; k < gecicibulunanlar.Length; k++)
                    {
                        if (gecicibulunanlar[k] == null) // Kelime içerisinde dizi halinde bulunan aranan karakterleri dizi halinde gecicibulunanlara eklemeyi sağladık. Örneğin Eskişehir eskrim eskrim klübü olarak yazıp 'eskr' aratırsak ilk bulduğu 4 lü diziyi gecicibulunanların 3.index ine kadar yazıp ikinci bulduğu 4 lü diziyi gecicibulunanların 4.index inden itibaren yazmaya başlar çünkü null olan ikinci turda 4.indexten itibaren olan kısımdır.
                        {
                            for (int l = 0; l < aranankontrol.Length; l++)
                            {
                                if ((k + l) < gecicibulunanlar.Length && k <= (gecicibulunanlar.Length - aranankontrol.Length))
                                {
                                    gecicibulunanlar[k + l] = aranankontrol[l].ToString();
                                    bulunanlarinsayaci++;
                                }
                            }
                            break; // Aranan kelime uzunluğundaki her aktarımdan sonra dışa çıkmayı sağladık break yapmazsak k değeri döngüsü boyunca mükerrer kayıt oluşturur.
                        }
                    }
                }
            }

            string[] bulunanlar = new string[bulunanlarinsayaci]; 

            for (int i = 0; i < gecicibulunanlar.Length; i++)
            {
                if (gecicibulunanlar[i] != null)
                {
                    bulunanlar[i] = gecicibulunanlar[i];// Gecicibulunanlarin uzunluğu kelime uzunluğu kadar ancak bazı indexleri boş, biz burada sadece dolu olan indexleri bulunanlar dizisi üzerine çektik.
                }
            }

            for (int i = 0; i < kelime.Length; i++)
            {
                bool varmi = false;
                for (int j = 0; j < bulunanlar.Length; j++)
                {
                    if (i == Convert.ToInt32(bulunanlar[j])) // Kodumuzu aradığımız karakter dizisi ana kelime dizisinde index olarak kaçıncı indexte ise o index e işlem yapacak şekilde yazdık
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(kelime[i]);
                        Console.ResetColor();
                        varmi = true;
                        break;
                    }
                }
                if (varmi == false)
                {
                    Console.Write(kelime[i]);
                }
            }
            Console.WriteLine("");
        }
    }
}
