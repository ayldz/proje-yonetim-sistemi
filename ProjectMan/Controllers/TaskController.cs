﻿using ProjectMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMan.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                pmsContext context = new pmsContext();
                Task gorev = FormCollectionToModel(collection);
                context.Task.Add(gorev);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Task/Edit/5
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

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private Task FormCollectionToModel(FormCollection fc)
        {

            string[] sdp = fc["startDatePlanned"].Split('/');
            string[] sda = fc["startDateActual"].Split('/');
            string[] edp = fc["endDatePlanned"].Split('/');
            string[] eda = fc["endDateActual"].Split('/');

            var gorev = new Task();

            gorev.name = fc["taskName"];
            gorev.description = fc["descriptionName"];
            gorev.startdateplanned = new DateTime(Convert.ToInt32(sdp[2]),Convert.ToInt32(sdp[1]),Convert.ToInt32(sdp[0]));
            gorev.enddateplanned = new DateTime(Convert.ToInt32(edp[2]), Convert.ToInt32(edp[1]), Convert.ToInt32(edp[0]));
            gorev.startdateactual = new DateTime(Convert.ToInt32(sda[2]), Convert.ToInt32(sda[1]), Convert.ToInt32(sda[0]));
            gorev.enddateplanned = new DateTime(Convert.ToInt32(eda[2]), Convert.ToInt32(eda[1]), Convert.ToInt32(eda[0]));
            gorev.progress = Convert.ToInt16(fc["progress"]);
            gorev.project = Convert.ToInt32(fc["proje"]);
            gorev.milestone = Convert.ToInt32(fc["milestone"]);
            gorev.assingto = Convert.ToInt32(fc["assingTo"]);

            return gorev;
        }
    }
}
