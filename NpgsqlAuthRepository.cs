using BCrypt.Net;
using BC = BCrypt.Net.BCrypt;
using Dapper;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Login contra la tabla usuario en PostgreSQL (Neon).
    /// El hash se verifica en C#. La consulta solo trae la fila.
    /// </summary>
    public class NpgsqlAuthRepository : IAuthRepository
    {
        public SesionActual? Validar(string usuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
                return null;

            using var conn = DbConnectionFactory.CreateConnection();
            var row = conn.QueryFirstOrDefault<UsuarioAuthRow>(
                @"SELECT u.pk_usuario AS UsuarioId,
                         u.usuario AS Login,
                         u.password_hash AS PasswordHash,
                         u.rol AS Rol,
                         u.activo AS UsuarioActivo,
                         u.fk_profesional AS ProfesionalId,
                         p.nombre AS Nombre,
                         p.color AS Color,
                         p.activo AS ProfesionalActivo
                  FROM usuario u
                  LEFT JOIN profesional p ON p.pk_profesional = u.fk_profesional
                  WHERE lower(u.usuario) = lower(@Usuario)
                  LIMIT 1",
                new { Usuario = usuario }
            );

            if (row is null || !row.UsuarioActivo)
                return null;

            if (row.ProfesionalId.HasValue && row.ProfesionalActivo != true)
                return null;

            if (!ClaveValida(clave, row.PasswordHash))
                return null;

            return new SesionActual
            {
                UsuarioId = row.UsuarioId,
                ProfesionalId = row.ProfesionalId,
                Nombre = string.IsNullOrWhiteSpace(row.Nombre) ? row.Login : row.Nombre,
                Color = string.IsNullOrWhiteSpace(row.Color) ? "#007ACC" : row.Color,
                Rol = row.Rol
            };
        }

        private static bool ClaveValida(string clave, string passwordHash)
        {
            try
            {
                return BC.Verify(clave, passwordHash);
            }
            catch (SaltParseException)
            {
                return false;
            }
        }

        private sealed class UsuarioAuthRow
        {
            public int UsuarioId { get; set; }
            public string Login { get; set; } = "";
            public string PasswordHash { get; set; } = "";
            public string Rol { get; set; } = "";
            public bool UsuarioActivo { get; set; }
            public int? ProfesionalId { get; set; }
            public string? Nombre { get; set; }
            public string? Color { get; set; }
            public bool? ProfesionalActivo { get; set; }
        }
    }
}
