using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.IO;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Centraliza la creación de conexiones a PostgreSQL (Neon).
    /// Lee el connection string de appsettings.json una sola vez.
    /// 
    /// Uso:
    ///   using var conn = DbConnectionFactory.CreateConnection();
    ///   var datos = conn.Query&lt;Paciente&gt;("SELECT * FROM paciente");
    /// </summary>
    public static class DbConnectionFactory
    {
        private static readonly string _connectionString;

        static DbConnectionFactory()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();

            _connectionString = config.GetConnectionString("Kinesiologia") ?? string.Empty;
        }

        /// <summary>
        /// Crea y devuelve una conexión PostgreSQL abierta.
        /// El caller es responsable de hacer Dispose (usar 'using').
        /// </summary>
        public static NpgsqlConnection CreateConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException(
                    "No se encontró el connection string 'Kinesiologia' en appsettings.json. " +
                    "Copiá appsettings.example.json como appsettings.json y completá tus credenciales de Neon.");
            }

            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Verifica si hay un connection string configurado (para decidir entre repo SQL y memoria).
        /// </summary>
        public static bool IsConfigured => !string.IsNullOrEmpty(_connectionString);
    }
}
