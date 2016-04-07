using ProjectMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMan.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc) {
            pmsContext context = new pmsContext();
            User o = (from c in context.User where c.id == 1 select c).FirstOrDefault();

            return View();
        }

        public ActionResult Dashboard() {
            return View();
        }
    }
}