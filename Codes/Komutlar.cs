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
        KullaniciSecimleri KullaniciSecimleri = KullaniciSecimleri.GetInstance();
        VeriHavuzu VeriHavuzu = VeriHavuzu.GetInstance();
        VeriTabani VeriTabani = VeriTabani.GetInstance();

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
        public void Baslat() 
        {
            Thread thread = new Thread(new ThreadStart(Basla));
            thread.Start();
            
        }

        [Obsolete]
        private void Basla() 
        {
            GirisYap();
            AnaSayfaBegen();
        }
        //Css selector ile element varmı yokmu kontrolu
        private bool Yuklendimi(string elementName)
        {
            try { webDriver.FindElement(By.CssSelector(elementName)); }
            catch (NoSuchElementException) { return false; }
            catch (StaleElementReferenceException) { return false; }
            return true;
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
        [Obsolete]
        private void GirisYap()
        {
            ChromeAyarları();

            webDriver.Navigate().GoToUrl("https://www.instagram.com");

            var kullaniciAdi = bekle.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorler.GirisEkrani.kullaniciAdiText))); //Elementi yüklendiyse alır yüklenmediyse sayfa bekler
            var parola = bekle.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorler.GirisEkrani.sifreText)));

            kullaniciAdi.SendKeys(KullaniciSecimleri.GirisBilgileri.kullaniciAdi);

            parola.SendKeys(KullaniciSecimleri.GirisBilgileri.sifre); //Buraya süre eklene bilir şifreyi yazınca direk enter tuşuna basıyor
            parola.SendKeys(OpenQA.Selenium.Keys.Enter);

            if (webDriver.Url== "https://www.instagram.com/accounts/login/two_factor?next=%2F") //2 adımlı doğrulama varsa
            {
                var guvenlikMsjText = bekle.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorler.GirisEkrani.guvenlikMsjText)));

                Application.OpenForms[0].Activate();

                string IsimGirisi = Interaction.InputBox("Bilgi Girişi", "Adınızı Giriniz.");
                guvenlikMsjText.SendKeys(IsimGirisi);

                Thread.Sleep(1000);
                guvenlikMsjText.SendKeys(OpenQA.Selenium.Keys.Enter);
            }

            var bilgi = bekle.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorler.GirisEkrani.bilgiButton)));
            bilgi.Click();

            var bildirimleriAc = bekle.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorler.GirisEkrani.bildirimleriAcButton)));
            bildirimleriAc.Click();

            Thread.Sleep(1000);
            
        }

        [Obsolete]
        private void AnaSayfaBegen() // sorunları var kontrol ettt 
        {
            Thread.Sleep(1000);
            Random random = new Random();
            string isim;

            int beğeniSayisi = 0;
            IWebElement begeni;
            List<IWebElement> gonderiler = new List<IWebElement>();

            gonderiler.AddRange(webDriver.FindElements(By.CssSelector(CssSelectorler.AnaSayfaBegen.gonderiler))); // gönderileri aldık
            while (true)
            {
            //Beğendiklerini bir kez daha atayınca ifin istündeki dizinde sorun çıkarıyor o yüzden beğendiğin kısımları döngüye sokmican
            Git0:
                foreach (var item in gonderiler)
                {
                    Thread.Sleep(800);
                    begeni = item.FindElement(By.CssSelector(CssSelectorler.AnaSayfaBegen.begeniClass));
                    if (begeni.FindElement(By.TagName("svg")).GetAttribute("aria-label") == "Like") //Gönderinin like kısmını kontrol eden kısım "fr66n" svg nin iki üstündeki dizin
                    {
                        begeni.FindElement(By.TagName("button")).Click(); //Gönderiyi Beğeniyor

                        isim = item.FindElement(By.CssSelector(CssSelectorler.AnaSayfaBegen.isimClasi)).GetAttribute("text"); //Gönderiyi paylaşan hesabın adı

                        Bilgi = beğeniSayisi.ToString() + " ->" + isim + "---Beğenildi";
                        VeriHazir();

                        beğeniSayisi++;
                    }
                }
                if (beğeniSayisi >= 50)
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

        [Obsolete]
        private void TakiptenCik()
        {
            int cikarilanHesapSayisi = 0;
            IWebElement button, btnTakip, takipDizini, hesapDizini;
            IWebElement cikButonu;

            Thread.Sleep(500);
            webDriver.Navigate().GoToUrl("https://www.instagram.com/" + KullaniciSecimleri.GirisBilgileri.kullaniciAdi);
            btnTakip = webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.takipEdilenler));
            btnTakip.Click();

            takipDizini = webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.takipDizini));
            hesapDizini = takipDizini.FindElement(By.ClassName(CssSelectorler.TakiptenCikma.hesapDizini)); // Kullanıcıları olduğu dizinin üstü

            List<IWebElement> hesaplar = new List<IWebElement>();
            hesaplar.AddRange(hesapDizini.FindElements(By.TagName("li")));


            foreach (var item in hesaplar)
            {
                button = item.FindElement(By.TagName("button"));
                if (button.GetAttribute("textContent") == "Following")
                {
                    button.Click();
                    Thread.Sleep(500);
                    cikButonu = webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.silmeButonu));
                    cikButonu.Click();
                    Thread.Sleep(1000);
                    cikarilanHesapSayisi++;
                    Bilgi = cikarilanHesapSayisi.ToString() + " - Takipten Çıkıldı";
                    VeriHazir();
                }
                if (cikarilanHesapSayisi%4==0)
                {
                    js.ExecuteScript("document.querySelector('.isgrP').scrollBy(0, 200)");
                    Thread.Sleep(700);
                }
                /*if (cikarilanHesapSayisi % 5==0)
                {
                    webDriver.Navigate().Refresh();
                    Thread.Sleep(2000);
                    hesaplar.Clear();
                    goto BasaGit;

                }*/
                if (cikarilanHesapSayisi >= 10)
                {
                    break;
                }
            }
        }

        private void YorumYapBegen() 
        {
            
            Thread.Sleep(500);
            webDriver.Navigate().GoToUrl("https://www.instagram.com/explore/tags/doğadan/");
            Thread.Sleep(700);

            List<IWebElement> gonderiler = new List<IWebElement>();

            gonderiler.AddRange(webDriver.FindElements(By.CssSelector(CssSelectorler.YorumyapBegen.gonderiler))); //Hashtag deki yüklenen gönderileri aldık bunun ilk 9 u popüler olanlar
            
            int yorumSayisi = 0;
            int gonderiSayac = 0;
            int yuklendimi = 0;
            string yorumYapaninAdi;
            bool takipEdilecek = true;
            IWebElement yorumYeri;
            IWebElement begenButonu;
            gonderiler[gonderiSayac].Click();
            do
            {

            Git0:
                Thread.Sleep(500);

                if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.YorumyapBegen.gonderiEkrani + "')") != null) //gönderiye tıklayınca çıkan ekran açık değilse None dönüyor
                {
                    if (gonderiSayac < gonderiler.Count - 1)
                    {
                        gonderiler[gonderiSayac].Click();
                    }
                    else
                        break;
                    yuklendimi++;
                    if (yuklendimi<3) // Üç kere kontrol ediyor
                    {
                        goto Git0;
                    }
                }
                begenButonu = webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.begeniButonu));
                string begenilmisMi = begenButonu.FindElement(By.TagName("svg")).GetAttribute("ariaLabel").ToString(); // gönderi önceden beğenildiyse unlike değerini yazar
                if (begenilmisMi=="Like" )
                {
                    // gönderi yoruma açık değilse null değeri döndürüyor
                    if (js.ExecuteScript("return document.querySelector('"+CssSelectorler.YorumyapBegen.yorumYapma+"')") != null)
                    {
                        yorumYeri = webDriver.FindElement(By.ClassName(CssSelectorler.YorumyapBegen.yorumYeri)); // yorum yerine tıklayınca text kısmı açılıyor o yüzden iki kere tanımlıyoruz
                        yorumYeri.Click();
                        Thread.Sleep(500);
                        yorumYeri = webDriver.FindElement(By.ClassName(CssSelectorler.YorumyapBegen.yorumYeri));
                        yorumYeri.SendKeys("Bir çiftçi ailesi"); // yorumda yazılacak kısım
                        if (takipEdilecek) //Takip edileceklerin hesap adını alındığı kısım
                        {
                            foreach (var item in webDriver.FindElements(By.ClassName(CssSelectorler.YorumyapBegen.yorumYapanlar)))
                            {
                                yorumYapaninAdi= item.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.yorumyapanınAdi)).GetAttribute("href").ToString();

                                if (!VeriHavuzu.TakipEdilecekler.Contains(yorumYapaninAdi)) //"Contains()" ilestede öyle bir değer varsa true döndürüyor
                                {
                                    VeriHavuzu.TakipEdilecekler.Add(yorumYapaninAdi);
                                    Bilgi = yorumYapaninAdi;
                                    VeriHazir();
                                }
                                
                            }
                        }
                        Thread.Sleep(500);
                        yorumYeri.SendKeys(OpenQA.Selenium.Keys.Enter);
                        begenButonu.Click();

                        Thread.Sleep(800);
                        webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.ileriButonu)).Click(); // bir sonraki gödneri
                    }
                    else
                        webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.ileriButonu)).Click();
                    gonderiSayac++;
                    yorumSayisi++;
                }
                else
                    webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.ileriButonu)).Click(); // bir sonraki gödneri


            } while (yorumSayisi<3);
            TakipEt();
        }

        private void TakipEt()
        {
            
            int acikHesapSay = 0;
            int gizliHesapSay = 0;
            string kullaniciAdi;
            
            IWebElement anaDizin;

            foreach (var item in VeriHavuzu.TakipEdilecekler)
            {
                webDriver.Navigate().GoToUrl(item);
                Thread.Sleep(800);

                anaDizin = webDriver.FindElement(By.CssSelector(CssSelectorler.TakipEt.anaDizin)); // Kullanıcı hesap adının ve butonun olduğu dizin
                kullaniciAdi = anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.kullaniciAdi)).GetAttribute("textContent").ToString();

                //açık hesapları Follow Classı ile kapalıların farklı
                if (js.ExecuteScript("return document.querySelector('"+ CssSelectorler.TakipEt.acikHesap + "')") != null) //Açık hesap
                {
                    anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.acikHesap)).Click(); // Takip butonuna tıklandı
                    Thread.Sleep(800);
                    acikHesapSay++;
                    VeriHavuzu.TakipEdilenHesaplar.Add(new ListTakipBilgi() { hesap = item,hesapBilgisi="Açık"}); //VeriTabanina takip edilen hesabın linkini ve gizlimi açıkmı onun bilgisi aktarmak için yeni bir class yaptım ve new dememin sebebi listedeki  eklene değişkenin değerini en son ne yaparsak tüm değişkenler o oluyor
                    Bilgi = kullaniciAdi + " Takip isteği gönderildi.";
                    VeriHazir();
                }
                else if(js.ExecuteScript("return document.querySelector('"+ CssSelectorler.TakipEt.gizliHesap + "')") != null) // Gizli Hesap
                {
                    anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.gizliHesap)).Click(); // Takip butonuna tıklandı
                    Thread.Sleep(800);
                    gizliHesapSay++;
                    VeriHavuzu.TakipEdilenHesaplar.Add(new ListTakipBilgi() { hesap = item, hesapBilgisi = "Gizli" }); //VeriTabanina takip edilen hesabın linkini ve gizlimi açıkmı onun bilgisi aktarmak için yeni bir class yaptım ve new dememin sebebi listedeki  eklene değişkenin değerini en son ne yaparsak tüm değişkenler o oluyor
                    Bilgi = kullaniciAdi + " Takip isteği gönderildi.";
                    VeriHazir();
                }

                if (acikHesapSay+gizliHesapSay==40)
                {
                    break;
                }
            }

            VeriTabani.TakipEdilenEkle();

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
                            Thread.Sleep(800);
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
                            Thread.Sleep(800);
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
                                            Thread.Sleep(800);
                                        }

                                    }

                                }
                            }
                            
                        }
                        
                    }
                }

                VeriTabani.IstekleriSil();
            }
        }

        private void LinkAl()
        {
            Thread.Sleep(500);
            webDriver.Navigate().GoToUrl("https://www.instagram.com/explore/locations/1995587203866158/geyve-belediyesi-yoresel-urunler-uretim-merkezi/");
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
    }
}

