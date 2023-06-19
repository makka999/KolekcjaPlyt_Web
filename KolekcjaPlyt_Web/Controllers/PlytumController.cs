using KolekcjaPlyt_Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KolekcjaPlyt_Web.Controllers
{
    public class PlytumController : Controller
    {
        private KolekcjaPlytContext db = new KolekcjaPlytContext();
        // GET: PlytumController
        public ActionResult Index()
        {
            return View(db.Plyta.ToList());
        }

        // GET: PlytumController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlytumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlytumController/Create
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

        // GET: PlytumController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlytumController/Edit/5
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

        // GET: PlytumController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlytumController/Delete/5
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
