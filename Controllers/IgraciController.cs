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
    public class IgraciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IgraciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Igraci
        public async Task<IActionResult> Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;

                var igraci = from igrac in _context.Igrac
                              select igrac;

                igraci = igraci.Where(igrac => igrac.Ime.Contains(search));
                return View(igraci.ToList());
            }
            return View(await _context.Igrac.ToListAsync());
        }

        // GET: Igraci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Igrac == null)
            {
                return NotFound();
            }

            var igrac = await _context.Igrac
                .FirstOrDefaultAsync(m => m.Id == id);
            if (igrac == null)
            {
                return NotFound();
            }

            return View(igrac);
        }

        // GET: Igraci/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Igraci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,BrojDresa,Klub")] Igrac igrac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(igrac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(igrac);
        }

        // GET: Igraci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Igrac == null)
            {
                return NotFound();
            }

            var igrac = await _context.Igrac.FindAsync(id);
            if (igrac == null)
            {
                return NotFound();
            }
            return View(igrac);
        }

        // POST: Igraci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,BrojDresa,Klub")] Igrac igrac)
        {
            if (id != igrac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(igrac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IgracExists(igrac.Id))
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
            return View(igrac);
        }

        // GET: Igraci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Igrac == null)
            {
                return NotFound();
            }

            var igrac = await _context.Igrac
                .FirstOrDefaultAsync(m => m.Id == id);
            if (igrac == null)
            {
                return NotFound();
            }

            return View(igrac);
        }

        // POST: Igraci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Igrac == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Igrac'  is null.");
            }
            var igrac = await _context.Igrac.FindAsync(id);
            if (igrac != null)
            {
                _context.Igrac.Remove(igrac);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IgracExists(int id)
        {
          return _context.Igrac.Any(e => e.Id == id);
        }
    }
}
