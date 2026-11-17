using System;

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

    public static class FranjaCalendario
    {
        public static bool CaeEnFranja(TimeSpan hora, FranjaItem franja)
        {
            var h = new TimeSpan(hora.Hours, hora.Minutes, 0);
            var desde = new TimeSpan(franja.HoraDesde.Hours, franja.HoraDesde.Minutes, 0);
            var hasta = new TimeSpan(franja.HoraHasta.Hours, franja.HoraHasta.Minutes, 0);
            return h >= desde && h < hasta;
        }
    }
}
