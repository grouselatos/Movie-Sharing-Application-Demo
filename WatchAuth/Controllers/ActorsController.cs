using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchAuth.Managers;
using WatchAuth.Models;

namespace WatchAuth.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActorsController : Controller
    {
        private DbManager db = new DbManager();
        // GET: Actors
    
        public ActionResult Index()
        {
            var actors = db.GetActors();
            ViewData["Message"] = "We are on index page!";
            return View(actors);
        }

        
        public ActionResult Create()
        {
            ViewBag.Message = "We are on create page!";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            db.AddActor(actor);
            TempData["notification-message"] = "Actor inserted successfully!";
            TempData["notification-color"] = "success";
            Session["Actions"] = (int)Session["Actions"] + 1;
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Actor actor = db.GetActor(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            db.UpdateActor2(actor);
            TempData["notification-message"] = "Actor edited successfully";
            TempData["notification-color"] = "warning";
            Session["Actions"] = (int)Session["Actions"] + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Actor actor = db.GetActor(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.DeleteActor(id);
            TempData["notification-message"] = "Actor deleted successfully";
            TempData["notification-color"] = "danger";
            Session["Actions"] = (int)Session["Actions"] + 1;
            return RedirectToAction("Index");
        }
    }
}