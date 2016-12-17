using System;
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
    public class DrikkeController : Controller
    {
        private readonly Julebrygg2Context db = new Julebrygg2Context();

        // GET: Drikke
        public ActionResult Index()
        {
            return View(db.Drikke.ToList());
        }

        // GET: Drikke/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drikke drikke = db.Drikke.Find(id);
            if (drikke == null)
            {
                return HttpNotFound();
            }
            return View(drikke);
        }

        // GET: Drikke/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drikke/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Navn,Bryggeri,Abv,Bilde,Stil,Pris,Land")] Drikke drikke)
        {
            if (ModelState.IsValid)
            {
                db.Drikke.Add(drikke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drikke);
        }

        // GET: Drikke/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drikke drikke = db.Drikke.Find(id);
            if (drikke == null)
            {
                return HttpNotFound();
            }
            return View(drikke);
        }

        // POST: Drikke/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Navn,Bryggeri,Abv,Bilde,Stil,Pris,Land")] Drikke drikke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drikke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drikke);
        }

        // GET: Drikke/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drikke drikke = db.Drikke.Find(id);
            if (drikke == null)
            {
                return HttpNotFound();
            }
            return View(drikke);
        }

        // POST: Drikke/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drikke drikke = db.Drikke.Find(id);
            db.Drikke.Remove(drikke);
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
