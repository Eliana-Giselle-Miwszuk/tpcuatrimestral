using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;
using Negocio;
namespace Negocio
{
   public class TurnoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Turno> Listar()
        {
            List<Turno> Lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT 
                            t.IDTurno, 
                            t.FechaHoraTurno,
                            t.NroHistoriaClinica, 
                            t.IDVeterinario,
                            t.MotivoConsulta, 
                            t.IDEstadoTurno,
                            t.FechaRegistro, 
                            t.Activo,
                            m.Nombre AS MascotaNombre,
                            v.Nombre AS VeterinarioNombre
                         FROM Turnos t
                         INNER JOIN Mascotas m ON t.NroHistoriaClinica = m.NroHistoriaClinica
                         INNER JOIN Veterinarios v ON t.IDVeterinario = v.IDVeterinario
                         WHERE t.Activo = 1
                         ORDER BY t.FechaHoraTurno");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();

                    aux.IdTurno = (int)datos.Lector["IDTurno"];
                    aux.FechaHoraTurno = (DateTime)datos.Lector["FechaHoraTurno"];
                    aux.NroHistoriaClinica = (int)datos.Lector["NroHistoriaClinica"];
                    aux.IdVeterinario = (int)datos.Lector["IDVeterinario"];
                    aux.MotivoConsulta = datos.Lector["MotivoConsulta"].ToString();
                    aux.IdEstadoTurno = (int)datos.Lector["IDEstadoTurno"];
                    aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    aux.MascotaNombre = datos.Lector["MascotaNombre"].ToString();
                    aux.VeterinarioNombre = datos.Lector["VeterinarioNombre"].ToString();

                    Lista.Add(aux);
                }

                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el listado de turnos", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }










