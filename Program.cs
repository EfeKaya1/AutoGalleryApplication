using System;
using System.Collections.Generic;

namespace OtoGaleriUygulamasi
{
    internal class Program
    {
        static Galeri OtoGaleri = new Galeri();
        static int sayac = 0;
        static void Main(string[] args)
        {
            // Kullanıcı ile etkileşime gireceğimiz bütün kodlar program sınıfı içerisinde yazılacak.
            OtoGaleri.SahteVeriGir();
            Uygulama();
        }
        static void Uygulama()
        {
            Menu();
            while (true)
            {
                string secim = SecimAl();
                Console.WriteLine();
                switch (secim)
                {

                    case "K":
                    case "1":
                        ArabaKirala();
                        break;
                    case "T":
                    case "2":
                        ArabaTeslimi();
                        break;
                    case "R":
                    case "3":
                        ArabalariListele("Kirada");
                        break;
                    case "M":
                    case "4":
                        ArabalariListele("Galeride");
                        break;
                    case "A":
                    case "5":
                        ArabalariListele("ArabaYok");
                        break;
                    case "I":
                    case "6":
                        KiralamaIptal();
                        break;
                    case "Y":
                    case "7":
                        YeniAraba();
                        break;
                    case "S":
                    case "8":
                        ArabaSil();
                        break;
                    case "G":
                    case "9":
                        BilgileriGoster();
                        break;
                    case "ÇIKIŞ":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        sayac++;
                        break;


                }
            }
        }
        static string SecimAl()
        {
            if (sayac != 10)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                return Console.ReadLine().ToUpper();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                return "ÇIKIŞ";
            }

        }

        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                        ");
            Console.WriteLine("1 - Araba Kirala(K)                     ");
            Console.WriteLine("2 - Araba Teslim Al(T)                  ");
            Console.WriteLine("3 - Kiradaki Arabaları Listele(R)       ");
            Console.WriteLine("4 - Galerideki Arabaları Listele(M)     ");
            Console.WriteLine("5 - Tüm Arabaları Listele(A)            ");
            Console.WriteLine("6 - Kiralama İptali(I)                  ");
            Console.WriteLine("7 - Araba Ekle(Y)                       ");
            Console.WriteLine("8 - Araba Sil(S)                        ");
            Console.WriteLine("9 - Bilgileri Göster(G)                 ");
        }


        static void ArabaKirala()
        {
            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine();

            try
            {
                if (OtoGaleri.Arabalar.Count == 0)
                {
                    throw new Exception("Galeride hiç araba yok");
                }
                else if (OtoGaleri.GaleridekiAracSayisi == 0)
                {
                    throw new Exception("Tüm araçlar kirada.");
                }
                string plaka;
                while (true)
                {
                    plaka = AracGerecler.PlakaAl("Kiralanacak arabanın plakası: ");
                    string durum = OtoGaleri.DurumGetir(plaka);

                    if (durum == "Kirada")
                    {
                        Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                    }
                    else if (durum == "ArabaYok")
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }
                    else
                    {
                        break;
                    }
                }

                int sure = AracGerecler.SayiAl("Kiralanma süresi: ");

                OtoGaleri.ArabaKirala(plaka, sure);
                Console.WriteLine();
                Console.WriteLine(plaka.ToUpper() + " plakalı araba " + sure + " saatliğine kiralandı.");

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            // kiralanabilecek aracın plakası doğru girilmediği sürece tekrar istesin.


        }

        static void ArabaTeslimi()
        {
            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine();
            try
            {
                if (OtoGaleri.Arabalar.Count == 0)
                {
                    throw new Exception("Galeride hiç araba yok.");

                }
                else if (OtoGaleri.KiradakiAracSayisi == 0)
                {
                    throw new Exception("Kirada hiç araba yok.");

                }


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            // Kullanıcıdan aldığımız plaka verisi ile arabanın olup olmadığı kirada mı değil mi? kontrol yapılıp eğer teslimata uygun değilse hata döndürüp tekrar veri istenir.
            // aldığımız veriyi oluşturduğumuz galerideki teslim alma metoduna göndererek işlemi tamamlıyoruz.
            string plaka;

            while (true)
            {
                plaka = AracGerecler.PlakaAl("Teslim edilecek arabanın plakası: ");
                string durum = OtoGaleri.DurumGetir(plaka);
                if (durum == "Galeride")
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                }
                else if (durum == "ArabaYok")
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                }
                else
                {
                    break;
                }
            }

            OtoGaleri.ArabaTeslimAl(plaka);
            Console.WriteLine();
            Console.WriteLine("Araba galeride beklemeye alındı.");



        }

        static void ArabalariListele(string durum)
        {
            //1.yol
            if (durum == "Kirada")
            {
                Console.WriteLine("-Kiradaki Arabalar-");
            }
            else if (durum == "Galeride")
            {
                Console.WriteLine("-Galerideki Arabalar-");
            }
            else
            {
                Console.WriteLine("-Tüm Arabalar-");
            }

            //2. yol
            //Console.WriteLine(durum == "Kirada" ? "-Kiradaki Arabalar-" : durum == "Galeride" ? "-Galerideki Arabalar-" : "-Tüm Arabalar-");

            Console.WriteLine();
            ArabaListele(OtoGaleri.ArabaListesiGetir(durum));
        }


        static void ArabaListele(List<Araba> liste)
        {
            //Toplam araç sayısı 0 ise listelenecek araç yok uyarısı verilsin.
            if (liste.Count == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
                return;
            }
            Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) +
                    "K. Sayısı".PadRight(12) + "Durum");
            Console.WriteLine("".PadRight(70, '-'));

            foreach (Araba item in liste)
            {
                Console.WriteLine(item.Plaka.PadRight(14) + item.Marka.PadRight(12) + item.KiralamaBedeli.ToString().PadRight(12) + item.AracTipi.ToString().PadRight(12) + item.KiralanmaSayisi.ToString().PadRight(12) + item.Durum);
            }

        }

        static void KiralamaIptal()
        {
            // Eğer hiç bir araba kiralanmadıysa bu hatayı döndürecek.
            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine();
            try
            {

                if (OtoGaleri.KiradakiAracSayisi == 0)
                {
                    throw new Exception("Kirada araba yok.");

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            // kullanıcıdan aldığımız plaka verisinin uygun , doğru olup olmadığı kontrol edilip eğer doğru değilse hata döndürülüp tekrar giriş talep edilir.
            // Kiralamaiptal metodu na kullanıcıdan aldığımız veri gönderek kiralamayı iptal ediyoruz.

            string plaka;

            while (true)
            {
                plaka = AracGerecler.PlakaAl("Kiralaması iptal edilecek arabanın plakası:  ");
                string durum = OtoGaleri.DurumGetir(plaka);
                if (durum == "Galeride")
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                }
                else if (durum == "ArabaYok")
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                }
                else
                {
                    break;
                }
            }

            OtoGaleri.KiralamaIptal(plaka);
            Console.WriteLine();
            Console.WriteLine("İptal gerçekleştirildi.");
        }

        static void YeniAraba()
        {
            Console.WriteLine("-Araba Ekle-");
            Console.WriteLine();

            string plaka; // Döngü dışarısında değişken tanımlıyoruz çünkü döngü içerisinde ki değişkeni metoda gönderemiyoruz.
            while (true)
            {
                plaka = AracGerecler.PlakaAl("Plaka: ");

                // Araçgereçlerde oluştuğumuz plaka alma metodu ile  kullanıcıdan girdiği veri kontrol edilip hata varsa hata döndürülüp tekrar giriş istenilir.

                if (OtoGaleri.DurumGetir(plaka) == "Kirada" || OtoGaleri.DurumGetir(plaka) == "Galeride") // Eğer koşul sağlanıyoruz galeride böyle bir araba kayıtlıdır tekrar bilgi alınır.
                {
                    Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                }
                else
                {
                    break; // if koşulu sağlandıysa araba yoktur yeni araba için bilgiler alınır.
                }
            }
            // Araçgereçlere tanımladığımız ve hazırladığımız metodlar ile kulannıcıdan veri alarak ekle metoduna gönderiyoruz ve yeni araba kaydı yapılmış oluyor.
            string marka = AracGerecler.YaziAl("Marka: ");
            float kiralamaBedeli = AracGerecler.SayiAl("Kiralama bedeli: ");
            string aracTipi = AracGerecler.AracTipiAl();
            OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, aracTipi);
            Console.WriteLine();
            Console.WriteLine("Araba başarılı bir şekilde eklendi.");
        }

        static void ArabaSil()
        {
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine();
            string plaka;
            try
            {

                if (OtoGaleri.Arabalar.Count == 0)
                {
                    throw new Exception("Galeride silinecek araba yok.");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            while (true)
            {
                plaka = AracGerecler.PlakaAl("Silmek istediğiniz arabanın plakasını giriniz:");

                if (OtoGaleri.DurumGetir(plaka) == "ArabaYok")
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                }
                else if (OtoGaleri.DurumGetir(plaka) == "Kirada")
                {
                    Console.WriteLine("Araba kirada olduğu için silme işlemi gerçekleştirilemedi.");
                }
                else
                {
                    break;
                }
            }
            OtoGaleri.ArabaSil(plaka);
            Console.WriteLine();
            Console.WriteLine("Araba silindi.");
        }

        static void BilgileriGoster()
        {

            // Galeri üzerine kaydettiğimiz araçların bilgilerini direkt classa ulaşarak bilgilerini döndürüyoruz.

            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine("Toplam araba sayısı: " + OtoGaleri.ToplamAracSayisi);
            Console.WriteLine("Kiradaki araba sayısı: " + OtoGaleri.KiradakiAracSayisi);
            Console.WriteLine("Bekleyen araba sayısı: " + OtoGaleri.GaleridekiAracSayisi);
            Console.WriteLine("Toplam araba kiralama süresi: " + OtoGaleri.ToplamAracKiralamaSuresi);
            Console.WriteLine("Toplam araba kiralama adedi: " + OtoGaleri.ToplamAracKiralamaAdeti);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);

        }

    }
}
