#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndividualSeeSharpers.Models;

namespace IndividualSeeSharpers.Controllers
{
    public class TheatreController : Controller
    {
        private readonly SeeSharpersContext _context;

        public TheatreController(SeeSharpersContext context)
        {
            _context = context;
        }

        // GET: Theatre
        public async Task<IActionResult> Index()
        {
            return View(await _context.Theatres.ToListAsync());
        }

        // GET: Theatre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatre = await _context.Theatres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (theatre == null)
            {
                return NotFound();
            }

            return View(theatre);
        }

        // GET: Theatre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Theatre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,AmountOfRows,AmountOfSeats")] Theatre theatre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theatre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theatre);
        }

        // GET: Theatre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatre = await _context.Theatres.FindAsync(id);
            if (theatre == null)
            {
                return NotFound();
            }
            return View(theatre);
        }

        // POST: Theatre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,AmountOfRows,AmountOfSeats")] Theatre theatre)
        {
            if (id != theatre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theatre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheatreExists(theatre.Id))
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
            return View(theatre);
        }

        // GET: Theatre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatre = await _context.Theatres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (theatre == null)
            {
                return NotFound();
            }

            return View(theatre);
        }

        // POST: Theatre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theatre = await _context.Theatres.FindAsync(id);
            _context.Theatres.Remove(theatre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheatreExists(int id)
        {
            return _context.Theatres.Any(e => e.Id == id);
        }
    }
}
