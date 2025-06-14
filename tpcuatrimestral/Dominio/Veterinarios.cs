using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Veterinarios
    {
     
            public int IDVeterinario { get; set; }
            public long Dni { get; set; }
            public string Apellido { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public long Telefono { get; set; }
            public string Email { get; set; }
            public int MatriculaNacional { get; set; }
            public int MatriculaProvincial { get; set; }
            public int IDEspecialidad { get; set; } // Foreign Key
            public DateTime FechaRegistro { get; set; }
            public bool Activo { get; set; }
    
    }
}
