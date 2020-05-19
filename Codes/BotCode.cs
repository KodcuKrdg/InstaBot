using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using AutoIt;
using System.Drawing;
using System.Threading;
using System.Data.SQLite;
using System.IO;

namespace WindowsFormsApp6
{
    class instagram
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

        public void ResimPaylas(string dosyaYolu, string mesaj)
        {
            try
            {
                webDriver.Navigate().GoToUrl("https://www.instagram.com");

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
                AutoItX.Send(dosyaYolu);
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
                    webDriver.FindElement(By.CssSelector("#react-root > section > div.A9bvI > section.IpSxo > div.NfvXc > textarea")).SendKeys(mesaj);
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

                Thread.Sleep(1000);

                paylasimOk = "Başarılı";
            }
            catch (Exception)
            {
                paylasimOk = "Başarısız";
            }
        }

        public void gonderiCek(string hasthag, int kacIcerik=10)
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

                string icerikYazisi="", resimYolu="";
                instagram test = new instagram();

                for (int i = 0; i < kacIcerik; i++)
                {
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
                        resimYolu = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div > div.KL4Bh > img")).GetAttribute("src");
                        webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                    }
                    else if (resim2)
                    {
                        resimYolu = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div > div.eLAPa._23QFA > div.KL4Bh > img")).GetAttribute("src");
                        webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                    }
                    else if (resim3)
                    {
                        resimYolu = webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div._97aPb > div > div.pR7Pc > div.Igw0E.IwRSH.eGOV_._4EzTm.O1flK.D8xaz.fm1AK.TxciK.yiMZG > div > div > div > ul > li:nth-child(2) > div > div > div > div.eLAPa._23QFA > div.KL4Bh > img")).GetAttribute("src");
                        webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                    }
                    else
                    {
                        webDriver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.EfHg9 > div > div > a._65Bje.coreSpriteRightPaginationArrow")).Click();
                    }

                    test.dataEKle(resimYolu,icerikYazisi);
                }

                paylasimOk = "Başarılı";
            }
            catch (Exception)
            {
                paylasimOk = "Başarısız";
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

        public void bilgileriSil()//bilgileri sildirme fonksiyonu
        {
            con = new SQLiteConnection("Data Source=databases.db;Password=instabot8975");//veritabanı yolum
            con.Open();//bağlantı açıyorum
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {

                    cmd.CommandText = @"Delete From gonderiler";//tablodaki verileri silme sorgusu
                    cmd.ExecuteNonQuery();//sorguyu çalıştırıyorum
                    con.Close();//bağlantı kapatıyorum
                }
            }
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

        void verileriGetir()
        {
            con = new SQLiteConnection("Data Source=databases.db;;Password=instabot8975");//veritabanı yolum
            con.Open();//bağlantı açıyorum

            var cmd = new SQLiteCommand("SELECT * FROM data", con);//tablodaki verileri getirme sorgusu
            SQLiteDataReader rdr = cmd.ExecuteReader();//tabloyu okutuyorum
            int i = 1;

            while (rdr.Read())//tablodaki veri kadar döndürüyorum ve gerekli değişkenleri ekrana yazdırıyorum.
            {
                Console.WriteLine("{0}.gün", i);
                i++;
                Console.Write("Bugün Hastalanan Kişi Sayısı: {0}", rdr.GetInt32(1));
                Console.Write("\nBugün Hastalanan Erkek Sayısı: {0}", rdr.GetInt32(2));
                Console.Write("\nBugün Hastalanan Kadın Sayısı: {0}", rdr.GetInt32(3));
                Console.Write("\nBugün Hastalanan 50-75 Yaş Grubu Sayısı: {0}", rdr.GetInt32(4));
                Console.Write("\nBugün Hastalanan 25-50 Yaş Grubu Sayısı: {0}", rdr.GetInt32(5));
                Console.Write("\nBugün Hastalanan 0-25 Yaş Grubu Sayısı: {0}", rdr.GetInt32(6));
                Console.Write("\nToplam Hastalanan Kişi Sayısı: {0}", rdr.GetInt32(7));
                Console.Write("\nBugün İyileşen Kişi Sayısı: {0}", rdr.GetInt32(8));
                Console.Write("\nToplam İyileşen Kişi Sayısı: {0}\n", rdr.GetInt32(9));
            }
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
