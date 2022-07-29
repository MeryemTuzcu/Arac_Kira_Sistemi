using AracKiraSistemi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AracKiraSistemi.Controllers.Api
{
    public class ArabaController : ApiController
    {
        private AracKiraContext db;
        public ArabaController()
        {
            db = new AracKiraContext();
        }
        [HttpGet]

        public IHttpActionResult GetAraba()
        {
            var araba = db.Araba.ToList();

            return Ok(araba);
        }

        
        [HttpGet]
        public IHttpActionResult GetAraba(int id)
        {
            var araba = db.Araba.SingleOrDefault(x => x.ArabaId == id);
            if (araba == null)
                return NotFound();
            return Ok(araba);
        }

        [HttpPost]
        public IHttpActionResult AddAraba(Araba pAraba)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Araba.Add(pAraba);
            db.SaveChanges();
            return Ok(pAraba);
        }

        [HttpPut]
        public IHttpActionResult UpdateAraba(int id, Araba pAraba)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var araba = db.Araba.SingleOrDefault(x => x.ArabaId == id);
            if (araba == null)
                return NotFound();

            araba.ArabaId = pAraba.ArabaId;
            araba.Name = pAraba.Name;
            araba.Model = pAraba.Model;
            araba.Branch = pAraba.Branch;
            araba.Year = pAraba.Year;
            araba.Km = pAraba.Km;
            araba.LeaseTypeId = pAraba.LeaseTypeId;


            db.SaveChanges();

            return Ok(araba);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAraba(int id)
        {
            var araba = db.Araba.SingleOrDefault(x => x.ArabaId == id);
            if (araba == null)
                return NotFound();

            db.Araba.Remove(araba);
            db.SaveChanges();

            return Ok();
        }



    }
}
