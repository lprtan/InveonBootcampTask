using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpCorrectApp
{
    public class EmailService
    {
        public void SendEmail(EmployeeServiceFixed employee)
        {
            Console.WriteLine($"{employee.Email} mail gönderildi");
        }
    }
}
