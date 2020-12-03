using Data;
using Models.BossModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkSoulsMVC.Controllers
{
    public class BossController : Controller
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: Boss
        //public ActionResult Index()
        //{
        //    var service = new BossService();
        //    var model = service.GetBosses();
        //    return View(model);
        //}
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var service = new BossService();
            var bosses = from boss in service.GetBosses() select boss;

            switch (sortOrder)
            {
                case "name_desc":
                    bosses = bosses.OrderBy(boss => boss.Name);
                    break;
                default:
                    bosses.OrderBy(b => b.ID);
                    break;
            }

            return View(bosses.ToList());
        }

        //GET: Boss/Create
        public ActionResult Create()
        {
            var service = new LocationService();
            ViewBag.ID = new SelectList(service.GetLocations().OrderBy(e => e.Name), "ID", "Name");
            return View();
        }
        //POST: Boss/Create
        [HttpPost]
        public ActionResult Create(BossCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new BossService();

            if (service.CreateBoss(model))
            {
                TempData["SaveResult"] = "Boss created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Boss could not be created");

            return View(model);
        }

        //GET: Boss/Details
        public ActionResult Details(int id)
        {
            var service = new BossService();
            var model = service.GetBossByID(id);

            return View(model);
        }

        //GET: Boss/Edit
        public ActionResult Edit(int id)
        {
            var service = new BossService();
            var detail = service.GetBossByID(id);

            var locationService = new LocationService();
            ViewBag.LocationID = new SelectList(ctx.Locations.ToList(), "ID", "Name");

            var model = new BossEdit
            {
                Name = detail.Name,
                Description = detail.Description,
                Health = detail.Health,
                Weakness = detail.Weakness,
                Location = detail.Location,
                LocationID = detail.LocationID,
                Tips = detail.Tips
            };

            return View(model);
        }
        //POST: Boss/Edit
        [HttpPost]
        public ActionResult Edit(int id, BossEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.ID != id)
            {
                ModelState.AddModelError("", "Wrong ID");
                return View(model);
            }

            var service = new BossService();

            if (service.UpdateBoss(model))
            {
                TempData["SaveResult"] = "Boss updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error");
            return View(model);
        }
        //GET: Boss/Delete
        public ActionResult Delete(int id)
        {
            var service = new BossService();
            var model = service.GetBossByID(id);

            return View(model);
        }
        //POST: Boss/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteBoss(int id)
        {
            var service = new BossService();

            service.DeleteBoss(id);

            TempData["SaveResult"] = "Boss deleted";

            return RedirectToAction("Index");
        }
    }
}