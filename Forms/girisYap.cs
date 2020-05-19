using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp6;

namespace InstaBot.Forms
{
    public partial class girisYap : Form
    {
        public girisYap()
        {
            InitializeComponent();
        }

        instagram test = new instagram();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            test.gonderiCek("hdwallpaper");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test.HesabaGirisYapPc(textBox1.Text, textBox2.Text);
        }
    }
}
