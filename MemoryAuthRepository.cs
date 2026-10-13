using BCrypt.Net;
using BC = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Login y administración de usuarios en memoria cuando no hay appsettings.json.
    /// Misma clave de dev que sql/005 y sql/006, guardada como hash.
    /// Los colores coinciden con MemoryTurnoRepository, no con el seed hasta_diciembre.
    /// La lista es estática: LogIn y Configuración usan instancias distintas
    /// y tienen que ver los mismos usuarios. Se pierde al cerrar la app.
    /// </summary>
    public class MemoryAuthRepository : IAuthRepository, IUsuarioRepository
    {
        private const string ClaveDev = "Kine2026";

        private static readonly string HashClaveDev = BC.HashPassword(ClaveDev, workFactor: 10);

        private static readonly List<UsuarioMemoria> _usuarios = new List<UsuarioMemoria>
        {
            new UsuarioMemoria { UsuarioId = 1, Login = "jperez",  ProfesionalId = 1, Nombre = "Dr. Juan Pérez",    Color = "#007ACC", Rol = "kinesiologo", PasswordHash = HashClaveDev },
            new UsuarioMemoria { UsuarioId = 2, Login = "atorres", ProfesionalId = 2, Nombre = "Lic. Ana Torres",   Color = "#28A745", Rol = "kinesiologo", PasswordHash = HashClaveDev },
            new UsuarioMemoria { UsuarioId = 3, Login = "mlopez",  ProfesionalId = 3, Nombre = "Lic. Martín López", Color = "#E83E8C", Rol = "kinesiologo", PasswordHash = HashClaveDev },
            new UsuarioMemoria { UsuarioId = 4, Login = "admin",   ProfesionalId = null, Nombre = "Administrador",  Color = "#007ACC", Rol = "admin",       PasswordHash = HashClaveDev }
        };

        private static readonly object _lock = new object();

        public SesionActual? Validar(string usuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
                return null;

            UsuarioMemoria? row;
            lock (_lock)
            {
                row = _usuarios.FirstOrDefault(u =>
                    string.Equals(u.Login, usuario, StringComparison.OrdinalIgnoreCase));
            }

            if (row is null || !row.Activo)
                return null;

            if (row.ProfesionalId.HasValue && !row.ProfesionalActivo)
                return null;

            if (!ClaveValida(clave, row.PasswordHash))
                return null;

            return new SesionActual
            {
                UsuarioId = row.UsuarioId,
                ProfesionalId = row.ProfesionalId,
                Nombre = row.Nombre,
                Color = row.Color,
                Rol = row.Rol,
                Foto = row.Foto
            };
        }

        public List<UsuarioItem> ObtenerTodos()
        {
            lock (_lock)
            {
                return _usuarios
                    .OrderBy(u => u.Login, StringComparer.OrdinalIgnoreCase)
                    .Select(u => new UsuarioItem
                    {
                        Id = u.UsuarioId,
                        Usuario = u.Login,
                        Nombre = u.Nombre,
                        Rol = u.Rol,
                        Activo = u.Activo
                    })
                    .ToList();
            }
        }

        public int Crear(NuevoUsuario nuevo)
        {
            var login = nuevo.Usuario.Trim();
            var hash = BC.HashPassword(nuevo.Clave, workFactor: 10);

            lock (_lock)
            {
                if (_usuarios.Any(u => string.Equals(u.Login, login, StringComparison.OrdinalIgnoreCase)))
                    throw new UsuarioDuplicadoException(login);

                var id = _usuarios.Max(u => u.UsuarioId) + 1;
                int? profesionalId = null;
                if (nuevo.Rol == "kinesiologo")
                    profesionalId = (_usuarios.Max(u => u.ProfesionalId) ?? 0) + 1;

                _usuarios.Add(new UsuarioMemoria
                {
                    UsuarioId = id,
                    Login = login,
                    ProfesionalId = profesionalId,
                    Nombre = nuevo.Nombre,
                    Color = nuevo.Color,
                    Rol = nuevo.Rol,
                    PasswordHash = hash,
                    Foto = nuevo.Foto
                });
                return id;
            }
        }

        public void CambiarActivo(int usuarioId, bool activo)
        {
            lock (_lock)
            {
                var row = _usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
                if (row is not null)
                    row.Activo = activo;
            }
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

        private sealed class UsuarioMemoria
        {
            public int UsuarioId { get; set; }
            public string Login { get; set; } = "";
            public int? ProfesionalId { get; set; }
            public string Nombre { get; set; } = "";
            public string Color { get; set; } = "#007ACC";
            public string Rol { get; set; } = "";
            public string PasswordHash { get; set; } = "";
            public byte[]? Foto { get; set; }
            public bool Activo { get; set; } = true;
            public bool ProfesionalActivo { get; set; } = true;
        }
    }
}
