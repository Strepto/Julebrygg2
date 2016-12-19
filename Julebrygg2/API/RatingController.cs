﻿using System;
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
    public class RatingController : ApiController
    {
        private Julebrygg2Context db = new Julebrygg2Context();

        // GET: api/Rating
        public IQueryable<Rating> GetRating()
        {
            return db.Rating.Include(r => r.Drikke).Include(r => r.Bruker).OrderByDescending(r => r.CreateDate);
        }

        // GET: api/Rating/5
        [ResponseType(typeof(Rating))]
        public IHttpActionResult GetRating(int id)
        {
            Rating rating = db.Rating.Include(r => r.Drikke).FirstOrDefault(i => i.ID == id);
            if (rating == null)
            {
                return NotFound();
            }
            

            return Ok(rating);
        }

        // PUT: api/Rating/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRating(int id, Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rating.ID)
            {
                return BadRequest();
            }

            db.Entry(rating).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
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

        // POST: api/Rating
        [ResponseType(typeof(Rating))]
        public IHttpActionResult PostRating(Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rating.Add(rating);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rating.ID }, rating);
        }

        // DELETE: api/Rating/5
        [ResponseType(typeof(Rating))]
        public IHttpActionResult DeleteRating(int id)
        {
            Rating rating = db.Rating.Find(id);
            if (rating == null)
            {
                return NotFound();
            }

            db.Rating.Remove(rating);
            db.SaveChanges();

            return Ok(rating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RatingExists(int id)
        {
            return db.Rating.Count(e => e.ID == id) > 0;
        }
    }
}