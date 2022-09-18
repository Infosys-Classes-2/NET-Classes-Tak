using HRM.Web.Data;
using HRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<Department>> GetAll()
        {
            var departments = db.Department.ToList();
            return departments;
        }
    }
}
