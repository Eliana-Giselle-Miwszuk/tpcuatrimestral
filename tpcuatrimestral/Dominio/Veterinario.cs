using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Veterinario
    {
        public int IDVeterinario { get; set; }
        public long Dni { get; set; }  // bigint en BD
        public string Apellido { get; set; }  // nvarchar(50)
        public string Nombre { get; set; }  // nvarchar(50)
        public string Direccion { get; set; }  // nvarchar(100)
        public long Telefono { get; set; }  // bigint en BD
        public string Email { get; set; }  // nvarchar(100)
        public long MatriculaNacional { get; set; }  // bigint en BD
        public long MatriculaProvincial { get; set; }  // bigint en BD
        public int IDEspecialidad { get; set; }  // int (FK)
        public DateTime FechaRegistro { get; set; }  // date
        public bool Activo { get; set; }  // bit
       // public int? IdUsuario { get; set; }  // int, nullable
    }
}
