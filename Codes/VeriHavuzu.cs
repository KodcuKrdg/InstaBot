using InstaBot.Codes.BaseVeriHavuzu;
using InstaBot.Database;
using System.Collections.Generic;

namespace InstaBot.BaseClass
{
    class VeriHavuzu
    {
        private VeriHavuzu() { }
        private static VeriHavuzu _instance;

        public static VeriHavuzu GetInstance()
        {
            if (_instance == null)
            {
                _instance = new VeriHavuzu();
            }
            return _instance;
        }

        public List<string> TakipEdilecekler = new List<string>(); // Göndericeki yorum yapanların linklerinin tutulduğu yer

        public List<ListTakipBilgi> TakipEdilenHesaplar = new List<ListTakipBilgi>(); //Takip isteği atılan hesapların veritabanına aktarılamdan önce tutulduğu yer

        public List<ListIstekBilgi> IstekAtilanHesaplar = new List<ListIstekBilgi>(); // Veritabanından takip isteği atılan hesapların bilgisinin sakladığı yer

        public List<string> SilinecekIstekIdler = new List<string>(); //İstekleri kontrol edildikten sonra silinecek verilerin idlerinin saklandığı yer

        public List<ListAlinanResimVideo> AlinanResimVidoe = new List<ListAlinanResimVideo>(); // hashtaglerden/profilden alınan resimlerin linki kullanıcının kontrol etmeden önceki gerekli bilgiler

        public List<string> PaylasimLinki = new List<string>(); // Gonderilerin linklerini saklandığı yer
    }
}
