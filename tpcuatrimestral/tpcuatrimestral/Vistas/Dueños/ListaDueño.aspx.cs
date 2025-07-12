using System;
using System.Web.UI;
using Negocio;
using Dominio;
using System.Diagnostics;

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

        protected void dgvDueños_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Eliminar")
            {
                
                int dniElegido = Convert.ToInt32(e.CommandArgument);
                eliminar(dniElegido);
            }
            else if (e.CommandName == "Editar")
            {
                int dniDueño = Convert.ToInt32(e.CommandArgument);
                //    Response.Redirect($"ModificarMascota.aspx?id={idMascota}");
                Response.Redirect($"EditarDueño.aspx?Dni={dniDueño}");

            }
        }
        private void eliminar(int dni)
        {
            try {
                var negocioDueño = new DueñoNegocio();
                bool fueEliminado = negocioDueño.EliminarDueño(dni);
                if (fueEliminado)
                {
                    Debug.WriteLine("TODO OK");
                    CargarDueños();
                }
                else
                {
                    Debug.WriteLine("Fallo algo ");
                }
            } catch { }
        }

        protected void dgvDueños_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            dgvDueños.PageIndex = e.NewPageIndex;
            CargarDueños();
        }
        /*   else if (e.CommandName == "Delete")
   {
       int MascotaNro = Convert.ToInt16(e.CommandArgument);
       EliminarMascota(MascotaNro);
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
}*/
    }
}