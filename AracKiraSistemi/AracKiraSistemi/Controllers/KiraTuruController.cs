using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AracKiraSistemi.Entities.Model;

namespace AracKiraSistemi.Controllers
{
    public class KiraTuruController : Controller
    {
        AracKiraContext db = new AracKiraContext();

        // GET: LeaseType
        public ActionResult Index()
        {
            return View(db.KiraTuru.ToList());
        }

        // GET: LeaseType/Create
        
        public ActionResult Create()
        {
            return View(new KiraTuru());
        }

        // POST: LeaseType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KiraTuruId,DailyPrice,WeeklyPrice,MonthlyPrice")] KiraTuru leaseType)
        {
            if (ModelState.IsValid)
            {
                db.KiraTuru.Add(leaseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leaseType);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            KiraTuru kiraTuru = db.KiraTuru.Find(id);
            return View(kiraTuru);
        }

        [HttpPost]
        public ActionResult Edit(KiraTuru pKiraTuru)
        {
            KiraTuru kiraTuru = db.KiraTuru.Find(pKiraTuru.KiraTuruId);
            kiraTuru.DailyPrice = pKiraTuru.DailyPrice;
            kiraTuru.WeeklyPrice = pKiraTuru.WeeklyPrice;
            kiraTuru.MonthlyPrice = pKiraTuru.MonthlyPrice;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: LeaseType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KiraTuru leaseType = db.KiraTuru.Find(id);
            if (leaseType == null)
            {
                return HttpNotFound();
            }
            return View(leaseType);
        }

        // POST: LeaseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KiraTuru leaseType = db.KiraTuru.Find(id);
            db.KiraTuru.Remove(leaseType);
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