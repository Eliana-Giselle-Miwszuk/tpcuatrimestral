using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace tpcuatrimestral.Vistas
{
    public partial class AgregarDueño : System.Web.UI.Page
    {
        DueñoNegocio negocioD = new DueñoNegocio();
        Validaciones validacion = new Validaciones();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*protected void BtnGuardarMascota_Click(object sender, EventArgs e)
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
        }*/
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string _dni = txtDni.Text.Trim(); 
                    string _apellido = txtApellido.Text.Trim();
                    string _nombre = txtNombre.Text.Trim();
                    string _direccion = txtDireccion.Text.Trim();
                    string _telefono = txtTelefono.Text.Trim();
                    string _email = txtEmail.Text.Trim();

                    if (!validacion.ParametrosNoVacio(new string[] { _dni, _apellido, _nombre, _direccion, _telefono, _email }))
                    {
                        lblCartel.Text = "FALTAN LLENAR CAMPOS.";
                        return;
                    }

                    if (!long.TryParse(_dni, out long dni) || !long.TryParse(_telefono, out long telefono))
                    {
                        lblCartel.Text = "DNI O TELÉFONO NO VÁLIDO.";
                        return;
                    }

                    // Validar valores no negativos
                    if (dni < 0 || telefono < 0)
                    {
                        lblCartel.Text = "DNI O TELÉFONO NO PUEDEN SER NEGATIVOS.";
                        return;
                    }
                    if (!validacion.EsEmailValido(_email))  
                    {
                        lblCartel.Text = "FORMATO INCORRECTO EN EMAIL.";
                        return;
                    }

                    Dueño dueño = new Dueño
                    {
                        Dni = dni,
                        Apellido = _apellido,
                        Nombre = _nombre,
                        Direccion = _direccion,
                        Telefono = telefono,
                        email = _email
                    };

                    int id = negocioD.InsertarDueño(dueño);
                    if (id > 0)
                    {
                        Response.Redirect("~/Vistas/Dueños/ListaDueño.aspx", false); 
                    }
                    else
                    {
                        lblCartel.Text = "NO SE PUDO REGISTRAR EL DUEÑO.";
                    }
                }
                catch (Exception ex)
                {
                 
                    lblCartel.Text = "ERROR: " + ex.Message;
                    Debug.WriteLine(ex.ToString()); 
                }
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDni.Text = string.Empty;
        }
    }
}