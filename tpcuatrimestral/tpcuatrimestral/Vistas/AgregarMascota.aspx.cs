using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace tpcuatrimestral.Vistas
{
    public partial class AgregarMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDueños();
                CargarRazas();
            }
        }
        private void CargarDueños()
        {
            try
            {
                DueñoNegocio negocio = new DueñoNegocio();
                var dueños = negocio.ListarDueñosActivos();

                DdlDueño.DataSource = dueños;
                DdlDueño.DataTextField = "Value";
                DdlDueño.DataValueField = "Key";
                DdlDueño.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void CargarRazas()
        {
            try
            {
                RazaNegocio negocio = new RazaNegocio();
                var razas = negocio.ListarRazasActivas();

                DdlRaza.DataSource = razas;
                DdlRaza.DataTextField = "Value";
                DdlRaza.DataValueField = "Key";
                DdlRaza.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected void BtnGuardarMascota_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Mascota mascota = new Mascota
                    {
                        IDDueño = Convert.ToInt32(DdlDueño.SelectedValue),
                        IDRaza = Convert.ToInt32(DdlRaza.SelectedValue),
                        Nombre = TxtNombre.Text,
                        Sexo = TextSexo.Text,
                        Color = TextColor.Text,
                        Peso = Convert.ToDecimal(TextPeso.Text),
                        FechaRegistro = DateTime.Now,
                        Activo = true
                    };

                    MascotaNegocio negocio = new MascotaNegocio();
                    int id = negocio.AgregarMascota(mascota);

                   
                    Response.Redirect("Mascotas.aspx?success=1");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}