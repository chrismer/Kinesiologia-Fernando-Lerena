using System;
using System.Collections.Generic;

namespace TESTSOLAPAS
{
    /// <summary>Franja fija: un kinesiólogo titular entre dos horas.</summary>
    public class FranjaItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public int ProfesionalId { get; set; }
        public string ProfesionalNombre { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        public string Horario => $"{HoraDesde:hh\\:mm}–{HoraHasta:hh\\:mm}";
    }

    /// <summary>Reemplazo de un día. No mueve turnos ya creados.</summary>
    public class FranjaExcepcionItem
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FranjaId { get; set; }
        public string FranjaNombre { get; set; } = string.Empty;
        public int ProfesionalId { get; set; }
        public string ProfesionalNombre { get; set; } = string.Empty;
    }

    /// <summary>Quién cubre una hora. Id null si no cae en ninguna franja.</summary>
    public class AsignacionFranja
    {
        public int? ProfesionalId { get; set; }
        public string ProfesionalNombre { get; set; } = "Sin asignar";
        public string ProfesionalColor { get; set; } = "#6C757D";
    }

    /// <summary>Datos para crear una orden y sus turnos hábiles.</summary>
    public class NuevaOrdenTurnos
    {
        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; } = string.Empty;
        public string PacienteDni { get; set; } = string.Empty;
        public string Cobertura { get; set; } = string.Empty;
        public string Medico { get; set; } = string.Empty;
        public string Diagnostico { get; set; } = string.Empty;
        public TimeSpan Hora { get; set; }
    }

    /// <summary>Un turno ya resuelto, listo para insertar.</summary>
    public class TurnoGenerado
    {
        public DateTime Fecha { get; set; }
        public int? ProfesionalId { get; set; }
        public string ProfesionalNombre { get; set; } = "Sin asignar";
        public string ProfesionalColor { get; set; } = "#6C757D";
    }

    public static class FranjaCalendario
    {
        /// <summary>N días de lunes a viernes desde la fecha, inclusive si cae hábil.</summary>
        public static List<DateTime> DiasHabiles(DateTime inicio, int cantidad)
        {
            if (cantidad < 1)
                throw new ArgumentOutOfRangeException(nameof(cantidad));

            var fechas = new List<DateTime>(cantidad);
            var dia = inicio.Date;
            while (fechas.Count < cantidad)
            {
                if (dia.DayOfWeek is not (DayOfWeek.Saturday or DayOfWeek.Sunday))
                    fechas.Add(dia);
                dia = dia.AddDays(1);
            }

            return fechas;
        }

        public static bool CaeEnFranja(TimeSpan hora, FranjaItem franja)
        {
            var h = new TimeSpan(hora.Hours, hora.Minutes, 0);
            var desde = new TimeSpan(franja.HoraDesde.Hours, franja.HoraDesde.Minutes, 0);
            var hasta = new TimeSpan(franja.HoraHasta.Hours, franja.HoraHasta.Minutes, 0);
            return h >= desde && h < hasta;
        }
    }
}
