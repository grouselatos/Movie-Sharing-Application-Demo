using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WatchAuth.Managers;
using WatchAuth.Models;

namespace WatchAuth.Controllers
{
    public class RestController : Controller
    {
        private DbManager db = new DbManager();

        [HttpGet]
        public JsonResult Actors()
        {
            var actors = db.GetActors();
            var result = actors.Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Actor(int id)
        {
            Actor actor = db.GetActor(id);
            var result = new
            {
                Id = actor.Id,
                Name = actor.Name,
                Age = actor.Age
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Actor(Actor actor)
        {
            db.UpdateActor(actor);
            return Json(actor);
        }

        [HttpPut]
        [ActionName("Actor")]
        
        public JsonResult AddActor(Actor actor)
        {
            db.AddActor(actor);
            return Json(actor);
        }

        [HttpDelete]
        [ActionName("Actor")]
        public JsonResult DeleteActor(int id)
        {
            bool result = db.DeleteActorBool(id);
            return Json(result);
        }
    }
}