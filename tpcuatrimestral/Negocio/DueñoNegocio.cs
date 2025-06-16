using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class DueñoNegocio
    {
        public List<Dueño> Listar()
        {
            List<Dueño> lista = new List<Dueño>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                    SELECT IDDueño, Dni, Apellido, Nombre, Direccion, 
                           Telefono, Email, FechaRegistro, Activo 
                    FROM Dueños
                    WHERE Activo = 1
                    ORDER BY Apellido, Nombre");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dueño dueño = new Dueño
                    {
                        IdDueño       = Convert.ToInt32(datos.Lector["IDDueño"]),
                        Dni           = Convert.ToInt64(datos.Lector["Dni"]),
                        Apellido      = datos.Lector["Apellido"].ToString(),
                        Nombre        = datos.Lector["Nombre"].ToString(),
                        Direccion     = datos.Lector["Direccion"].ToString(),
                        Telefono      = Convert.ToInt64(datos.Lector["Telefono"]),
                        email         = datos.Lector["Email"].ToString(),
                        FechaRegistro = Convert.ToDateTime(datos.Lector["FechaRegistro"]),
                        Activo        = Convert.ToBoolean(datos.Lector["Activo"])
                    };

                    lista.Add(dueño);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el listado de dueños", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}