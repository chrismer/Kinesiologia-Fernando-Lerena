namespace TESTSOLAPAS
{
    /// <summary>
    /// Contrato de login. La pantalla no habla con la base: llama a Validar.
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Devuelve la sesión si el usuario existe, está activo,
        /// la clave coincide y (si tiene profesional) ese profesional está activo.
        /// Cualquier otro caso devuelve null. No dice cuál falló.
        /// </summary>
        SesionActual? Validar(string usuario, string clave);
    }
}
