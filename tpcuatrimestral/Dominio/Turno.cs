using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public int NroHistoriaClinica { get; set; }
        public int IdVeterinario { get; set; }
        public string MotivoConsulta { get; set; }
        public int IdEstadoTurno { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        public string MascotaNombre { get; set; }
        public string VeterinarioNombre { get; set; }
        //aca tamo agregando una propiedad extra para el aspx TurnoXfecha
        public string EstadoTurnoDescripcion { get; set; }
    }
}