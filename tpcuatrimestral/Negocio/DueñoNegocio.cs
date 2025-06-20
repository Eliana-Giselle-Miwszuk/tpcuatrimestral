using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class DueñoNegocio
    {
        AccesoDatos datos = new AccesoDatos();
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
            public List<KeyValuePair<int, string>> ListarDueñosActivos()
            {
                try
                {
                    return datos.CargarDesplegable(
                        tabla: "Dueños",
                        idColumna: "IDDueño",
                        textoColumna: "Apellido + ', ' + Nombre as NombreCompleto",
                        condiciones: "Activo = @activo",
                        parametros: new Dictionary<string, object> { { "activo", true } }
                    );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        /*    public bool EliminarMasco(int nro)
        {
            try
            {
                Debug.WriteLine(nro);
                var parametros = new Dictionary<string, object>
        {
            { "Activo", false }
        };
                var condicion = $"NroHistoriaClinica = {nro}"; 
                int filasAfectadas = accesoDatos.Actualizar("Mascotas", parametros, condicion);
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ACA HAY ERREOR: " + ex.Message);
                return false;
            }
        }*/
        public bool EliminarDueño(int dni)
        {
            try {
                var parametro = new Dictionary<string, object> { { "Activo", false } };
                var condicion = $"Dni = {dni}";
                int filasAfectadas = datos.Actualizar("Dueños", parametro, condicion);
                return filasAfectadas > 0;

            
            } catch {
                return false;
            }
        }
        /* public int AgregarMascota(Mascota mascota)
        {
            try
            {
                var parametros = new Dictionary<string, object>
        {
            {"IDDueño", mascota.IDDueño},
            {"IDRaza", mascota.IDRaza},
            {"Nombre", mascota.Nombre},
            {"Sexo", mascota.Sexo},
            {"Color", mascota.Color},
            {"Peso", mascota.Peso},
            {"FechaRegistro", mascota.FechaRegistro},
            {"Activo", mascota.Activo}
        };

                return accesoDatos.Insertar("Mascotas", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public Dueño getDueñoPreCarga(int dni)
        {
            try
            {
                datos.setearConsulta("SELECT * FROM Dueños WHERE Dni = @Dni");
                datos.setearParametro("@Dni", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Dueño
                    {
                        IdDueño = (int)datos.Lector["IdDueño"],
                        Dni = (long)datos.Lector["Dni"],
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Direccion = datos.Lector["Direccion"].ToString(),
                        Telefono = (long)datos.Lector["Telefono"],
                        email = datos.Lector["email"].ToString(),
                        FechaRegistro = (DateTime)datos.Lector["FechaRegistro"],
                        Activo = (bool)datos.Lector["Activo"]
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                // Podés loguear el error si querés, ej:
                System.Diagnostics.Debug.WriteLine("Error en getDueñoPreCarga: " + ex.Message);
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool ActualizarDueño(Dueño dueño)
        {
            try
            {
                var parametros = new Dictionary<string, object>
        {
            { "Apellido", dueño.Apellido },
            { "Nombre", dueño.Nombre },
            { "Direccion", dueño.Direccion },
            { "Telefono", dueño.Telefono }, // corregido
            { "email", dueño.email }
        };

                var condicion = "Dni = " + dueño.Dni; // corregido
                int filasAfectadas = datos.Actualizar("Dueños", parametros, condicion);
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al actualizar dueño: " + ex.Message);
                return false;
            }
        }

        /*        public bool ActualizarMascota(Mascota mascota)
        {
            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "Nombre",mascota.Nombre},
                    {"Peso", mascota.Peso }
                };
                var accesoDatos = new AccesoDatos();
                var condicion = "NroHistoriaClinica= " + mascota.NroHistoriaClinica;
                int filasAfectadas = accesoDatos.Actualizar("Mascotas", parametros, condicion);
                return filasAfectadas > 0;
            } catch (Exception ex)
            {

                return false;
            }
        }*/
        /*    public Mascota ObtenerPorNroHistoria(int nroHistoriaClinica)
        {
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM Mascotas WHERE NroHistoriaClinica = @nro");
                accesoDatos.setearParametro("@nro", nroHistoriaClinica);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    return new Mascota
                    {
                        NroHistoriaClinica = (int)accesoDatos.Lector["NroHistoriaClinica"],
                        IDDueño = (int)accesoDatos.Lector["IDDueño"],
                        IDRaza = (int)accesoDatos.Lector["IDRaza"],
                        Nombre = accesoDatos.Lector["Nombre"].ToString(),
                        Sexo = accesoDatos.Lector["Sexo"].ToString(),
                        Color = accesoDatos.Lector["Color"].ToString(),
                        Peso = Convert.ToDecimal(accesoDatos.Lector["Peso"]),
                        FechaRegistro = (DateTime)accesoDatos.Lector["FechaRegistro"],
                        Activo = (bool)accesoDatos.Lector["Activo"]
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }*/
        public int InsertarDueño(Dueño dueño)
        {
            try {
                var parametros = new Dictionary<string, object>
                {
                    { "Dni",dueño.Dni },
                    { "Apellido" , dueño.Apellido},
                    { "Nombre", dueño.Apellido },
                    {"Direccion",dueño.Direccion },
                    {"Telefono",dueño.Telefono },
                    {"Email",dueño.email }
                };
                return datos.Insertar("Dueños", parametros);
            } catch {
                return -1;
            }
        }
    }
}