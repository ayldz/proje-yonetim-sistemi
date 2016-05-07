using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMan.Helpers
{
    public class MenuAuthorizationHelper : AuthorizationBase
    {
        public MenuAuthorizationHelper(object model) : base(model)
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
            Models.Menu Menu = (Models.Menu)Model;

            Dictionary<String, UserPositions[]> readList = new Dictionary<string, UserPositions[]>();

            readList.Add("Company", new UserPositions[] { UserPositions.Admin, UserPositions.ProjectManager, UserPositions.Developer, UserPositions.Customer });
            readList.Add("Project", new UserPositions[] { UserPositions.Admin, UserPositions.ProjectManager, UserPositions.Developer, UserPositions.Customer });
            readList.Add("Milestone", new UserPositions[] { UserPositions.Admin, UserPositions.ProjectManager, UserPositions.Developer, UserPositions.Customer });
            readList.Add("Task", new UserPositions[] { UserPositions.Admin, UserPositions.ProjectManager, UserPositions.Developer, UserPositions.Customer });
            readList.Add("User", new UserPositions[] { UserPositions.Admin, UserPositions.ProjectManager, UserPositions.Developer });
            readList.Add("Menu", new UserPositions[] { UserPositions.Admin });

            if (readList.ContainsKey(Menu.controller)) {
                if (readList[Menu.controller].ToList().Contains((UserPositions)User.position)){
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        public override bool Update()
        {
            return false;
        }
    }
}