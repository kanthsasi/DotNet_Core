using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models.Domain
{
    public class Employee
    {
        [Key] //Data annotations
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Salary { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; }//Collection navigation property to represent the employees managed by the manager
       

        //One-to-Many relationship with Manager

        public int ManagerId { get; set; }
        public Manager Manager { get; set; }//Navigate to represent the manager

        //one-to-one relationship with manager
        public EmployeeDetails EmployeeDetails { get; set; }//Reference navigation to dependent entity-EmployeeDetails
    }
}
