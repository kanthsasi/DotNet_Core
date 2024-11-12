/*
using EFCore.Data;

using (var context = new AppDbContext())
{
    //Begin Transaction
    using (var transaction = context.Database.BeginTransaction())
    {
        //Perform database operations
        var employeeId = 3;
        //Retrive the employee details,project,and manager to update
        var employeeToUpdate = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        var employeeDetailsToUpdate = context.EmployeeDetails.FirstOrDefault(ed => ed.Id == employeeToUpdate.EmployeeId);

        if (employeeToUpdate != null && employeeDetailsToUpdate != null)
        {
            try
            {
                //Update the employee,s last name and address
                employeeToUpdate.LastName = "H";
                employeeDetailsToUpdate.Address = "Singapore";

                //Update manager details
                employeeToUpdate.ManagerId = 3;
                context.ChangeTracker.DetectChanges();
                Console.WriteLine(context.ChangeTracker.DebugView.LongView);
                Console.ReadLine();
                context.SaveChanges();
                //Commit the transaction
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
           
        }
        else
        {
            throw new Exception("New Exception");
        }
    }
}
*/