using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace tpcuatrimestral.Vistas
{

    public partial class ListarMascotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMascotas();
                MostrarMensajes();
            }
        }

        protected void gdMascotas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int nroHistoria = Convert.ToInt32(gdMascotas.DataKeys[e.RowIndex].Value);
                MascotaNegocio negocio = new MascotaNegocio();

               /* if (negocio.Eliminar(nroHistoria))
                {
                    CargarMascotas();
                    MostrarMensaje("Mascota eliminada correctamente", "success");
                }
                else
                {
                    MostrarMensaje("No se pudo eliminar la mascota", "error");
                }*/
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al eliminar: {ex.Message}", "error");
            }
        }

        protected void CargarMascotas()
        {
            try
            {
                MascotaNegocio negocio = new MascotaNegocio();
                var resultado = negocio.ListarMascotas();

           

                gdMascotas.DataSource = resultado;
                gdMascotas.DataBind();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar mascotas: {ex.Message}", "error");
            }
        }

        protected void gdMascotas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string idMascota = e.CommandArgument.ToString();
               
                Response.Redirect($"ModificarMascota.aspx?id={idMascota}");
            }
            else if (e.CommandName == "Delete")
            {
                int MascotaNro = Convert.ToInt16(e.CommandArgument);
                EliminarMascota(MascotaNro);
                CargarMascotas();
            }

        }
        protected void EliminarMascota(int nro)
        {
            try
            {
                var negocio = new MascotaNegocio();
                bool eliminacion = negocio.EliminarMasco(nro);
                if (eliminacion)
                {
                    Console.WriteLine("Chau masco");
                }
            }
            catch { }
        }
   
        protected void BtnAplicarFiltro_Click(object sender, EventArgs e)
        {
            CargarMascotas();
        }

        private void MostrarMensajes()
        {
            if (Request.QueryString["success"] != null)
            {
                MostrarMensaje(Request.QueryString["success"], "success");
            }
            if (Request.QueryString["error"] != null)
            {
                MostrarMensaje(Request.QueryString["error"], "error");
            }
        }

        private void MostrarMensaje(string mensaje, string tipo)
        {
            string cssClass = tipo == "success" ? "alert-success" : "alert-danger";
            string script = $@"
                $(document).ready(function() {{
                    $('<div class=""alert {cssClass} alert-dismissible fade show"" role=""alert"">' +
                      '{mensaje.Replace("'", "\\'")}' +
                      '<button type=""button"" class=""close"" data-dismiss=""alert"">' +
                      '<span>&times;</span></button></div>')
                      .prependTo('.container').delay(5000).fadeOut();
                }});";

            ClientScript.RegisterStartupScript(this.GetType(), "showMessage", script, true);
        }

        protected void gdMascotas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdMascotas.PageIndex = e.NewPageIndex;
            CargarMascotas();
        }
    }
}