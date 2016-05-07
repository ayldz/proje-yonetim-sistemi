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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            pmsContext context = new pmsContext();
            return View(context.User.ToList().Where(p => SessionHelper.Current.AuthorizedFor(p, Helpers.DataOperations.Read) == true).ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            pmsContext context = new pmsContext();
            User kullanici = context.User.Find(id);

            return View(kullanici);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                pmsContext context = new pmsContext();
                User kullanici = FormCollectionToModel(collection);
                context.User.Add(kullanici);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            pmsContext context = new pmsContext();
            User kullanici = context.User.Find(id);

            return View(kullanici);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                User kullanici = this.FormCollectionToModel(collection);
                kullanici.id = id;

                pmsContext context = new pmsContext();
                context.Entry(kullanici).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            pmsContext context = new pmsContext();
            User user = context.User.Find(id);
            context.User.Remove(user);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        private User FormCollectionToModel(FormCollection fc)
        {
            var model = new User();

            model.username = fc["userName"];
            model.password = fc["password"];
            model.name = fc["name"];
            model.surname = fc["soyad"];
            model.position = Convert.ToInt32(fc["pozisyon"]);

            return model;
        }
    }
}
