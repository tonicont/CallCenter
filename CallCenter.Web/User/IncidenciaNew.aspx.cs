using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CallCenter.Application;
using CallCenter.DAO;
using CallCenter.CORE.Domain;

namespace CallCenter.Web.User
{
    public partial class IncidenciaNew : System.Web.UI.Page
    {
        DBContext dbContext;
        EquipoService equipoService;
        IncidenciaService incidenciaService;
        Guid userId;
        List<Equipo> Equipos;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Creamos el contexto de datos y los servicios
            dbContext = new DBContext("DefaultConnection");
            equipoService = new EquipoService(dbContext);
            incidenciaService = new IncidenciaService(dbContext);

            //Cogemos la información del usuario actual, en userId cogeremos su id o un guid vacio si no esta logueado
            MembershipUser user = Membership.GetUser();
            userId = user == null ? Guid.Empty : (Guid)user.ProviderUserKey; 
            

            //Obtenemos la lista de todos los equipos del usuario actual
            Equipos = equipoService.GetByUserId(userId).ToList();
            //Obtenemos nos nombres de los equipos para mostrar en la ListaEquipos
            List<String> NombreEquipos = new List<string>();
            for (int i = 0; i < Equipos.Count; i++)
            {
                NombreEquipos.Add(Equipos.ElementAt(i).Nombre);
            }
            if (!Page.IsPostBack)
            {
                //Bindeamos la ListaEquipos
                ListaEquipos.DataSource = NombreEquipos;
                ListaEquipos.DataBind();
            }
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            Incidencia incidencia = new Incidencia()
            {
                Id = Guid.NewGuid(),
                Fecha = DateTime.Now,
                Equipo = Equipos.ElementAt(ListaEquipos.SelectedIndex),
                Descripcion = txtDescipcion.InnerText,
                UserId = userId,
                Estado = 0,
            };
            try
            {
                incidenciaService.Insert(incidencia);
                lblResult.Text = "Incidencia creada correctamente. Será atendida en breve.";
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Error al crear incidencia";
            }
        }
    }
}