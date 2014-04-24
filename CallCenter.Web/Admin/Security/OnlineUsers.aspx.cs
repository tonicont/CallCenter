using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Seguridad.Admin.Access
{
    public partial class OnlineUsers : System.Web.UI.Page
    {
        private void Page_PreRender()
        {
            MembershipUserCollection allUsers = Membership.GetAllUsers();
            MembershipUserCollection filteredUsers = new MembershipUserCollection();
            bool isOnline = true;
            foreach (MembershipUser user in allUsers)
            {
                if (user.IsOnline == isOnline)
                {
                    filteredUsers.Add(user);
                }
            }
            Users.DataSource = filteredUsers;
            Users.DataBind();
        }
    }
}