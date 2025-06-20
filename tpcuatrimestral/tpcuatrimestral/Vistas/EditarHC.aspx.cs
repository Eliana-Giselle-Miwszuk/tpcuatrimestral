using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpcuatrimestral.Vistas
{
    public partial class EditarHC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"], out int idRegistro))
                {
                    CargarHC(idRegistro);
                }
                else
                {
                    Response.Redirect("HistoriasClinicas.aspx");
                }
            }

        }
        private void CargarHC(int idRegistro)
        {
            var negocio = new HistoriaClinicaNegocio();
            var hc = negocio.ObtenerPorID(idRegistro);

            if (hc != null)
            {
                txtSintoma.Text = hc.Sintomas;
                txtDiagnostico.Text = hc.Diagnostico;
                txtTratamiento.Text = hc.Tratamiento;
                Medicacion.Text = hc.Medicacion;
                txtObervacion.Text = hc.Observaciones;
            }
            else
            {
                Response.Redirect("HistoriasClinicas.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idRegistro = Convert.ToInt32(Request.QueryString["id"]);

                var hc = new HistoriaClinica
                {
                    IDRegistro = idRegistro,
                    Sintomas = txtSintoma.Text,
                    Diagnostico = txtDiagnostico.Text,
                    Tratamiento = txtTratamiento.Text,
                    Medicacion = Medicacion.Text,
                    Observaciones = txtObervacion.Text
                };

                var negocio = new HistoriaClinicaNegocio();
                negocio.ActualizarHC(hc);

                Response.Redirect("HistoriasClinicas.aspx");
            }
            catch
            {
                
                Response.Redirect("HistoriasClinicas.aspx");
            }

        }
    }
}