using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.DependencyInversionPrinciple.DipCorrectApp
{
    public class EmployeeDetailsFixed
    {
        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }

        private readonly ISalaryCalculate _salaryCalculate;

        public EmployeeDetailsFixed(ISalaryCalculate salaryCalculate)
        {
            this._salaryCalculate = salaryCalculate;
        }

        public int GetSalary()
        {
            return _salaryCalculate.SalaryCalculate(HoursWorked, HourlyRate);
        }

    }
}
