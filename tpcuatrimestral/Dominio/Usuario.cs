using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
     public   int idUsuario { get; set; }  // Identificador único del usuario
        public string nombreUsuario { get; set; }  // Nombre de usuario (ejemplo: "jdoe")  
        public string contrasena { get; set; }  // Contraseña del usuario (debería ser almacenada de forma segura, por ejemplo, hasheada)
        public string email { get; set; }  // Email del usuario (debería ser único)
        public string tipoUsuario { get; set; }  // Tipo de usuario (ejemplo: "Recepcionista", "Veterinario", "Administrador")
    }
}
