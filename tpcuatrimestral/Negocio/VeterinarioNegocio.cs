using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Diagnostics;

namespace Negocio
{
    public class VeterinarioNegocio
    {
        AccesoDatos sqlDatos = new AccesoDatos();

        /**/
        public List<Veterinario> Listar()
        {
            List<Veterinario> listaVeterinario = new List<Veterinario>();
            try
            {
                string consulta = "SELECT IDVeterinario, Dni, Apellido, Nombre, Direccion, Telefono, Email, " +
                    "MatriculaNacional, MatriculaProvincial, IDEspecialidad, FechaRegistro, Activo, IdUsuario " +
                    "FROM Veterinarios WHERE Activo=1" ;
                sqlDatos.setearConsulta(consulta);
                sqlDatos.ejecutarLectura();
                while (sqlDatos.Lector.Read())
                {
                    Veterinario veterinario = new Veterinario
                    {
                        IDVeterinario       = (int)sqlDatos.Lector["IDVeterinario"],
                        Dni                 = Convert.ToInt64(sqlDatos.Lector["Dni"]),
                        Apellido            = sqlDatos.Lector["Apellido"].ToString(),
                        Nombre              = sqlDatos.Lector["Nombre"].ToString(),
                        Direccion           = sqlDatos.Lector["Direccion"].ToString(),
                        Telefono            = Convert.ToInt64(sqlDatos.Lector["Telefono"]),
                        Email               = sqlDatos.Lector["Email"].ToString(),
                        MatriculaNacional   = Convert.ToInt64(sqlDatos.Lector["MatriculaNacional"]),
                        MatriculaProvincial = Convert.ToInt64(sqlDatos.Lector["MatriculaProvincial"]),
                        IDEspecialidad      = (int)sqlDatos.Lector["IDEspecialidad"],
                        FechaRegistro       = (DateTime)sqlDatos.Lector["FechaRegistro"],
                        Activo              = (bool)sqlDatos.Lector["Activo"]
                       // IdUsuario = sqlDatos.Lector["IdUsuario"] != DBNull.Value ? (int)sqlDatos.Lector["IdUsuario"] : (int?)null
                    };
                    listaVeterinario.Add(veterinario);
                }
                return listaVeterinario;

            }
            catch (Exception ex)
            {

                Debug.WriteLine("ERROR" + ex + listaVeterinario);
                return listaVeterinario;
            }
        }
          public Veterinario ObtenerPorId(int id)
          {
              Veterinario veterinario = null;

              try
              {
                  sqlDatos.setearConsulta(
                      "SELECT IDVeterinario, Dni, Apellido, Nombre, Direccion, Telefono, Email, " +
                      "MatriculaNacional, MatriculaProvincial, IDEspecialidad, FechaRegistro, Activo, IdUsuario " +
                      "FROM Veterinarios WHERE IDVeterinario = @ID");

                  sqlDatos.setearParametro("@ID", id);
                  sqlDatos.ejecutarLectura();

                  if (sqlDatos.Lector.Read())
                  {
                      veterinario = new Veterinario
                      {
                          IDVeterinario = (int)sqlDatos.Lector["IDVeterinario"],
                          Dni = Convert.ToInt64(sqlDatos.Lector["Dni"]),
                          Apellido = sqlDatos.Lector["Apellido"].ToString(),
                          Nombre = sqlDatos.Lector["Nombre"].ToString(),
                          Direccion = sqlDatos.Lector["Direccion"].ToString(),
                          Telefono = Convert.ToInt64(sqlDatos.Lector["Telefono"]),
                          Email = sqlDatos.Lector["Email"].ToString(),
                          MatriculaNacional = Convert.ToInt64(sqlDatos.Lector["MatriculaNacional"]),
                          MatriculaProvincial = Convert.ToInt64(sqlDatos.Lector["MatriculaProvincial"]),
                          IDEspecialidad = (int)sqlDatos.Lector["IDEspecialidad"],
                          FechaRegistro = (DateTime)sqlDatos.Lector["FechaRegistro"],
                          Activo = (bool)sqlDatos.Lector["Activo"]
                         // IdUsuario = sqlDatos.Lector["IdUsuario"] != DBNull.Value ? (int)sqlDatos.Lector["IdUsuario"] : (int?)null
                      };
                  }

                  return veterinario;
              }
              catch (Exception ex)
              {
                  Debug.WriteLine("Error al obtener veterinario: " + ex.Message);
                  return null;
              }
              finally
              {
                  sqlDatos.cerrarConexion();
              }
          }
          public bool EditarVeterinario(Veterinario veterinario)
          {
              try
              {
                  sqlDatos.setearConsulta(
               "UPDATE Veterinarios SET " +
              "Dni = @Dni, " +
              "Apellido = @Apellido, " +
              "Nombre = @Nombre, " +
              "Direccion = @Direccion, " +
              "Telefono = @Telefono, " +
              "Email = @Email, " +
              "MatriculaNacional = @MatriculaNacional, " +
              "MatriculaProvincial = @MatriculaProvincial, " +
              "IDEspecialidad = @IDEspecialidad, " +
              "Activo = @Activo " +
              "WHERE IDVeterinario = @ID");

                  sqlDatos.setearParametro("@ID", veterinario.IDVeterinario);
                  sqlDatos.setearParametro("@Dni", veterinario.Dni);
                  sqlDatos.setearParametro("@Apellido", veterinario.Apellido);
                  sqlDatos.setearParametro("@Nombre", veterinario.Nombre);
                  sqlDatos.setearParametro("@Direccion", veterinario.Direccion);
                  sqlDatos.setearParametro("@Telefono", veterinario.Telefono);
                  sqlDatos.setearParametro("@Email", veterinario.Email);
                  sqlDatos.setearParametro("@MatriculaNacional", veterinario.MatriculaNacional);
                  sqlDatos.setearParametro("@MatriculaProvincial", veterinario.MatriculaProvincial);
                  sqlDatos.setearParametro("@IDEspecialidad", veterinario.IDEspecialidad);
                  sqlDatos.setearParametro("@Activo", veterinario.Activo);

                  sqlDatos.ejecutarAccion();
                  return true;
              }
              catch (Exception ex)
              {
                  Debug.WriteLine("Error al actualizar veterinario A REVISAR NEGOCIO: " + ex.Message);
                  return false;
              }
              finally
              {
                  sqlDatos.cerrarConexion();
              }
          }
          public bool Agregar(Veterinario veterinario)
          {
              try
              {
                  sqlDatos.setearConsulta(
                      "INSERT INTO Veterinarios (Dni, Apellido, Nombre, Direccion, Telefono, Email, " +
                      "MatriculaNacional, MatriculaProvincial, IDEspecialidad, FechaRegistro, Activo, IdUsuario) " +
                      "VALUES (@Dni, @Apellido, @Nombre, @Direccion, @Telefono, @Email, " +
                      "@MatriculaNacional, @MatriculaProvincial, @IDEspecialidad, @FechaRegistro, @Activo, @IdUsuario)");

                  sqlDatos.setearParametro("@Dni", veterinario.Dni);//aca uso los Gets de mi clase Veterinario.Asigno a mis parametro SQL lo que tiene mi objeto guardado
                  sqlDatos.setearParametro("@Apellido", veterinario.Apellido);
                  sqlDatos.setearParametro("@Nombre", veterinario.Nombre);
                  sqlDatos.setearParametro("@Direccion", veterinario.Direccion);
                  sqlDatos.setearParametro("@Telefono", veterinario.Telefono);
                  sqlDatos.setearParametro("@Email", veterinario.Email);
                  sqlDatos.setearParametro("@MatriculaNacional", veterinario.MatriculaNacional);
                  sqlDatos.setearParametro("@MatriculaProvincial", veterinario.MatriculaProvincial);
                  sqlDatos.setearParametro("@IDEspecialidad", veterinario.IDEspecialidad);
                  sqlDatos.setearParametro("@FechaRegistro", veterinario.FechaRegistro);
                  sqlDatos.setearParametro("@Activo", veterinario.Activo);
                // sqlDatos.setearParametro("@IdUsuario", veterinario.IdUsuario ?? (object)DBNull.Value);
                sqlDatos.setearParametro("@IdUsuario", veterinario.IdUsuario);
                sqlDatos.ejecutarAccion();
                  return true;
              }
              catch (Exception ex)
              {
                  Debug.WriteLine("Error al agregar veterinario: " + ex.Message);
                  return false;
              }
              finally
              {
                  sqlDatos.cerrarConexion();
              }
          }

