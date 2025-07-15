using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tpcuatrimestral.Vistas.Turnos
{
    public partial class AgregarTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMascotas();
                txtFechaTurno.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                // Recrear botones si ya se seleccionó veterinario y fecha
                if (ViewState["idVeterinario"] != null && ViewState["fechaSeleccionada"] != null)
                {
                    int idVet = int.Parse(ViewState["idVeterinario"].ToString());
                    DateTime fecha = DateTime.Parse(ViewState["fechaSeleccionada"].ToString());
                    MostrarHorariosDisponibles(idVet, fecha); // <-- Esto recrea los botones
                }
            }
        }

        private void CargarMascotas()
        {
            TurnoNegocio negocio = new TurnoNegocio();
            try
            {
                ddlNroHistoriaClinica.DataSource = negocio.ListarMascotas();
                ddlNroHistoriaClinica.DataTextField = "Nombre";
                ddlNroHistoriaClinica.DataValueField = "NroHistoriaClinica";
                ddlNroHistoriaClinica.DataBind();
                ddlNroHistoriaClinica.Items.Insert(0, new ListItem("-- Seleccione una mascota --", "0"));
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("../Error.aspx");
            }
        }

        protected void txtFechaTurno_TextChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("=== INICIO txtFechaTurno_TextChanged ===");
            Debug.WriteLine($"Valor de txtFechaTurno.Text: {txtFechaTurno.Text}");

            try
            {
                if (!string.IsNullOrEmpty(txtFechaTurno.Text))
                {
                    Debug.WriteLine("Validación de texto no vacío pasada");

                    DateTime fechaSeleccionada;
                    if (!DateTime.TryParse(txtFechaTurno.Text, out fechaSeleccionada))
                    {
                        Debug.WriteLine("Falló el parseo de fecha");
                        MostrarErrorEnPagina("Formato de fecha inválido");
                        return;
                    }

                    Debug.WriteLine($"Fecha parseada: {fechaSeleccionada}");

                    if (fechaSeleccionada < DateTime.Today)
                    {
                        Debug.WriteLine("Fecha es anterior a hoy");
                        MostrarErrorEnPagina("No se pueden agendar turnos en fechas pasadas");
                        return;
                    }

                    Debug.WriteLine("Fecha válida, cargando veterinarios...");
                    CargarVeterinariosDisponibles(fechaSeleccionada);

                    divVeterinarios.Visible = true;
                    divHorarios.Visible = false;
                    divFormularioCompleto.Visible = false;

                    Debug.WriteLine("Proceso completado exitosamente");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EXCEPCIÓN: {ex.ToString()}");
                MostrarErrorEnPagina($"Error al procesar: {ex.Message}");
            }

            Debug.WriteLine("=== FIN txtFechaTurno_TextChanged ===");
        }
        private void MostrarErrorEnPagina(string mensaje)
        {
            Debug.WriteLine($"Mostrando error en página: {mensaje}");

            // Agrega este control si no lo tienes
            // <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false" ForeColor="Red"></asp:Label>

            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;

            // Opcional: Scroll automático al mensaje de error
            ScriptManager.RegisterStartupScript(this, GetType(), "scrollToError", "window.scrollTo(0, document.getElementById('" + lblMensajeError.ClientID + "').offsetTop);", true);
        }
        private void CargarVeterinariosDisponibles(DateTime fecha)
        {
            Debug.WriteLine($"=== INICIO CargarVeterinariosDisponibles ({fecha}) ===");

            try
            {
                TurnoNegocio negocio = new TurnoNegocio();
                Debug.WriteLine("Instancia de TurnoNegocio creada");

                var veterinarios = negocio.ListarVeterinariosDisponibles(fecha);
                Debug.WriteLine($"Veterinarios obtenidos: {veterinarios?.Count ?? 0}");

                if (veterinarios == null || veterinarios.Count == 0)
                {
                    Debug.WriteLine("No hay veterinarios disponibles");
                    MostrarErrorEnPagina("No hay veterinarios disponibles para la fecha seleccionada");
                    return;
                }

                ddlVeterinarios.DataSource = veterinarios;
                ddlVeterinarios.DataTextField = "Nombre";
                ddlVeterinarios.DataValueField = "IDVeterinario";
                ddlVeterinarios.DataBind();
                ddlVeterinarios.Items.Insert(0, new ListItem("-- Seleccione un veterinario --", "0"));

                Debug.WriteLine("DropDownList de veterinarios cargado exitosamente");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EXCEPCIÓN en CargarVeterinariosDisponibles: {ex.ToString()}");
                MostrarErrorEnPagina($"Error al cargar veterinarios: {ex.Message}");
            }

            Debug.WriteLine("=== FIN CargarVeterinariosDisponibles ===");
        }

        protected void ddlVeterinarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("=== INICIO ddlVeterinarios_SelectedIndexChanged ===");
            Debug.WriteLine($"Veterinario seleccionado: {ddlVeterinarios.SelectedValue}");

            try
            {
                if (ddlVeterinarios.SelectedValue != "0" && !string.IsNullOrEmpty(txtFechaTurno.Text))
                {
                    Debug.WriteLine("Validación pasada - procediendo a cargar horarios");

                    int idVeterinario = int.Parse(ddlVeterinarios.SelectedValue);
                    DateTime fechaSeleccionada = DateTime.Parse(txtFechaTurno.Text);

                    Debug.WriteLine($"ID Veterinario: {idVeterinario}, Fecha: {fechaSeleccionada}");

                    // 🔁 Guardamos los valores necesarios para recrear los botones luego del PostBack
                    ViewState["idVeterinario"] = idVeterinario;
                    ViewState["fechaSeleccionada"] = fechaSeleccionada;

                    MostrarHorariosDisponibles(idVeterinario, fechaSeleccionada);
                    divHorarios.Visible = true;

                    Debug.WriteLine("Horarios mostrados exitosamente");
                }
                else
                {
                    Debug.WriteLine("Validación fallida - no se cargarán horarios");
                    divHorarios.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EXCEPCIÓN: {ex.ToString()}");
                MostrarErrorEnPagina($"Error al cargar horarios: {ex.Message}");
            }

            Debug.WriteLine("=== FIN ddlVeterinarios_SelectedIndexChanged ===");
        }

        private void MostrarHorariosDisponibles(int idVeterinario, DateTime fecha)
        {
            Debug.WriteLine($"=== INICIO MostrarHorariosDisponibles (VetID: {idVeterinario}, Fecha: {fecha}) ===");

            try
            {
                horariosContainer.Controls.Clear();
                Debug.WriteLine("Contenedor de horarios limpiado");

                TurnoNegocio negocio = new TurnoNegocio();
                Debug.WriteLine("Instancia de TurnoNegocio creada");

                // 1. Obtener horario del veterinario
                var horario = negocio.ObtenerHorarioVeterinario(idVeterinario);
                Debug.WriteLine($"Horario obtenido: Apertura={horario.HoraApertura}, Cierre={horario.HoraCierre}");

                // 2. Obtener turnos ocupados
                var turnosOcupados = negocio.ListarTurnosOcupados(idVeterinario, fecha);
                Debug.WriteLine($"Turnos ocupados encontrados: {turnosOcupados.Count}");

                // 3. Generar horarios disponibles
                TimeSpan intervalo = TimeSpan.FromMinutes(30);
                TimeSpan horaActual = horario.HoraApertura;
                int horariosDisponibles = 0;

                Debug.WriteLine("Generando botones de horarios...");

                while (horaActual < horario.HoraCierre)
                {
                    DateTime fechaHoraCompleta = fecha.Date + horaActual;
                    bool ocupado = turnosOcupados.Exists(t => t.TimeOfDay >= horaActual && t.TimeOfDay < horaActual + intervalo);

                    if (!ocupado)
                    {
                        Button btnHorario = new Button();
                        btnHorario.Text = horaActual.ToString(@"hh\:mm");
                        btnHorario.CssClass = "horario-btn";
                        btnHorario.CommandArgument = fechaHoraCompleta.ToString("yyyy-MM-dd HH:mm:ss");
                        btnHorario.Click += BtnHorario_Click;
                        horariosContainer.Controls.Add(btnHorario);
                        horariosDisponibles++;
                    }

                    horaActual = horaActual.Add(intervalo);
                }

                Debug.WriteLine($"Botones creados: {horariosDisponibles} horarios disponibles");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EXCEPCIÓN en MostrarHorariosDisponibles: {ex.ToString()}");
                throw; // Re-lanzamos para manejar en el método llamador
            }

            Debug.WriteLine("=== FIN MostrarHorariosDisponibles ===");
        }

        protected void BtnHorario_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("=== INICIO BtnHorario_Click ===");

            try
            {
                Button btn = (Button)sender;
                Debug.WriteLine($"Horario seleccionado: {btn.CommandArgument}");

                DateTime fechaHoraSeleccionada = DateTime.Parse(btn.CommandArgument);

                // Mostrar la fecha/hora seleccionada
                txtFechaHoraTurnoSeleccionada.Text = fechaHoraSeleccionada.ToString("g");
                Debug.WriteLine($"Fecha/hora asignada: {txtFechaHoraTurnoSeleccionada.Text}");

                // Mostrar el formulario completo
                divFormularioCompleto.Visible = true;
                Debug.WriteLine("Formulario completo visible");

                // Ocultar secciones que ya no son necesarias
                divHorarios.Visible = false;

                // Enfocar el campo de motivo de consulta
                txtMotivoConsulta.Focus();

                Debug.WriteLine("Proceso de selección de horario completado");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EXCEPCIÓN en BtnHorario_Click: {ex.ToString()}");
                MostrarErrorEnPagina($"Error al seleccionar horario: {ex.Message}");
            }

            Debug.WriteLine("=== FIN BtnHorario_Click ===");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("===> Entrando a btnGuardar_Click");

            try
            {
                // Validación
                if (string.IsNullOrEmpty(txtFechaHoraTurnoSeleccionada.Text) ||
                    ddlNroHistoriaClinica.SelectedValue == "0" ||
                    string.IsNullOrEmpty(txtMotivoConsulta.Text) ||
                    ddlVeterinarios.SelectedValue == "0")
                {
                    Debug.WriteLine("Validación fallida");
                    Session["Error"] = "Por favor complete todos los campos obligatorios";
                    Response.Redirect("../Error.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                Debug.WriteLine("Validación OK");

                Turno nuevoTurno = new Turno();
                nuevoTurno.FechaHoraTurno = DateTime.Parse(txtFechaHoraTurnoSeleccionada.Text);
                nuevoTurno.NroHistoriaClinica = int.Parse(ddlNroHistoriaClinica.SelectedValue);
                nuevoTurno.IdVeterinario = int.Parse(ddlVeterinarios.SelectedValue);
                nuevoTurno.MotivoConsulta = txtMotivoConsulta.Text;

                Debug.WriteLine("Llamando a AgregarTurno...");
                TurnoNegocio negocio = new TurnoNegocio();
                negocio.AgregarTurno(nuevoTurno);

                Debug.WriteLine("Turno agregado. Redirigiendo...");
                Response.Redirect("Turnos.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en btnGuardar_Click: " + ex.ToString());
                Session["Error"] = ex.ToString();
                Response.Redirect("../Error.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}