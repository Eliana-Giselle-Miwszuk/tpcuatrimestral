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

        }

        protected void gvVeterinarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int id = Convert.ToInt32(e.CommandArgument);//Extraigo mi IdVeterinario de la fila seleccionada
                Response.Redirect($"EditarVeterinario.aspx?id={id}"); //Me voy a la vista EditarVeterinario y me llevo el ID del la fila seleccionada
            } else if (e.CommandName == "Eliminar")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                veterinarioNegocio.Delete(Id);
            }
            
            /*      else if (e.CommandName == "Delete")
            {
                int MascotaNro = Convert.ToInt16(e.CommandArgument);
                EliminarMascota(MascotaNro);
            }*/
        }
    }
}