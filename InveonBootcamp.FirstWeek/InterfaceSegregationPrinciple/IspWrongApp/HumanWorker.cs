using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.InterfaceSegregationPrinciple.IspWrongApp
{
    public class HumanWorker : Iworker
    {
        public void Eat()
        {
            Console.WriteLine("Yemek yenildi.");
        }

        public void Sleep()
        {
            Console.WriteLine("Uyunuldu");
        }

        public void Work()
        {
            Console.WriteLine("İnsan çalıştı");
        }
    }
}
