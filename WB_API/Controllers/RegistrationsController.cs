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
    public class RegistrationsController : ApiController
    {
        private CharityMobileEntities db = new CharityMobileEntities();

        // GET: api/Registrations
        [ResponseType(typeof(List<ResponseRegistration>))]
        public IHttpActionResult GetRegistration()
        {
            var responseRegistrations = db.Registration.ToList().ConvertAll(p => new ResponseRegistration(p));
            return Ok(responseRegistrations);
        }

        /*
                [Route("api/getRegistrationС")]
                public IHttpActionResult GetRegistrationС(int registId)
                {
                    var regist = db.Registration.ToList().Where(p => p.RegistrationId == registId).ToList();
                    return Ok(regist);
                }*/


        // GET: api/Registrations/5
        [ResponseType(typeof(Registration))]
        public IHttpActionResult GetRegistration(int id)
        {
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return NotFound();
            }

            return Ok(registration);
        }

        // PUT: api/Registrations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistration(int id, Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registration.RegistrationId)
            {
                return BadRequest();
            }

            db.Entry(registration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(id))
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

        // POST: api/Registrations
        [ResponseType(typeof(Registration))]
        public IHttpActionResult PostRegistration(Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Registration.Add(registration);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registration.RegistrationId }, registration);
        }

        // DELETE: api/Registrations/5
        [ResponseType(typeof(Registration))]
        public IHttpActionResult DeleteRegistration(int id)
        {
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return NotFound();
            }

            db.Registration.Remove(registration);
            db.SaveChanges();

            return Ok(registration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistrationExists(int id)
        {
            return db.Registration.Count(e => e.RegistrationId == id) > 0;
        }
    }
}