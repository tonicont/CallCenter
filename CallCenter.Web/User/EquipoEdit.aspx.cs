using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.CORE.Domain;
using CallCenter.Application;
using CallCenter.DAO;

namespace CallCenter.Web.User
{
    public partial class EquipoEdit : System.Web.UI.Page
    {
        DBContext dbContext;
        EquipoService equipoService;
        TipoEquipoService tipoEquipoService;
        List<TipoEquipo> ListaTipos;
        Guid userId;
        Equipo equipoBD;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Creamos el contexto de datos y el servicio
            dbContext = new DBContext("DefaultConnection");
            equipoService = new EquipoService(dbContext);
            tipoEquipoService = new TipoEquipoService(dbContext);


            //Cogemos el Id que nos viene por la queryString, si no viene ninguno o erróneo se entiende que se quiere insertar
            //Si viene uno y es del usuario que está logueado es que se quiere modificar
            string idQueryString = Request.QueryString["Id"];
            Guid id;
            Guid.TryParse(idQueryString, out id);

            equipoBD = equipoService.GetById(id);

            //Obtenemos la lista de todos los tipos de equipo 
            List<String> Tipos = new List<String>();
            ListaTipos = tipoEquipoService.GetAlls().ToList();
            for (int i = 0; i < ListaTipos.Count; i++)
            {
                Tipos.Add(ListaTipos.ElementAt(i).Nombre);
            }
                

            if (!Page.IsPostBack)
            {
                if (equipoBD == null)
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Error: No se ha encontrado el registro para actualizar";
                }
                else
                {
                   
                    //Bindeamos la ListaTipo
                    Listatipo.DataSource = Tipos;
                    Listatipo.DataBind();
                    txtNombre.Text = equipoBD.Nombre;
                    txtDescripcion.InnerText = equipoBD.Descripcion;
                    Listatipo.SelectedValue = equipoBD.Tipo.Nombre;
                }
            }

            if (equipoBD == null)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Error: No se ha encontrado el registro para actualizar";
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            Equipo equipo = new Equipo()
            {
                Id = equipoBD.Id,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.InnerText,
                Tipo = ListaTipos.ElementAt(Listatipo.SelectedIndex)
            };

            equipoService.Update(equipo);
            lblResult.Text = "Datos actualizados";
        }
    }
}