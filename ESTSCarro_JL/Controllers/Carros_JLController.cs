using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESTSCarro_JL.Models;

namespace ESTSCarro_JL.Controllers
{
    public class Carros_JLController : Controller
    {
        private readonly ESTSCarro_JLContext _context;

        public Carros_JLController(ESTSCarro_JLContext context)
        {
            _context = context;
        }

        // GET: Carros_JL
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carro_JL.ToListAsync());
        }

        // GET: Carros_JL/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro_JL = await _context.Carro_JL
                .FirstOrDefaultAsync(m => m.Carro_JLId == id);
            if (carro_JL == null)
            {
                return NotFound();
            }

            return View(carro_JL);
        }

        // GET: Carros_JL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carros_JL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Carro_JLId,Marca_JL,Modelo_JL")] Carro_JL carro_JL)
        {
            if (ModelState.IsValid)
            {
                carro_JL.Carro_JLId = Guid.NewGuid();
                _context.Add(carro_JL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carro_JL);
        }

        // GET: Carros_JL/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro_JL = await _context.Carro_JL.FindAsync(id);
            if (carro_JL == null)
            {
                return NotFound();
            }
            return View(carro_JL);
        }

        // POST: Carros_JL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Carro_JLId,Marca_JL,Modelo_JL")] Carro_JL carro_JL)
        {
            if (id != carro_JL.Carro_JLId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro_JL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Carro_JLExists(carro_JL.Carro_JLId))
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
            return View(carro_JL);
        }

        // GET: Carros_JL/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro_JL = await _context.Carro_JL
                .FirstOrDefaultAsync(m => m.Carro_JLId == id);
            if (carro_JL == null)
            {
                return NotFound();
            }

            return View(carro_JL);
        }

        // POST: Carros_JL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var carro_JL = await _context.Carro_JL.FindAsync(id);
            if (carro_JL != null)
            {
                _context.Carro_JL.Remove(carro_JL);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Carro_JLExists(Guid id)
        {
            return _context.Carro_JL.Any(e => e.Carro_JLId == id);
        }
    }
}
