using System;
using System.Collections.Generic;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Representa a un paciente del consultorio kinesiológico.
    /// </summary>
    public class Paciente
    {
        public int Id { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Cobertura { get; set; } = string.Empty;
        public string MotivoConsulta { get; set; } = string.Empty;
        public string DiagnosticoInicial { get; set; } = string.Empty;
    }

    /// <summary>
    /// Representa el registro de evolución de una sesión de kinesiología.
    /// </summary>
    public class EvolucionSesion
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int? TurnoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Profesional { get; set; } = string.Empty;

        /// <summary>
        /// Nivel de dolor según la Escala Visual Analógica (EVA), de 0 a 10.
        /// </summary>
        public int NivelDolorEva { get; set; }

        /// <summary>
        /// Técnicas aplicadas durante la sesión, separadas por coma.
        /// Ejemplo: "Magnetoterapia, Ejercicio Terapéutico"
        /// </summary>
        public string TecnicasAplicadas { get; set; } = string.Empty;

        /// <summary>
        /// Notas libres del profesional sobre la evolución del paciente en la sesión.
        /// </summary>
        public string ComentariosEvolucion { get; set; } = string.Empty;
    }
}
