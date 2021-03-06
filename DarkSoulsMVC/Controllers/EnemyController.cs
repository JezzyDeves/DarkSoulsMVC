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
        //public ActionResult Index()
        //{
        //    var service = new EnemyService();
        //    var model = service.GetEnemies();

        //    return View(model);
        //}
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var service = new EnemyService();
            var enemies = from enemy in service.GetEnemies() select enemy;

            switch (sortOrder)
            {
                case "name_desc":
                    enemies = enemies.OrderBy(enemy => enemy.Name);
                    break;
                default:
                    enemies.OrderBy(e => e.EnemyID);
                    break;
            }

            return View(enemies.ToList());
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

        //GET: Enemy/Detail
        public ActionResult Details(int id)
        {
            var service = new EnemyService();
            var model = service.GetEnemyByID(id);

            return View(model);
        }

        //GET: Enemy/Edit
        public ActionResult Edit(int id)
        {
            var service = new EnemyService();
            var detail = service.GetEnemyByID(id);
            ViewBag.LocationID = new SelectList(ctx.Locations.ToList(), "ID", "Name");


            var model = new EnemyEdit
            {
                EnemyID = detail.EnemyID,
                Name = detail.Name,
                Description = detail.Description,
                Health = detail.Health,
                LocationID = detail.LocationID,
                Location = detail.Location
            };


            return View(model);
        }
        //POST: Enemy/Edit
        [HttpPost]
        public ActionResult Edit(int id, EnemyEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.EnemyID != id)
            {
                ModelState.AddModelError("", "Wrong ID");
                return View(model);
            }

            var service = new EnemyService();

            if (service.UpdateEnemy(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error");
            return View(model);
        }

        //GET: Enemy/Delete
        public ActionResult Delete(int id)
        {
            var service = new EnemyService();
            var model = service.GetEnemyByID(id);

            return View(model);
        }
        //POST: Enemy/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEnemy(int id)
        {
            var service = new EnemyService();

            service.DeleteEnemy(id);

            return RedirectToAction("Index");
        }
    }
}