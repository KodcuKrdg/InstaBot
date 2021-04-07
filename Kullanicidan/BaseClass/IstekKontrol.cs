using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaBot.BaseClass
{
    class IstekKontrol
    {
        public bool takipKontrolEdilsinMi { get; set; }
        public bool acikHesap { get; set; }
        public bool gizliHesap { get; set; }
        public bool gonderiBegen { get; set; }
        public int IstekSayisi { get; set; }
        public int kontrolSayisi { get; set; }
        public int begenilecekSayi { get; set; }

    }
}
