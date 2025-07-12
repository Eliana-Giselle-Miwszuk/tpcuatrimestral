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
    public partial class TurnosXFechaVete : System.Web.UI.Page
    {
        private VeterinarioNegocio veteNegocio = new VeterinarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["FechaSeleccionada"] != null)
                {
                    DateTime fechaSeleccionada = (DateTime)Session["FechaSeleccionada"];
                    lblFecha.Text = fechaSeleccionada.ToShortDateString();

                    CargarGdvSegunFechaRecibida(fechaSeleccionada);
                }
                else
                {
                    Response.Redirect("Almaneque.aspx");
                }
            }
        }
        private void CargarGdvSegunFechaRecibida(DateTime fechaRecibida)
        {
            try
            {
                VeterinarioNegocio negocio = new VeterinarioNegocio();
                List<Turno> listaTurnos = negocio.ObtenerTurnosPorFecha(fechaRecibida);

                if (listaTurnos.Count > 0)
                {
                    gdvTurnoXFecha.DataSource = listaTurnos;
                    gdvTurnoXFecha.DataBind();
                }
                else
                {
                  
                    lblMensaje.Text = "No hay turnos programados para esta fecha.";
                    gdvTurnoXFecha.Visible = false;
                }
            }
            catch (Exception ex)
            {
               
                lblMensaje.Text = "Error al cargar los turnos: " + ex.Message;
            }
        }
        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarHC")
            {
                int nroHC = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"HCxID.aspx?nroHC={nroHC}");
            }
        }
       

    }
}