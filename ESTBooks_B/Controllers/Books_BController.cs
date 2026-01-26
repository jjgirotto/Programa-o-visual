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
    public class Books_BController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Books_BController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Books_B
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Book_B.Include(b => b.Store_B);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Books_B/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book_B = await _context.Book_B
                .Include(b => b.Store_B)
                .FirstOrDefaultAsync(m => m.Book_BId == id);
            if (book_B == null)
            {
                return NotFound();
            }

            return View(book_B);
        }

        // GET: Books_B/Create
        public IActionResult Create()
        {
            ViewData["Store_BId"] = new SelectList(_context.Set<BookStore_B>(), "BookStore_BId", "BookStore_BId");
            populateViewData();
            return View();
        }

        // POST: Books_B/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book_BId,Title_B,Price_B,Units_B,Category_B,Store_BId")] Book_B book_B)
        {
            
            if (ModelState.IsValid)
            {
                book_B.Book_BId = Guid.NewGuid();
                _context.Add(book_B);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["Store_BId"] = new SelectList(_context.Set<BookStore_B>(), "BookStore_BId", "BookStore_BId", book_B.Store_BId);
            populateViewData(book_B);
            return View(book_B);
        }

        // GET: Books_B/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book_B = await _context.Book_B.FindAsync(id);
            if (book_B == null)
            {
                return NotFound();
            }
            ViewData["Store_BId"] = new SelectList(_context.Set<BookStore_B>(), "BookStore_BId", "BookStore_BId", book_B.Store_BId);
            populateViewData(book_B);
            return View(book_B);
        }

        // POST: Books_B/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Book_BId,Title_B,Price_B,Units_B,Category_B,Store_BId")] Book_B book_B)
        {
            if (id != book_B.Book_BId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book_B);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Book_BExists(book_B.Book_BId))
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
            ViewData["Store_BId"] = new SelectList(_context.Set<BookStore_B>(), "BookStore_BId", "BookStore_BId", book_B.Store_BId);
            populateViewData(book_B);
            return View(book_B);
        }

        // GET: Books_B/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book_B = await _context.Book_B
                .Include(b => b.Store_B)
                .FirstOrDefaultAsync(m => m.Book_BId == id);
            if (book_B == null)
            {
                return NotFound();
            }

            return View(book_B);
        }

        // POST: Books_B/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var book_B = await _context.Book_B.FindAsync(id);
            if (book_B != null)
            {
                _context.Book_B.Remove(book_B);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Book_BExists(Guid id)
        {
            return _context.Book_B.Any(e => e.Book_BId == id);
        }

        private void populateViewData(Book_B? book = null)
        {
            ViewData["Store_BId"] = new SelectList(_context.Set<BookStore_B>(),
                                                "BookStore_BId", "Location",
                                                 book?.Store_BId);
            ViewData["Categories"] = new SelectList(Enum.GetValues<BookCategory_B>().Select(c =>
                                                    new {
                                                        Value = (int)c,
                                                        Name = c.ToString()
                                                      
                                                    }),
                                                          "Value", "Name");
        }
    }
}
