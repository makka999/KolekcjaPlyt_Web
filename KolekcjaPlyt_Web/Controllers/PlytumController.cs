﻿using KolekcjaPlyt_Web.Models;
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


            return View(Index);

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
