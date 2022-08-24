using Microsoft.AspNetCore.Mvc;
using HelloWeb.Models;

namespace HelloWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // employee/list
        
        public IActionResult List()
        {
            Employee employee1 = new()
            {
                FirstName = "Ram",
                LastName = "Basnet",
                Designation = "Software Engineer",
                level = "7",
                Department = "HRS",

            };

            Employee employee2 = new()
            {
                FirstName = "Ram",
                LastName = "Basnet",
                Designation = "Software Engineer",
                level = "7",
                Department = "HRS",

            };
            List<Employee> employees = new List<Employee>() { employee1, employee2};
            return View(employees);
        }
    }
}
