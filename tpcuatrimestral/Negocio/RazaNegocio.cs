using System;
using System.Collections.Generic;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class RazaNegocio
    {
        private AccesoDatos accesoDatos = new AccesoDatos();

        public List<KeyValuePair<int, string>> ListarRazasActivas()
        {
            try
            {
                return accesoDatos.CargarDesplegable(
                    tabla: "Razas",
                    idColumna: "IDRaza",
                    textoColumna: "NombreRaza",
                    condiciones: null // Podrías agregar condiciones si necesitas filtrar
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}