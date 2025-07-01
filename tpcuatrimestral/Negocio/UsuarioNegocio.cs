using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private readonly AccesoDatos _datos = new AccesoDatos();

        public Usuario ValidarUsuario(string nombreUsuario, string contrasena)
        {
            try
            {
                _datos.setearConsulta(
                    "SELECT idUsuario, nombreUsuario, contrasena, tipoUsuario, usuMaster " +
                    "FROM Usuarios " +
                    "WHERE nombreUsuario = @usuario AND activo = 1");

                _datos.setearParametro("@usuario", nombreUsuario);
                _datos.ejecutarLectura();

                if (_datos.Lector.Read())
                {
                    string contrasenaBD = _datos.Lector["contrasena"].ToString();

                    // Comparar contraseñas (aquí implementar tu lógica de comparación/hashing)
                    if (contrasena == contrasenaBD) // o comparación de hashes
                    {
                        return new Usuario
                        {
                            IdUsuario = Convert.ToInt32(_datos.Lector["idUsuario"]),
                            NombreUsuario = _datos.Lector["nombreUsuario"].ToString(),
                            TipoUsuario = _datos.Lector["tipoUsuario"].ToString(),
                            UsuMaster = Convert.ToBoolean(_datos.Lector["usuMaster"])
                        };
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario", ex);
            }
            finally
            {
                _datos.cerrarConexion();
            }
        }

        public List<Usuario> ListarPorTipo(string tipoUsuario)
        {
            try
            {
                _datos.setearConsulta(
                    "SELECT idUsuario, nombreUsuario,fechaRegistro " +
                    "FROM Usuarios " +
                    "WHERE tipoUsuario = @tipo AND activo = 1");

                _datos.setearParametro("@tipo", tipoUsuario);

                List<Usuario> lista = new List<Usuario>();
                _datos.ejecutarLectura();

                while (_datos.Lector.Read())
                {
                    lista.Add(new Usuario
                    {
                        IdUsuario      = Convert.ToInt32(_datos.Lector["idUsuario"]),
                        NombreUsuario  = _datos.Lector["nombreUsuario"].ToString(),
                        FechaRegistro  = Convert.ToDateTime(_datos.Lector["fechaRegistro"])
                    });
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar usuarios de tipo {tipoUsuario}", ex);
            }
            finally
            {
                _datos.cerrarConexion();
            }
        }

        /*public int CrearUsuario(Usuario nuevoUsuario)
        {
            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "nombreUsuario", nuevoUsuario.NombreUsuario },
                    { "contrasena", nuevoUsuario.Contrasena },
                    { "email", nuevoUsuario.Email },
                    { "tipoUsuario", nuevoUsuario.TipoUsuario },
                    { "activo", true }
                };

                return _datos.Insertar("Usuarios", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear usuario", ex);
            }
        }*/
    }
}
