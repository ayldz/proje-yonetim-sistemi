﻿using ProjectMan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
            return View(context.Company.ToList());
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            pmsContext context = new pmsContext();
            Company comp = context.Company.Find(id);

            return View(comp);
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
                context.Company.Add(comp);
                context.SaveChanges();
                return RedirectToAction("Index");
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

            return View(comp);
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
            context.Company.Remove(comp);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        private Company FormCollectionToModel(FormCollection fc)
        {
            var model = new Company();

            model.name = fc["companyName"];
            model.adress = fc["companyAdress"];
            model.billedto = fc["billedTo"];
            model.contactname = fc["contactName"];
            model.contactemail = fc["contactEmail"];
            model.cantacttel = fc["contactTel"];

            return model;
        }
    }
}
