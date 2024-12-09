using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.InterfaceSegregationPrinciple.IspWrongApp
{
    public class RobotWorker : Iworker
    {
        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Sleep()
        {
            throw new NotImplementedException();
        }

        public void Work()
        {
            Console.WriteLine("Robot Çalıştı");
        }
    }
}
