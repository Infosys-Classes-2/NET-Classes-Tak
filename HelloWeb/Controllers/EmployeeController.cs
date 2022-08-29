using Microsoft.AspNetCore.Mvc;
using HelloWeb.Models;
using Microsoft.Data.SqlClient;

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
            GetPeople();
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
