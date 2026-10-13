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

        /// <summary>Foto de perfil actual (JPEG), o null si no tiene.</summary>
        byte[]? ObtenerFoto(int usuarioId);

        /// <summary>Reemplaza la foto de perfil. Null la borra.</summary>
        void CambiarFoto(int usuarioId, byte[]? foto);

        /// <summary>Guarda una clave nueva. Recibe texto plano y persiste solo el hash BCrypt.</summary>
        void CambiarClave(int usuarioId, string clave);
    }

    /// <summary>El nombre de usuario ya está tomado (sin distinguir mayúsculas).</summary>
    public class UsuarioDuplicadoException : System.Exception
    {
        public UsuarioDuplicadoException(string usuario)
            : base($"El usuario \"{usuario}\" ya existe.") { }
    }
}
