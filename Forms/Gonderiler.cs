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
using System.Threading;

namespace InstaBot.Forms
{
    public partial class Gonderiler : Form
    {
        public Gonderiler()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Gonderiler_Load(object sender, EventArgs e)
        {
            PostlariHizala();
        }

        private void PostlariHizala() 
        {
            for (int i = 0; i < 50; i++)
            {
                My_Post post = new My_Post();
                flowLayoutPanel1.Controls.Add(post);
            }
            
        }
    }
}
