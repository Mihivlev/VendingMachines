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
    public class MaintenancesController : ApiController
    {
        private DB_VendingMachinesEntities db = new DB_VendingMachinesEntities();

        // GET: api/Maintenances
        public IQueryable<Maintenance> GetMaintenance()
        {
            return db.Maintenance;
        }

        // GET: api/Maintenances/5
        [ResponseType(typeof(Maintenance))]
        public IHttpActionResult GetMaintenance(int id)
        {
            Maintenance maintenance = db.Maintenance.Find(id);
            if (maintenance == null)
            {
                return NotFound();
            }

            return Ok(maintenance);
        }

        // PUT: api/Maintenances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaintenance(int id, Maintenance maintenance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maintenance.id)
            {
                return BadRequest();
            }

            db.Entry(maintenance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceExists(id))
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

        // POST: api/Maintenances
        [ResponseType(typeof(Maintenance))]
        public IHttpActionResult PostMaintenance(Maintenance maintenance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Maintenance.Add(maintenance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = maintenance.id }, maintenance);
        }

        // DELETE: api/Maintenances/5
        [ResponseType(typeof(Maintenance))]
        public IHttpActionResult DeleteMaintenance(int id)
        {
            Maintenance maintenance = db.Maintenance.Find(id);
            if (maintenance == null)
            {
                return NotFound();
            }

            db.Maintenance.Remove(maintenance);
            db.SaveChanges();

            return Ok(maintenance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaintenanceExists(int id)
        {
            return db.Maintenance.Count(e => e.id == id) > 0;
        }
    }
}