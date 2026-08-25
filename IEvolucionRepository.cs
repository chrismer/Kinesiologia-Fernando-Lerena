using System.Collections.Generic;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Contrato para el repositorio de evoluciones de sesión.
    /// Implementaciones: MemoryEvolucionRepository (offline), NpgsqlEvolucionRepository (Neon).
    /// </summary>
    public interface IEvolucionRepository
    {
        /// <summary>Devuelve el historial de sesiones de un paciente ordenadas por fecha descendente.</summary>
        List<EvolucionSesion> ObtenerHistorialPorPaciente(int pacienteId);

        /// <summary>Persiste una nueva evolución de sesión.</summary>
        void GuardarEvolucion(EvolucionSesion evolucion);
    }
}
