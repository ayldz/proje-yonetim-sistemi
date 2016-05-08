using ProjectMan.Helpers;
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

        private static Dictionary<String, SessionHelper> _instances;

        public static SessionHelper Current
        {
            get
            {
                string sessionid = HttpContext.Current.Session.SessionID;

                if (_instances == null) {
                    _instances = new Dictionary<string, SessionHelper>();
                }

                if (!_instances.ContainsKey(sessionid))
                {
                    _instances.Add(sessionid, new SessionHelper());
                }
                return _instances[sessionid];
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

        public Boolean AuthorizedFor(object model, DataOperations action) {

            if ((UserPositions)WhoAmI().position == UserPositions.Admin) {
                return true;
            }

            AuthorizationBase auth = AuthorizationHelper.GetHelper(model);

            if (action == DataOperations.Create) {
                return auth.Create();
            }
            else if (action == DataOperations.Read)
            {
                return auth.Read();
            }
            else if (action == DataOperations.Update)
            {
                return auth.Update();
            }
            else if (action == DataOperations.Delete)
            {
                return auth.Delete();
            }
            else {
                return false;
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