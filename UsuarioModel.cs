namespace TESTSOLAPAS
{
    /// <summary>
    /// Fila de la grilla de usuarios en Configuración.
    /// </summary>
    public class UsuarioItem
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
    }

    /// <summary>
    /// Datos para dar de alta un usuario. La clave llega en texto plano
    /// y el repositorio guarda solo el hash BCrypt.
    /// Si el rol es kinesiólogo, se crea también su fila en profesional (Nombre y Color).
    /// </summary>
    public class NuevoUsuario
    {
        public string Usuario { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Rol { get; set; } = "kinesiologo";
        public string Nombre { get; set; } = string.Empty;
        public string Color { get; set; } = "#007ACC";
        public byte[]? Foto { get; set; }
    }
}
