using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.DependencyInversionPrinciple.DipWrongApp
{
    public class EmployeeDetails
    {
        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }

        public int GetSalary()
        {
            SalaryCalculate salaryCalculate = new SalaryCalculate();
            return salaryCalculate.CalculateSalary(HoursWorked, HourlyRate);
        }
    }
}
