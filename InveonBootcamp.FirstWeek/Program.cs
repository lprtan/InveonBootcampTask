
using InveonBootcamp.FirstWeek.OpenClosedPrinciple.OcpCorrectApp;
using InveonBootcamp.FirstWeek.OpenClosedPrinciple.OcpWrongApp;
using InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpCorrectApp;
using InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpWrongApp;

#region Yanlış kod uygulaması
EmployeeService employeeService = new EmployeeService
{
    FirstName = "Ali",
    LastName = "Veli",
    Email = "aliveli@gmail.com"
};
employeeService.EmployeeRegistration(employeeService);
#endregion

#region SRP ile düzeltlmiş kod uygulması
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

#region Yanlış kod uygulması
Console.WriteLine(Account.CalculateInterest(AccountType.Salary, 1000));
#endregion

#region OCP ile düzeltilmiş kod uygulaması
IAccount regularAccount = new RegularAccount();
IAccount salaryAccount = new SalaryAccount();
IAccount childSavingAccount = new ChildSavingsAccount();

Console.WriteLine($"Regular Account: {regularAccount.CalculateInterest(1000).ToString()}");
Console.WriteLine($"Salary Account: {salaryAccount.CalculateInterest(1000).ToString()}");
Console.WriteLine($"Child Saving Account: {childSavingAccount.CalculateInterest(1000).ToString()}");
#endregion


Console.ReadKey();