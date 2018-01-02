using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmCollection.Models;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
namespace FilmCollection.Controllers
{
    public class ReziserController : Controller
    {
        // GET: Reziser
        FilmContext db = new FilmContext();

        public ActionResult Index(int? page, int pageSize = 3)
        {
            var reziseri = db.Reziseri.OrderBy(x => x.Prezime).ThenBy(x => x.Ime).ToPagedList(page ?? 1, pageSize);
            return View(reziseri);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Reziser reziser)
        {
            if (ModelState.IsValid)
            {
                db.Reziseri.Add(reziser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View(reziser);
        }

        public ActionResult Edit(int? id)
        {
            var reziser = db.Reziseri.Find(id);
            if (reziser == null)
            {
                return HttpNotFound();
            }
            ViewBag.Reziser = reziser.Ime + " " + reziser.Prezime;
            return View(reziser);
        }

        [HttpPost]
        public ActionResult Edit(Reziser reziser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reziser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reziser);
        }

        public ActionResult Delete(int? id)
        {
            var reziser = db.Reziseri.Find(id);
            if (reziser == null)
            {
                return HttpNotFound();
            }
            db.Reziseri.Remove(reziser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}