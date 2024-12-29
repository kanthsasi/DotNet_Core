/*
using EFCore.Data;
using EFCore.Models.Domain;
using Microsoft.EntityFrameworkCore;

using (var context =new AppDbContext())
{
    
    //Insert manager details

    var manager = new Manager();
    manager.FirstName = "Sasi";
    manager.LastName = "S";

    context.Managers.Add(manager);
    context.SaveChanges();

    //Insert employee details

     var employee = new Employee();
     employee.FirstName = "Sahana";
     employee.LastName = "Bhat";
     employee.Salary = 10000;
     employee.ManagerId = 2;
     context.Employees.Add(employee);
     context.SaveChanges();

     //Insert Employee Details

     var empDetails = new EmployeeDetails()
     {
         Address = "Singapore",
         Email = "mukund@email.com",
         PhoneNumber = "9578556018",
         EmployeeId = 3
     };
     context.EmployeeDetails.Add(empDetails);
     context.SaveChanges();
   

    var updateproject = new Project();
    updateproject.Name = "Asp.Net Core Web API"; 
    context.Projects.Add(updateproject);
    context.SaveChanges();
    
    //Retrieve and display all the employees

    var employees = context.Employees.ToList();
    foreach (var employee in employees)
    {
        Console.WriteLine("Employee Name:" + employee.FirstName + "Salary:" + employee.Salary);
    }
   // Console.ReadLine();

    //Retrieve employee whose EmployeeId is 1

    var Employee = context.Employees.Single(s => s.EmployeeId == 4);
    Console.WriteLine("Employee Name:" + Employee.FirstName + "Salary:" + Employee.Salary);
   // Console.ReadLine();

    //Update the Data

    var updateEmployee = context.Employees.Single(s =>s.EmployeeId ==3);
    updateEmployee.FirstName = "Sumitha";
    updateEmployee.LastName = "S";
    updateEmployee.Salary = 20000;
    context.SaveChanges();
    Console.WriteLine("Employee Name:"+updateEmployee.FirstName+"Salary:"+updateEmployee.Salary);
   // Console.ReadLine();

    //Update Manager

    var updateManager1 = context.Managers.Single(s => s.ManagerId == 3);
    updateManager1.FirstName = "Manoj";
    updateManager1.LastName = "V";
    context.SaveChanges();
    Console.WriteLine("Manager Name:" + updateManager1.FirstName);

    var updateManager2 = context.Managers.Single(s => s.ManagerId == 4);
    updateManager2.FirstName = "RahulRaj";
    updateManager2.LastName = "D";
    context.SaveChanges();
    Console.WriteLine("Manager Name:" + updateManager2.FirstName);

    var updateManager3 = context.Managers.Single(s => s.ManagerId == 2);
    updateManager3.FirstName = "SasiKanth";
    updateManager3.LastName = "S";
    context.SaveChanges();
    Console.WriteLine("Manager Name:" + updateManager3.FirstName);

    var updateManager4 = context.Managers.Single(s => s.ManagerId == 6);
    updateManager4.FirstName = "Keerthivasan";
    updateManager4.LastName = "A";
    context.SaveChanges();
    Console.WriteLine("Manager Name:" + updateManager4.FirstName);
   // Console.ReadLine();

    //Delete the Data

    //var deleteManager = context.Managers.Single(s => s.ManagerId == 7);
    //if (deleteManager != null)
    //{
      //  context.Managers.Remove(deleteManager);
        //context.SaveChanges();
    //}

    //Eager loading-Include method
   // var includeEmployee = context.Employees.Include(i => i.EmployeeDetails).ToList();
    //foreach (var include in includeEmployee)
    //{
      //  Console.WriteLine("Id:"+include.EmployeeDetails.EmployeeId+"Name:"+include.FirstName+"Address:"+include.EmployeeDetails.Address);
    //}
    //Console.ReadLine();

    //Eager Loading-ThenInclude method

    var thenInclude = context.Projects.Include(e => e.EmployeeProjects).ThenInclude(e => e.Employee).ToList();
    foreach (var thenincludes in thenInclude)
    {
        Console.WriteLine("Project Name:"+thenincludes.Name);
        foreach (var emp in thenincludes.EmployeeProjects)
        {
            Console.WriteLine("Employee:"+emp.Employee.FirstName);
        }
    }

    //Loading main entity

    var loadingEmployee = context.Employees.ToList();
    foreach (var LE in loadingEmployee)
    {
        //Load Related entity
        context.Entry(LE).Reference(r => r.EmployeeDetails).Load();

        Console.WriteLine("Id:"+LE.EmployeeDetails.EmployeeId+"Name:"+LE.FirstName+"Address:"+LE.EmployeeDetails.Address);
    }
    Console.ReadLine();
    

}
*/
