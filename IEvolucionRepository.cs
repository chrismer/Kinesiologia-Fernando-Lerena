using System.Collections.Generic;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Contrato para el repositorio de evoluciones de sesión.
    /// La implementación actual es en memoria; cuando llegue la base de datos
    /// se proveerá una nueva implementación sin cambiar esta interfaz ni la UI.
    /// 
    /// Nota: ObtenerPacienteDemo() vive aquí como atajo para esta fase de desarrollo.
    /// En la tarea de integración con DB los pacientes deberán tener su propio
    /// repositorio y este método se migrará o eliminará.
    /// </summary>
    public interface IEvolucionRepository
    {
        /// <summary>Devuelve el historial de sesiones de un paciente ordenadas por fecha descendente.</summary>
        List<EvolucionSesion> ObtenerHistorialPorPaciente(int pacienteId);

        /// <summary>Persiste una nueva evolución de sesión.</summary>
        void GuardarEvolucion(EvolucionSesion evolucion);

        /// <summary>
        /// Devuelve un paciente de prueba para uso durante el desarrollo,
        /// mientras no exista una pantalla de selección de pacientes real.
        /// </summary>
        Paciente ObtenerPacienteDemo();
    }
}
