using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Seguridad.Controls;

namespace Seguridad.Admin.Access
{
    public partial class User : System.Web.UI.Page
    {
        private void Page_PreRender()
        {
            if (Alphalinks.Letter == "Todos")
            {
                Users.DataSource = Membership.GetAllUsers();
            }
            else
            {
                Users.DataSource = Membership.FindUsersByName(Alphalinks.Letter + "%");
            }
            Users.DataBind();
        }
    }
}