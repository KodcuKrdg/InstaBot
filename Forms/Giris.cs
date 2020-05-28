using InstaBot.MyDesign;
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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

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
        int i = 0;
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            
            i += 1;
            My_FinishTime bitis = new My_FinishTime();
            bitis.IslemAdi = "Beğeni";
            bitis.KalanSaatText = i.ToString();
            bitis.KalanDakkaText = "40";
            bitis.BarMax = 100;
            bitis.BarDeger = 50;
            BitisSureleriPnl.Controls.Add(bitis);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BitisSureleriPnl.Controls.RemoveAt(0);
        }

        private void chckBegen_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBegen.Checked == true)
                pnlBegen.Enabled = true;
            else
                pnlBegen.Enabled = false;
        }

        private void chckYorumYap_CheckedChanged(object sender, EventArgs e)
        {
            if (chckYorumYap.Checked == true)
                pnlYorum.Enabled = true;
            else
                pnlYorum.Enabled = false;
        }

        private void chckTakipEt_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTakipEt.Checked == true)
                pnlTakipEt.Enabled = true;
            else
                pnlTakipEt.Enabled = false;
        }

        private void chckTakiptenCık_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTakiptenCık.Checked == true)
                pnlTakiptenCikma.Enabled = true;
            else
                pnlTakiptenCikma.Enabled = false;
        }

        private void chckIstekKontrol_CheckedChanged(object sender, EventArgs e)
        {
            if (chckIstekKontrol.Checked == true)
                pnlTakipIstegiKontrol.Enabled = true;
            else
                pnlTakipIstegiKontrol.Enabled = false;
        }

        private void chckResimAl_CheckedChanged(object sender, EventArgs e)
        {
            if (chckResimAl.Checked == true)
                pnlResimAl.Enabled = true;
            else
                pnlResimAl.Enabled = false;
        }

        private void chckResimYukle_CheckedChanged(object sender, EventArgs e)
        {
            if (chckResimYukle.Checked == true)
                pnlResimPaylas.Enabled = true;
            else
                pnlResimPaylas.Enabled = false;
        }
        private void nmrcBegeniSayisi_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
