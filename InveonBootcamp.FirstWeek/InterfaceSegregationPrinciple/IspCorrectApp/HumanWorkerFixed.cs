using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.InterfaceSegregationPrinciple.IspCorrectApp
{
    public class HumanWorkerFixed : IWorkable, IEatable, ISleepable
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
