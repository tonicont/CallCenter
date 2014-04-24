using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CallCenter.Application;
using CallCenter.CORE.Domain;
using CallCenter.DAO;

namespace CallCenter.Web.User
{
    public partial class IncidenciasList : System.Web.UI.Page
    {
        DBContext dbContext;
        IncidenciaService incidenciaService;
        Guid userId;
        List<Incidencia> ListaIncidencias;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Creamos el contexto de datos y los servicios
            dbContext = new DBContext("DefaultConnection");
            incidenciaService = new IncidenciaService(dbContext);

            //Cogemos la información del usuario actual, en userId cogeremos su id o un guid vacio si no esta logueado
            MembershipUser user = Membership.GetUser();
            userId = user == null ? Guid.Empty : (Guid)user.ProviderUserKey; 

            //Bindeamos el ListView1 de las incidencias
            ListView1.DataSource = incidenciaService.GetByUserId(userId).ToList();
            ListView1.DataBind();
        }

        protected void Eliminar_Click(object sender, CommandEventArgs e)
        {
            incidenciaService.Delete(Guid.Parse(e.CommandArgument.ToString()));
            //Refrescamos el ListView
            ListView1.DataSource = incidenciaService.GetAll().ToList();
            ListView1.DataBind();
        }
    }
}