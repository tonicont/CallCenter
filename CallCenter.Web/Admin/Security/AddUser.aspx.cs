using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Seguridad.Admin.Access
{
    public partial class AddUser : System.Web.UI.Page
    {
        MembershipUser user;

        private void Page_Load()
        {
            if (IsPostBack)
            {
                try
                {
                    Adduser();

                    Response.Redirect("Users.aspx");
                }
                catch (Exception ex)
                {
                    ConfirmationMessage.InnerText = "Fallo al insertar: " + ex.Message;
                }
            }
        }

        protected void Adduser()
        {
            // Add User.
            MembershipUser newUser = Membership.CreateUser(username.Text, password.Text, email.Text);
            newUser.Comment = comment.Text;
            Membership.UpdateUser(newUser);

            // Add Roles.
            foreach (ListItem rolebox in UserRoles.Items)
            {
                if (rolebox.Selected)
                {
                    Roles.AddUserToRole(username.Text, rolebox.Text);
                }
            }
        }

        private void Page_PreRender()
        {
            UserRoles.DataSource = Roles.GetAllRoles();
            UserRoles.DataBind();
        }
    }
}