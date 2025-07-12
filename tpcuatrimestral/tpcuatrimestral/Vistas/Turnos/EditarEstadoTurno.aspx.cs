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
    public partial class EditarEstadoTurno : System.Web.UI.Page
    {
        private TurnoNegocio turnoNegocio = new TurnoNegocio();
        private int idTurno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoUsuario"]?.ToString() != "Admisionista")
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Request.QueryString["idTurno"] != null && int.TryParse(Request.QueryString["idTurno"], out idTurno))
                {
                    CargarDatosTurno(idTurno);
                    CargarEstadosTurno();
                }
                else
                {
                    MostrarError("No se ha especificado un turno válido");
                    btnGuardar.Enabled = false;
                }
            }
        }
        private void CargarDatosTurno(int idTurno)
        {
            try
            {
                Turno turno = turnoNegocio.GetId(idTurno);
                if (turno != null)
                {
                    txtIdTurno.Text = turno.IdTurno.ToString();
                    // Aquí podrías cargar más datos del turno si los necesitas mostrar
                }
                else
                {
                    MostrarError("No se encontró el turno especificado");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar los datos del turno: " + ex.Message);
            }
        }

        private void CargarEstadosTurno()
        {
            try
            {
                List<EstadoTurno> estados = turnoNegocio.ListarEstadoTurnos();

                ddlEstadoTurno.DataSource = estados;
                ddlEstadoTurno.DataTextField = "TipoEstado";
                ddlEstadoTurno.DataValueField = "IDEstadoTurno";
                ddlEstadoTurno.DataBind();

                // Seleccionar el estado actual del turno
                if (int.TryParse(Request.QueryString["idTurno"], out idTurno))
                {
                    Turno turno = turnoNegocio.ObtenerTurnoPorId(idTurno);
                    if (turno != null)
                    {
                        ddlEstadoTurno.SelectedValue = turno.IdEstadoTurno.ToString();
                    }
                }

                // Agregar un ítem por defecto si es necesario
                if (ddlEstadoTurno.Items.Count == 0)
                {
                    ddlEstadoTurno.Items.Insert(0, new ListItem("-- Seleccione Estado --", "0"));
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar los estados de turno: " + ex.Message);
                // Registrar el error en un log si es necesario
            }
        }
        private void MostrarError(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = "alert alert-danger";
            lblMensaje.Visible = true;
        }

        private void MostrarMensajeExito(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = "alert alert-success";
            lblMensaje.Visible = true;
            btnGuardar.Enabled = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtIdTurno.Text, out idTurno) &&
                    int.TryParse(ddlEstadoTurno.SelectedValue, out int nuevoEstado))
                {
                    turnoNegocio.ActualizarEstadoTurno(idTurno, nuevoEstado);
                    MostrarMensajeExito("Estado del turno actualizado correctamente");
                }
                else
                {
                    MostrarError("Datos inválidos para actualizar el estado");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar el estado del turno: " + ex.Message);
            }
        }
    }
}