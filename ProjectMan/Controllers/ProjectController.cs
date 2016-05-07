using ProjectMan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMan.Controllers
{
    [LoggedIn]
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
            pmsContext context = new pmsContext();
            Project proje = context.Project.Find(id);

            return View(proje);
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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Project project = this.FormCollectionToModel(collection);
                project.id = id;

                pmsContext context = new pmsContext();
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();

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
            pmsContext context = new pmsContext();
            Project proj = context.Project.Find(id);
            context.Project.Remove(proj);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult RenderOption(String name, Int32? value)
        {
            pmsContext context = new pmsContext();
            List<Project> list = context.Project.ToList().Where(p => SessionHelper.Current.AuthorizedFor(p, Helpers.DataOperations.Read)).ToList();
            Tuple<string, Int32?, List<Project>> model = new Tuple<string, Int32?, List<Project>>(name, value, list);
            return PartialView("_ProjectSelect", model);
        }


        private Project FormCollectionToModel(FormCollection fc)
        {
            var model = new Project();

            model.name = fc["projectName"];
            model.startdateplanned = new DateTime(Convert.ToInt32(fc["startDatePlanned"].Split('/')[2]), Convert.ToInt32(fc["startDatePlanned"].Split('/')[1]), Convert.ToInt32(fc["startDatePlanned"].Split('/')[0]));
            model.enddateplanned = new DateTime(Convert.ToInt32(fc["endDatePlanned"].Split('/')[2]), Convert.ToInt32(fc["endDatePlanned"].Split('/')[1]), Convert.ToInt32(fc["endDatePlanned"].Split('/')[0]));
            model.stardateactual = new DateTime(Convert.ToInt32(fc["startDateActual"].Split('/')[2]), Convert.ToInt32(fc["startDateActual"].Split('/')[1]), Convert.ToInt32(fc["startDateActual"].Split('/')[0]));
            model.enddateactual = new DateTime(Convert.ToInt32(fc["endDateActual"].Split('/')[2]), Convert.ToInt32(fc["endDateActual"].Split('/')[1]), Convert.ToInt32(fc["endDateActual"].Split('/')[0]));
            model.progress = Convert.ToInt16(fc["progress"]);
            model.company = Convert.ToInt32(fc["company"]);
            model.projectmanager = Convert.ToInt32(fc["projectManager"]);
     
            return model;
        }
    }
}
