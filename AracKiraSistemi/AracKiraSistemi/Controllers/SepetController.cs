using AracKiraSistemi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AracKiraSistemi.Controllers
{
    public class SepetController : Controller
    {
        AracKiraContext db = new AracKiraContext();

        public ActionResult Index()
        {
            var basket = db.Sepet.Include(b => b.Araba).Include(b => b.Musteri);
            return View(basket.ToList());
        }

        // GET: Basket/Create
        public ActionResult Create()
        {
            List<SelectListItem> arabaId = db.Araba.AsNoTracking()
                               .Select(s => new SelectListItem
                               {
                                   Value = s.ArabaId.ToString(),
                                   Text = s.Name
                               }).ToList();

            List<SelectListItem> musteriId = db.Musteri.AsNoTracking()
                .Select(s => new SelectListItem
                {
                    Value = s.MusteriId.ToString(),
                    Text = s.FirstName
                }).ToList();
            ViewBag.MusteriId = musteriId;
            ViewBag.ArabaId = arabaId;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SepetId,CustomerId,CarId,PurchaseDate,DeliveryDate,TotalPrice")] Sepet basket)
        {
            if (ModelState.IsValid)
            {
                var car = db.Araba.Include(x => x.KiraTuru).First(x => x.ArabaId == basket.CarId);
                if ((basket.DeliveryDate - basket.PurchaseDate).TotalDays <= 1)
                    basket.TotalPrice = car.KiraTuru.WeeklyPrice;
                else if ((basket.DeliveryDate - basket.PurchaseDate).TotalDays <= 7)
                    basket.TotalPrice = car.KiraTuru.WeeklyPrice;
                else
                    basket.TotalPrice = car.KiraTuru.MonthlyPrice;

                db.Sepet.Add(basket);
                db.SaveChanges();
                return RedirectToAction("Index");

                

            }
            List<SelectListItem> arabaId = db.Araba.AsNoTracking()
                                   .Select(s => new SelectListItem
                                   {
                                       Value = s.ArabaId.ToString(),
                                       Text = s.Name
                                   }).ToList();

            List<SelectListItem> musteriId = db.Musteri.AsNoTracking()
                .Select(s => new SelectListItem
                {
                    Value = s.MusteriId.ToString(),
                    Text = s.FirstName
                }).ToList();

            ViewBag.MusteriId = musteriId;
            ViewBag.ArabaId = arabaId;
            return View();



        }
        /*[HttpPost]
        public ActionResult Create(Sepet pSepet)
        {
            Araba urun = db.Araba.Where(x => x.ArabaId == pSepet.CarId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                
                List<SelectListItem> arabaId = db.Araba.AsNoTracking()
                               .Select(s => new SelectListItem
                               {
                                   Value = s.ArabaId.ToString(),
                                   Text = s.Name
                               }).ToList();

                List<SelectListItem> musteriId = db.Musteri.AsNoTracking()
                    .Select(s => new SelectListItem
                    {
                        Value = s.MusteriId.ToString(),
                        Text = s.FirstName
                    }).ToList();

                ViewBag.MusteriId = musteriId;
                ViewBag.ArabaId = arabaId;
                return View();
            }

   
            var car = db.Araba.Include(x => x.KiraTuru).First(x => x.ArabaId == pSepet.CarId);
            if ((pSepet.DeliveryDate - pSepet.PurchaseDate).TotalDays <= 1)
                pSepet.TotalPrice = car.KiraTuru.WeeklyPrice;
            else if ((pSepet.DeliveryDate - pSepet.PurchaseDate).TotalDays <= 7)
                pSepet.TotalPrice = car.KiraTuru.WeeklyPrice;
            else
                pSepet.TotalPrice = car.KiraTuru.MonthlyPrice;

            db.Sepet.Add(pSepet);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }*/

        // GET: Basket/Edit/5     
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet basket = db.Sepet.Find(id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> araba = db.Araba.AsNoTracking()
                              .Select(s => new SelectListItem
                              {
                                  Value = s.ArabaId.ToString(),
                                  Text = s.Name
                              }).ToList();

            List<SelectListItem> musteri = db.Musteri.AsNoTracking()
                .Select(s => new SelectListItem
                {
                    Value = s.MusteriId.ToString(),
                    Text = s.FirstName
                }).ToList();

            ViewBag.Musteri = musteri;
            ViewBag.Araba = araba;
            return View(basket);
        }

        // POST: Basket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SepetId,CustomerId,CarId,PurchaseDate,DeliveryDate,TotalPrice")]int id, Sepet basket)
        {
       
                if (ModelState.IsValid)
                {

                var basketItem = db.Sepet.SingleOrDefault(x => x.SepetId == id);                
                basketItem.CustomerId = basket.CustomerId;
                basketItem.CarId = basket.CarId;
                basketItem.DeliveryDate = basket.DeliveryDate;
                basketItem.PurchaseDate = basket.PurchaseDate;
                basketItem.TotalPrice = basket.TotalPrice;
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        // GET: Basket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet basket = db.Sepet.Find(id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            return View(basket);
        }

        // POST: Basket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sepet basket = db.Sepet.Find(id);
            db.Sepet.Remove(basket);
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
