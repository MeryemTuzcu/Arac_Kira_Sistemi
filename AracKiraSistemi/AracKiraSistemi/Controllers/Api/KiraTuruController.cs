using AracKiraSistemi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AracKiraSistemi.Controllers.Api
{
    public class KiraTuruController : ApiController
    {
        private AracKiraContext db;
        public KiraTuruController()
        {
            db = new AracKiraContext();
        }
          [HttpGet]

        public IHttpActionResult GetKiraTuru()
        {
            var kiraturu = db.KiraTuru.ToList();

            return Ok(kiraturu);
        }

        //api/kategori/1
        [HttpGet]
        public IHttpActionResult GetKiraTuru(int id)
        {
            var kiraturu = db.KiraTuru.SingleOrDefault(x => x.KiraTuruId == id);
            if (kiraturu == null)
                return NotFound();
            return Ok(kiraturu);
        }

        [HttpPost]
        public IHttpActionResult AddKiraTuru(KiraTuru pkiraturu)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.KiraTuru.Add(pkiraturu);
                db.SaveChanges();
            return Ok(pkiraturu);
        }

        [HttpPut]
        public IHttpActionResult UpdateKiraTuru(int id , KiraTuru pkiraturu)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var kiraturu = db.KiraTuru.SingleOrDefault(x=>x.KiraTuruId == id);
            if (kiraturu == null)
                return NotFound();

            kiraturu.KiraTuruId = pkiraturu.KiraTuruId;
            kiraturu.DailyPrice = pkiraturu.DailyPrice;
            kiraturu.WeeklyPrice = pkiraturu.WeeklyPrice;
            kiraturu.MonthlyPrice = pkiraturu.MonthlyPrice;
            db.SaveChanges();

            return Ok(kiraturu);
        }  

        [HttpDelete]
        public IHttpActionResult DeleteKiraTuru(int id)
        {
            var kiraturu = db.KiraTuru.SingleOrDefault(x=>x.KiraTuruId == id);
            if (kiraturu == null)
                return NotFound();
            db.KiraTuru.Remove(kiraturu);
            db.SaveChanges();

            return Ok();
        }
        

        
    }
}
