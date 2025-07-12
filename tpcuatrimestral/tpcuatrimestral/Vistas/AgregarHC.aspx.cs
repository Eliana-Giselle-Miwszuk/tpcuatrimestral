using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace tpcuatrimestral.Vistas
{
    public partial class AgregarHC : System.Web.UI.Page
    {
        //ACÓPLAMIENTO 
        Validaciones validacion = new Validaciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHistoriasClinicas();
            }
        }

        private void CargarHistoriasClinicas()
        {
            try
            {
                MascotaNegocio negocio = new MascotaNegocio();
                var historias = negocio.ListarHistoriasClinicasDisponibles();

                DdlNroHistoriaClinica.DataSource = historias;
                DdlNroHistoriaClinica.DataTextField = "Value";
                DdlNroHistoriaClinica.DataValueField = "Key";
                DdlNroHistoriaClinica.DataBind();

                DdlNroHistoriaClinica.Items.Insert(0, new ListItem("Seleccione una historia clínica", ""));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DdlNroHistoriaClinica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DdlNroHistoriaClinica.SelectedValue))
            {
                int nroHistoria = Convert.ToInt32(DdlNroHistoriaClinica.SelectedValue);
                CargarTurnosPorHistoria(nroHistoria);
            }
            else
            {
                DdlTurno.Items.Clear();
                DdlTurno.Items.Insert(0, new ListItem("Seleccione un turno", ""));
            }
        }

        private void CargarTurnosPorHistoria(int nroHistoriaClinica)
        {
            try
            {
                TurnoNegocio negocio = new TurnoNegocio();
                var turnos = negocio.ListarTurnosPorHistoria(nroHistoriaClinica);

                DdlTurno.DataSource = turnos;
                DdlTurno.DataTextField = "FechaHoraTurno";
                DdlTurno.DataValueField = "IDTurno";
                DdlTurno.DataBind();

                DdlTurno.Items.Insert(0, new ListItem("Seleccione un turno", ""));
            }
            catch (Exception ex)
            {
              
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DdlNroHistoriaClinica.SelectedValue) ||
                    string.IsNullOrEmpty(DdlTurno.SelectedValue))
                {
                    
                    return;
                }

                    string sintomas = TextSintomas.Text;
                   string diagnostico = TextDiagnostico.Text;
                   string tratamiento = TextTratamiento.Text;
                string mmedicacion = TextMedicacion.Text;
                if (validacion.ParametrosNoVacio(new string[]{sintomas,diagnostico,tratamiento,mmedicacion})==false) {
                    lblValidar.Text = "HAY CAMPOS OBLIGATORIOS A COMPLETAR";
                    return;
                }
                HistoriaClinica historia = new HistoriaClinica
                {
                    NroHistoriaClinica = Convert.ToInt32(DdlNroHistoriaClinica.SelectedValue),
                    IDTurno = Convert.ToInt32(DdlTurno.SelectedValue),
                    FechaHoraCita = Convert.ToDateTime(TxtFechaHoraCita.Text),
                    Sintomas = TextSintomas.Text,
                    Diagnostico = TextDiagnostico.Text,
                    Tratamiento = TextTratamiento.Text,
                    Medicacion = TextMedicacion.Text,
                    Observaciones = TextObservaciones.Text
                };

                HistoriaClinicaNegocio negocio = new HistoriaClinicaNegocio();
                int idRegistro = negocio.AgregarHistoriaClinica(historia);

               
                Response.Redirect($"HistoriasClinicas.aspx?nroHistoria={historia.NroHistoriaClinica}&success=1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}