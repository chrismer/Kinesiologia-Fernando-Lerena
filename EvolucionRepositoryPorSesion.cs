using System.Collections.Generic;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Envuelve otro IEvolucionRepository y firma cada evolución nueva
    /// con el kinesiólogo logueado (nombre e id), no con un nombre fijo.
    /// El historial del paciente se sigue viendo completo: el paciente es de la clínica.
    /// </summary>
    public class EvolucionRepositoryPorSesion : IEvolucionRepository
    {
        private readonly IEvolucionRepository _inner;
        private readonly SesionActual _sesion;

        public EvolucionRepositoryPorSesion(IEvolucionRepository inner, SesionActual sesion)
        {
            _inner = inner;
            _sesion = sesion;
        }

        public List<EvolucionSesion> ObtenerHistorialPorPaciente(int pacienteId) =>
            _inner.ObtenerHistorialPorPaciente(pacienteId);

        public void GuardarEvolucion(EvolucionSesion evolucion)
        {
            evolucion.Profesional = _sesion.Nombre;
            evolucion.ProfesionalId = _sesion.ProfesionalId;
            _inner.GuardarEvolucion(evolucion);
        }
    }
}
