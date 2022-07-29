using AracKiraSistemi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AracKiraSistemi.Controllers.Api
{
    public class MusteriController : ApiController
    {
        private AracKiraContext db;
        public MusteriController()
        {
            db = new AracKiraContext();
        }
        [HttpGet]

        public IHttpActionResult GetMusteri()
        {
            var musteris = db.Musteri.ToList();

            return Ok(musteris);
        }

        //parametreli Listeleme
        [HttpGet]
        public IHttpActionResult GetMusteri(int id)
        {
            var musteri = db.Musteri.SingleOrDefault(x => x.MusteriId == id);
            if (musteri == null)
                return NotFound();
            return Ok(musteri);
        }

        [HttpPost]
        public IHttpActionResult AddMusteri(Musteri pMusteri)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Musteri.Add(pMusteri);
            db.SaveChanges();
            return Ok(pMusteri);
        }

        [HttpPut]
        public IHttpActionResult UpdateMusteri(int id, Musteri pMusteri)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var musteri = db.Musteri.SingleOrDefault(x => x.MusteriId == id);
            if (musteri == null)
                return NotFound();
            
            musteri.FirstName = pMusteri.FirstName;
            musteri.LastName = pMusteri.LastName;
            musteri.BornDate = pMusteri.BornDate;
            musteri.Gender = pMusteri.Gender;
            musteri.MusteriEmail = pMusteri.MusteriEmail;
            
            db.SaveChanges();

            return Ok(musteri);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMusteri(int id)
        {
            var musteri= db.Musteri.SingleOrDefault(x => x.MusteriId == id);
            if (musteri == null)
                return NotFound();

            db.Musteri.Remove(musteri);
            db.SaveChanges();

            return Ok();
        }



    }
}
