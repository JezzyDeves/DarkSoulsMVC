﻿using Data;
using Models.EnemyModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkSoulsMVC.Controllers
{
    public class EnemyController : Controller
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        // GET: Enemy
        public ActionResult Index()
        {
            var service = new EnemyService();
            var model = service.GetEnemies();

            return View(model);
        }

        //GET: Enemy/Create
        public ActionResult Create()
        {
            var service = new EnemyService();
            ViewBag.LocationID = new SelectList(ctx.Locations.ToList(), "ID", "Name");

            return View();
        }
        //POST: Enemy/Create
        [HttpPost]
        public ActionResult Create(EnemyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new EnemyService();

            if (service.CreateEnemy(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Enemy could not be created");

            return View(model);
        }
    }
}