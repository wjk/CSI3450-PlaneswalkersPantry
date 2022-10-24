using MySqlConnector;

namespace PlaneswalkersPantry.Models;

public sealed class Account
{
    public static Account? LookUp(string userName)
    {
        MySqlCommand command = new MySqlCommand("SELECT * FROM USER WHERE USER_NAME = @Name", Database.DatabaseConnection);
        command.Parameters.Add(new MySqlParameter("@Name", userName));

        var results = command.ExecuteReader();
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

    public string? UserName { get; set; }
    public string? HashedPassword { get; set; }
    public string? UserType { get; set; }
}