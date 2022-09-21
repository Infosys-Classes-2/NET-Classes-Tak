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
    }
}