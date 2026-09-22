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

    /// <summary>
    /// Datos completos de un paciente para la ficha de detalle (modal).
    /// Incluye todos los campos de la tabla paciente + obra social.
    /// No reemplaza a Paciente: el listado sigue usando el DTO liviano.
    /// </summary>
    public class PacienteDetalle
    {
        public int Id { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime? FechaNac { get; set; }
        public int? Edad { get; set; }           // calculado con AGE() en la query
        public string Sexo { get; set; } = string.Empty;
        public string Calle { get; set; } = string.Empty;
        public string Localidad { get; set; } = string.Empty;
        public string CodPostal { get; set; } = string.Empty;
        public string Telefono1 { get; set; } = string.Empty;
        public string Telefono2 { get; set; } = string.Empty;
        public string Telefono3 { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ObraSocial { get; set; } = string.Empty;   // descripcion de obrasocial
        public string OsAfiliado { get; set; } = string.Empty;
        public string OsPlan { get; set; } = string.Empty;
        public DateTime? FechaIngreso { get; set; }
        public string Observaciones { get; set; } = string.Empty;

        /// <summary>Nombre completo calculado para mostrar en la UI.</summary>
        public string NombreCompleto => $"{Nombre} {Apellido}".Trim();
    }
}
