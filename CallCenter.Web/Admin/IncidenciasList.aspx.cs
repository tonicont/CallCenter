using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Application;
using CallCenter.CORE.Domain;
using CallCenter.DAO;

namespace CallCenter.Web.Admin
{
    public partial class IncidenciasList : System.Web.UI.Page
    {
        DBContext dbContext;
        IncidenciaService incidenciaService;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Creamos el contexto de datos y servicios
            dbContext = new DBContext("DefaultConnection");
            incidenciaService = new IncidenciaService(dbContext);

            //Bindeamos el ListView
            ListView1.DataSource = incidenciaService.GetAll().ToList();
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