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
        ToplananVeriler ToplananVeriler = ToplananVeriler.GetInstance();
        
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
        public void IslemSec() 
        {
            Thread thread = new Thread(new ThreadStart(Basla));
            thread.Start();
            
        }

        [Obsolete]
        private void Basla() 
        {
            GirisYap();
            YorumYapBegen();
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

            webDriver.Manage().Window.Size = new Size(1200, 900);
        }
        public void SeleniumKapat()
        {
            webDriver.Dispose();
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
        private void AnaSayfaBegen()
        {
            Thread.Sleep(1000);
            
            string isim;

            var gonderiDizini = bekle.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorler.AnaSayfaBegen.gonderiDizini))); // Gönderilerin Yüklendiği Dizin
            int beğeniSayisi=0;
            IWebElement begeni;
            while (true)
            {
                
                foreach (var item in gonderiDizini.FindElements(By.TagName("article"))) // Gönderileri dizinden alıyor
                {
                    begeni = bekle.Until(ExpectedConditions.ElementToBeClickable(item.FindElement(By.ClassName(CssSelectorler.AnaSayfaBegen.begeniDizini)))); //Beğeni kısmının sayfada yüklenmediyse belirli süre bekler yüklesin diye süreyi aşarsa hata verir

                    if (begeni.FindElement(By.TagName("svg")).GetAttribute("aria-label") == "Like") //Gönderinin like kısmını kontrol eden kısım "fr66n" svg nin iki üstündeki dizin
                    {
                        begeni.FindElement(By.TagName("button")).Click(); //Gönderiyi Beğeniyor

                        Thread.Sleep(500);
                        isim = item.FindElement(By.CssSelector(CssSelectorler.AnaSayfaBegen.isimClasi)).GetAttribute("text"); //Gönderiyi paylaşan hesabın adı

                        Bilgi = beğeniSayisi .ToString()+ " ->" + isim+"---Beğenimldi";
                        VeriHazir();
                        
                        beğeniSayisi++;
                    }                    
                    if (beğeniSayisi==15)
                    {
                        break;
                    }
                }

                if (beğeniSayisi==15)
                {
                    break;
                }
                js.ExecuteScript("window.scrollBy(0, 1000)");
                Thread.Sleep(900);
            }
            
        }

        [Obsolete]
        private void TakiptenCik()
        {
            Thread.Sleep(500);
            webDriver.Navigate().GoToUrl("https://www.instagram.com/" + KullaniciSecimleri.GirisBilgileri.kullaniciAdi);
            var btnTakip = bekle.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorler.TakiptenCikma.takipEdilenler)));
            btnTakip.Click();

            var takipDizini = bekle.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorler.TakiptenCikma.takipDizini)));
            var hesapDizini = takipDizini.FindElement(By.ClassName(CssSelectorler.TakiptenCikma.hesapDizini)); // Kullanıcıları olduğu dizinin üstü

            List<IWebElement> hesaplar = new List<IWebElement>();
            hesaplar.AddRange(hesapDizini.FindElements(By.TagName("li")));


            int cikarilanHesapSayisi = 0;
            IWebElement button;
            IWebElement cikButonu;
            BasaGit:
            foreach (var item in hesaplar)
            {
                button = item.FindElement(By.TagName("button"));
                if (button.GetAttribute("textContent") == "Following")
                {
                    button.Click();
                    Thread.Sleep(700);
                    cikButonu = webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.silmeButonu));
                    cikButonu.Click();
                    Thread.Sleep(700);
                    cikarilanHesapSayisi++;
                    Bilgi = cikarilanHesapSayisi.ToString() + " - Takipten Çıkıldı";
                    VeriHazir();
                }
                if (cikarilanHesapSayisi%4==0)
                {
                    js.ExecuteScript("document.querySelector('.isgrP').scrollBy(0, 200)");
                    Thread.Sleep(700);
                }
                if (cikarilanHesapSayisi >= 150)
                {
                    break;
                }
            }

            if (cikarilanHesapSayisi<150)
            {
                hesaplar.Clear();
                for (int i = cikarilanHesapSayisi-1; i < hesapDizini.FindElements(By.TagName("li")).Count; i++) // Çıkarılan hesapları ayıklıyoruz
                {
                    hesaplar.Add(hesapDizini.FindElements(By.TagName("li"))[i]);
                }
                goto BasaGit;
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
                string hazirmi = js.ExecuteScript("return document.querySelector('body > div._2dDPU.CkGkG')").ToString(); //gönderiye tıklayınca çıkan ekran açık değilse None dönüyor

                if (hazirmi == "None")
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
                if (begenilmisMi=="Like")
                {
                    string yorumaAcikmi = js.ExecuteScript("return document.querySelector('.sH9wk._JgwE')").ToString(); // gönderi yoruma açık değilse None değeri döndürüyor
                    if (yorumaAcikmi != "None")
                    {
                        yorumYeri = webDriver.FindElement(By.ClassName(CssSelectorler.YorumyapBegen.yorumYeri)); // yorum yerine tıklayınca text kısmı açılıyor o yüzden iki kere tanımlıyoruz
                        yorumYeri.Click();
                        Thread.Sleep(500);
                        yorumYeri = webDriver.FindElement(By.ClassName("Ypffh"));
                        yorumYeri.SendKeys("Bir çiftçi ailesi"); // yorumda yazılacak kısım
                        if (takipEdilecek) //Takip edileceklerin hesap adını alındığı kısım
                        {
                            foreach (var item in webDriver.FindElements(By.ClassName(CssSelectorler.YorumyapBegen.yorumYapanlar)))
                            {
                                yorumYapaninAdi= item.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.yorumyapanınAdi)).GetAttribute("href").ToString();
                                ToplananVeriler.TakipEdilecekler.Add(yorumYapaninAdi);
                                Bilgi = yorumYapaninAdi;
                                VeriHazir();
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


            } while (yorumSayisi<1);
            TakipEt();
        }

        private void TakipEt()
        {
            
            int acikHesapSay = 0;
            int gizliHesapSay = 0;
            string kullaniciAdi;
            List<string> TakipEdilenHesaplar = new List<string>();
            IWebElement anaDizin;

            foreach (var item in ToplananVeriler.TakipEdilecekler)
            {
                webDriver.Navigate().GoToUrl(item);
                Thread.Sleep(500);

                anaDizin = webDriver.FindElement(By.CssSelector(CssSelectorler.TakipEt.anaDizin)); // Kullanıcı hesap adının ve butonun olduğu dizin
                kullaniciAdi = anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.kullaniciAdi)).GetAttribute("textContent").ToString();

                //açık hesapları Follow Classı ile kapalıların farklı
                if (js.ExecuteScript("return document.querySelector('._5f5mN.jIbKX._6VtSN.yZn4P')") != null) //Açık hesap
                {
                    anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.acikHesap)).Click(); // Takip butonuna tıklandı
                    Thread.Sleep(500);
                    acikHesapSay++;
                    TakipEdilenHesaplar.Add(item);
                    Bilgi = kullaniciAdi + " Takip isteği gönderildi.";
                    VeriHazir();
                }
                else if(js.ExecuteScript("return document.querySelector('.BY3EC.sqdOP.L3NKy.y3zKF')") != null) // Gizli Hesap
                {
                    anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.gizliHesap)).Click(); // Takip butonuna tıklandı
                    Thread.Sleep(500);
                    gizliHesapSay++;
                    TakipEdilenHesaplar.Add(item);
                    Bilgi = kullaniciAdi + " Takip isteği gönderildi.";
                    VeriHazir();
                }
            }

            

        }
    }
}

