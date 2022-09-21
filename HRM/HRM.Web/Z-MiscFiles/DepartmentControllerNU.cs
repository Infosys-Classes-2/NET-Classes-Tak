using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRM.Web.Data;
using HRM.Web.Models;
using Microsoft.AspNetCore.Authorization;
using HRM.Infrastructure.Repositories;
using HRM.Web.Mapper;
using HRM.Web.ViewModels;

namespace HRM.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentControllerNU : Controller
    {
        /*
        private readonly EmployeeContext _context;

        public DepartmentController(EmployeeContext context)
        {
            _context = context;
        }
        */
        private readonly DepartmentRepositoryNU departmentRepository;

        // Dependency injection (DI), built-in
        public DepartmentControllerNU(DepartmentRepositoryNU departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }


        // GET: Department
        /*
        public async Task<IActionResult> Index()
        {
              return _context.Department != null ? 
                          View(await _context.Department.ToListAsync()) :
                          Problem("Entity set 'EmployeeContext.Department'  is null.");
        }
        */
        public async Task<IActionResult> Index()
        {
            var department = await departmentRepository.GetAllAsync();
            var departmentViewModel = department.ToViewModel();

            return departmentViewModel != null ? 
                View(departmentViewModel):
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

            /*
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
            */
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            var department = departmentRepository.GetAsync(id.Value);
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
            if (department == null)
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
