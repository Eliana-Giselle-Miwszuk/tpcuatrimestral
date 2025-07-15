using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Agenda
    {
        public int ID { get; set; }
        public int IDVeterinario { get; set; }
        public DateTime FechaHora { get; set; }
        public int DuracionMinutos { get; set; } = 60; 
        public string Descripcion { get; set; }
        public int? IDPaciente { get; set; } 
        public bool Disponible { get; set; } = true;
        public bool Activo { get; set; } = true;

        public Veterinario Veterinario { get; set; }
    }

    public class HorarioLaboral
    {
        public int ID { get; set; }
        public int IDVeterinario { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Activo { get; set; } = true;
    }
}
