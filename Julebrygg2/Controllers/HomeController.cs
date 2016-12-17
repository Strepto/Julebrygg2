using Julebrygg2.DAL;
using Julebrygg2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Julebrygg2.Controllers
{
    public class HomeController : Controller
    {
        private readonly Julebrygg2Context db = new Julebrygg2Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                db.Bruker.Add(bruker);
                db.SaveChanges();
                Response.Cookies["cookie"].Value = bruker.ID.ToString();
                
                return RedirectToAction("Create", "Rating");
            }
            return View(bruker);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}