using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KolekcjaPlyt_Web.Controllers
{
    public class UtworController1 : Controller
    {
        // GET: UtworController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: UtworController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UtworController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtworController1/Create
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

        // GET: UtworController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UtworController1/Edit/5
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

        // GET: UtworController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UtworController1/Delete/5
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
