using InstaBot.Codes;
using InstaBot.Database;
using InstaBot.Kullanicidan;
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
        AyarlarVeritabani AyarlarVeritabani = AyarlarVeritabani.GetInstance();
        KullaniciSecimleri Secimler = KullaniciSecimleri.GetInstance();
        VeriTabani VeriTabani = VeriTabani.GetInstance();
        Komutlar komutlar = Komutlar.GetInstance();

        private void Giris_Load(object sender, EventArgs e)
        {
            komutlar.VeriyiAlacak(this); //Komutlar Classından verileri almak için gerekli ayar
            KayitliAyarlar();
            ComboBoxAyarı();
        }
        public void VeriyiAl(ISubject subject)
        {
            listBox1.Items.Add((subject as Komutlar).Bilgi);
            // Listbox a veri aklenince en alta alma
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1;
        }

        private void KayitliAyarlar() //Enson seçtiği işlem ayarlarını veritabanından çekiyoruz ve formdaki ilgili kısımları dolduruyoruz
        {
            chckBegen.Checked = Secimler.Begen.begenecekMi;
            nmrcBegeniSayisi.Value = Secimler.Begen.begeniSayisi;
            chckAnaSayfaBegen.Checked = Secimler.Begen.anaSayfaBegen;
            lblBegeniSayisi.Text = Secimler.Begen.yapilanBegeniSayisi;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Begen

            chckYorumYap.Checked = Secimler.YorumYap.yorumYapacakMi;
            nmrcYorumSayisi.Value = Secimler.YorumYap.yorumSayisi;
            chckYorumRasgele.Checked = Secimler.YorumYap.rasgeleHarfEkle;
            cmbYorumGrubu.Text = Secimler.YorumYap.yorumGrubu;
            lblYorumSayisi.Text = Secimler.YorumYap.yapilanYorumSayisi;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ YorumYap

            chckTakipEt.Checked = Secimler.TakipEt.takipEdicekMi;
            nmrcTakipSayisi.Value = Secimler.TakipEt.takipEtmeSayisi;
            chckYorumYapanlardan.Checked = Secimler.TakipEt.yorumlardanTkpEt;
            chckTakipEttiklerini.Checked = Secimler.TakipEt.takipEttiklerindenTkpEt;
            chckTakipçilerini.Checked = Secimler.TakipEt.takipcilerdenTkpEt;
            chckAcikHesap.Checked = Secimler.TakipEt.acikHesaplariTkpEtme;
            lblTakipSayisi.Text = Secimler.TakipEt.takipEdilenSayi;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Et

            chckTakiptenCık.Checked = Secimler.TakiptenCik.takiptenCikacakMi;
            nmrcTakiptenCkSayisi.Value = Secimler.TakiptenCik.takiptenCikmaSayisi;
            lblTakiptenCıkmaSayisi.Text = Secimler.TakiptenCik.takiptenCikarilanSayi;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Çık

            chckIstekKontrol.Checked = Secimler.TakipKontrol.takipKontrolEdilsinMi;
            lblIstekSayisi.Text = Secimler.TakipKontrol.kontrolSayisi;
            chckAcik.Checked = Secimler.TakipKontrol.acikHesap;
            chckGizli.Checked = Secimler.TakipKontrol.gizliHesap;
            chckIstekKabulBegen.Checked = Secimler.TakipKontrol.gonderiBegen;
            nmrcTakipSayisi.Value = Secimler.TakipKontrol.begenilecekSayi;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip İsteği Kontrol

            chckResimAl.Checked = Secimler.ResimAl.resimAlsinMi;
            nmrcResimAlmaSayisi.Value = Secimler.ResimAl.resimSayisi;
            lblResimSayisi.Text = Secimler.ResimAl.alinanResimSayisi;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Al

            chckResimYukle.Checked = Secimler.ResimPaylas.resimPaylasacakMi;
            cmbResimPaylas.Text = Secimler.ResimPaylas.resimGrubu;
            nmrcResimPySayisi.Value = Secimler.ResimPaylas.paylasimSayisi;
            lblResimPaylasimSay.Text = Secimler.ResimPaylas.yapilanPySayisi;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Paylaş
        }

        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

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
        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBaslat_Click(btnBaslat, new EventArgs());
            }
        }
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            string gidilecekYer="";
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            if (rdHashtag.Checked)
                gidilecekYer = "https://www.instagram.com/explore/tags/";
            else if (rdKullaniciAdi.Checked)
                gidilecekYer = "https://www.instagram.com/";
            Secimler.GidilecekYer.Clear();
            foreach (var item in chckLst.CheckedItems)
            {
                Secimler.GidilecekYer.Add(gidilecekYer + item.ToString() + "/");
            }

            kullaniciAdi = kullaniciAdi.TrimStart();
            kullaniciAdi = kullaniciAdi.TrimEnd();

            sifre = sifre.TrimStart();
            sifre = sifre.TrimEnd();

            Secimler.GirisBilgileri.kullaniciAdi = kullaniciAdi;
            Secimler.GirisBilgileri.sifre = sifre;

            //komutlar.Baslat();

            AyarlarVeritabani.AyarlarıKaydet();
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
        private void chckAnaSayfaBegen_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.Begen.anaSayfaBegen = chckAnaSayfaBegen.Checked;
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
            Secimler.TakipEt.acikHesaplariTkpEtme = chckAcikHesap.Checked;
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
            Secimler.TakipKontrol.acikHesap = chckGizli.Checked;
        }

        private void chckBeniTakipEtmeyenler_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.TakipKontrol.gizliHesap = chckGizli.Checked;
        }

        private void chckIstekKabulBegen_CheckedChanged(object sender, EventArgs e)
        {
            if (chckIstekKabulBegen.Checked==true)
                nmrcIstekKabulBegeniSayisi.Enabled = true;
            else
                nmrcIstekKabulBegeniSayisi.Enabled = true;

            Secimler.TakipKontrol.gonderiBegen = chckIstekKabulBegen.Checked;
        }

        private void nmrcIstekKabulBegeniSayisi_ValueChanged(object sender, EventArgs e)
        {
            Secimler.TakipKontrol.begenilecekSayi = Convert.ToInt32(nmrcIstekKabulBegeniSayisi.Value);
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
        int Sure;
        private void nmrcBegeniYorumMinSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcBegeniYorumMinSr.Value);

            Sure = (1000 * Sure) / 60; // burada kulanıcının belirlediği saniyeyi milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.minBegenYorum = Sure;
        }

        private void nmrcBegeniYorumMaxSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcBegeniYorumMaxSr.Value);

            Sure = (1000 * Sure) / 60; // burada kulanıcının belirlediği saniyeyi milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.maxBegenYorum = Sure;
        }

        private void nmrcTakipEtCkMinSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcTakipEtCkMinSr.Value);

            Sure = (1000 * Sure) / 60; // burada kulanıcının belirlediği saniyeyi milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.minTakipEtCik = Sure;
        }

        private void nmrcTakipEtCkMaxSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcTakipEtCkMaxSr.Value);

            Sure = (1000 * Sure) / 60; // burada kulanıcının belirlediği saniyeyi milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.maxTakipEtCik = Sure;
        }

        private void nmrcPaylasimMinSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcPaylasimMinSr.Value);

            Sure *= 1000; // burada kulanıcının belirlediği dk milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.minResimPay = Sure;
        }

        private void nmrcPaylasimMaxSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcPaylasimMaxSr.Value);

            Sure *=1000; // burada kulanıcının belirlediği dk milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.maxResimPay = Sure;
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ bekleme sürelerini numarikten alıp milisaniye cinsine çevirip KullaniciSecimleri.cs ye kaydettik
        private void ComboBoxAyarı() // burada veritabanından kullanıcı ve hashtaglerin grup adlarını combobox a ekledik
        {
            if (rdHashtag.Checked)
            {
                foreach (var item in Secimler.HashtagGrup) // hashtag gruplarını Ekledik
                {
                    cmbKulHasGrup.Items.Add(item);
                }
                lblKullaniciHashtag.Text = "Gruba yeni hashtag";
            }
            else if (rdKullaniciAdi.Checked)
            {
                foreach (var item in Secimler.KullaniciAdigGrup) // kullanıcı adi gruplarını Ekledik
                {
                    cmbKulHasGrup.Items.Add(item);
                }
                lblKullaniciHashtag.Text = "Gruba yeni kullanıcı adı";
            }
            if (cmbKulHasGrup.Items.Count != 0)//combobox daki ilk değeri seçme
            {
                cmbKulHasGrup.SelectedIndex = 0;
            }
        }

        private void cmbKulHasGrup_SelectedValueChanged(object sender, EventArgs e) // cmbxKulHasGrup de grup seçilirse
        {
            chckLst.Items.Clear();
            chckTumuSec.Checked = false;
            if (rdKullaniciAdi.Checked)
            {
                foreach (var item in Secimler.ListKullaniciAdi) // CheckList e ilgili grubun bilgilerini girdik
                {
                    if (item.grupAdi == cmbKulHasGrup.SelectedItem.ToString())
                    {
                        chckLst.Items.Add(item.kullaniciAdi);
                    }
                }
            }
            else if (rdHashtag.Checked)
            {
                foreach (var item in Secimler.ListHashtags)
                {
                    if (item.grupAdi == cmbKulHasGrup.SelectedItem.ToString())
                    {
                        chckLst.Items.Add(item.hashtag);
                    }
                }
            }           
            
        }

        private void rdKullaniciAdi_CheckedChanged(object sender, EventArgs e)
        {
            cmbKulHasGrup.Items.Clear();
            chckTumuSec.Checked = false;
            if (rdKullaniciAdi.Checked)
            {
                foreach (var item in Secimler.KullaniciAdigGrup) // grupları Ekledik
                {
                    cmbKulHasGrup.Items.Add(item);
                }

                if (cmbKulHasGrup.Items.Count != 0)//combobox daki ilk değeri seçme
                {
                    cmbKulHasGrup.SelectedIndex = 0;
                }
                lblKullaniciHashtag.Text = "Gruba yeni kullanıcı adı";
            }
        }

        private void rdHashtag_CheckedChanged(object sender, EventArgs e)
        {
            cmbKulHasGrup.Items.Clear();
            chckTumuSec.Checked = false;
            if (rdHashtag.Checked)
            {
                foreach (var item in Secimler.HashtagGrup) // grupları Ekledik
                {
                    cmbKulHasGrup.Items.Add(item);
                }
                if (cmbKulHasGrup.Items.Count != 0) //combobox daki ilk değeri seçme
                {
                    cmbKulHasGrup.SelectedIndex = 0;
                }
                lblKullaniciHashtag.Text = "Gruba yeni hashtag";
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string grupAdi = cmbKulHasGrup.Text;
            string eklenen = txtEklenen.Text;
            eklenen = eklenen.TrimStart().TrimEnd();
            grupAdi = grupAdi.TrimStart().TrimEnd();
            if (rdHashtag.Checked)
            {
                VeriTabani.KullaniciHashtagEkle("tbl_Hashtag", grupAdi,eklenen);
            }
            else if (rdKullaniciAdi.Checked)
                VeriTabani.KullaniciHashtagEkle("tbl_KullaniciAdi", grupAdi, eklenen);

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

        
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ cmbxKulasGrup kısmı ayarları
    }
}
