using HRM.ApplicationCore.Models;
using HRM.Infrastructure.Repositories;
using HRM.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HRM.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly DepartmentRepository departmentRepository;
        private readonly DesignationRepository designationRepository;

        //public EmployeeController(EmployeeRepository employeeRepository)
        //{
        //    this.employeeRepository = employeeRepository;
        //}

        public EmployeeController(EmployeeRepository employeeRepository,
    DepartmentRepository departmentRepository,
    DesignationRepository designationRepository)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
            this.designationRepository = designationRepository;
        }

        [HttpGet]
        //public async Task<IActionResult> Get(string searchText)
        public async Task<IActionResult> Get(string searchText)
        {
            var employees = await employeeRepository.GetAllAsync(searchText);
            return Ok(employees);
        }

    }
}