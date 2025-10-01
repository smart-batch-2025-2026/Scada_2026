using MySql.Data.MySqlClient;

public class DatabaseService
{
    private string connStr;

    public DatabaseService(string connectionString)
    {
        connStr = connectionString;
    }

    public void LogMotorState(string state)
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        string sql = "INSERT INTO motor_logs (motor_state) VALUES (@state)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@state", state);
        cmd.ExecuteNonQuery();
    }

    public void LogAlarm(string message)
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        string sql = "INSERT INTO motor_alarms (message) VALUES (@msg)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@msg", message);
        cmd.ExecuteNonQuery();
    }
}
