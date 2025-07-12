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
        //mi acoplamiento puessss
        Validaciones validacion = new Validaciones();
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
                string id = DdlDueño.SelectedValue.ToString();
                string iDRaza = (DdlRaza.SelectedValue).ToString();
                string nombre = TxtNombre.Text;
                string sexo = TextSexo.Text;
                string color = TextColor.Text;
                Decimal peso = Convert.ToDecimal(TextPeso.Text);
                if (validacion.ParametrosNoVacio(new string[] { id,iDRaza,nombre,sexo,color })==false)
                {
                    lblValidacion.Text = "ERROR CAMPOS OBLIGATORIOS";
                    return;
                }
                if (validacion.DecimalNoNegativo(peso)==false)
                {
                    lblValidacion.Text = "PESO DEBE SER POSITIVO";
                    return;
                }
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
                    int idRegistrado = negocio.AgregarMascota(mascota);

                   
                    Response.Redirect("~/Vistas/Mascotas/ListarMascotas.aspx");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}