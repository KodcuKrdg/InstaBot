using InstaBot.CssSelector;
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

        public GirisEkrani GirisEkrani = new GirisEkrani();

        public AnaSayfaBegen AnaSayfaBegen = new AnaSayfaBegen();

    }
}
