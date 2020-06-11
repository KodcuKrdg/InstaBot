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
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM tbl_GirisEkrani,tbl_AnaSayfa", con);
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
                }

                con.Close();
            }
        }
    }
}
