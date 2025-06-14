using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class HistoriaClinica
    {
        
            public int IDRegistro { get; set; }
            public int NroHistoriaClinica { get; set; } // Foreign Key
            public int IDTurno { get; set; } // Foreign Key
            public DateTime FechaHoraCita { get; set; }
            public string Sintomas { get; set; }
            public string Diagnostico { get; set; }
            public string Tratamiento { get; set; }
            public string Medicacion { get; set; }
            public string Observaciones { get; set; }
            public DateTime FechaRegistro { get; set; }
            public bool Activo { get; set; }
        
    }
}
