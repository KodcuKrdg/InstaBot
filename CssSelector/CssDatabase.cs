using System.Data.SQLite;
using System.IO;

namespace InstaBot.Codes
{
    class CssDatabase
    {

        private CssSelectorler cssSelector = CssSelectorler.GetInstance();

        private string veritabaniAdi = "CssDatabase.db";
        private string veritabaniSifre = "cssDatabase5441";

        public  CssDatabase()
        {
            verileriAl();
        }

        SQLiteConnection con;//Veritabanı bağlantı değişkeni
        private void verileriAl() 
        {
            using (con = new SQLiteConnection("Data Source="+ veritabaniAdi + ";Password="+veritabaniSifre))
            {
                var girisEkrani = cssSelector.GirisEkrani;
                var anaSayfaBegen = cssSelector.AnaSayfaBegen;
                var takiptenCikma = cssSelector.TakiptenCikma;
                var yorumyapBegen = cssSelector.YorumyapBegen;
                var takipEt = cssSelector.TakipEt;
                var istekKontrol = cssSelector.IstekKontrol;
                var likAl = cssSelector.LinkAl;

                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM tbl_GirisEkrani,tbl_AnaSayfa,tbl_TakiptenCik,tbl_YorumyapBegen,tbl_TakipEt,tbl_IstekKontrol,tbl_LinkAl", con);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())//tablodaki veri kadar döndürüyorum ve gerekli değişkenleri ekrana yazdırıyorum.
                {
                    //CssSelector Classına veritabanındaki verileri ekledikki Komutlar Classında kulanılabilsin diye
                    girisEkrani.kullaniciAdiText = rd["kullaniciAdiText"].ToString();
                    girisEkrani.sifreText = rd["sifreText"].ToString();
                    girisEkrani.guvenlikMsjText = rd["guvenlikMsjText"].ToString();
                    girisEkrani.bilgiButton = rd["bilgiButton"].ToString();
                    girisEkrani.bildirimleriAcButton = rd["bildirimleriAcButton"].ToString();
                    girisEkrani.bildirimleriAcButton = rd["bildirimleriAcButton"].ToString();
                    girisEkrani.bildirimleriAcButton = rd["bildirimleriAcButton"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    anaSayfaBegen.gonderiler = rd["gonderiler"].ToString();
                    anaSayfaBegen.begeniClass = rd["begeniClass"].ToString();
                    anaSayfaBegen.isimClasi = rd["isimClasi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    takiptenCikma.takipEdilenler = rd["takipEdilenler"].ToString();
                    takiptenCikma.takipDizini = rd["takipDizini"].ToString();
                    takiptenCikma.hesapDizini = rd["hesapDizini"].ToString();
                    takiptenCikma.silmeButonu = rd["silmeButonu"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    yorumyapBegen.gonderiler = rd["gonderiler"].ToString();
                    yorumyapBegen.gonderiEkrani = rd["gonderiEkrani"].ToString();
                    yorumyapBegen.yorumYapma = rd["yorumYapma"].ToString();
                    yorumyapBegen.begeniButonu = rd["begeniButonu"].ToString();
                    yorumyapBegen.yorumYeri = rd["yorumYeri"].ToString();
                    yorumyapBegen.yorumYapanlar = rd["yorumYapanlar"].ToString();
                    yorumyapBegen.yorumyapanınAdi = rd["yorumyapanınAdi"].ToString();
                    yorumyapBegen.ileriButonu = rd["ileriButonu"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    takipEt.anaDizin = rd["anaDizin"].ToString();
                    takipEt.kullaniciAdi = rd["kullaniciAdi"].ToString();
                    takipEt.acikHesap = rd["acikHesap"].ToString();
                    takipEt.gizliHesap = rd["gizliHesap"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    istekKontrol.AtakiptenCik = rd["AtakiptenCik"].ToString();
                    istekKontrol.GtakiptenCik = rd["GtakiptenCik"].ToString();
                    istekKontrol.onayButonu = rd["onayButonu"].ToString();
                    istekKontrol.istekKabul = rd["istekKabul"].ToString();
                    istekKontrol.gonderi = rd["gonderi"].ToString();
                    istekKontrol.begenButon = rd["begenButon"].ToString();
                    istekKontrol.ileriButon = rd["ileriButon"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    likAl.gonderiler = rd["gonderiler"].ToString();
                    likAl.ileri = rd["ileri"].ToString();
                    likAl.liClass = rd["liClass"].ToString();
                    likAl.resim = rd["resim"].ToString();
                    likAl.video = rd["video"].ToString();
                    likAl.aciklama = rd["aciklama"].ToString();
                    likAl.paylasan = rd["paylasan"].ToString();
                    likAl.playTusu = rd["playTusu"].ToString();
                }

                con.Close();
                cmd.Dispose();
            }
        }
    }
}
