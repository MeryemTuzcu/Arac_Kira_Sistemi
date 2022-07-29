using AracKiraSistemi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AracKiraSistemi.Controllers.Api
{
    public class SepetController : ApiController
    {
        private AracKiraContext db;
        public SepetController()
        {
            db = new AracKiraContext();
        }
        [HttpGet]

        public IHttpActionResult GetSepets()
        {
            var sepets = db.Sepet.ToList();

            return Ok(sepets);
        }


        [HttpGet]
        public IHttpActionResult GetSepet(int id)
        {
            var sepet = db.Sepet.SingleOrDefault(x => x.SepetId == id);
            if (sepet == null)
                return NotFound();
            return Ok(sepet);
        }

        [HttpPost]
        public IHttpActionResult AddSepet(Sepet pSepet)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Sepet.Add(pSepet);
            db.SaveChanges();
            return Ok(pSepet);
        }

        [HttpPut]
        public IHttpActionResult UpdatepSepet(int id, Sepet pSepet)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sepet = db.Sepet.SingleOrDefault(x => x.SepetId == id);
            if (sepet == null)
                return NotFound();
            sepet.SepetId = pSepet.SepetId;
            sepet.Musteri.MusteriId = pSepet.Musteri.MusteriId;
            sepet.Araba.ArabaId = pSepet.Araba.ArabaId;
            sepet.PurchaseDate = pSepet.PurchaseDate;
            sepet.DeliveryDate = pSepet.DeliveryDate;
            sepet.TotalPrice = pSepet.TotalPrice;    
            
            db.SaveChanges();

            return Ok(sepet);
        }

        [HttpDelete]
        public IHttpActionResult DeletepSepet(int id)
        {
            var sepet = db.Sepet.SingleOrDefault(x => x.SepetId == id);
            if (sepet == null)
                return NotFound();

            db.Sepet.Remove(sepet);
            db.SaveChanges();

            return Ok();
        }



    }
}
