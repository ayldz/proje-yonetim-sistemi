using ProjectMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMan.Controllers
{
    [LoggedIn]
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            pmsContext context = new pmsContext();
            return View(context.Menu.ToList());
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                pmsContext context = new pmsContext();
                Menu menu = FormCollectionToModel(collection);
                context.Menu.Add(menu);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int id)
        {
            pmsContext context = new pmsContext();
            Menu menu = context.Menu.Find(id);

            return View(menu);
        }

        // POST: Menu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Menu menu = this.FormCollectionToModel(collection);
                menu.id = id;

                pmsContext context = new pmsContext();
                context.Entry(menu).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int id)
        {
            pmsContext context = new pmsContext();
            Menu menu = context.Menu.Find(id);
            context.Menu.Remove(menu);
            context.SaveChanges();

            return RedirectToAction("Index"); ;
        }


        private Menu FormCollectionToModel(FormCollection fc)
        {
            var model = new Menu();

            model.icon = fc["icon"];
            model.text = fc["text"];
            model.controller = fc["controller"];
            model.action = fc["action"];

            return model;
        }
    }
}
