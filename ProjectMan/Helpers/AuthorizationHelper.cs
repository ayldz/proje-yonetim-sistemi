using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMan.Helpers
{
    public enum DataOperations { Create, Read, Update, Delete };

    public enum UserPositions { Admin, ProjectManager, Developer, Customer};

    public static class AuthorizationHelper
    {
        public static AuthorizationBase GetHelper(object model) {
            Type type = model.GetType();

            if (type == typeof(Models.Company) || type.BaseType == typeof(Models.Company))
            {
                return new CompanyAuthorizationHelper(model);
            }
            else if ( type == typeof(Models.Milestone) || type.BaseType == typeof(Models.Milestone))
            {
                return new MilestoneAuthorizationHelper(model);
            }
            else if (type == typeof(Models.Project) || type.BaseType == typeof(Models.Project))
            {
                return new ProjectAuthorizationHelper(model);
            }
            else if (type == typeof(Models.Task) || type.BaseType == typeof(Models.Task))
            {
                return new TaskAuthorizationHelper(model);
            }
            else if (type == typeof(Models.User) || type.BaseType == typeof(Models.User))
            {
                return new UserAuthorizationHelper(model);
            }
            else if (type == typeof(Models.Menu) || type.BaseType == typeof(Models.Menu)) {
                return new MenuAuthorizationHelper(model);
            }
            else
            {
                return new InvalidAuthorizationHelper(model);
            }
        }

    }

    public abstract class AuthorizationBase {

        protected object Model;
        protected UserPositions UserPosition;
        protected Models.User User;

        public AuthorizationBase(object model) {
            this.Model = model;
            this.User = SessionHelper.Current.WhoAmI();
            this.UserPosition = (UserPositions)User.position;
        }
        public abstract Boolean Create();
        public abstract Boolean Read();
        public abstract Boolean Update();
        public abstract Boolean Delete();

    }

    public class InvalidAuthorizationHelper : AuthorizationBase
    {
        public InvalidAuthorizationHelper(object model) : base(model)
        {
        }

        public override bool Create()
        {
            return false;
        }

        public override bool Delete()
        {
            return false;
        }

        public override bool Read()
        {
            return false;
        }

        public override bool Update()
        {
            return false;
        }
    }

}