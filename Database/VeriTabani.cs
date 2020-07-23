using InstaBot.BaseClass;
using InstaBot.Codes;
using InstaBot.Kullanicidan.BaseClass;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq.Expressions;

namespace InstaBot.Database
{
    class VeriTabani
    {
        private VeriTabani() 
        { 
            GerekliVerileriAl(); 
        }

        private static VeriTabani _instance;

        public static VeriTabani GetInstance()
        {
            if (_instance == null)
            {
                _instance = new VeriTabani();
                
            }
            return _instance;
        }


        VeriHavuzu VeriHavuzu = VeriHavuzu.GetInstance();
        KullaniciSecimleri KullaniciSecimleri = KullaniciSecimleri.GetInstance();

        SQLiteConnection Baglan = new SQLiteConnection("Data Source=Database.db;Password=Database5441");
        SQLiteCommand Sorgu;

        public void GerekliVerileriAl()
        {
            Sorgu = Baglan.CreateCommand();
            Sorgu.CommandText = "SELECT * FROM tbl_Hashtag order by grupAdi ASC";
            Baglan.Open();
            using (var veriler = Sorgu.ExecuteReader())
            {
                while (veriler.Read())
                {
                    //"Contains()" listenin içinde o değer var mı yok mu kontrol eder bizim kullanım amacımız farklı grupları ayırt edip grup adlarını alıp kullanıcıya sunmak
                    //böylelikle seçtiği gruba dahil olan değerleri bir döngü ile ala bilmek
                    if (!KullaniciSecimleri.HashtagGrup.Contains(veriler["grupAdi"].ToString())) 
                    {
                        KullaniciSecimleri.HashtagGrup.Add(veriler["grupAdi"].ToString());
                    }
                    KullaniciSecimleri.ListHashtags.Add(new ListHashtag()
                    {
                        id = veriler["id"].ToString(),
                        hashtag = veriler["hashtag"].ToString(),
                        grupAdi = veriler["grupAdi"].ToString()
                    });
                }
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Hashtag

            Sorgu.CommandText = "SELECT * FROM tbl_KullaniciAdi order by grupAdi ASC";
            using (var veriler = Sorgu.ExecuteReader())
            {
                while (veriler.Read())
                {
                    //"Contains()" listenin içinde o değer var mı yok mu kontrol eder bizim kullanım amacımız farklı grupları ayırt edip grup adlarını alıp kullanıcıya sunmak
                    //böylelikle seçtiği gruba dahil olan değerleri bir döngü ile ala bilmek
                    if (!KullaniciSecimleri.KullaniciAdigGrup.Contains(veriler["grupAdi"].ToString()))
                    {
                        KullaniciSecimleri.KullaniciAdigGrup.Add(veriler["grupAdi"].ToString());
                    }
                    KullaniciSecimleri.ListKullaniciAdi.Add(new ListKullaniciAdi()
                    {
                        id = veriler["id"].ToString(),
                        kullaniciAdi = veriler["kullaniciAdi"].ToString(),
                        grupAdi = veriler["grupAdi"].ToString()
                    });
                }
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Kullanici Adları

            Sorgu.CommandText = "SELECT * FROM tbl_Yorumlar order by grupAdi ASC";
            using (var veriler = Sorgu.ExecuteReader())
            {
                while (veriler.Read())
                {
                    //"Contains()" listenin içinde o değer var mı yok mu kontrol eder bizim kullanım amacımız farklı grupları ayırt edip grup adlarını alıp kullanıcıya sunmak
                    //böylelikle seçtiği gruba dahil olan değerleri bir döngü ile ala bilmek
                    if (!KullaniciSecimleri.YorumGrubu.Contains(veriler["grupAdi"].ToString()))
                    {
                        KullaniciSecimleri.YorumGrubu.Add(veriler["grupAdi"].ToString());
                    }
                    KullaniciSecimleri.ListYorumlar.Add(new ListYorumlar()
                    {
                        id = veriler["id"].ToString(),
                        yorum = veriler["yorum"].ToString(),
                        grupAdi = veriler["grupAdi"].ToString()
                    });
                }
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Yapılacak Yorumlar
            Baglan.Close();
            Sorgu.Dispose();
        }

        public void KullaniciHashtagEkle(string nereye,string grupAdi,string eklenen) //Kullanici Hashtag grubunun içindeki yeni veri ekleme kısmı
        {
            Sorgu = Baglan.CreateCommand();
            Baglan.Open();
            if (nereye== "tbl_Hashtag")
            {
                Sorgu.CommandText = "INSERT INTO tbl_Hashtag(hashtag,grupAdi) VALUES(@eklenen,@grupAdi)";
            }
            else if (nereye == "tbl_KullaniciAdi")
            {
                Sorgu.CommandText = "INSERT INTO tbl_KullaniciAdi(kullaniciAdi,grupAdi) VALUES(@eklenen,@grupAdi)";
            }

            Sorgu.Parameters.AddWithValue("@eklenen", eklenen);
            Sorgu.Parameters.AddWithValue("@grupAdi", grupAdi);

            Sorgu.ExecuteNonQuery();

            Baglan.Close();
            Sorgu.Dispose();
        }

        public void TakipEdilenKaydet() //ListTakipBilgisi takip edilen hesapların linki ve gizli mi onun bilgisini aktarılmasına yardımcı olan class
        {
            Sorgu = Baglan.CreateCommand();
            Baglan.Open();
            Sorgu.CommandText = "INSERT INTO tbl_TakipAtilan(hesap,hesapBilgisi,kimAtti) VALUES(@hesap,@hesapBilgisi,@kimAtti)";
            foreach (var item in VeriHavuzu.TakipEdilenHesaplar)
            {
                Sorgu.Parameters.AddWithValue("@hesap", item.hesap);
                Sorgu.Parameters.AddWithValue("@hesapBilgisi", item.hesapBilgisi);
                Sorgu.Parameters.AddWithValue("@kimAtti", KullaniciSecimleri.GirisBilgileri.kullaniciAdi);
                Sorgu.ExecuteNonQuery();
            }
            Baglan.Close();
            Sorgu.Dispose();

            VeriHavuzu.TakipEdilenHesaplar.Clear();
        }

        public void IstekAtilanHesaplar() // İstek atılan hesapların veri tabanından bilgilerinin alındığı yer 
        {
            Sorgu = Baglan.CreateCommand();
            Sorgu.CommandText = "SELECT * FROM tbl_TakipAtilan WHERE kimAtti=@kimAtti";
            Sorgu.Parameters.AddWithValue("@kimAtti", KullaniciSecimleri.GirisBilgileri.kullaniciAdi);
            Baglan.Open();
            using (var veriler = Sorgu.ExecuteReader())
            {
                while (veriler.Read())
                {
                    VeriHavuzu.IstekAtilanHesaplar.Add(new ListIstekBilgi()
                    {
                        id = veriler["id"].ToString(),
                        hesap = veriler["hesap"].ToString(),
                        hesapBilgisi = veriler["hesapBilgisi"].ToString()
                    });
                }
            }

            Baglan.Close();
            Sorgu.Dispose();
        }

        public void IstekleriSil() // İstek atılan hesapları kabul etmişmi ontrol edip siliyoruz
        {
            Sorgu = Baglan.CreateCommand();
            Sorgu.CommandText = "DELETE FROM tbl_TakipAtilan WHERE id=@id";
            Baglan.Open();

            foreach (var item in VeriHavuzu.SilinecekIstekIdler)
            {
                Sorgu.Parameters.AddWithValue("@id", item);
                Sorgu.ExecuteNonQuery();
            }
            Baglan.Close();
            Sorgu.Dispose();

            VeriHavuzu.SilinecekIstekIdler.Clear();
        }

        public void ResimVideoLinkiKaydet() // hashtagten/profilden alınan resimleri bilgilerini veritabanına kaydediyoruz
        {
            Sorgu = Baglan.CreateCommand();
            Baglan.Open();
            Sorgu.CommandText = "INSERT INTO tbl_ResimVideoLink(link,aciklama,tur,paylasan,anaLink,kimAldi) VALUES(@link,@aciklama,@tur,@paylasan,@anaLink,@kimAldi)";
            foreach (var item in VeriHavuzu.AlinanResimVidoe)
            {
                Sorgu.Parameters.AddWithValue("@link", item.link);
                Sorgu.Parameters.AddWithValue("@aciklama", item.aciklama);
                Sorgu.Parameters.AddWithValue("@tur", item.tur); 
                Sorgu.Parameters.AddWithValue("@paylasan", item.paylasan);
                Sorgu.Parameters.AddWithValue("@anaLink", item.anaLink);
                Sorgu.Parameters.AddWithValue("@kimAldi", KullaniciSecimleri.GirisBilgileri.kullaniciAdi);
                Sorgu.ExecuteNonQuery();
            }
            Baglan.Close();
            Sorgu.Dispose();
            VeriHavuzu.AlinanResimVidoe.Clear();
        }
    }
}

