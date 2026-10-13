namespace TESTSOLAPAS
{
    /// <summary>
    /// Usuario ya validado. La pantalla de login la entrega y Principal la recibe.
    /// ProfesionalId es null para admin y recepción.
    /// </summary>
    public sealed class SesionActual
    {
        public int UsuarioId { get; init; }
        public int? ProfesionalId { get; init; }
        public string Nombre { get; init; } = "";
        public string Color { get; init; } = "#007ACC";
        public string Rol { get; init; } = "";

        /// <summary>Foto de perfil (JPEG). Null si el usuario no subió ninguna.</summary>
        public byte[]? Foto { get; init; }
    }
}
