using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Especie
    {
        public int IDEspecie { get; set; }  // Identificador único de la especie
        public string NombreEspecie { get; set; }  // Nombre de la especie (ejemplo: "Perro", "Gato")
        public string Caracteristas { get; set; }  // Descripción adicional sobre la especie
    
    }
}
