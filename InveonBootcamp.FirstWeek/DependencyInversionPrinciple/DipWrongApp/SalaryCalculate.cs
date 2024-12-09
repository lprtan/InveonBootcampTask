using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.DependencyInversionPrinciple.DipWrongApp
{
    public class SalaryCalculate
    {
        public int CalculateSalary(int hoursWorked, int hoursRate) { return hoursRate * hoursWorked; }
    }
}
