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
                try {
                    Dueño dueño = new Dueño
                        {
                        Dni = Convert.ToInt64(txtDni.Text),
                        Apellido = txtApellido.Text,
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = Convert.ToInt64(txtTelefono.Text),
                        email = txtEmail.Text,
                    };
                    DueñoNegocio dueñoNegocio = new DueñoNegocio();
                    int id = negocioD.InsertarDueño(dueño);
                    if (id > -1)
                    {
                        Debug.WriteLine("TODO OK");
                        Response.Redirect("~/ListaDueño.aspx");
                    }
                } catch { }
            }
       
        }
    }
}