using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        int idUsuario { get; set; }  // Identificador único del usuario
        string nombreUsuario { get; set; }  // Nombre de usuario (ejemplo: "jdoe")  
        string contrasena { get; set; }  // Contraseña del usuario (debería ser almacenada de forma segura, por ejemplo, hasheada)
        string email { get; set; }  // Email del usuario (debería ser único)
        string tipoUsuario { get; set; }  // Tipo de usuario (ejemplo: "Cliente", "Veterinario", "Administrador")
    }
}
