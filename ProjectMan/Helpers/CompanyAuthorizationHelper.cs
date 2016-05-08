using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMan.Helpers
{
    public class CompanyAuthorizationHelper : AuthorizationBase
    {

        private Models.Company Company;

        public CompanyAuthorizationHelper(object model) : base(model)
        {
            Company = (Models.Company)model;
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
            if (UserPosition == UserPositions.Customer){
                return (Company.user == User.id) ? true : false;
            }
            else {
                return true;
            }
        }

        public override bool Update()
        {
            return false;
        }
    }
}