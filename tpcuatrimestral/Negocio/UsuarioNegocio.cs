using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Dominio;
using System.Diagnostics;

namespace Negocio
{
   public class UsuarioNegocio
    {
        AccesoDatos ds = new AccesoDatos();
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> Lista = new List<Usuario>();
            try {
                ds.setearConsulta("SELECT Id,nombre,tipoUsuario FROM Usuario");
                ds.ejecutarLectura();
                while (ds.Lector.Read())
                {
                    Usuario usuario = new Usuario {
                        idUsuario = (int)ds.Lector["Id"],
                        nombreUsuario = ds.Lector["nombre"].ToString(),
                        tipoUsuario = ds.Lector["tipoUsuario"].ToString()


                    };
                    Lista.Add(usuario);
                }
                return Lista;
            } catch(Exception ex) {
                Debug.WriteLine("NEGOCIO ERROR" + ex);
                return Lista;
            }
        }
    }
}
