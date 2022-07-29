using AracKiraSistemi.Entities.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProductManager.Controllers
{
    public class ArabaController : Controller
    {
        AracKiraContext db = new AracKiraContext();

        // GET: Car
        public ActionResult Index()
        {
            var araba = db.Araba.Include(c => c.KiraTuru);
            return View(araba.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> kiraTuru = db.KiraTuru.AsNoTracking()
                .Select(s => new SelectListItem
                {
                    Value = s.KiraTuruId.ToString(),
                    Text = s.KiraTuruId.ToString()                 
                }).ToList();

            ViewBag.kiraTuru = kiraTuru;
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArabaId,Name,Model,Branch,Year,Km,LeaseTypeId")] Araba car)
        {
            if (ModelState.IsValid)
            {
                db.Araba.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeaseTypeId = new SelectList(db.KiraTuru, "Id", "Id", car.LeaseTypeId);
            return View(car);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Araba araba = db.Araba.Find(id);
            List<SelectListItem> KiraTuru = db.KiraTuru.AsNoTracking()
               .Select(s => new SelectListItem
               {
                   Value = s.KiraTuruId.ToString(),
                   Text = s.KiraTuruId.ToString()
               }).ToList();

            ViewBag.KiraTuru = KiraTuru;
            return View(araba);
        }

        [HttpPost]
        public ActionResult Edit(Araba paraba)
        {
            Araba araba = db.Araba.Find(paraba.ArabaId);
            araba.Name = paraba.Name;
            araba.Model = paraba.Model;
            araba.Branch = paraba.Branch;
            araba.Year = paraba.Year;
            araba.Km = paraba.Km;
            araba.LeaseTypeId = paraba.LeaseTypeId;
            araba.KiraTuru = db.KiraTuru.Where(x => x.KiraTuruId == paraba.LeaseTypeId).FirstOrDefault();
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba car = db.Araba.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Araba car = db.Araba.Find(id);
            db.Araba.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
