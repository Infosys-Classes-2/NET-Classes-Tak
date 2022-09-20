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
    public class DepartmentController : Controller
    {
        /*
        private readonly EmployeeContext _context;

        public DepartmentController(EmployeeContext context)
        {
            _context = context;
        }
        */
        private readonly DepartmentRepository departmentRepository;
        private object departmentViewModel;

        // Dependency injection (DI), built-in
        public DepartmentController(DepartmentRepository departmentRepository)
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

            return View(department.ToViewModel());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var department = await departmentRepository.GetAllAsync();

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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Established")] DepartmentViewModel departmentViewModel)
        {
            /*
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
                */
            var dept = departmentViewModel.ToModel();

            departmentRepository.InsertAsync(dept);

                return RedirectToAction(nameof(Index));

            }

            // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var department = await departmentRepository.GetAsync(id);

            return View(department.ToViewModel());

            /*
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
            */
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Established")] DepartmentViewModel departmentViewModel)
        {
            var emp = departmentViewModel.ToModel();

            await departmentRepository.EditAsync(emp);

            return RedirectToAction(nameof(Index));

            /*
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
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
            */
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var department = departmentRepository.GetAsync(id);
            return View(department);

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

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DepartmentViewModel departmentViewModel)
        {
            var dept = departmentViewModel.ToModel();

            await departmentRepository.DeleteAsync(dept);

            return RedirectToAction(nameof(Index));

            /*
                public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Department == null)
            {
                return Problem("Entity set 'EmployeeContext.Department'  is null.");
            }
            var department = await _context.Department.FindAsync(id);
            if (department != null)
            {
                _context.Department.Remove(department);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            */
        }
        /*
        private bool DepartmentExists(int id)
        {
          return (_context.Department?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */
    }
}
