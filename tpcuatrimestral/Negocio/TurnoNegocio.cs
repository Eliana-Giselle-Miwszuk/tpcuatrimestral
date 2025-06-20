using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;
namespace Negocio
{
   public class TurnoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

       

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
    }
}
