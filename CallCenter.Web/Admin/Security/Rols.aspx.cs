using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

namespace Seguridad.Admin.Access
{
    public partial class Rols : System.Web.UI.Page
    {
        private bool createRoleSuccess = true;

        protected void Page_PreRender()
        {
            // Create a DataTable and define its columns
            DataTable RoleList = new DataTable();
            RoleList.Columns.Add("Role Name");
            RoleList.Columns.Add("User Count");

            string[] allRoles = Roles.GetAllRoles();

            // Get the list of roles in the system and how many users belong to each role
            foreach (string roleName in allRoles)
            {
                int numberOfUsersInRole = Roles.GetUsersInRole(roleName).Length;
                string[] roleRow = { roleName, numberOfUsersInRole.ToString() };
                RoleList.Rows.Add(roleRow);
            }

            // Bind the DataTable to the GridView
            UserRoles.DataSource = RoleList;
            UserRoles.DataBind();

            if (createRoleSuccess)
            {
                // Clears form field after a role was successfully added. Alternative to redirect technique I often use.
                NewRole.Text = "";
            }
        }

        protected void AddRole(object sender, EventArgs e)
        {
            try
            {
                Roles.CreateRole(NewRole.Text);
                ConfirmationMessage.InnerText = "El nuevo rol ha sido añadido.";
                createRoleSuccess = true;
            }
            catch (Exception ex)
            {
                ConfirmationMessage.InnerText = ex.Message;
                createRoleSuccess = false;
            }
        }

        protected void DeleteRole(object sender, CommandEventArgs e)
        {
            try
            {
                Roles.DeleteRole(e.CommandArgument.ToString());
                ConfirmationMessage.InnerText = "El Rol '" + e.CommandArgument.ToString() + "' ha sido eliminado.";
            }
            catch (Exception ex)
            {
                ConfirmationMessage.InnerText = ex.Message;
            }
        }        
    }
}