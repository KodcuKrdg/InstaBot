using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using InstaBot.Ob;
using OpenQA.Selenium.Support.UI;
using InstaBot.BaseClass;
using InstaBot.Database;
using InstaBot.Codes.BaseVeriHavuzu;

namespace InstaBot.Codes
{
    class Komutlar :ISubject
    {
        private Komutlar() { }

        private static Komutlar _instance;
        public static Komutlar GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Komutlar();
            }
            return _instance;
        }

        IWebDriver webDriver;
        IJavaScriptExecutor js;
        WebDriverWait bekle;// Elemet yüklenmediyse beklenilecek süre

        CssSelectorler CssSelectorler = CssSelectorler.GetInstance();
        KullaniciSecimleri Secimler = KullaniciSecimleri.GetInstance();
        VeriHavuzu VeriHavuzu = VeriHavuzu.GetInstance();
        VeriTabani VeriTabani = VeriTabani.GetInstance();

        Random random = new Random();
        List<string> paylasimLinki = new List<string>();

        bool WebAcik = false;


        //ISubject İşlemleri
        private List<IObserver> _observers = new List<IObserver>(); // Veri lerin iletileceği Classlar
        public string Bilgi { get; set; }
        public void VeriyiAlacak(IObserver observer)
        {
            _observers.Add(observer);
        }  // Haber verilecek Claasları ekler
        public void VeriyiBirakacak(IObserver observer)
        {
            _observers.Remove(observer);
        } // Artık haber edilmesinme gerek duyulmayanları çıkarır
        public void VeriHazir()
        {
            foreach (var observer in _observers) //Verileri Alıcak Claslara veriyi gönderiyor
            {
                observer.VeriyiAl(this);
            }
        } // Bu Classta Veri işlenince İletilecek Claslara haber verir
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        [Obsolete]
        public void Baslat() 
        {
            Thread ThYapilacaklar = new Thread(Yapilacaklar);
            ThYapilacaklar.Start();
        }
        private void Yapilacaklar()
        {
            GirisYap();

            if (Secimler.Begen.begenecekMi && Secimler.Begen.anaSayfaBegen)
            {
                AnaSayfaBegen();
            }
            
            if (Secimler.YorumYap.yorumYapacakMi)
            {
                if (paylasimLinki.Count<1)
                {
                    PaylasimLinkiAl();
                }
                YorumYapBegen();
            }

            if (Secimler.TakipEt.takipEdicekMi)
            {
                TakipEt();
            }

            if (Secimler.TakiptenCik.takiptenCikacakMi)
            {
                TakiptenCik();
            }
            
            
        }
        private void ChromeAyarları()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true; //açılan cmd yi kapar
            ChromeOptions options = new ChromeOptions(); //Chrome ayarlamak için
            options.AddExcludedArgument("enable-automation"); //Üst paneldeki yazılım test yazısını kaldırır
            options.AddAdditionalCapability("useAutomationExtension", false);//Şifre katme popUp ı kapatır  
            options.AddUserProfilePreference("credentials_enable_service", false); //Şifre Kaydetmeme
            options.AddUserProfilePreference("profile.password_manager_enabled", false); //Şifre Kaydetmeme
            ChromeDriver driver = new ChromeDriver(service, options);
            webDriver = driver;
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //sayfanın yüklemesi için bekleniler süre
            js = webDriver as IJavaScriptExecutor;
            bekle = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            webDriver.Manage().Window.Maximize();
            WebAcik = true;
        }
        public void SeleniumKapat()
        {
            if (WebAcik)
            {
                /*webDriver.Close();
                webDriver.Quit();
                //webDriver.Dispose();*/
            }
            
        }
        private void GirisYap()
        {
            ChromeAyarları();

            webDriver.Navigate().GoToUrl("https://www.instagram.com");
            Thread.Sleep(random.Next(1000, 2000));

            var kullaniciAdi = webDriver.FindElement(By.CssSelector(CssSelectorler.GirisEkrani.kullaniciAdiText)); 
            var parola = webDriver.FindElement(By.CssSelector(CssSelectorler.GirisEkrani.sifreText));

            kullaniciAdi.SendKeys(Secimler.GirisBilgileri.kullaniciAdi);

            parola.SendKeys(Secimler.GirisBilgileri.sifre); //Buraya süre eklene bilir şifreyi yazınca direk enter tuşuna basıyor
            parola.SendKeys(OpenQA.Selenium.Keys.Enter);

            if (webDriver.Url== "https://www.instagram.com/accounts/login/two_factor?next=%2F") //2 adımlı doğrulama varsa
            {
                Thread.Sleep(random.Next(1000, 2000));
                var guvenlikMsjText = webDriver.FindElement(By.CssSelector(CssSelectorler.GirisEkrani.guvenlikMsjText));

                Application.OpenForms[0].Activate();

                string IsimGirisi = Interaction.InputBox("Bilgi Girişi", "Adınızı Giriniz.");
                guvenlikMsjText.SendKeys(IsimGirisi);

                Thread.Sleep(1000);
                guvenlikMsjText.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
            Thread.Sleep(random.Next(1000, 2000));

            var bilgi = webDriver.FindElement(By.CssSelector(CssSelectorler.GirisEkrani.bilgiButton));
            bilgi.Click();
            Thread.Sleep(random.Next(1000, 2000));

            var bildirimleriAc = webDriver.FindElement(By.CssSelector(CssSelectorler.GirisEkrani.bildirimleriAcButton));
            bildirimleriAc.Click();

            Thread.Sleep(random.Next(1000, 2000));

        }
        private void AnaSayfaBegen() // sorunları var kontrol ettt 
        {
            Thread.Sleep(random.Next(1000, 2000));
            string isim;

            int beğeniSayisi = 0;
            int Sayac = 20;
            IWebElement begeni;
            List<IWebElement> gonderiler = new List<IWebElement>();

            try
            {
                gonderiler.AddRange(webDriver.FindElements(By.CssSelector(CssSelectorler.AnaSayfaBegen.gonderiler))); // gönderileri aldık
                while (true)
                {
                //Beğendiklerini bir kez daha atayınca ifin istündeki dizinde sorun çıkarıyor o yüzden beğendiğin kısımları döngüye sokmican
                Git0:
                    foreach (var item in gonderiler)
                    {
                        Thread.Sleep(random.Next(Secimler.Sureler.minBegen, Secimler.Sureler.maxBegen));
                        begeni = item.FindElement(By.CssSelector(CssSelectorler.AnaSayfaBegen.begeniClass)); // Paylaşımın altındaki paylaşının adına tıklıyor sorunu çöz
                        if (begeni.FindElement(By.TagName("svg")).GetAttribute("aria-label") == "Like") //Gönderinin like kısmını kontrol eden kısım "fr66n" svg nin iki üstündeki dizin
                        {
                            begeni.FindElement(By.TagName("button")).Click(); //Gönderiyi Beğeniyor

                            isim = item.FindElement(By.CssSelector(CssSelectorler.AnaSayfaBegen.isimClasi)).GetAttribute("text"); //Gönderiyi paylaşan hesabın adı

                            Bilgi = beğeniSayisi.ToString() + " ->" + isim + "---Beğenildi";
                            VeriHazir();

                            beğeniSayisi++;
                        }
                    }
                    if (beğeniSayisi >= Sayac)
                    {
                        break;
                    }
                    else // burada scrol aşağı indikçe "article" yani gönderiler maxsimim 8 adet oluyor ve bunun ilk 4 ü bizim beğendiğimiz onları eklemiyoruz
                    {
                        gonderiler.Clear();
                        for (int i = 3; i < webDriver.FindElements(By.CssSelector(CssSelectorler.AnaSayfaBegen.gonderiler)).Count; i++)
                        {
                            gonderiler.Add(webDriver.FindElements(By.CssSelector(CssSelectorler.AnaSayfaBegen.gonderiler))[i]);
                        }
                        goto Git0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void YorumYapBegen() 
        {
            IWebElement metinKutusu;
            IWebElement begenButonu;

            string bilgi="",yorumYapaninAdi,paylasan = "";

            try
            {
                for (int i = 0; i < 5 && paylasimLinki.Count > 0; i++)
                {
                    webDriver.Navigate().GoToUrl(paylasimLinki[0]);
                    paylasimLinki.RemoveAt(0); // hep listenin ilk değerine gidiyor ve gittiği değeri siliyor

                    Thread.Sleep(random.Next(1000, 2000));

                    paylasan = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.paylasan)).GetAttribute("textContent"); // <a> etiketin classı ile aldık 

                    if (Secimler.Begen.begenecekMi)
                    {
                        begenButonu = webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.begeniButonu));
                        string begenilmisMi = begenButonu.FindElement(By.TagName("svg")).GetAttribute("ariaLabel").ToString(); // gönderi önceden beğenildiyse unlike değerini yazar
                        if (begenilmisMi == "Like" || begenilmisMi == "Beğen")
                        {
                            begenButonu.Click();
                            Thread.Sleep(random.Next(Secimler.Sureler.minBegen, Secimler.Sureler.maxBegen));
                            bilgi = " Beğenildi ve";
                        }
                        else
                            bilgi = "";
                    }

                    // gönderi yoruma açık değilse null değeri döndürüyor
                    if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.YorumyapBegen.yorumYapma + "')") != null)
                    {
                        metinKutusu = webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.yorumYeri)).FindElement(By.TagName("textarea")); // yorum yerine tıklayınca text kısmı açılıyor o yüzden iki kere tanımlıyoruz
                        metinKutusu.Click();
                        Thread.Sleep(random.Next(200, 300));
                        metinKutusu = webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.yorumYeri)).FindElement(By.TagName("textarea"));
                        metinKutusu.SendKeys(Secimler.YapilacakYorumlar[random.Next(Secimler.YapilacakYorumlar.Count - 1)]); // Yorumlar arasında rasgele yorum seçiyor
                        Thread.Sleep(random.Next(300, 500));
                        webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.yorumYeri)).FindElement(By.TagName("button")).Click(); // bunu post tuşu ile yap
                        bilgi += " Yorum yapıldı.";
                    }

                    //Yorum yapan varsa yapanların linkini alır
                    if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.YorumyapBegen.yorumYapanlar + "')") != null)
                    {
                        if (Secimler.TakipEt.takipEdicekMi) //Takip edileceklerin hesap adını alındığı kısım
                        {
                            foreach (var yorumYapanlar in webDriver.FindElements(By.CssSelector(CssSelectorler.YorumyapBegen.yorumYapanlar)))
                            {
                                yorumYapaninAdi = yorumYapanlar.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.yorumyapanınAdi)).GetAttribute("href").ToString();

                                if (!VeriHavuzu.TakipEdilecekler.Contains(yorumYapaninAdi)) //"Contains()" ilestede öyle bir değer varsa true döndürüyor
                                {
                                    VeriHavuzu.TakipEdilecekler.Add(yorumYapaninAdi);
                                }

                            }
                        }
                    }

                    Bilgi = paylasan + bilgi;
                    VeriHazir();

                    if (Secimler.ResimAl.resimAlsinMi)
                    {
                        ResimVideoLinkAl();
                    }

                    Thread.Sleep(random.Next(Secimler.Sureler.minYorum, Secimler.Sureler.maxYorum));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TakipEt()
        {
            
            int acikHesapSay = 0;
            int gizliHesapSay = 0;
            string kullaniciAdi;
            string gidilecekYer="";
            
            IWebElement anaDizin;
            try
            {
                for (int i = 0; i < 10 && VeriHavuzu.TakipEdilecekler.Count > 0; i++)
                {
                    gidilecekYer = VeriHavuzu.TakipEdilecekler[0];
                    VeriHavuzu.TakipEdilecekler.RemoveAt(0);

                    webDriver.Navigate().GoToUrl(gidilecekYer);
                    Thread.Sleep(random.Next(1000, 2000));

                    anaDizin = webDriver.FindElement(By.CssSelector(CssSelectorler.TakipEt.anaDizin)); // Kullanıcı hesap adının ve butonun olduğu dizin
                    kullaniciAdi = anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.kullaniciAdi)).GetAttribute("textContent").ToString();

                    //açık hesapları Follow Classı ile kapalıların farklı
                    if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.TakipEt.acikHesap + "')") != null && !Secimler.TakipEt.acikHesaplariTkpEtme) //Açık hesap
                    {
                        anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.acikHesap)).Click(); // Takip butonuna tıklandı

                        acikHesapSay++;
                        VeriHavuzu.TakipEdilenHesaplar.Add(new ListTakipBilgi() { hesap = gidilecekYer, hesapBilgisi = "Açık" }); //VeriTabanina takip edilen hesabın linkini ve gizlimi açıkmı onun bilgisi aktarmak için yeni bir class yaptım ve new dememin sebebi listedeki  eklene değişkenin değerini en son ne yaparsak tüm değişkenler o oluyor
                        Bilgi = kullaniciAdi + " Takip isteği gönderildi.";
                        VeriHazir();
                    }
                    else if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.TakipEt.gizliHesap + "')") != null) // Gizli Hesap
                    {
                        anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.gizliHesap)).Click(); // Takip butonuna tıklandı

                        gizliHesapSay++;
                        VeriHavuzu.TakipEdilenHesaplar.Add(new ListTakipBilgi() { hesap = gidilecekYer, hesapBilgisi = "Gizli" }); //VeriTabanina takip edilen hesabın linkini ve gizlimi açıkmı onun bilgisi aktarmak için yeni bir class yaptım ve new dememin sebebi listedeki  eklene değişkenin değerini en son ne yaparsak tüm değişkenler o oluyor
                        Bilgi = kullaniciAdi + " Takip isteği gönderildi.";
                        VeriHazir();
                    }
                    Thread.Sleep(random.Next(Secimler.Sureler.minYorum, Secimler.Sureler.maxYorum));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                VeriTabani.TakipEdilenKaydet(); //Takip edilen hesapları kaydettiğimiz yer
            }
        }
        private void TakiptenCik()
        {
            int cikarilanHesapSayisi = 0;
            string hesapAdi="";
            IWebElement button, hesapDizini;
            BasaGit:
            webDriver.Navigate().GoToUrl("https://www.instagram.com/" + Secimler.GirisBilgileri.kullaniciAdi);
            Thread.Sleep(random.Next(1000, 2000));
            webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.takipEdilenler)).Click(); //Takip edilenler kısmı

            hesapDizini = webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.hesapDizini)); // Kullanıcıları olduğu dizinin üstü

            List<IWebElement> hesaplar = new List<IWebElement>();
            hesaplar.AddRange(hesapDizini.FindElements(By.TagName("li")));


            foreach (var item in hesaplar)
            {
                if (js.ExecuteScript("return document.querySelector('"+CssSelectorler.TakiptenCikma.acilanEkran+"')") != null)
                {
                    button = item.FindElement(By.TagName("button"));
                    hesapAdi = item.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.hesapAdi)).GetAttribute("title"); //Hesap isiminin yazdığı <a> etiketinin clası
                    if (button.GetAttribute("textContent") == "Following")
                    {
                        button.Click();
                        webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.silmeButonu)).Click(); // Takipten çıkma tuşu
                        cikarilanHesapSayisi++;
                        Bilgi = hesapAdi + "  Takipten Çıkarıldı.";
                        VeriHazir();
                        Thread.Sleep(random.Next(Secimler.Sureler.minTakipEtCik, Secimler.Sureler.maxTakipEtCik));
                    }
                }
                else
                    goto BasaGit;

                if (cikarilanHesapSayisi == 10)
                {
                    break;
                }
            }
        }
        private void IstekKontrol() 
        {
            VeriTabani.IstekAtilanHesaplar();
            if (VeriHavuzu.IstekAtilanHesaplar.Count>0)
            {
                IWebElement silmeButonu;
                IWebElement begenButonu;
                foreach (var item in VeriHavuzu.IstekAtilanHesaplar)
                {
                    if (item.hesapBilgisi=="Açık")
                    {
                        webDriver.Navigate().GoToUrl(item.hesap);
                        if (js.ExecuteScript("return document.querySelector('"+CssSelectorler.IstekKontrol.AtakiptenCik+"')") != null) //nesnenin olup olmadığını kontrol ediyoruz
                        {
                            silmeButonu = webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.AtakiptenCik)); // Mesaj butonunun yanındaki takipten çıkarma ana butonu
                            silmeButonu.Click();
                            silmeButonu = webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.onayButonu)); // takipten çıkma onay butonu
                            silmeButonu.Click();

                            Bilgi = item.hesap + " --- çıkarıldı";
                            VeriHazir();

                            VeriHavuzu.SilinecekIstekIdler.Add(item.id);
                        }
                        else // takip et yazıyorsada VeriTabaninda silinsin
                            VeriHavuzu.SilinecekIstekIdler.Add(item.id);
                    }
                    else // Gizli hesaplar
                    {
                        webDriver.Navigate().GoToUrl(item.hesap);
                        if (js.ExecuteScript("return document.querySelector('"+ CssSelectorler.IstekKontrol.GtakiptenCik + "')") != null) // Eğer kabul ettiyse isteği geri çekme butonu olmaz
                        {
                            silmeButonu = webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.GtakiptenCik)); // Mesaj butonunun yanındaki takipten çıkarma ana butonu
                            silmeButonu.Click();
                            silmeButonu = webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.onayButonu)); // takipten çıkma butonu
                            silmeButonu.Click();

                            Bilgi = item.hesap + " --- çikarıldı";
                            VeriHazir();
                            VeriHavuzu.SilinecekIstekIdler.Add(item.id);
                        }
                        else
                        {
                            VeriHavuzu.SilinecekIstekIdler.Add(item.id);
                            if (js.ExecuteScript("return document.querySelector('"+ CssSelectorler.IstekKontrol.istekKabul + "')")!=null) //takip isteğini kabul etmiş
                            {
                                if (js.ExecuteScript("return document.querySelector('"+ CssSelectorler.IstekKontrol.gonderi + "')") != null) //Sayfada bir gönderi varsa boş dönmez
                                {
                                    webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.gonderi)).Click();

                                    for (int i = 0; i < 2; i++)// paylaşımlarını beğenme
                                    {
                                        begenButonu = webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.begenButon));
                                        begenButonu.Click();
                                        Thread.Sleep(500);
                                        if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.IstekKontrol.ileriButon + "')") != null) // bir sonraki resim butonu varmı (yorumyapla aynı css)
                                        {
                                            webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.ileriButon)).Click(); // bir sonraki gödneri (yorumyapla aynı css)
                                            
                                        }

                                    }

                                }
                            }
                            
                        }
                        
                    }
                    Thread.Sleep(random.Next(Secimler.Sureler.minTakipEtCik, Secimler.Sureler.maxTakipEtCik));
                }

                VeriTabani.IstekleriSil();
            }
        }
        private void ResimVideoLinkAl()
        {
            Thread.Sleep(500);
            webDriver.Navigate().GoToUrl("https://www.instagram.com/explore/tags/keşfet/");
            Thread.Sleep(800);

            List<IWebElement> gonderiler = new List<IWebElement>(); // Gonderileri almak ve üzerinde işlem yapabilmek için
            List<string> paylasimLinki = new List<string>();
            string link="", aciklama="",paylasan,tur="",anaLink;
            bool gir = false;

            try
            {
                gonderiler.AddRange(webDriver.FindElements(By.CssSelector(CssSelectorler.LinkAl.gonderiler))); // gonderileri class ile aldık 

                foreach (var item in gonderiler)
                {
                    paylasimLinki.Add(item.FindElement(By.TagName("a")).GetAttribute("href"));
                }

                foreach (var item in paylasimLinki)
                {
                    webDriver.Navigate().GoToUrl(item);

                    if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.LinkAl.ileri + "')") != null) //Bİr sonraki resim butonu demekki Albüm(Resim,Resim veya Video,Resim,....)
                    {
                        //Burada albumdeki linkleri aldık ve linklerin resim mi video mu ayırtını yaptık
                        //gerekli veriler <li> değerinde
                        //sayfa yüklenince standart iki li geliyor ilk önce for ile ordaki değerleri aldık
                        //sonra bir sonraki tuşuna bastık ve bir tane daha <li> eklendi maxsimum 3 li oluyor ve while da onunkini alıyoruz
                        //whilin algoritması bir sonraki tuş varsa son yani 3. <li> yi alıyor eğer yoksa yani bittiyse <li> sayısı 2 oluyor
                        //biz bir sonraki gönderiyi gelmeden ekrana linki aldığımızdan ileri tuşu bitince while dan çıkıyoruz

                        //sayfanın linkindeki p bibi sağındaki gönderi id ile albumleri ayırt edeblirsin
                        for (int i = 0; i < 2; i++)
                        {
                            if (js.ExecuteScript("return document.querySelectorAll('" + CssSelectorler.LinkAl.liClass + "')[" + i.ToString() + "].querySelector('" + CssSelectorler.LinkAl.resim + "')") != null) // Resim
                            {
                                link = webDriver.FindElements(By.CssSelector(CssSelectorler.LinkAl.liClass))[i].FindElement(By.TagName("img")).GetAttribute("currentSrc"); // resimin linki
                                tur = "Resim";
                            }
                            else if (js.ExecuteScript("return document.querySelectorAll('" + CssSelectorler.LinkAl.liClass + "')[" + i.ToString() + "].querySelector('" + CssSelectorler.LinkAl.video + "')") != null) // video
                            {
                                link = webDriver.FindElements(By.CssSelector(CssSelectorler.LinkAl.liClass))[i].FindElement(By.CssSelector(CssSelectorler.LinkAl.video)).GetAttribute("currentSrc"); // Video linki
                                tur = "Video";
                            }
                            anaLink = item;

                            if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.LinkAl.aciklama + "')") != null) // Açıklama yapmış mı
                                aciklama = webDriver.FindElement(By.TagName(CssSelectorler.LinkAl.aciklama)).FindElements(By.TagName("span"))[1].GetAttribute("textContent"); // açıklamanın olduğu yer(<span>)
                            else
                                aciklama = "Yok";

                            paylasan = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.paylasan)).GetAttribute("textContent"); // <a> etiketin classı ile aldık 
                            VeriHavuzu.AlinanResimVidoe.Add(new ListAlinanResimVideo() { link = link, aciklama = aciklama, tur = tur, paylasan = paylasan, anaLink = anaLink });
                        }

                        while (true)
                        {
                            webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.ileri)).Click();
                            Thread.Sleep(500);
                            if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.LinkAl.ileri + "')") != null)
                            {
                                if (js.ExecuteScript("return document.querySelectorAll('" + CssSelectorler.LinkAl.liClass + "')[2].querySelector('" + CssSelectorler.LinkAl.resim + "')") != null) // Resim
                                {
                                    link = webDriver.FindElements(By.CssSelector(CssSelectorler.LinkAl.liClass))[2].FindElement(By.TagName("img")).GetAttribute("currentSrc"); // resimin linki
                                    tur = "Resim";
                                }
                                else if (js.ExecuteScript("return document.querySelectorAll('" + CssSelectorler.LinkAl.liClass + "')[2].querySelector('" + CssSelectorler.LinkAl.video + "')") != null) // video
                                {
                                    link = webDriver.FindElements(By.CssSelector(CssSelectorler.LinkAl.liClass))[2].FindElement(By.CssSelector(CssSelectorler.LinkAl.video)).GetAttribute("currentSrc"); // Video linki
                                    tur = "Video";
                                }

                                anaLink = item;

                                if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.LinkAl.aciklama + "')") != null) // Açıklama yapmış mı
                                    aciklama = webDriver.FindElement(By.TagName(CssSelectorler.LinkAl.aciklama)).FindElements(By.TagName("span"))[1].GetAttribute("textContent"); // açıklamanın olduğu yer(<span>)
                                else
                                    aciklama = "Yok";

                                paylasan = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.paylasan)).GetAttribute("textContent"); // <a> etiketin classı ile aldık 
                                VeriHavuzu.AlinanResimVidoe.Add(new ListAlinanResimVideo() { link = link, aciklama = aciklama, tur = tur, paylasan = paylasan, anaLink = anaLink });
                            }
                            else
                            {
                                gir = false; // bunun sebebi albumleri kaydederken son paylaşımı iki kez yazıyor eper buraya girdiyse alttaki kaydetmeye girmicek çünkü yukarıda kaydedildi
                                break;
                            }
                        }
                    }
                    else
                    {
                        gir = true;
                        if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.LinkAl.video + "')") != null) // video clası
                        {
                            if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.LinkAl.playTusu + "')") != null)// Video (".PyenC") videonun ortasındaki play tuşu
                            {
                                link = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.video)).GetAttribute("currentSrc"); // Video linki
                                tur = "Video";
                            }
                            else // Igtv 60 sniyeden uzun olan videolarda videonun ortasında play tuşu olmuyor
                            {
                                link = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.video)).GetAttribute("currentSrc"); // Video linki
                                tur = "Igtv";

                            }
                        }
                        else // Resim 
                        {
                            link = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.resim)).FindElement(By.TagName("img")).GetAttribute("currentSrc"); // resimin linki
                            tur = "Resim";

                        }
                    }
                    if (gir)
                    {
                        anaLink = item;

                        if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.LinkAl.aciklama + "')") != null) // Açıklama yapmış mı
                            aciklama = webDriver.FindElement(By.TagName(CssSelectorler.LinkAl.aciklama)).FindElements(By.TagName("span"))[1].GetAttribute("textContent"); // açıklamanın olduğu yer(<span>)
                        else
                            aciklama = "Yok";

                        paylasan = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.paylasan)).GetAttribute("textContent"); // <a> etiketin classı ile aldık 
                        VeriHavuzu.AlinanResimVidoe.Add(new ListAlinanResimVideo() { link = link, aciklama = aciklama, tur = tur, paylasan = paylasan, anaLink = anaLink });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            VeriTabani.ResimVideoLinkiKaydet();
        }
        private void PaylasimLinkiAl()
        {
            List<string> ilkBakilacaklar = new List<string>();
            List<string> sonBakilacaklar = new List<string>();

            int alinacakLinkSayisi;

            if ((Secimler.YorumYap.yorumSayisi / Secimler.GidilecekYer.Count) <= 25) // Burada kaçtane link varsa her birinden alınacak gönderi sayısını belirledik
            {
                alinacakLinkSayisi = (Secimler.YorumYap.yorumSayisi / Secimler.GidilecekYer.Count);
            }
            else
                alinacakLinkSayisi = 25;

            Thread.Sleep(500);

            for (int i = 0; i < Secimler.GidilecekYer.Count; i++)
            {
                webDriver.Navigate().GoToUrl(Secimler.GidilecekYer[i]);
                Thread.Sleep(1000);

                foreach (var item in webDriver.FindElements(By.CssSelector(CssSelectorler.YorumyapBegen.gonderiler))) // Hashtag deki gönderi aldık
                {
                    if ((ilkBakilacaklar.Count + sonBakilacaklar.Count) < (alinacakLinkSayisi * (i + 1))) // her hashtag den belirlenen sayı kadar almak için kontrol
                    {
                        if (ilkBakilacaklar.Count <= (9 * (i + 1)))// burada ilk 9 yani popüler olanları aldık
                            ilkBakilacaklar.Add(item.FindElement(By.TagName("a")).GetAttribute("href"));
                        else
                            sonBakilacaklar.Add(item.FindElement(By.TagName("a")).GetAttribute("href"));
                    }

                }

            }

            paylasimLinki.AddRange(ilkBakilacaklar);
            paylasimLinki.AddRange(sonBakilacaklar);
        }
    }
}

