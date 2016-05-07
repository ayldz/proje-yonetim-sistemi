using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMan.Helpers
{
    public class MilestoneAuthorizationHelper : AuthorizationBase
    {
        Models.Milestone Milestone;

        public MilestoneAuthorizationHelper(object model) : base(model)
        {
            Milestone = (Models.Milestone)model;
        }

        public override bool Create()
        {
            if (UserPosition == UserPositions.ProjectManager)
            {
                return (Milestone.Project1.projectmanager == User.id) ? true : false;
            }
            else {
                return false;
            }
        }

        public override bool Delete()
        {
            if (UserPosition == UserPositions.ProjectManager)
            {
                return (Milestone.Project1.projectmanager == User.id) ? true : false;
            }
            else
            {
                return false;
            }
        }

        public override bool Read()
        {
            if (UserPosition == UserPositions.Customer)
            {
                return (Milestone.Project1.Company1.contactemail == User.name) ? true : false;
            }
            else {
                return true;
            }
        }

        public override bool Update()
        {
            if (UserPosition == UserPositions.ProjectManager)
            {
                return (Milestone.Project1.projectmanager == User.id) ? true : false;
            }
            else
            {
                return false;
            }
        }
    }
}