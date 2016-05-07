using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMan.Helpers
{
    public class ProjectAuthorizationHelper : AuthorizationBase
    {

        private Models.Project Project;

        public ProjectAuthorizationHelper(object model) : base(model)
        {
            Project = (Models.Project)model;
        }

        public override bool Create()
        {
            return (UserPosition == UserPositions.ProjectManager) ? true : false;
        }

        public override bool Delete()
        {
            if (UserPosition == UserPositions.ProjectManager)
            {
                return (Project.projectmanager == User.id) ? true : false;
            }
            else {
                return false;
            }
        }

        public override bool Read()
        {
            if (UserPosition == UserPositions.Customer)
            {
                //TODO:
                return (Project.Company1.contactemail == User.username) ? true : false;
            }
            else {
                return true;
            }
        }

        public override bool Update()
        {
            if (UserPosition == UserPositions.ProjectManager)
            {
                return (Project.projectmanager == User.id) ? true : false;
            }
            else
            {
                return false;
            }
        }
    }
}