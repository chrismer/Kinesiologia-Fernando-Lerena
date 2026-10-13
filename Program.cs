namespace TESTSOLAPAS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            IAuthRepository authRepo = DbConnectionFactory.IsConfigured
                ? new NpgsqlAuthRepository()
                : new MemoryAuthRepository();

            // Si el usuario cancela o cierra el login, la app termina acá.
            using var login = new Pantallas.LogIn(authRepo);
            if (login.ShowDialog() != DialogResult.OK || login.Sesion is null)
                return;

            Application.Run(new Principal(login.Sesion));
        }
    }
}