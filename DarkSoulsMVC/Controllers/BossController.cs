﻿using Data;
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
        // GET: Boss
        public ActionResult Index()
        {
            var service = new BossService();
            var model = service.GetBosses();
            return View(model);
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
    }
}