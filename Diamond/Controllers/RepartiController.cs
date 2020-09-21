using Diamond.Data;
using Diamond.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Diamond.Controllers
{
    public class RepartiController : Controller
    {
        private readonly DiamondContext _context;

        public RepartiController(DiamondContext context)
        {
            _context = context;
        }

        // GET: reparti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reparto.ToListAsync());
        }

        // GET: reparti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparto = await _context.Reparto
                .FirstOrDefaultAsync(m => m.repartoId == id);
            if (reparto == null)
            {
                return NotFound();
            }

            return View(reparto);
        }

        // GET: reparti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: reparti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("repartoId,nome")] Reparto reparto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reparto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reparto);
        }

        // GET: reparti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparto = await _context.Reparto.FindAsync(id);
            if (reparto == null)
            {
                return NotFound();
            }
            return View(reparto);
        }

        // POST: reparti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("repartoId,nome")] Reparto reparto)
        {
            if (id != reparto.repartoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!repartoExists(reparto.repartoId))
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
            return View(reparto);
        }

        // GET: reparti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparto = await _context.Reparto
                .FirstOrDefaultAsync(m => m.repartoId == id);
            if (reparto == null)
            {
                return NotFound();
            }

            return View(reparto);
        }

        // POST: reparti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reparto = await _context.Reparto.FindAsync(id);
            _context.Reparto.Remove(reparto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool repartoExists(int id)
        {
            return _context.Reparto.Any(e => e.repartoId == id);
        }
    }
}
