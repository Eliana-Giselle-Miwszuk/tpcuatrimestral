using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Diagnostics;

namespace tpcuatrimestral.Vistas
{
    public partial class ListarVeterinarios : System.Web.UI.Page
    {
        VeterinarioNegocio veterinarioNegocio = new VeterinarioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridview();
            }
        }

        protected void CargarGridview()
        {
            gvVeterinarios.DataSource = veterinarioNegocio.Listar();
            gvVeterinarios.DataBind();
        }

        protected void gvVeterinarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Implementación si es necesaria
        }

        protected void gvVeterinarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditarVeterinario.aspx?id={id}");
            }
            else if (e.CommandName == "Eliminar")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                veterinarioNegocio.Delete(Id);
                CargarGridview();
            }
            else if (e.CommandName == "Agenda")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"AgendaVetenaria.aspx?id={id}");
            }
            else if (e.CommandName == "GenerarAgenda")
            {
                int idVeterinario = Convert.ToInt32(e.CommandArgument);
                GenerarAgendaBasica(idVeterinario);
            }
        }


        protected void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();

                if (!string.IsNullOrEmpty(nombre))
                {
                    List<Veterinario> listaVeterinarios = veterinarioNegocio.BuscarPorNombre(nombre);

                    if (listaVeterinarios.Count > 0)
                    {
                        gvVeterinarios.DataSource = listaVeterinarios;
                        gvVeterinarios.DataBind();
                        lblMensaje.Text = string.Empty;
                    }
                    else
                    {
                        gvVeterinarios.DataSource = null;
                        gvVeterinarios.DataBind();
                        lblMensaje.Text = "No se encontraron veterinarios con ese nombre.";
                        lblMensaje.CssClass = "alert alert-info";
                    }
                }
                else
                {
                    lblMensaje.Text = "Por favor ingrese un nombre para buscar.";
                    lblMensaje.CssClass = "alert alert-warning";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar veterinarios: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        protected void gvVeterinarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVeterinarios.PageIndex = e.NewPageIndex;
            CargarGridview();
        }

        protected void GenerarAgendaBasica(int idVeterinario)
        {
            try
            {
                HorarioNegocio horarioNegocio = new HorarioNegocio();

                // Verificar si ya existe un horario para este veterinario
                if (horarioNegocio.ExisteHorarioParaVeterinario(idVeterinario))
                {
                    lblMensaje.Text = "Este veterinario ya tiene una agenda configurada.";
                    lblMensaje.CssClass = "alert alert-warning";
                    Debug.WriteLine("ID VETE Lista 1: " + idVeterinario);
                }
                else
                {
                    // Generar horario básico
                    if (horarioNegocio.GenerarHorarioBasico(idVeterinario))
                    {
                        lblMensaje.Text = "Agenda básica generada exitosamente (Lunes a Viernes de 9:00 a 17:00).";
                        lblMensaje.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo generar la agenda básica.";
                        lblMensaje.CssClass = "alert alert-danger";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al generar agenda: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
            finally
            {
                CargarGridview();
            }
        }
    }
}