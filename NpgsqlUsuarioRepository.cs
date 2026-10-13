using BC = BCrypt.Net.BCrypt;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Alta, listado y baja lógica de usuarios en PostgreSQL (Neon).
    /// Requiere sql/006_usuario_nombre_foto.sql.
    /// </summary>
    public class NpgsqlUsuarioRepository : IUsuarioRepository
    {
        public List<UsuarioItem> ObtenerTodos()
        {
            using var conn = DbConnectionFactory.CreateConnection();
            return conn.Query<UsuarioItem>(
                @"SELECT u.pk_usuario AS Id,
                         u.usuario AS Usuario,
                         COALESCE(p.nombre, u.nombre, u.usuario) AS Nombre,
                         u.rol AS Rol,
                         u.activo AS Activo
                  FROM usuario u
                  LEFT JOIN profesional p ON p.pk_profesional = u.fk_profesional
                  ORDER BY lower(u.usuario)"
            ).ToList();
        }

        public int Crear(NuevoUsuario nuevo)
        {
            var hash = BC.HashPassword(nuevo.Clave, workFactor: 10);

            using var conn = DbConnectionFactory.CreateConnection();
            using var tx = conn.BeginTransaction();
            try
            {
                // Un kinesiólogo necesita su fila en profesional (agenda, turnos, color).
                int? profesionalId = null;
                if (nuevo.Rol == "kinesiologo")
                {
                    profesionalId = conn.ExecuteScalar<int>(
                        @"INSERT INTO profesional (nombre, color, activo)
                          VALUES (@Nombre, @Color, TRUE)
                          RETURNING pk_profesional",
                        new { nuevo.Nombre, nuevo.Color }, tx);
                }

                var id = conn.ExecuteScalar<int>(
                    @"INSERT INTO usuario (fk_profesional, usuario, nombre, password_hash, rol, activo, foto)
                      VALUES (@ProfesionalId, @Usuario, @Nombre, @Hash, @Rol, TRUE, @Foto)
                      RETURNING pk_usuario",
                    new
                    {
                        ProfesionalId = profesionalId,
                        Usuario = nuevo.Usuario.Trim(),
                        nuevo.Nombre,
                        Hash = hash,
                        nuevo.Rol,
                        nuevo.Foto
                    }, tx);

                tx.Commit();
                return id;
            }
            catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
            {
                // El rollback deshace también el profesional recién creado.
                tx.Rollback();
                throw new UsuarioDuplicadoException(nuevo.Usuario.Trim());
            }
        }

        public void CambiarActivo(int usuarioId, bool activo)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            conn.Execute(
                "UPDATE usuario SET activo = @Activo WHERE pk_usuario = @Id",
                new { Id = usuarioId, Activo = activo });
        }
    }
}
