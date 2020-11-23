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
        //GET: Item/Detail
        public ActionResult Details(int id)
        {
            var service = new ItemService();
            var model = service.GetItemByID(id);

            return View(model);
        }

        //GET: Item/Create
        public ActionResult Create()
        {
            var service = new ItemService();
            ViewBag.LocationID = new SelectList(ctx.Locations.ToList(), "ID", "Name");

            return View();
        }
        //POST: Item/Create
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

        //GET: Item/Edit
        public ActionResult Edit(int id)
        {
            var service = new ItemService();
            var detail = service.GetItemByID(id);
            ViewBag.LocationID = new SelectList(ctx.Locations.ToList(), "ID", "Name");


            var model = new ItemEdit
            {
                ItemID = detail.ItemID,
                Name = detail.Name,
                Description = detail.Description,
                LocationID = detail.LocationID,
            };


            return View(model);
        }
        //POST: Item/Edit
        [HttpPost]
        public ActionResult Edit(int id, ItemEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.ItemID != id)
            {
                ModelState.AddModelError("", "Wrong ID");
                return View(model);
            }

            var service = new ItemService();

            if (service.UpdateItem(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error");
            return View(model);
        }
    }
}