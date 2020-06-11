using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.BaseClass
{
    class TakipEt
    {
        public bool takipEdicekMi { get; set; }
        public bool yorumlardanTkpEt { get; set; }
        public bool begenilerdenTkpEt { get; set; }
        public bool takipEttiklerindenTkpEt { get; set; }
        public bool takipcilerdenTkpEt { get; set; }
        public bool acikHesaplariTkpEt { get; set; }
        public int takipEtmeSayisi { get; set; }
        public int minSure { get; set; }
        public int maxSure { get; set; }
        public string takipEdilenSayi { get; set; }
    }
}
