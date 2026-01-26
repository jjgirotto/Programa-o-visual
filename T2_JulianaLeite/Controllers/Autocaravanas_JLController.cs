using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T2_JulianaLeite.Data;
using T2_JulianaLeite.Models;

namespace T2_JulianaLeite.Controllers
{
    public class Autocaravanas_JLController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Autocaravanas_JLController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Autocaravanas_JL
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Autocaravana_JL.Include(a => a.ParqueAutocaravanismo_JL);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Autocaravanas_JL/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autocaravana_JL = await _context.Autocaravana_JL
                .Include(a => a.ParqueAutocaravanismo_JL)
                .FirstOrDefaultAsync(m => m.Autocaravana_JLId == id);
            if (autocaravana_JL == null)
            {
                return NotFound();
            }

            return View(autocaravana_JL);
        }

        // GET: Autocaravanas_JL/Create
        public IActionResult Create()
        {
            ViewData["ParqueAutocaravanismo_JLId"] = new SelectList(_context.ParqueAutocaravanismo_JL, "ParqueAutocaravanismo_JLId", "ParqueAutocaravanismo_JLId");
            return View();
        }

        // POST: Autocaravanas_JL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Autocaravana_JLId,Matricula_JL,Diaria_JL,ParqueAutocaravanismo_JLId")] Autocaravana_JL autocaravana_JL)
        {
            if (ModelState.IsValid)
            {
                autocaravana_JL.Autocaravana_JLId = Guid.NewGuid();
                _context.Add(autocaravana_JL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParqueAutocaravanismo_JLId"] = new SelectList(_context.ParqueAutocaravanismo_JL, "ParqueAutocaravanismo_JLId", "ParqueAutocaravanismo_JLId", autocaravana_JL.ParqueAutocaravanismo_JLId);
            return View(autocaravana_JL);
        }

        // GET: Autocaravanas_JL/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autocaravana_JL = await _context.Autocaravana_JL.FindAsync(id);
            if (autocaravana_JL == null)
            {
                return NotFound();
            }
            ViewData["ParqueAutocaravanismo_JLId"] = new SelectList(_context.ParqueAutocaravanismo_JL, "ParqueAutocaravanismo_JLId", "ParqueAutocaravanismo_JLId", autocaravana_JL.ParqueAutocaravanismo_JLId);
            return View(autocaravana_JL);
        }

        // POST: Autocaravanas_JL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Autocaravana_JLId,Matricula_JL,Diaria_JL,ParqueAutocaravanismo_JLId")] Autocaravana_JL autocaravana_JL)
        {
            if (id != autocaravana_JL.Autocaravana_JLId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autocaravana_JL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Autocaravana_JLExists(autocaravana_JL.Autocaravana_JLId))
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
            ViewData["ParqueAutocaravanismo_JLId"] = new SelectList(_context.ParqueAutocaravanismo_JL, "ParqueAutocaravanismo_JLId", "ParqueAutocaravanismo_JLId", autocaravana_JL.ParqueAutocaravanismo_JLId);
            return View(autocaravana_JL);
        }

        // GET: Autocaravanas_JL/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autocaravana_JL = await _context.Autocaravana_JL
                .Include(a => a.ParqueAutocaravanismo_JL)
                .FirstOrDefaultAsync(m => m.Autocaravana_JLId == id);
            if (autocaravana_JL == null)
            {
                return NotFound();
            }

            return View(autocaravana_JL);
        }

        // POST: Autocaravanas_JL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var autocaravana_JL = await _context.Autocaravana_JL.FindAsync(id);
            if (autocaravana_JL != null)
            {
                _context.Autocaravana_JL.Remove(autocaravana_JL);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Autocaravana_JLExists(Guid id)
        {
            return _context.Autocaravana_JL.Any(e => e.Autocaravana_JLId == id);
        }
    }
}
