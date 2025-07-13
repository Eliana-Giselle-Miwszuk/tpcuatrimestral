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
        protected VeterinarioNegocio veteNegocio = new VeterinarioNegocio();
        protected UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        protected Validaciones validacion = new Validaciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEspecialidades();
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
                MostrarError("Error al cargar especialidades: " + ex.Message);
                Debug.WriteLine("Error en CargarEspecialidades: " + ex.Message);
            }
        }

        protected void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscarDniUsuario.Text))
            {
                if (long.TryParse(txtBuscarDniUsuario.Text, out long dni))
                {
                    Usuario usuario = usuarioNegocio.BuscarPorDNI(dni);

                    if (usuario != null)
                    {
                        // Mostrar nombre de usuario
                        txtNombreUsuario.Text = usuario.NombreUsuario;

                        // Guardar el ID del usuario en el campo oculto
                        hdnIdUsuario.Value = usuario.IdUsuario.ToString();

                        lblResultadoBusqueda.Text = "Usuario encontrado";
                        lblResultadoBusqueda.CssClass = "text-success small";
                    }
                    else
                    {
                        lblResultadoBusqueda.Text = "No se encontró un usuario con ese DNI";
                        lblResultadoBusqueda.CssClass = "text-danger small";
                        // Limpiar campos si no se encuentra
                        txtNombreUsuario.Text = "";
                        hdnIdUsuario.Value = "";
                    }
                }
                else
                {
                    lblResultadoBusqueda.Text = "Ingrese un DNI válido";
                    lblResultadoBusqueda.CssClass = "text-danger small";
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (InsertarVeterinario())
                {
                    MostrarExito("Veterinario agregado exitosamente");
                    Response.Redirect("~/Vistas/Veterinarios/ListarVeterinarios.aspx", false);
                }
                else
                {
                    MostrarError("Error al guardar el veterinario");
                }
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/Veterinarios/ListarVeterinarios.aspx");
        }

        private bool ValidarCampos()
        {
            // Validación básica de campos requeridos
            if (string.IsNullOrEmpty(hdnIdUsuario.Value)) return MostrarErrorValidacion("Debe buscar y seleccionar un usuario");
            if (string.IsNullOrEmpty(txtApellido.Text)) return MostrarErrorValidacion("El apellido es requerido");
            if (string.IsNullOrEmpty(txtNombre.Text)) return MostrarErrorValidacion("El nombre es requerido");
            if (string.IsNullOrEmpty(txtDireccion.Text)) return MostrarErrorValidacion("La dirección es requerida");
            if (string.IsNullOrEmpty(txtTelefono.Text)) return MostrarErrorValidacion("El teléfono es requerido");
            if (string.IsNullOrEmpty(txtEmail.Text)) return MostrarErrorValidacion("El email es requerido");
            if (string.IsNullOrEmpty(txtMatriculaNacional.Text)) return MostrarErrorValidacion("La matrícula nacional es requerida/en caso de tener M.P Ingrese 0");
            if (string.IsNullOrEmpty(txtMatriculaProvincial.Text)) return MostrarErrorValidacion("La matrícula provincial es requerida/en caso de tener M.N Ingrese 0");
            if (ddlEspecialidad.SelectedValue == "0") return MostrarErrorValidacion("Debe seleccionar una especialidad");

            // Validación de formatos
            if (!long.TryParse(txtTelefono.Text, out _)) return MostrarErrorValidacion("El teléfono debe ser numérico");
            if (!long.TryParse(txtMatriculaNacional.Text, out _)) return MostrarErrorValidacion("La matrícula nacional debe ser numérica");
            if (!long.TryParse(txtMatriculaProvincial.Text, out _)) return MostrarErrorValidacion("La matrícula provincial debe ser numérica");

            return true;
        }

        private bool MostrarErrorValidacion(string mensaje)
        {
            MostrarError(mensaje);
            return false;
        }

        private bool InsertarVeterinario()
        {
            try
            {
                Veterinario veterinario = new Veterinario
                {
                    Dni = long.Parse(txtBuscarDniUsuario.Text), // Tomamos el DNI del campo de búsqueda
                    Apellido = txtApellido.Text,
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = long.Parse(txtTelefono.Text),
                    Email = txtEmail.Text,
                    MatriculaNacional = long.Parse(txtMatriculaNacional.Text),
                    MatriculaProvincial = long.Parse(txtMatriculaProvincial.Text),
                    IDEspecialidad = int.Parse(ddlEspecialidad.SelectedValue),
                    FechaRegistro = DateTime.Now,
                    IdUsuario = int.Parse(hdnIdUsuario.Value),
                    Activo = true
                };

                if (!validacion.ParametrosNoVacio(new string[] {
                    veterinario.Dni.ToString(),
                    veterinario.Apellido,
                    veterinario.Nombre,
                    veterinario.Direccion,
                    veterinario.Telefono.ToString(),
                    veterinario.Email
                }))
                {
                    MostrarError("Todos los campos son requeridos");
                    return false;
                }

                if (!validacion.EsMatriculaValida(veterinario.MatriculaNacional))
                {
                    MostrarError("La matrícula nacional no es válida");
                    return false;
                }

                if (!validacion.EsMatriculaValida(veterinario.MatriculaProvincial))
                {
                    MostrarError("La matrícula provincial no es válida");
                    return false;
                }

                veteNegocio.Agregar(veterinario);
                return true;
            }
            catch (Exception ex)
            {
                MostrarError("Error al guardar el veterinario: " + ex.Message);
                Debug.WriteLine("ERROR en InsertarVeterinario: " + ex);
                return false;
            }
        }

        private void LimpiarFormulario()
        {
            txtBuscarDniUsuario.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
            hdnIdUsuario.Value = string.Empty;
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMatriculaNacional.Text = string.Empty;
            txtMatriculaProvincial.Text = string.Empty;
            ddlEspecialidad.SelectedIndex = 0;
            lblResultadoBusqueda.Text = string.Empty;
            lblCartel.Text = string.Empty;
            lblCartel.Visible = false;
        }

        private void MostrarExito(string mensaje)
        {
            lblCartel.Text = mensaje;
            lblCartel.CssClass = "status-message text-success";
            lblCartel.Visible = true;
        }

        private void MostrarError(string mensaje)
        {
            lblCartel.Text = mensaje;
            lblCartel.CssClass = "status-message text-danger";
            lblCartel.Visible = true;
        }
    }
}