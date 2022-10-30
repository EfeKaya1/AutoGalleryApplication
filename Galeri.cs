using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasi
{
    internal class Galeri
    {
        // bu sınıf içinde galeri ile ilgili kodlar yazılacak.
        // Galeriye ilişkin herhangi bir verinin değiştirilmesi gerektiğinde 
        // ilgili kodlar bu sınıfta yazılmalı.

        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamAracSayisi
        {
            get
            {
                return this.Arabalar.Count;
            }
        }


        public int KiradakiAracSayisi
        {
            get
            {
                //int adet = 0;
                //foreach (Araba item in Arabalar)
                //{
                //    if (item.Durum == "Kirada")
                //    {
                //        adet++;
                //    }
                //}
                //return adet;

                return this.Arabalar.Where(t => t.Durum == "Kirada").ToList().Count;
            }
        }

        public int GaleridekiAracSayisi
        {
            get
            {
                return this.Arabalar.Where(a => a.Durum == "Galeride").ToList().Count;
            }
        }
        public int ToplamAracKiralamaSuresi
        {
            get
            {
                //int toplam = 0;
                //foreach (Araba item in Arabalar)
                //{
                //    toplam += item.ToplamKiralanmaSüresi;
                //}
                //return toplam;

                return this.Arabalar.Sum(a => a.KiralamaSureleri.Sum());
            }
        }
        public int ToplamAracKiralamaAdeti
        {
            get
            {
                return this.Arabalar.Sum(a => a.KiralanmaSayisi);
            }
        }

        public float Ciro
        {
            get
            {
                return this.Arabalar.Sum(a => a.ToplamKiralanmaSuresi * a.KiralamaBedeli);
            }
        }

        public List<Araba> ArabaListesiGetir(string durum)
        {
            // parametreden aldığımız durum veri tipinde aldığımız veri ile otogaleride araç durumlarına göre listeleme gerçekleştiriyoruz.

            List<Araba> liste = this.Arabalar;
            if (durum == "Kirada" || durum == "Galeride")
            {
                liste = this.Arabalar.Where(a => a.Durum == durum).ToList();
            }
            return liste;
        }


        public string DurumGetir(string plaka)
        {
            // parametreden aldığımız plaka bilgisi ile aradığımız aracı buluyoruz.
            // FirsOrDefault metodu çağırdığımız listede ki ilk veriyi alır.
            // Eğer böyle bir araç varsa bulduğumuz aracın güncel durumunu döndürür eğer araç yoksa araç olmadığı için Empty döndürür.


            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();
            if (a != null)
            {
                return a.Durum;
            }
            return "ArabaYok";
        }

        public void ArabaKirala(string plaka, int sure)
        {
            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null && a.Durum == "Galeride")
            {
                a.Durum = "Kirada";
                a.KiralamaSureleri.Add(sure);
            }

        }

        public void ArabaTeslimAl(string plaka)
        {
            // bu plakaya ait arabayı bulmanız lazım

            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();

            //foreach (Araba item in Arabalar)
            //{
            //    if (item.Plaka == plaka)
            //    {
            //        a = item;
            //    }
            //}
            if (a != null)
            {
                if (a.Durum == "Galeride")
                {
                    throw new Exception("zaten galeride");
                }
                a.Durum = "Galeride";
            }
            else
            {
                throw new Exception("Bu plakada bir araç yok");
            }

        }

        public void KiralamaIptal(string plaka)
        {
            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null)
            {
                a.Durum = "Galeride";
                a.KiralamaSureleri.RemoveAt(a.KiralamaSureleri.Count - 1);
            }

        }


        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, string aTipi)
        {
            // paramatreden aldığımız bilgiler ile yeni bir araba oluşacak.
            // bu oluşan arabayı Arabalar listesine de ekleyeceğiz.


            Araba a = new Araba(plaka, marka, kiralamaBedeli, aTipi);
            this.Arabalar.Add(a);


        }
        public void ArabaSil(string plaka)
        {
            // parametreden aldığımız plaka bilgisi ile aradığımız aracı buluyoruz.
            // FirsOrDefault metodu çağırdığımız listede ki ilk veriyi alır.
            // remove metodu ile eğer böyle bir araç var ise ve galeride ise listeden bu aracın silinmesini sağlıyoruz.

            Araba a = this.Arabalar.Where(x => x.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null && a.Durum == "Galeride")
            {
                this.Arabalar.Remove(a);
            }
        }

        public void SahteVeriGir()
        {
            // Oluşturduğumuz Arabaekle metodu ile manuel bilgi girerek sahteveri oluştururuz.

            ArabaEkle("34ARB3434", "FIAT", 70, "Sedan");
            ArabaEkle("35ARB3535", "KIA", 60, "SUV");
            ArabaEkle("34US2342", "OPEL", 50, "Hatchback");

        }

    }
}
