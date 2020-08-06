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
            KullaniciHashtagYorumAl();
            IstekAtilanHesaplar();
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
        KullaniciSecimleri Secimler = KullaniciSecimleri.GetInstance();

        SQLiteConnection Baglan = new SQLiteConnection("Data Source=Database.db;Password=Database5441");
        SQLiteCommand Sorgu;

        public void KullaniciHashtagYorumAl()
        {
            Secimler.ListHashtags.Clear();
            Secimler.ListKullaniciAdi.Clear();
            Secimler.ListYorumlar.Clear();

            Sorgu = Baglan.CreateCommand();
            Sorgu.CommandText = "SELECT * FROM tbl_Hashtag order by id ASC";
            Baglan.Open();
            using (var veriler = Sorgu.ExecuteReader())
            {
                while (veriler.Read())
                {
                    //"Contains()" listenin içinde o değer var mı yok mu kontrol eder bizim kullanım amacımız farklı grupları ayırt edip grup adlarını alıp kullanıcıya sunmak
                    //böylelikle seçtiği gruba dahil olan değerleri bir döngü ile ala bilmek
                    if (!Secimler.HashtagGrup.Contains(veriler["grupAdi"].ToString())) 
                    {
                        Secimler.HashtagGrup.Add(veriler["grupAdi"].ToString());
                    }
                    Secimler.ListHashtags.Add(new ListHashtag()
                    {
                        id = veriler["id"].ToString(),
                        hashtag = veriler["hashtag"].ToString(),
                        grupAdi = veriler["grupAdi"].ToString()
                    });
                }
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Hashtag

            Sorgu.CommandText = "SELECT * FROM tbl_KullaniciAdi order by id ASC";
            using (var veriler = Sorgu.ExecuteReader())
            {
                while (veriler.Read())
                {
                    //"Contains()" listenin içinde o değer var mı yok mu kontrol eder bizim kullanım amacımız farklı grupları ayırt edip grup adlarını alıp kullanıcıya sunmak
                    //böylelikle seçtiği gruba dahil olan değerleri bir döngü ile ala bilmek
                    if (!Secimler.KullaniciAdiGrup.Contains(veriler["grupAdi"].ToString()))
                    {
                        Secimler.KullaniciAdiGrup.Add(veriler["grupAdi"].ToString());
                    }
                    Secimler.ListKullaniciAdi.Add(new ListKullaniciAdi()
                    {
                        id = veriler["id"].ToString(),
                        kullaniciAdi = veriler["kullaniciAdi"].ToString(),
                        grupAdi = veriler["grupAdi"].ToString()
                    });
                }
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Kullanici Adları

            Sorgu.CommandText = "SELECT * FROM tbl_Yorumlar order by id ASC";
            using (var veriler = Sorgu.ExecuteReader())
            {
                while (veriler.Read())
                {
                    //"Contains()" listenin içinde o değer var mı yok mu kontrol eder bizim kullanım amacımız farklı grupları ayırt edip grup adlarını alıp kullanıcıya sunmak
                    //böylelikle seçtiği gruba dahil olan değerleri bir döngü ile ala bilmek
                    if (!Secimler.YorumGrubu.Contains(veriler["grupAdi"].ToString()))
                    {
                        Secimler.YorumGrubu.Add(veriler["grupAdi"].ToString());
                    }
                    Secimler.ListYorumlar.Add(new ListYorumlar()
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

        public void KullaniciHashtagYorumEkle(string nereye,string grupAdi,string eklenen) //Kullanici Hashtag grubunun içindeki yeni veri ekleme kısmı
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
            else if (nereye == "tbl_Yorumlar")
            {
                Sorgu.CommandText = "INSERT INTO tbl_Yorumlar(yorum,grupAdi) VALUES(@eklenen,@grupAdi)";
            }

            Sorgu.Parameters.AddWithValue("@eklenen", eklenen);
            Sorgu.Parameters.AddWithValue("@grupAdi", grupAdi);

            Sorgu.ExecuteNonQuery();

            Baglan.Close();
            Sorgu.Dispose();

            KullaniciHashtagYorumAl();// YEni Bir değer eklenince ListHashtag ve ListKullanici Adi Classları tekrardan doldurulsun diye
        }

        public void GrupAdlariniGuncelle(string nereye, string eskiAd, string yeniAd)
        {
            Sorgu = Baglan.CreateCommand();
            Baglan.Open();
            if (nereye == "tbl_Hashtag")
            {
                Sorgu.CommandText = "UPDATE tbl_Hashtag set grupAdi=@yeniAd WHERE grupAdi=@eskiAd";
            }
            else if (nereye == "tbl_KullaniciAdi")
            {
                Sorgu.CommandText = "UPDATE tbl_KullaniciAdi set grupAdi=@yeniAd WHERE grupAdi=@eskiAd";
            }
            else if (nereye == "tbl_Yorumlar")
            {
                Sorgu.CommandText = "UPDATE tbl_Yorumlar set grupAdi=@yeniAd WHERE grupAdi=@eskiAd";
            }

            Sorgu.Parameters.AddWithValue("@yeniAd", yeniAd);
            Sorgu.Parameters.AddWithValue("@eskiAd", eskiAd);

            Sorgu.ExecuteNonQuery();

            Baglan.Close();
            Sorgu.Dispose();

        } //Grup adlarını Güncelleme
        public void YorumHashtagKullaniciGuncelle(string nereye, string id, string yeniVeri)
        {
            Sorgu = Baglan.CreateCommand();
            Baglan.Open();
            if (nereye == "tbl_Hashtag")
            {
                Sorgu.CommandText = "UPDATE tbl_Hashtag set hashtag=@yeniVeri WHERE id=@id";
            }
            else if (nereye == "tbl_KullaniciAdi")
            {
                Sorgu.CommandText = "UPDATE tbl_KullaniciAdi set kullaniciAdi=@yeniVeri WHERE id=@id";
            }
            else if (nereye == "tbl_Yorumlar")
            {
                Sorgu.CommandText = "UPDATE tbl_Yorumlar set yorum=@yeniVeri WHERE id=@id";
            }

            Sorgu.Parameters.AddWithValue("@id", id);
            Sorgu.Parameters.AddWithValue("@yeniVeri", yeniVeri);

            Sorgu.ExecuteNonQuery();

            Baglan.Close();
            Sorgu.Dispose();

        } //Yorum Hashtag Kullanıcı Güncelleme
        public void GruplarıSil(string nerenin, string grupAdi)
        {
            Sorgu = Baglan.CreateCommand();
            Baglan.Open();
            if (nerenin == "tbl_Hashtag")
            {
                Sorgu.CommandText = "DELETE FROM tbl_Hashtag WHERE grupAdi=@grupAdi";
            }
            else if (nerenin == "tbl_KullaniciAdi")
            {
                Sorgu.CommandText = "DELETE FROM tbl_KullaniciAdi WHERE grupAdi=@grupAdi";
            }
            else if (nerenin == "tbl_Yorumlar")
            {
                Sorgu.CommandText = "DELETE FROM tbl_Yorumlar WHERE grupAdi=@grupAdi";
            }

            Sorgu.Parameters.AddWithValue("@grupAdi", grupAdi);

            Sorgu.ExecuteNonQuery();

            Baglan.Close();
            Sorgu.Dispose();

        } //Grupları silme
        public void KullaniciHashtagYorumSil(string nerenin, string id)
        {
            Sorgu = Baglan.CreateCommand();
            Baglan.Open();
            if (nerenin == "tbl_Hashtag")
            {
                Sorgu.CommandText = "DELETE FROM tbl_Hashtag WHERE id=@id";
            }
            else if (nerenin == "tbl_KullaniciAdi")
            {
                Sorgu.CommandText = "DELETE FROM tbl_KullaniciAdi WHERE id=@id";
            }
            else if (nerenin == "tbl_Yorumlar")
            {
                Sorgu.CommandText = "DELETE FROM tbl_Yorumlar WHERE id=@id";
            }

            Sorgu.Parameters.AddWithValue("@id", id);

            Sorgu.ExecuteNonQuery();

            Baglan.Close();
            Sorgu.Dispose();
        }

        public void TakipEdilenKaydet() //ListTakipBilgisi takip edilen hesapların linki ve gizli mi onun bilgisini aktarılmasına yardımcı olan class
        {
            if (VeriHavuzu.TakipEdilenHesaplar.Count>0)
            {
                Sorgu = Baglan.CreateCommand();
                Baglan.Open();
                Sorgu.CommandText = "INSERT INTO tbl_TakipAtilan(hesapAdi,hesapLinki,hesap,tarih,kimAtti) VALUES(@hesapAdi,@hesapLinki,@hesap,date(),@kimAtti)";
                foreach (var item in VeriHavuzu.TakipEdilenHesaplar)
                {
                    Sorgu.Parameters.AddWithValue("@hesapAdi", item.hesapAdi);
                    Sorgu.Parameters.AddWithValue("@hesapLinki", item.hesapLinki);
                    Sorgu.Parameters.AddWithValue("@hesap", item.hesap);
                    Sorgu.Parameters.AddWithValue("@kimAtti", Secimler.GirisBilgileri.kullaniciAdi);
                    Sorgu.ExecuteNonQuery();
                }
                Baglan.Close();
                Sorgu.Dispose();

                VeriHavuzu.TakipEdilenHesaplar.Clear();
            }
            
        }

        public void IstekAtilanHesaplar() // İstek atılan hesapların veri tabanından bilgilerinin alındığı yer 
        {
            Sorgu = Baglan.CreateCommand();
            Sorgu.CommandText = "SELECT * FROM tbl_TakipAtilan WHERE kimAtti=@kimAtti and tarih<date()"; // "tarih<date()" kaydedilen tarih eğer bugün değilse
            Sorgu.Parameters.AddWithValue("@kimAtti", Secimler.GirisBilgileri.kullaniciAdi);
            Baglan.Open();
            using (var veriler = Sorgu.ExecuteReader())
            {
                while (veriler.Read())
                {
                    VeriHavuzu.IstekAtilanHesaplar.Add(new ListIstekBilgi()
                    {
                        id = veriler["id"].ToString(),
                        hesapAdi = veriler["hesapAdi"].ToString(),
                        hesapLinki = veriler["hesapLinki"].ToString(),
                        hesap = veriler["hesap"].ToString(),
                    }) ;
                }
            }

            Baglan.Close();
            Sorgu.Dispose();

            Secimler.IstekKontrol.IstekSayisi = VeriHavuzu.IstekAtilanHesaplar.Count; // Veritabanında kaçtane istek atılan hesap bilgisi varsa kulanıcıya sayısını göstermek için
        }

        public void IstekleriSil() // İstek atılan hesapları kabul etmişmi ontrol edip siliyoruz
        {
            if (VeriHavuzu.SilinecekIstekIdler.Count > 0)
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
            
        }

        public void ResimVideoLinkiKaydet() // hashtagten/profilden alınan resimleri bilgilerini veritabanına kaydediyoruz
        {
            if (VeriHavuzu.AlinanResimVidoe.Count>0)
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
                    Sorgu.Parameters.AddWithValue("@kimAldi", Secimler.GirisBilgileri.kullaniciAdi);
                    Sorgu.ExecuteNonQuery();
                }
                Baglan.Close();
                Sorgu.Dispose();

                VeriHavuzu.AlinanResimVidoe.Clear();
            }
            
        }
    }
}

