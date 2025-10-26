using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{
    public class MiniaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MiniaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Miniatures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Miniatures.ToListAsync());
        }

        // GET: Miniatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniatures = await _context.Miniatures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniatures == null)
            {
                return NotFound();
            }

            return View(miniatures);
        }

        // GET: Miniatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Miniatures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TableReady,Description")] Miniatures miniatures)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miniatures);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miniatures);
        }

        // GET: Miniatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniatures = await _context.Miniatures.FindAsync(id);
            if (miniatures == null)
            {
                return NotFound();
            }
            return View(miniatures);
        }

        // POST: Miniatures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TableReady,Description")] Miniatures miniatures)
        {
            if (id != miniatures.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miniatures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiniaturesExists(miniatures.Id))
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
            return View(miniatures);
        }

        // GET: Miniatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniatures = await _context.Miniatures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniatures == null)
            {
                return NotFound();
            }

            return View(miniatures);
        }

        // POST: Miniatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miniatures = await _context.Miniatures.FindAsync(id);
            if (miniatures != null)
            {
                _context.Miniatures.Remove(miniatures);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiniaturesExists(int id)
        {
            return _context.Miniatures.Any(e => e.Id == id);
        }
    }
}
