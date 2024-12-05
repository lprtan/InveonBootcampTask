
using InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpCorrectApp;
using InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpWrongApp;

#region Yanlış SRP uygulaması
EmployeeService employeeService = new EmployeeService
{
    FirstName = "Ali",
    LastName = "Veli",
    Email = "aliveli@gmail.com"
};
employeeService.EmployeeRegistration(employeeService);
#endregion

#region Doğru SRP uygulması
var emailService = new EmailService();
var employeeService2 = new EmployeeServiceFixed();

var mediator = new Mediator(employeeService2, emailService);

var employee = new EmployeeServiceFixed
{
    FirstName = "Ali",
    LastName = "Veli",
    Email = "ali.veli@example.com"
};
employeeService2.SaveEmployee(employee);
#endregion


Console.ReadKey();