using ProjectMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMan
{
    public class SessionHelper
    {
        private SessionHelper()
        {
            var id = HttpContext.Current.Session["currentuser"];
            if (id != null && id.GetType() == typeof(Int32))
            {
                this.setCurrentUser(Convert.ToInt32(id));
            }
        }

        private static SessionHelper _instance;

        public static SessionHelper Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SessionHelper();
                }
                return _instance;
            }
        }

        private Models.User currentUser;

        private void setCurrentUser(int id)
        {
            using (pmsContext context = new pmsContext())
            {
                this.currentUser = (from u in context.User where u.id == id select u).FirstOrDefault();
                if (this.currentUser == null)
                {
                    HttpContext.Current.Session.Remove("currentuser");
                }

            }
        }

        public Boolean Login(String username, String password)
        {
            using (pmsContext context = new pmsContext())
            {
                this.currentUser = (from u in context.User where u.username.Equals(username) && u.password.Equals(password) select u).FirstOrDefault();
                if (this.currentUser != null)
                {
                    HttpContext.Current.Session["currentuser"] = this.currentUser.id;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Models.User WhoAmI() {
            if (this.currentUser != null)
            {
                return this.currentUser;
            }
            else if (HttpContext.Current.Session["currentuser"] != null)
            {
                int id = Convert.ToInt32(HttpContext.Current.Session["currentuser"]);
                using (pmsContext context = new pmsContext())
                {
                    this.currentUser = (from u in context.User where u.id == id select u).FirstOrDefault();
                    if (this.currentUser != null)
                    {
                        return this.currentUser;
                    }
                    else {
                        HttpContext.Current.Session.Remove("currentuser");
                        return null;
                    }
                }
            }
            else {
                return null;
            }
        }

        public void Logout() {
            this.currentUser = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
    }
}