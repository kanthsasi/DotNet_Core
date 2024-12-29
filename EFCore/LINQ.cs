using EFCore.Data;
using EFCore.Models.Domain;

using (var context = new AppDbContext())
{
    //Filtering:

    var employeessalary = context.Employees.Where(e => e.Salary > 50000).ToList();
    foreach (var employeesalary in employeessalary)
    {
        Console.WriteLine("Name:"+employeesalary.FirstName+" Salary:"+employeesalary.Salary);
       
    }
    Console.ReadLine();

    //Sorting:

    //Ascending:
    var sorting = context.Employees.OrderBy(e => e.Salary).ToList();
    //var sorting = context.Employees.OrderByDescending(e => e.Salary).ToList();
    foreach (var sort in sorting)
    {
        Console.WriteLine("Salary:"+sort.Salary);
    }
    Console.ReadLine();

    //Selecting Specific Fields:

    var EmployeeNameAndSalary = context.Employees.Select(s => new { s.FirstName, s.Salary }).ToList();
    foreach (var emp in EmployeeNameAndSalary)
    {
        Console.WriteLine("Employee Name:"+emp.FirstName+" Employee Salary:"+emp.Salary);
    }
    Console.ReadLine();

    //Grouping:

    var grouping = context.Employees.GroupBy(g => g.Salary);
    foreach (var group in grouping)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine("ManagerId:"+group.Key);
        foreach (var manager in group)
            Console.WriteLine("Name:" + manager.FirstName + " LN:" + manager.LastName);
    }
    Console.ReadLine();

    //Aggregation Operations:
    //Count:

    var count = context.Employees.Count(c => c.Salary > 50000);
    Console.WriteLine("Numbers of employee salary above $50000:"+count);
    Console.ReadLine();

    //Sum:

    var totalsalary = context.Employees.Sum(s => s.Salary);
    Console.WriteLine("Total price of all products:"+totalsalary);
    Console.ReadLine();

    //Average:

    var averagesalary = context.Employees.Average(a => a.Salary);
    Console.WriteLine("Average Salary:"+averagesalary);
    Console.ReadLine();

    //MIN and MAX:

    var minsalary = context.Employees.Min(m => m.Salary);
    var maxsalary = context.Employees.Max(m => m.Salary);
    Console.WriteLine("Lowest Salary:"+minsalary);
    Console.WriteLine("Highest Salary:"+maxsalary);
    Console.ReadLine();

    //Complex Queries:
    //Compound Query:
    var mostsalary = context.Employees.GroupBy(p => p.EmployeeId)
        .Select(group => new
        {
            EmployeeId = group.Key,
            Mostsalary = group.OrderBy(p => p.Salary).FirstOrDefault()
        });
    foreach (var item in mostsalary)
    {
        Console.WriteLine("EmployeeId:"+item.EmployeeId+"Name:"+item.Mostsalary.FirstName+"Salary:"+item.Mostsalary.Salary);
    }
    Console.ReadLine();
}