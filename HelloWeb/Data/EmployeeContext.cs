using HelloWeb.Models;
using Microsoft.EntityFrameworkCore;
namespace HelloWeb.Data
{
    public class EmployeeContext:DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
