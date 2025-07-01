using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace tpcuatrimestral.Vistas.Veterinarios
{
    public partial class Veterinarios : System.Web.UI.Page
    {
        VeterinarioNegocio negocio = new VeterinarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridview();
            }
        }

        protected void CargarGridview()
        {


            gvVeterinarios.DataSource = negocio.Listar();
            gvVeterinarios.DataBind();

        }

        protected void gvVeterinarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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
                negocio.Delete(Id); 
                CargarGridview(); 
            }
        }
    }
}
