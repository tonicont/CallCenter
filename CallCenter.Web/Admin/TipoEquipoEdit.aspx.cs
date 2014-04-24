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
    public partial class TipoEquipoEdit : System.Web.UI.Page
    {
        DBContext dbcontext;
        TipoEquipoService tipoEquipoService;
        TipoEquipo tipoEquipoDB;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Creamos el contexto de datos y de servicio
            dbcontext = new DBContext("DefaultConnection");
            tipoEquipoService = new TipoEquipoService(dbcontext);

            if (!Page.IsPostBack)
            {
                //Cogemos el Id que nos viene por la queryString, si no viene ninguno o erróneo se entiende que se quiere insertar
                //Si viene uno y es del usuario que está logueado es que se quiere modificar
                string idQueryString = Request.QueryString["Id"];
                Guid id;
                Guid.TryParse(idQueryString, out id);

                tipoEquipoDB = tipoEquipoService.GetById(id);

                if (tipoEquipoDB == null)
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Error: No se encuentra el registro que quiere modificar";
                }
                else
                {
                    Id.Text = tipoEquipoDB.Id.ToString();
                    Nombre.Text = tipoEquipoDB.Nombre;
                    Descripcion.InnerText = tipoEquipoDB.Descripcion;
                }
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            TipoEquipo tipoEquipo = new TipoEquipo()
            {
                Id = Guid.Parse(Id.Text),
                Nombre = Nombre.Text,
                Descripcion = Descripcion.InnerText
            };
            tipoEquipoService.Update(tipoEquipo);
            lblResult.Text = "Datos actualizados";
        }
    }
}