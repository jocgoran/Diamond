using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diamond.Controllers
{
    public class ProdottoController : Controller
    {
        // GET: ProdottoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProdottoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdottoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdottoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdottoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdottoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdottoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdottoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
