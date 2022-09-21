using HRM.ApplicationCore.Models;
using HRM.Web.Data;
using HRM.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Repositories
{
    public class EmployeeRepository
    {
        private readonly EmployeeContext db;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            db = employeeContext;
        }

        public async Task<List<Employee>> GetAllAsync(string searchText)
        {
            var employees = await db.Employees
            .Where(e => e.Active.Value && (string.IsNullOrEmpty(searchText)  //Short-circuit
                    || e.FirstName.Contains(searchText)
                    || e.LastName.Contains(searchText)))
            .Include(x => x.Department)
            .Include(y => y.Designation).ToListAsync();

            return employees;
        }

        public async Task<Employee> GetAsync(int id) =>
            await db.Employees.FindAsync(id);

        public async Task<int> InsertAsync(Employee emp)
        {
            await db.Employees.AddAsync(emp);
            return await CommitAsync();
        }

        public async Task<int> EditAsync(Employee emp)
        {
            db.Employees.Update(emp);
            return await CommitAsync();
        }

        public async Task<int> CommitAsync()
        {
            var rowsAffected = await db.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
