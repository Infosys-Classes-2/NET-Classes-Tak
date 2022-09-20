using HRM.Web.Data;
using HRM.Web.Models;
using Microsoft.EntityFrameworkCore;

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
            var departments = await db.Department.ToListAsync();
            return departments;
        }

        //Mine Added
        public async Task<Department> GetAsync(int id) =>
         await db.Department.FindAsync(id);


        public async Task<int> InsertAsync(Department dept)
        {
            await db.Department.AddAsync(dept);
            return await CommitAsync();
        }

        public async Task<int> EditAsync(Department dept)
        {
            db.Department.Update(dept);
            return await CommitAsync();
        }

        public async Task<int> CommitAsync()
        {
            var rowsAffected = await db.SaveChangesAsync();
            return rowsAffected;
        }
        public async Task<int> DeleteAsync(Department dept)
        {
            db.Department.Remove(dept);
            return await CommitAsync();
        }


    }
}
