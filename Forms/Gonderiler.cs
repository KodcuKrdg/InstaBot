using InstaBot.MyDesign;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BotCodes;


namespace InstaBot.Forms
{
    public partial class Gonderiler : Form
    {
        public Gonderiler()
        {
            InitializeComponent();
        }
        Bot botCode;
        private void Gonderiler_Load(object sender, EventArgs e)
        {
            botCode = new Bot();
            PostlariHizala();
        }
        private void PostlariHizala() 
        {
            for (int i = 0; i < 50; i++)
            {
                My_Post pos = new My_Post();
                flowLayoutPanel1.Controls.Add(pos);
            }
        }
    }
}
