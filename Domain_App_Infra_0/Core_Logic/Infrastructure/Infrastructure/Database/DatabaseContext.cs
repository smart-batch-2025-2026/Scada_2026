using MySql.Data.MySqlClient;

namespace Smart_Batch_Scada.DataAccess
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString =
            "server=localhost;user id=root;password=3@Abdullah21st;database=hary_data_0;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
