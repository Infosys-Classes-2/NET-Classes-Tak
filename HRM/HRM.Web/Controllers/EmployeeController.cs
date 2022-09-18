using HRM.Infrastructure.Repositories;
using HRM.Web.Mapper;
using HRM.Web.Models;
using HRM.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace HRM.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly DepartmentRepository departmentRepository;
        private readonly DesignationRepository designationRepository;

        // Dependency injection (DI), built-in
        public EmployeeController(EmployeeRepository employeeRepository,
            DepartmentRepository departmentRepository,
            DesignationRepository designationRepository)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
            this.designationRepository = designationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List(string searchText)
        {
            var employees = await employeeRepository.GetAllAsync(searchText);

            return View(employees.ToViewModel());
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Add()
        {
            var departments = await departmentRepository.GetAll();
            ViewData["Department"] = departments.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var designations = await designationRepository.GetAll();
            ViewData["Designation"] = designations.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel employeeViewModel)
        {
            employeeViewModel.ProfileImage = SaveProfileImage(employeeViewModel.Avatar);
            employeeViewModel.Active = true;

            var emp = employeeViewModel.ToModel();

            employeeRepository.InsertAsync(emp);

            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var departments = await departmentRepository.GetAll();
            ViewData["Department"] = departments.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var designations = await designationRepository.GetAll();
            ViewData["Designation"] = designations.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var employee = await employeeRepository.GetAsync(id);

            return View(employee.ToViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            if (employeeViewModel.Avatar is not null)
            {
                employeeViewModel.ProfileImage = SaveProfileImage(employeeViewModel.Avatar);
            }
            var emp = employeeViewModel.ToModel();

            await employeeRepository.EditAsync(emp);

            return RedirectToAction(nameof(List));
        }

        public IActionResult Delete(int id)
        {
            var employee = employeeRepository.GetAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee emp)
        {
            //db.Employees.Remove(emp);
            var employee = await employeeRepository.GetAsync(emp.Id);

            employee.Active = false;

            employeeRepository.CommitAsync();

            return RedirectToAction(nameof(List));
        }

        private string SaveProfileImage(IFormFile avatar)
        {
            // Save profile image to "profile-images" folder        
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profile-images");

            Directory.CreateDirectory(folderPath);

            var uniqueImageName = $"{Guid.NewGuid():D}_{avatar.FileName}";
            var filePath = Path.Combine(folderPath, uniqueImageName);

            using FileStream fileStream = new(filePath, FileMode.Create);
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

            string queryString = "SELECT * from person";

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
                Console.ReadLine();
            }
        }
    }
}