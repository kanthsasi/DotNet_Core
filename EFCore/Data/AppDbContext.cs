using EFCore.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data
{
    public class AppDbContext:DbContext
    {
        public string ConnectionString { get; }
        public AppDbContext()
        {
            ConnectionString = "Server=SASIKANTH-PC;Database=EmployeeMngt_EFCorePractice;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>()
                 .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);
        }
    }
}
