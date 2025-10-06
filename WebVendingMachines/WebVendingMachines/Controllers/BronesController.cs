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
using WebVendingMachines.Models;

namespace WebVendingMachines.Controllers
{
    public class BronesController : ApiController
    {
        private DB_VendingMachinesEntities db = new DB_VendingMachinesEntities();

        // GET: api/Brones
        public IQueryable<Brones> GetBrones()
        {
            return db.Brones;
        }

        // GET: api/Brones/5
        [ResponseType(typeof(Brones))]
        public IHttpActionResult GetBrones(int id)
        {
            Brones brones = db.Brones.Find(id);
            if (brones == null)
            {
                return NotFound();
            }

            return Ok(brones);
        }

        // PUT: api/Brones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBrones(int id, Brones brones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brones.id)
            {
                return BadRequest();
            }

            db.Entry(brones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BronesExists(id))
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

        // POST: api/Brones
        [ResponseType(typeof(Brones))]
        public IHttpActionResult PostBrones(Brones brones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brones.Add(brones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brones.id }, brones);
        }

        // DELETE: api/Brones/5
        [ResponseType(typeof(Brones))]
        public IHttpActionResult DeleteBrones(int id)
        {
            Brones brones = db.Brones.Find(id);
            if (brones == null)
            {
                return NotFound();
            }

            db.Brones.Remove(brones);
            db.SaveChanges();

            return Ok(brones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BronesExists(int id)
        {
            return db.Brones.Count(e => e.id == id) > 0;
        }
    }
}