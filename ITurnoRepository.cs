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
    }
}
