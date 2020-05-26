using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaBot.MyDesign
{
    public partial class My_FinishTime : UserControl
    {
        public My_FinishTime()
        {
            InitializeComponent();
        }

        public String IslemAdi 
        {
            get { return lblIslem.Text; }
            set { lblIslem.Text = value; }
        }

        public String KalanSaatText
        {
            get { return lblSa.Text; }
            set { lblSa.Text = value; }
        }

        public String KalanDakkaText
        {
            get { return lblDk.Text; }
            set { lblDk.Text = value; }
        }

        public int BarMax
        {
            get { return prgrsBar.Maximum; }
            set { prgrsBar.Maximum = value; }
        }

        public int BarDeger
        {
            get { return prgrsBar.Value; }
            set { prgrsBar.Value = value; }
        }
        // bu event label önceki text inden farklı text alınca tetikleniyor
        private void lblSa_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(lblSa.Text) == 0) //işelem bitince görünümünü kapatıyoruz
            {
                lblSa.Visible = false;
                lblTextSa.Visible = false;
            } 
        }

        private void lblDk_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(lblDk.Text) == 0)
            {
                lblDk.Visible = false;
                lblTextDk.Visible = false;
            }
        }
    }
}