        public Turno ObtenerTurnoPorID(int idTurno)
        {
            try
            {
                datos.setearConsulta("SELECT * FROM Turnos WHERE IDTurno = @id");
                datos.setearParametro("@id", idTurno);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Turno
                    {
                        IdTurno = (int)datos.Lector["IDTurno"],
                        FechaHoraTurno = (DateTime)datos.Lector["FechaHoraTurno"],
                        NroHistoriaClinica = (int)datos.Lector["NroHistoriaClinica"],
                        IdVeterinario = (int)datos.Lector["IDVeterinario"],
                        MotivoConsulta = datos.Lector["MotivoConsulta"].ToString(),
                        IdEstadoTurno = (int)datos.Lector["IDEstadoTurno"],
                        FechaRegistro = (DateTime)datos.Lector["FechaRegistro"],
                        Activo = (bool)datos.Lector["Activo"]
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
                datos.cerrarConexion();
            }
        }

        public List<Turno> ListarTurnosPorHistoria(int nroHistoriaClinica)
        {
            try
            {
                List<Turno> lista = new List<Turno>();
                string query = "SELECT * FROM Turnos WHERE NroHistoriaClinica = @nroHistoria AND Activo = 1";

                datos.setearConsulta(query);
                datos.setearParametro("@nroHistoria", nroHistoriaClinica);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno turno = new Turno
                    {
                        IdTurno = (int)datos.Lector["IDTurno"],
                        FechaHoraTurno = (DateTime)datos.Lector["FechaHoraTurno"],
                        NroHistoriaClinica = (int)datos.Lector["NroHistoriaClinica"],
                        IdVeterinario = (int)datos.Lector["IDVeterinario"],
                        MotivoConsulta = datos.Lector["MotivoConsulta"].ToString(),
                        IdEstadoTurno = (int)datos.Lector["IDEstadoTurno"],
                        FechaRegistro = (DateTime)datos.Lector["FechaRegistro"],
                        Activo = (bool)datos.Lector["Activo"]
                    };

                    lista.Add(turno);
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
        public Turno ObtenerTurnoPorId(int idTurno)
        {
            try
            {
                string query = @"
        SELECT 
            t.IDTurno, 
            t.FechaHoraTurno, 
            t.NroHistoriaClinica, 
            t.IDVeterinario, 
            t.MotivoConsulta, 
            t.IDEstadoTurno,
            et.TipoEstado AS EstadoTurno,
            v.Nombre + ' ' + v.Apellido AS VeterinarioNombre,
            m.Nombre AS MascotaNombre
        FROM Turnos t
        INNER JOIN EstadoTurnos et ON t.IDEstadoTurno = et.IDEstadoTurno
        INNER JOIN Veterinarios v ON t.IDVeterinario = v.IDVeterinario
        INNER JOIN Mascotas m ON t.NroHistoriaClinica = m.NroHistoriaClinica
        WHERE t.IDTurno = @idTurno";

                datos.setearConsulta(query);
                datos.setearParametro("@idTurno", idTurno);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Turno
                    {
                        IdTurno = (int)datos.Lector["IDTurno"],
                        FechaHoraTurno = (DateTime)datos.Lector["FechaHoraTurno"],
                        NroHistoriaClinica = (int)datos.Lector["NroHistoriaClinica"],
                        IdVeterinario = (int)datos.Lector["IDVeterinario"],
                        MotivoConsulta = datos.Lector["MotivoConsulta"].ToString(),
                        IdEstadoTurno = (int)datos.Lector["IDEstadoTurno"],
                        VeterinarioNombre = datos.Lector["VeterinarioNombre"].ToString(),
                        MascotaNombre = datos.Lector["MascotaNombre"].ToString(),
                        EstadoTurnoDescripcion = datos.Lector["EstadoTurno"].ToString()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener turno por ID", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool ActualizarEstadoTurno(int idTurno, int nuevoEstado)
        {
            try
            {
                string query = "UPDATE Turnos SET IDEstadoTurno = @estado WHERE IDTurno = @idTurno";

                datos.setearConsulta(query);
                datos.setearParametro("@estado", nuevoEstado);
                datos.setearParametro("@idTurno", idTurno);

                 datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar estado del turno", ex);
                
            }
        }
        public List<EstadoTurno> ListarEstadoTurnos()
        {
            try
            {
                List<EstadoTurno> lista = new List<EstadoTurno>();
                string query = "SELECT IDEstadoTurno, TipoEstado FROM EstadoTurnos";

                datos.setearConsulta(query);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new EstadoTurno
                    {
                        IDEstadoTurno = (int)datos.Lector["IDEstadoTurno"],
                        TipoEstado = datos.Lector["TipoEstado"].ToString()
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar estados de turno", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Turno GetId(int idTurno)
        {
            Turno turno = null;
            try
            {
                string query = @"SELECT t.IDTurno, t.IDEstadoTurno, et.TipoEstado 
                        FROM Turnos t
                        INNER JOIN EstadoTurnos et ON t.IDEstadoTurno = et.IDEstadoTurno
                        WHERE t.IDTurno = @idTurno";

                datos.setearConsulta(query);
                datos.setearParametro("@idTurno", idTurno);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    turno = new Turno
                    {
                        IdTurno = Convert.ToInt32(datos.Lector["IDTurno"]),
                        IdEstadoTurno = Convert.ToInt32(datos.Lector["IDEstadoTurno"]),
                        EstadoTurnoDescripcion = datos.Lector["TipoEstado"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener turno por ID", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return turno;
        }
        public List<Veterinario> ListarVeterinariosDisponibles(DateTime fecha)
        {
            List<Veterinario> lista = new List<Veterinario>();
            try
            {
                int diaSemana = (int)fecha.DayOfWeek;
                datos.limpiarParametros();
                datos.setearConsulta(@"
                    SELECT v.IDVeterinario, v.Nombre, v.Apellido
                    FROM Veterinarios v
                    INNER JOIN HorarioVeterinario h ON v.IDVeterinario = h.id_veterinario
                    WHERE v.Activo = 1 AND 
                    (
                        (h.domingo = 1 AND @diaSemana = 0) OR
                        (h.lunes = 1 AND @diaSemana = 1) OR
                        (h.martes = 1 AND @diaSemana = 2) OR
                        (h.miercoles = 1 AND @diaSemana = 3) OR
                        (h.jueves = 1 AND @diaSemana = 4) OR
                        (h.viernes = 1 AND @diaSemana = 5) OR
                        (h.sabado = 1 AND @diaSemana = 6)
                    )");

                datos.setearParametro("@diaSemana", diaSemana);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Veterinario aux = new Veterinario();
                    aux.IDVeterinario = (int)datos.Lector["IDVeterinario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];

                    lista.Add(aux);
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
        public HorarioVeterinario ObtenerHorarioVeterinario(int idVeterinario)
        {
            try
            {
                datos.limpiarParametros();
                datos.setearConsulta("SELECT hora_apertura, hora_cierre FROM HorarioVeterinario WHERE id_veterinario = @idVeterinario");
                datos.setearParametro("@idVeterinario", idVeterinario);
                datos.ejecutarLectura();

                HorarioVeterinario horario = new HorarioVeterinario();

                if (datos.Lector.Read())
                {
                    // Verifica que no sean nulos
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("hora_apertura")))
                        horario.HoraApertura = (TimeSpan)datos.Lector["hora_apertura"];
                    else
                        throw new Exception("El veterinario no tiene hora de apertura configurada");

                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("hora_cierre")))
                        horario.HoraCierre = (TimeSpan)datos.Lector["hora_cierre"];
                    else
                        throw new Exception("El veterinario no tiene hora de cierre configurada");
                }
                else
                {
                    throw new Exception("No se encontró horario para el veterinario seleccionado");
                }

                return horario;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EXCEPCIÓN en ObtenerHorarioVeterinario: {ex.ToString()}");
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<DateTime> ListarTurnosOcupados(int idVeterinario, DateTime fecha)
        {
            List<DateTime> lista = new List<DateTime>();
            try
            {
                datos.limpiarParametros();
                datos.setearConsulta(@"
            SELECT FechaHoraTurno 
            FROM Turnos 
            WHERE IDVeterinario = @idVeterinario 
            AND CONVERT(DATE, FechaHoraTurno) = @fecha
            AND Activo = 1");

                datos.setearParametro("@idVeterinario", idVeterinario);
                datos.setearParametro("@fecha", fecha.Date);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("FechaHoraTurno")))
                        lista.Add((DateTime)datos.Lector["FechaHoraTurno"]);
                }

                Debug.WriteLine($"Turnos ocupados encontrados: {lista.Count}");
                return lista;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EXCEPCIÓN en ListarTurnosOcupados: {ex.ToString()}");
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void AgregarTurno(Turno turno)
        {
            try
            {
                
                datos.setearConsulta(@"
                    INSERT INTO Turnos (
                        FechaHoraTurno, 
                        NroHistoriaClinica, 
                        IDVeterinario, 
                        MotivoConsulta, 
                        IDEstadoTurno, 
                        FechaRegistro, 
                        Activo
                    ) VALUES (
                        @FechaHoraTurno, 
                        @NroHistoriaClinica, 
                        @IDVeterinario, 
                        @MotivoConsulta, 
                        1, -- Pendiente
                        GETDATE(), 
                        1
                    )");

                datos.setearParametro("@FechaHoraTurno", turno.FechaHoraTurno);
                datos.setearParametro("@NroHistoriaClinica", turno.NroHistoriaClinica);
                datos.setearParametro("@IDVeterinario", turno.IdVeterinario);
                datos.setearParametro("@MotivoConsulta", turno.MotivoConsulta);

                datos.ejecutarAccion();
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
        public List<Mascota> ListarMascotas()
        {
            List<Mascota> lista = new List<Mascota>();
            try
            {
                datos.limpiarParametros();
                datos.setearConsulta("SELECT NroHistoriaClinica, Nombre FROM Mascotas WHERE Activo = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mascota aux = new Mascota();
                    aux.NroHistoriaClinica = (int)datos.Lector["NroHistoriaClinica"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(aux);
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
    }
}
