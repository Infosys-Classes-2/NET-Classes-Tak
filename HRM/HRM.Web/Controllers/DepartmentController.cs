using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRM.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using HRM.Infrastructure.Repositories;
using HRM.Web.Mapper;

namespace HRM.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            var departments = await departmentRepository.GetAllAsync();
            var departmentViewModels = departments.ToViewModel();

            return departmentViewModels != null ?
                        View(departmentViewModels) :
                        Problem("No Departments exist on database.");
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var department = await departmentRepository.GetAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }

            return View(department.ToViewModel());
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Established")] Department department)
        {
            if (ModelState.IsValid)
            {
                await departmentRepository.InsertAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var department = await departmentRepository.GetAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Established")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await departmentRepository.EditAsync(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var department = await departmentRepository.GetAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await departmentRepository.GetAsync(id);
            if (department != null)
            {
                await departmentRepository.DeleteAsync(department);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            var department = departmentRepository.GetAsync(id).Result;
            return department != null;
        }
    }
}
