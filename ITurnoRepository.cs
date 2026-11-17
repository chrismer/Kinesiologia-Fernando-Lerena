using System;
using System.Collections.Generic;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Contrato para el repositorio de turnos y profesionales.
    /// </summary>
    public interface ITurnoRepository
    {
        /// <summary>Devuelve los turnos correspondientes a una fecha específica (para el Dashboard).</summary>
        List<TurnoItem> ObtenerTurnosDelDia(DateTime fecha);

        /// <summary>Devuelve los turnos filtrados según rango de fechas, profesional, búsqueda por paciente y estado.</summary>
        List<TurnoItem> ObtenerTurnosFiltrados(DateTime? desde, DateTime? hasta, int? profesionalId, string? busqueda, string? estado);

        /// <summary>Devuelve los turnos de un profesional en un rango de fechas (para la Agenda).</summary>
        List<TurnoItem> ObtenerTurnosPorProfesional(int profesionalId, DateTime desde, DateTime hasta);

        /// <summary>Devuelve la lista de profesionales activos con su color de agenda.</summary>
        List<ProfesionalItem> ObtenerProfesionales();

        /// <summary>Marca o desmarca un turno como presente (paciente en sala de espera).</summary>
        void MarcarPresente(int turnoId, bool presente);

        /// <summary>
        /// Igual que ObtenerTurnosFiltrados, sin el recorte por kinesiólogo de la sesión.
        /// Turnos lo usa para que un suplente vea turnos de otros y se los asigne.
        /// </summary>
        List<TurnoItem> ObtenerTurnosParaTomar(DateTime? desde, DateTime? hasta, int? profesionalId, string? busqueda, string? estado);

        /// <summary>Pasa el turno a otro kinesiólogo. No cambia la grilla fija.</summary>
        void AsignarProfesional(int turnoId, int profesionalId);

        /// <summary>Crea la orden y un turno por cada fecha ya resuelta. No reescribe turnos viejos.</summary>
        int CrearOrdenConTurnos(NuevaOrdenTurnos datos, IReadOnlyList<TurnoGenerado> turnos);
    }
}
