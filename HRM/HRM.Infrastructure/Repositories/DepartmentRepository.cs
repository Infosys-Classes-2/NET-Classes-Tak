using HRM.ApplicationCore.Models;
using HRM.Web.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HRM.Infrastructure.Repositories
{
    public class DepartmentRepository
    {
        private readonly EmployeeContext db;
        public DepartmentRepository(EmployeeContext employeeContext)
        {
            db = employeeContext;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            var departments = db.Department.ToList();
            return departments;
        }

        public async Task<Department> GetAsync(int id) =>
            await db.Department.FindAsync(id);

        public async Task<int> InsertAsync(Department department)
        {
            await db.Department.AddAsync(department);
            return await CommitAsync();
        }

        public async Task<int> EditAsync(Department department)
        {
            db.Department.Update(department);
            return await CommitAsync();
        }

        public async Task<int> DeleteAsync(Department department)
        {
            db.Department.Remove(department);
            return await CommitAsync();
        }

        public async Task<int> CommitAsync()
        {
            var rowsAffected = await db.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
