using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.DependencyInversionPrinciple.DipCorrectApp
{
    public class SalaryCalculateFixed : ISalaryCalculate
    {
        public int SalaryCalculate(int hoursWorked, int hoursRate)
        {
            return hoursWorked * hoursRate;
        }
    }
}
