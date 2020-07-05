using InstaBot.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.Codes
{
    class KullaniciSecimleri
    {
        private KullaniciSecimleri() { }
        private static KullaniciSecimleri _instance;
        public static KullaniciSecimleri GetInstance()
        {
            if (_instance == null)
            {
                _instance = new KullaniciSecimleri();
            }
            return _instance;
        }
        public Begen Begen = new Begen();

        public YorumYap YorumYap = new YorumYap();

        public TakipEt TakipEt = new TakipEt();

        public TakiptenCik TakiptenCik = new TakiptenCik();

        public TakipKontrol TakipKontrol = new TakipKontrol();

        public ResimAl ResimAl = new ResimAl();

        public ResimPaylas ResimPaylas = new ResimPaylas();

        public GirisBilgileri GirisBilgileri = new GirisBilgileri();
    }
}
