using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Validaciones
    {
        public  bool EsDniValido(long dni)
        {
          

            return dni > 0;//abreviatura porque retorna true si dni es mayor a 0
        }
        public bool ParametrosNoVacio(string[] parametros)//-> que rico un buen vacioo
        {
            foreach (string param in parametros)
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    return false;
                }
            }
            return true;
        }
        public bool ValoresNoNegativo(long[] enteros)
        {
            foreach(var numero in enteros)
            {
                if (numero < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool EsTelefonoValido(long telefono)
        {
            return telefono > 0;
        }

        public bool EsEmailValido(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Contains("@");
        }

        public bool EsMatriculaValida(long matricula)
        {
            return matricula > 0;
        }
        public bool DecimalNoNegativo(Decimal valor)
        {
            return valor > 0;
        }
        public bool EsNombreUsuarioValido(string nombreUsuario)
        {
            return !string.IsNullOrWhiteSpace(nombreUsuario) && nombreUsuario.Length <= 50;
        }

        
    }


}
