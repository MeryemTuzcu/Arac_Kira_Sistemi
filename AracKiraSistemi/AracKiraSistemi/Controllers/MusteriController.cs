using AracKiraSistemi.Entities.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProductManager.Controllers
{
    public class MusteriController : Controller
    {
        AracKiraContext db = new AracKiraContext();
        [HttpGet]
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Musteri.ToList());
        }
        [HttpGet]
        // GET: Customer/Create
        public ActionResult Create()
        {
            return View(new Musteri());
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusteriId,FirstName,LastName,BornDate,Gender,MusteriKAdi,MusteriParola,MusteriEmail")] Musteri customer)
        {
            if (ModelState.IsValid)
            {
                db.Musteri.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            Musteri musteri = db.Musteri.Find(id);
            
            return View(musteri);
        }

        [HttpPost]
        public ActionResult Edit(Musteri pMusteri)
        {
            Musteri musteri = db.Musteri.Find(pMusteri.MusteriId);
            musteri.FirstName = pMusteri.FirstName;
            musteri.LastName = pMusteri.LastName;
            musteri.BornDate = pMusteri.BornDate;
            musteri.Gender = pMusteri.Gender;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri customer = db.Musteri.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteri customer = db.Musteri.Find(id);
            db.Musteri.Remove(customer);
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
