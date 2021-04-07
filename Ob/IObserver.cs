using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.Ob
{
    public interface IObserver
    {
        // İşlenen veriyi karşıya iletir
        void VeriyiAl(ISubject subject);
    }
}
