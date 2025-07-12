using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpcuatrimestral.Vistas.Turnos
{
    public partial class Almaneque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviarFecha_Click(object sender, EventArgs e)
        {
            try
            {
                if (Calendario.SelectedDate != DateTime.MinValue)
                {
                    DateTime fechaSeleccionada = Calendario.SelectedDate;
                    Session["FechaSeleccionada"] = fechaSeleccionada;

                    if (Session["TipoUsuario"] != null)
                    {
                        string tipoUsuario = Session["TipoUsuario"].ToString();

                        switch (tipoUsuario)
                        {
                            case "Veterinario":
                                Response.Redirect("TurnosXFechaVete.aspx");
                                break;
                            case "Admisionista": 
                                Response.Redirect("TurnosXFechaRecep.aspx");
                                break;
                            default:
                                lblMensajeError.Text = "Su tipo de usuario no tiene acceso a esta funcionalidad.";
                                break;
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx"); 
                    }
                }
                else
                {
                   
                    lblMensajeError.Text = "Por favor, seleccione una fecha del calendario.";
                }
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Ha ocurrido un error inesperado. Por favor, inténtelo de nuevo. Detalles: " + ex.Message;
            }
        }
    }
}