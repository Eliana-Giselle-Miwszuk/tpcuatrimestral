using System;
using System.Web.UI;
using Dominio;
using Negocio;

namespace tpcuatrimestral.Vistas
{
    public partial class EditarMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int nroHistoriaClinica = Convert.ToInt32(Request.QueryString["id"]);
                    CargarDatosMascota(nroHistoriaClinica);
                }
                else
                {
                    Response.Redirect("Mascotas.aspx");
                }
            }
        }

        private void CargarDatosMascota(int nroHistoriaClinica)
        {
            var negocio = new MascotaNegocio();
            var mascota = negocio.ObtenerPorNroHistoria(nroHistoriaClinica);

            if (mascota != null)
            {
                txtNombre.Text = mascota.Nombre;
                txtPeso.Text = mascota.Peso.ToString();
            }
            else
            {
                Response.Redirect("Mascotas.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var mascota = new Mascota
                {
                    NroHistoriaClinica = Convert.ToInt32(Request.QueryString["id"]),
                    Nombre = txtNombre.Text,
                    Peso = Convert.ToDecimal(txtPeso.Text)
                };

                var negocio = new MascotaNegocio();
                negocio.ActualizarMascota(mascota);

                Response.Redirect("Mascotas.aspx");
            }
            catch (Exception)
            {
                
                Response.Redirect("Mascotas.aspx");
            }
        }
    }
}
