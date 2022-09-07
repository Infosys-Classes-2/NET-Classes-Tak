using Microsoft.AspNetCore.Mvc;
using HRM.Web.Models;
using Microsoft.Data.SqlClient;
using HRM.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.Web.Controllers
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
        // if nullable then keep .Value, if no nullable then no need to keep .Value
        public async Task<IActionResult> List(string searchText="")
        {
            //EmployeeContext db = ne
            var employees = await db.Employees
                .Where(e => e.Active.Value && (string.IsNullOrEmpty(searchText) //Short-circuit
                || e.FirstName.Contains(searchText)
                || e.LastName.Contains(searchText)))
                .Include(x => x.DepartmentName)
                .Include(y => y.DesignationName).ToListAsync();
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
        public async Task<IActionResult> Add(EmployeeViewModel emp) //View bata data pauna, db lai data pathauna viewbata
        {
            //string uniqueImageName = SaveProfileImage(emp);
            emp.ProfileImage = SaveProfileImage (emp.Avatar);
            emp.Active = true;
           
            // Add to db
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
            var designation = await db.Designation.ToListAsync();
            ViewData["Designation"] = designation.Select(y => new SelectListItem()
            {
                Text = y.Name,
                Value = y.Id.ToString()
            });

            var employee = await db.Employees.FindAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel emp) //View bata data pauna, user lai form pathauna viewma
        {
            if (emp.Avatar is not null)
            {
                emp.ProfileImage = SaveProfileImage(emp.Avatar);
            }

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
        public async Task<IActionResult> Delete(EmployeeViewModel emp) //View bata data pauna, user lai form pathauna viewma
        {
            //db.Employees.Remove(emp);
            var employee = await db.Employees.FindAsync(emp.Id );
            employee.Active = false;
            db.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        private string SaveProfileImage(IFormFile avatar)
        {
            //Save profile image to "Profile-images" folder
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profile-images");

            Directory.CreateDirectory(folderPath);

            var uniqueImageName = $"{Guid.NewGuid():D}_{avatar.FileName}";
            var filePath = Path.Combine(folderPath, uniqueImageName);

            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            avatar.CopyTo(fileStream);

            return uniqueImageName;
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
