using MySqlConnector;

namespace PlaneswalkersPantry.Models;

public sealed class Account
{
    public static Account? LookUp(string userName)
    {
        using MySqlConnection conn = Database.CreateConnection();
        using MySqlCommand command = new MySqlCommand("SELECT * FROM USER WHERE USER_NAME = @Name", conn);
        command.Parameters.Add(new MySqlParameter("@Name", userName));

        using var results = command.ExecuteReader();
        results.Read();
        if (!results.HasRows) return null; // user name not found

        Account account = new Account()
        {
            UserName = results.GetString("USER_NAME"),
            HashedPassword = results.GetString("HASHED_PASSWORD"),
            UserType = results.GetString("USER_TYPE")
        };

        bool moreRows = results.NextResult();
        if (moreRows)
        {
            results.Close();
            throw new InvalidOperationException($"More than one user for name '{userName}'");
        }

        results.Close();
        return account;
    }

    public void SaveNew()
    {
        using MySqlConnection conn = Database.CreateConnection();
        using MySqlCommand command = new MySqlCommand("INSERT INTO USER (USER_NAME, HASHED_PASSWORD, USER_TYPE)" +
                                                      "VALUES (@name, @pwd, @type)", conn);
        command.Parameters.Add(new MySqlParameter("name", UserName));
        command.Parameters.Add(new MySqlParameter("pwd", HashedPassword));
        command.Parameters.Add(new MySqlParameter("type", UserType));

        command.ExecuteNonQuery();
    }

    public string? UserName { get; set; }
    public string? HashedPassword { get; set; }
    public string? UserType { get; set; }
}