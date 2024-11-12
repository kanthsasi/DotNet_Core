/*
using EFCore.Data;
using EFCore.Models.Domain;

namespace EFCore
{
    public class Program
    {
        
        static void CreateEmployee(Employee employee)
        {
            using (var context = new AppDbContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                Console.WriteLine("Employee Added Successfully.");
            }
        }
        static void ReadAllEmployees()
        {
            using (var context = new AppDbContext())
            {
                var employees = context.Employees.ToList();
                Console.WriteLine("All Employees:");
                foreach (var employee in employees)
                {
                    Console.WriteLine("Id:"+employee.EmployeeId+"Name:"+employee.FirstName+"Salary:"+employee.Salary);
                }
            }
        }

        static void UpdateEmployeeSalary(int id, long newSalary)
        {
            using (var context = new AppDbContext())
            {
                var employee = context.Employees.Find(id);
                if (employee != null)
                {
                    employee.Salary = newSalary;
                    //Change Tracking:
                    context.ChangeTracker.DetectChanges();
                    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
                    context.SaveChanges();
                    Console.WriteLine("Employee Salary updated successfully.");
                }
            }
        }

        static void DeleteEmployee(int id)
        {
            using (var context = new AppDbContext())
            {
                var employee = context.Employees.Find(id);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    Console.WriteLine("Employee Deleted Successfully.");
                }
            }
        }
        static void Main()
        {
            CreateEmployee(new Employee { FirstName = "Rajini", LastName = "B", Salary = 25000, ManagerId = 3 });
            ReadAllEmployees();
            UpdateEmployeeSalary(9,90000);
            DeleteEmployee(12);
            Console.ReadLine();
        }

    }
}
*/