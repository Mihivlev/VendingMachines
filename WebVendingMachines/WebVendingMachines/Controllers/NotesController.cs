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
    public class NotesController : ApiController
    {
        private DB_VendingMachinesEntities db = new DB_VendingMachinesEntities();

        // GET: api/Notes
        public IQueryable<Notes> GetNotes()
        {
            return db.Notes;
        }

        // GET: api/Notes/5
        [ResponseType(typeof(Notes))]
        public IHttpActionResult GetNotes(int id)
        {
            Notes notes = db.Notes.Find(id);
            if (notes == null)
            {
                return NotFound();
            }

            return Ok(notes);
        }

        // PUT: api/Notes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNotes(int id, Notes notes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notes.id)
            {
                return BadRequest();
            }

            db.Entry(notes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesExists(id))
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

        // POST: api/Notes
        [ResponseType(typeof(Notes))]
        public IHttpActionResult PostNotes(Notes notes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notes.Add(notes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = notes.id }, notes);
        }

        // DELETE: api/Notes/5
        [ResponseType(typeof(Notes))]
        public IHttpActionResult DeleteNotes(int id)
        {
            Notes notes = db.Notes.Find(id);
            if (notes == null)
            {
                return NotFound();
            }

            db.Notes.Remove(notes);
            db.SaveChanges();

            return Ok(notes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotesExists(int id)
        {
            return db.Notes.Count(e => e.id == id) > 0;
        }
    }
}