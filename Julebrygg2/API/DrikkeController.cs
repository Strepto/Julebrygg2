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
using Julebrygg2.DAL;
using Julebrygg2.Models;
using System.Web.Http.Cors;

namespace Julebrygg2.API
{

    // Allow CORS for all origins. (Caution!)
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DrikkeController : ApiController
    {
        private Julebrygg2Context db = new Julebrygg2Context();

        // GET: api/Drikke
        public IQueryable<Drikke> GetDrikke()
        {
            return db.Drikke;
        }

        // GET: api/Drikke/5
        [ResponseType(typeof(Drikke))]
        public IHttpActionResult GetDrikke(int id)
        {
            Drikke drikke = db.Drikke.Find(id);
            if (drikke == null)
            {
                return NotFound();
            }

            return Ok(drikke);
        }


        //// GET: api/Drikke/5
        //[ResponseType(typeof(IQueryable<Rating>))]
        //public IHttpActionResult GetRatingsAndDrikkeForUser(int id)
        //{
        //    var bruker = db.Bruker.Include(b => b.Rating.Select(r => r.Drikke)).FirstOrDefault(b => b.ID == id);
        //    var rating = db.Rating.Include(r => r.Drikke).Where(r => r.BrukerID == id);

        //    if (rating == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(rating);
        //}

        // PUT: api/Drikke/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrikke(int id, Drikke drikke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drikke.ID)
            {
                return BadRequest();
            }

            db.Entry(drikke).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrikkeExists(id))
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

        // POST: api/Drikke
        [ResponseType(typeof(Drikke))]
        public IHttpActionResult PostDrikke(Drikke drikke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drikke.Add(drikke);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drikke.ID }, drikke);
        }

        // DELETE: api/Drikke/5
        [ResponseType(typeof(Drikke))]
        public IHttpActionResult DeleteDrikke(int id)
        {
            Drikke drikke = db.Drikke.Find(id);
            if (drikke == null)
            {
                return NotFound();
            }

            db.Drikke.Remove(drikke);
            db.SaveChanges();

            return Ok(drikke);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrikkeExists(int id)
        {
            return db.Drikke.Count(e => e.ID == id) > 0;
        }
    }
}