using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace tpcuatrimestral.Vistas
{
    public partial class EditarVeterinario : System.Web.UI.Page
    {
        private VeterinarioNegocio veterinarioNegocio = new VeterinarioNegocio();
        Validaciones validacion = new Validaciones();
        //ViewState
        private int IdVeterinario
        {
            get { return ViewState["IdVeterinario"] != null ? (int)ViewState["IdVeterinario"] : 0; }
            set { ViewState["IdVeterinario"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int id))
                {
                    IdVeterinario = id;
                    Debug.WriteLine($"ID Veterinario recibido: {IdVeterinario}");

                    CargarEspecialidades();
                    CargarDatosVeterinario();
                }
                else
                {

                    Response.Redirect("ListarVeterinarios.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        private void CargarEspecialidades()
        {
            try
            {
                List<EspecialidadVeterinario> especialidades = veterinarioNegocio.ObtenerEspecialidades();

                ddlEspecialidad.DataSource = especialidades;
                ddlEspecialidad.DataTextField = "NombreEspecilidad";
                ddlEspecialidad.DataValueField = "IdEspecialidad";
                ddlEspecialidad.DataBind();

                ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione Especialidad --", "0"));
            }
            catch (Exception ex)
            {
                MostrarMensajeError("Error al cargar especialidades: " + ex.Message);
                Debug.WriteLine("Error en CargarEspecialidades: " + ex);
            }
        }

        private void CargarDatosVeterinario()
        {
            try
            {
                Veterinario veterinario = veterinarioNegocio.ObtenerPorId(IdVeterinario);

                if (veterinario != null)
                {
                    txtDni.Text = veterinario.Dni.ToString();
                    txtApellido.Text = veterinario.Apellido;
                    txtNombre.Text = veterinario.Nombre;
                    txtDireccion.Text = veterinario.Direccion;
                    txtTelefono.Text = veterinario.Telefono.ToString();
                    txtEmail.Text = veterinario.Email;
                    txtMatriculaNacional.Text = veterinario.MatriculaNacional.ToString();
                    txtMatriculaProvincial.Text = veterinario.MatriculaProvincial.ToString();

                    // Seleccionar la especialidad actual
                    SeleccionarEspecialidad(veterinario.IDEspecialidad);
                }
                else
                {
                    MostrarMensajeError("No se encontró el veterinario con ID: " + IdVeterinario);
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError("Error al cargar datos: " + ex.Message);
                Debug.WriteLine("Error en CargarDatosVeterinario: " + ex);
            }
        }

        private void SeleccionarEspecialidad(int idEspecialidad)
        {
            ListItem item = ddlEspecialidad.Items.FindByValue(idEspecialidad.ToString());
            if (item != null)
            {
                ddlEspecialidad.ClearSelection();
                item.Selected = true;
            }
            else
            {
                Debug.WriteLine($"Especialidad {idEspecialidad} no encontrada en el DropDownList");
            }
        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                ActualizarVeterinario();
            }
        }

        private void ActualizarVeterinario()
        {
            try
            {
                Debug.WriteLine($"Intentando actualizar veterinario ID: {IdVeterinario}");

                Veterinario veterinario = CrearVeterinarioDesdeFormulario();
                long telefono = veterinario.Telefono;
                string correo = veterinario.Email;
                long dni = veterinario.Dni;
                long mp = veterinario.MatriculaProvincial;
                long mt = veterinario.MatriculaNacional;
                if(validacion.ValoresNoNegativo(new long[] { telefono,dni,mp,mt}) == false)
                {
                    MostrarMensajeError("Valores negatico no admitidos");
                    return;
                }
                if (veterinarioNegocio.EditarVeterinario(veterinario))
                {
                    Response.Redirect("ListarVeterinarios.aspx");
                }
                else
                {
                    MostrarMensajeError("No se pudo actualizar el veterinario");
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError("Error al actualizar: " + ex.Message);
                Debug.WriteLine("Error en ActualizarVeterinario: " + ex);
            }
        }

        private Veterinario CrearVeterinarioDesdeFormulario()
        {
            return new Veterinario
            {
                IDVeterinario = IdVeterinario,
                Dni = long.Parse(txtDni.Text),
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Telefono = long.Parse(txtTelefono.Text),
                Email = txtEmail.Text,
                MatriculaNacional = long.Parse(txtMatriculaNacional.Text),
                MatriculaProvincial = long.Parse(txtMatriculaProvincial.Text),
                IDEspecialidad = int.Parse(ddlEspecialidad.SelectedValue),
                Activo = true
            };
        }

        private bool ValidarCampos()
        {

            if (IdVeterinario <= 0)
            {
                MostrarMensajeError("ID de veterinario inválido");
                return false;
            }

            if (string.IsNullOrEmpty(txtDni.Text) || !long.TryParse(txtDni.Text, out _))
            {
                MostrarMensajeError("DNI inválido");
                return false;
            }



            return true;
        }

        private void MostrarMensajeError(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Visible = true;
            Debug.WriteLine(mensaje);
        }


    }
}