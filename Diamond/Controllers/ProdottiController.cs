using Diamond.Data;
using Diamond.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Diamond.Controllers
{
    public class ProdottiController : Controller
    {
        private readonly DiamondContext _context;

        public ProdottiController(DiamondContext context)
        {
            _context = context;
        }

        // GET: Prodotti
        [Route("Prodotti")]
        public async Task<IActionResult> Index(string searchString, int page = 0)
        {
            var pageSize = 8;
            var totalPosts = _context.Prodotto.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var prodotti = from p in _context.Prodotto
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                prodotti = prodotti.Where(p => p.nome.Contains(searchString));
            }

            prodotti = prodotti.OrderBy(p => p.nome)
                               .Skip(pageSize * page)
                               .Take(pageSize);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(prodotti.ToArray());

            //            var prodotti = await _context.Prodotto.OrderBy(x => x.nome).Take(10).ToListAsync();
            return View(await prodotti.AsNoTracking().ToListAsync());
        }

        // GET: Prodotti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // GET: Prodotti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prodotti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome,prezzo,quantita")] Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodotto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prodotto);
        }

        // GET: Prodotti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotto.FindAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }

        // POST: Prodotti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome,prezzo,quantita")] Prodotto prodotto)
        {
            if (id != prodotto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodotto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdottoExists(prodotto.ID))
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
            return View(prodotto);
        }

        // GET: Prodotti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // POST: Prodotti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodotto = await _context.Prodotto.FindAsync(id);
            _context.Prodotto.Remove(prodotto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdottoExists(int id)
        {
            return _context.Prodotto.Any(e => e.ID == id);
        }
    }
}
