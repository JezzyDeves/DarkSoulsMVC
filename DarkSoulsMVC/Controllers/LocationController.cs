using Models.LocationModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkSoulsMVC.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            var service = new LocationService();
            var model = service.GetLocations();
            return View(model);
        }

        //GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Location/Create
        [HttpPost]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new LocationService();

            if (service.CreateLocation(model))
            {
                TempData["SaveResult"] = "Location created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Location could not be created");

            return View(model);
        }

        //GET: Location/Details
        public ActionResult Details(int id)
        {
            var service = new LocationService();
            var model = service.GetLocationByID(id);

            return View(model);
        }

        //GET: Location/Edit
        public ActionResult Edit(int id)
        {
            var service = new LocationService();
            var detail = service.GetLocationByID(id);
            var model = new LocationEdit
            {
                ID = detail.ID,
                Name = detail.Name,
                Description = detail.Description
            };

            return View(model);
        }
        //POST: Location/Edit
        [HttpPost]
        public ActionResult Edit(int id, LocationEdit model)
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

            var service = new LocationService();

            if (service.UpdateLocation(model))
            {
                TempData["SaveResult"] = "Location updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error");
            return View(model);
        }

        //GET: Location/Delete
        public ActionResult Delete(int id)
        {
            var service = new LocationService();
            var model = service.GetLocationByID(id);

            return View(model);
        }
        //POST: Location/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteLocation(int id)
        {
            var service = new LocationService();

            service.DeleteLocation(id);

            TempData["SaveResult"] = "Location deleted";

            return RedirectToAction("Index");
        }
    }
}