using ProjectMan.Models;
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
            return View(context.Milestone.ToList().Where(m => SessionHelper.Current.AuthorizedFor(m, Helpers.DataOperations.Read)).ToList());
        }

        // GET: Milestone/Details/5
        public ActionResult Details(int id)
        {
            pmsContext context = new pmsContext();
            Milestone mile = context.Milestone.Find(id);
            if (SessionHelper.Current.AuthorizedFor(mile, Helpers.DataOperations.Read))
            {
                return View(mile);
            }
            else {
                TempData["Error"] = "Bu Kilometre taşını görüntülemek için yetkiniz bulunmamaktadır.";
                return RedirectToAction("Index");
            }
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
                if (SessionHelper.Current.AuthorizedFor(mile, Helpers.DataOperations.Create))
                {
                    context.Milestone.Add(mile);
                    context.SaveChanges();
                    TempData["Info"] = "Yeni Kilometre Taşı başarı ile oluşturuldu.";
                    return RedirectToAction("Index");
                }
                else {
                    TempData["Error"] = "Bu kilometre taşını oluşturmak için yetkini bulunmamaktadır.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Milestone/Edit/5
        public ActionResult Edit(int id)
        {
            pmsContext context = new pmsContext();
            Milestone kmtas = context.Milestone.Find(id);

            if (SessionHelper.Current.AuthorizedFor(kmtas, Helpers.DataOperations.Update))
            {
                return View(kmtas);
            }
            else {
                TempData["Error"] = "Bu kilometre taşını güncellemek için yetkiniz bulunmamaktadır.";
                return RedirectToAction("Index");
            }
        }

        // POST: Milestone/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Milestone kmtas = this.FormCollectionToModel(collection);
                kmtas.id = id;

                pmsContext context = new pmsContext();
                context.Entry(kmtas).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                TempData["Info"] = "Kilometre Taşı bilgileri başarı ile güncellendi."

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

        public ActionResult RenderOption(String name, Int32? value)
        {
            pmsContext contex = new pmsContext();
            List<Milestone> list = contex.Milestone.ToList().Where(p => SessionHelper.Current.AuthorizedFor(p, Helpers.DataOperations.Read)).ToList();
            Tuple<string, Int32?, List<Milestone>> model = new Tuple<string, Int32?, List<Milestone>>(name, value, list);
            return PartialView("_MilestoneSelect", model);
        }
        
        private Milestone FormCollectionToModel(FormCollection fc)
        {
            var mile = new Milestone();

            mile.name = fc["milestoneName"];
            mile.progress = Convert.ToInt32(fc["progress"]);
            mile.project = Convert.ToInt32(fc["project"]);

            return mile;
        }
    }
}
