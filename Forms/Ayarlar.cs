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

            if (btnYorumEkle.Text == "Yorum Ekle")
            {
                if (yorum.Length > 0 && grupAdi.Length > 0)
                {
                    VeriTabani.KullaniciHashtagYorumEkle("tbl_Yorumlar", grupAdi, yorum);
                    txtYorum.Clear();
                    txtYorum.Focus();
                    lstBx.Items.Clear();
                    foreach (var item in Secimler.ListYorumlar)
                    {
                        if (item.grupAdi == grupAdi)
                        {
                            lstBx.Items.Add(sayac+" -> "+item.yorum);
                            sayac++;
                        }
                    }
                }
                else
                    MessageBox.Show("Yorum giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(btnYorumEkle.Text == "Grubu kaydet") // Yeni Grup Ekleme
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
                
            }
            else if(btnYorumEkle.Text == "Grup Adını düzelt")
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

                btnGrupYorumDuzenle.Text = "Adı Düzenle";
                txtYorumGrupAdi.Text = cmbYorum.Text;

                cmbYorum.Enabled = true;
                btnGrupYorumEkle.Enabled = true;
                btnGrupYorumSil.Enabled = true;
                txtYorum.Enabled = true;

                txtYorumGrupAdi.Enabled = false;
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
                if (cmbYorum.Items.Count>0)
                {
                    cmbYorum.SelectedIndex = 0;
                }
                
            }
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Yorum
        private void btnHashtagGrupEkle_Click(object sender, EventArgs e)
        {
            if (btnHashtagGrupEkle.Text == "Grup Ekle")
            {
                txtHashtagGrupAdi.Enabled = true;
                btnHashtagAdiDuznele.Enabled = false;
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
                btnHashtagAdiDuznele.Enabled = true;
                btnHastagGrupSil.Enabled = true;
                cmbHashtag.Enabled = true;

                txtHashtagGrupAdi.Enabled = false;
                txtYorumGrupAdi.Text = cmbHashtag.Text;

            }
        }

        private void btnHashtagAdiDuznele_Click(object sender, EventArgs e)
        {
            if (btnHashtagAdiDuznele.Text == "Adı Düzenle")
            {
                btnHashtagAdiDuznele.Text = "İptal";
                btnHashtagEkle.Text = "Grup Adını düzelt";

                cmbHashtag.Enabled = false;
                btnHashtagGrupEkle.Enabled = false;
                btnHastagGrupSil.Enabled = false;
                txtHashtagEkle.Enabled = false;

                txtHashtagGrupAdi.Enabled = true;
            }
            else
            {
                btnHashtagAdiDuznele.Text = "Adı Düzenle";
                btnHashtagEkle.Text = "Hashtag Ekle";
                txtHashtagGrupAdi.Text = cmbHashtag.Text;

                cmbHashtag.Enabled = true;
                btnHashtagAdiDuznele.Enabled = true;
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

            }
        }

        private void cmbHashtag_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHashtagGrupAdi.Text = cmbHashtag.Text;
            btnHashtagAdiDuznele.Enabled = true;
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

            if (btnHashtagEkle.Text == "Hashtag Ekle")
            {
                if (hashtag.Length > 0 && grupAdi.Length > 0)
                {
                    VeriTabani.KullaniciHashtagYorumEkle("tbl_Hashtag", grupAdi, hashtag);
                    txtHashtagEkle.Clear();
                    txtHashtagEkle.Focus();
                    lstBx.Items.Clear();
                    foreach (var item in Secimler.ListHashtags)
                    {
                        if (item.grupAdi == grupAdi)
                        {
                            lstBx.Items.Add(sayac + " -> " + item.hashtag);
                            sayac++;
                        }
                    }
                }
                else
                    MessageBox.Show("Hashtag giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (btnHashtagEkle.Text == "Grubu kaydet") // Yeni Grup Ekleme
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
                        btnHashtagAdiDuznele.Enabled = true;

                        txtHashtagGrupAdi.Enabled = false;
                    }
                    else
                        MessageBox.Show("Grup adi ve hashtag giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(grupAdi + " adlı grup bulunmaktadır! Farklı bir ad belirleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (btnHashtagEkle.Text == "Grup Adını düzelt")
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

                btnHashtagGrupEkle.Text = "Adı Düzenle";
                txtHashtagGrupAdi.Text = cmbYorum.Text;

                cmbHashtag.Enabled = true;
                btnHashtagGrupEkle.Enabled = true;
                btnHastagGrupSil.Enabled = true;
                txtHashtagEkle.Enabled = true;

                txtHashtagGrupAdi.Enabled = false;
            }
        }

        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Hashtag
        private void cmbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKullaniciGrupAdi.Text = cmbKullanici.Text;
            btnKullaniciGrupAdi.Enabled = true;
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

            }
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            int sayac = 1;
            string grupAdi = txtKullaniciGrupAdi.Text;
            string kullaniciAdi = txtKullaniciAdi.Text;

            grupAdi = grupAdi.TrimStart().TrimStart();
            kullaniciAdi = kullaniciAdi.TrimStart().TrimStart();

            if (btnKullaniciEkle.Text == "Kullanıcı Adı Ekle")
            {
                if (kullaniciAdi.Length > 0 && grupAdi.Length > 0)
                {
                    VeriTabani.KullaniciHashtagYorumEkle("tbl_KullaniciAdi", grupAdi, kullaniciAdi);
                    txtKullaniciAdi.Clear();
                    txtKullaniciAdi.Focus();
                    lstBx.Items.Clear();
                    foreach (var item in Secimler.ListKullaniciAdi)
                    {
                        if (item.grupAdi == grupAdi)
                        {
                            lstBx.Items.Add(sayac + " -> " + item.kullaniciAdi);
                            sayac++;
                        }
                    }
                }
                else
                    MessageBox.Show("Kullanıcı Adı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (btnKullaniciEkle.Text == "Grubu kaydet") // Yeni Grup Ekleme
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

            }
            else if (btnKullaniciEkle.Text == "Grup Adını düzelt")
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

                btnKullaniciGrupAdi.Text = "Adı Düzenle";
                txtKullaniciGrupAdi.Text = cmbKullanici.Text;

                btnKullaniciGrupEkle.Enabled = true;
                cmbKullanici.Enabled = true;
                btnKullaniciGrupAdi.Enabled = true;
                btnKullaniciGrupSil.Enabled = true;
                txtKullaniciAdi.Enabled = true;

                txtKullaniciGrupAdi.Enabled = false;
            }
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Kullanıcı Adı

        private void btnSil_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("'"+listedekiDeger[lstBx.SelectedIndex].anaDeger + "' silinicektir!", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int sayac = 1;

                VeriTabani.KullaniciHashtagYorumSil(listedekiDeger[lstBx.SelectedIndex].nerenin, listedekiDeger[lstBx.SelectedIndex].id);

                if (listedekiDeger[lstBx.SelectedIndex].nerenin == "tbl_Yorumlar")
                {
                    for (int i = 0; i < Secimler.ListYorumlar.Count; i++)
                    {
                        if (Secimler.ListYorumlar[i].id == listedekiDeger[lstBx.SelectedIndex].id)
                        {
                            Secimler.ListYorumlar.RemoveAt(i);
                        }
                    }

                }
                else if (listedekiDeger[lstBx.SelectedIndex].nerenin == "tbl_Hashtag")
                {
                    for (int i = 0; i < Secimler.ListHashtags.Count; i++)
                    {
                        if (Secimler.ListHashtags[i].id == listedekiDeger[lstBx.SelectedIndex].id)
                        {
                            Secimler.ListHashtags.RemoveAt(i);
                        }
                    }
                }
                else if (listedekiDeger[lstBx.SelectedIndex].nerenin == "tbl_KullaniciAdi")
                {
                    for (int i = 0; i < Secimler.ListKullaniciAdi.Count; i++)
                    {
                        if (Secimler.ListKullaniciAdi[i].id == listedekiDeger[lstBx.SelectedIndex].id) //çıkarılan değeri sbulup silmek için
                        {
                            Secimler.ListKullaniciAdi.RemoveAt(i); // çıkarılan değeri sildik
                        }
                    }
                }
                listedekiDeger.RemoveAt(lstBx.SelectedIndex); // Burada silinen değeri lsiteden sildik
                lstBx.Items.Clear();
                foreach (var item in listedekiDeger)
                {
                    lstBx.Items.Add(sayac.ToString() + " - > " + item.anaDeger);
                    sayac++;
                }
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