using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Envuelve otro ITurnoRepository y deja ver solo los turnos de un profesional.
    /// Principal lo usa cuando entra un kinesiólogo; admin y recepción ven todo.
    /// Las pantallas no cambian: el filtro se aplica acá aunque elijan "Todos".
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
    }
}
