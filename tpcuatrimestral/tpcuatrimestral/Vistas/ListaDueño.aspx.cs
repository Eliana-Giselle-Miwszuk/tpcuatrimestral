using System;
using System.Web.UI;
using Negocio;
using Dominio;

namespace tpcuatrimestral.Vistas
{
    public partial class ListaDueño : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    CargarDueños();
                }
                catch (Exception ex)
                {
                    // Mostrar error amigable al usuario
                    Session["Error"] = ex.Message;
                    Response.Redirect("ErrorPage.aspx", false);
                }
            }
        }

        private void CargarDueños()
        {
            DueñoNegocio negocio = new DueñoNegocio();
            dgvDueños.DataSource = negocio.Listar();
            dgvDueños.DataBind();
        }
    }
}