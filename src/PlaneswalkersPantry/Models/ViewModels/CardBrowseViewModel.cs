using MySqlConnector;

namespace PlaneswalkersPantry.Models.ViewModels;

public class CardBrowseViewModel
{
    public IDictionary<string, CardSet> CardSets { get; } = new Dictionary<string, CardSet>();
    public IList<Card> Cards { get; } = new List<Card>();

    public CardBrowseViewModel()
    {
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
                Cards.Add(Card.FromSqlRow(results));
                hasRows = results.Read();
            }

            results.Close();
        }
    }
}