using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMan.Helpers
{
    public class TaskAuthorizationHelper : AuthorizationBase
    {

        private Models.Task Task;

        public TaskAuthorizationHelper(object model) : base(model)
        {
            Task = (Models.Task)Model;
        }

        public override bool Create()
        {
            if (UserPosition == UserPositions.Customer)
            {
                return (Task.Project1.Company1.user == User.id) ? true : false;
            }
            else if (UserPosition == UserPositions.Developer)
            {
                return (Task.assingto == User.id) ? true : false;
            }
            else {
                return true;
            }
        }

        public override bool Read()
        {
            return true;
        }

        public override bool Delete()
        {
            if (UserPosition == UserPositions.ProjectManager)
            {
                return (Task.Project1.projectmanager == User.id) ? true : false;
            }
            else {
                return false;
            }
        }

        public override bool Update()
        {
            if (UserPosition == UserPositions.Customer)
            {
                return false;
            }
            else if (UserPosition == UserPositions.Developer)
            {
                return (Task.assingto == User.id) ? true : false;
            }
            else
            {
                return true;
            }
        }
    }
}