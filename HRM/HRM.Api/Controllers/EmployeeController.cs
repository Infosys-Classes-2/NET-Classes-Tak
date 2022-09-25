using HRM.ApplicationCore.Models;
using HRM.Infrastructure.Repositories;
using HRM.Web.Data;
using Microsoft.AspNetCore.Mvc;


namespace HRM.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly EmployeeContext db;

        private string searchText;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("searchText")]
        public async Task<IActionResult> Get()
        {
            var employees = await employeeRepository.GetAllAsync(searchText);
            return Ok(employees);
        }
    }
}
