using System;
using System.Text;

namespace Dominio
{
    public class HorarioVeterinario
    {
        public int IdHorario { get; set; }
        public int IdVeterinario { get; set; }

        // Días de atención
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }

        // Horario
        public TimeSpan HoraApertura { get; set; }
        public TimeSpan HoraCierre { get; set; }

        // Método para verificar si atiende en un día específico (versión compatible con C# 7.3)
        public bool AtiendeElDia(DayOfWeek dia)
        {
            switch (dia)
            {
                case DayOfWeek.Monday:
                    return Lunes;
                case DayOfWeek.Tuesday:
                    return Martes;
                case DayOfWeek.Wednesday:
                    return Miercoles;
                case DayOfWeek.Thursday:
                    return Jueves;
                case DayOfWeek.Friday:
                    return Viernes;
                case DayOfWeek.Saturday:
                    return Sabado;
                case DayOfWeek.Sunday:
                    return Domingo;
                default:
                    return false;
            }
        }

        // Método para validar el horario
        public bool EsHorarioValido()
        {
            return HoraApertura < HoraCierre;
        }

        // Método para obtener los días de atención como string
        public string ObtenerDiasAtencion()
        {
            var dias = new StringBuilder();

            if (Lunes) dias.Append("Lunes, ");
            if (Martes) dias.Append("Martes, ");
            if (Miercoles) dias.Append("Miércoles, ");
            if (Jueves) dias.Append("Jueves, ");
            if (Viernes) dias.Append("Viernes, ");
            if (Sabado) dias.Append("Sábado, ");
            if (Domingo) dias.Append("Domingo, ");

            if (dias.Length > 0)
                dias.Length -= 2; // Eliminar la última coma y espacio

            return dias.ToString();
        }

        // Método para obtener el horario formateado
        public string ObtenerHorarioFormateado()
        {
            return $"{HoraApertura:hh\\:mm} - {HoraCierre:hh\\:mm}";
        }

        // Método adicional para verificar si está abierto en un momento específico
        public bool EstaAbierto(DateTime fechaHora)
        {
            if (!AtiendeElDia(fechaHora.DayOfWeek))
                return false;

            TimeSpan horaActual = fechaHora.TimeOfDay;
            return horaActual >= HoraApertura && horaActual <= HoraCierre;
        }
    }
}