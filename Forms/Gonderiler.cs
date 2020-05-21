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
    public partial class Gonderiler : Form
    {
        public Gonderiler()
        {
            InitializeComponent();
        }

        int bosluk;
        private void Hizalama() 
        {
            int pnlWidth = flowLayoutPanel1.Width; 

            My_Post post = new My_Post();

            int postWidth = post.Width;

            bosluk = pnlWidth% postWidth/4;
        }

        private void Gonderiler_Load(object sender, EventArgs e)
        {
            Hizalama();
            PostlariHizala();
        }

        private void PostlariHizala() 
        {
            int solBoşluk= Convert.ToInt32(bosluk);
            int ustBosluk=5;
            for (int i = 0; i < 50; i++)
            {
                My_Post post = new My_Post();
                flowLayoutPanel1.Controls.Add(post);
            }
            
        }
    }
}
