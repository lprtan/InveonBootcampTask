using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.InterfaceSegregationPrinciple.IspCorrectApp
{
    public class RobotWorkerFixed : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Robot Çalıştı");
        }
    }
}
