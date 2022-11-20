using System.ComponentModel.DataAnnotations;

using MySqlConnector;

namespace PlaneswalkersPantry.Models;

public class Card
{
    public static Card? Find(int cardNumber)
    {
        MySqlConnection conn = Database.CreateConnection();
        using (MySqlCommand command = new MySqlCommand("SELECT * FROM CARD WHERE (CARD_NUMBER = @num)", conn))
        {
            command.Parameters.Add(new MySqlParameter("num", cardNumber));
            using var results = command.ExecuteReader();
            results.Read();

            if (!results.HasRows)
            {
                results.Close();
                conn.Close();
                return null;
            }

            Card card = Card.FromSqlRow(results);

            results.NextResult();
            bool hasMoreRows = results.Read();
            results.Close();
            conn.Close();

            if (hasMoreRows)
                throw new InvalidOperationException($"More than one card with CARD_NUMBER {cardNumber}");

            return card;
        }
    }

    public static Card FromSqlRow(MySqlDataReader results)
    {
        static string? FixDbNull(MySqlDataReader reader, string columnName)
        {
            try
            {
                return reader.GetString(columnName);
            }
            catch (InvalidCastException)
            {
                // This happens if DBNull is found.
                return null;
            }
        }

        Card card = new Card();
        card.CardNumber = results.GetInt32("CARD_NUMBER");
        card.Title = results.GetString("CARD_TITLE");
        card.ManaCost = results.GetString("MANA_COST");
        card.RulesText = results.GetString("RULES_TEXT");
        card.FlavorText = FixDbNull(results, "FLAVOR_TEXT");
        card.SetCode = results.GetString("SET_CODE");
        card.Rarity = results.GetString("RARITY_CODE") switch
        {
            "C" => CardRarity.Common,
            "U" => CardRarity.Uncommon,
            "R" => CardRarity.Rare,
            "M" => CardRarity.MythicRare,
            _ => throw new ArgumentException($"Unrecognized RARITY_CODE for card {card.Title}")
        };
        card.Power = FixDbNull(results, "POWER");
        card.Toughness = FixDbNull(results, "TOUGHNESS");
        card.TypeLine = results.GetString("TYPE_LINE");
        card.NumberOwned = results.GetUInt32("NUMBER_OWNED");

        return card;
    }

    public int GetNumberCheckedOut()
    {
        int count;

        using MySqlConnection conn = Database.CreateConnection();
        using (MySqlCommand command =
               new MySqlCommand("SELECT SUM(COUNT) AS COUNT FROM CARD_IN_CHECKOUT WHERE (CARD_NUMBER = @num)", conn))
        {
            command.Parameters.Add(new MySqlParameter("num", CardNumber));
            MySqlDataReader results = command.ExecuteReader();

            results.Read();
            count = results.GetInt32("COUNT");
            results.Close();
        }

        conn.Close();
        return count;
    }

    public int GetNumberAvailable() => (int)NumberOwned - GetNumberCheckedOut();

    [Required] public int CardNumber { get; set; }
    [Required] public string? Title { get; set; }
    public string? ManaCost { get; set; }
    public string? RulesText { get; set; }
    public string? FlavorText { get; set; }
    [Required] public string? SetCode { get; set; }
    public CardRarity Rarity { get; set; } = CardRarity.Common;
    public string? Power { get; set; }
    public string? Toughness { get; set; }
    public string? TypeLine { get; set; }
    [Required] public uint NumberOwned { get; set; }
}

public enum CardRarity
{
    Common,
    Uncommon,
    Rare,
    MythicRare
}