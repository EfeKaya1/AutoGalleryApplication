using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasi
{
    internal class Araba
    {
        // Bu sınıfta araba ile ilgili özellik ve işlemler olmalı

        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public string AracTipi { get; set; }
        public string Durum { get; set; }

        public List<int> KiralamaSureleri = new List<int>();


        public Araba(string plaka, string marka, float kiralamaBedeli, string aractipi)
        {
            // parametreli bir constructor oluşturarak yeni bir araba nesnesi oluşması sağlanır.
            this.Plaka = plaka;
            this.Plaka = plaka;
            this.Marka = marka;
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aractipi;
            this.Durum = "Galeride";
        }


        public int KiralanmaSayisi
        {
            get
            {
                return this.KiralamaSureleri.Count;
            }
        }

        public int ToplamKiralanmaSuresi
        {
            get
            {
                return this.KiralamaSureleri.Sum();
            }
        }




    }
}
