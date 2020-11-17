using Models.LocationModels;
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
            var model = new LocationListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}