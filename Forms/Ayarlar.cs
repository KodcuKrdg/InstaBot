using InstaBot.BaseClass;
using InstaBot.Codes;
using InstaBot.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaBot.Forms
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        VeriTabani VeriTabani = VeriTabani.GetInstance();
        KullaniciSecimleri Secimler = KullaniciSecimleri.GetInstance();

        List<ListListedekiDeger> listedekiDeger = new List<ListListedekiDeger>();
        private void Ayarlar_Load(object sender, EventArgs e)
        {
            ComboxAyarları();
        }

        private void ComboxAyarları()
        {
            cmbHashtag.Items.Clear();
            cmbYorum.Items.Clear();
            cmbKullanici.Items.Clear();

            if (Secimler.ListYorumlar.Count > 0)
            {
                foreach (var item in Secimler.YorumGrubu)
                {
                    cmbYorum.Items.Add(item);
                }
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Yorum

            if (Secimler.ListHashtags.Count > 0)
            {
                foreach (var item in Secimler.HashtagGrup)
                {
                    cmbHashtag.Items.Add(item);
                }
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Hashtag

            if (Secimler.ListKullaniciAdi.Count > 0)
            {
                foreach (var item in Secimler.KullaniciAdiGrup)
                {
                    cmbKullanici.Items.Add(item);
                }
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Kullanıcı Adı
        }

        private void cmbYorum_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtYorumGrupAdi.Text = cmbYorum.Text;

            txtYorum.Enabled = true;
            btnYorumEkle.Enabled = true;
            btnGrupYorumSil.Enabled = true;
            btnGrupYorumDuzenle.Enabled = true;

            int sayac = 1;
            lstBx.Items.Clear();
            listedekiDeger.Clear();
            foreach (var item in Secimler.ListYorumlar)
            {
                if (item.grupAdi== cmbYorum.Text)
                {
                    lstBx.Items.Add(sayac.ToString()+" -> "+item.yorum);
                    listedekiDeger.Add(new ListListedekiDeger { id = item.id, anaDeger = item.yorum, nerenin = "tbl_Yorumlar", grupAdi = item.grupAdi });
                    sayac++;
                }
            }
        }

        private void btnGrupYorumEkle_Click(object sender, EventArgs e)
        {
            if (btnGrupYorumEkle.Text == "Grup Ekle")
            {
                txtYorumGrupAdi.Enabled = true;
                txtYorum.Enabled = true;
                btnYorumEkle.Enabled = true;


                btnGrupYorumDuzenle.Enabled = false;
                btnGrupYorumSil.Enabled = false;
                cmbYorum.Enabled = false;

                txtYorumGrupAdi.Clear();
                txtYorumGrupAdi.Focus();

                btnGrupYorumEkle.Text = "İptal";
                btnYorumEkle.Text = "Grubu kaydet";
            }
            else
            {
                btnYorumEkle.Text = "Yorum Ekle";
                btnGrupYorumEkle.Text = "Grup Ekle";
                btnGrupYorumDuzenle.Enabled = true;
                btnGrupYorumSil.Enabled = true; 
                cmbYorum.Enabled = true;

                txtYorumGrupAdi.Enabled = false;
                txtYorumGrupAdi.Text = cmbYorum.Text;

            }
        }

        private void btnYorumEkle_Click(object sender, EventArgs e)
        {
            int sayac = 1;
            string grupAdi = txtYorumGrupAdi.Text;
            string yorum = txtYorum.Text;

            grupAdi = grupAdi.TrimStart().TrimStart();
            yorum = yorum.TrimStart().TrimStart();

            switch (btnYorumEkle.Text)
            {

                case "Yorum Ekle":
                    {
                        if (yorum.Length > 0 && grupAdi.Length > 0)
                        {
                            VeriTabani.KullaniciHashtagYorumEkle("tbl_Yorumlar", grupAdi, yorum);

                            txtYorum.Clear();
                            txtYorum.Focus();

                            lstBx.Items.Clear();
                            listedekiDeger.Clear();
                            foreach (var item in Secimler.ListYorumlar)
                            {
                                if (item.grupAdi == grupAdi)
                                {
                                    lstBx.Items.Add(sayac + " -> " + item.yorum);
                                    listedekiDeger.Add(new ListListedekiDeger { id = item.id, anaDeger = item.yorum, nerenin = "tbl_Yorumlar", grupAdi = item.grupAdi }); // ListBoxdan değer silmek yada düzenlemekte kontrol amaçlı kulanıyoruz
                                    sayac++;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Yorum giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                case "Grubu kaydet":
                    {
                        if (!Secimler.YorumGrubu.Contains(grupAdi))
                        {
                            if (yorum.Length > 0 && grupAdi.Length > 0)
                            {
                                VeriTabani.KullaniciHashtagYorumEkle("tbl_Yorumlar", grupAdi, yorum);

                                ComboxAyarları();
                                cmbYorum.SelectedIndex = cmbYorum.Items.Count - 1; // Eklediğimiz herzaman en sonuncusu olduğundan list box da onu yorumları olsun diye

                                txtYorum.Clear();
                                txtYorum.Focus();

                                btnYorumEkle.Text = "Yorum Ekle";
                                btnGrupYorumEkle.Text = "Grup Ekle";
                                btnGrupYorumSil.Enabled = true;
                                btnGrupYorumDuzenle.Enabled = true;
                                cmbYorum.Enabled = true;

                                txtYorumGrupAdi.Enabled = false;
                            }
                            else
                                MessageBox.Show("Grup adi ve yorum giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show(grupAdi + " adlı grup bulunmaktadır! Farklı bir ad belirleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    }
                case "Grup Adını düzelt":
                    {
                        VeriTabani.GrupAdlariniGuncelle("tbl_Yorumlar", cmbYorum.Text, grupAdi);

                        for (int i = 0; i < Secimler.YorumGrubu.Count; i++) // değişen grubum adını Secimler.YorumGrubu deki değerini eğiştirdik
                        {
                            if (Secimler.YorumGrubu[i] == cmbYorum.Text)
                            {
                                Secimler.YorumGrubu[i] = grupAdi;
                            }
                        }

                        cmbYorum.Text = grupAdi;
                        ComboxAyarları();

                        btnYorumEkle.Text = "Yorum Ekle";
                        btnGrupYorumDuzenle.Text = "Adı Düzenle";
                        txtYorumGrupAdi.Text = cmbYorum.Text;

                        cmbYorum.Enabled = true;
                        btnGrupYorumEkle.Enabled = true;
                        btnGrupYorumSil.Enabled = true;
                        txtYorum.Enabled = true;

                        txtYorumGrupAdi.Enabled = false;
                        break;
                    }
                case "Yorumu Düzelt":
                    {
                        string yeniYorum = txtYorum.Text.TrimStart().TrimEnd();

                        btnYorumEkle.Text = "Yorum Ekle";

                        VeriTabani.YorumHashtagKullaniciGuncelle(listedekiDeger[lstBx.SelectedIndex].nerenin, listedekiDeger[lstBx.SelectedIndex].id, yeniYorum);

                        for (int i = 0; i < Secimler.ListYorumlar.Count; i++)
                        {
                            if (Secimler.ListYorumlar[i].id == listedekiDeger[lstBx.SelectedIndex].id)
                            {
                                Secimler.ListYorumlar[i].yorum = yeniYorum;
                            }
                        }

                        lstBx.Items.Clear();
                        listedekiDeger.Clear();
                        foreach (var item in Secimler.ListYorumlar)
                        {
                            if (item.grupAdi == grupAdi)
                            {
                                lstBx.Items.Add(sayac + " -> " + item.yorum);
                                listedekiDeger.Add(new ListListedekiDeger { id = item.id, anaDeger = item.yorum, nerenin = "tbl_Yorumlar", grupAdi = item.grupAdi }); // ListBoxdan değer silmek yada düzenlemekte kontrol amaçlı kulanıyoruz
                                sayac++;
                            }
                        }

                        YorumDuzeltmeSonrasi();

                        break;
                    }
            }
        }

        private void btnGrupYorumDuzenle_Click(object sender, EventArgs e)
        {
            if (btnGrupYorumDuzenle.Text == "Adı Düzenle")
            {
                btnGrupYorumDuzenle.Text = "İptal";
                btnYorumEkle.Text = "Grup Adını düzelt";

                cmbYorum.Enabled = false;
                btnGrupYorumEkle.Enabled = false;
                btnGrupYorumSil.Enabled = false;
                txtYorum.Enabled = false;

                txtYorumGrupAdi.Enabled = true;
            }
            else
            {
                btnYorumEkle.Text = "Yorum Ekle";
                btnGrupYorumDuzenle.Text = "Adı Düzenle";
                txtYorumGrupAdi.Text = cmbYorum.Text;

                cmbYorum.Enabled = true;
                btnGrupYorumEkle.Enabled = true;
                btnGrupYorumSil.Enabled = true;
                txtYorum.Enabled = true;

                txtYorumGrupAdi.Enabled = false;

            }
        }

        private void btnGrupYorumSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("'" + cmbYorum.Text + "' grubu silinicektir!", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                VeriTabani.GruplarıSil("tbl_Yorumlar", cmbYorum.Text);
                Secimler.YorumGrubu.Remove(cmbYorum.Text);
                ComboxAyarları();
                if (cmbYorum.Items.Count > 0)
                {
                    cmbYorum.SelectedIndex = 0;
                }
                else
                {
                    cmbYorum.Text = "";
                    lstBx.Items.Clear();
                    txtYorumGrupAdi.Clear();
                    btnGrupYorumDuzenle.Enabled = false;
                }


            }
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Yorum
        private void btnHashtagGrupEkle_Click(object sender, EventArgs e)
        {
            if (btnHashtagGrupEkle.Text == "Grup Ekle")
            {
                txtHashtagGrupAdi.Enabled = true;
                txtHashtagEkle.Enabled = true;
                btnHashtagEkle.Enabled = true;


                btnGrupHashtag.Enabled = false;
                btnHastagGrupSil.Enabled = false;
                cmbHashtag.Enabled = false;

                txtYorumGrupAdi.Clear();
                txtYorumGrupAdi.Focus();

                btnHashtagGrupEkle.Text = "İptal";
                btnHashtagEkle.Text = "Grubu kaydet";
            }
            else
            {
                btnHashtagEkle.Text = "Hashtag Ekle";
                btnHashtagGrupEkle.Text = "Grup Ekle";
                btnGrupHashtag.Enabled = true;
                btnHastagGrupSil.Enabled = true;
                cmbHashtag.Enabled = true;

                txtHashtagGrupAdi.Enabled = false;
                txtYorumGrupAdi.Text = cmbHashtag.Text;

            }
        }

        private void btnHashtagAdiDuznele_Click(object sender, EventArgs e)
        {
            if (btnGrupHashtag.Text == "Adı Düzenle")
            {
                btnGrupHashtag.Text = "İptal";
                btnHashtagEkle.Text = "Grup Adını düzelt";

                cmbHashtag.Enabled = false;
                btnHashtagGrupEkle.Enabled = false;
                btnHastagGrupSil.Enabled = false;
                txtHashtagEkle.Enabled = false;

                txtHashtagGrupAdi.Enabled = true;
            }
            else
            {
                btnGrupHashtag.Text = "Adı Düzenle";
                btnHashtagEkle.Text = "Hashtag Ekle";
                txtHashtagGrupAdi.Text = cmbHashtag.Text;

                cmbHashtag.Enabled = true;
                btnGrupHashtag.Enabled = true;
                btnHastagGrupSil.Enabled = true;
                txtHashtagEkle.Enabled = true;

                txtHashtagGrupAdi.Enabled = false;

            }
        }

        private void btnHastagGrupSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("'" + cmbHashtag.Text + "' grubu silinicektir!", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                VeriTabani.GruplarıSil("tbl_Hashtag", cmbHashtag.Text);
                Secimler.HashtagGrup.Remove(cmbHashtag.Text);
                ComboxAyarları();
                if (cmbHashtag.Items.Count > 0)
                {
                    cmbHashtag.SelectedIndex = 0;
                }
                else
                {
                    cmbHashtag.Text = "";
                    lstBx.Items.Clear();
                    txtHashtagGrupAdi.Clear();
                    btnGrupHashtag.Enabled = false;
                }

            }
        }

        private void cmbHashtag_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHashtagGrupAdi.Text = cmbHashtag.Text;

            txtHashtagEkle.Enabled = true;
            btnHashtagEkle.Enabled = true;
            btnGrupHashtag.Enabled = true;
            btnHastagGrupSil.Enabled = true;

            int sayac = 1;
            lstBx.Items.Clear();
            listedekiDeger.Clear();
            foreach (var item in Secimler.ListHashtags)
            {
                if (item.grupAdi == cmbHashtag.Text)
                {
                    lstBx.Items.Add(sayac.ToString() + " -> " + item.hashtag);
                    listedekiDeger.Add(new ListListedekiDeger { id = item.id, anaDeger = item.hashtag, nerenin = "tbl_Hashtag", grupAdi = item.grupAdi });
                    sayac++;
                }

            }
        }

        private void btnHashtagEkle_Click(object sender, EventArgs e)
        {
            int sayac = 1;
            string grupAdi = txtHashtagGrupAdi.Text;
            string hashtag = txtHashtagEkle.Text;

            grupAdi = grupAdi.TrimStart().TrimStart();
            hashtag = hashtag.TrimStart().TrimStart();

            switch (btnHashtagEkle.Text)
            {
                case "Hashtag Ekle":
                    {
                        if (hashtag.Length > 0 && grupAdi.Length > 0)
                        {
                            VeriTabani.KullaniciHashtagYorumEkle("tbl_Hashtag", grupAdi, hashtag);
                            txtHashtagEkle.Clear();
                            txtHashtagEkle.Focus();
                            lstBx.Items.Clear();
                            listedekiDeger.Clear();
                            foreach (var item in Secimler.ListHashtags)
                            {
                                if (item.grupAdi == grupAdi)
                                {
                                    lstBx.Items.Add(sayac + " -> " + item.hashtag);
                                    listedekiDeger.Add(new ListListedekiDeger { id = item.id, anaDeger = item.hashtag, nerenin = "tbl_Hashtag", grupAdi = item.grupAdi }); // ListBoxdan değer silmek yada düzenlemekte kontrol amaçlı kulanıyoruz
                                    sayac++;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Hashtag giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    }

                case "Grubu kaydet":
                    {
                        if (!Secimler.HashtagGrup.Contains(grupAdi))
                        {
                            if (hashtag.Length > 0 && grupAdi.Length > 0)
                            {
                                VeriTabani.KullaniciHashtagYorumEkle("tbl_Hashtag", grupAdi, hashtag);

                                ComboxAyarları();
                                cmbHashtag.SelectedIndex = cmbHashtag.Items.Count - 1; // Eklediğimiz herzaman en sonuncusu olduğundan list box da onu yorumları olsun diye

                                txtHashtagEkle.Clear();
                                txtHashtagEkle.Focus();

                                btnHashtagEkle.Text = "Hashtag Ekle";
                                btnHashtagGrupEkle.Text = "Grup Ekle";
                                btnHastagGrupSil.Enabled = true;
                                cmbHashtag.Enabled = true;
                                btnGrupHashtag.Enabled = true;

                                txtHashtagGrupAdi.Enabled = false;
                            }
                            else
                                MessageBox.Show("Grup adi ve hashtag giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show(grupAdi + " adlı grup bulunmaktadır! Farklı bir ad belirleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    }

                case "Grup Adını düzelt":
                    {
                        VeriTabani.GrupAdlariniGuncelle("tbl_Hashtag", cmbHashtag.Text, grupAdi);

                        for (int i = 0; i < Secimler.HashtagGrup.Count; i++) // değişen grubum adını Secimler.YorumGrubu deki değerini eğiştirdik
                        {
                            if (Secimler.HashtagGrup[i] == cmbHashtag.Text)
                            {
                                Secimler.HashtagGrup[i] = grupAdi;
                            }
                        }

                        cmbHashtag.Text = grupAdi;
                        ComboxAyarları();

                        btnHashtagEkle.Text = "Hashtag Ekle";
                        btnGrupHashtag.Text = "Adı Düzenle";
                        txtHashtagGrupAdi.Text = cmbHashtag.Text;

                        cmbHashtag.Enabled = true;
                        btnHashtagGrupEkle.Enabled = true;
                        btnHastagGrupSil.Enabled = true;
                        txtHashtagEkle.Enabled = true;

                        txtHashtagGrupAdi.Enabled = false;

                        break;
                    }

                case "Hashtag Düzelt":
                    {
                        string yeniHashtag = txtHashtagEkle.Text.TrimStart().TrimEnd();

                        btnHashtagEkle.Text = "Hashtag Ekle";

                        VeriTabani.YorumHashtagKullaniciGuncelle(listedekiDeger[lstBx.SelectedIndex].nerenin, listedekiDeger[lstBx.SelectedIndex].id, yeniHashtag);

                        for (int i = 0; i < Secimler.ListHashtags.Count; i++)
                        {
                            if (Secimler.ListHashtags[i].id == listedekiDeger[lstBx.SelectedIndex].id)
                            {
                                Secimler.ListHashtags[i].hashtag = yeniHashtag;
                            }
                        }

                        lstBx.Items.Clear();
                        listedekiDeger.Clear();
                        foreach (var item in Secimler.ListHashtags)
                        {
                            if (item.grupAdi == grupAdi)
                            {
                                lstBx.Items.Add(sayac + " -> " + item.hashtag);
                                listedekiDeger.Add(new ListListedekiDeger { id = item.id, anaDeger = item.hashtag, nerenin = "tbl_Hashtag", grupAdi = item.grupAdi }); // ListBoxdan değer silmek yada düzenlemekte kontrol amaçlı kulanıyoruz
                                sayac++;
                            }
                        }

                        YorumDuzeltmeSonrasi();

                        break;
                    }
            }
        }

        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Hashtag
        private void cmbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKullaniciGrupAdi.Text = cmbKullanici.Text;

            txtKullaniciAdi.Enabled = true;
            btnKullaniciEkle.Enabled = true;
            btnKullaniciGrupAdi.Enabled = true;
            btnKullaniciGrupSil.Enabled = true;

            int sayac = 1;
            lstBx.Items.Clear();
            listedekiDeger.Clear();
            foreach (var item in Secimler.ListKullaniciAdi)
            {
                if (item.grupAdi == cmbKullanici.Text)
                {
                    lstBx.Items.Add(sayac.ToString() + " -> " + item.kullaniciAdi);
                    listedekiDeger.Add(new ListListedekiDeger { id = item.id, anaDeger = item.kullaniciAdi, nerenin = "tbl_KullaniciAdi", grupAdi = item.grupAdi });
                    sayac++;
                }

            }
        }

        private void btnKullaniciGrupEkle_Click(object sender, EventArgs e)
        {
            if (btnKullaniciGrupEkle.Text == "Grup Ekle")
            {
                txtKullaniciGrupAdi.Enabled = true;
                txtKullaniciAdi.Enabled = true;
                btnKullaniciEkle.Enabled = true;

                btnKullaniciGrupAdi.Enabled = false;
                btnKullaniciGrupSil.Enabled = false;
                cmbKullanici.Enabled = false;

                txtKullaniciGrupAdi.Clear();
                txtKullaniciGrupAdi.Focus();

                btnKullaniciGrupEkle.Text = "İptal";
                btnKullaniciEkle.Text = "Grubu kaydet";
            }
            else
            {
                btnKullaniciEkle.Text = "Kullanıcı Adı Ekle";
                btnKullaniciGrupEkle.Text = "Grup Ekle";
                btnKullaniciGrupAdi.Enabled = true;
                btnKullaniciGrupSil.Enabled = true;
                cmbKullanici.Enabled = true;

                txtKullaniciGrupAdi.Enabled = false;
                txtKullaniciGrupAdi.Text = cmbKullanici.Text;

            }
        }

        private void btnKullaniciGrupDuzenle_Click(object sender, EventArgs e)
        {
            if (btnKullaniciGrupAdi.Text == "Adı Düzenle")
            {
                btnKullaniciGrupAdi.Text = "İptal";
                btnKullaniciEkle.Text = "Grup Adını düzelt";

                cmbKullanici.Enabled = false;
                btnKullaniciGrupEkle.Enabled = false;
                btnKullaniciGrupSil.Enabled = false;
                txtKullaniciAdi.Enabled = false;

                txtKullaniciGrupAdi.Enabled = true;
            }
            else
            {
                btnKullaniciGrupAdi.Text = "Adı Düzenle";
                btnKullaniciEkle.Text = "Kullanıcı Adı Ekle";
                txtKullaniciGrupAdi.Text = cmbKullanici.Text;

                cmbKullanici.Enabled = true;
                btnKullaniciGrupAdi.Enabled = true;
                btnKullaniciGrupSil.Enabled = true;
                txtKullaniciAdi.Enabled = true;

                txtKullaniciGrupAdi.Enabled = false;

            }
        }

        private void btnKullaniciGrupSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("'" + cmbKullanici.Text + "' grubu silinicektir!", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                VeriTabani.GruplarıSil("tbl_KullaniciAdi", cmbKullanici.Text);
                Secimler.KullaniciAdiGrup.Remove(cmbKullanici.Text);
                
                ComboxAyarları();
                if (cmbKullanici.Items.Count > 0)
                {
                    cmbKullanici.SelectedIndex = 0;
                }
                else
                {
                    lstBx.Items.Clear();
                    cmbKullanici.Text = "";
                    txtKullaniciGrupAdi.Clear();
                    btnKullaniciGrupAdi.Enabled = false;
                }

            }
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            int sayac = 1;
            string grupAdi = txtKullaniciGrupAdi.Text;
            string kullaniciAdi = txtKullaniciAdi.Text;

            grupAdi = grupAdi.TrimStart().TrimStart();
            kullaniciAdi = kullaniciAdi.TrimStart().TrimStart();

            switch (btnKullaniciEkle.Text)
            {
                case "Kullanıcı Adı Ekle":
                    {
                        if (kullaniciAdi.Length > 0 && grupAdi.Length > 0)
                        {
                            VeriTabani.KullaniciHashtagYorumEkle("tbl_KullaniciAdi", grupAdi, kullaniciAdi);
                            txtKullaniciAdi.Clear();
                            txtKullaniciAdi.Focus();
                            lstBx.Items.Clear();
                            listedekiDeger.Clear();
                            foreach (var item in Secimler.ListKullaniciAdi)
                            {
                                if (item.grupAdi == grupAdi)
                                {
                                    lstBx.Items.Add(sayac + " -> " + item.kullaniciAdi);
                                    listedekiDeger.Add(new ListListedekiDeger { id = item.id, anaDeger = item.kullaniciAdi, nerenin = "tbl_KullaniciAdi", grupAdi = item.grupAdi }); // ListBoxdan değer silmek yada düzenlemekte kontrol amaçlı kulanıyoruz
                                    sayac++;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Kullanıcı Adı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    }

                case "Grubu kaydet":
                    {
                        if (!Secimler.KullaniciAdiGrup.Contains(grupAdi))
                        {
                            if (kullaniciAdi.Length > 0 && grupAdi.Length > 0)
                            {
                                VeriTabani.KullaniciHashtagYorumEkle("tbl_KullaniciAdi", grupAdi, kullaniciAdi);

                                ComboxAyarları();
                                cmbKullanici.SelectedIndex = cmbKullanici.Items.Count - 1; // Eklediğimiz herzaman en sonuncusu olduğundan list box da onu yorumları olsun diye

                                txtKullaniciAdi.Clear();
                                txtKullaniciAdi.Focus();

                                btnKullaniciEkle.Text = "Kullanıcı Adı Ekle";
                                btnKullaniciGrupEkle.Text = "Grup Ekle";
                                btnKullaniciGrupSil.Enabled = true;
                                btnKullaniciGrupAdi.Enabled = true;
                                cmbKullanici.Enabled = true;

                                txtKullaniciGrupAdi.Enabled = false;
                            }
                            else
                                MessageBox.Show("Grup adi ve kullanıcı adı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show(grupAdi + " adlı grup bulunmaktadır! Farklı bir ad belirleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    }

                case "Grup Adını düzelt":
                    {
                        VeriTabani.GrupAdlariniGuncelle("tbl_KullaniciAdi", cmbKullanici.Text, grupAdi);

                        for (int i = 0; i < Secimler.KullaniciAdiGrup.Count; i++) // değişen grubum adını Secimler.YorumGrubu deki değerini eğiştirdik
                        {
                            if (Secimler.KullaniciAdiGrup[i] == cmbKullanici.Text)
                            {
                                Secimler.KullaniciAdiGrup[i] = grupAdi;
                            }
                        }

                        cmbKullanici.Text = grupAdi;
                        ComboxAyarları();

                        btnKullaniciEkle.Text = "Kullanıcı Adı Ekle";
                        btnKullaniciGrupAdi.Text = "Adı Düzenle";
                        txtKullaniciGrupAdi.Text = cmbKullanici.Text;

                        btnKullaniciGrupEkle.Enabled = true;
                        cmbKullanici.Enabled = true;
                        btnKullaniciGrupAdi.Enabled = true;
                        btnKullaniciGrupSil.Enabled = true;
                        txtKullaniciAdi.Enabled = true;

                        txtKullaniciGrupAdi.Enabled = false;

                        break;
                    }

                case "Kullanıcı Adı Düzelt":
                    {
                        string yeniKullanici = txtKullaniciAdi.Text.TrimStart().TrimEnd();

                        btnHashtagEkle.Text = "Hashtag Ekle";

                        VeriTabani.YorumHashtagKullaniciGuncelle(listedekiDeger[lstBx.SelectedIndex].nerenin, listedekiDeger[lstBx.SelectedIndex].id, yeniKullanici);

                        for (int i = 0; i < Secimler.ListKullaniciAdi.Count; i++)
                        {
                            if (Secimler.ListKullaniciAdi[i].id == listedekiDeger[lstBx.SelectedIndex].id)
                            {
                                Secimler.ListKullaniciAdi[i].kullaniciAdi = yeniKullanici;
                            }
                        }

                        lstBx.Items.Clear();
                        listedekiDeger.Clear();
                        foreach (var item in Secimler.ListKullaniciAdi)
                        {
                            if (item.grupAdi == grupAdi)
                            {
                                lstBx.Items.Add(sayac + " -> " + item.kullaniciAdi);
                                listedekiDeger.Add(new ListListedekiDeger { id = item.id, anaDeger = item.kullaniciAdi, nerenin = "tbl_KullaniciAdi", grupAdi = item.grupAdi }); // ListBoxdan değer silmek yada düzenlemekte kontrol amaçlı kulanıyoruz
                                sayac++;
                            }
                        }

                        YorumDuzeltmeSonrasi();

                        break;
                    }
            }
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Kullanıcı Adı

        private void btnSil_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("'"+listedekiDeger[lstBx.SelectedIndex].anaDeger + "' silinicektir!", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int sayac = 1;

                VeriTabani.KullaniciHashtagYorumSil(listedekiDeger[lstBx.SelectedIndex].nerenin, listedekiDeger[lstBx.SelectedIndex].id);

                switch (listedekiDeger[lstBx.SelectedIndex].nerenin)
                {
                    case "tbl_Yorumlar":
                        {
                            for (int i = 0; i < Secimler.ListYorumlar.Count; i++)
                            {
                                if (Secimler.ListYorumlar[i].id == listedekiDeger[lstBx.SelectedIndex].id)//çıkarılan değeri bulup silmek için
                                {
                                    Secimler.ListYorumlar.RemoveAt(i);// çıkarılan değeri sildik
                                }
                            }

                            break;
                        }

                    case "tbl_Hashtag":
                        {
                            for (int i = 0; i < Secimler.ListHashtags.Count; i++)
                            {
                                if (Secimler.ListHashtags[i].id == listedekiDeger[lstBx.SelectedIndex].id)//çıkarılan değeri bulup silmek için
                                {
                                    Secimler.ListHashtags.RemoveAt(i);// çıkarılan değeri sildik
                                }
                            }

                            break;
                        }

                    case "tbl_KullaniciAdi":
                        {
                            for (int i = 0; i < Secimler.ListKullaniciAdi.Count; i++)
                            {
                                if (Secimler.ListKullaniciAdi[i].id == listedekiDeger[lstBx.SelectedIndex].id) //çıkarılan değeri bulup silmek için
                                {
                                    Secimler.ListKullaniciAdi.RemoveAt(i); // çıkarılan değeri sildik
                                }
                            }

                            break;
                        }
                }

                listedekiDeger.RemoveAt(lstBx.SelectedIndex); // Burada silinen değeri lsiteden sildik
                lstBx.Items.Clear();
                foreach (var item in listedekiDeger)
                {
                    lstBx.Items.Add(sayac.ToString() + " -> " + item.anaDeger);
                    sayac++;
                }
            }
        }

        private void btnDuzenle_Click_1(object sender, EventArgs e)
        {
            if (btnDuzenle.Text == "Düzelt")
            {
                if (lstBx.SelectedItem != null)
                {
                    btnDuzenle.Text = "İptal";
                    btnDuzenle.Image = Image.FromFile(Application.StartupPath + @"\Images\cancel.png");

                    switch (listedekiDeger[lstBx.SelectedIndex].nerenin)
                    {
                        case "tbl_Yorumlar":
                            {
                                grpHashtag.Enabled = false;
                                grpKullanicilar.Enabled = false;

                                for (int i = 0; i < grpYorum.Controls.Count; i++) // grupbox ın içindeki nesnelerin aktifliğini kapattık
                                {
                                    grpYorum.Controls[i].Enabled = false;
                                }
                                //gerekli yerlerin aktifliğini açtık
                                btnYorumEkle.Text = "Yorumu Düzelt";
                                btnYorumEkle.Enabled = true;

                                txtYorum.Enabled = true;
                                txtYorum.Text = listedekiDeger[lstBx.SelectedIndex].anaDeger;
                                txtYorum.Focus();

                                break;
                            }

                        case "tbl_Hashtag":
                            {
                                grpYorum.Enabled = false;
                                grpKullanicilar.Enabled = false;

                                for (int i = 0; i < grpHashtag.Controls.Count; i++)// grupbox ın içindeki nesnelerin aktifliğini kapattık
                                {
                                    grpHashtag.Controls[i].Enabled = false;
                                }
                                //gerekli yerlerin aktifliğini açtık
                                btnHashtagEkle.Text = "Hashtag Düzelt";
                                btnHashtagEkle.Enabled = true;

                                txtHashtagEkle.Enabled = true;
                                txtHashtagEkle.Text = listedekiDeger[lstBx.SelectedIndex].anaDeger;
                                txtHashtagEkle.Focus();

                                break;
                            }

                        case "tbl_KullaniciAdi":
                            {
                                grpHashtag.Enabled = false;
                                grpYorum.Enabled = false;

                                for (int i = 0; i < grpKullanicilar.Controls.Count; i++)// grupbox ın içindeki nesnelerin aktifliğini kapattık
                                {
                                    grpKullanicilar.Controls[i].Enabled = false;
                                }
                                //gerekli yerlerin aktifliğini açtık
                                btnKullaniciEkle.Text = "Kullanıcı Adı Düzelt";
                                btnKullaniciEkle.Enabled = true;

                                txtKullaniciAdi.Enabled = true;
                                txtKullaniciAdi.Text = listedekiDeger[lstBx.SelectedIndex].anaDeger;
                                txtKullaniciAdi.Focus();

                                break;
                            }
                    }
                }
            }
            else
            {
                YorumDuzeltmeSonrasi();
            }
            
        }

        private void YorumDuzeltmeSonrasi()
        {
            btnDuzenle.Text = "Düzelt";
            txtKullaniciAdi.Text = txtHashtagEkle.Text = txtYorum.Text = "";
            btnDuzenle.Image = Image.FromFile(Application.StartupPath + @"\Images\edit.png");

            

            for (int i = 0; i < this.Controls.Count; i++) // fromdaki en üsteki nesneler içindeki nesler önce üstüne ulaşmak gerek
            {
                this.Controls[i].Enabled = true; // En üst nesneyi kullanabilri ediyor
                for (int k = 0; k < this.Controls[i].Controls.Count && this.Controls[i].Controls.Count > 0; k++) // Eğer nesnenin içinde nesne varsa giricek ve içindeki nesnelrin kullanımı aktif edicek
                {
                    if (this.Controls[i].Controls[k].Name != "txtYorumGrupAdi" && this.Controls[i].Controls[k].Name != "txtHashtagGrupAdi" && this.Controls[i].Controls[k].Name != "txtKullaniciGrupAdi") // grup adının yazıldığı textboxların kulanılabilirliği kapalı olmalı o yüzden onları aktif etmiyoruz
                    {
                        this.Controls[i].Controls[k].Enabled = true;
                    }
                }
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ formdaki bağzı nesneler hariç geriye kalanların aktifliğini açma
            if (txtYorumGrupAdi.Text.Length==0)
            {
                btnGrupYorumDuzenle.Enabled = false;
            }

            if (txtHashtagGrupAdi.Text.Length == 0)
            {
                btnGrupHashtag.Enabled = false;
            }

            if (txtKullaniciGrupAdi.Text.Length == 0)
            {
                btnKullaniciGrupAdi.Enabled = false;
            }

            lstBx.SelectedIndex = -1; // Birşey seçilise listeden o seçimi kapatır

            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Grup adlarını düzeltme butonun aktifliği yanıntaki txtbox dolu ise 
        } // Yorum Düzeltme ve iptali sonrası gerekli ayarlar

        private void lstBx_SelectedIndexChanged(object sender, EventArgs e) // Eğer listboxta birşey seçili ise düzenltme ve silme tuşu açık olucak
        {
            if (lstBx.SelectedIndex != -1)
            {
                btnDuzenle.Enabled = true;
                btnSil.Enabled = true;

            }
            else
            {
                btnDuzenle.Enabled = false;
                btnSil.Enabled = false;
            }

        }

    }
}

class ListListedekiDeger // Listbox a eklenen değerleri düzenlemek için oluşturduğum bir class
{
    public string id { get; set; }
    public string anaDeger { get; set; }
    public string nerenin { get; set; }
    public string grupAdi { get; set; }
}