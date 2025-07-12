using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpcuatrimestral
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (!IsPostBack)
            {
                VerificarSesion();
            }
        }
        private void VerificarSesion()
        {
            if (Session["UsuarioAutenticado"] != null && (bool)Session["UsuarioAutenticado"])
            {
                
                lblNombreUsuario.Text = Session["NombreUsuario"]?.ToString() ?? "Usuario";
                lblTipoUsuario.Text   = Session["TipoUsuario"]?.ToString() ?? "Rol";
                if (Session["UsuMaster"] is true) 
                {
                    lblUsuMaster.Text = "Usuario Maestro";
                }
                else
                {
                    lblUsuMaster.Text = "";
                }
                
            }
            else
            {
                // Redirigir a login si no hay sesión
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // 1. Limpiar todas las variables de sesión
            Session.Clear();

            // 2. Abandonar la sesión del servidor
            Session.Abandon();

            // 3. Redirigir al login (sin manipular cookies)
            Response.Redirect("~/Default.aspx");
        }

    }
}