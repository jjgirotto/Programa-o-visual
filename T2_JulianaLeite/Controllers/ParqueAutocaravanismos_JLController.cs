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
    public class ParqueAutocaravanismos_JLController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParqueAutocaravanismos_JLController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParqueAutocaravanismos_JL
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParqueAutocaravanismo_JL.Include(d => d.Autocaravanas_JL).ToListAsync());
        }

        // GET: ParqueAutocaravanismos_JL/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parqueAutocaravanismo_JL = await _context.ParqueAutocaravanismo_JL
                .FirstOrDefaultAsync(m => m.ParqueAutocaravanismo_JLId == id);
            if (parqueAutocaravanismo_JL == null)
            {
                return NotFound();
            }

            return View(parqueAutocaravanismo_JL);
        }

        // GET: ParqueAutocaravanismos_JL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParqueAutocaravanismos_JL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParqueAutocaravanismo_JLId,Nome_JL")] ParqueAutocaravanismo_JL parqueAutocaravanismo_JL)
        {
            if (ModelState.IsValid)
            {
                parqueAutocaravanismo_JL.ParqueAutocaravanismo_JLId = Guid.NewGuid();
                _context.Add(parqueAutocaravanismo_JL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parqueAutocaravanismo_JL);
        }

        // GET: ParqueAutocaravanismos_JL/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parqueAutocaravanismo_JL = await _context.ParqueAutocaravanismo_JL.FindAsync(id);
            if (parqueAutocaravanismo_JL == null)
            {
                return NotFound();
            }
            return View(parqueAutocaravanismo_JL);
        }

        // POST: ParqueAutocaravanismos_JL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ParqueAutocaravanismo_JLId,Nome_JL")] ParqueAutocaravanismo_JL parqueAutocaravanismo_JL)
        {
            if (id != parqueAutocaravanismo_JL.ParqueAutocaravanismo_JLId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parqueAutocaravanismo_JL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParqueAutocaravanismo_JLExists(parqueAutocaravanismo_JL.ParqueAutocaravanismo_JLId))
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
            return View(parqueAutocaravanismo_JL);
        }

        // GET: ParqueAutocaravanismos_JL/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parqueAutocaravanismo_JL = await _context.ParqueAutocaravanismo_JL
                .FirstOrDefaultAsync(m => m.ParqueAutocaravanismo_JLId == id);
            if (parqueAutocaravanismo_JL == null)
            {
                return NotFound();
            }

            return View(parqueAutocaravanismo_JL);
        }

        // POST: ParqueAutocaravanismos_JL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var parqueAutocaravanismo_JL = await _context.ParqueAutocaravanismo_JL.FindAsync(id);
            if (parqueAutocaravanismo_JL != null)
            {
                _context.ParqueAutocaravanismo_JL.Remove(parqueAutocaravanismo_JL);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParqueAutocaravanismo_JLExists(Guid id)
        {
            return _context.ParqueAutocaravanismo_JL.Any(e => e.ParqueAutocaravanismo_JLId == id);
        }
    }
}
