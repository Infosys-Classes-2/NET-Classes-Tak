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

        public async Task<List<Designation>> GetAll()
        {
            var designations = db.Designation.ToList();
            return designations;
        }

        //Mine Added
        public async Task<Designation> GetAsync(int id) =>
         await db.Designation.FindAsync(id);


        public async Task<int> InsertAsync(Designation dgn)
        {
            await db.Designation.AddAsync(dgn);
            return await CommitAsync();
        }

        public async Task<int> EditAsync(Designation dgn)
        {
            db.Designation.Update(dgn);
            return await CommitAsync();
        }

        public async Task<int> CommitAsync()
        {
            var rowsAffected = await db.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
