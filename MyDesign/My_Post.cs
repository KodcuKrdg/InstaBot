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
    public partial class My_Post : UserControl
    {
        public My_Post()
        {
            InitializeComponent();
        }

        public Image My_Image { 
            get{ return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public String My_Aciklama {
            get { return rchTextAciklama.Text; }
            set { rchTextAciklama.Text = value; }
        }

    }
}
