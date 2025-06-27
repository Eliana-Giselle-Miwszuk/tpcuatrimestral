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
            try {
                string consulta = "SELECT IDVeterinario, Dni, Apellido, Nombre, Direccion, Telefono, Email, " +
                    "MatriculaNacional, MatriculaProvincial, IDEspecialidad, FechaRegistro, Activo, IdUsuario " +
                    "FROM Veterinarios";
                sqlDatos.setearConsulta(consulta);
                sqlDatos.ejecutarLectura();
                while (sqlDatos.Lector.Read())
                {
                    Veterinario veterinario = new Veterinario
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
                        Activo = (bool)sqlDatos.Lector["Activo"],
                        IdUsuario = sqlDatos.Lector["IdUsuario"] != DBNull.Value ? (int)sqlDatos.Lector["IdUsuario"] : (int?)null
                    };
                    listaVeterinario.Add(veterinario); 
                }
                return listaVeterinario;

            } catch(Exception ex) {
                
                Debug.WriteLine("ERROR"+ex+ listaVeterinario);
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
                        Activo = (bool)sqlDatos.Lector["Activo"],
                        IdUsuario = sqlDatos.Lector["IdUsuario"] != DBNull.Value ? (int)sqlDatos.Lector["IdUsuario"] : (int?)null
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

                sqlDatos.setearParametro("@Dni", veterinario.Dni);
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
                sqlDatos.setearParametro("@IdUsuario", veterinario.IdUsuario ?? (object)DBNull.Value);

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

    }
}
