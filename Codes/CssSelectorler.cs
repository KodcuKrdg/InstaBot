using InstaBot.CssSelector;
using InstaBot.CssSelector.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.Codes
{
    class CssSelectorler
    {
        private CssSelectorler() { }

        private static CssSelectorler _instance;

        public static CssSelectorler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CssSelectorler();
                CssDatabase cssDatabase = new CssDatabase(); //Selectorleri Veritabanından çektik
            }
            return _instance;
        }

        public CssGirisEkrani GirisEkrani = new CssGirisEkrani();

        public CssAnaSayfaBegen AnaSayfaBegen = new CssAnaSayfaBegen();

        public CssTakiptenCikma TakiptenCikma = new CssTakiptenCikma();

        public CssYorumyapBegen YorumyapBegen = new CssYorumyapBegen();

        public CssTakipEt TakipEt = new CssTakipEt();

    }
}
