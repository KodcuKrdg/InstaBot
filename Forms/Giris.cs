using InstaBot.Codes;
using InstaBot.MyDesign;
using InstaBot.Ob;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InstaBot.Forms
{
    public partial class Giris : Form,IObserver
    {
        public Giris()
        {
            Control.CheckForIllegalCrossThreadCalls = false; // Threadlerin birbiri ile çakışmasını önlemek için
            InitializeComponent();
        }
        KullaniciSecimleri Secimler = KullaniciSecimleri.GetInstance();


        private void txtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            altpnlKullanici.BackColor = Color.Blue;
        }

        private void txtKullaniciAdi_Leave(object sender, EventArgs e)
        {
            altpnlKullanici.BackColor = Color.Gray;
        }

        private void txtSifre_Leave(object sender, EventArgs e)
        {
            altpnlSifre.BackColor = Color.Gray;
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            altpnlSifre.BackColor = Color.Blue;
        }
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            kullaniciAdi = kullaniciAdi.TrimStart();
            kullaniciAdi = kullaniciAdi.TrimEnd();

            sifre = sifre.TrimStart();
            sifre = sifre.TrimEnd();

            Secimler.GirisBilgileri.kullaniciAdi = kullaniciAdi;
            Secimler.GirisBilgileri.sifre = sifre;

            Komutlar komutlar = Komutlar.GetInstance();
            komutlar.VeriyiAlacak(this);
            komutlar.IslemSec();
        }
        
        //Begeni
        private void chckBegen_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBegen.Checked == true)
                pnlBegen.Enabled = true;
            else
                pnlBegen.Enabled = false;

            Secimler.Begen.begenecekMi = chckBegen.Checked;
        }
        private void nmrcBegeniSayisi_ValueChanged_1(object sender, EventArgs e)
        {
            Secimler.Begen.begeniSayisi = Convert.ToInt32(nmrcBegeniSayisi.Value);
        }
        //Yorum
        private void chckYorumYap_CheckedChanged(object sender, EventArgs e)
        {
            if (chckYorumYap.Checked == true)
                pnlYorum.Enabled = true;
            else
                pnlYorum.Enabled = false;

            Secimler.YorumYap.yorumYapacakMi = chckYorumYap.Checked;
        }
        private void nmrcYorumSayisi_ValueChanged(object sender, EventArgs e)
        {
            Secimler.YorumYap.yorumSayisi = Convert.ToInt32(nmrcYorumSayisi.Value);
        }
        private void cmbYorumGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Secimler.YorumYap.yorumGrubu = cmbYorumGrubu.Text;
        }
        private void chckYorumRasgele_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.YorumYap.rasgeleHarfEkle = chckYorumRasgele.Checked;
        }
        //Takip Etme
        private void chckTakipEt_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTakipEt.Checked == true)
                pnlTakipEt.Enabled = true;
            else
                pnlTakipEt.Enabled = false;

            Secimler.TakipEt.takipEdicekMi = chckTakipEt.Checked;
        }
        private void nmrcTakipSayisi_ValueChanged(object sender, EventArgs e)
        {
            Secimler.TakipEt.takipEtmeSayisi = Convert.ToInt32(nmrcTakipSayisi.Value);
        }
        private void chckYorumYapanlar_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.TakipEt.yorumlardanTkpEt = chckYorumYapanlardan.Checked;
        }
        private void chckBegenenleriTakipEt_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.TakipEt.begenilerdenTkpEt = chckBegenenleriTakipEt.Checked;
        }
        private void chckTakipEttiklerini_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.TakipEt.takipEttiklerindenTkpEt = chckTakipEttiklerini.Checked;
        }
        private void chckTakipçilerini_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.TakipEt.takipcilerdenTkpEt = chckTakipçilerini.Checked;
        }
        private void chckAcikHesap_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.TakipEt.acikHesaplariTkpEt = chckAcikHesap.Checked;
        }
        //Takipten Çık
        private void chckTakiptenCık_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTakiptenCık.Checked == true)
                pnlTakiptenCikma.Enabled = true;
            else
                pnlTakiptenCikma.Enabled = false;

            Secimler.TakiptenCik.takiptenCikacakMi = chckTakiptenCık.Checked;
        }
        private void nmrcTakiptenCkSayisi_ValueChanged(object sender, EventArgs e)
        {
            Secimler.TakiptenCik.takiptenCikmaSayisi = Convert.ToInt32(nmrcTakiptenCkSayisi.Value);
        }
        private void chckBeniTakipEdenler_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.TakiptenCik.geriTakipleriCikarma = chckBeniTakipEdenler.Checked;
        }

        //Takip İstekleri Kontrol
        private void chckIstekKontrol_CheckedChanged(object sender, EventArgs e)
        {
            if (chckIstekKontrol.Checked == true)
                pnlTakipIstegiKontrol.Enabled = true;
            else
                pnlTakipIstegiKontrol.Enabled = false;

            Secimler.TakipKontrol.takipKontrolEdilsinMi = chckIstekKontrol.Checked;
        }
        private void chckTakipKabulEtmeyenler_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.TakipKontrol.kabulEdilmeyenler = chckTakipKabulEtmeyenler.Checked;
        }

        private void chckBeniTakipEtmeyenler_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.TakipKontrol.takipEtmeyenleriCikar = chckTakipKabulEtmeyenler.Checked;
        }

        private void chckIstekKabulBegen_CheckedChanged(object sender, EventArgs e)
        {
            if (chckIstekKabulBegen.Checked==true)
                nmrcIstekKabulBegeniSayisi.Enabled = true;
            else
                nmrcIstekKabulBegeniSayisi.Enabled = true;

            Secimler.TakipKontrol.gonderiBegen = chckIstekKabulBegen.Checked;
        }

        private void nmrcKontrolSayisi_ValueChanged(object sender, EventArgs e)
        {
            Secimler.TakipKontrol.kontrolSayisi = Convert.ToInt32(nmrcKontrolSayisi.Value);
        }
        //Resim Al
        private void chckResimAl_CheckedChanged(object sender, EventArgs e)
        {
            if (chckResimAl.Checked == true)
                pnlResimAl.Enabled = true;
            else
                pnlResimAl.Enabled = false;

            Secimler.ResimAl.resimAlsinMi = chckResimAl.Checked;
        }
        private void nmrcResimAlmaSayisi_ValueChanged(object sender, EventArgs e)
        {
            Secimler.ResimAl.resimSayisi = Convert.ToInt32(nmrcResimAlmaSayisi.Value);
        }
        //Resim Paylaşma
        private void chckResimYukle_CheckedChanged(object sender, EventArgs e)
        {
            if (chckResimYukle.Checked == true)
                pnlResimPaylas.Enabled = true;
            else
                pnlResimPaylas.Enabled = false;

            Secimler.ResimPaylas.resimPaylasacakMi = chckResimYukle.Checked;
        }

        private void cmbResimPaylas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Secimler.ResimPaylas.resimGrubu = cmbResimPaylas.Text;
        }

        private void nmrcResimPySayisi_ValueChanged(object sender, EventArgs e)
        {
            Secimler.ResimPaylas.paylasimSayisi = Convert.ToInt32(nmrcResimPySayisi.Value);
        }
        //Bekleme Süreleri
        private void nmrcBegeniYorumMinSr_ValueChanged(object sender, EventArgs e)
        {
            Secimler.Begen.minSure = Convert.ToInt32(nmrcBegeniYorumMinSr.Value);
            Secimler.YorumYap.minSure = Convert.ToInt32(nmrcBegeniYorumMinSr.Value);
        }

        private void nmrcBegeniYorumMaxSr_ValueChanged(object sender, EventArgs e)
        {
            Secimler.Begen.maxSure = Convert.ToInt32(nmrcBegeniYorumMaxSr.Value);
            Secimler.YorumYap.maxSure = Convert.ToInt32(nmrcBegeniYorumMaxSr.Value);
        }

        private void nmrcTakipEtCkMinSr_ValueChanged(object sender, EventArgs e)
        {
            Secimler.TakipEt.minSure = Convert.ToInt32(nmrcTakipEtCkMinSr.Value);
            Secimler.TakiptenCik.minSure = Convert.ToInt32(nmrcTakipEtCkMinSr.Value);
        }

        private void nmrcTakipEtCkMaxSr_ValueChanged(object sender, EventArgs e)
        {
            Secimler.TakipEt.maxSure = Convert.ToInt32(nmrcTakipEtCkMaxSr.Value);
            Secimler.TakiptenCik.maxSure = Convert.ToInt32(nmrcTakipEtCkMaxSr.Value);
        }

        private void nmrcPaylasimMinSr_ValueChanged(object sender, EventArgs e)
        {
            Secimler.ResimPaylas.minSure = Convert.ToInt32(nmrcPaylasimMinSr.Value);
        }

        private void nmrcPaylasimMaxSr_ValueChanged(object sender, EventArgs e)
        {
            Secimler.ResimPaylas.maxSure = Convert.ToInt32(nmrcPaylasimMaxSr.Value);
        }

        //Kullanıcı/Hashtag Listesinden Tümünü Seçme
        private void chckTumuSec_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTumuSec.Checked == true)
            {
                for (int i = 0; i < chckLst.Items.Count; i++)
                {
                    chckLst.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < chckLst.Items.Count; i++)
                {
                    chckLst.SetItemChecked(i, false);
                }
            }
                       
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnBaslat_Click(btnBaslat, new EventArgs());
            }
        }

        public void VeriyiAl(ISubject subject)
        {
            listBox1.Items.Add((subject as Komutlar).Bilgi);
            // Listbox a veri aklenince en alta alma
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1;
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            btnBaslat_Click(btnBaslat, new EventArgs());
        }
    }
}
