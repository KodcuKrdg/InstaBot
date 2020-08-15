using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using InstaBot.Database;
using InstaBot.Forms;

namespace InstaBot
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            VeriTabani VeriTabani = VeriTabani.GetInstance();
            string adres = "https://karadagyazilim.com/versiyon.php";
            string gelenHamVeri, apVer, guncellemeApVer;

            WebClient client = new WebClient();
            Stream stream = client.OpenRead(adres);
            StreamReader streamReader = new StreamReader(stream);

            gelenHamVeri = streamReader.ReadToEnd();

            apVer = gelenHamVeri.Split('/')[0].Split('=')[1]; // versiyonları aldık 
            guncellemeApVer = gelenHamVeri.Split('/')[1].Split('=')[1];

            var versiyonlar = VeriTabani.VersiyonlariAl();

            if (guncellemeApVer != versiyonlar[0]) //Guncelleme uygulamanı günceller
            {
                Guncelleme guncelleme = new Guncelleme();
                guncelleme.versiyon = guncellemeApVer;
                Application.Run(guncelleme);

            }
            else if (apVer != versiyonlar[1]) // Ana uygulamnayı günceller
            {
                VeriTabani.VersiyonlariGuncelle("ApVer", apVer);
                string guncellemeAp = Application.StartupPath + @"\Guncelleme\Guncelleme.exe";
                ProcessStartInfo info = new ProcessStartInfo(guncellemeAp);
                Process.Start(info);
                Application.Exit();
            }
            else
                Application.Run(new AnaSayfa());
        }
    }
}
