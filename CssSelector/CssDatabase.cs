using InstaBot.CssSelector;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void veritabaniOlustur()
        {
            

            if (!File.Exists("CssDatabase.db"))
            {
                SQLiteConnection.CreateFile(veritabaniAdi);

                con = new SQLiteConnection("Data Source="+ veritabaniAdi+";");//veritabanı yolum

                con.Open();
                con.ChangePassword(veritabaniSifre);
                con.Close();
            }
        }

        public void verileriAl() 
        {
            using (con = new SQLiteConnection("Data Source="+ veritabaniAdi + ";Password="+veritabaniSifre))
            {
                var girisEkrani = cssSelector.GirisEkrani;
                var anaSayfaBegen = cssSelector.AnaSayfaBegen;
                var takiptenCikma = cssSelector.TakiptenCikma;
                var yorumyapBegen = cssSelector.YorumyapBegen;
                var takipEt = cssSelector.TakipEt;

                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM tbl_GirisEkrani,tbl_AnaSayfa,tbl_TakiptenCik,tbl_YorumyapBegen,tbl_TakipEt", con);
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
                    anaSayfaBegen.gonderiDizini = rd["gonderiDizini"].ToString();
                    anaSayfaBegen.begeniDizini = rd["begeniDizini"].ToString();
                    anaSayfaBegen.isimClasi = rd["isimClasi"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    takiptenCikma.takipEdilenler = rd["takipEdilenler"].ToString();
                    takiptenCikma.takipDizini = rd["takipDizini"].ToString();
                    takiptenCikma.hesapDizini = rd["hesapDizini"].ToString();
                    takiptenCikma.silmeButonu = rd["silmeButonu"].ToString();
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    yorumyapBegen.gonderiler = rd["gonderiler"].ToString();
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
                }

                con.Close();
            }
        }
    }
}
