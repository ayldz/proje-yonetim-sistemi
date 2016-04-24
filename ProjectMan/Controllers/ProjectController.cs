using ProjectMan.Models;
using System;
using System.Collections.Generic;
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
            return View();
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
            return View();
        }

        // POST: Project/Edit/5
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

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
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

        private Project FormCollectionToModel(FormCollection fc) {


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
