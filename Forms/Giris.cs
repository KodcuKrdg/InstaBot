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

        private void btnGiris_Click(object sender, EventArgs e)
        {
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
    }
}
