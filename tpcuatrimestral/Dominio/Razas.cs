using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Razas
    {
        int IDRaza { get; set; }  // Identificador único de la raza
        int IDEspecie { get; set; }  // Foreign Key a la especie
        string NombreRaza { get; set; }  // Nombre de la raza (ejemplo: "Labrador", "Persa")
        string Caracteristicas { get; set; }  // Descripción adicional sobre la raza
    }
}
