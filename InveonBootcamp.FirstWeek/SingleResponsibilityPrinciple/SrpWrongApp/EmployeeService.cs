using InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpCorrectApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpWrongApp
{
    public class EmployeeService
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void EmployeeRegistration(EmployeeService employee)
        {
            EmployeeData.Employees.Add(employee);
            Console.WriteLine($"{FirstName} {LastName} adlı kullanıcı eklendi");
            SendEmail();
        }
        private void SendEmail()
        {
            Console.WriteLine($"{Email} mail gönderildi");
        }
    }
}
