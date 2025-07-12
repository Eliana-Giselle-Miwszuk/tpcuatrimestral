using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace tpcuatrimestral.Vistas.Turnos
{
    public partial class Turnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTurnos();
            }
        }

        private void CargarTurnos()
        {
            try
            {
                TurnoNegocio negocio = new TurnoNegocio();
                dgvTurnos.DataSource = negocio.Listar();
                dgvTurnos.DataBind();
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("~/ErrorPage.aspx", false);
            }
        }

        protected void dgvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect($"AgregarTurno.aspx?id={e.CommandArgument}");
            }
        }
    }
}