using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Seguridad.Admin.Access
{
    public partial class UsersByRole : System.Web.UI.Page
    {
        private void Page_Init()
        {
            UserRoles.DataSource = Roles.GetAllRoles();
            UserRoles.DataBind();
        }

        private void Page_PreRender()
        {         

            MembershipUserCollection allUsers = Membership.GetAllUsers();
            MembershipUserCollection filteredUsers = new MembershipUserCollection();

            if (UserRoles.SelectedIndex > 0)
            {
                string[] usersInRole = Roles.GetUsersInRole(UserRoles.SelectedValue);
                foreach (MembershipUser user in allUsers)
                {
                    foreach (string userInRole in usersInRole)
                    {
                        if (userInRole == user.UserName)
                        {
                            filteredUsers.Add(user);
                            break; // Breaks out of the inner foreach loop to avoid unneeded checking.
                        }
                    }
                }
            }
            else
            {
                filteredUsers = allUsers;
            }
            Users.DataSource = filteredUsers;
            Users.DataBind();
        }
    }
}