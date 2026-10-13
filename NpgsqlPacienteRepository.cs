using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Implementación de IPacienteRepository con PostgreSQL (Neon) vía Dapper.
    /// </summary>
    public class NpgsqlPacienteRepository : IPacienteRepository
    {
        public List<Paciente> ObtenerTodos()
        {
            using var conn = DbConnectionFactory.CreateConnection();
            return conn.Query<Paciente>(
                @"SELECT pk_paciente AS Id,
                         documento AS Dni,
                         nombre || ' ' || apellido AS NombreCompleto,
                         EXTRACT(YEAR FROM AGE(fechanac))::INT AS Edad,
                         COALESCE(os.descripcion, 'Particular') AS Cobertura,
                         observaciones AS MotivoConsulta,
                         observaciones AS DiagnosticoInicial
                  FROM paciente p
                  LEFT JOIN obrasocial os ON os.pk_os = p.fk_os
                  ORDER BY apellido, nombre"
            ).ToList();
        }

        public Paciente? ObtenerPorId(int pacienteId)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            return conn.QueryFirstOrDefault<Paciente>(
                @"SELECT pk_paciente AS Id,
                         documento AS Dni,
                         nombre || ' ' || apellido AS NombreCompleto,
                         EXTRACT(YEAR FROM AGE(fechanac))::INT AS Edad,
                         COALESCE(os.descripcion, 'Particular') AS Cobertura,
                         p.observaciones AS MotivoConsulta,
                         p.observaciones AS DiagnosticoInicial
                  FROM paciente p
                  LEFT JOIN obrasocial os ON os.pk_os = p.fk_os
                  WHERE pk_paciente = @Id",
                new { Id = pacienteId }
            );
        }

        public void Guardar(Paciente paciente)
        {
            using var conn = DbConnectionFactory.CreateConnection();

            if (paciente.Id == 0)
            {
                // Parsear NombreCompleto en nombre + apellido
                var partes = paciente.NombreCompleto.Split(' ', 2);
                var nombre = partes[0];
                var apellido = partes.Length > 1 ? partes[1] : "";

                paciente.Id = conn.ExecuteScalar<int>(
                    @"INSERT INTO paciente (documento, nombre, apellido, fechaingreso)
                      VALUES (@Dni, @Nombre, @Apellido, CURRENT_DATE)
                      RETURNING pk_paciente",
                    new { paciente.Dni, Nombre = nombre, Apellido = apellido }
                );
            }
            else
            {
                var partes = paciente.NombreCompleto.Split(' ', 2);
                var nombre = partes[0];
                var apellido = partes.Length > 1 ? partes[1] : "";

                conn.Execute(
                    @"UPDATE paciente
                      SET documento = @Dni, nombre = @Nombre, apellido = @Apellido
                      WHERE pk_paciente = @Id",
                    new { paciente.Dni, Nombre = nombre, Apellido = apellido, paciente.Id }
                );
            }
        }
        public PacienteDetalle? ObtenerDetallePorId(int pacienteId)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            return conn.QueryFirstOrDefault<PacienteDetalle>(
                @"SELECT
                      p.pk_paciente          AS Id,
                      p.documento            AS Documento,
                      p.nombre               AS Nombre,
                      p.apellido             AS Apellido,
                      p.fechanac             AS FechaNac,
                      CASE WHEN p.fechanac IS NOT NULL
                           THEN EXTRACT(YEAR FROM AGE(p.fechanac))::INT
                           ELSE NULL
                      END                    AS Edad,
                      COALESCE(p.sexo, '')            AS Sexo,
                      COALESCE(p.calle, '')            AS Calle,
                      COALESCE(p.localidad, '')        AS Localidad,
                      COALESCE(p.codpostal, '')        AS CodPostal,
                      COALESCE(p.telefono1, '')        AS Telefono1,
                      COALESCE(p.telefono2, '')        AS Telefono2,
                      COALESCE(p.telefono3, '')        AS Telefono3,
                      COALESCE(p.email, '')            AS Email,
                      COALESCE(os.descripcion, 'Particular') AS ObraSocial,
                      COALESCE(p.osafiliado, '')       AS OsAfiliado,
                      COALESCE(p.osplan, '')           AS OsPlan,
                      p.fechaingreso                  AS FechaIngreso,
                      COALESCE(p.observaciones, '')   AS Observaciones
                  FROM paciente p
                  LEFT JOIN obrasocial os ON os.pk_os = p.fk_os
                  WHERE p.pk_paciente = @Id",
                new { Id = pacienteId }
            );
        }
    }
}
