using BCrypt.Net;
using BC = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Login en memoria cuando no hay appsettings.json.
    /// Misma clave de dev que sql/005_seed_usuarios.sql, guardada como hash.
    /// Los colores coinciden con MemoryTurnoRepository, no con el seed hasta_diciembre.
    /// </summary>
    public class MemoryAuthRepository : IAuthRepository
    {
        private const string ClaveDev = "Kine2026";

        private static readonly string HashClaveDev = BC.HashPassword(ClaveDev, workFactor: 10);

        private readonly List<UsuarioMemoria> _usuarios;

        public MemoryAuthRepository()
        {
            _usuarios = new List<UsuarioMemoria>
            {
                new UsuarioMemoria { UsuarioId = 1, Login = "jperez",  ProfesionalId = 1, Nombre = "Dr. Juan Pérez",    Color = "#007ACC", Rol = "kinesiologo" },
                new UsuarioMemoria { UsuarioId = 2, Login = "atorres", ProfesionalId = 2, Nombre = "Lic. Ana Torres",   Color = "#28A745", Rol = "kinesiologo" },
                new UsuarioMemoria { UsuarioId = 3, Login = "mlopez",  ProfesionalId = 3, Nombre = "Lic. Martín López", Color = "#E83E8C", Rol = "kinesiologo" }
            };
        }

        public SesionActual? Validar(string usuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
                return null;

            var row = _usuarios.FirstOrDefault(u =>
                string.Equals(u.Login, usuario, StringComparison.OrdinalIgnoreCase));

            if (row is null || !row.Activo)
                return null;

            if (row.ProfesionalId.HasValue && !row.ProfesionalActivo)
                return null;

            if (!BC.Verify(clave, HashClaveDev))
                return null;

            return new SesionActual
            {
                UsuarioId = row.UsuarioId,
                ProfesionalId = row.ProfesionalId,
                Nombre = row.Nombre,
                Color = row.Color,
                Rol = row.Rol
            };
        }

        private sealed class UsuarioMemoria
        {
            public int UsuarioId { get; set; }
            public string Login { get; set; } = "";
            public int? ProfesionalId { get; set; }
            public string Nombre { get; set; } = "";
            public string Color { get; set; } = "#007ACC";
            public string Rol { get; set; } = "";
            public bool Activo { get; set; } = true;
            public bool ProfesionalActivo { get; set; } = true;
        }
    }
}
