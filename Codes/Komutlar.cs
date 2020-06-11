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
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using InstaBot.Forms;
using InstaBot.Ob;
using OpenQA.Selenium.Support.UI;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace InstaBot.Codes
{
    class Komutlar :ISubject
    {
        IWebDriver webDriver;
        IJavaScriptExecutor js;
        WebDriverWait bekle;// Elemet yüklenmediyse beklenilecek süre

        CssSelectorler CssSelectorler = CssSelectorler.GetInstance();
        KullaniciSecimleri KullaniciSecimleri = KullaniciSecimleri.GetInstance();
        
        //ISubject İşlemleri
        private List<IObserver> _observers = new List<IObserver>(); // Veri lerin iletileceği Classlar
        public string Gelen { get; set ; }
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
            AnaSayfaBegen();
        }
        //Css selector ile element varmı yokmu kontrolu
        private bool IsElementPresent_byCssSelector(string elementName)
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
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //sayfanın yüklemesi için bekleniler süre
            js = webDriver as IJavaScriptExecutor;
            bekle = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            webDriver.Manage().Window.Size = new Size(1200, 900);
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
        }
        public string Bilgi { get; set; }

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

    }
}
