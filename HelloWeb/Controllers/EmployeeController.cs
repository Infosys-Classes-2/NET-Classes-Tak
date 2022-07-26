﻿using Microsoft.AspNetCore.Mvc;
using HelloWeb.Models;
using Microsoft.Data.SqlClient;
using HelloWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelloWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // Tightly coupled code
        // EmployeeContext db = new EmployeeContext();

        private readonly EmployeeContext db;

        // Dependency injection (DI), built-in
        public EmployeeController(EmployeeContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        // Async application
        public async Task<IActionResult> List()
        {
            //EmployeeContext db = new();
            var employees = await db.Employees.Include(x => x.Department).Include(y => y.Designation).ToListAsync();
            // var degsination = await db.Employees.Include(x => x.Designation).ToListAsync();
            /*
            var quaryEmployee = from employee in db.Employees
                                join dept in db.Department on employee.DepartmentId equals dept.Id
                                select new
                                {
                                    Name = employee.FirstName,
                                    Department = dept.Name
                                };
            */
            //GetPeople();
            return View(employees);
        }
        [HttpGet] // This will be called when 'Add Employee' button is clicked
        public async Task<IActionResult> Add() //view lae data dina, user lai form display garna
        {
            // Dropdown list selection for form field for Dept
            var department = await db.Department.ToListAsync();
            ViewData["Department"] = department.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            // Dropdown list selection for form field for Designation
            var designation = await db.Designation.ToListAsync();
            ViewData["Designation"] = designation.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }

        [HttpPost] // This will be called when submit button click
        public async Task<IActionResult> Add(Employee emp) //View bata data pauna, db lai data pathauna viewbata
        {
            // Add to db
            //employees.Add(emp)
            await db.Employees.AddAsync(emp);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(List)); //"List"
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var department = await db.Department.ToListAsync();
            ViewData["Department"] = department.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var employee = await db.Employees.FindAsync(id);
            //var employee = Employee.Where(XmlConfigurationExtensions => x.ID == id).First();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp) //View bata data pauna, user lai form pathauna viewma
        {
            db.Employees.Update(emp);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(List)); //"List"
        }

        [HttpGet]
        public IActionResult Delete(int id) //View bata data pauna, user lai form pathauna viewma
        {            
            var employee = db.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee emp) //View bata data pauna, user lai form pathauna viewma
        {
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        // Using ADO.NET
        public void GetPeople()
        {
            // Using ADO.NET
            string connectionString =
                @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=TestDb;"
                + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * from dbo.Person";

        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.
        using (SqlConnection connection = new(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new(queryString, connection);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
