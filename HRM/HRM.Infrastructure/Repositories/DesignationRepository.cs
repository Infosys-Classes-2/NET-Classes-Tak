using HRM.ApplicationCore.Models;
using HRM.Web.Data;
using HRM.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Repositories
{
    public class DesignationRepository
    {
        private readonly EmployeeContext db;
        public DesignationRepository(EmployeeContext employeeContext)
        {
            db = employeeContext;
        }

        public async Task<List<Designation>> GetAll()
        {
            var designations = db.Designation.ToList();
            return designations;
        }

        public async Task<Designation> GetAsync(int id) =>
            await db.Designation.FindAsync(id);

        public async Task<int> InsertAsync(Designation designation)
        {
            await db.Designation.AddAsync(designation);
            return await CommitAsync();
        }

        public async Task<int> EditAsync(Designation designation)
        {
            db.Designation.Update(designation);
            return await CommitAsync();
        }

        public async Task<int> DeleteAsync(Designation designation)
        {
            db.Designation.Remove(designation);
            return await CommitAsync();
        }

        public async Task<int> CommitAsync()
        {
            var rowsAffected = await db.SaveChangesAsync();
            return rowsAffected;
        }

    }
}
