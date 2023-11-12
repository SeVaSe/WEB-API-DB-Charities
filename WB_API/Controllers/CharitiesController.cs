using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WB_API;
using WB_API.Models;

namespace WB_API.Controllers
{
    public class CharitiesController : ApiController
    {
        private CharityMobileEntities db = new CharityMobileEntities();

        // GET: api/Charities
        [ResponseType(typeof(List<ResponseCharity>))]
        public IHttpActionResult GetCharity()
        {
            return Ok(db.Charity.ToList().ConvertAll(p => new ResponseCharity(p)));
        }

        // GET: api/Charities/5
        [ResponseType(typeof(Charity))]
        public IHttpActionResult GetCharity(int id)
        {
            Charity charity = db.Charity.Find(id);
            if (charity == null)
            {
                return NotFound();
            }

            return Ok(charity);
        }

        // PUT: api/Charities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCharity(int id, Charity charity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != charity.CharityId)
            {
                return BadRequest();
            }

            db.Entry(charity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Charities
        [ResponseType(typeof(Charity))]
        public IHttpActionResult PostCharity(Charity charity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Charity.Add(charity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = charity.CharityId }, charity);
        }

        // DELETE: api/Charities/5
        [ResponseType(typeof(Charity))]
        public IHttpActionResult DeleteCharity(int id)
        {
            Charity charity = db.Charity.Find(id);
            if (charity == null)
            {
                return NotFound();
            }

            db.Charity.Remove(charity);
            db.SaveChanges();

            return Ok(charity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharityExists(int id)
        {
            return db.Charity.Count(e => e.CharityId == id) > 0;
        }
    }
}