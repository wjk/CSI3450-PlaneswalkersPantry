using MySqlConnector;

namespace PlaneswalkersPantry.Models;

public static class Database
{
    static Database()
    {
        DatabaseConnection = new MySqlConnection(
            "Server=localhost;" +
            "Database=PlaneswalkersPantry;" +
            "User=PlaneswalkersPantry;"+
            "Password=PlaneswalkersPantry123");
        DatabaseConnection.Open();
    }

    public static MySqlConnection DatabaseConnection { get; }
}