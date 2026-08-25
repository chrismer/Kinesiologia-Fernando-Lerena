using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Implementación de IEvolucionRepository con PostgreSQL (Neon) vía Dapper.
    /// Consulta la tabla 'evolucion' creada con 001_create_tables.sql.
    /// </summary>
    public class NpgsqlEvolucionRepository : IEvolucionRepository
    {
        public List<EvolucionSesion> ObtenerHistorialPorPaciente(int pacienteId)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            return conn.Query<EvolucionSesion>(
                @"SELECT e.pk_evolucion AS Id,
                         e.fk_paciente AS PacienteId,
                         e.fecha AS Fecha,
                         p.nombre AS Profesional,
                         e.niveldoloreva AS NivelDolorEva,
                         e.tecnicasaplicadas AS TecnicasAplicadas,
                         e.comentariosevolucion AS ComentariosEvolucion
                  FROM evolucion e
                  LEFT JOIN profesional p ON p.pk_profesional = e.fk_profesional
                  WHERE e.fk_paciente = @PacienteId
                  ORDER BY e.fecha DESC",
                new { PacienteId = pacienteId }
            ).ToList();
        }

        public void GuardarEvolucion(EvolucionSesion evolucion)
        {
            using var conn = DbConnectionFactory.CreateConnection();

            // Buscar el PK_Profesional por nombre (simplificado para esta fase)
            int? profesionalId = conn.QueryFirstOrDefault<int?>(
                "SELECT pk_profesional FROM profesional WHERE nombre = @Nombre LIMIT 1",
                new { Nombre = evolucion.Profesional }
            );

            // Si no se encuentra el profesional, usar el primero disponible
            profesionalId ??= conn.QueryFirstOrDefault<int?>(
                "SELECT pk_profesional FROM profesional ORDER BY pk_profesional LIMIT 1"
            );

            conn.Execute(
                @"INSERT INTO evolucion (fk_paciente, fecha, fk_profesional, niveldoloreva,
                                         tecnicasaplicadas, comentariosevolucion)
                  VALUES (@PacienteId, @Fecha, @ProfesionalId, @NivelDolorEva,
                          @TecnicasAplicadas, @ComentariosEvolucion)",
                new
                {
                    evolucion.PacienteId,
                    Fecha = evolucion.Fecha == default ? DateTime.Now : evolucion.Fecha,
                    ProfesionalId = profesionalId ?? 1,
                    evolucion.NivelDolorEva,
                    evolucion.TecnicasAplicadas,
                    evolucion.ComentariosEvolucion
                }
            );
        }
    }
}
