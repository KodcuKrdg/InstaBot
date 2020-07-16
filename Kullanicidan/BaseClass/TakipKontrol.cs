using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaBot.BaseClass
{
    class TakipKontrol
    {
        public bool takipKontrolEdilsinMi { get; set; }
        public bool acikHesap { get; set; }
        public bool gizliHesap { get; set; }
        public bool gonderiBegen { get; set; }
        public string kontrolSayisi { get; set; }
        public int begenilecekSayi { get; set; }

    }
}
