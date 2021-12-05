using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFinaces.Data;
using MyFinaces.Models;

namespace MyFinaces.Controllers
{
    [Authorize]
    public class MovToFinController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovToFinController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovToFin
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovToFin.ToListAsync());
        }

        // GET: MovToFin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movToFin = await _context.MovToFin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movToFin == null)
            {
                return NotFound();
            }

            return View(movToFin);
        }

        // GET: MovToFin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovToFin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Description,DataMovto,DataLastUpdate,User")] MovToFin movToFin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movToFin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movToFin);
        }

        // GET: MovToFin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movToFin = await _context.MovToFin.FindAsync(id);
            if (movToFin == null)
            {
                return NotFound();
            }
            return View(movToFin);
        }

        // POST: MovToFin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Description,DataMovto,DataLastUpdate,User")] MovToFin movToFin)
        {
            if (id != movToFin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movToFin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovToFinExists(movToFin.Id))
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
            return View(movToFin);
        }

        // GET: MovToFin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movToFin = await _context.MovToFin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movToFin == null)
            {
                return NotFound();
            }

            return View(movToFin);
        }

        // POST: MovToFin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movToFin = await _context.MovToFin.FindAsync(id);
            _context.MovToFin.Remove(movToFin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovToFinExists(int id)
        {
            return _context.MovToFin.Any(e => e.Id == id);
        }
    }
}
