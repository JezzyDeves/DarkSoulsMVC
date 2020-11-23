using Data;
using Models.ItemModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkSoulsMVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        // GET: Item
        public ActionResult Index()
        {
            var service = new ItemService();
            var model = service.GetItems();

            return View(model);
        }

        //GET: Item/Create
        public ActionResult Create()
        {
            var service = new ItemService();
            ViewBag.LocationID = new SelectList(ctx.Locations.ToList(), "ID", "Name");

            return View();
        }
        //POST: Enemy/Create
        [HttpPost]
        public ActionResult Create(ItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new ItemService();

            if (service.CreateItem(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Item could not be created");

            return View(model);
        }
    }
}