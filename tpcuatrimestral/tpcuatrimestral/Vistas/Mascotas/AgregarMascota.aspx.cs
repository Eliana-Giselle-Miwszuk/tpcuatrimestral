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
               // CargarDueños();
                CargarRazas();
            }
        }
       /* private void CargarDueños()
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
        }*/
        /*----------------*///BUSCAR POR DNI
        protected void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscarDNI.Text))
            {
                if (long.TryParse(txtBuscarDNI.Text, out long dni))
                {
                    DueñoNegocio negocio = new DueñoNegocio();
                    Dueño dueño = negocio.BuscarPorDNI(dni);

                    if (dueño != null)
                    {
                        // Mostrar nombre y apellido en los TextBox
                        txtNombreDueño.Text = dueño.Nombre;
                        txtApellidoDueño.Text = dueño.Apellido;

                        // Guardar el ID del dueño en el campo oculto
                        hdnIdDueño.Value = dueño.IdDueño.ToString();

                        lblResultadoBusqueda.Text = "Dueño encontrado";
                        lblResultadoBusqueda.CssClass = "text-success small";
                    }
                    else
                    {
                        lblResultadoBusqueda.Text = "No se encontró un dueño con ese DNI";
                        lblResultadoBusqueda.CssClass = "text-danger small";
                        // Limpiar campos si no se encuentra
                        txtNombreDueño.Text = "";
                        txtApellidoDueño.Text = "";
                        hdnIdDueño.Value = ""; // Limpiar el ID también
                    }
                }
                else
                {
                    lblResultadoBusqueda.Text = "Ingrese un DNI válido";
                    lblResultadoBusqueda.CssClass = "text-danger small";
                }
            }
        }
        /*----------------*/


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
                // Obtener el ID del dueño del campo oculto en lugar del DropDownList
                string idDueño = hdnIdDueño.Value;
                string iDRaza = DdlRaza.SelectedValue.ToString();
                string nombre = TxtNombre.Text;
                string sexo = DdlSexo.SelectedValue;
                string color = TextColor.Text;
                Decimal peso = Convert.ToDecimal(TextPeso.Text);

                if (validacion.ParametrosNoVacio(new string[] { idDueño, iDRaza, nombre, sexo, color }) == false)
                {
                    lblValidacion.Text = "ERROR CAMPOS OBLIGATORIOS";
                    return;
                }

                if (validacion.DecimalNoNegativo(peso) == false)
                {
                    lblValidacion.Text = "PESO DEBE SER POSITIVO";
                    return;
                }

                try
                {
                    Mascota mascota = new Mascota
                    {
                        IDDueño = Convert.ToInt32(idDueño), // Usar el ID del campo oculto
                        IDRaza = Convert.ToInt32(DdlRaza.SelectedValue),
                        Nombre = TxtNombre.Text,
                        Sexo = DdlSexo.SelectedValue,
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                // Redirige a la página de listado en la misma carpeta
                Response.Redirect("~/Vistas/Mascotas/ListarMascotas.aspx");
            }
            catch (Exception ex)
            {
                // Opcional: Mostrar mensaje de error
                lblValidacion.Text = "Error al cancelar: " + ex.Message;
                lblValidacion.CssClass = "text-danger";
                lblValidacion.Visible = true;
            }
        }


    }
}