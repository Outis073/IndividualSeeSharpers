using IndividualSeeSharpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndividualSeeSharpers.Controllers
{
    public class SpecialController : Controller

    {

    private readonly SeeSharpersContext _context;

    public SpecialController(SeeSharpersContext context)
    {
        _context = context;
    }

    // GET: Specials
    public async Task<IActionResult> Index()
    {
        var specials = _context.Specials.Where(s =>
            s.BeginDate < DateTime.Today && s.EndDate > (DateTime.Now));

        return View(await specials.ToListAsync());
    }

    // GET: Specials/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var special = await _context.Specials
            .FirstOrDefaultAsync(m => m.Id == id);
        if (special == null)
        {
            return NotFound();
        }

        return View(special);
    }

    // GET: Specials/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Specials/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,BeginDate,EndDate,Cost,Description")] Special special)
    {
        if (ModelState.IsValid)
        {
            _context.Add(special);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(special);
    }

    // GET: Specials/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var special = await _context.Specials.FindAsync(id);
        if (special == null)
        {
            return NotFound();
        }
        return View(special);
    }

    // POST: Specials/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BeginDate,EndDate,Cost,Description")] Special special)
    {
        if (id != special.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(special);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialExists(special.Id))
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
        return View(special);
    }

    // GET: Specials/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var special = await _context.Specials
            .FirstOrDefaultAsync(m => m.Id == id);
        if (special == null)
        {
            return NotFound();
        }

        return View(special);
    }

    // POST: Specials/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var special = await _context.Specials.FindAsync(id);
        _context.Specials.Remove(special);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SpecialExists(int id)
    {
        return _context.Specials.Any(e => e.Id == id);
    }
}
}
