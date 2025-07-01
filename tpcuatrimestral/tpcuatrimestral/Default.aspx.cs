using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tpcuatrimestral
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlError.Visible = false;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario    = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MostrarError("Por favor complete todos los campos");
                return;
            }

            try
            {
                var usuarioNegocio = new UsuarioNegocio();
                Usuario user = usuarioNegocio.ValidarUsuario(usuario, contrasena);

                if (user != null)
                {
                    // Configurar variables de sesión
                    Session["UsuarioAutenticado"] = true;
                    Session["UserId"]             = user.IdUsuario;
                    Session["NombreUsuario"]      = user.NombreUsuario;
                    Session["TipoUsuario"]        = user.TipoUsuario;
                    Session["UsuMaster"]          = user.UsuMaster;

                    // Redirigir según tipo de usuario
                    RedirigirSegunTipoUsuario(user.TipoUsuario);
                }
                else
                {
                    MostrarError("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al iniciar sesión: " + ex.Message);
            }
        }

        private void RedirigirSegunTipoUsuario(string tipoUsuario)
        {
            switch (tipoUsuario)
            {
                case "Veterinario":
                    if (Convert.ToInt32(Session["UsuMaster"]) == 1) 
                    {
                        Response.Redirect("~/Vistas/Inicio.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Vistas/InicioVete.aspx");
                    }
                        break;
                case "Admisionista":
                    if (Convert.ToInt32(Session["UsuMaster"]) == 1)
                    {
                        Response.Redirect("~/Vistas/Inicio.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Vistas/Admision/PanelAdmision.aspx");
                    }
                        break;
                default:
                    MostrarError("Tipo de usuario no reconocido");
                    break;
            }
        }

        private void MostrarError(string mensaje)
        {
            litError.Text = mensaje;
            pnlError.Visible = true;
        }
    }
}