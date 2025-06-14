using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class EstadoTurno
    {
        public int IDEstadoTurno { get; set; }  
        public string TipoEstado { get; set; }  // Ejemplo: "Pendiente", "Confirmado", "Cancelado", "Finalizado"
    }
}
