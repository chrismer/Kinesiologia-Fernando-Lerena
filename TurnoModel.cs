using System;

namespace TESTSOLAPAS
{
    /// <summary>
    /// DTO que representa un turno con los datos aplanados de Paciente, Profesional y Orden médica.
    /// Utilizado en Dashboard, Turnos y Agenda.
    /// </summary>
    public class TurnoItem
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }

        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; } = string.Empty;
        public string PacienteDni { get; set; } = string.Empty;
        public string Cobertura { get; set; } = string.Empty;

        public int ProfesionalId { get; set; }
        public string ProfesionalNombre { get; set; } = string.Empty;
        public string ProfesionalColor { get; set; } = "#007ACC";

        public string Diagnostico { get; set; } = string.Empty;
        public string Nota { get; set; } = string.Empty;

        public bool Presente { get; set; }
        public bool Ausente { get; set; }
        public bool Sobreturno { get; set; }
        public TimeSpan? HoraPresente { get; set; }

        /// <summary>
        /// Estado calculado: "Atendido" (si tiene evolución), "Presente" (en sala), "Ausente", o "Pendiente".
        /// </summary>
        public string Estado { get; set; } = "Pendiente";
    }

    /// <summary>
    /// Representa un profesional de la kinesiología con su color de agenda.
    /// </summary>
    public class ProfesionalItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Color { get; set; } = "#007ACC";
        public bool Activo { get; set; } = true;
    }
}
