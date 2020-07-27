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

        KullaniciSecimleri Secimler = KullaniciSecimleri.GetInstance();

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
                    Secimler.Begen.begenecekMi = Convert.ToBoolean(veriler["begenecekMi"]);
                    Secimler.Begen.begeniSayisi = Convert.ToInt32(veriler["begeniSayisi"]);
                    Secimler.Begen.anaSyBegeniSayisi = Convert.ToInt32(veriler["anaSyBegeniSayisi"]); 
                    Secimler.Begen.anaSayfaBegen = Convert.ToBoolean(veriler["anaSayfaBegen"]);
                    Secimler.Begen.yapilanBegeniSayisi = Convert.ToInt32(veriler["yapilanBegeniSayisi"]);
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Beğeni
                    Secimler.GirisBilgileri.kullaniciAdi = veriler["kullaniciAdi"].ToString();
                    Secimler.GirisBilgileri.sifre = veriler["sifre"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Giris Bilgileri
                    Secimler.ResimAl.resimAlsinMi = Convert.ToBoolean(veriler["resimAlsinMi"]);
                    Secimler.ResimAl.resimSayisi = Convert.ToInt32(veriler["resimSayisi"]);
                    Secimler.ResimAl.alinanResimSayisi = veriler["alinanResimSayisi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Al
                    Secimler.ResimPaylas.resimPaylasacakMi = Convert.ToBoolean(veriler["resimPaylasacakMi"]);
                    Secimler.ResimPaylas.resimGrubu = veriler["resimGrubu"].ToString();
                    Secimler.ResimPaylas.paylasimSayisi = Convert.ToInt32(veriler["paylasimSayisi"]);
                    Secimler.ResimPaylas.yapilanPySayisi = veriler["yapilanPySayisi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Paylaş
                    Secimler.TakipEt.takipEdicekMi = Convert.ToBoolean(veriler["takipEdicekMi"]);
                    Secimler.TakipEt.yorumlardanTkpEt = Convert.ToBoolean(veriler["yorumlardanTkpEt"]);
                    Secimler.TakipEt.takipEttiklerindenTkpEt = Convert.ToBoolean(veriler["takipEttiklerindenTkpEt"]);
                    Secimler.TakipEt.takipcilerdenTkpEt = Convert.ToBoolean(veriler["takipcilerdenTkpEt"]);
                    Secimler.TakipEt.acikHesaplariTkpEtme = Convert.ToBoolean(veriler["acikHesaplariTkpEtme"]);
                    Secimler.TakipEt.takipEtmeSayisi = Convert.ToInt32(veriler["takipEtmeSayisi"]);
                    Secimler.TakipEt.takipEdilenSayi = Convert.ToInt32(veriler["takipEdilenSayi"]);
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Et
                    Secimler.TakipKontrol.takipKontrolEdilsinMi = Convert.ToBoolean(veriler["takipKontrolEdilsinMi"]);
                    Secimler.TakipKontrol.acikHesap = Convert.ToBoolean(veriler["acikHesap"]);
                    Secimler.TakipKontrol.gizliHesap = Convert.ToBoolean(veriler["gizliHesap"]);
                    Secimler.TakipKontrol.gonderiBegen = Convert.ToBoolean(veriler["gonderiBegen"]);
                    Secimler.TakipKontrol.kontrolSayisi = veriler["kontrolSayisi"].ToString();
                    Secimler.TakipKontrol.begenilecekSayi = Convert.ToInt32(veriler["begenilecekSayi"]);
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip İstekleri Kontrol
                    Secimler.TakiptenCik.takiptenCikacakMi = Convert.ToBoolean(veriler["takiptenCikacakMi"]);
                    Secimler.TakiptenCik.takiptenCikmaSayisi = Convert.ToInt32(veriler["takiptenCikmaSayisi"]);
                    Secimler.TakiptenCik.takiptenCikarilanSayi = veriler["takiptenCikarilanSayi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takipten Çıkma
                    Secimler.YorumYap.yorumYapacakMi = Convert.ToBoolean(veriler["yorumYapacakMi"]);
                    Secimler.YorumYap.rasgeleHarfEkle = Convert.ToBoolean(veriler["rasgeleHarfEkle"]);
                    Secimler.YorumYap.yorumSayisi = Convert.ToInt32(veriler["yorumSayisi"]);
                    Secimler.YorumYap.yorumGrubu = veriler["yorumGrubu"].ToString();
                    Secimler.YorumYap.yapilanYorumSayisi = Convert.ToInt32(veriler["yapilanYorumSayisi"]);
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Yorum Yap
                    Secimler.Sureler.minBegen = Convert.ToInt32(veriler["minBegen"]);
                    Secimler.Sureler.minYorum = Convert.ToInt32(veriler["minYorum"]);
                    Secimler.Sureler.minTakipEtCik = Convert.ToInt32(veriler["minTakipEtCik"]);
                    Secimler.Sureler.minResimPay = Convert.ToInt32(veriler["minResimPay"]);
                    Secimler.Sureler.maxBegen = Convert.ToInt32(veriler["maxBegen"]); 
                    Secimler.Sureler.maxYorum = Convert.ToInt32(veriler["maxYorum"]); 
                    Secimler.Sureler.maxTakipEtCik = Convert.ToInt32(veriler["maxTakipEtCik"]);
                    Secimler.Sureler.maxResimPay = Convert.ToInt32(veriler["maxResimPay"]);
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

            Sorgu.CommandText = "UPDATE tbl_Begen SET begenecekMi=@begenecekMi,begeniSayisi=@begeniSayisi,anaSayfaBegen=@anaSayfaBegen,anaSyBegeniSayisi=@anaSyBegeniSayisi";

            Sorgu.Parameters.AddWithValue("@begenecekMi", Secimler.Begen.begenecekMi.ToString()) ;
            Sorgu.Parameters.AddWithValue("@begeniSayisi", Secimler.Begen.begeniSayisi.ToString());
            Sorgu.Parameters.AddWithValue("@anaSyBegeniSayisi", Secimler.Begen.anaSyBegeniSayisi.ToString());
            Sorgu.Parameters.AddWithValue("@anaSayfaBegen", Secimler.Begen.anaSayfaBegen.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Beğeni

            Sorgu.CommandText = "UPDATE tbl_GirisBilgileri SET kullaniciAdi=@kullaniciAdi,sifre=@sifre";

            Sorgu.Parameters.AddWithValue("@kullaniciAdi", Secimler.GirisBilgileri.kullaniciAdi.ToString());
            Sorgu.Parameters.AddWithValue("@sifre", Secimler.GirisBilgileri.sifre.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Giris Bilgileri

            Sorgu.CommandText = "UPDATE tbl_ResimAl SET resimAlsinMi=@resimAlsinMi,resimSayisi=@resimSayisi";

            Sorgu.Parameters.AddWithValue("@resimAlsinMi", Secimler.ResimAl.resimAlsinMi.ToString());
            Sorgu.Parameters.AddWithValue("@resimSayisi", Secimler.ResimAl.resimSayisi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Al
            //
            Sorgu.CommandText = "UPDATE tbl_ResimPaylas SET resimPaylasacakMi=@resimPaylasacakMi,resimGrubu=@resimGrubu,paylasimSayisi=@paylasimSayisi";

            Sorgu.Parameters.AddWithValue("@resimPaylasacakMi", Secimler.ResimPaylas.resimPaylasacakMi.ToString());
            Sorgu.Parameters.AddWithValue("@resimGrubu", Secimler.ResimPaylas.resimGrubu.ToString());
            Sorgu.Parameters.AddWithValue("@paylasimSayisi", Secimler.ResimPaylas.paylasimSayisi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Paylaş

            Sorgu.CommandText = "UPDATE tbl_TakipEt SET takipEdicekMi=@takipEdicekMi,yorumlardanTkpEt=@yorumlardanTkpEt,takipEttiklerindenTkpEt=@takipEttiklerindenTkpEt,takipcilerdenTkpEt=@takipcilerdenTkpEt,acikHesaplariTkpEtme=@acikHesaplariTkpEtme,takipEtmeSayisi=@takipEtmeSayisi";

            Sorgu.Parameters.AddWithValue("@takipEdicekMi", Secimler.TakipEt.takipEdicekMi.ToString());
            Sorgu.Parameters.AddWithValue("@yorumlardanTkpEt", Secimler.TakipEt.yorumlardanTkpEt.ToString());
            Sorgu.Parameters.AddWithValue("@takipEttiklerindenTkpEt", Secimler.TakipEt.takipEttiklerindenTkpEt.ToString());
            Sorgu.Parameters.AddWithValue("@takipcilerdenTkpEt", Secimler.TakipEt.takipcilerdenTkpEt.ToString());
            Sorgu.Parameters.AddWithValue("@acikHesaplariTkpEtme", Secimler.TakipEt.acikHesaplariTkpEtme.ToString());
            Sorgu.Parameters.AddWithValue("@takipEtmeSayisi", Secimler.TakipEt.takipEtmeSayisi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Et

            Sorgu.CommandText = "UPDATE tbl_TakipKontrol SET takipKontrolEdilsinMi=@takipKontrolEdilsinMi,acikHesap=@acikHesap,gizliHesap=@gizliHesap,gonderiBegen=@gonderiBegen,kontrolSayisi=@kontrolSayisi,begenilecekSayi=@begenilecekSayi";

            Sorgu.Parameters.AddWithValue("@takipKontrolEdilsinMi", Secimler.TakipKontrol.takipKontrolEdilsinMi.ToString());
            Sorgu.Parameters.AddWithValue("@acikHesap", Secimler.TakipKontrol.acikHesap.ToString());
            Sorgu.Parameters.AddWithValue("@gizliHesap", Secimler.TakipKontrol.gizliHesap.ToString());
            Sorgu.Parameters.AddWithValue("@gonderiBegen", Secimler.TakipKontrol.gonderiBegen.ToString());
            Sorgu.Parameters.AddWithValue("@kontrolSayisi", Secimler.TakipKontrol.kontrolSayisi.ToString());
            Sorgu.Parameters.AddWithValue("@begenilecekSayi", Secimler.TakipKontrol.begenilecekSayi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip İstekleri Kontrol

            Sorgu.CommandText = "UPDATE tbl_TakiptenCik SET takiptenCikacakMi=@takiptenCikacakMi,takiptenCikmaSayisi=@takiptenCikmaSayisi";

            Sorgu.Parameters.AddWithValue("@takiptenCikacakMi", Secimler.TakiptenCik.takiptenCikacakMi.ToString());
            Sorgu.Parameters.AddWithValue("@takiptenCikmaSayisi", Secimler.TakiptenCik.takiptenCikmaSayisi.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takipten Çıkma
            
            Sorgu.CommandText = "UPDATE tbl_YorumYap SET yorumYapacakMi=@yorumYapacakMi,rasgeleHarfEkle=@rasgeleHarfEkle,yorumSayisi=@yorumSayisi,yorumGrubu=@yorumGrubu";

            Sorgu.Parameters.AddWithValue("@yorumYapacakMi", Secimler.YorumYap.yorumYapacakMi.ToString());
            Sorgu.Parameters.AddWithValue("@rasgeleHarfEkle", Secimler.YorumYap.rasgeleHarfEkle.ToString());
            Sorgu.Parameters.AddWithValue("@yorumSayisi", Secimler.YorumYap.yorumSayisi.ToString());
            Sorgu.Parameters.AddWithValue("@yorumGrubu", Secimler.YorumYap.yorumGrubu.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Yorum Yap

            Sorgu.CommandText = "UPDATE tbl_Sureler SET minBegen=@minBegen,minYorum=@minYorum,minTakipEtCik=@minTakipEtCik,minResimPay=@minResimPay,maxBegen=@maxBegen,maxYorum=@maxYorum,maxTakipEtCik=@maxTakipEtCik,maxResimPay=@maxResimPay";

            Sorgu.Parameters.AddWithValue("@minBegen", Secimler.Sureler.minBegen.ToString());
            Sorgu.Parameters.AddWithValue("@minYorum", Secimler.Sureler.minYorum.ToString());
            Sorgu.Parameters.AddWithValue("@minTakipEtCik", Secimler.Sureler.minTakipEtCik.ToString());
            Sorgu.Parameters.AddWithValue("@minResimPay", Secimler.Sureler.minResimPay.ToString());
            Sorgu.Parameters.AddWithValue("@maxBegen", Secimler.Sureler.maxBegen.ToString());
            Sorgu.Parameters.AddWithValue("@maxYorum", Secimler.Sureler.maxYorum.ToString());
            Sorgu.Parameters.AddWithValue("@maxTakipEtCik", Secimler.Sureler.maxTakipEtCik.ToString());
            Sorgu.Parameters.AddWithValue("@maxResimPay", Secimler.Sureler.maxResimPay.ToString());

            Sorgu.ExecuteNonQuery();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Bekleme Sureleri
            Baglan.Close();
            Sorgu.Dispose();

        } // işleme başladığı anda ayarları veritabanına ekledik
        
    }
}
