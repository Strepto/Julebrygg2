﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Julebrygg2.DAL;
using Julebrygg2.Models;

namespace Julebrygg2.Controllers
{
    public class RatingController : Controller
    {
        private Julebrygg2Context db = new Julebrygg2Context();

        // GET: Rating
        public ActionResult Index()
        {
            var rating = db.Rating.Include(r => r.Bruker).Include(r => r.Drikke);
            return View(rating.ToList());
        }

        // GET: Rating/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Rating.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // GET: Rating/Create
        public ActionResult Create()
        {
            ViewBag.BrukerID = new SelectList(db.Bruker, "ID", "Navn");
            ViewBag.DrikkeID = new SelectList(db.Drikke, "ID", "Navn");
            return View();
        }

        // POST: Rating/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DrikkeID,BrukerID,Bilde,Karakter,Nokkelord,SmakerJul,ModifiedDate,CreateDate")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Rating.Add(rating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrukerID = new SelectList(db.Bruker, "ID", "Navn", rating.BrukerID);
            ViewBag.DrikkeID = new SelectList(db.Drikke, "ID", "Navn", rating.DrikkeID);
            return View(rating);
        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Rating.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrukerID = new SelectList(db.Bruker, "ID", "Navn", rating.BrukerID);
            ViewBag.DrikkeID = new SelectList(db.Drikke, "ID", "Navn", rating.DrikkeID);
            return View(rating);
        }

        // POST: Rating/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DrikkeID,BrukerID,Bilde,Karakter,Nokkelord,SmakerJul,ModifiedDate,CreateDate")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrukerID = new SelectList(db.Bruker, "ID", "Navn", rating.BrukerID);
            ViewBag.DrikkeID = new SelectList(db.Drikke, "ID", "Navn", rating.DrikkeID);
            return View(rating);
        }

        // GET: Rating/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Rating.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // POST: Rating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rating rating = db.Rating.Find(id);
            db.Rating.Remove(rating);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
