using Npgsql;

namespace ConsoleApp1
{
    public class Conexao
    {
        private static string connectionString =
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=ADMIN;" +
            "Database=postgres";

        public static NpgsqlConnection ObterConexao()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}