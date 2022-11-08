using MySqlConnector;

namespace PlaneswalkersPantry.Models.ViewModels;

public class CardBrowseViewModel
{
    public IDictionary<string, CardSet> CardSets { get; } = new Dictionary<string, CardSet>();
    public IList<Card> Cards { get; } = new List<Card>();

    public CardBrowseViewModel()
    {
        string? FixDBNull(MySqlDataReader reader, string columnName)
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

        using MySqlConnection conn = Database.CreateConnection();

        using (MySqlCommand command = new MySqlCommand("SELECT * FROM CARD_SET;", conn))
        {
            using var results = command.ExecuteReader();
            bool hasRows = results.Read();

            while (hasRows)
            {
                CardSet cset = new CardSet();
                cset.SetCode = results.GetString("SET_CODE");
                cset.SetName = results.GetString("SET_NAME");
                cset.ReleaseYear = results.GetInt32("RELEASE_YEAR");

                CardSets[cset.SetCode] = cset;
                hasRows = results.Read();
            }

            results.Close();
        }

        using (MySqlCommand command = new MySqlCommand("SELECT * FROM CARD;", conn))
        {
            using var results = command.ExecuteReader();
            bool hasRows = results.Read();

            while (hasRows)
            {
                Card card = new Card();
                card.CardNumber = results.GetInt32("CARD_NUMBER");
                card.Title = results.GetString("CARD_TITLE");
                card.ManaCost = results.GetString("MANA_COST");
                card.RulesText = results.GetString("RULES_TEXT");
                card.FlavorText = FixDBNull(results, "FLAVOR_TEXT");
                card.SetCode = results.GetString("SET_CODE");
                card.Rarity = results.GetString("RARITY_CODE") switch
                {
                    "C" => "Common",
                    "U" => "Uncommon",
                    "R" => "Rare",
                    "M" => "Mythic Rare",
                    _ => throw new ArgumentException($"Unrecognized RARITY_CODE for card {card.Title}")
                };
                card.Power = FixDBNull(results, "POWER");
                card.Toughness = FixDBNull(results, "TOUGHNESS");
                card.TypeLine = results.GetString("TYPE_LINE");
                card.NumberOwned = results.GetUInt32("NUMBER_OWNED");

                Cards.Add(card);
                hasRows = results.Read();
            }

            results.Close();
        }
    }
}