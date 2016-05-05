﻿using ProjectMan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMan.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            pmsContext context = new pmsContext();
            return View(context.Project.ToList());
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                pmsContext context = new pmsContext();
                Project proje = FormCollectionToModel(collection);
                context.Project.Add(proje);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            pmsContext context = new pmsContext();
            Project proje = context.Project.Find(id);

            return View(proje);
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,startdateplanned,enddateplanned,stardateactual,enddateactual,progress,company,projectmanager")] Project project)
        {
            pmsContext context = new pmsContext();
            if (ModelState.IsValid)
            {
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            pmsContext context = new pmsContext();
            Project proj = context.Project.Find(id);
            context.Project.Remove(proj);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        private Project FormCollectionToModel(FormCollection fc)
        {
            var model = new Project();

            model.name = fc["projectName"];
            model.startdateplanned = new DateTime(Convert.ToInt32(fc["startDatePlanned"].Split('/')[2]), Convert.ToInt32(fc["startDatePlanned"].Split('/')[1]), Convert.ToInt32(fc["startDatePlanned"].Split('/')[0]));
            model.enddateplanned = new DateTime(Convert.ToInt32(fc["endDatePlanned"].Split('/')[2]), Convert.ToInt32(fc["endDatePlanned"].Split('/')[1]), Convert.ToInt32(fc["endDatePlanned"].Split('/')[0]));
            model.startDateActual = new DateTime(Convert.ToInt32(fc["startDateActual"].Split('/')[2]), Convert.ToInt32(fc["startDateActual"].Split('/')[1]), Convert.ToInt32(fc["startDateActual"].Split('/')[0]));
            model.enddateactual = new DateTime(Convert.ToInt32(fc["endDateActual"].Split('/')[2]), Convert.ToInt32(fc["endDateActual"].Split('/')[1]), Convert.ToInt32(fc["endDateActual"].Split('/')[0]));
            model.progress = Convert.ToInt16(fc["progress"]);
            model.company = Convert.ToInt32(fc["company"]);
            model.projectmanager = Convert.ToInt32(fc["projectManager"]);
     
            return model;
        }
    }
}
