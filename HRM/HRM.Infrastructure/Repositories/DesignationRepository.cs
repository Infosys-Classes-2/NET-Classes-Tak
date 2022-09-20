using HRM.Web.Data;
using HRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Repositories
{
    public class DesignationRepository
    {
        private readonly EmployeeContext db;
        public DesignationRepository(EmployeeContext employeeContext)
        {
            db = employeeContext;
        }

        public async Task<List<Designation>> GetAllAsync()
        {
            var designations = db.Designation.ToList();
            return designations;
        }

        //Mine Added
        public async Task<Designation> GetAsync(int id) =>
         await db.Designation.FindAsync(id);


        public async Task<int> InsertAsync(Designation department)
        {
            await db.Designation.AddAsync(department);
            return await CommitAsync();
        }

        public async Task<int> EditAsync(Designation department)
        {
            db.Designation.Update(department);
            return await CommitAsync();
        }

        public async Task<int> DeleteAsync(Designation department)
        {
            db.Designation.Remove(department);
            return await CommitAsync();
        }

        public async Task<int> CommitAsync()
        {
            var rowsAffected = await db.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
