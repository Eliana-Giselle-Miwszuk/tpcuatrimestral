using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Mascota
    {
        public int NroHistoriaClinica { get; set; }
        public int IDDueño { get; set; }
        public int IDRaza { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Color { get; set; }
        public decimal Peso { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }
}
