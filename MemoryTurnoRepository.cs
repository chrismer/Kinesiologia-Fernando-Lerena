using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Implementación en memoria de ITurnoRepository para desarrollo offline.
    /// </summary>
    public class MemoryTurnoRepository : ITurnoRepository
    {
        private readonly List<TurnoItem> _turnos;
        private readonly List<ProfesionalItem> _profesionales;

        public MemoryTurnoRepository()
        {
            _profesionales = new List<ProfesionalItem>
            {
                new ProfesionalItem { Id = 1, Nombre = "Dr. Juan Pérez", Color = "#007ACC", Activo = true },
                new ProfesionalItem { Id = 2, Nombre = "Lic. Ana Torres", Color = "#28A745", Activo = true },
                new ProfesionalItem { Id = 3, Nombre = "Lic. Martín López", Color = "#E83E8C", Activo = true }
            };

            var hoy = DateTime.Today;

            _turnos = new List<TurnoItem>
            {
                new TurnoItem
                {
                    Id = 1, Fecha = hoy, Hora = new TimeSpan(8, 0, 0),
                    PacienteId = 1, PacienteNombre = "María Gómez Blanía", PacienteDni = "12378738", Cobertura = "OSDE 210",
                    ProfesionalId = 1, ProfesionalNombre = "Dr. Juan Pérez", ProfesionalColor = "#007ACC",
                    Diagnostico = "Lumbalgia crónica - Hernia L4-L5", Presente = true, Estado = "Atendido"
                },
                new TurnoItem
                {
                    Id = 2, Fecha = hoy, Hora = new TimeSpan(9, 0, 0),
                    PacienteId = 2, PacienteNombre = "Carlos Fernández", PacienteDni = "24567890", Cobertura = "IOMA",
                    ProfesionalId = 2, ProfesionalNombre = "Lic. Ana Torres", ProfesionalColor = "#28A745",
                    Diagnostico = "Post-op plástica LCA rodilla", Presente = true, Estado = "Presente"
                },
                new TurnoItem
                {
                    Id = 3, Fecha = hoy, Hora = new TimeSpan(10, 0, 0),
                    PacienteId = 3, PacienteNombre = "Sofía Ramírez", PacienteDni = "31234567", Cobertura = "OSDE 210",
                    ProfesionalId = 1, ProfesionalNombre = "Dr. Juan Pérez", ProfesionalColor = "#007ACC",
                    Diagnostico = "Cervicobraquialgia", Presente = false, Estado = "Pendiente"
                },
                new TurnoItem
                {
                    Id = 4, Fecha = hoy, Hora = new TimeSpan(11, 30, 0),
                    PacienteId = 4, PacienteNombre = "Lucas Díaz", PacienteDni = "29876543", Cobertura = "Swiss Medical",
                    ProfesionalId = 3, ProfesionalNombre = "Lic. Martín López", ProfesionalColor = "#E83E8C",
                    Diagnostico = "Desgarro gemelo interno", Presente = false, Estado = "Pendiente"
                },
                new TurnoItem
                {
                    Id = 5, Fecha = hoy, Hora = new TimeSpan(14, 0, 0),
                    PacienteId = 5, PacienteNombre = "Valentina Suárez", PacienteDni = "35678901", Cobertura = "Particular",
                    ProfesionalId = 2, ProfesionalNombre = "Lic. Ana Torres", ProfesionalColor = "#28A745",
                    Diagnostico = "Esguince de tobillo izq.", Presente = false, Estado = "Pendiente"
                },
                new TurnoItem
                {
                    Id = 6, Fecha = hoy, Hora = new TimeSpan(16, 0, 0),
                    PacienteId = 6, PacienteNombre = "Tomás Molina", PacienteDni = "22345678", Cobertura = "PAMI",
                    ProfesionalId = 1, ProfesionalNombre = "Dr. Juan Pérez", ProfesionalColor = "#007ACC",
                    Diagnostico = "Coxartrosis bilateral", Presente = false, Estado = "Pendiente"
                }
            };
        }

        public List<TurnoItem> ObtenerTurnosDelDia(DateTime fecha) =>
            _turnos.Where(t => t.Fecha.Date == fecha.Date).OrderBy(t => t.Hora).ToList();

        public List<TurnoItem> ObtenerTurnosFiltrados(DateTime? desde, DateTime? hasta, int? profesionalId, string? busqueda, string? estado)
        {
            var query = _turnos.AsQueryable();

            if (desde.HasValue) query = query.Where(t => t.Fecha.Date >= desde.Value.Date);
            if (hasta.HasValue) query = query.Where(t => t.Fecha.Date <= hasta.Value.Date);
            if (profesionalId.HasValue && profesionalId.Value > 0) query = query.Where(t => t.ProfesionalId == profesionalId.Value);
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                query = query.Where(t => t.PacienteNombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                         t.PacienteDni.Contains(busqueda, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(estado) && !estado.Equals("Todos", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(t => t.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));
            }

            return query.OrderByDescending(t => t.Fecha).ThenBy(t => t.Hora).ToList();
        }

        public List<TurnoItem> ObtenerTurnosPorProfesional(int profesionalId, DateTime desde, DateTime hasta) =>
            _turnos.Where(t => t.Fecha.Date >= desde.Date && t.Fecha.Date <= hasta.Date &&
                               (profesionalId == 0 || t.ProfesionalId == profesionalId))
                   .OrderBy(t => t.Fecha).ThenBy(t => t.Hora).ToList();

        public List<ProfesionalItem> ObtenerProfesionales() => _profesionales.ToList();

        public void MarcarPresente(int turnoId, bool presente)
        {
            var turno = _turnos.FirstOrDefault(t => t.Id == turnoId);
            if (turno != null)
            {
                turno.Presente = presente;
                turno.HoraPresente = presente ? DateTime.Now.TimeOfDay : null;
                if (turno.Estado != "Atendido")
                {
                    turno.Estado = presente ? "Presente" : "Pendiente";
                }
            }
        }
    }
}
