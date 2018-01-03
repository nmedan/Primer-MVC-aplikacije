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
    public class FilmController : Controller
    {
        // GET: Film
        FilmContext db = new FilmContext();

        public ActionResult Index(int? page, int pageSize = 3)
        {
            
            ViewBag.Filmovi = db.Filmovi.Include(x=>x.Reziser).OrderBy(x=>x.Godina).ThenBy(x=>x.Ime).ToPagedList(page ?? 1, pageSize);
            ViewBag.Reziser = new SelectList(db.Reziseri, "Id", "PunoIme");
            return View();
        }

        [HttpPost]
        public ActionResult Index(Pretraga pretraga, int? page, int pageSize = 3)
        {
            ViewBag.Reziser = new SelectList(db.Reziseri, "Id", "PunoIme", pretraga.Reziser);
            if (pretraga.PocetnaGodina != null && pretraga.ZavrsnaGodina != null)
            {

                ViewBag.Filmovi = db.Filmovi.Include(x => x.Reziser).Where(x => x.Godina >= pretraga.PocetnaGodina && x.Godina <= pretraga.ZavrsnaGodina && (x.Reziser.Id == pretraga.Reziser || pretraga.Reziser == null)).OrderBy(x => x.Godina).ThenBy(x => x.Ime).ToPagedList(page ?? 1, pageSize);
            }
            else if (pretraga.PocetnaGodina != null)
            {
                ViewBag.Filmovi = db.Filmovi.Include(x => x.Reziser).Where(x => x.Godina >= pretraga.PocetnaGodina && (x.Reziser.Id == pretraga.Reziser || pretraga.Reziser == null)).OrderBy(x => x.Godina).ThenBy(x => x.Ime).ToPagedList(page ?? 1, pageSize);
            }
            else if (pretraga.ZavrsnaGodina != null)
            {
                ViewBag.Filmovi = db.Filmovi.Include(x => x.Reziser).Where(x => x.Godina <= pretraga.ZavrsnaGodina && (x.Reziser.Id == pretraga.Reziser || pretraga.Reziser == null)).OrderBy(x => x.Godina).ThenBy(x => x.Ime).ToPagedList(page ?? 1, pageSize);
            }
            else
            {
                ViewBag.Filmovi = db.Filmovi.Include(x => x.Reziser).Where(x => x.Reziser.Id == pretraga.Reziser || pretraga.Reziser == null).OrderBy(x => x.Godina).ThenBy(x => x.Ime).ToPagedList(page ?? 1, pageSize);
            }
            return View(pretraga);
        }

        public ActionResult Create()
        {
            ViewBag.Reziseri = new SelectList(db.Reziseri, "Id", "PunoIme");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                db.Filmovi.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index", "Film");
            }
            ViewBag.Reziseri = new SelectList(db.Reziseri, "Id", "PunoIme", film.ReziserId);
            return View(film);
        }

        public ActionResult Edit(int? id)
        {
            
            var film = db.Filmovi.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.Film = film.Ime;
            ViewBag.Reziseri = new SelectList(db.Reziseri, "Id", "PunoIme");
            return View(film);
        }

        [HttpPost]
        public ActionResult Edit(Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Film = film.Ime;
            ViewBag.Reziseri = new SelectList(db.Reziseri, "Id", "PunoIme", film.ReziserId);
            return View(film);
        }

        public ActionResult Delete(int? id)
        {
            var film = db.Filmovi.Find(id);
            if (film == null) {
                return HttpNotFound();
            }
            db.Filmovi.Remove(film);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}