using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Implementación de ITurnoRepository con PostgreSQL (Neon) vía Dapper.
    /// Realiza JOIN entre turno, orden, paciente y profesional.
    /// </summary>
    public class NpgsqlTurnoRepository : ITurnoRepository
    {
        private const string BaseSelectTurnos = @"
            SELECT 
                t.pk_turno AS Id,
                t.fecha AS Fecha,
                t.turnohora AS Hora,
                p.pk_paciente AS PacienteId,
                p.nombre || ' ' || p.apellido AS PacienteNombre,
                p.documento AS PacienteDni,
                COALESCE(os.descripcion, 'Particular') AS Cobertura,
                pr.pk_profesional AS ProfesionalId,
                pr.nombre AS ProfesionalNombre,
                COALESCE(pr.color, '#007ACC') AS ProfesionalColor,
                COALESCE(o.diagnostico, t.nota, 'Kinesiología general') AS Diagnostico,
                COALESCE(t.nota, '') AS Nota,
                t.presente AS Presente,
                t.ausente AS Ausente,
                t.sobreturno AS Sobreturno,
                t.horapresente AS HoraPresente,
                CASE 
                    WHEN EXISTS (SELECT 1 FROM evolucion e WHERE e.fk_turno = t.pk_turno) THEN 'Atendido'
                    WHEN t.presente = TRUE THEN 'Presente'
                    WHEN t.ausente = TRUE THEN 'Ausente'
                    ELSE 'Pendiente'
                END AS Estado
            FROM turno t
            JOIN orden o ON o.pk_orden = t.fk_orden
            JOIN paciente p ON p.pk_paciente = o.fk_paciente
            LEFT JOIN obrasocial os ON os.pk_os = o.fk_os OR os.pk_os = p.fk_os
            LEFT JOIN profesional pr ON pr.pk_profesional = t.atendidopor
        ";

        public List<TurnoItem> ObtenerTurnosDelDia(DateTime fecha)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            var sql = BaseSelectTurnos + @"
                WHERE t.fecha = @Fecha
                ORDER BY t.turnohora ASC";

            return conn.Query<TurnoItem>(sql, new { Fecha = fecha.Date }).ToList();
        }

        public List<TurnoItem> ObtenerTurnosFiltrados(DateTime? desde, DateTime? hasta, int? profesionalId, string? busqueda, string? estado)
        {
            using var conn = DbConnectionFactory.CreateConnection();

            var conditions = new List<string>();
            var parameters = new DynamicParameters();

            if (desde.HasValue)
            {
                conditions.Add("t.fecha >= @Desde");
                parameters.Add("Desde", desde.Value.Date);
            }

            if (hasta.HasValue)
            {
                conditions.Add("t.fecha <= @Hasta");
                parameters.Add("Hasta", hasta.Value.Date);
            }

            if (profesionalId.HasValue && profesionalId.Value > 0)
            {
                conditions.Add("t.atendidopor = @ProfesionalId");
                parameters.Add("ProfesionalId", profesionalId.Value);
            }

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                conditions.Add("(p.nombre ILIKE @Busqueda OR p.apellido ILIKE @Busqueda OR p.documento ILIKE @Busqueda)");
                parameters.Add("Busqueda", $"%{busqueda.Trim()}%");
            }

            var whereClause = conditions.Count > 0 ? " WHERE " + string.Join(" AND ", conditions) : "";
            var sql = BaseSelectTurnos + whereClause + " ORDER BY t.fecha DESC, t.turnohora ASC";

            var turnos = conn.Query<TurnoItem>(sql, parameters).ToList();

            // Filtrado de estado en memoria o posterior si se especificó
            if (!string.IsNullOrWhiteSpace(estado) && !estado.Equals("Todos", StringComparison.OrdinalIgnoreCase))
            {
                turnos = turnos.Where(t => t.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return turnos;
        }

        public List<TurnoItem> ObtenerTurnosPorProfesional(int profesionalId, DateTime desde, DateTime hasta)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            var sql = BaseSelectTurnos + @"
                WHERE t.fecha >= @Desde AND t.fecha <= @Hasta
                  AND (@ProfesionalId = 0 OR t.atendidopor = @ProfesionalId)
                ORDER BY t.fecha ASC, t.turnohora ASC";

            return conn.Query<TurnoItem>(sql, new
            {
                Desde = desde.Date,
                Hasta = hasta.Date,
                ProfesionalId = profesionalId
            }).ToList();
        }

        public List<ProfesionalItem> ObtenerProfesionales()
        {
            using var conn = DbConnectionFactory.CreateConnection();
            return conn.Query<ProfesionalItem>(
                @"SELECT pk_profesional AS Id, nombre AS Nombre, color AS Color, activo AS Activo
                  FROM profesional
                  WHERE activo = TRUE
                  ORDER BY nombre ASC"
            ).ToList();
        }

        public void MarcarPresente(int turnoId, bool presente)
        {
            using var conn = DbConnectionFactory.CreateConnection();

            // Pasamos la hora local calculada en C# para evitar discrepancias de zona horaria con el servidor
            TimeSpan? horaPresente = presente ? DateTime.Now.TimeOfDay : null;

            conn.Execute(
                @"UPDATE turno 
                  SET presente = @Presente, 
                      horapresente = @HoraPresente 
                  WHERE pk_turno = @TurnoId",
                new { Presente = presente, HoraPresente = horaPresente, TurnoId = turnoId }
            );
        }
    }
}
