using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.DependencyInversionPrinciple.DipCorrectApp
{
    public interface ISalaryCalculate
    {
        int SalaryCalculate(int hoursWorked, int hoursRate);
    }
}
