using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESTBooks_B.Data;
using ESTBooks_B.Models;

namespace ESTBooks_B.Controllers
{
    public class BookStores_BController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookStores_BController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookStores_B
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookStore_B.ToListAsync());
        }

        // GET: BookStores_B/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookStore_B = await _context.BookStore_B
                .FirstOrDefaultAsync(m => m.BookStore_BId == id);
            if (bookStore_B == null)
            {
                return NotFound();
            }

            return View(bookStore_B);
        }

        // GET: BookStores_B/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookStores_B/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookStore_BId,Location_B")] BookStore_B bookStore_B)
        {
            if (ModelState.IsValid)
            {
                bookStore_B.BookStore_BId = Guid.NewGuid();
                _context.Add(bookStore_B);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookStore_B);
        }

        // GET: BookStores_B/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookStore_B = await _context.BookStore_B.FindAsync(id);
            if (bookStore_B == null)
            {
                return NotFound();
            }
            return View(bookStore_B);
        }

        // POST: BookStores_B/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BookStore_BId,Location_B")] BookStore_B bookStore_B)
        {
            if (id != bookStore_B.BookStore_BId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookStore_B);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookStore_BExists(bookStore_B.BookStore_BId))
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
            return View(bookStore_B);
        }

        // GET: BookStores_B/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookStore_B = await _context.BookStore_B
                .FirstOrDefaultAsync(m => m.BookStore_BId == id);
            if (bookStore_B == null)
            {
                return NotFound();
            }

            return View(bookStore_B);
        }

        // POST: BookStores_B/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bookStore_B = await _context.BookStore_B.FindAsync(id);
            if (bookStore_B != null)
            {
                _context.BookStore_B.Remove(bookStore_B);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookStore_BExists(Guid id)
        {
            return _context.BookStore_B.Any(e => e.BookStore_BId == id);
        }
    }
}
