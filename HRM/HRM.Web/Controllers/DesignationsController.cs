using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRM.Web.Data;
using HRM.Web.Models;
using HRM.ApplicationCore.Models;
using HRM.Infrastructure.Repositories;

namespace HRM.Web.Controllers
{
    public class DesignationController : Controller
    {
        private readonly DesignationRepository designationRepository;

        public DesignationController(DesignationRepository designationRepository)
        {
            this.designationRepository = designationRepository;
        }

        /*
        private readonly EmployeeContext _context;

        public DesignationController(EmployeeContext context)
        {
            _context = context;
        }
        
        // GET: Designation
        public async Task<IActionResult> Index()
        {
            return _context.Designation != null ?
                        View(await _context.Designation.ToListAsync()) :
                        Problem("Entity set 'EmployeeContext.Designations'  is null.");
        }

        // GET: Designation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Designation == null)
            {
                return NotFound();
            }

            var designation = await _context.Designation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // GET: Designation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Designation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Detials")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(designation);
        }

        // GET: Designation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Designation == null)
            {
                return NotFound();
            }

            var designation = await _context.Designation.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }
            return View(designation);
        }

        // POST: Designation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Detials")] Designation designation)
        {
            if (id != designation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignationExists(designation.Id))
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
            return View(designation);
        }

        // GET: Designation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Designation == null)
            {
                return NotFound();
            }

            var designation = await _context.Designation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // POST: Designation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Designation == null)
            {
                return Problem("Entity set 'EmployeeContext.Designations'  is null.");
            }
            var designation = await _context.Designation.FindAsync(id);
            if (designation != null)
            {
                _context.Designation.Remove(designation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignationExists(int id)
        {
            return (_context.Designation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */
    }
}
