using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using AutoIt;
using System.Drawing;
using System.Threading;
using System.Data.SQLite;
using System.IO;
using System.Drawing.Imaging;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace BotCodes
{
    class Bot
    {
        IWebDriver webDriver;

        public string girisOk;
        public string paylasimOk;

        SQLiteConnection con;//Veritabanı bağlantı değişkeni
        public bool IsElementPresent_byCssSelector(string elementName)
        {
            try { webDriver.FindElement(By.CssSelector(elementName)); }
            catch (NoSuchElementException) { return false; }
            catch (StaleElementReferenceException) { return false; }
            return true;
        }

        public bool IsElementPresent_byXpath(string elementName)
        {
            try { webDriver.FindElement(By.XPath(elementName)); }
            catch (NoSuchElementException) { return false; }
            catch (StaleElementReferenceException) { return false; }
            return true;
        }

        public void HesabaGirisYapMobil(string kullaniciAdim, string parolam)
        {
            try
            {
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                ChromeOptions options = new ChromeOptions();
                service.HideCommandPromptWindow = true;
                options.EnableMobileEmulation("iPhone 6");
                options.AddExcludedArgument("enable-automation");
                options.AddAdditionalCapability("useAutomationExtension", false);
                options.AddUserProfilePreference("credentials_enable_service", false);
                options.AddUserProfilePreference("profile.password_manager_enabled", false);
                webDriver = new ChromeDriver(service, options);

                webDriver.Manage().Window.Size = new Size(375, 746);
                webDriver.Navigate().GoToUrl("https://www.instagram.com");

            tekrar1:
                var girisYap = IsElementPresent_byCssSelector("#react-root > section > main > article > div > div > div > div:nth-child(2) > button");

                if (girisYap)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > article > div > div > div > div:nth-child(2) > button")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar1;
                }

                Thread.Sleep(1000);

            tekrar2:
                var kullaniciAdi = IsElementPresent_byCssSelector("#react-root > section > main > article > div > div > div > form > div:nth-child(4) > div > label > input");

                if (kullaniciAdi)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > article > div > div > div > form > div:nth-child(4) > div > label > input")).SendKeys(kullaniciAdim);
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar2;
                }

                Thread.Sleep(1000);

            tekrar3:
                var parola = IsElementPresent_byCssSelector("#react-root > section > main > article > div > div > div > form > div:nth-child(5) > div > label > input");

                if (parola)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > article > div > div > div > form > div:nth-child(5) > div > label > input")).SendKeys(parolam);
                    Thread.Sleep(1000);
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > article > div > div > div > form > div:nth-child(5) > div > label > input")).SendKeys(OpenQA.Selenium.Keys.Enter);
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar3;
                }

                Thread.Sleep(1000);

            tekrar4:
                var beniHatirla = IsElementPresent_byCssSelector("#react-root > section > main > div > div > section > div > button");

                if (beniHatirla)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > div > div > section > div > button")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar4;
                }

                Thread.Sleep(1500);

            tekrar5:
                var anaSayfaEkle = IsElementPresent_byCssSelector("body > div.RnEpo.Yx5HN > div > div > div.mt3GC > button.aOOlW.HoLwm");

                if (anaSayfaEkle)
                {
                    webDriver.FindElement(By.CssSelector("body > div.RnEpo.Yx5HN > div > div > div.mt3GC > button.aOOlW.HoLwm")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar5;
                }

                Thread.Sleep(1000);

                IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;

            tekrar6:

                for (int i = 1; i <= 50; i++)
                {
                    js.ExecuteScript("window.scrollBy(0," + i + ")", "");
                }

                Thread.Sleep(1000);


                var bildirimAc = IsElementPresent_byCssSelector("body > div.RnEpo.Yx5HN > div > div > div.mt3GC > button.aOOlW.HoLwm");

                if (bildirimAc)
                {
                    webDriver.FindElement(By.CssSelector("body > div.RnEpo.Yx5HN > div > div > div.mt3GC > button.aOOlW.HoLwm")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar6;
                }

                girisOk = "Başarılı";
            }
            catch (Exception)
            {
                girisOk = "Başarısız";
            }
        }

        public void HesabaGirisYapPc(string kullaniciAdim, string parolam)
        {
            try
            {
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                ChromeOptions options = new ChromeOptions();
                service.HideCommandPromptWindow = true;
                options.AddExcludedArgument("enable-automation");
                options.AddAdditionalCapability("useAutomationExtension", false);
                options.AddUserProfilePreference("credentials_enable_service", false);
                options.AddUserProfilePreference("profile.password_manager_enabled", false);
                webDriver = new ChromeDriver(service, options);

                webDriver.Manage().Window.Size = new Size(1200, 780);
                webDriver.Navigate().GoToUrl("https://www.instagram.com");

                Thread.Sleep(1000);

            tekrar1:
                var kullaniciAdi = IsElementPresent_byCssSelector("#react-root > section > main > article > div.rgFsT > div:nth-child(1) > div > form > div:nth-child(2) > div > label > input");

                if (kullaniciAdi)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > article > div.rgFsT > div:nth-child(1) > div > form > div:nth-child(2) > div > label > input")).SendKeys(kullaniciAdim);
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar1;
                }

                Thread.Sleep(1000);

            tekrar2:
                var parola = IsElementPresent_byCssSelector("#react-root > section > main > article > div.rgFsT > div:nth-child(1) > div > form > div:nth-child(3) > div > label > input");

                if (parola)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > article > div.rgFsT > div:nth-child(1) > div > form > div:nth-child(3) > div > label > input")).SendKeys(parolam);
                    Thread.Sleep(1000);
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > article > div.rgFsT > div:nth-child(1) > div > form > div:nth-child(3) > div > label > input")).SendKeys(OpenQA.Selenium.Keys.Enter);
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar2;
                }

                Thread.Sleep(1000);

                int sayi = 0;
            tekrar3:
                sayi++;
                var bilgi = IsElementPresent_byCssSelector("#react-root > section > main > div > div > div > section > div > button");

                if (bilgi)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > div > div > div > section > div > button")).Click();
                }
                else
                {
                    Thread.Sleep(1000);
                    if (sayi != 3)
                        goto tekrar3;
                }

                Thread.Sleep(1000);

            tekrar4:
                var beniHatirla = IsElementPresent_byCssSelector("body > div.RnEpo.Yx5HN > div > div > div.mt3GC > button.aOOlW.HoLwm");

                if (beniHatirla)
                {
                    webDriver.FindElement(By.CssSelector("body > div.RnEpo.Yx5HN > div > div > div.mt3GC > button.aOOlW.HoLwm")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar4;
                }

                girisOk = "Başarılı";
            }
            catch (Exception)
            {
                girisOk = "Başarısız";
            }
        }

        public string ResimPaylas(string dosyaYolu, string mesaj)
        {
            try
            {
                webDriver.Navigate().GoToUrl("https://www.instagram.com");

                Thread.Sleep(1000);

            tekrar1:
                var girisYap = IsElementPresent_byCssSelector("#react-root > section > nav.NXc7H.f11OC > div > div > div.KGiwt > div > div > div.q02Nz._0TPg");

                if (girisYap)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > nav.NXc7H.f11OC > div > div > div.KGiwt > div > div > div.q02Nz._0TPg")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar1;
                }

                Thread.Sleep(1000);

                AutoItX.WinActivate("Aç");
                AutoItX.Send(Application.StartupPath + "\\" + dosyaYolu);
                Thread.Sleep(500);
                AutoItX.Send("{ENTER}");

                Thread.Sleep(1000);

            tekrar2:
                var devamEt = IsElementPresent_byCssSelector("#react-root > section > div.Scmby > header > div > div.mXkkY.KDuQp > button");

                if (devamEt)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > div.Scmby > header > div > div.mXkkY.KDuQp > button")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar2;
                }

                Thread.Sleep(1000);

            tekrar3:
                var mesajim = IsElementPresent_byCssSelector("#react-root > section > div.A9bvI > section.IpSxo > div.NfvXc > textarea");

                if (mesajim)
                {
                    Thread t = new Thread((ThreadStart)(() =>
                    {
                        Clipboard.SetText(mesaj);
                    }));
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();
                    t.Join();
                    Thread.Sleep(500);
                    webDriver.FindElement(By.CssSelector("#react-root > section > div.A9bvI > section.IpSxo > div.NfvXc > textarea")).SendKeys(OpenQA.Selenium.Keys.Control + "v");
                    /*
                    char[] icerik = mesaj.ToCharArray();
                    for (int i = 0; i < icerik.Count(); i++)
                    {
                        webDriver.FindElement(By.CssSelector("#react-root > section > div.A9bvI > section.IpSxo > div.NfvXc > textarea")).SendKeys(icerik[i].ToString());
                    }*/
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar3;
                }

                Thread.Sleep(1000);

            tekrar4:
                var paylas = IsElementPresent_byCssSelector("#react-root > section > div.Scmby > header > div > div.mXkkY.KDuQp > button");

                if (paylas)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > div.Scmby > header > div > div.mXkkY.KDuQp > button")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar4;
                }

                Thread.Sleep(500);

                var gonderildi = IsElementPresent_byCssSelector("body > div.Z2m7o > div > div > div > p");

                if (gonderildi)
                {
                    return paylasimOk = "Başarısız";
                }
                else
                {
                    bilgileriSil(dosyaYolu);
                    return paylasimOk = "Başarılı";
                }
            }
            catch (Exception)
            {
                return paylasimOk = "Başarısız";
            }
        }

        public string random()
        {
            string harfler = "ABCDEFGHIJKLMNOPRSTUVWXYZ0123456789";

            string uret = "";

            Random random = new Random();
            HashSet<int> sayilar = new HashSet<int>();

            while (sayilar.Count != 10)
                sayilar.Add(random.Next(0, 35));

            foreach (var i in sayilar)
            {
                uret += harfler[i];
            }

            return uret;
        }

        public class DownloadImage
        {
            private string imageUrl;
            private Bitmap bitmap;
            public DownloadImage(string imageUrl)
            {
                this.imageUrl = imageUrl;
            }
            public void Download()
            {
                try
                {
                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead(imageUrl);
                    bitmap = new Bitmap(stream);
                    stream.Flush();
                    stream.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            public Bitmap GetImage()
            {
                return bitmap;
            }
            public void SaveImage(string filename, ImageFormat format)
            {
                if (bitmap != null)
                {
                    bitmap.Save(filename, format);
                }
            }
        }

        public string gonderiCek(string hasthag)
        {
            try
            {
                Thread.Sleep(500);

                var ileriTusu = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow");

                if (ileriTusu)
                    goto devamEt;

                webDriver.Navigate().GoToUrl("https://www.instagram.com/explore/tags/" + hasthag + "/");

                Thread.Sleep(1000);

            tekrar4:
                var beniHatirla = IsElementPresent_byCssSelector("#react-root > section > main > article > div.EZdmt > div > div > div:nth-child(1) > div:nth-child(1) > a > div");

                if (beniHatirla)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > article > div.EZdmt > div > div > div:nth-child(1) > div:nth-child(1) > a > div")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar4;
                }

            devamEt:

                Thread.Sleep(1000);

                string icerikYazisi = "", resimYolu = "";

                Thread.Sleep(1500);
                var resim1 = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div > div.KL4Bh > img");
                var resim2 = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div > div.eLAPa._23QFA > div.KL4Bh > img");
                var resim3 = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > div > div > ul > li:nth-child(2) > div > div > div > div.eLAPa._23QFA > div.KL4Bh > img");
                var resim4 = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > div > div > ul > li:nth-child(3) > div > div > div > div.KL4Bh > img");
                var icerik = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div.eo2As > div.EtaWk > ul > div > li > div > div > div.C4VMK > span");
                if (icerik)
                {
                    Thread.Sleep(1000);
                    icerikYazisi = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div.eo2As > div.EtaWk > ul > div > li > div > div > div.C4VMK > span")).Text;
                }
                if (resim1)
                {
                    Thread.Sleep(500);
                    resimYolu = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div > div.KL4Bh > img")).GetAttribute("src");
                    webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                }
                else if (resim2)
                {
                    Thread.Sleep(500);
                    resimYolu = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div > div.eLAPa._23QFA > div.KL4Bh > img")).GetAttribute("src");
                    webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                }
                else if (resim3)
                {
                    Thread.Sleep(500);
                    resimYolu = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > div > div > ul > li:nth-child(2) > div > div > div > div.eLAPa._23QFA > div.KL4Bh > img")).GetAttribute("src");
                    webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                }

                Thread.Sleep(500);
                DownloadImage ImageDownload = new DownloadImage(resimYolu);
                ImageDownload.Download();
                string resimDosyaYolu = "gonderiler\\resim" + random() + ".png";
                ImageDownload.SaveImage(resimDosyaYolu, ImageFormat.Png);

                dataEKle(resimDosyaYolu, icerikYazisi);
                Thread.Sleep(500);

                return paylasimOk = "Başarılı";
            }
            catch (Exception)
            {
                return paylasimOk = "Başarısız";
            }
        }

        public int ilkSatirId()
        {
            con = new SQLiteConnection("Data Source=databases.db;Password=instabot8975");//veritabanı yolum
            con.Open();//bağlantı açıyorum
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = @"select ROWID from gonderiler order by ROWID asc LIMIT 1";//tablodaki satır sayısını gösteren sorgu
                    int id = Convert.ToInt32(cmd.ExecuteScalar());//sorgudan dönen veriyi değişkene atıyorum
                    con.Close();//bağlantı kapatıyorum
                    return id;//değeri döndürüyorum
                }
            }
        }

        public void veritabaniOlustur()
        {
            if (!File.Exists("databases.db"))
            {
                SQLiteConnection.CreateFile("databases.db");

                con = new SQLiteConnection("Data Source=databases.db;");//veritabanı yolum

                con.Open();
                con.ChangePassword("instabot8975");
                con.Close();
            }

            con = new SQLiteConnection("Data Source=databases.db;Password=instabot8975");
            con.Open();
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = @"Create table if not exists gonderiler (
                        gonderiId INTEGER PRIMARY KEY AUTOINCREMENT,
                        resimYolu TEXT, 
                        icerik TEXT)";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public int satirSayisi()//satır sayısı buldurma fonksiyonu
        {
            con = new SQLiteConnection("Data Source=databases.db;Password=instabot8975");//veritabanı yolum
            con.Open();//bağlantı açıyorum
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {

                    cmd.CommandText = @"select count(*) from gonderiler";//tablodaki satır sayısını gösteren sorgu
                    int lastID = Convert.ToInt32(cmd.ExecuteScalar());//sorgudan dönen veriyi değişkene atıyorum
                    con.Close();//bağlantı kapatıyorum
                    return lastID;//değeri döndürüyorum
                }
            }
        }

        public void bilgileriSil(string resimYolu)//bilgileri sildirme fonksiyonu
        {
            con = new SQLiteConnection("Data Source=databases.db;Password=instabot8975");//veritabanı yolum
            con.Open();//bağlantı açıyorum
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    SQLiteTransaction transaction = null;
                    transaction = con.BeginTransaction();
                    cmd.CommandText = "Delete From gonderiler where resimYolu=@resimYolu";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("resimYolu", resimYolu);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    con.Close();
                }
            }
            string dosyaYoluu = Application.StartupPath + "\\" + resimYolu;
            File.Delete(dosyaYoluu);
        }

        public void dataEKle(string resimYolu, string icerik)
        {
            con = new SQLiteConnection("Data Source=databases.db;Password=instabot8975");//veritabanı yolum
            con.Open();//bağlantı açıyorum
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    SQLiteTransaction transaction = null;
                    transaction = con.BeginTransaction();
                    cmd.CommandText = "INSERT INTO gonderiler (resimYolu, icerik) VALUES (@resimYolu, @icerik)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("resimYolu", resimYolu);
                    cmd.Parameters.AddWithValue("icerik", icerik);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    con.Close();
                }
            }
        }

        public string[] verileriGetir(int gonderiId)
        {
            con = new SQLiteConnection("Data Source=databases.db;;Password=instabot8975");//veritabanı yolum
            con.Open();
            var cmd = new SQLiteCommand("SELECT * FROM gonderiler where gonderiId=" + gonderiId, con);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            string[] dizi = new string[2];

            while (rdr.Read())//tablodaki veri kadar döndürüyorum ve gerekli değişkenleri ekrana yazdırıyorum.
            {
                dizi[0] = rdr.GetString(1);
                dizi[1] = rdr.GetString(2);
            }
            con.Close();
            return dizi;
        }
        /*public void gonderiCek(string hasthag)
        {
            try
            {
                webDriver.Navigate().GoToUrl("https://www.instagram.com/explore/tags/" + hasthag + "/");

            tekrar4:
                var beniHatirla = IsElementPresent_byCssSelector("#react-root > section > main > article > div.EZdmt > div > div > div:nth-child(1) > div:nth-child(1) > a > div");

                if (beniHatirla)
                {
                    webDriver.FindElement(By.CssSelector("#react-root > section > main > article > div.EZdmt > div > div > div:nth-child(1) > div:nth-child(1) > a > div")).Click();
                }
                else
                {
                    Thread.Sleep(500);
                    goto tekrar4;
                }

                Thread.Sleep(1000);

                for (int i = 0; i < 15; i++)
                {
                    Thread.Sleep(1500);
                    var resim1 = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div > div.KL4Bh > img");
                    var resim2 = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div > div.eLAPa._23QFA > div.KL4Bh > img");
                    var resim3 = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > div > div > ul > li:nth-child(2) > div > div > div > div.eLAPa._23QFA > div.KL4Bh > img");
                    var resim4 = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > div > div > ul > li:nth-child(3) > div > div > div > div.KL4Bh > img");
                    if (resim1)
                    {
                        var imageSrc = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div > div.KL4Bh > img")).GetAttribute("src");
                        Clipboard.SetText(imageSrc);
                        webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                    }
                    else if (resim2)
                    {
                        var imageSrc = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div > div.eLAPa._23QFA > div.KL4Bh > img")).GetAttribute("src");
                        Clipboard.SetText(imageSrc);
                        webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                    }
                    else if (resim4)
                    {
                        var imageSrc = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > div > div > ul > li:nth-child(3) > div > div > div > div.KL4Bh > img")).GetAttribute("src");
                        Clipboard.SetText(imageSrc);

                        Thread.Sleep(500);
                        var ileriTusu = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > button > div");

                        if (ileriTusu)
                            webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > button > div")).Click();
                        else
                            webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                    }
                    else if (resim3)
                    {
                        var imageSrc = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > div > div > ul > li:nth-child(2) > div > div > div > div.eLAPa._23QFA > div.KL4Bh > img")).GetAttribute("src");
                        Clipboard.SetText(imageSrc);

                        Thread.Sleep(500);
                        var ileriTusu = IsElementPresent_byCssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > button > div");

                        if (ileriTusu)
                            webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > button > div")).Click();
                        else
                            webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                    }
                    else
                    {
                        webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                    }
                }

                paylasimOk = "Başarılı";
            }
            catch (Exception)
            {
                paylasimOk = "Başarısız";
            }
        }*/ 
    }
}
