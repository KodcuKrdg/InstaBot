using InstaBot.Codes;
using InstaBot.Database;
using InstaBot.Kullanicidan;
using InstaBot.Kullanicidan.BaseClass;
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
    public partial class Islemler : Form,IObserver
    {
        public Islemler()
        {
            Control.CheckForIllegalCrossThreadCalls = false; // Threadlerin birbiri ile çakışmasını önlemek için
            InitializeComponent();
        }
        AyarlarVeritabani AyarlarVeritabani = AyarlarVeritabani.GetInstance();
        KullaniciSecimleri Secimler = KullaniciSecimleri.GetInstance();
        VeriTabani VeriTabani = VeriTabani.GetInstance();
        Komutlar Komutlar = Komutlar.GetInstance();
        
        Random random = new Random();

        private void Giris_Load(object sender, EventArgs e)
        {
            Komutlar.VeriyiAlacak(this); //Komutlar Classından verileri almak için gerekli ayar
            KulHasListeVerileri();
            YorumGrubu();
            KayitliAyarlar();
        }
        public void YenidenLoad()
        {
            KulHasListeVerileri();
            YorumGrubu();
            KayitliAyarlar();
        }
        public void VeriyiAl(ISubject subject)
        {
            
            // Listbox a veri aklenince en alta alma
            if ((subject as Komutlar).Bilgi != "") // Gelen Boş ise yapılan işlem sayılarını yeniliyor demektir
            {
                lstBxYapilan.Items.Add((subject as Komutlar).Bilgi);
                lstBxYapilan.SelectedIndex = lstBxYapilan.Items.Count - 1;
                lstBxYapilan.SelectedIndex = -1;
            }
            
            
            YapilanIslemSayilari();
        }

        private void YapilanIslemSayilari() // Gün içinde yapılan işlemlerin sayısının gerekli labelara atadık onları forma yazar
        {
            lblBegeniSayisi.Text = Secimler.Begen.yapilanBegeniSayisi.ToString();
            lblYorumSayisi.Text = Secimler.YorumYap.yapilanYorumSayisi.ToString();
            lblTakipSayisi.Text = Secimler.TakipEt.takipEdilenSayi.ToString();
            lblTakiptenCıkmaSayisi.Text = Secimler.TakiptenCik.takiptenCikarilanSayi.ToString();
            lblResimSayisi.Text = Secimler.ResimAl.alinanResimSayisi.ToString();
            lblResimPaylasimSay.Text = Secimler.ResimPaylas.yapilanPySayisi.ToString();

            lblIstekSayisi.Text = Secimler.IstekKontrol.IstekSayisi.ToString();
            if (Secimler.IstekKontrol.IstekSayisi == 0) // Kontrol edilecek takip isteği yok o zmn takip isteği kontrol kısmını kapalı olsun
            {
                chckIstekKontrol.Checked = false;
                chckIstekKontrol.Enabled = false;
            }
        }

        private void KayitliAyarlar() //Enson seçtiği işlem ayarlarını veritabanından çekiyoruz ve formdaki ilgili kısımları dolduruyoruz
        {
            txtKullaniciAdi.Text = Secimler.GirisBilgileri.kullaniciAdi;
            txtSifre.Text = Secimler.GirisBilgileri.sifre;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Giriş bilgileri
            chckBegen.Checked = Secimler.Begen.begenecekMi;
            nmrcBegeniSayisi.Value = Secimler.Begen.begeniSayisi;
            chckAnaSayfaBegen.Checked = Secimler.Begen.anaSayfaBegen;
            nmrcAnaSySayi.Value = Secimler.Begen.anaSyBegeniSayisi;
            lblBegeniSayisi.Text = Secimler.Begen.yapilanBegeniSayisi.ToString();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Begen

            chckYorumYap.Checked = Secimler.YorumYap.yorumYapacakMi;
            nmrcYorumSayisi.Value = Secimler.YorumYap.yorumSayisi;
            chckYorumRasgele.Checked = Secimler.YorumYap.rasgeleHarfEkle;

            if (Secimler.YorumGrubu.Contains(Secimler.YorumYap.yorumGrubu)) // Son yapıulan yorum grubu eğer silinmediyse
            {
                cmbYorumGrubu.Text = Secimler.YorumYap.yorumGrubu;
            }
            
            lblYorumSayisi.Text = Secimler.YorumYap.yapilanYorumSayisi.ToString();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ YorumYap

            chckTakipEt.Checked = Secimler.TakipEt.takipEdicekMi;
            nmrcTakipSayisi.Value = Secimler.TakipEt.takipEtmeSayisi;
            chckYorumYapanlardan.Checked = Secimler.TakipEt.yorumlardanTkpEt;
            chckTakipEttiklerini.Checked = Secimler.TakipEt.takipEttiklerindenTkpEt;
            chckTakipçilerini.Checked = Secimler.TakipEt.takipcilerdenTkpEt;
            chckAcikHesap.Checked = Secimler.TakipEt.acikHesaplariTkpEt;
            lblTakipSayisi.Text = Secimler.TakipEt.takipEdilenSayi.ToString();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Et

            chckTakiptenCık.Checked = Secimler.TakiptenCik.takiptenCikacakMi;
            nmrcTakiptenCkSayisi.Value = Secimler.TakiptenCik.takiptenCikmaSayisi;
            lblTakiptenCıkmaSayisi.Text = Secimler.TakiptenCik.takiptenCikarilanSayi.ToString();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip Çık

            chckIstekKontrol.Checked = Secimler.IstekKontrol.takipKontrolEdilsinMi;
            lblIstekSayisi.Text = Secimler.IstekKontrol.IstekSayisi.ToString();
            nmrcMaxKontrolSayisi.Maximum = Secimler.IstekKontrol.IstekSayisi;
            chckAcik.Checked = Secimler.IstekKontrol.acikHesap;
            chckGizli.Checked = Secimler.IstekKontrol.gizliHesap;
            chckIstekKabulBegen.Checked = Secimler.IstekKontrol.gonderiBegen;
            nmrcIstekKabulBegeniSayisi.Value = Secimler.IstekKontrol.begenilecekSayi;

            if (Secimler.IstekKontrol.IstekSayisi > Secimler.IstekKontrol.kontrolSayisi) // Maxsimum değer önceki kontrol sayısından büyükse yazsın küçükse istek atılan sayıyı yazsın
            {
                nmrcMaxKontrolSayisi.Value = Secimler.IstekKontrol.kontrolSayisi;
            }
            else
                nmrcMaxKontrolSayisi.Value = Secimler.IstekKontrol.IstekSayisi;

            if (Secimler.IstekKontrol.IstekSayisi == 0) // Kontrol edilecek takip isteği yok o zmn takip isteği kontrol kısmını kapalı olsun
            {
                chckIstekKontrol.Checked = false;
                chckIstekKontrol.Enabled = false;
            }
            else
            {
                chckIstekKontrol.Checked = true;
                chckIstekKontrol.Enabled = true;
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Takip İsteği Kontrol

            chckResimAl.Checked = Secimler.ResimAl.resimAlsinMi;
            nmrcResimAlmaSayisi.Value = Secimler.ResimAl.resimSayisi;
            lblResimSayisi.Text = Secimler.ResimAl.alinanResimSayisi.ToString();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Al

            chckResimYukle.Checked = Secimler.ResimPaylas.resimPaylasacakMi;
            cmbResimPaylas.Text = Secimler.ResimPaylas.resimGrubu;
            nmrcResimPySayisi.Value = Secimler.ResimPaylas.paylasimSayisi;
            lblResimPaylasimSay.Text = Secimler.ResimPaylas.yapilanPySayisi.ToString();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Resim Paylaş
            //Bu çarpma işlemleri veritabanına milisaniye cinsinden karşılığğını kaydettiğimiz için ekrana saniye cinsine çevirdik
            nmrcBegeniMinSr.Value = Secimler.Sureler.minBegen / 1000;
            nmrcBegeniMaxSr.Value = Secimler.Sureler.maxBegen / 1000;
            nmrcYorumMinSr.Value = Secimler.Sureler.minYorum / 1000;
            nmrcYorumMaxSr.Value = Secimler.Sureler.maxYorum / 1000;
            nmrcTakipEtCkMinSr.Value = Secimler.Sureler.minTakipEtCik  / 1000;
            nmrcTakipEtCkMaxSr.Value = Secimler.Sureler.maxTakipEtCik  / 1000;
            nmrcPaylasimMinSr.Value = Secimler.Sureler.minResimPay / 10000;
            nmrcPaylasimMaxSr.Value = Secimler.Sureler.maxResimPay / 10000;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ İşlemler Arası Bekleme Süreleri

            rdHashtag.Checked = false; //Bunun sebebi rdHastag metodundaki işlemler yapılsın diye
            rdHashtag.Checked = true; //Bunun sebebi rdHastag metodundaki işlemler yapılsın diye
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
        private void YorumGrubu()
        {
            if (Secimler.YorumGrubu.Count>0)
            {
                foreach (var item in Secimler.YorumGrubu)
                {
                    cmbYorumGrubu.Items.Add(item);
                }
            }
        }
        private void chckYorumYap_CheckedChanged(object sender, EventArgs e)
        {
            if (chckYorumYap.Checked == true)
            {
                if (cmbYorumGrubu.Items.Count>0)
                {
                    pnlYorum.Enabled = true;
                }
                else
                {
                    pnlYorum.Enabled = false;
                    chckYorumYap.Checked = false;
                    MessageBox.Show("Lütfen Yorum grubu oluşturunuz!", "Yorum Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            if (Secimler.YorumYap.yorumYapacakMi) // Açılınca ycmbyorum dolduruluyor ve listboxta gösteriliyor adam yorum yapmıcaksa göstermesin
            {
                int sayac = 1;
                Secimler.YorumYap.yorumGrubu = cmbYorumGrubu.Text;

                lstBxYapilan.Items.Clear();
                lstBxYapilan.Items.Add("Seçitiği yorum grubundaki yorumlar");
                foreach (var item in Secimler.ListYorumlar) // Yorum seçilince içindeki yorumları gösteriyoruz
                {
                    if (item.grupAdi == cmbYorumGrubu.Text)
                    {
                        lstBxYapilan.Items.Add(sayac.ToString() + " -> " + item.yorum);
                        sayac++;
                    }
                }
            }
            
        }
        private void chckYorumRasgele_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.YorumYap.rasgeleHarfEkle = chckYorumRasgele.Checked;
        }
        //Takip Etme
        private void chckTakipEt_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTakipEt.Checked == true)
            {
                pnlTakipEt.Enabled = true;
                if (chckYorumYapanlardan.Enabled)
                {
                    chckYorumYapanlardan.Checked = true;
                }
                else
                    chckTakipçilerini.Checked = true;
            }
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
        //Takip İstekleri Kontrol
        private void chckIstekKontrol_CheckedChanged(object sender, EventArgs e)
        {
            if (chckIstekKontrol.Checked == true)
                pnlTakipIstegiKontrol.Enabled = true;
            else
                pnlTakipIstegiKontrol.Enabled = false;

            Secimler.IstekKontrol.takipKontrolEdilsinMi = chckIstekKontrol.Checked;
        }
        private void chckAcik_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.IstekKontrol.acikHesap = chckAcik.Checked;
        }

        private void chckGizli_CheckedChanged(object sender, EventArgs e)
        {
            Secimler.IstekKontrol.gizliHesap = chckGizli.Checked;
        }

        private void chckIstekKabulBegen_CheckedChanged(object sender, EventArgs e)
        {
            if (chckIstekKabulBegen.Checked==true)
                nmrcIstekKabulBegeniSayisi.Enabled = true;
            else
                nmrcIstekKabulBegeniSayisi.Enabled = true;

            Secimler.IstekKontrol.gonderiBegen = chckIstekKabulBegen.Checked;
        }

        private void nmrcIstekKabulBegeniSayisi_ValueChanged(object sender, EventArgs e)
        {
            Secimler.IstekKontrol.begenilecekSayi = Convert.ToInt32(nmrcIstekKabulBegeniSayisi.Value);
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
            Sure = Convert.ToInt32(nmrcBegeniMinSr.Value);

            Sure *=1000; // burada kulanıcının belirlediği saniyeyi milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.minBegen = Sure;
        }

        private void nmrcBegeniYorumMaxSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcBegeniMaxSr.Value);

            Sure *= 1000; // burada kulanıcının belirlediği saniyeyi milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.maxBegen = Sure;
        }

        private void nmrcYorumMinSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcYorumMinSr.Value);

            Sure *= 1000; // burada kulanıcının belirlediği saniyeyi milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.minYorum = Sure;
        }

        private void nmrcYorumMaxSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcYorumMaxSr.Value);

            Sure *= 1000; // burada kulanıcının belirlediği saniyeyi milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.maxYorum = Sure;
        }

        private void nmrcTakipEtCkMinSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcTakipEtCkMinSr.Value);

            Sure *= 1000; // burada kulanıcının belirlediği saniyeyi milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.minTakipEtCik = Sure;
        }

        private void nmrcTakipEtCkMaxSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcTakipEtCkMaxSr.Value);

            Sure *= 1000; // burada kulanıcının belirlediği saniyeyi milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.maxTakipEtCik = Sure;
        }

        private void nmrcPaylasimMinSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcPaylasimMinSr.Value);

            Sure *= 10000; // burada kulanıcının belirlediği dk milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.minResimPay = Sure;
        }

        private void nmrcPaylasimMaxSr_ValueChanged(object sender, EventArgs e)
        {
            Sure = Convert.ToInt32(nmrcPaylasimMaxSr.Value);

            Sure *=10000; // burada kulanıcının belirlediği dk milisaniye cinsinden karşılığını alıyoruz

            Secimler.Sureler.maxResimPay = Sure;
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ bekleme sürelerini numarikten alıp milisaniye cinsine çevirip KullaniciSecimleri.cs ye kaydettik
        private void KulHasListeVerileri() // burada veritabanından kullanıcı ve hashtaglerin grup adlarını combobox a ekledik
        {
            chckLst.Items.Clear();
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
                foreach (var item in Secimler.KullaniciAdiGrup) // kullanıcı adi gruplarını Ekledik
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
                foreach (var item in Secimler.KullaniciAdiGrup) // grupları Ekledik
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
            if (rdHashtag.Checked)
            {
                chckTakipEttiklerini.Checked = false;
                chckTakipEttiklerini.Enabled = false;

                chckTakipçilerini.Checked = false;
                chckTakipçilerini.Enabled = false;

                chckYorumYapanlardan.Enabled = true;
            }
            else
            {
                chckTakipEttiklerini.Enabled = true;

                chckTakipçilerini.Enabled = true;

                chckYorumYapanlardan.Checked = false;
                chckYorumYapanlardan.Enabled = false;
            }
            txtEklenen.Clear();
            cmbKulHasGrup.Items.Clear();
            chckLst.Items.Clear();
            cmbKulHasGrup.Text = "";
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
            chckLst.Items.Add(eklenen);
            if (rdHashtag.Checked)
            {
                VeriTabani.KullaniciHashtagYorumEkle("tbl_Hashtag", grupAdi,eklenen);
            }
            else if (rdKullaniciAdi.Checked)
                VeriTabani.KullaniciHashtagYorumEkle("tbl_KullaniciAdi", grupAdi, eklenen);
            txtEklenen.Clear();
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
        private void txtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            altpnlKullanici.BackColor = Color.FromArgb(120, 89, 100);
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
            altpnlSifre.BackColor = Color.FromArgb(120, 89, 100);
        }

        [Obsolete]
        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBaslat_Click(btnBaslat, new EventArgs());
            }
        }
        private void IslemleriKapaAc(bool kapaAc)
        {

            for (int i = 0; i < pnlIslemler.Controls.Count ; i++) 
            {
                //son iki özellik aktif değil
                if (pnlIslemler.Controls[i].Name!= "chckResimAl" && pnlIslemler.Controls[i].Name != "pnlResimAl" && pnlIslemler.Controls[i].Name != "chckResimYukle" && pnlIslemler.Controls[i].Name != "pnlResimPaylas")
                {
                    pnlIslemler.Controls[i].Enabled = kapaAc;
                }
                
            }

            grpKullaniciHashtag.Enabled = kapaAc;
            grpSure.Enabled = kapaAc;
            txtKullaniciAdi.Enabled = kapaAc;
            txtSifre.Enabled = kapaAc;
        }
        [Obsolete]
        private void btnBaslat_Click(object sender, EventArgs e)
        {

            string gidilecekYer = "";
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            txtEklenen.Clear();
            lstBxYapilan.Items.Clear();

            kullaniciAdi = kullaniciAdi.TrimStart();
            kullaniciAdi = kullaniciAdi.TrimEnd();

            sifre = sifre.TrimStart();
            sifre = sifre.TrimEnd();

            Secimler.GirisBilgileri.kullaniciAdi = kullaniciAdi;
            Secimler.GirisBilgileri.sifre = sifre;

            AyarlarVeritabani.AyarlarıKaydet();

            if (btnBaslat.Text == "Başlat")
            {
                
                if (Secimler.YorumYap.yorumYapacakMi || Secimler.TakipEt.takipEdicekMi) // chckliste seçilecek bireşy yok ve seçim yapmamış
                {
                    if (chckLst.Items.Count==0 && chckLst.CheckedItems.Count == 0)
                    {
                        if (rdHashtag.Checked)
                        {
                            MessageBox.Show("Hiç hashtag yoktur. Lütfen 'Listeler' sayfasından hashtag ekleyin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (rdKullaniciAdi.Checked)
                        {
                            MessageBox.Show("Hiç kulanıcı adı yoktur. Lütfen 'Listeler' sayfasından kullanıcı adı ekleyin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                    else if (chckLst.CheckedItems.Count == 0) // Chckliste seçilecek değer var fakat seçim yapmamış
                    {
                        MessageBox.Show("Lütfen Hashtag veya Kullanıcı Adi seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (rdHashtag.Checked)
                            gidilecekYer = "https://www.instagram.com/explore/tags/";
                        else if (rdKullaniciAdi.Checked)
                            gidilecekYer = "https://www.instagram.com/";
                        Secimler.GidilecekYer.Clear();

                        foreach (var item in chckLst.CheckedItems) // Gidilecek Hashtagler veya Kullanıcı Adları
                        {
                            Secimler.GidilecekYer.Add(gidilecekYer + item.ToString() + "/");
                        }

                        foreach (var item in Secimler.ListYorumlar) // Yapılacak Yorumlar
                        {
                            if (item.grupAdi == cmbYorumGrubu.Text)
                            {
                                if (chckYorumRasgele.Checked)
                                    Secimler.YapilacakYorumlar.Add(item.yorum + " " + item.yorum.Substring(random.Next(item.yorum.Length - 1), 1)); // burada yorumun için rasgele bir harf seçtik ve sonuna bir boşluk ekleyip harfi yerleştirdik yorumu farklılaştırdık
                                else
                                    Secimler.YapilacakYorumlar.Add(item.yorum);

                            }
                        }
                        btnBaslat.Text = "Bitir";
                        Komutlar.Baslat();
                        IslemleriKapaAc(false);
                    }
                }
                else
                {
                    IslemleriKapaAc(false);
                    Komutlar.Baslat();
                    btnBaslat.Text = "Bitir";
                }
            }
            else
            {
                Komutlar.Bitir();
                IslemleriKapaAc(true);
                btnBaslat.Text = "Başlat";
            }
        }

        private void nmrcMaxKontrolSayisi_ValueChanged(object sender, EventArgs e)
        {
            Secimler.IstekKontrol.kontrolSayisi = Convert.ToInt32(nmrcMaxKontrolSayisi.Value);
        }

        private void nmrcAnaSySayi_ValueChanged(object sender, EventArgs e)
        {
            Secimler.Begen.anaSyBegeniSayisi = Convert.ToInt32(nmrcAnaSySayi.Value);
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            Secimler.GirisBilgileri.kullaniciAdi = txtKullaniciAdi.Text;
            VeriTabani.IstekAtilanHesaplar();
            KayitliAyarlar();
        }
    }
}
