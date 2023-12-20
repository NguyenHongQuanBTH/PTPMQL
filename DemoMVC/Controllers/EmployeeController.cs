using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DemoMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public EmployeeController(ApplicationDbcontext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Models = await _context.Person.ToListAsync();
            return View(Models);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId, FullName, Address, Age")] Employee employee)
        {
           if(ModelState.IsValid)
           {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           }
           return View(employee);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if(id == null || _context.Person == null)
            {
                return NotFound();
            }
            var employee = await _context.Person.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View (employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeId, FullName, Address, Age")] Employee employee)
        {
            if(id != employee.PersonId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try{
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!PersonExists(employee.PersonId))
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
            return View(employee);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }
            var person = await _context.Person
            .FirstOrDefaultAsync(m => m.PersonId == id);
            if(person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if(_context.Person == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person' is null.");
            }
            var person = await _context.Person.FindAsync(id);
            if(person != null)
            {
                _context.Person.Remove(person);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool PersonExists(string id)
        {
            return (_context.Person?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}