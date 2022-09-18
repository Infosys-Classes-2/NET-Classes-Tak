using HRM.Infrastructure.Repositories;
using HRM.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

// Yasma 
namespace HRM.Web.Data
{
    public class EmployeeContext: IdentityDbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> dbContextOptions):
            base(dbContextOptions)
        {
        }
        /*
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=HrmDb;"
            + "Integrated Security=true");
            // optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        */

        // Auto Value field in Table (Database seeding)  
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "HR" }
                );
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Designation> Designation { get; set; }

    }
}
