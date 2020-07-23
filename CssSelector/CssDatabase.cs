using System.Data.SQLite;
using System.IO;

namespace InstaBot.Codes
{
    class CssDatabase
    {

        private CssSelectorler cssSelector = CssSelectorler.GetInstance();


        public  CssDatabase()
        {
            verileriAl();
        }

        private void verileriAl() //CssSelector Classına veritabanındaki verileri aldık Komutlar Classında kulanılabilsin diye
        {
            using (var Baglan = new SQLiteConnection("Data Source=CssDatabase.db;Password=cssDatabase5441"))
            {
                var girisEkrani = cssSelector.GirisEkrani;
                var anaSayfaBegen = cssSelector.AnaSayfaBegen;
                var takiptenCikma = cssSelector.TakiptenCikma;
                var yorumyapBegen = cssSelector.YorumyapBegen;
                var takipEt = cssSelector.TakipEt;
                var istekKontrol = cssSelector.IstekKontrol;
                var likAl = cssSelector.LinkAl;


                SQLiteCommand Sorgu = new SQLiteCommand(Baglan);

                Sorgu.CommandText = "SELECT * FROM tbl_GirisEkrani";
                Baglan.Open();
                using (var veriler = Sorgu.ExecuteReader())
                {
                    while (veriler.Read())
                    {
                        girisEkrani.kullaniciAdiText = veriler["kullaniciAdiText"].ToString();
                        girisEkrani.sifreText = veriler["sifreText"].ToString();
                        girisEkrani.guvenlikMsjText = veriler["guvenlikMsjText"].ToString();
                        girisEkrani.bilgiButton = veriler["bilgiButton"].ToString();
                        girisEkrani.bildirimleriAcButton = veriler["bildirimleriAcButton"].ToString();
                        girisEkrani.bildirimleriAcButton = veriler["bildirimleriAcButton"].ToString();
                        girisEkrani.bildirimleriAcButton = veriler["bildirimleriAcButton"].ToString();
                    }

                }
                
                Sorgu.CommandText = "SELECT * FROM tbl_AnaSayfa";
                using (var veriler = Sorgu.ExecuteReader())
                {
                    while (veriler.Read())
                    {
                        anaSayfaBegen.gonderiler = veriler["gonderiler"].ToString();
                        anaSayfaBegen.begeniClass = veriler["begeniClass"].ToString();
                        anaSayfaBegen.isimClasi = veriler["isimClasi"].ToString();
                    }

                }

                Sorgu.CommandText = "SELECT * FROM tbl_TakiptenCik";
                using (var veriler = Sorgu.ExecuteReader())
                {
                    while (veriler.Read())
                    {
                        takiptenCikma.takipEdilenler = veriler["takipEdilenler"].ToString();
                        takiptenCikma.hesapDizini = veriler["hesapDizini"].ToString();
                        takiptenCikma.acilanEkran = veriler["acilanEkran"].ToString();
                        takiptenCikma.hesapAdi = veriler["hesapAdi"].ToString();
                        takiptenCikma.silmeButonu = veriler["silmeButonu"].ToString();
                    }

                }

                Sorgu.CommandText = "SELECT * FROM tbl_YorumyapBegen";
                using (var veriler = Sorgu.ExecuteReader())
                {
                    while (veriler.Read())
                    {
                        yorumyapBegen.gonderiler = veriler["gonderiler"].ToString();
                        yorumyapBegen.yorumYapma = veriler["yorumYapma"].ToString();
                        yorumyapBegen.begeniButonu = veriler["begeniButonu"].ToString();
                        yorumyapBegen.yorumYeri = veriler["yorumYeri"].ToString();
                        yorumyapBegen.yorumYapanlar = veriler["yorumYapanlar"].ToString();
                        yorumyapBegen.yorumyapanınAdi = veriler["yorumyapanınAdi"].ToString();
                    }

                }

                Sorgu.CommandText = "SELECT * FROM tbl_TakipEt";
                using (var veriler = Sorgu.ExecuteReader())
                {
                    while (veriler.Read())
                    {
                        takipEt.anaDizin = veriler["anaDizin"].ToString();
                        takipEt.kullaniciAdi = veriler["kullaniciAdi"].ToString();
                        takipEt.acikHesap = veriler["acikHesap"].ToString();
                        takipEt.gizliHesap = veriler["gizliHesap"].ToString();
                    }

                }

                Sorgu.CommandText = "SELECT * FROM tbl_IstekKontrol";
                using (var veriler = Sorgu.ExecuteReader())
                {
                    while (veriler.Read())
                    {
                        istekKontrol.AtakiptenCik = veriler["AtakiptenCik"].ToString();
                        istekKontrol.GtakiptenCik = veriler["GtakiptenCik"].ToString();
                        istekKontrol.onayButonu = veriler["onayButonu"].ToString();
                        istekKontrol.istekKabul = veriler["istekKabul"].ToString();
                        istekKontrol.gonderi = veriler["gonderi"].ToString();
                        istekKontrol.begenButon = veriler["begenButon"].ToString();
                        istekKontrol.ileriButon = veriler["ileriButon"].ToString();
                    }

                }

                Sorgu.CommandText = "SELECT * FROM tbl_LinkAl";
                using (var veriler = Sorgu.ExecuteReader())
                {
                    while (veriler.Read())
                    {
                        likAl.gonderiler = veriler["gonderiler"].ToString();
                        likAl.ileri = veriler["ileri"].ToString();
                        likAl.liClass = veriler["liClass"].ToString();
                        likAl.resim = veriler["resim"].ToString();
                        likAl.video = veriler["video"].ToString();
                        likAl.aciklama = veriler["aciklama"].ToString();
                        likAl.paylasan = veriler["paylasan"].ToString();
                        likAl.playTusu = veriler["playTusu"].ToString();
                    }

                }



                Sorgu.Dispose();
                Baglan.Close();
            }
        }
    }
}
