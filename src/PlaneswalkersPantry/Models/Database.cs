using MySqlConnector;

namespace PlaneswalkersPantry.Models;

public static class Database
{
    public static MySqlConnection CreateConnection()
    {
        var conn = new MySqlConnection(
            "Server=localhost;" +
            "Database=PlaneswalkersPantry;" +
            "User=PlaneswalkersPantry;" +
            "Password=PlaneswalkersPantry123");

        conn.Open();
        return conn;
    }
}