using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.Ob
{
    public interface ISubject
    {

        // İşlenen veriyi alacak gönderilecek sınıf 
        void VeriyiAlacak(IObserver observer);

        // İşlenen veriyi almaktan vazgeçen sınıf
        void VeriyiBirakacak(IObserver observer);

        // Verinin İşlendiğini Alınmaya uygun olduğunu bildirir
        void VeriHazir();
    }
}
