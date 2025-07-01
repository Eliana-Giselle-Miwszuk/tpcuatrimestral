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
    public partial class EditarDueño : System.Web.UI.Page
    {
        DueñoNegocio dueñoNegocio = new DueñoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int dni = Convert.ToInt32(Request.QueryString["Dni"]);
                cargarTextbox(dni);
            }
        }
        protected void cargarTextbox(int dni) {
           var dueño=  dueñoNegocio.getDueñoPreCarga(dni);
            if (dueño != null)
            {
                txtApellido.Text = dueño.Apellido;
                txtNombre.Text = dueño.Nombre;
                txtDireccion.Text = dueño.Direccion;
                txtTelefono.Text = Convert.ToString(dueño.Telefono);
                txtEmail.Text = dueño.email;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                long dni = Convert.ToInt64(Request.QueryString["Dni"]);

                var dueño = new Dueño
                {
                    Dni = dni,
                    Apellido = txtApellido.Text,
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = Convert.ToInt64(txtTelefono.Text),
                    email = txtEmail.Text
                };

                bool actualizado = dueñoNegocio.ActualizarDueño(dueño);

                if (actualizado)
                {
                    Response.Redirect("ListaDueño.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    // Podés mostrar un mensaje visual si querés
                    Debug.WriteLine("No se pudo actualizar el dueño.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al guardar cambios: " + ex.Message);
            }


        }
        /*
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
             }*/
    }
}