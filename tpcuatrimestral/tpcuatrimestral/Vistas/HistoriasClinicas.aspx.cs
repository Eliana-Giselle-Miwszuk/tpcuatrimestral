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
    public partial class HistoriasClinicas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarHC();
        }

       private void CargarHC()
        {
            var negocioHc = new HistoriaClinicaNegocio();
            var Hc = negocioHc.ListarTodos();
            gdHC.DataSource = Hc;
            gdHC.DataBind();
        }

        protected void gdHC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "Eliminar")
            {
                int IdHC = Convert.ToInt32(e.CommandArgument);
                Eliminar(IdHC);
            }
            else if (e.CommandName == "Editar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditarHC.aspx?id={id}");
            }


        }
        private void Eliminar(int id)
        {
            try {
                var negocioHc = new HistoriaClinicaNegocio();
                bool PorOPorNo = negocioHc.EliminarHC(id);
                if (PorOPorNo)
                {
                    Debug.WriteLine("Barbaro");
                }
            } catch { }
        }

    }
}