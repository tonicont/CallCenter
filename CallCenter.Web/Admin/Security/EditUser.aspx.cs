using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Seguridad.Admin.Access
{
    public partial class EditUser : System.Web.UI.Page
    {
        string username;

        MembershipUser user;

        private void Page_Load()
        {
            username = Request.QueryString["username"];
            if (username == null || username == "")
            {
                Response.Redirect("users.aspx");
            }
            user = Membership.GetUser(username);
            UserUpdateMessage.Text = "";
        }

        protected void UserInfo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //Need to handle the update manually because MembershipUser does not have a
            //parameterless constructor  

            user.Email = (string)e.NewValues[0];
            user.Comment = (string)e.NewValues[1];
            user.IsApproved = (bool)e.NewValues[2];

            try
            {
                // Update user info:
                Membership.UpdateUser(user);

                // Update user roles:
                UpdateUserRoles();

                UserUpdateMessage.Text = "Modificación satisfactoria.";

                e.Cancel = true;
                UserInfo.ChangeMode(DetailsViewMode.ReadOnly);
            }
            catch (Exception ex)
            {
                UserUpdateMessage.Text = "Fallo al modificar: " + ex.Message;

                e.Cancel = true;
                UserInfo.ChangeMode(DetailsViewMode.ReadOnly);
            }
        }

        protected void Page_PreRender()
        {
            // Load the User Roles into checkboxes.
            UserRoles.DataSource = Roles.GetAllRoles();
            UserRoles.DataBind();

            // Disable checkboxes if appropriate:
            if (UserInfo.CurrentMode != DetailsViewMode.Edit)
            {
                foreach (ListItem checkbox in UserRoles.Items)
                {
                    checkbox.Enabled = false;
                }
            }

            // Bind these checkboxes to the User's own set of roles.
            string[] userRoles = Roles.GetRolesForUser(username);
            foreach (string role in userRoles)
            {
                ListItem checkbox = UserRoles.Items.FindByValue(role);
                checkbox.Selected = true;
            }
        }

        protected void UpdateUserRoles()
        {
            foreach (ListItem rolebox in UserRoles.Items)
            {
                if (rolebox.Selected)
                {
                    if (!Roles.IsUserInRole(username, rolebox.Text))
                    {
                        Roles.AddUserToRole(username, rolebox.Text);
                    }
                }
                else
                {
                    if (Roles.IsUserInRole(username, rolebox.Text))
                    {
                        Roles.RemoveUserFromRole(username, rolebox.Text);
                    }
                }
            }
        }

        protected void DeleteUser(object sender, EventArgs e)
        {         
            Membership.DeleteUser(username, true); // DC: except during testing, of course!
            Response.Redirect("users.aspx");
        }

        protected void UnlockUser(object sender, EventArgs e)
        {
            // Unlock the user.
            user.UnlockUser();

            // DataBind the GridView to reflect same.
            UserInfo.DataBind();
        }
    }
}