
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinManager.Data;
using FinManager.Models;
using FinManager.Services;

namespace FinManager.Controllers
{
    public class DoersController : Controller
    {
        private readonly FinManagerContext _context;
        private readonly DoerService _doerService;

        public DoersController(FinManagerContext context, DoerService doerService)
        {
            _context = context;
            _doerService = doerService;
        }

        // GET: Doers
        public async Task<IActionResult> Index()
        {
            return _context.Doer != null ?
                        View(await _context.Doer.ToListAsync()) :
                        Problem("Entity set 'SalesWebMvcContext.Department'  is null.");
        }

        // GET: Doers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doer == null)
            {
                return NotFound();
            }

            var doer = await _context.Doer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doer == null)
            {
                return NotFound();
            }

            return View(doer);
        }

        // GET: Doers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Doer doer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doer);
        }

        // GET: Doers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doer == null)
            {
                return NotFound();
            }

            var doer = await _context.Doer.FindAsync(id);
            if (doer == null)
            {
                return NotFound();
            }
            return View(doer);
        }

        // POST: Doers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Doer doer)
        {
            if (id != doer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoerExists(doer.Id))
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
            return View(doer);
        }

        // GET: Doers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doer == null)
            {
                return NotFound();
            }

            var doer = await _context.Doer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doer == null)
            {
                return NotFound();
            }

            return View(doer);
        }

        // POST: Doers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doer == null)
            {
                return Problem("Entity set 'FinManagerContext.Doer'  is null.");
            }
            var doer = await _context.Doer.FindAsync(id);
            if (doer != null)
            {
                _context.Doer.Remove(doer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoerExists(int id)
        {
          return (_context.Doer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
