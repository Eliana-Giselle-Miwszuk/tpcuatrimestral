using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
namespace tpcuatrimestral.Vistas.Mascotas
{
    public partial class EditarMascota : System.Web.UI.Page
    {
        Validaciones validacion = new Validaciones();
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
                    Response.Redirect("~/Vistas/Mascotas/ListarMascotas.aspx");
                }
                if (lblCartel == null)
                {
                    Response.Write("lblCartel está null 😵");
                }
                else
                {
                    Response.Write("lblCartel está vinculado ✅");
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
                Response.Redirect("~/Vistas/Mascotas/ListarMascotas.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string NroHC = txtNombre.Text;
                Decimal pesito = Decimal.Parse(txtPeso.Text);

                if (validacion.DecimalNoNegativo(pesito) == false)
                {

                    lblCartel.Text = "ERROR PESO TIENE QUE SER POSITIVO";
                    return;
                }
                if (validacion.ParametrosNoVacio(new string[] { NroHC }) == false)
                {
                    lblCartel.Text = "NO DEJAR CAMPOS EN BLANCO/VACIO";//que rico un buen vacio
                    return;
                }
                var mascota = new Mascota
                {
                    NroHistoriaClinica = Convert.ToInt32(Request.QueryString["id"]),
                    Nombre = txtNombre.Text,
                    Peso = Convert.ToDecimal(txtPeso.Text)
                };

                var negocio = new MascotaNegocio();
                negocio.ActualizarMascota(mascota);

                Response.Redirect("~/Vistas/Mascotas/ListarMascotas.aspx");

            }
            catch (Exception)
            {

                Response.Redirect("~/Vistas/Mascotas/ListarMascotas.aspx");

            }
        }

    }
}