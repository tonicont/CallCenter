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
    public partial class IncidenciaView : System.Web.UI.Page
    {
        DBContext dbContext;
        IncidenciaService incidenciaService;
        Guid id;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Creamos el contexto de datos y los servicios
            dbContext = new DBContext("DefaultConnection");
            incidenciaService = new IncidenciaService(dbContext);

            //Cogemos el Id que nos viene por la queryString, si no viene ninguno o erróneo se entiende que se quiere insertar
            //Si viene uno y es del usuario que está logueado es que se quiere modificar
            string idQueryString = Request.QueryString["Id"];
            Guid.TryParse(idQueryString, out id);

            Incidencia incidenciaBD = incidenciaService.GetById(id);

            //Bindeamos los datos
            lblEstado.Text = incidenciaBD.Estado.ToString();
            lblId.Text = incidenciaBD.Id.ToString();
            lblFecha.Text = incidenciaBD.Fecha.ToString();
            lblEquipo.Text = incidenciaBD.Equipo.Nombre;
            lblDescripcionEquipo.Text = incidenciaBD.Equipo.Descripcion;
            lblProblema.Text = incidenciaBD.Descripcion;

            if (!Page.IsPostBack)
            {
                //Obtenemos los mensajes de la incidencia y bindeamos el Listview1
                List<Mensaje> Mensajes = incidenciaService.GetMensajes(id).ToList();
                ListView1.DataSource = Mensajes;
                ListView1.DataBind();
                
               
            }
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            //Cogemos la información del usuario actual, en userId cogeremos su id o un guid vacio si no esta logueado
            MembershipUser user = Membership.GetUser();
            Guid userId = user == null ? Guid.Empty : (Guid)user.ProviderUserKey;
            
            Mensaje mensaje = new Mensaje()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Fecha = DateTime.Now,
                Texto = txtMensaje.InnerText,
                IncidenciaId = id
            };
            try
            {
                incidenciaService.AddMensaje(id, mensaje);
            }
            catch (Exception ex)
            {
                lblResult.Text = "Error al enviar el mensaje";
            }

            //Obtenemos los mensajes de la incidencia y bindeamos el Listview1
            List<Mensaje> Mensajes = incidenciaService.GetMensajes(id).ToList();
            ListView1.DataSource = Mensajes;
            ListView1.DataBind();
        }
    }
}