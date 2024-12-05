
using InveonBootcamp.FirstWeek.InterfaceSegregationPrinciple.IspCorrectApp;
using InveonBootcamp.FirstWeek.InterfaceSegregationPrinciple.IspWrongApp;
using InveonBootcamp.FirstWeek.LiskovSubstitutionPrinciple.LspCorrectApp;
using InveonBootcamp.FirstWeek.LiskovSubstitutionPrinciple.LspWrongApp;
using InveonBootcamp.FirstWeek.OpenClosedPrinciple.OcpCorrectApp;
using InveonBootcamp.FirstWeek.OpenClosedPrinciple.OcpWrongApp;
using InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpCorrectApp;
using InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpWrongApp;

#region Yanlış kod uygulaması (SRP)
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

#region Yanlış kod uygulması (OCP)
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

#region Yanlış kod uygulması (LSP)
AccessDataFile adminFile = new AdminUserFile();
adminFile.FilePath = @"c:\temp\a.txt";
adminFile.ReadFile();
adminFile.WriteFile();

AccessDataFile regularFile = new RegularFileUser();
regularFile.FilePath = @"c:\temp\a.txt";
regularFile.ReadFile();
//accessDataFileR.WriteFile();  // Throws exception
#endregion

#region LSP ile düzeltilmiş kod uygulaması
IFileReader adminFileReader = new AdminFileUserFixed();
adminFileReader.ReadFile(@"c:\temp\a.txt");

IFileWriter adminFileWriter = new AdminFileUserFixed();
adminFileWriter.FileWrite(@"c:\temp\a.txt");

IFileReader regularFileReader = new RegularFileUserFixed();
regularFileReader.ReadFile(@"c:\temp\a.txt");
#endregion

#region Yanlış kod uygulması (ISP)
Iworker humanWorker = new HumanWorker();
humanWorker.Eat();
humanWorker.Sleep();
humanWorker.Work();

Iworker robotWorker = new RobotWorker();
//robotWorker.Eat(); //Throws exception
//robotWorker.Sleep(); //Throws exception
robotWorker.Work();
#endregion

#region ISP ile düzeltilmiş kod uygulması
HumanWorkerFixed humanWorkerFixed = new HumanWorkerFixed();
humanWorkerFixed.Eat();
humanWorkerFixed.Sleep();
humanWorkerFixed.Work();

RobotWorkerFixed robotWorkerFixed = new RobotWorkerFixed();
robotWorkerFixed.Work();
#endregion

Console.ReadKey();