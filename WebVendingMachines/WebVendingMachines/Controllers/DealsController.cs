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
    public class DealsController : ApiController
    {
        private DB_VendingMachinesEntities db = new DB_VendingMachinesEntities();

        // GET: api/Deals
        public IQueryable<Deals> GetDeals()
        {
            return db.Deals;
        }

        // GET: api/Deals/5
        [ResponseType(typeof(Deals))]
        public IHttpActionResult GetDeals(int id)
        {
            Deals deals = db.Deals.Find(id);
            if (deals == null)
            {
                return NotFound();
            }

            return Ok(deals);
        }

        // PUT: api/Deals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeals(int id, Deals deals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deals.id)
            {
                return BadRequest();
            }

            db.Entry(deals).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealsExists(id))
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

        // POST: api/Deals
        [ResponseType(typeof(Deals))]
        public IHttpActionResult PostDeals(Deals deals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deals.Add(deals);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deals.id }, deals);
        }

        // DELETE: api/Deals/5
        [ResponseType(typeof(Deals))]
        public IHttpActionResult DeleteDeals(int id)
        {
            Deals deals = db.Deals.Find(id);
            if (deals == null)
            {
                return NotFound();
            }

            db.Deals.Remove(deals);
            db.SaveChanges();

            return Ok(deals);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DealsExists(int id)
        {
            return db.Deals.Count(e => e.id == id) > 0;
        }
    }
}