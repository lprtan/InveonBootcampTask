using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpCorrectApp
{
    public class Mediator : IMediator
    {
        private readonly EmployeeServiceFixed _employeeService;
        private readonly EmailService _emailService;

        public Mediator(EmployeeServiceFixed employeeService, EmailService emailService)
        {
            _employeeService = employeeService;
            _employeeService.SetMediator(this); // Bağlantıyı kuruyoruz

            _emailService = emailService;
        }
        public void Notify(string action, EmployeeServiceFixed employee)
        {
            if (action == "EmployeeSaved")
            {
                _emailService.SendEmail(employee);
            }
        }
    }
}
