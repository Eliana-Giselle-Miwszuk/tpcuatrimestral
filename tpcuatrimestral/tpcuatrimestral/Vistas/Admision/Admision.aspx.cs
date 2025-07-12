using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace tpcuatrimestral.Vistas.Admision
{
    public partial class Admision1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    CargarAdmisionistas();
                }
                catch (Exception ex)
                {
                    Session["Error"] = "Error al cargar admisionistas: " + ex.Message;
                    Response.Redirect("~/ErrorPage.aspx", false);
                }
            }
        }

        private void CargarAdmisionistas(string filtro = null)
        {
            AdmisionistaNegocio negocio = new AdmisionistaNegocio();
            var lista = negocio.Listar();

            if (!string.IsNullOrEmpty(filtro))
            {
                string filtroUpper = filtro.ToUpper(); // Optimización: convertir una sola vez
                lista = lista.Where(a =>
                    a.Nombre.ToUpper().Contains(filtroUpper) ||
                    a.Apellido.ToUpper().Contains(filtroUpper) ||
                    a.Dni.ToString().Contains(filtro)).ToList();
            }

            dgvAdmisionistas.DataSource = lista;
            dgvAdmisionistas.DataBind();
        }

        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarAdmisionistas(TxtFiltrar.Text.Trim());
            }
            catch (Exception ex)
            {
                Session["Error"] = "Error al filtrar: " + ex.Message;
                Response.Redirect("~/ErrorPage.aspx", false);
            }
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtFiltrar.Text = "";
            CargarAdmisionistas();
        }

        protected void dgvAdmisionistas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                AdmisionistaNegocio negocio = new AdmisionistaNegocio();

                switch (e.CommandName)
                {
                    case "Editar":
                        Response.Redirect($"EditarAdmisionista.aspx?id={id}");
                        break;
                    case "Eliminar":
                        // negocio.Eliminar(id);
                        CargarAdmisionistas();
                        break;
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = "Error al procesar comando: " + ex.Message;
                Response.Redirect("~/ErrorPage.aspx", false);
            }
        }

        protected void dgvAdmisionistas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvAdmisionistas.PageIndex = e.NewPageIndex;
            CargarAdmisionistas(TxtFiltrar.Text.Trim());
        }

        protected void dgvAdmisionistas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                // Personalizar encabezados si es necesario
            }
        }
    }
}