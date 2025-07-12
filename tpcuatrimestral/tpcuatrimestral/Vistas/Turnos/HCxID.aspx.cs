using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
namespace tpcuatrimestral.Vistas.Turnos
{
    public partial class HCxID : System.Web.UI.Page
    {
        private HistoriaClinicaNegocio hcnegocio = new HistoriaClinicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["nroHC"] != null)
                {
                    int nroHC;
                    if (int.TryParse(Request.QueryString["nroHC"], out nroHC))
                    {
                        CargarGridSegunNROrecibido(nroHC);
                    }
                    else
                    {
                        // Manejar error de parámetro inválido
                        MostrarMensaje("Número de historia clínica inválido");
                    }
                }
                else
                {
                    // Redirigir si no se recibió el parámetro
                    Response.Redirect("~/Vistas/Turnos/Almaneque.aspx");
                }
            }
        }
        private void CargarGridSegunNROrecibido(int nroHC)
        {
            try
            {
                List<HistoriaClinica> historias = hcnegocio.ListarPorMascota(nroHC);

                if (historias.Count > 0)
                {
                    gdvHCxID.DataSource = historias;
                    gdvHCxID.DataBind();
                    ConfigurarGridView();
                }
                else
                {
                    MostrarMensaje($"No se encontraron historias clínicas para el número {nroHC}");
                    gdvHCxID.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar historias clínicas: {ex.Message}");
            }
        }
        private void ConfigurarGridView()
        {
            gdvHCxID.HeaderRow.TableSection = TableRowSection.TableHeader;
            gdvHCxID.GridLines = GridLines.None;
            gdvHCxID.CssClass = "table table-striped table-bordered";
        }

        private void MostrarMensaje(string mensaje)
        {
            // Puedes implementar esto según tu estructura de página
            // Ejemplo: usando un Label o un control de mensajes
            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                $"alert('{mensaje}');", true);
        }
    }
}