using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PINProject.Data;
using Rukomet.Models;

namespace Rukomet.Controllers
{
    public class KluboviController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KluboviController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Klubovi
        public async Task<IActionResult> Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;

                var klubovi = from klub in _context.Klub
                              select klub;

                klubovi = klubovi.Where(klub => klub.ImeKluba.Contains(search));
                return View(klubovi.ToList());
            }
              return View(await _context.Klub.ToListAsync());
        }

        // GET: Klubovi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Klub == null)
            {
                return NotFound();
            }

            var klub = await _context.Klub
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klub == null)
            {
                return NotFound();
            }

            return View(klub);
        }

        // GET: Klubovi/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klubovi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImeKluba,GradKluba,BrojTrofeja")] Klub klub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klub);
        }

        // GET: Klubovi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klub == null)
            {
                return NotFound();
            }

            var klub = await _context.Klub.FindAsync(id);
            if (klub == null)
            {
                return NotFound();
            }
            return View(klub);
        }

        // POST: Klubovi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImeKluba,GradKluba,BrojTrofeja")] Klub klub)
        {
            if (id != klub.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlubExists(klub.Id))
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
            return View(klub);
        }

        // GET: Klubovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klub == null)
            {
                return NotFound();
            }

            var klub = await _context.Klub
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klub == null)
            {
                return NotFound();
            }

            return View(klub);
        }

        // POST: Klubovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klub == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Klub'  is null.");
            }
            var klub = await _context.Klub.FindAsync(id);
            if (klub != null)
            {
                _context.Klub.Remove(klub);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlubExists(int id)
        {
          return _context.Klub.Any(e => e.Id == id);
        }
    }
}
