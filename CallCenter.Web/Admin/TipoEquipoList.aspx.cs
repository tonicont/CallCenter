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
    public partial class TipoEquipoList : System.Web.UI.Page
    {
        DBContext dbcontext;
        TipoEquipoService tipoEquipoService;
        List<TipoEquipo> TiposEquipos;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Creamos el contexto de datos y de servicio
            dbcontext = new DBContext("DefaultConnection");
            tipoEquipoService = new TipoEquipoService(dbcontext);

            //Bindeamos el ListView
            TiposEquipos = tipoEquipoService.GetAlls().ToList();
            ListView1.DataSource = TiposEquipos;
            ListView1.DataBind();
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            TipoEquipo tipoEquipo = new TipoEquipo()
            {
                Id = Guid.NewGuid(),
                Nombre = Nombre_nuevo.Text,
                Descripcion = Descripcion_nuevo.InnerText
            };
            try
            {
                tipoEquipoService.Insert(tipoEquipo);
                Result.Text = "Tipo de equipo insertado correctamente";
                ListView1.DataSource = tipoEquipoService.GetAlls().ToList();
                ListView1.DataBind();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                Result.ForeColor = System.Drawing.Color.Red;
                Result.Text = "Error al guardar, verifique que no existe otro Tipo de Dispositivo con el mismo ID";
            }
        }

        protected void Eliminar_Click(object sender, CommandEventArgs e)
        {
            try
            {
               
                tipoEquipoService.Delete(Guid.Parse(e.CommandArgument.ToString()));
                ListView1.DataSource = tipoEquipoService.GetAlls().ToList();
                ListView1.DataBind();
            }
            catch (Exception ex)
            {
                Result.ForeColor = System.Drawing.Color.Red;
                Result.Text = "No se puede eliminar éste registro";
            }
            
        }
    }
}