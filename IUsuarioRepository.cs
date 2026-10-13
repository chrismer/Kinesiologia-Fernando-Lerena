using System.Collections.Generic;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Administración de usuarios (pantalla Configuración, solo admin).
    /// Implementaciones: NpgsqlUsuarioRepository (Neon), MemoryAuthRepository (offline).
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>Devuelve todos los usuarios, activos e inactivos, ordenados por usuario.</summary>
        List<UsuarioItem> ObtenerTodos();

        /// <summary>
        /// Crea el usuario (y su profesional si es kinesiólogo). Devuelve el pk_usuario.
        /// Lanza UsuarioDuplicadoException si el nombre de usuario ya existe.
        /// </summary>
        int Crear(NuevoUsuario nuevo);

        /// <summary>Activa o desactiva el login de un usuario. No toca su profesional ni sus turnos.</summary>
        void CambiarActivo(int usuarioId, bool activo);
    }

    /// <summary>El nombre de usuario ya está tomado (sin distinguir mayúsculas).</summary>
    public class UsuarioDuplicadoException : System.Exception
    {
        public UsuarioDuplicadoException(string usuario)
            : base($"El usuario \"{usuario}\" ya existe.") { }
    }
}
