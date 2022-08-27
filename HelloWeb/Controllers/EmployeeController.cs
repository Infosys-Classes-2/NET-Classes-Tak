using Microsoft.AspNetCore.Mvc;
using HelloWeb.Models;

namespace HelloWeb.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees = new()
        {
            new()
            {
                Id = 1,
                FirstName = "Ram",
                LastName = "Basnet",
                Designation = "Software Engineer",
                level = 7,
                JoinDate = DateTime.Now,
                Department = "HRS",

            },
            new()
            {
                Id=2,
                FirstName = "Ram",
                LastName = "Basnet",
                Designation = "Software Engineer",
                level = 7,
                JoinDate = DateTime.Now,
                Department = "HRS",

            }
        };
        public IActionResult List()
        {            
            return View(employees);
        }
        [HttpGet]
        public IActionResult Add() //view lae data dina, user lai form display garna
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee emp) //View bata data pauna, user lai form pathauna viewma
        {
            // Add to db
            employees.Add(emp);
            return RedirectToAction(nameof(List)); //"List"
        }

       public IActionResult Edit(int id)
        {
            var employee = employees.Where(x => x.Id == id).First();
            //var employee = Employee.Where(XmlConfigurationExtensions => x.ID == id).First();
            return View(employee);
        }
    }
}
