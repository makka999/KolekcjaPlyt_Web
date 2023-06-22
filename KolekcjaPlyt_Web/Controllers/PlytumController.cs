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
            var utwory = db.Utwors.ToList();
            
            var wyszukaneUtwory = utwory.FindAll(u => u.IdPlyta == id);
            var utworList = new List<Utwor> { };

            foreach (var item in wyszukaneUtwory) {
                utworList.Add(item);
                }
            return View(utworList);
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
            //var formContent = collection.ToList();
            var dataNabycia = collection["DataNabycia"];
            var cena = collection["Cena"];
            var nazwa = collection["Nazwa"];
            var rodzajPlyty = collection["RodzajPlyty"];


            var addNabycie = new Nabycie
            {
                Cena = Convert.ToDecimal(cena),
                DataNabycia = Convert.ToDateTime(dataNabycia)
            };

            db.Nabycies.Add(addNabycie);
            db.SaveChanges();

            var addPlyta = new Plytum
            {
                Nazwa = nazwa,
                RodzajPlyty = rodzajPlyty,
                Komentarz = null,
                StatusPosiadania = "Add by Web",
                IdNabycie = addNabycie.IdNabycie

            };

            db.Plyta.Add(addPlyta);
            db.SaveChanges();


            return View();

        }

        // GET: PlytumController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(db.Plyta.Find(id));
        }

        // POST: PlytumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {

                var nazwa = collection["Nazwa"];
                var rodzajPlyty = collection["RodzajPlyty"];
                var komentarz = collection["Komentarz"];
                Plytum modPlyta = db.Plyta.Find(id);

                modPlyta.Komentarz = komentarz;
            modPlyta.StatusPosiadania = "Mod by Web";
            modPlyta.Nazwa = nazwa;
            modPlyta.RodzajPlyty = rodzajPlyty;

                db.Plyta.Update(modPlyta);
                db.SaveChanges();

            return View();

        }

        // GET: PlytumController/Delete/5
        public ActionResult Delete(int id)
        {
            Plytum plyta = db.Plyta.Find(id);
            return View(plyta);
        }

        // POST: PlytumController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            //try
            //{
                Plytum plyta = db.Plyta.Find(id);
                db.Plyta.Remove(plyta);
                db.SaveChanges();


                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
