using InstaBot.BaseClass;
using InstaBot.Kullanicidan.BaseClass;
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

        //Kullanıcının Seçtiği ayarlarının saklandığı yer
        public Begen Begen = new Begen(); 

        public YorumYap YorumYap = new YorumYap();

        public TakipEt TakipEt = new TakipEt();

        public TakiptenCik TakiptenCik = new TakiptenCik();

        public IstekKontrol IstekKontrol = new IstekKontrol();

        public ResimAl ResimAl = new ResimAl();

        public ResimPaylas ResimPaylas = new ResimPaylas();

        public Sureler Sureler = new Sureler();

        public GirisBilgileri GirisBilgileri = new GirisBilgileri();

        public List<ListHashtag> ListHashtags = new List<ListHashtag>(); // Kullanıcının kaydettiği hasahtaglerin bilgisi

        public List<string> HashtagGrup = new List<string>(); //Hashtagler de kaç farklı grup varsa onların tutulduğu yer

        public List<string> KullaniciAdigGrup = new List<string>(); //Kullanici Adi kısmında kaç farklı grup varsa onları isimleri

        public List<ListKullaniciAdi> ListKullaniciAdi = new List<ListKullaniciAdi>(); // Kayıtlı Kullanici adları

        public List<string> GidilecekYer = new List<string>(); // Kullanıcı adları veya hashtagleri hangilerine gidilecekse onları saklandığı yer

        public List<ListYorumlar> ListYorumlar = new List<ListYorumlar>(); // Yapılacak Yorumları veritabanından alıp sakladığımı yer

        public List<string> YorumGrubu = new List<string>(); // Yapılacak yorumların farklı olan grubların sadece adını saklandığı yer sonra grup ayrımı yapa bilmek için

        public List<string> YapilacakYorumlar = new List<string>(); // Yapılacak yorumların farklı olan grubların sadece adını saklandığı yer sonra grup ayrımı yapa bilmek için


    }
}
