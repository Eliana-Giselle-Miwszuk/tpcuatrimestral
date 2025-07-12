using System;
using System.Web.UI;
using Dominio;
using Negocio;

namespace tpcuatrimestral.Vistas
{
    public partial class ModificarMascota : System.Web.UI.Page
    {
        //ACOPLAMIENTO
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
                    Response.Redirect("ListarMascotas.aspx");
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
                Response.Redirect("Mascotas.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string NroHC = txtNombre.Text;
                decimal pesito = decimal.Parse(txtPeso.Text);

                if (!validacion.DecimalNoNegativo(pesito))
                {
                    lblCartel.Text = "ERROR: el peso tiene que ser positivo.";
                    return;
                }

                if (!validacion.ParametrosNoVacio(new string[] { NroHC }))
                {
                    lblCartel.Text = "NO DEJAR CAMPOS EN BLANCO/VACÍO.";
                    return;
                }

                var mascota = new Mascota
                {
                    NroHistoriaClinica = Convert.ToInt32(Request.QueryString["id"]),
                    Nombre = txtNombre.Text,
                    Peso = pesito
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