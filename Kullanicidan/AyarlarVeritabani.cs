using InstaBot.Codes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.Kullanicidan
{
    class AyarlarVeritabani
    {
        private AyarlarVeritabani()
        {
            VerileriAl();
        }

        private static AyarlarVeritabani _instance;

        public static AyarlarVeritabani GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AyarlarVeritabani();

            }
            return _instance;
        }

        KullaniciSecimleri KullaniciSecimleri = KullaniciSecimleri.GetInstance();

        SQLiteConnection Baglan = new SQLiteConnection("Data Source=KullaniciAyarlari.db;Password=kullaniciayarlari5441");
        SQLiteCommand Sorgu;

        private void VerileriAl()
        {
            Sorgu = Baglan.CreateCommand();
            Sorgu.CommandText = "SELECT * FROM tbl_Begen,tbl_GirisBilgileri,tbl_ResimAl,tbl_ResimPaylas,tbl_TakipEt,tbl_TakipKontrol,tbl_TakiptenCik,tbl_YorumYap,tbl_Sureler";
            Baglan.Open();
            using (var veriler = Sorgu.ExecuteReader())
            {
                while (veriler.Read())
                {
                    KullaniciSecimleri.Begen.begenecekMi = Convert.ToBoolean(veriler["begenecekMi"]);
                    KullaniciSecimleri.Begen.anaSayfaBegen = Convert.ToBoolean(veriler["anaSayfaBegen"]);
                    KullaniciSecimleri.Begen.begeniSayisi = Convert.ToInt32(veriler["begeniSayisi"]);
                    KullaniciSecimleri.Begen.yapilanBegeniSayisi = veriler["yapilanBegeniSayisi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Beğeni
                    KullaniciSecimleri.GirisBilgileri.kullaniciAdi = veriler["kullaniciAdi"].ToString();
                    KullaniciSecimleri.GirisBilgileri.sifre = veriler["sifre"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Giris Bilgileri
                    KullaniciSecimleri.ResimAl.resimAlsinMi = Convert.ToBoolean(veriler["resimAlsinMi"]);
                    KullaniciSecimleri.ResimAl.resimSayisi = Convert.ToInt32(veriler["resimSayisi"]);
                    KullaniciSecimleri.ResimAl.alinanResimSayisi = veriler["alinanResimSayisi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Al
                    KullaniciSecimleri.ResimPaylas.resimPaylasacakMi = Convert.ToBoolean(veriler["resimPaylasacakMi"]);
                    KullaniciSecimleri.ResimPaylas.resimGrubu = veriler["resimGrubu"].ToString();
                    KullaniciSecimleri.ResimPaylas.paylasimSayisi = Convert.ToInt32(veriler["paylasimSayisi"]);
                    KullaniciSecimleri.ResimPaylas.yapilanPySayisi = veriler["yapilanPySayisi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Paylaş
                    KullaniciSecimleri.TakipEt.takipEdicekMi = Convert.ToBoolean(veriler["takipEdicekMi"]);
                    KullaniciSecimleri.TakipEt.yorumlardanTkpEt = Convert.ToBoolean(veriler["yorumlardanTkpEt"]);
                    KullaniciSecimleri.TakipEt.takipEttiklerindenTkpEt = Convert.ToBoolean(veriler["takipEttiklerindenTkpEt"]);
                    KullaniciSecimleri.TakipEt.takipcilerdenTkpEt = Convert.ToBoolean(veriler["takipcilerdenTkpEt"]);
                    KullaniciSecimleri.TakipEt.acikHesaplariTkpEtme = Convert.ToBoolean(veriler["acikHesaplariTkpEtme"]);
                    KullaniciSecimleri.TakipEt.takipEtmeSayisi = Convert.ToInt32(veriler["takipEtmeSayisi"]);
                    KullaniciSecimleri.TakipEt.takipEdilenSayi = veriler["takipEdilenSayi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Et
                    KullaniciSecimleri.TakipKontrol.takipKontrolEdilsinMi = Convert.ToBoolean(veriler["takipKontrolEdilsinMi"]);
                    KullaniciSecimleri.TakipKontrol.acikHesap = Convert.ToBoolean(veriler["acikHesap"]);
                    KullaniciSecimleri.TakipKontrol.gizliHesap = Convert.ToBoolean(veriler["gizliHesap"]);
                    KullaniciSecimleri.TakipKontrol.gonderiBegen = Convert.ToBoolean(veriler["gonderiBegen"]);
                    KullaniciSecimleri.TakipKontrol.kontrolSayisi = veriler["kontrolSayisi"].ToString();
                    KullaniciSecimleri.TakipKontrol.begenilecekSayi = Convert.ToInt32(veriler["begenilecekSayi"]);
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip İstekleri Kontrol
                    KullaniciSecimleri.TakiptenCik.takiptenCikacakMi = Convert.ToBoolean(veriler["takiptenCikacakMi"]);
                    KullaniciSecimleri.TakiptenCik.takiptenCikmaSayisi = Convert.ToInt32(veriler["takiptenCikmaSayisi"]);
                    KullaniciSecimleri.TakiptenCik.takiptenCikarilanSayi = veriler["takiptenCikarilanSayi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takipten Çıkma
                    KullaniciSecimleri.YorumYap.yorumYapacakMi = Convert.ToBoolean(veriler["yorumYapacakMi"]);
                    KullaniciSecimleri.YorumYap.rasgeleHarfEkle = Convert.ToBoolean(veriler["rasgeleHarfEkle"]);
                    KullaniciSecimleri.YorumYap.yorumSayisi = Convert.ToInt32(veriler["yorumSayisi"]);
                    KullaniciSecimleri.YorumYap.yorumGrubu = veriler["yorumGrubu"].ToString();
                    KullaniciSecimleri.YorumYap.yapilanYorumSayisi = veriler["yapilanYorumSayisi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Yorum Yap
                    KullaniciSecimleri.Sureler.minBegen = Convert.ToInt32(veriler["minBegen"]);
                    KullaniciSecimleri.Sureler.minYorum = Convert.ToInt32(veriler["minYorum"]);
                    KullaniciSecimleri.Sureler.minTakipEtCik = Convert.ToInt32(veriler["minTakipEtCik"]);
                    KullaniciSecimleri.Sureler.minResimPay = Convert.ToInt32(veriler["minResimPay"]);
                    KullaniciSecimleri.Sureler.maxBegen = Convert.ToInt32(veriler["maxBegen"]); 
                    KullaniciSecimleri.Sureler.maxYorum = Convert.ToInt32(veriler["maxYorum"]); 
                    KullaniciSecimleri.Sureler.maxTakipEtCik = Convert.ToInt32(veriler["maxTakipEtCik"]);
                    KullaniciSecimleri.Sureler.maxResimPay = Convert.ToInt32(veriler["maxResimPay"]);
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Bekleme Sureleri
                }
            }

            Baglan.Close();
            Sorgu.Dispose();
        } // Kulanıcının enson işlem yaptığı ayarları veritabanından aldık

        public void AyarlarıKaydet()
        {
            Sorgu = Baglan.CreateCommand();
            Baglan.Open();

            Sorgu.CommandText = "UPDATE tbl_Begen SET begenecekMi=@begenecekMi,anaSayfaBegen=@anaSayfaBegen,begeniSayisi=@begeniSayisi";

            Sorgu.Parameters.AddWithValue("@begenecekMi", KullaniciSecimleri.Begen.begenecekMi.ToString()) ;
            Sorgu.Parameters.AddWithValue("@anaSayfaBegen", KullaniciSecimleri.Begen.anaSayfaBegen.ToString());
            Sorgu.Parameters.AddWithValue("@begeniSayisi", KullaniciSecimleri.Begen.begeniSayisi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Beğeni

            Sorgu.CommandText = "UPDATE tbl_GirisBilgileri SET kullaniciAdi=@kullaniciAdi,sifre=@sifre";

            Sorgu.Parameters.AddWithValue("@kullaniciAdi", KullaniciSecimleri.GirisBilgileri.kullaniciAdi.ToString());
            Sorgu.Parameters.AddWithValue("@sifre", KullaniciSecimleri.GirisBilgileri.sifre.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Giris Bilgileri

            Sorgu.CommandText = "UPDATE tbl_ResimAl SET resimAlsinMi=@resimAlsinMi,resimSayisi=@resimSayisi";

            Sorgu.Parameters.AddWithValue("@resimAlsinMi", KullaniciSecimleri.ResimAl.resimAlsinMi.ToString());
            Sorgu.Parameters.AddWithValue("@resimSayisi", KullaniciSecimleri.ResimAl.resimSayisi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Al
            //
            Sorgu.CommandText = "UPDATE tbl_ResimPaylas SET resimPaylasacakMi=@resimPaylasacakMi,resimGrubu=@resimGrubu,paylasimSayisi=@paylasimSayisi";

            Sorgu.Parameters.AddWithValue("@resimPaylasacakMi", KullaniciSecimleri.ResimPaylas.resimPaylasacakMi.ToString());
            Sorgu.Parameters.AddWithValue("@resimGrubu", KullaniciSecimleri.ResimPaylas.resimGrubu.ToString());
            Sorgu.Parameters.AddWithValue("@paylasimSayisi", KullaniciSecimleri.ResimPaylas.paylasimSayisi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Paylaş

            Sorgu.CommandText = "UPDATE tbl_TakipEt SET takipEdicekMi=@takipEdicekMi,yorumlardanTkpEt=@yorumlardanTkpEt,takipEttiklerindenTkpEt=@takipEttiklerindenTkpEt,takipcilerdenTkpEt=@takipcilerdenTkpEt,acikHesaplariTkpEtme=@acikHesaplariTkpEtme,takipEtmeSayisi=@takipEtmeSayisi";

            Sorgu.Parameters.AddWithValue("@takipEdicekMi", KullaniciSecimleri.TakipEt.takipEdicekMi.ToString());
            Sorgu.Parameters.AddWithValue("@yorumlardanTkpEt", KullaniciSecimleri.TakipEt.yorumlardanTkpEt.ToString());
            Sorgu.Parameters.AddWithValue("@takipEttiklerindenTkpEt", KullaniciSecimleri.TakipEt.takipEttiklerindenTkpEt.ToString());
            Sorgu.Parameters.AddWithValue("@takipcilerdenTkpEt", KullaniciSecimleri.TakipEt.takipcilerdenTkpEt.ToString());
            Sorgu.Parameters.AddWithValue("@acikHesaplariTkpEtme", KullaniciSecimleri.TakipEt.acikHesaplariTkpEtme.ToString());
            Sorgu.Parameters.AddWithValue("@takipEtmeSayisi", KullaniciSecimleri.TakipEt.takipEtmeSayisi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Et

            Sorgu.CommandText = "UPDATE tbl_TakipKontrol SET takipKontrolEdilsinMi=@takipKontrolEdilsinMi,acikHesap=@acikHesap,gizliHesap=@gizliHesap,gonderiBegen=@gonderiBegen,kontrolSayisi=@kontrolSayisi,begenilecekSayi=@begenilecekSayi";

            Sorgu.Parameters.AddWithValue("@takipKontrolEdilsinMi", KullaniciSecimleri.TakipKontrol.takipKontrolEdilsinMi.ToString());
            Sorgu.Parameters.AddWithValue("@acikHesap", KullaniciSecimleri.TakipKontrol.acikHesap.ToString());
            Sorgu.Parameters.AddWithValue("@gizliHesap", KullaniciSecimleri.TakipKontrol.gizliHesap.ToString());
            Sorgu.Parameters.AddWithValue("@gonderiBegen", KullaniciSecimleri.TakipKontrol.gonderiBegen.ToString());
            Sorgu.Parameters.AddWithValue("@kontrolSayisi", KullaniciSecimleri.TakipKontrol.kontrolSayisi.ToString());
            Sorgu.Parameters.AddWithValue("@begenilecekSayi", KullaniciSecimleri.TakipKontrol.begenilecekSayi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip İstekleri Kontrol

            Sorgu.CommandText = "UPDATE tbl_TakiptenCik SET takiptenCikacakMi=@takiptenCikacakMi,takiptenCikmaSayisi=@takiptenCikmaSayisi";

            Sorgu.Parameters.AddWithValue("@takiptenCikacakMi", KullaniciSecimleri.TakiptenCik.takiptenCikacakMi.ToString());
            Sorgu.Parameters.AddWithValue("@takiptenCikmaSayisi", KullaniciSecimleri.TakiptenCik.takiptenCikmaSayisi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takipten Çıkma
            
            Sorgu.CommandText = "UPDATE tbl_YorumYap SET yorumYapacakMi=@yorumYapacakMi,rasgeleHarfEkle=@rasgeleHarfEkle,yorumSayisi=@yorumSayisi,yorumGrubu=@yorumGrubu";

            Sorgu.Parameters.AddWithValue("@yorumYapacakMi", KullaniciSecimleri.YorumYap.yorumYapacakMi.ToString());
            Sorgu.Parameters.AddWithValue("@rasgeleHarfEkle", KullaniciSecimleri.YorumYap.rasgeleHarfEkle.ToString());
            Sorgu.Parameters.AddWithValue("@yorumSayisi", KullaniciSecimleri.YorumYap.yorumSayisi.ToString());
            Sorgu.Parameters.AddWithValue("@yorumGrubu", KullaniciSecimleri.YorumYap.yorumGrubu.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Yorum Yap

            Sorgu.CommandText = "UPDATE tbl_Sureler SET minBegen=@minBegen,minYorum=@minYorum,minTakipEtCik=@minTakipEtCik,minResimPay=@minResimPay,maxBegen=@maxBegen,maxYorum=@maxYorum,maxTakipEtCik=@maxTakipEtCik,maxResimPay=@maxResimPay";

            Sorgu.Parameters.AddWithValue("@minBegen", KullaniciSecimleri.Sureler.minBegen.ToString());
            Sorgu.Parameters.AddWithValue("@minYorum", KullaniciSecimleri.Sureler.minYorum.ToString());
            Sorgu.Parameters.AddWithValue("@minTakipEtCik", KullaniciSecimleri.Sureler.minTakipEtCik.ToString());
            Sorgu.Parameters.AddWithValue("@minResimPay", KullaniciSecimleri.Sureler.minResimPay.ToString());
            Sorgu.Parameters.AddWithValue("@maxBegen", KullaniciSecimleri.Sureler.maxBegen.ToString());
            Sorgu.Parameters.AddWithValue("@maxYorum", KullaniciSecimleri.Sureler.maxYorum.ToString());
            Sorgu.Parameters.AddWithValue("@maxTakipEtCik", KullaniciSecimleri.Sureler.maxTakipEtCik.ToString());
            Sorgu.Parameters.AddWithValue("@maxResimPay", KullaniciSecimleri.Sureler.maxResimPay.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Bekleme Sureleri
            Baglan.Close();
            Sorgu.Dispose();

        } // işleme başladığı anda ayarları veritabanına ekledik
        
    }
}
