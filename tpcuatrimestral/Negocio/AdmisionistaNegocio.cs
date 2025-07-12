using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class AdmisionistaNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Admisionista> Listar()
        {
            List<Admisionista> lista = new List<Admisionista>();

            try
            {
                datos.setearConsulta(@"
                    SELECT IDAdmisionista, Dni, Apellido, Nombre, Direccion, 
                           Telefono, Email, FechaRegistro, Activo 
                    FROM Admisionistas
                    WHERE Activo = 1
                    ORDER BY Apellido, Nombre");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Admisionista admisionista = new Admisionista
                    {
                        IDAdmisionista = Convert.ToInt32(datos.Lector["IDAdmisionista"]),
                        Dni = Convert.ToInt64(datos.Lector["Dni"]),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Direccion = datos.Lector["Direccion"].ToString(),
                        Telefono = Convert.ToInt64(datos.Lector["Telefono"]),
                        Email = datos.Lector["Email"].ToString(),
                        FechaRegistro = Convert.ToDateTime(datos.Lector["FechaRegistro"]),
                        Activo = Convert.ToBoolean(datos.Lector["Activo"])
                    };

                    lista.Add(admisionista);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el listado de admisionistas", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Admisionista ObtenerPorId(int id)
        {
            try
            {
                datos.setearConsulta(@"
            SELECT IDAdmisionista, Dni, Apellido, Nombre, Direccion, 
                   Telefono, Email, FechaRegistro, Activo 
            FROM Admisionistas 
            WHERE IDAdmisionista = @id");

                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Admisionista
                    {
                        IDAdmisionista = Convert.ToInt32(datos.Lector["IDAdmisionista"]),
                        Dni = Convert.ToInt64(datos.Lector["Dni"]),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Direccion = datos.Lector["Direccion"].ToString(),
                        Telefono = Convert.ToInt64(datos.Lector["Telefono"]),
                        Email = datos.Lector["Email"].ToString(),
                        FechaRegistro = Convert.ToDateTime(datos.Lector["FechaRegistro"]),
                        Activo = Convert.ToBoolean(datos.Lector["Activo"])
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener admisionista por ID", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool ActualizarAdmisionista(Admisionista admisionista)
        {
            try
            {
                datos.setearConsulta(@"
            UPDATE Admisionistas SET 
                Dni = @dni,
                Apellido = @apellido,
                Nombre = @nombre,
                Direccion = @direccion,
                Telefono = @telefono,
                Email = @email,
                Activo = @activo
            WHERE IDAdmisionista = @id");

                datos.setearParametro("@id", admisionista.IDAdmisionista);
                datos.setearParametro("@dni", admisionista.Dni);
                datos.setearParametro("@apellido", admisionista.Apellido);
                datos.setearParametro("@nombre", admisionista.Nombre);
                datos.setearParametro("@direccion", admisionista.Direccion);
                datos.setearParametro("@telefono", admisionista.Telefono);
                datos.setearParametro("@email", admisionista.Email);
                datos.setearParametro("@activo", admisionista.Activo);

                int filasAfectadas = datos.ejecutarAccion(true);
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar admisionista: {ex.Message}");
                throw new Exception("Error al actualizar el admisionista", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        

    }
}
