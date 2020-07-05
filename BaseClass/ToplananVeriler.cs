using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.BaseClass
{
    class ToplananVeriler
    {
        private ToplananVeriler() { }
        private static ToplananVeriler _instance;

        public static ToplananVeriler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ToplananVeriler();
            }
            return _instance;
        }

        public List<string> TakipEdilecekler = new List<string>();
    }
}
