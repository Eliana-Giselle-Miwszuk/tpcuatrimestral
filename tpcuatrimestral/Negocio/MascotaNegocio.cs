using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;
namespace Negocio
{
    public class MascotaNegocio
    {
        AccesoDatos accesoDatos = new AccesoDatos();

        public int AgregarMascota(Mascota mascota)
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
        }

        public List<Mascota> ListarMascotas()
        {
            try {
                string condiciones = "Activo=@activo";
                var parametros = new Dictionary<string, object>
                {
                    {"Activo",true }
                };
                var mascotas = accesoDatos.Listar<Mascota>("Mascotas", condiciones,parametros,MapeoMascota);
                return mascotas;
            } catch {
                return null;
            }
        }
        public bool ActualizarMascota(Mascota mascota)
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
        }
        private Mascota MapeoMascota(SqlDataReader reader)
        {
            return new Mascota
            {
                NroHistoriaClinica = Convert.ToInt32(reader["NroHistoriaClinica"]),
                IDDueño = Convert.ToInt32(reader["IDDueño"]),
                IDRaza = Convert.ToInt32(reader["IDRaza"]),
                Nombre = reader["Nombre"].ToString(),
                Sexo = reader["Sexo"].ToString(),
                Color = reader["Color"].ToString(),
                Peso = Convert.ToDecimal(reader["Peso"]),
                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                Activo = Convert.ToBoolean(reader["Activo"])
            };

        }
        public List<KeyValuePair<int, string>> ListarHistoriasClinicasDisponibles()
        {
            try
            {
                return accesoDatos.CargarDesplegable(
                    tabla: "Mascotas",
                    idColumna: "NroHistoriaClinica",
                    textoColumna: "CONCAT('HC-', NroHistoriaClinica, ' - ', Nombre) as InfoMascota",
                    condiciones: "Activo = 1"
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Mascota ObtenerPorNroHistoria(int nroHistoriaClinica)
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
        }
        public bool EliminarMasco(int nro)
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
        }



    }
}
