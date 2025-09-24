using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebVendingMachines.Models;

namespace WebVendingMachines.Controllers
{
	public class VendingMachinesController : ApiController
    {
        private DB_VendingMachinesEntities db = new DB_VendingMachinesEntities();

        // GET: api/VendingMachines
        public IQueryable<VendingMachines> GetVendingMachines()
        {
            return db.VendingMachines;
        }

        // GET: api/VendingMachines/5
        [ResponseType(typeof(VendingMachines))]
        public IHttpActionResult GetVendingMachines(string id)
        {
            VendingMachines vendingMachines = db.VendingMachines.Find(id);
            if (vendingMachines == null)
            {
                return NotFound();
            }

            return Ok(vendingMachines);
        }

        // PUT: api/VendingMachines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendingMachines(string id, VendingMachines vendingMachines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendingMachines.id)
            {
                return BadRequest();
            }

            db.Entry(vendingMachines).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendingMachinesExists(id))
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

        // POST: api/VendingMachines
        [ResponseType(typeof(VendingMachines))]
        public IHttpActionResult PostVendingMachines(VendingMachines vendingMachines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VendingMachines.Add(vendingMachines);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VendingMachinesExists(vendingMachines.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vendingMachines.id }, vendingMachines);
        }

        // DELETE: api/VendingMachines/5
        [ResponseType(typeof(VendingMachines))]
        public IHttpActionResult DeleteVendingMachines(string id)
        {
            VendingMachines vendingMachines = db.VendingMachines.Find(id);
            if (vendingMachines == null)
            {
                return NotFound();
            }

            db.VendingMachines.Remove(vendingMachines);
            db.SaveChanges();

            return Ok(vendingMachines);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendingMachinesExists(string id)
        {
            return db.VendingMachines.Count(e => e.id == id) > 0;
        }
    }
}