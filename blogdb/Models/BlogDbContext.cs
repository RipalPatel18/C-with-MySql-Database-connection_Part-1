using MySql.Data.MySqlClient;


namespace blogdb.Models
{
    public class BlogDbContext
    {
        private static string User { get { return "root"; } }

        private static string Password { get { return " "; } }

        private static string Database { get { return "blog"; } }

        private static string Server { get { return "localhost"; } }

        private static string Port { get { return "3306"; } }


        protected static string ConnectionString
        {
            get
            {
                return $"Server={Server};" +
                    $"Port={Port};" +
                    $"Database={Database};" +
                    $"User ID={User};" +
                    $"Password={Password};";
            }
        }
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
