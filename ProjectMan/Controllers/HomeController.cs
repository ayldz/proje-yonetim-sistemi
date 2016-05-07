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
            String Username = fc["username"];
            String Password = fc["password"];

            Boolean success = SessionHelper.Current.Login(Username, Password);
            if (success)
            {
                return Redirect("/Home/Dashboard");
            }
            else {
                ViewData["LoginError"] = true;
                return View();
            }
        }

        public ActionResult Dashboard() {
            if (SessionHelper.Current.WhoAmI() != null){
                return View();
            }
            else {
                return Redirect("/Home/Login");
            }
        }

        public ActionResult Logout() {
            SessionHelper.Current.Logout();
            return Redirect("/Home/Dashboard");
        }

    }
}