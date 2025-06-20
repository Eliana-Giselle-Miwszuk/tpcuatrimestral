using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;
namespace Negocio
{
  public class HistoriaClinicaNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public int AgregarHistoriaClinica(HistoriaClinica historia)
        {
            try
            {
                var parametros = new Dictionary<string, object>
                {
                    {"NroHistoriaClinica", historia.NroHistoriaClinica},
                    {"IDTurno", historia.IDTurno},
                    {"FechaHoraCita", historia.FechaHoraCita},
                    {"Sintomas", historia.Sintomas},
                    {"Diagnostico", historia.Diagnostico},
                    {"Tratamiento", historia.Tratamiento},
                    {"Medicacion", historia.Medicacion},
                    {"Observaciones", historia.Observaciones},
                    {"FechaRegistro", DateTime.Now},
                    {"Activo", true}
                };

                return datos.Insertar("HistoriasClinicas", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ActualizarHC(HistoriaClinica historiaClinica)
        {
            try
            {
                var parametros = new Dictionary<string, object>
        {
            { "Sintomas", historiaClinica.Sintomas },
            { "Diagnostico", historiaClinica.Diagnostico },
            { "Tratamiento", historiaClinica.Tratamiento },
            { "Medicacion", historiaClinica.Medicacion },
            { "Observaciones", historiaClinica.Observaciones }
           // { "IDRegistro", historiaClinica.IDRegistro }
        };

                var condicion = $"IDRegistro = {historiaClinica.IDRegistro}";

                int filasAfectadas = datos.Actualizar("HistoriasClinicas", parametros, condicion);
                return filasAfectadas > 0;
            }
            catch
            {
                return false;
            }
        }


        public List<HistoriaClinica> ListarPorMascota(int nroHistoriaClinica)
        {
            try
            {
                List<HistoriaClinica> lista = new List<HistoriaClinica>();
                string query = "SELECT * FROM HistoriasClinicas WHERE NroHistoriaClinica = @nroHistoria AND Activo = 1";

                datos.setearConsulta(query);
                datos.setearParametro("@nroHistoria", nroHistoriaClinica);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    HistoriaClinica historia = new HistoriaClinica
                    {
                        IDRegistro = (int)datos.Lector["IDRegistro"],
                        NroHistoriaClinica = (int)datos.Lector["NroHistoriaClinica"],
                        IDTurno = (int)datos.Lector["IDTurno"],
                        FechaHoraCita = (DateTime)datos.Lector["FechaHoraCita"],
                        Sintomas = datos.Lector["Sintomas"].ToString(),
                        Diagnostico = datos.Lector["Diagnostico"].ToString(),
                        Tratamiento = datos.Lector["Tratamiento"].ToString(),
                        Medicacion = datos.Lector["Medicacion"].ToString(),
                        Observaciones = datos.Lector["Observaciones"].ToString(),
                        FechaRegistro = (DateTime)datos.Lector["FechaRegistro"],
                        Activo = (bool)datos.Lector["Activo"]
                    };

                    lista.Add(historia);
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
        public List<HistoriaClinica> ListarTodos()
        {
            try
            {
                var condicion = "Activo = @Activo";
                var parametros = new Dictionary<string, object> { {"Activo",true } };
                var Hcs = datos.Listar<HistoriaClinica>("HistoriasClinicas", condicion, parametros,Mapeo);
                return Hcs;
            }
            catch
            {
                return null;
            }
        }
        /*      public bool EliminarMasco(int nro)
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

        public bool EliminarHC(int id)
        {
            try {
                var parametro = new Dictionary<string, object> { { "Activo" , false} };
                var condicion = $"IDRegistro = { id}";
                int filaAfectada = datos.Actualizar("HistoriasClinicas", parametro, condicion);
                return filaAfectada > 0;
            
            } catch {
                return false;
                    }
        }
        public HistoriaClinica Mapeo(SqlDataReader reader)
        {
            return new HistoriaClinica
            {
                IDRegistro = reader.GetInt32(reader.GetOrdinal("IDRegistro")),
                NroHistoriaClinica = reader.GetInt32(reader.GetOrdinal("NroHistoriaClinica")),
                IDTurno = reader.GetInt32(reader.GetOrdinal("IDTurno")),
                FechaHoraCita = reader.GetDateTime(reader.GetOrdinal("FechaHoraCita")),
                Sintomas = reader.GetString(reader.GetOrdinal("Sintomas")),
                Diagnostico = reader.GetString(reader.GetOrdinal("Diagnostico")),
                Tratamiento = reader.GetString(reader.GetOrdinal("Tratamiento")),
                Medicacion = reader.IsDBNull(reader.GetOrdinal("Medicacion")) ? null : reader.GetString(reader.GetOrdinal("Medicacion")),
                Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones")),
                FechaRegistro = reader.GetDateTime(reader.GetOrdinal("FechaRegistro")),
                Activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
            };

        }
        public HistoriaClinica ObtenerPorID(int idRegistro)
        {
            try
            {
                var condicion = "IDRegistro = @id";
                var parametros = new Dictionary<string, object>
        {
            { "id", idRegistro }
        };

                var resultado = datos.Listar("HistoriasClinicas", condicion, parametros, Mapeo);
                return resultado.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la historia clínica con ID {idRegistro}: {ex.Message}", ex);
            }
        }




    }
}
