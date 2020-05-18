using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaBot
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void pcCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool mouseDown; //Formu sürüklemek için
        private Point lastLocation; //Formu sürüklemek için
        private void pnlUst_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true; //Formu sürüklemek için
            lastLocation = e.Location; //Formu sürüklemek için
        }

        private void pnlUst_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) //Formu sürüklemek için
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void pnlUst_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false; //Formu sürüklemek için
        }

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlSag.Controls.Add(childForm);
            pnlSag.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pnl_GirisYap_Click(object sender, EventArgs e)
        {
            pcGiris.Image = Image.FromFile(@"D:\Kodlar\C#\InstaBot\bin\Debug\Images\login1.png");
        }
        private void pnl_Begen_Click(object sender, EventArgs e)
        {
            pcBegen.Image = Image.FromFile(@"D:\Kodlar\C#\InstaBot\bin\Debug\Images\like1.png");
        }


    }
}