          //mi metodo para poder cargar el desplegable de Especialidades:
          public List<EspecialidadVeterinario> ObtenerEspecialidades()
          {
              List<EspecialidadVeterinario> lista = new List<EspecialidadVeterinario>();
              try
              {
                  sqlDatos.setearConsulta("SELECT IDEspecialidad, NombreEspecialidad FROM EspecialidadesVeterinarios");

                  sqlDatos.ejecutarLectura();

                  while (sqlDatos.Lector.Read())
                  {
                      EspecialidadVeterinario Espe = new EspecialidadVeterinario
                      {
                          IdEspecialidad = (int)sqlDatos.Lector["IDEspecialidad"],
                          NombreEspecilidad = sqlDatos.Lector["NombreEspecialidad"].ToString()
                      };
                      lista.Add(Espe);
                  }
                  return lista;
              }
              catch (Exception ex)
              {
                  Debug.WriteLine("Error al obtener especialidades: " + ex.Message);
                  throw;
              }
              finally
              {
                  sqlDatos.cerrarConexion();
              }
          }
          public bool Delete(int idVeterinario)
          {
              try
              {
                  sqlDatos.setearConsulta("UPDATE Veterinarios SET Activo = 0 WHERE IDVeterinario = @ID");
                  sqlDatos.setearParametro("@ID", idVeterinario);


                  int filasAfectadas = sqlDatos.ejecutarAccion(true);

                  return filasAfectadas > 0;
              }
              catch (Exception ex)
              {
                  Debug.WriteLine("Error en EliminarLogico: " + ex.Message);
                  return false;
              }
              finally
              {
                  sqlDatos.cerrarConexion();
              }
          }
        public List<Veterinario> BuscarPorNombre(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Veterinario> lista = new List<Veterinario>();

            try
            {
                datos.setearConsulta("SELECT Dni, Apellido, Nombre, Direccion, Telefono, Email, " +
                                   "MatriculaNacional, MatriculaProvincial, IDEspecialidad, " +
                                   "FechaRegistro, Activo, IdUsuario " +
                                   "FROM Veterinarios " +
                                   "WHERE Nombre LIKE @nombre AND Activo = 1");
                datos.setearParametro("@nombre", "%" + nombre + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Veterinario veterinario = new Veterinario();
                    veterinario.Dni = (long)datos.Lector["Dni"];
                    veterinario.Apellido = (string)datos.Lector["Apellido"];
                    veterinario.Nombre = (string)datos.Lector["Nombre"];
                    veterinario.Direccion = (string)datos.Lector["Direccion"];
                    veterinario.Telefono = (long)datos.Lector["Telefono"];
                    veterinario.Email = (string)datos.Lector["Email"];
                    veterinario.MatriculaNacional = (long)datos.Lector["MatriculaNacional"];
                    veterinario.MatriculaProvincial = (long)datos.Lector["MatriculaProvincial"];
                    veterinario.IDEspecialidad = (int)datos.Lector["IDEspecialidad"];
                    veterinario.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
                    veterinario.Activo = (bool)datos.Lector["Activo"];
                    veterinario.IdUsuario = (int)datos.Lector["IdUsuario"];

                    lista.Add(veterinario);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Turno> ObtenerTurnosPorFecha(DateTime fecha)
        {
            try
            {
                // Consulta SQL que une las tablas Turnos, EstadoTurnos y probablemente otras como Veterinarios y Mascotas
                string query = @"
            SELECT 
                t.IDTurno, 
                t.FechaHoraTurno, 
                t.NroHistoriaClinica, 
                t.IDVeterinario, 
                t.MotivoConsulta, 
                t.IDEstadoTurno, 
                t.FechaRegistro, 
                t.Activo,
                et.TipoEstado AS EstadoTurno,
                v.Nombre + ' ' + v.Apellido AS VeterinarioNombre,
                m.Nombre AS MascotaNombre
            FROM Turnos t
            INNER JOIN EstadoTurnos et ON t.IDEstadoTurno = et.IDEstadoTurno
            INNER JOIN Veterinarios v ON t.IDVeterinario = v.IDVeterinario
            INNER JOIN Mascotas m ON t.NroHistoriaClinica = m.NroHistoriaClinica
            WHERE CONVERT(date, t.FechaHoraTurno) = @fecha
            AND t.Activo = 1
            ORDER BY t.FechaHoraTurno";

                sqlDatos.setearConsulta(query);
                sqlDatos.setearParametro("@fecha", fecha.Date); // Usamos solo la parte de fecha

                return sqlDatos.ObtenerLista(reader => new Turno
                {
                    IdTurno = Convert.ToInt32(reader["IDTurno"]),
                    FechaHoraTurno = Convert.ToDateTime(reader["FechaHoraTurno"]),
                    NroHistoriaClinica = Convert.ToInt32(reader["NroHistoriaClinica"]),
                    IdVeterinario = Convert.ToInt32(reader["IDVeterinario"]),
                    MotivoConsulta = reader["MotivoConsulta"].ToString(),
                    IdEstadoTurno = Convert.ToInt32(reader["IDEstadoTurno"]),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                    Activo = Convert.ToBoolean(reader["Activo"]),
                    VeterinarioNombre = reader["VeterinarioNombre"].ToString(),
                    MascotaNombre = reader["MascotaNombre"].ToString(),
                    EstadoTurnoDescripcion = reader["EstadoTurno"].ToString() // Agrega esta propiedad a tu clase Turno
                });
            }
            catch (Exception ex)
            {
               
                throw new Exception("Error al obtener turnos por fecha", ex);
            }
            finally
            {
                sqlDatos.cerrarConexion();
            }
        }


    }
}
