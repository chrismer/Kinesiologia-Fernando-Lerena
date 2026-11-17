using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Envuelve otro ITurnoRepository.
    /// El Dashboard sigue viendo solo los turnos del kinesiólogo logueado.
    /// ObtenerTurnosParaTomar no filtra: en Turnos puede ver los de otros y asignárselos.
    /// AsignarProfesional solo acepta su propio id.
    /// </summary>
    public class TurnoRepositoryPorSesion : ITurnoRepository
    {
        private readonly ITurnoRepository _inner;
        private readonly int _profesionalId;

        public TurnoRepositoryPorSesion(ITurnoRepository inner, int profesionalId)
        {
            _inner = inner;
            _profesionalId = profesionalId;
        }

        public List<TurnoItem> ObtenerTurnosDelDia(DateTime fecha) =>
            _inner.ObtenerTurnosDelDia(fecha)
                  .Where(t => t.ProfesionalId == _profesionalId)
                  .ToList();

        public List<TurnoItem> ObtenerTurnosFiltrados(DateTime? desde, DateTime? hasta, int? profesionalId, string? busqueda, string? estado) =>
            _inner.ObtenerTurnosFiltrados(desde, hasta, _profesionalId, busqueda, estado);

        public List<TurnoItem> ObtenerTurnosPorProfesional(int profesionalId, DateTime desde, DateTime hasta) =>
            _inner.ObtenerTurnosPorProfesional(_profesionalId, desde, hasta);

        public List<ProfesionalItem> ObtenerProfesionales() =>
            _inner.ObtenerProfesionales()
                  .Where(p => p.Id == _profesionalId)
                  .ToList();

        public void MarcarPresente(int turnoId, bool presente) =>
            _inner.MarcarPresente(turnoId, presente);

        public List<TurnoItem> ObtenerTurnosParaTomar(DateTime? desde, DateTime? hasta, int? profesionalId, string? busqueda, string? estado) =>
            _inner.ObtenerTurnosParaTomar(desde, hasta, profesionalId, busqueda, estado);

        public void AsignarProfesional(int turnoId, int profesionalId)
        {
            if (profesionalId != _profesionalId)
                throw new InvalidOperationException("Un kinesiólogo solo puede asignarse el turno a sí mismo.");

            _inner.AsignarProfesional(turnoId, profesionalId);
        }

        public int CrearOrdenConTurnos(NuevaOrdenTurnos datos, IReadOnlyList<TurnoGenerado> turnos) =>
            _inner.CrearOrdenConTurnos(datos, turnos);
    }
}
