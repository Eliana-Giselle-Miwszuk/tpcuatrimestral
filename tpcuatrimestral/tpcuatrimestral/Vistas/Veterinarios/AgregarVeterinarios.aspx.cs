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
    public partial class ListaVeterinarios : System.Web.UI.Page
    {
        //Acoplamientoss puessss
        Validaciones validacion = new Validaciones();
        VeterinarioNegocio veteNegocio = new VeterinarioNegocio();
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarEspecialidades();
                CargarUsuarios();
            }

        }

        private void CargarUsuarios()
        {
            try
            {
                List<Usuario> usuarios = usuarioNegocio.ObtenerUsuarios();

                ddlIdUsuario.DataSource = usuarios;
                ddlIdUsuario.DataTextField = "nombreUsuario"; // Cambiado a nombreUsuario
                ddlIdUsuario.DataValueField = "idUsuario";    // Cambiado a idUsuario (minúscula para coincidir)
                ddlIdUsuario.DataBind();

                ddlIdUsuario.Items.Insert(0, new ListItem("-- Seleccione Usuario --", ""));

                Debug.WriteLine("Usuarios cargados: " + usuarios.Count);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en CargarUsuarios: " + ex.Message);

            }
        }
        private void CargarEspecialidades()
        {
            try
            {
                List<EspecialidadVeterinario> especialidades = veteNegocio.ObtenerEspecialidades();

                ddlEspecialidad.DataSource = especialidades;
                ddlEspecialidad.DataTextField = "NombreEspecilidad";
                ddlEspecialidad.DataValueField = "IdEspecialidad";
                ddlEspecialidad.DataBind();

                ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione Especialidad --", "0"));
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error en CargarEspecialidades: " + ex);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (InsertarVeterinario() == true)
            {
                lblCartel.Text = "Agregado Exitosamente";
                Response.Redirect("~/Vistas/Veterinarios/ListarVeterinarios.aspx");
            }
            else
            {
                lblCartel.Text = "ERROR AL INGRESAR";
            }

        }

        protected bool InsertarVeterinario()
        {
            try
            {
                string dni = txtDni.Text;
                string ape = txtApellido.Text;
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string email = txtEmail.Text;
                long _matriculaN = Convert.ToInt64(txtMatriculaNacional.Text);
                string _matriP = txtMatriculaProvincial.Text;
                long matriPro = int.Parse(_matriP);
                if (validacion.ParametrosNoVacio(new string[] {dni,ape,nombre,direccion,telefono,email})==false)
                {
                    return false;
                }
                if (validacion.EsMatriculaValida(_matriculaN) == false)
                {
                    return false;
                }
                if (validacion.EsMatriculaValida(matriPro) == false)
                {
                    return false;
                }
                    Veterinario veterinario = new Veterinario
                {
                    Dni = long.Parse(txtDni.Text),
                    Apellido = txtApellido.Text,
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = long.Parse(txtTelefono.Text),
                    Email = txtEmail.Text,
                    MatriculaNacional = long.Parse(txtMatriculaNacional.Text),
                    MatriculaProvincial = long.Parse(txtMatriculaProvincial.Text),
                    IDEspecialidad = int.Parse(ddlEspecialidad.SelectedValue),
                    FechaRegistro = DateTime.Now,
                    IdUsuario = int.Parse(ddlIdUsuario.SelectedValue),
                    Activo = true,

                };
               

                veteNegocio.Agregar(veterinario);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR" + ex);
                return false;
            }
        }

    }
}