using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using InstaBot.Database;
using Ionic.Zip;

namespace InstaBot.Forms
{
    public partial class Guncelleme : Form
    {
        public Guncelleme()
        {
            InitializeComponent();
        }
        VeriTabani VeriTabani = VeriTabani.GetInstance();
        string dosyaYolu;
        public string versiyon;
        private void Guncelleme_Load(object sender, EventArgs e)
        {
            //Üst Kök dizine çıktık
            dosyaYolu = Application.StartupPath + @"\Guncelleme\guncellemeap.zip"; // zipin nereye ineceği
            WebClient istek = new WebClient();
            istek.DownloadFileCompleted += new AsyncCompletedEventHandler(Bitti);
            istek.DownloadProgressChanged += new DownloadProgressChangedEventHandler(BarDegisim);
            istek.DownloadFileAsync(new Uri("https://karadagyazilim.com/guncellemeap/guncellemeap.zip"), dosyaYolu);
            
        }
        private void DosyalarıAcma()
        {
            string cikarilacakZip = dosyaYolu; // indirilen zipin yeri
            string nereyeCikarilacak = Application.StartupPath + @"\Guncelleme\"; // zipin çıkacağı yer

            using (ZipFile zip = ZipFile.Read(cikarilacakZip)) // sadece .zip uzantıları açıyor
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(nereyeCikarilacak, ExtractExistingFileAction.OverwriteSilently);
                }
            }

            VeriTabani.VersiyonlariGuncelle("guncellemeApVer", versiyon);
            File.Delete(dosyaYolu); // zipi siler
            
            MessageBox.Show("Güncelleme Başarıyla Tamamlanmıştır.", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Güncelleme bitmiştir
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void Bitti(object sender, AsyncCompletedEventArgs e)
        {
            label1.Text = "İndirme Tamamlandı";
            DosyalarıAcma();
        }
        private void BarDegisim(object sender, DownloadProgressChangedEventArgs e)
        {
            prgBar.Value = e.ProgressPercentage;
        }
    }
}
