﻿using ProjectMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMan.Controllers
{
    [LoggedIn]
    public class MilestoneController : Controller
    {
        // GET: Milestone
        public ActionResult Index()
        {
            pmsContext context = new pmsContext();
            return View(context.Milestone.ToList());
        }

        // GET: Milestone/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Milestone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Milestone/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                pmsContext context = new pmsContext();
                Milestone mile = FormCollectionToModel(collection);
                context.Milestone.Add(mile);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Milestone/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Milestone/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Milestone/Delete/5
        public ActionResult Delete(int id)
        {
            pmsContext context = new pmsContext();
            Milestone ms = context.Milestone.Find(id);
            context.Milestone.Remove(ms);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        private Milestone FormCollectionToModel(FormCollection fc)
        {
            var mile = new Milestone();

            mile.name = fc["milestoneName"];
            mile.progress = Convert.ToInt32(fc["progress"]);
            mile.project = Convert.ToInt32(fc["proje"]);

            return mile;
        }
    }
}
