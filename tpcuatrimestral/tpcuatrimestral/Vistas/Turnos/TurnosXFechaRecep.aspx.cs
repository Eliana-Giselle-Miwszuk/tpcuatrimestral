using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
namespace tpcuatrimestral.Vistas.Turnos
{
    public partial class TurnosXFechaRecep : System.Web.UI.Page
    {
        private TurnoNegocio turnoNegocio = new TurnoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoUsuario"]?.ToString() != "Admisionista")
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["FechaSeleccionada"] != null)
                {
                    DateTime fechaSeleccionada = (DateTime)Session["FechaSeleccionada"];
                    lblFecha.Text = fechaSeleccionada.ToShortDateString();
                    cargarTurnoSegunFechaRecibida(fechaSeleccionada);
                }
                else
                {
                    Response.Redirect("Almaneque.aspx");
                }
            }
        }
        protected void gridXfecha_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarEstado")
            {
                int idTurno = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditarEstadoTurno.aspx?idTurno={idTurno}", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        private void cargarTurnoSegunFechaRecibida(DateTime fechaRecibida)
        {
            try
            {
                VeterinarioNegocio negocio = new VeterinarioNegocio();
                List<Turno> listaTurnos = negocio.ObtenerTurnosPorFecha(fechaRecibida);

                if (listaTurnos.Count > 0)
                {
                    gridXfecha.DataSource = listaTurnos;
                    gridXfecha.DataBind();
                }
                else
                {

                    lblMensaje.Text = "No hay turnos programados para esta fecha.";
                    gridXfecha.Visible = false;
                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error al cargar los turnos: " + ex.Message;
            }
        }
    }
}