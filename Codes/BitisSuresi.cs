using InstaBot.MyDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.Codes
{
    class BitisSuresi
    {
        private BitisSuresi() { }
        private static BitisSuresi _instance;
        public List<My_FinishTime> my_FinishTimes = new List<My_FinishTime>();

        public static BitisSuresi GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BitisSuresi();
            }
            return _instance;
        }
        public void Ekle(string islemAdi, string kalanSaatText, string kalanDakkaText, int adimMaxDeger) 
        {
            My_FinishTime bitis = new My_FinishTime();
            bitis.IslemAdi = islemAdi;
            bitis.KalanSaatText = kalanSaatText;
            bitis.KalanDakkaText = kalanDakkaText;
            bitis.AdimMaxDegerText = adimMaxDeger.ToString();
            bitis.AdimText = "0";
            bitis.BarMax = adimMaxDeger;
            bitis.BarDeger = 0;
            my_FinishTimes.Add(bitis);
        }
    }
}
