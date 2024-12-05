using InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpWrongApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpCorrectApp
{
    public class EmployeeServiceFixed
    {
        private IMediator _mediator;

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void SaveEmployee(Employee employee)
        {
            EmployeDataFixed.Employees.Add(employee);

            Console.WriteLine($"Çalışan kaydedildi: {employee.FirstName} {employee.LastName}");
            _mediator?.Notify("EmployeeSaved", employee);
        }
    }
}
