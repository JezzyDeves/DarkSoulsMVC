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
    }
}