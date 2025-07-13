using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
  
        public int IdUsuario { get; set; }
        public long Dni { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string TipoUsuario { get; set; }
        public bool UsuMaster { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }


    }
}
