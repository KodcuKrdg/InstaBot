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
        public bool kabulEdilmeyenler { get; set; }
        public bool takipEtmeyenleriCikar { get; set; }
        public bool gonderiBegen { get; set; }
        public int kontrolSayisi { get; set; }
        public int begenilecekSayi { get; set; }
        public string kontrolEdilenSayi { get; set; }

    }
}
