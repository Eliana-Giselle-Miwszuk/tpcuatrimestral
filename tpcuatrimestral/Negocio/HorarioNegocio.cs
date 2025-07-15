using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Dominio;

namespace Negocio
{
    public class HorarioNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<HorarioVeterinario> Listar()
        {
            List<HorarioVeterinario> lista = new List<HorarioVeterinario>();

            try
            {
                datos.setearConsulta(@"
                    SELECT id_horario, id_veterinario, 
                           lunes, martes, miercoles, jueves, viernes, sabado, domingo,
                           hora_apertura, hora_cierre
                    FROM HorarioVeterinario");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(CrearHorarioDesdeLector(datos.Lector));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener listado de horarios", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<HorarioVeterinario> ListarPorVeterinario(int idVeterinario)
        {
            List<HorarioVeterinario> lista = new List<HorarioVeterinario>();

            try
            {
                datos.setearConsulta(@"
                    SELECT id_horario, id_veterinario, 
                           lunes, martes, miercoles, jueves, viernes, sabado, domingo,
                           hora_apertura, hora_cierre
                    FROM HorarioVeterinario
                    WHERE id_veterinario = @idVeterinario");

                datos.setearParametro("@idVeterinario", idVeterinario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(CrearHorarioDesdeLector(datos.Lector));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horarios del veterinario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public HorarioVeterinario ObtenerPorId(int idHorario)
        {
            try
            {
                datos.setearConsulta(@"
                    SELECT id_horario, id_veterinario, 
                           lunes, martes, miercoles, jueves, viernes, sabado, domingo,
                           hora_apertura, hora_cierre
                    FROM HorarioVeterinario
                    WHERE id_horario = @idHorario");

                datos.setearParametro("@idHorario", idHorario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return CrearHorarioDesdeLector(datos.Lector);
                }
                else
                {
                    throw new Exception("No se encontró el horario especificado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horario por ID", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool ExisteHorarioParaVeterinario(int idVeterinario)
        {
            try
            {
                datos.setearConsulta("SELECT 1 FROM HorarioVeterinario WHERE id_veterinario = @idVeterinario");
                datos.setearParametro("@idVeterinario", idVeterinario);
                datos.ejecutarLectura();

                return datos.Lector.HasRows;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar existencia de horario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Agregar(HorarioVeterinario horario)
        {
            try
            {
                datos.setearConsulta(@"
                    INSERT INTO HorarioVeterinario 
                    (id_veterinario, lunes, martes, miercoles, jueves, viernes, sabado, domingo, hora_apertura, hora_cierre)
                    VALUES (@idVeterinario, @lunes, @martes, @miercoles, @jueves, @viernes, @sabado, @domingo, @horaApertura, @horaCierre)");

                datos.setearParametro("@idVeterinario", horario.IdVeterinario);
                datos.setearParametro("@lunes", horario.Lunes);
                datos.setearParametro("@martes", horario.Martes);
                datos.setearParametro("@miercoles", horario.Miercoles);
                datos.setearParametro("@jueves", horario.Jueves);
                datos.setearParametro("@viernes", horario.Viernes);
                datos.setearParametro("@sabado", horario.Sabado);
                datos.setearParametro("@domingo", horario.Domingo);
                datos.setearParametro("@horaApertura", horario.HoraApertura);
                datos.setearParametro("@horaCierre", horario.HoraCierre);

                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar horario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Editar(HorarioVeterinario horario)
        {
            try
            {
                datos.setearConsulta(@"
                    UPDATE HorarioVeterinario 
                    SET lunes = @lunes, martes = @martes, miercoles = @miercoles, 
                        jueves = @jueves, viernes = @viernes, sabado = @sabado, 
                        domingo = @domingo, hora_apertura = @horaApertura, 
                        hora_cierre = @horaCierre
                    WHERE id_horario = @idHorario");

                datos.setearParametro("@idHorario", horario.IdHorario);
                datos.setearParametro("@lunes", horario.Lunes);
                datos.setearParametro("@martes", horario.Martes);
                datos.setearParametro("@miercoles", horario.Miercoles);
                datos.setearParametro("@jueves", horario.Jueves);
                datos.setearParametro("@viernes", horario.Viernes);
                datos.setearParametro("@sabado", horario.Sabado);
                datos.setearParametro("@domingo", horario.Domingo);
                datos.setearParametro("@horaApertura", horario.HoraApertura);
                datos.setearParametro("@horaCierre", horario.HoraCierre);

                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar horario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Eliminar(int idHorario)
        {
            try
            {
                datos.setearConsulta("DELETE FROM HorarioVeterinario WHERE id_horario = @idHorario");
                datos.setearParametro("@idHorario", idHorario);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar horario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool GenerarHorarioBasico(int idVeterinario)
        {
            try
            {
                datos.limpiarParametros(); // <---- LIMPIAMOS ANTES DE USAR
                datos.setearConsulta(@"
            INSERT INTO HorarioVeterinario 
            (id_veterinario, lunes, martes, miercoles, jueves, viernes, sabado, domingo, hora_apertura, hora_cierre)
            VALUES (@idVeterinario, 1, 1, 1, 1, 1, 0, 0, '09:00:00', '17:00:00')");

                datos.setearParametro("@idVeterinario", idVeterinario);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private HorarioVeterinario CrearHorarioDesdeLector(SqlDataReader lector)
        {
            return new HorarioVeterinario
            {
                IdHorario = Convert.ToInt32(lector["id_horario"]),
                IdVeterinario = Convert.ToInt32(lector["id_veterinario"]),
                Lunes = Convert.ToBoolean(lector["lunes"]),
                Martes = Convert.ToBoolean(lector["martes"]),
                Miercoles = Convert.ToBoolean(lector["miercoles"]),
                Jueves = Convert.ToBoolean(lector["jueves"]),
                Viernes = Convert.ToBoolean(lector["viernes"]),
                Sabado = Convert.ToBoolean(lector["sabado"]),
                Domingo = Convert.ToBoolean(lector["domingo"]),
                HoraApertura = TimeSpan.Parse(lector["hora_apertura"].ToString()),
                HoraCierre = TimeSpan.Parse(lector["hora_cierre"].ToString())
            };
        }
    }
}