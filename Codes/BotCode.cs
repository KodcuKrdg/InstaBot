using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using AutoIt;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApp6
{
    class instagram
    {
        IWebDriver webDriver;

        public string girisOk;
        public string paylasimOk;

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

        public void HesabaGirisYap(string kullaniciAdim, string parolam)
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

                Thread.Sleep(1000);

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

        public void gonderiCek(string hasthag)
        {
            //Form1 frm = new Form();
            //frm.Show();
            try
            {
                webDriver.Navigate().GoToUrl("https://www.instagram.com/explore/tags/" + hasthag + "/");

                IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;

                int abc = 0;

            tekrar11:

                for (int i = 1; i <= 100; i++)
                {
                    js.ExecuteScript("window.scrollBy(0," + i + ")", "");
                }
                abc++;

                if (abc != 10)
                    goto tekrar11;


                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        var paylas = IsElementPresent_byXpath("//*[@id=\"react-root\"]/section/main/article/div[2]/div/div[" + i + "]/div[" + j + "]/a/div/div[1]/img");

                        if (paylas)
                        {
                            var imageSrc = webDriver.FindElement(By.XPath("//*[@id=\"react-root\"]/section/main/article/div[2]/div/div[" + i + "]/div[" + j + "]/a/div/div[1]/img")).GetAttribute("src");

                            //frm.listBox1.Items.Add(imageSrc);
                        }
                        else
                        {
                            var imageSrc = webDriver.FindElement(By.XPath("//*[@id=\"react-root\"]/section/main/article/div[2]/div/div[" + i + "]/div[" + j + "]/a/div[1]/div[1]/img")).GetAttribute("src");

                            //frm.listBox1.Items.Add(imageSrc);
                        }
                    }
                }

                paylasimOk = "Başarılı";
            }
            catch (Exception)
            {
                paylasimOk = "Başarısız";
            }
        }
    }
}
