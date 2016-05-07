using ProjectMan.Helpers;
using ProjectMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectMan.Controllers
{
    [LoggedIn]
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            pmsContext context = new pmsContext();
            return View(context.Company.ToList().Where(c => SessionHelper.Current.AuthorizedFor(c, DataOperations.Read)).ToList());
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            pmsContext context = new pmsContext();
            Company comp = context.Company.Find(id);
            if (SessionHelper.Current.AuthorizedFor(comp, DataOperations.Read))
            {
                return View(comp);
            }
            else
            {
                TempData["Error"] = "Bu Şirket bilgilerini görüntüleme yetkiniz bulunmamaktadır.";
                return RedirectToAction("Index");
            }
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                pmsContext context = new pmsContext();
                Company comp = FormCollectionToModel(collection);

                if (SessionHelper.Current.AuthorizedFor(comp, DataOperations.Create))
                {
                    context.Company.Add(comp);
                    context.SaveChanges();
                    TempData["Info"] = "Yeni şirket kaydı oluşturuldu.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Yeni Şirket kaydetmek için için yetkiniz bulunmamaktadır.";
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            pmsContext context = new pmsContext();
            Company comp = context.Company.Find(id);

            if (SessionHelper.Current.AuthorizedFor(comp, DataOperations.Update))
            {
                return View(comp);
            }
            else
            {
                TempData["Error"] = "Bu şirket kaydını güncellemek için yetkiniz bulunmamaktadır.";
                return RedirectToAction("Index");
            }
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Company comp = this.FormCollectionToModel(collection);
                comp.id = id;

                pmsContext context = new pmsContext();
                context.Entry(comp).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                TempData["Info"] = "Şirket bilgileri başarı ile güncellendi.";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            pmsContext context = new pmsContext();
            Company comp = context.Company.Find(id);

            if (SessionHelper.Current.AuthorizedFor(comp, DataOperations.Delete))
            {
                context.Company.Remove(comp);
                context.SaveChanges();
                TempData["Info"] = "1 Kayıt Silindi.";
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
            List<Company> list = context.Company.ToList().Where(p => SessionHelper.Current.AuthorizedFor(p, Helpers.DataOperations.Read)).ToList();
            Tuple<string, Int32?, List<Company>> model = new Tuple<string, Int32?, List<Company>>(name, value, list);
            return PartialView("_CompanySelect", model);
        }

        private Company FormCollectionToModel(FormCollection fc)
        {
            var model = new Company();

            model.name = fc["companyName"];
            model.adress = fc["companyAdress"];
            model.billedto = fc["billedTo"];
            model.contactname = fc["contactName"];
            model.contactemail = fc["contactEmail"];
            model.contacttel = fc["contactTel"];
            model.user = Convert.ToInt32(fc["user"]);

            return model;
        }
    }
}
