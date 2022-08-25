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
                level = 7,
                JoinDate = DateTime.Now,
                Department = "HRS",

            };

            Employee employee2 = new()
            {
                FirstName = "Jenny",
                LastName = "Maharjan",
                Designation = "Software Engineer",
                level = 7,
                JoinDate= DateTime.Now,
                Department = "HRS",

            };
            List<Employee> employees = new List<Employee>() { employee1, employee2 };

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
            //Employee.Add(emp);
            return RedirectToAction(nameof(List)); //"List"
        }

       public IActionResult Edit(int id)
        {
            //var employee = Employee.Where(XmlConfigurationExtensions => x.ID == id).First();
            return View();
        }
    }
}
