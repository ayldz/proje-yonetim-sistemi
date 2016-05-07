using ProjectMan.Helpers;
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
            return View(context.User.ToList().Where(p => SessionHelper.Current.AuthorizedFor(p, Helpers.DataOperations.Read)).ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            pmsContext context = new pmsContext();
            User kullanici = context.User.Find(id);
            if (SessionHelper.Current.AuthorizedFor(kullanici, DataOperations.Read))
            {
                return View(kullanici);
            }
            else
            {
                TempData["Error"] = "Bu kullanıcı bilgilerini görüntüleme yetkiniz bulunmamaktadır.";
                return RedirectToAction("Index");
            }

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

                if (SessionHelper.Current.AuthorizedFor(kullanici, DataOperations.Create))
                {
                    context.User.Add(kullanici);
                    context.SaveChanges();
                    TempData["Info"] = "Yeni kullanıcı kaydı oluşturuldu.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Yeni kullanıcı kaydetmek için yetkiniz bulunmamaktadır.";
                    return RedirectToAction("Index");
                }


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

            if (SessionHelper.Current.AuthorizedFor(kullanici, DataOperations.Update))
            {
                return View(kullanici);
            }
            else
            {
                TempData["Error"] = "Bu kullanıcı kaydını güncellemek için yetkiniz bulunmamaktadır.";
                return RedirectToAction("Index");
            }


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

                TempData["Info"] = "Şirket bilgileri başarı ile güncellendi. ";

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

            if (SessionHelper.Current.AuthorizedFor(user, DataOperations.Delete))
            {
                context.User.Remove(user);
                context.SaveChanges();
                TempData["Info"] = "1 Kayıt Silindi";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Silme işlemi için yetkiniz bulunmamaktadır.";
                return RedirectToAction("Index");
            }
        }

        public ActionResult RenderOption(String name, Int32? value)
        {
            pmsContext context = new pmsContext();
            List<User> list = context.User.ToList().Where(p => SessionHelper.Current.AuthorizedFor(p, Helpers.DataOperations.Read)).ToList();
            Tuple<string, Int32?, List<User>> model = new Tuple<string, Int32?, List<User>>(name, value, list);
            return PartialView("_UserSelect", model);
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
