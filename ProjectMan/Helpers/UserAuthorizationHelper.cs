using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMan.Helpers
{
    public class UserAuthorizationHelper : AuthorizationBase
    {

        Models.User UserModel;

        public UserAuthorizationHelper(object model) : base(model)
        {
            UserModel = (Models.User)model;
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
            return (UserModel.id == User.id) ? true : false;
        }

        public override bool Update()
        {
            return (UserModel.id == User.id) ? true : false;
        }
    }
}