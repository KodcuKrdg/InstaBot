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
using InstaBot.Forms;
using InstaBot.Kullanicidan;

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

        ChromeDriver webDriver;
        IJavaScriptExecutor js;

        CssSelectorler CssSelectorler = CssSelectorler.GetInstance();
        KullaniciSecimleri Secimler = KullaniciSecimleri.GetInstance();
        VeriHavuzu VeriHavuzu = VeriHavuzu.GetInstance();
        VeriTabani VeriTabani = VeriTabani.GetInstance();
        AyarlarVeritabani AyarlarVeritabani = AyarlarVeritabani.GetInstance();

        Random random = new Random();
        private List<string> YapilacakYorumlar = new List<string>();

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
        private void ChromeAyarları()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true; //açılan cmd yi kapar
            ChromeOptions options = new ChromeOptions(); //Chrome ayarlamak için
            options.AddExcludedArgument("enable-automation"); //Üst paneldeki yazılım test yazısını kaldırır
            options.AddAdditionalCapability("useAutomationExtension", false);//Şifre katme popUp ı kapatır  
            options.AddUserProfilePreference("credentials_enable_service", false); //Şifre Kaydetmeme
            options.AddUserProfilePreference("profile.password_manager_enabled", false); //Şifre Kaydetmeme
            webDriver = new ChromeDriver(service, options);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //sayfanın yüklemesi için bekleniler süre
            js = webDriver as IJavaScriptExecutor;

            webDriver.Manage().Window.Maximize();
        }
        Thread ThYapilacaklar;
        public void Baslat() 
        {
            VeriHavuzu.PaylasimLinki.Clear(); 
            VeriHavuzu.TakipEdilecekler.Clear();
            YapilacakYorumlar.Clear();

            ThYapilacaklar = new Thread(Yapilacaklar);
            ThYapilacaklar.Start();
        }

        [Obsolete]
        public void Bitir()
        {
            try
            {
                if (ThYapilacaklar != null) // program açılıp direk pakatıldığında "ThYapilacaklar" bir değer atanmadığından hata veriyor
                {
                    if (ThYapilacaklar.IsAlive) // Eğer çalışıyorsa
                    {
                        ThYapilacaklar.Abort();
                        webDriver.Close();
                        webDriver.Quit();
                        // Kapatırken eğer kaydedilecek birşey kaldıysa kaydetsin
                        VeriTabani.TakipEdilenKaydet();
                        VeriTabani.IstekleriSil();
                        VeriTabani.ResimVideoLinkiKaydet();
                    }
                }
            }
            catch { }
            
        }

        [Obsolete]
        private void Yapilacaklar()
        {
            try
            {
                IslemSinirlari();
                GirisYap();
                do
                {
                    if (GirAnaSyBegen)
                    {
                        if (SayacAnaSyBegen > 0 && SayacBegen > 0)
                        {
                            AnaSayfaBegen();
                        }
                        else
                            GirAnaSyBegen = false;
                    }
                    //^^^^^^^^^^^^^^^^^Anasayfa Beğenme Kontrolleri

                    if (GirYorumYap)
                    {
                        if (SayacYorumYap > 0)
                        {
                            if (VeriHavuzu.PaylasimLinki.Count < 1)
                            {
                                if (Secimler.GidilecekYer.Count <= 0) // Eğer yapılan yorum sayısı yapılacak yorum sayısına gelmediyse sayac 0 dan büyük olucak fakat bakılacak paylaşım kalmıcak ve baştan tekrar paylaşım alıcak onu engellemek için
                                {
                                    GirYorumYap = false;
                                }
                                else
                                    PaylasimLinkiAl();
                            }
                            YorumYap();
                        }
                        else
                            GirYorumYap = false;
                    }
                    //^^^^^^^^^^^^^^^^^Yorum Yapma Kontrolleri

                    if (GirTakipEt)
                    {
                        if (SayacTakipEt > 0)
                        {
                            if (VeriHavuzu.TakipEdilecekler.Count <= 0)
                            {
                                if (Secimler.TakipEt.yorumlardanTkpEt)
                                {

                                    if (!Secimler.YorumYap.yorumYapacakMi) // Eğer yorum yapmıyacak ise gönderilere gidip yorum yapanların linkini alır
                                    {
                                        string sayfaLinki;
                                        if (Secimler.GidilecekYer.Count > 0) // Eğer bakılacak gödnerilerin linki alınmadıysa bu değer 0 dan büyük olucak ve her hashtag e gidildikçe gidilen siliniyor
                                            PaylasimLinkiAl();
                                        else // buraya ikinci kez girince yani tüm paylaşımlara bakmış ve takip atılan sayı yetmemiş ikinci kez girince çıkıyor
                                            GirTakipEt = false;
                                        for (int i = 0; i < 5 && VeriHavuzu.PaylasimLinki.Count > 0; i++)
                                        {

                                            sayfaLinki = VeriHavuzu.PaylasimLinki[0];
                                            VeriHavuzu.PaylasimLinki.RemoveAt(0); // hep listenin ilk değerine gidiyor ve gittiği değeri siliyor

                                            webDriver.Navigate().GoToUrl(sayfaLinki);
                                            Thread.Sleep(random.Next(1000, 2000));

                                            YorumYapanalariAl(); ///yorum yapanları alır

                                        }
                                    }
                                }

                                if (Secimler.TakipEt.takipEttiklerindenTkpEt)
                                {
                                    if (Secimler.GidilecekYer.Count > 0) // İlk defa alınacaksa Gidilecek yer olur ve alınıp yer silinir böylelikle tekrara düşmez
                                        TakipEttikleriniAl();
                                    else
                                        GirTakipEt = false;
                                }

                                if (Secimler.TakipEt.takipcilerdenTkpEt)
                                {
                                    if (Secimler.GidilecekYer.Count > 0) // İlk defa alınacaksa Gidilecek yer olur ve alınıp yer silinir böylelikle tekrara düşmez
                                        TakipcileriAl();
                                    else
                                        GirTakipEt = false;

                                }
                            }

                            TakipEt();

                        }
                        else
                            GirTakipEt = false;
                    }
                    //^^^^^^^^^^^^^^^^^Takip Etme Kontrolleri

                    if (GirTakiptenCik)
                    {
                        if (SayacTakiptenCik > 0)
                        {
                            TakiptenCik();
                        }
                        else
                            GirTakiptenCik = false;
                    }
                    //^^^^^^^^^^^^^^^^^Takip Çıkma Kontrolleri

                    if (GirIstekKontrol)
                    {
                        if (SayacIstekKontrol > 0)
                        {
                            IstekKontrol();
                        }
                        else
                            GirIstekKontrol = false;
                    }
                    //^^^^^^^^^^^^^^^^^Takip Kontrol Kontrolu
                } while (GirAnaSyBegen || GirYorumYap || GirTakipEt || GirTakiptenCik || GirIstekKontrol);

            }
            catch (Exception) { }
            finally
            {
                Bilgi = "Tüm işlemler bitmiştir.";
                VeriHazir();
                Bitir();
            }

        }

        bool GirBegen;
        bool GirAnaSyBegen;
        int SayacAnaSyBegen;
        int SayacBegen;

        bool GirYorumYap;
        int SayacYorumYap;

        bool GirTakipEt;
        int SayacTakipEt;

        bool GirTakiptenCik;
        int SayacTakiptenCik;

        bool GirIstekKontrol;
        int SayacIstekKontrol;
        private void IslemSinirlari() // Burada kaç gönderi beğenilecek ne kadar resim alınıcak kaç adet yorum atılacak fln onların hesaplandığı yer
        {
            if (Secimler.Begen.begenecekMi)
            {
                if (Secimler.Begen.anaSayfaBegen && Secimler.Begen.anaSyBegeniSayisi > 0)
                {
                    SayacAnaSyBegen = Secimler.Begen.anaSyBegeniSayisi;
                    GirAnaSyBegen = true;
                }
                else
                    GirAnaSyBegen = false;

                GirBegen = true;
                SayacBegen = Secimler.Begen.begeniSayisi;
            }
            else
                GirBegen = false;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Beğeni

            if (Secimler.YorumYap.yorumYapacakMi)
            {
                if (Secimler.YorumYap.yorumSayisi>0)
                {
                    GirYorumYap = true;

                    SayacYorumYap = Secimler.YorumYap.yorumSayisi;

                    if (Secimler.YorumYap.rasgeleHarfEkle)
                    {
                        foreach (var item in Secimler.ListYorumlar) // Yapılacak Yorumlar
                        {
                            if (item.grupAdi == Secimler.YorumYap.yorumGrubu)
                            {
                                if (Secimler.YorumYap.rasgeleHarfEkle)
                                    YapilacakYorumlar.Add(item.yorum + " " + item.yorum.Substring(random.Next(item.yorum.Length - 1), 1)); // burada yorumun için rasgele bir harf seçtik ve sonuna bir boşluk ekleyip harfi yerleştirdik yorumu farklılaştırdık
                                else
                                    YapilacakYorumlar.Add(item.yorum);
                            }
                        }
                    }
                }
                else
                    GirYorumYap = false;
            }
            else
                GirYorumYap = false;

            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Yorum Yap

            if (Secimler.TakipEt.takipEdicekMi)
            {
                if (Secimler.TakipEt.takipEtmeSayisi > 0)
                {
                    SayacTakipEt = Secimler.TakipEt.takipEtmeSayisi;
                    GirTakipEt = true;
                }
                else
                    GirTakipEt = false;
            }
            else
                GirTakipEt = false;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Et

            if (Secimler.TakiptenCik.takiptenCikacakMi)
            {
                SayacTakiptenCik = Secimler.TakiptenCik.takiptenCikmaSayisi;
                GirTakiptenCik = true;
            }
            else
                GirTakiptenCik = false;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Et

            if (Secimler.IstekKontrol.takipKontrolEdilsinMi)
            {
                GirIstekKontrol = true;
                SayacIstekKontrol = Secimler.IstekKontrol.kontrolSayisi;
            }
            else
                GirIstekKontrol = false;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Kontrol

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

            Thread.Sleep(random.Next(2000, 3000));

            if (webDriver.Url== "https://www.instagram.com/accounts/login/two_factor?next=%2F") //2 adımlı doğrulama varsa
            {
                Application.OpenForms[0].Activate();

                string IsimGirisi = Interaction.InputBox("Bilgi Girişi", "Adınızı Giriniz.");
                var guvenlikMsjText = webDriver.FindElement(By.CssSelector(CssSelectorler.GirisEkrani.guvenlikMsjText));
                guvenlikMsjText.SendKeys(IsimGirisi);
                guvenlikMsjText.SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(1000);
            }
            Thread.Sleep(random.Next(1000, 2000));

            webDriver.FindElement(By.CssSelector(CssSelectorler.GirisEkrani.kayitButon)).Click();

            Thread.Sleep(random.Next(1000, 2000));

            webDriver.FindElement(By.CssSelector(CssSelectorler.GirisEkrani.bildirimleriAcButton)).Click();

            

        }
        private void AnaSayfaBegen() 
        {
            if (webDriver.Url != "https://www.instagram.com/") // Bu şifre girişi yaptıktan sonra direk anasayfaya düşüyor eper url anasayfa ise direk başlıyor değilse anasayfaya gidiyor
            {
                webDriver.Navigate().GoToUrl("https://www.instagram.com/");
            }
            Thread.Sleep(random.Next(1000, 2000));

            string isim;

            int beğeniSayisi = 0;
            IWebElement begeni;
            List<IWebElement> gonderiler = new List<IWebElement>();

            try
            {
                gonderiler.AddRange(webDriver.FindElements(By.CssSelector(CssSelectorler.AnaSayfaBegen.gonderiler))); // gönderileri aldık
                while (beğeniSayisi < 4 && SayacAnaSyBegen > 0)
                {
                    //Beğendiklerini bir kez daha atayınca ifin istündeki dizinde sorun çıkarıyor o yüzden beğendiğin kısımları döngüye sokmican
                    try
                    {
                        foreach (var item in gonderiler)
                        {
                            beğeniSayisi++; // Metot içinde ne kadar Beğendiğini sayar
                            SayacAnaSyBegen--; // Kulanıcının Girdiği Anasayfa Beğeni sayısı ve her beğenide düşüyor
                            if (SayacAnaSyBegen > 0 && SayacBegen > 0)
                            {
                                Thread.Sleep(random.Next(Secimler.Sureler.minBegen, Secimler.Sureler.maxBegen));
                                begeni = item.FindElement(By.CssSelector(CssSelectorler.AnaSayfaBegen.begeniClass)); // Paylaşımın altındaki paylaşının adına tıklıyor sorunu çöz
                                isim = item.FindElement(By.CssSelector(CssSelectorler.AnaSayfaBegen.isimClasi)).GetAttribute("text"); //Gönderiyi paylaşan hesabın adı
                                if (begeni.FindElement(By.TagName("svg")).GetAttribute("aria-label") == "Like") //Gönderinin like kısmını kontrol eden kısım "fr66n" svg nin iki üstündeki dizin
                                {
                                    begeni.FindElement(By.TagName("button")).Click(); //Gönderiyi Beğeniyor



                                    
                                    SayacBegen--; // Kulanıcının Girdiği Beğeni sayısı ve her beğenide düşüyor
                                    Secimler.Begen.yapilanBegeniSayisi++; // Kulanıcıya göstereceğimiz yapılan beğeni sayisini atırıyor

                                    Bilgi = isim + " paylaşımı beğenildi";
                                    VeriHazir();
                                }
                                else
                                {
                                    Bilgi = isim + " paylaşını daha önce beğenilmiş";
                                    VeriHazir();
                                }

                                if (beğeniSayisi > 4) // Metotda bir kerede ke kadar beğenilecekse o sayıya geldiyse göngüden çıkıyor veya kullanıcının isteği kadar beğenildiyse
                                {
                                    break;
                                }
                            }
                            else
                                break;

                        }

                        gonderiler.Clear();
                        for (int i = 3; i < webDriver.FindElements(By.CssSelector(CssSelectorler.AnaSayfaBegen.gonderiler)).Count; i++)
                        {
                            gonderiler.Add(webDriver.FindElements(By.CssSelector(CssSelectorler.AnaSayfaBegen.gonderiler))[i]);
                        }
                    }
                    catch (Exception)
                    {
                        SayacAnaSyBegen--;
                        Bilgi = "Anasayfadaki paylaşımı beğenirken bir hata ile karşılaşıldı.";
                        VeriHazir();
                    }
                    
                }
            }
            catch {}
            finally
            {
                AyarlarVeritabani.IslemSayisi("Begen");
            }
            
        }
        private void YorumYap() 
        {
            IWebElement metinKutusu;
            IWebElement begenButonu;

            string bilgi="",paylasan = "",sayfaLinki;

            //Döngü her çağırıldığında 5 kere dönek
            //Her turda paylaşım linkinin ilk değerini silecek
            //Paylaşım linki varsa çalışacak
            //Kulanıcının belirlediği sayı kadar dönecek
            //Her turda "SayaçYorumYap" bir azalacak
            for (int i = 0; i < 5 && VeriHavuzu.PaylasimLinki.Count > 0 && SayacYorumYap > 0; i++)
            {
                try
                {
                    sayfaLinki = VeriHavuzu.PaylasimLinki[0];
                    VeriHavuzu.PaylasimLinki.RemoveAt(0); // hep listenin ilk değerine gidiyor ve gittiği değeri siliyor

                    webDriver.Navigate().GoToUrl(sayfaLinki);

                    Thread.Sleep(random.Next(1000, 2000));

                    paylasan = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.paylasan)).GetAttribute("textContent"); // <a> etiketin classı ile aldık 

                    if (GirBegen && SayacBegen > 0)
                    {
                        begenButonu = webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.begeniButonu));
                        string begenilmisMi = begenButonu.FindElement(By.TagName("svg")).GetAttribute("ariaLabel").ToString(); // gönderi önceden beğenildiyse unlike değerini yazar
                        if (begenilmisMi == "Like" || begenilmisMi == "Beğen")
                        {
                            begenButonu.Click();

                            SayacBegen--; // Kulanıcının Belirlediği begeni bir sayaç olarak sayısını her beğenide azaltıyoruz
                            Secimler.Begen.yapilanBegeniSayisi++; // Kulanıcıya ne kadar beğeni yapıldığını göstermek için

                            Thread.Sleep(random.Next(Secimler.Sureler.minBegen, Secimler.Sureler.maxBegen));
                            bilgi = " Beğenildi ve";
                        }
                        else
                            bilgi = "";
                    }
                    else
                        bilgi = "";
                    // gönderi yoruma açık değilse null değeri döndürüyor
                    if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.YorumyapBegen.yorumYapma + "')") != null) //yorumYapma clkasını değiştir
                    {
                        metinKutusu = webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.yorumYeri)).FindElement(By.TagName("textarea")); // yorum yerine tıklayınca text kısmı açılıyor o yüzden iki kere tanımlıyoruz
                        metinKutusu.Click();
                        Thread.Sleep(random.Next(200, 300));
                        metinKutusu = webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.yorumYeri)).FindElement(By.TagName("textarea"));
                        metinKutusu.SendKeys(Secimler.YapilacakYorumlar[random.Next(Secimler.YapilacakYorumlar.Count - 1)]); // Yorumlar arasında rasgele yorum seçiyor
                        Thread.Sleep(random.Next(300, 500));
                        webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.yorumYeri)).FindElement(By.TagName("button")).Click(); // bunu post tuşu ile yap
                        bilgi += " Yorum yapıldı.";

                        SayacYorumYap--; // Belirlenen yorumsayısını azalttık;
                        Secimler.YorumYap.yapilanYorumSayisi++; // Kulanıcıya ne kadar yorum yapıldığını göstermek için 
                    }

                    Bilgi = paylasan + bilgi;
                    VeriHazir();
                    Thread.Sleep(random.Next(Secimler.Sureler.minYorum, Secimler.Sureler.maxYorum));

                    //Yorum yapan varsa yapanların linkini alır
                    YorumYapanalariAl();

                    if (Secimler.ResimAl.resimAlsinMi)
                    {
                        ResimVideoLinkAl(sayfaLinki);
                    }
                }
                catch (Exception)
                {
                    SayacYorumYap--; 
                    Bilgi = "Yorum yapılırken bir hatai le karşılaşıldı.";
                    VeriHazir();
                }


            }

            AyarlarVeritabani.IslemSayisi("Yorum");
            VeriTabani.ResimVideoLinkiKaydet();
        }
        private void TakipEt()
        {
            int acikHesapSay = 0;
            int gizliHesapSay = 0;
            string kullaniciAdi;
            string gidilecekYer = "";
            IWebElement anaDizin;
            for (int i = 0; i < 10 && VeriHavuzu.TakipEdilecekler.Count > 0 && SayacTakipEt > 0; i++)
            {
                try
                {
                    gidilecekYer = VeriHavuzu.TakipEdilecekler[0];
                    VeriHavuzu.TakipEdilecekler.RemoveAt(0);

                    webDriver.Navigate().GoToUrl(gidilecekYer);
                    Thread.Sleep(random.Next(1000, 2000));

                    anaDizin = webDriver.FindElement(By.CssSelector(CssSelectorler.TakipEt.anaDizin)); // Kullanıcı hesap adının ve butonun olduğu dizin
                    kullaniciAdi = anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.kullaniciAdi)).GetAttribute("textContent").ToString();

                    //açık hesapları Follow Classı ile kapalıların farklı
                    if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.TakipEt.acikHesap + "')") != null && Secimler.TakipEt.acikHesaplariTkpEt) //Açık hesap
                    {
                        anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.acikHesap)).Click(); // Takip butonuna tıklandı

                        acikHesapSay++;
                        VeriHavuzu.TakipEdilenHesaplar.Add(new ListTakipBilgi() { hesapAdi = kullaniciAdi, hesapLinki = gidilecekYer, hesap = "Açık"}); //VeriTabanina takip edilen hesabın linkini ve gizlimi açıkmı onun bilgisi aktarmak için yeni bir class yaptım ve new dememin sebebi listedeki  eklene değişkenin değerini en son ne yaparsak tüm değişkenler o oluyor

                        SayacTakipEt--;
                        Secimler.TakipEt.takipEdilenSayi++;

                        Bilgi = kullaniciAdi + " Takip isteği gönderildi.";
                        VeriHazir();
                    }
                    else if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.TakipEt.gizliHesap + "')") != null) // Gizli Hesap
                    {
                        anaDizin.FindElement(By.CssSelector(CssSelectorler.TakipEt.gizliHesap)).Click(); // Takip butonuna tıklandı

                        gizliHesapSay++;
                        VeriHavuzu.TakipEdilenHesaplar.Add(new ListTakipBilgi() { hesapAdi = kullaniciAdi, hesapLinki = gidilecekYer, hesap = "Gizli"}); //VeriTabanina takip edilen hesabın linkini ve gizlimi açıkmı onun bilgisi aktarmak için yeni bir class yaptım ve new dememin sebebi listedeki  eklene değişkenin değerini en son ne yaparsak tüm değişkenler o oluyor

                        SayacTakipEt--;
                        Secimler.TakipEt.takipEdilenSayi++;

                        Bilgi = kullaniciAdi + " Takip isteği gönderildi.";
                        VeriHazir();
                    }

                }
                catch 
                {
                    SayacTakipEt--;
                    Bilgi = "Takip isteği göndderilirken hata ile karşılaşıldı.";
                    VeriHazir();
                }
                finally
                {
                    Thread.Sleep(random.Next(Secimler.Sureler.minYorum, Secimler.Sureler.maxYorum));
                }

            }
            //Yapılan işleri veritabanına kaydedilen yer
            AyarlarVeritabani.IslemSayisi("TakipEt");
            VeriTabani.TakipEdilenKaydet();
            
        }
        private void YorumYapanalariAl()
        {
            string yorumYapaninAdi;
            if (Secimler.TakipEt.takipEdicekMi) //Takip edileceklerin hesap adını alındığı kısım
            {
                if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.YorumyapBegen.yorumYapanlar + "')") != null)
                {
                    if (js.ExecuteScript("return document.querySelector('"+ CssSelectorler.YorumyapBegen.dahaFazlaButonu+ "')") != null) // daha fazla yorum göster butonu
                    {
                        webDriver.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.dahaFazlaButonu)).Click();
                        Thread.Sleep(random.Next(500, 1000));

                    }
                    foreach (var yorumYapanlar in webDriver.FindElements(By.CssSelector(CssSelectorler.YorumyapBegen.yorumYapanlar)))
                    {
                        yorumYapaninAdi = yorumYapanlar.FindElement(By.CssSelector(CssSelectorler.YorumyapBegen.yorumyapanınAdi)).GetAttribute("href").ToString();

                        if (!VeriHavuzu.TakipEdilecekler.Contains(yorumYapaninAdi) && !yorumYapaninAdi.Contains(Secimler.GirisBilgileri.kullaniciAdi)) //"Contains()" ilestede öyle bir değer varsa true döndürüyor
                        {
                            VeriHavuzu.TakipEdilecekler.Add(yorumYapaninAdi);
                        }

                    }
                }
            }
        } // Yorumlardan yorum yapanların linkini aldık
        private void TakipcileriAl()
        {
            string kontrol;
            string link;

            int alinacakSayi = SayacTakipEt / Secimler.GidilecekYer.Count;
            int alinankontrol;

            List<string> linkler = new List<string>();
            for (int i = 0;  Secimler.GidilecekYer.Count > 0; i++)
            {
                link = Secimler.GidilecekYer[0];
                Secimler.GidilecekYer.RemoveAt(0);//Gidilen yeri sildik
                webDriver.Navigate().GoToUrl(link);
                linkler.Clear();
                Thread.Sleep(random.Next(1000, 2000));

                if (js.ExecuteScript("return document.querySelector('.QlxVY')") == null)
                {
                    var dizinler = webDriver.FindElements(By.CssSelector(".Y8-fY"));// Takipçi kısmındaki li classı bundan 3 adet var ve takip edilenler li si 2. sırada
                    dizinler[1].Click();//Takip edilenler kısmı
                    Thread.Sleep(random.Next(500, 1000));
                    var hesapDizini = webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.hesapDizini)); // Kullanıcıları olduğu dizinin üstü
                    // Burada Belirlenen sayı kadarhesapların linki alınıyor
                    // Çalışma mantığı takip edilmeyen  hesapların profil linkini alıyor ve
                    // Eğer toplanan hesap sayısı yetmiyorsa açılır ekranı aşağıya indiriyor  ve yeniden verileri alıyor
                    while(linkler.Count < (alinacakSayi*(i+1))) //"(alinacakSayi*(i+1))" bunu amacı misal 10 link alınacak 2 hesaptan o zmn her hesaptan 5 tane alınacaktır
                    {
                        if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.TakiptenCikma.acilanEkran + "')") != null)// Takiçilerine basınca Açılan ekran
                        {
                            js.ExecuteScript("document.querySelector('.isgrP').scrollBy(0,1000);"); // açılır ekranın classı
                            alinankontrol = linkler.Count;
                            linkler.Clear();

                            Thread.Sleep(random.Next(500, 1000));
                            foreach (var hesap in hesapDizini.FindElements(By.TagName("li")))
                            {
                                kontrol = hesap.FindElement(By.TagName("button")).GetAttribute("textContent");
                                if (kontrol == "Follow" || kontrol == "Takip Et")
                                {
                                    linkler.Add(hesap.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.hesapAdi)).GetAttribute("href"));
                                    
                                }
                            }

                            if (alinankontrol == linkler.Count) // Eğer sayfayı aşağıya indirip yeni hesap ekleyince sayı artmıyorsa demekki tümünü almışındır
                            {
                                break;
                            }
                        }
                        else
                        {
                            dizinler[1].Click();//Takip edilenler kısmı
                            Thread.Sleep(random.Next(500, 1000));
                        }
                    }
                }

                if (linkler.Count > 0)
                {
                    for (int k = 0; k < alinacakSayi; k++)
                    {
                        VeriHavuzu.TakipEdilecekler.Add(linkler[k]);
                    }
                }
            }

        }// Seçilen hesabın takipçilerini alır // Takipçilerden veya takip ettiklerinden alırken belirlenene sayı kadar yoksa çıkma kontrolu
        private void TakipEttikleriniAl()
        {
            string kontrol;
            string link;

            int alinacakSayi = SayacTakipEt / Secimler.GidilecekYer.Count;
            int alinankontrol;

            List<string> linkler = new List<string>();
            for (int i = 0; Secimler.GidilecekYer.Count > 0; i++)
            {
                link = Secimler.GidilecekYer[0];
                Secimler.GidilecekYer.RemoveAt(0);//Gidilen yeri sildik
                webDriver.Navigate().GoToUrl(link);
                linkler.Clear();
                Thread.Sleep(random.Next(1000, 2000));

                if (js.ExecuteScript("return document.querySelector('.QlxVY')") == null)
                {
                    var dizinler = webDriver.FindElements(By.CssSelector(".Y8-fY"));// Takipçi kısmındaki li classı bundan 3 adet var ve takip edilenler li si 2. sırada
                    dizinler[2].Click();//Takip edilenler kısmı
                    Thread.Sleep(random.Next(500, 1000));
                    var hesapDizini = webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.hesapDizini)); // Kullanıcıları olduğu dizinin üstü
                    // Burada Belirlenen sayı kadarhesapların linki alınıyor
                    // Çalışma mantığı takip edilmeyen  hesapların profil linkini alıyor ve
                    // Eğer toplanan hesap sayısı yetmiyorsa açılır ekranı aşağıya indiriyor  ve yeniden verileri alıyor
                    while (linkler.Count < alinacakSayi) // bunu amacı misal 10 link alınacak 2 hesaptan o zmn her hesaptan 5 tane alınacaktır
                    {
                        if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.TakiptenCikma.acilanEkran + "')") != null)// Takiçilerine basınca Açılan ekran
                        {
                            js.ExecuteScript("document.querySelector('.isgrP').scrollBy(0,1000);"); // açılır ekranın classı
                            alinankontrol = linkler.Count;
                            linkler.Clear();

                            Thread.Sleep(random.Next(500, 1000));
                            foreach (var hesap in hesapDizini.FindElements(By.TagName("li")))
                            {
                                kontrol = hesap.FindElement(By.TagName("button")).GetAttribute("textContent");
                                if (kontrol == "Follow" || kontrol == "Takip Et")
                                {
                                    linkler.Add(hesap.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.hesapAdi)).GetAttribute("href"));

                                }
                            }

                            if (alinankontrol == linkler.Count) // Eğer sayfayı aşağıya indirip yeni hesap ekleyince sayı artmıyorsa demekki tümünü almışındır
                            {
                                break;
                            }
                        }
                        else
                        {
                            dizinler[2].Click();//Takip edilenler kısmı
                            Thread.Sleep(random.Next(500, 1000));
                        }
                    }
                }

                if (linkler.Count>0)
                {
                    for (int k = 0; k < alinacakSayi; k++)
                    {
                        VeriHavuzu.TakipEdilecekler.Add(linkler[k]);
                    }
                }
                
            }
        }// Seçilen hesabın takip ettiklerini alır
        private void TakiptenCik()
        {
            int cikarilanHesapSayisi = 0;
            string hesapAdi="";
            IWebElement button, hesapDizini;

            try
            {
                webDriver.Navigate().GoToUrl("https://www.instagram.com/" + Secimler.GirisBilgileri.kullaniciAdi);
                Thread.Sleep(random.Next(1000, 2000));
                webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.takipEdilenler)).Click(); //Takip edilenler kısmı

                hesapDizini = webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.hesapDizini)); // Kullanıcıları olduğu dizinin üstü

                List<IWebElement> hesaplar = new List<IWebElement>();
                hesaplar.AddRange(hesapDizini.FindElements(By.TagName("li")));


                foreach (var item in hesaplar)
                {
                    if (SayacTakiptenCik > 0 && cikarilanHesapSayisi < 4)
                    {
                        if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.TakiptenCikma.acilanEkran + "')") != null)
                        {
                            button = item.FindElement(By.TagName("button"));
                            hesapAdi = item.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.hesapAdi)).GetAttribute("title"); //Hesap isiminin yazdığı <a> etiketinin clası
                            if (button.GetAttribute("textContent") == "Following" || button.GetAttribute("textContent") == "Takiptesin")
                            {
                                button.Click();
                                webDriver.FindElement(By.CssSelector(CssSelectorler.TakiptenCikma.silmeButonu)).Click(); // Takipten çıkma tuşu

                                cikarilanHesapSayisi++;
                                SayacTakiptenCik--;
                                Secimler.TakiptenCik.takiptenCikarilanSayi++;

                                Bilgi = hesapAdi + "  Takipten Çıkarıldı.";
                                VeriHazir();

                                Thread.Sleep(random.Next(Secimler.Sureler.minTakipEtCik, Secimler.Sureler.maxTakipEtCik));
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception)
            {
                SayacTakiptenCik--;
                Bilgi = "Takipten çıkarken bir hata ile karşılaşıldı";
                VeriHazir();
            }
            finally
            {
                AyarlarVeritabani.IslemSayisi("TakiptenCik");
            }
            
        }
        private void IstekKontrol()  // kaçtane kontrol edilecek forma onu eklicen
        {
            int kacGonderi = 0;
            string kontrol;
            ListIstekBilgi listIstekBilgi;

            if (VeriHavuzu.IstekAtilanHesaplar.Count > 0)
            {
                for (int i = 0; i < 10 && VeriHavuzu.IstekAtilanHesaplar.Count > 0 && SayacIstekKontrol > 0; i++)
                {
                    try
                    {
                        SayacIstekKontrol--;
                        Secimler.IstekKontrol.IstekSayisi--;

                        listIstekBilgi = VeriHavuzu.IstekAtilanHesaplar[0]; // her seferinde ilk değeri alma nedenimiz her ilk değeri alınca siliyoruz yani ikinci değer hep ilk değer oluyor
                        VeriHavuzu.IstekAtilanHesaplar.RemoveAt(0);
                        if (listIstekBilgi.hesap == "Açık" && Secimler.IstekKontrol.acikHesap)
                        {
                            webDriver.Navigate().GoToUrl(listIstekBilgi.hesapLinki);
                            VeriHavuzu.SilinecekIstekIdler.Add(listIstekBilgi.id);

                            Thread.Sleep(random.Next(300, 500));
                            if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.IstekKontrol.AtakiptenCik + "')") != null) //nesnenin olup olmadığını kontrol ediyoruz
                            {
                                webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.AtakiptenCik)).Click(); // Mesaj butonunun yanındaki takipten çıkarma ana butonu
                                Thread.Sleep(random.Next(300, 500));
                                webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.onayButonu)).Click(); // takipten çıkma onay butonu

                                Bilgi = listIstekBilgi.hesapAdi + " Takipten çıkıldı";
                                VeriHazir();

                            }
                        }
                        else if (listIstekBilgi.hesap == "Gizli" && Secimler.IstekKontrol.gizliHesap) // Gizli hesaplar
                        {
                            webDriver.Navigate().GoToUrl(listIstekBilgi.hesapLinki);
                            VeriHavuzu.SilinecekIstekIdler.Add(listIstekBilgi.id);

                            Thread.Sleep(random.Next(300, 500));
                            if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.IstekKontrol.GtakiptenCik + "')") != null) // Eğer kabul ettiyse isteği geri çekme butonu olmaz
                            {
                                kontrol = webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.GtakiptenCik)).GetAttribute("textContent");//Takip et butonu ile isteği geri geçk aynı csselektro
                                if (kontrol == "İstek Gönderildi" || kontrol == "Requested")
                                {
                                    webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.GtakiptenCik)).Click(); ; // Mesaj butonunun yanındaki takipten çıkarma ana butonu
                                    Thread.Sleep(random.Next(300, 500));
                                    webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.onayButonu)).Click(); ; // takipten çıkma butonu

                                    Bilgi = listIstekBilgi.hesapAdi + " İstek geri çekildi";
                                    VeriHazir();
                                }
                            }
                            else
                            {

                                if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.IstekKontrol.istekKabul + "')") != null) //takip isteğini kabul etmiş
                                {
                                    kacGonderi = Convert.ToInt32(js.ExecuteScript("return document.querySelector('#react-root > section > main > div > header > section > ul > li:nth-child(1) > span > span').textContent"));
                                    if (kacGonderi > 0) //Sayfada bir gönderi varsa
                                    {
                                        //"try" kullanma nedeni kulanıcı tam beğenirken ekrana tıklarsa gönderi açık olamz ve hataya düşer hataya düşerse bir sonraki hesaba baksın
                                        try
                                        {
                                            webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.gonderi)).Click();

                                            if (kacGonderi > Secimler.IstekKontrol.begenilecekSayi) // eğer beğenilecek sayı dan fazla gönderi varsa ayarlanan sayı kadar beğensin
                                            {
                                                kacGonderi = Secimler.IstekKontrol.begenilecekSayi;
                                            }

                                            Bilgi = listIstekBilgi.hesapAdi + " İsteğinizi kabul etmiş";
                                            VeriHazir();
                                            for (int k = 0; k < kacGonderi; k++)// paylaşımlarını beğenme
                                            {
                                                webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.begenButon)).Click(); // beğen butonun csselectoru
                                                Secimler.Begen.yapilanBegeniSayisi++;
                                                Bilgi = listIstekBilgi.hesapAdi + " Gonderisi Beğenildi";
                                                VeriHazir();
                                                Thread.Sleep(500);
                                                if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.IstekKontrol.ileriButon + "')") != null) // bir sonraki resim butonu varmı (yorumyapla aynı css)
                                                {
                                                    webDriver.FindElement(By.CssSelector(CssSelectorler.IstekKontrol.ileriButon)).Click(); // bir sonraki gödneri (yorumyapla aynı css)
                                                    Thread.Sleep(500);
                                                }


                                            }
                                        }
                                        catch { }


                                    }
                                }

                            }

                        }
                        Thread.Sleep(random.Next(Secimler.Sureler.minTakipEtCik, Secimler.Sureler.maxTakipEtCik));
                    }
                    catch (Exception)
                    {
                        SayacIstekKontrol--;
                        Bilgi = "İstek Kontrol edilirken bir hata ile karşılaşıldı.";
                        VeriHazir();
                    }
                }

            }

            VeriTabani.IstekleriSil();
        }
        private void ResimVideoLinkAl(string sayfaLinki)
        {

            string link="", aciklama="",paylasan,tur="";
            bool gir = false;

            try
            {
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

                        if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.LinkAl.aciklama + "')") != null) // Açıklama yapmış mı
                            aciklama = webDriver.FindElement(By.TagName(CssSelectorler.LinkAl.aciklama)).FindElements(By.TagName("span"))[1].GetAttribute("textContent"); // açıklamanın olduğu yer(<span>)
                        else
                            aciklama = "Yok";

                        paylasan = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.paylasan)).GetAttribute("textContent"); // <a> etiketin classı ile aldık 
                        VeriHavuzu.AlinanResimVidoe.Add(new ListAlinanResimVideo() { link = link, aciklama = aciklama, tur = tur, paylasan = paylasan, anaLink = sayfaLinki });
                    }

                    while (true)
                    {
                        webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.ileri)).Click();
                        Thread.Sleep(random.Next(500,1000));
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


                            if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.LinkAl.aciklama + "')") != null) // Açıklama yapmış mı
                                aciklama = webDriver.FindElement(By.TagName(CssSelectorler.LinkAl.aciklama)).FindElements(By.TagName("span"))[1].GetAttribute("textContent"); // açıklamanın olduğu yer(<span>)
                            else
                                aciklama = "Yok";

                            paylasan = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.paylasan)).GetAttribute("textContent"); // <a> etiketin classı ile aldık 
                            VeriHavuzu.AlinanResimVidoe.Add(new ListAlinanResimVideo() { link = link, aciklama = aciklama, tur = tur, paylasan = paylasan, anaLink = sayfaLinki });
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

                    if (js.ExecuteScript("return document.querySelector('" + CssSelectorler.LinkAl.aciklama + "')") != null) // Açıklama yapmış mı
                        aciklama = webDriver.FindElement(By.TagName(CssSelectorler.LinkAl.aciklama)).FindElements(By.TagName("span"))[1].GetAttribute("textContent"); // açıklamanın olduğu yer(<span>)
                    else
                        aciklama = "Yok";

                    paylasan = webDriver.FindElement(By.CssSelector(CssSelectorler.LinkAl.paylasan)).GetAttribute("textContent"); // <a> etiketin classı ile aldık 
                    VeriHavuzu.AlinanResimVidoe.Add(new ListAlinanResimVideo() { link = link, aciklama = aciklama, tur = tur, paylasan = paylasan, anaLink = sayfaLinki });
                }
            }
            catch (Exception)
            {
                Bilgi = "Resim veya Video alınırken bir hata ile karşılaşıldı";
                VeriHazir();
            }
        }
        private void PaylasimLinkiAl()
        {
            List<string> ilkBakilacaklar = new List<string>();
            List<string> sonBakilacaklar = new List<string>();

            int alinacakLinkSayisi;
            int sayaç = 1;
            string sayfaLinki;

            if ((Secimler.YorumYap.yorumSayisi / Secimler.GidilecekYer.Count) <= 25) // Burada kaçtane link varsa her birinden alınacak gönderi sayısını belirledik
            {
                alinacakLinkSayisi = (Secimler.YorumYap.yorumSayisi / Secimler.GidilecekYer.Count);
            }
            else
                alinacakLinkSayisi = 25;


            ilkBakilacaklar.Clear(); // Eğer bu metot ikinci kez çağırılırsa önceki veriler silinsin
            sonBakilacaklar.Clear();
            while (Secimler.GidilecekYer.Count > 0)
            {
                try
                {
                    sayfaLinki = Secimler.GidilecekYer[0]; // bunu yapma nedeni eğer sayfaya gitmezse demekki bir hata alıcak hata alınca lat satırı çalıştıramıcak lat satır hata olsa olmasada silicek değeri
                    webDriver.Navigate().GoToUrl(sayfaLinki);
                    Secimler.GidilecekYer.RemoveAt(0);//Gittiğimiz yerleri temizliyoruzki çalışırken ikinci kez aynı yere gitmesin
                    Thread.Sleep(1000);

                    foreach (var item in webDriver.FindElements(By.CssSelector(CssSelectorler.LinkAl.gonderiler))) // Hashtag deki gönderi aldık
                    {
                        if ((ilkBakilacaklar.Count + sonBakilacaklar.Count) < (alinacakLinkSayisi * sayaç)) // her hashtag den belirlenen sayı kadar almak için kontrol
                        {
                            if (ilkBakilacaklar.Count <= (9 * sayaç))// burada ilk 9 yani popüler olanları aldık
                                ilkBakilacaklar.Add(item.FindElement(By.TagName("a")).GetAttribute("href"));
                            else
                                sonBakilacaklar.Add(item.FindElement(By.TagName("a")).GetAttribute("href"));
                        }

                    }
                    sayaç++;
                }
                catch (Exception)
                {
                    Bilgi = "Paylaşımların linklerini alırken bir hata ile karşılaşıldı.";
                    VeriHazir();
                }

            }
            if (ilkBakilacaklar.Count != 0)
            {
                VeriHavuzu.PaylasimLinki.AddRange(ilkBakilacaklar);
            }
            if (sonBakilacaklar.Count != 0)
            {
                VeriHavuzu.PaylasimLinki.AddRange(sonBakilacaklar);
            }
        }
    }
}

