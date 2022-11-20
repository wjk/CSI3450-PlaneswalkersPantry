using MySqlConnector;

namespace PlaneswalkersPantry.Models;

public class CardSet
{
    public static CardSet? Find(string setCode)
    {
        CardSet retval;

        using MySqlConnection conn = Database.CreateConnection();
        using (MySqlCommand command = new MySqlCommand("SELECT * FROM CARD_SET WHERE (SET_CODE = @code)", conn))
        {
            command.Parameters.Add(new MySqlParameter("code", setCode));

            MySqlDataReader results = command.ExecuteReader();
            bool hasRows = results.Read();
            if (!hasRows) return null;

            retval = FromSqlReader(results);
            results.Close();
        }

        conn.Close();
        return retval;
    }

    public static CardSet FromSqlReader(MySqlDataReader reader)
    {
        CardSet value = new CardSet();
        value.SetCode = reader.GetString("SET_CODE");
        value.SetName = reader.GetString("SET_NAME");
        value.ReleaseYear = reader.GetInt32("RELEASE_YEAR");
        return value;
    }

    public string SetCode { get; set; } = string.Empty;
    public string SetName { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
}