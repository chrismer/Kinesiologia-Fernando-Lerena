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

            // "Cerrar sesión" vuelve al login. Cancelar el login o cerrar con la X termina la app.
            while (true)
            {
                using var login = new Pantallas.LogIn(authRepo);
                if (login.ShowDialog() != DialogResult.OK || login.Sesion is null)
                    return;

                var principal = new Principal(login.Sesion);
                Application.Run(principal);
                if (!principal.CerrarSesionPedida)
                    return;
            }
        }
    }
}