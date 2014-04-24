using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using CallCenter.Application;
using CallCenter.DAO;
using CallCenter.CORE.Domain;

namespace CallCenter.Web.User
{
    public partial class EquiposList : System.Web.UI.Page
    {   
        DBContext dbContext;
        EquipoService equipoService;
        TipoEquipoService tipoEquipoService;
        List<TipoEquipo> ListaTipos;
        Guid userId;

        protected void Page_Load(object sender, EventArgs e)
        {   
            //Creamos el contexto de datos y el servicio
            dbContext = new DBContext("DefaultConnection");
            equipoService = new EquipoService(dbContext);
            tipoEquipoService = new TipoEquipoService(dbContext); 

            //Cogemos la información del usuario actual, en userId cogeremos su id o un guid vacio si no esta logueado
            MembershipUser user = Membership.GetUser();
            userId = user == null ? Guid.Empty : (Guid)user.ProviderUserKey; 
           

            //Bindeamos el ListView
            ListView1.DataSource = equipoService.GetByUserId(userId).ToList();
            ListView1.DataBind();

            //Obtenemos la lista de todos los tipos de equipo 
            List<String> Tipos = new List<String>();
            ListaTipos = tipoEquipoService.GetAlls().ToList();
            for (int i = 0; i < ListaTipos.Count; i++)
            {
                Tipos.Add(ListaTipos.ElementAt(i).Nombre);
            }

            if (!Page.IsPostBack)
            {
                //Bindeamos la ListaTipo
                Listatipo.DataSource = Tipos;
                Listatipo.DataBind();
            }
           
            
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            Equipo equipo = new Equipo()
            {
                Id = Guid.NewGuid(),
                Nombre = Nombre_nuevo.Text,
                Descripcion = Descripcion_nuevo.InnerText,
                Tipo = ListaTipos.ElementAt(Listatipo.SelectedIndex),
                UserId = userId
            };
            try
            {
                equipoService.Insert(equipo);
                Result.Text = "Equipo guardado correctamente";
                //Bindeamos el ListView
                ListView1.DataSource = equipoService.GetByUserId(userId).ToList();
                ListView1.DataBind();
                //Limpiamos los campos de texto
                Nombre_nuevo.Text = "";
                Descripcion_nuevo.InnerText = "";
                Listatipo.ClearSelection();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                Result.ForeColor = System.Drawing.Color.Red;
                Result.Text = "Error al guardar, verifique que no existe otro Equipo con el mismo ID";
            }
        }

        protected void Eliminar_Click(object sender, CommandEventArgs e)
        {
            try
            {
                equipoService.Delete(Guid.Parse(e.CommandArgument.ToString()));
                //Bindeamos el ListView
                ListView1.DataSource = equipoService.GetByUserId(userId).ToList();
                ListView1.DataBind();
                Result.Text = "Registro eliminado";
            }
            catch (Exception ex)
            {
                Result.ForeColor = System.Drawing.Color.Red;
                Result.Text = "No se puede eliminar éste registro. Asegurese de no tener una incidencia sobre éste equipo";
            }
        }
    }
}