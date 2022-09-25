using HRM.ApplicationCore.Models;
using HRM.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentRepository departmentRepository;
        public DepartmentController(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var department = await departmentRepository.GetAllAsync();
            return Ok(department);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var department = await departmentRepository.GetAsync(id);
            if(department == null)
                return NotFound();
            return Ok(department);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Department department)
        {
            await departmentRepository.InsertAsync(department);
            return Created(nameof(Get), department.Id);
        }

    }
}
