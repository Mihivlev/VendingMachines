using Microsoft.Ajax.Utilities;
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
    public class UsersController : ApiController
    {
        private DB_VendingMachinesEntities db = new DB_VendingMachinesEntities();

        // GET: api/Users
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(string id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

		// GET: api/Users/
        [Route("api/User/{email}/{password}")]
		public IHttpActionResult GetUser(string email, string password)
		{
            Users user = db.Users.ToList().FirstOrDefault(x => x.email == email && x.password == password);
            if (user != null)
                return Ok(user);
			return NotFound();
		}

		// GET: api/Users/
		[Route("api/Users/{id}/Notes")]
		public IHttpActionResult GetNotes(string id)
		{
			Users user = db.Users.Find(id);
			if (user != null)
				return Ok(user.Notes);
			return NotFound();
		}

		// GET: api/Users/
		[Route("api/Users/{id}/Maintenance")]
		public IHttpActionResult GetMaintenance(string id)
		{
			Users user = db.Users.Find(id);
			if (user != null)
				return Ok(user.Maintenance);
			return NotFound();
		}

		// PUT: api/Users/5
		[ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(string id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.id)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsersExists(users.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = users.id }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(string id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(string id)
        {
            return db.Users.Count(e => e.id == id) > 0;
        }
    }
}