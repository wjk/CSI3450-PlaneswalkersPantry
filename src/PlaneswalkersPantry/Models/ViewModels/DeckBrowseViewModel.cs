using MySqlConnector;

namespace PlaneswalkersPantry.Models.ViewModels;

public class DeckBrowseViewModel
{
    private static Card? FindCard(int cardNumber)
    {
        using MySqlConnection conn = Database.CreateConnection();
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

    private static IEnumerable<(Card Card, int numberInDeck)> FindCardsInDeck(Deck deck)
    {
        List<(int cardId, int numberInDeck)> references = new List<(int cardId, int numberInDeck)>();

        using MySqlConnection conn = Database.CreateConnection();
        using (MySqlCommand command = new MySqlCommand("SELECT * FROM CARD_IN_DECK WHERE (DECK_NUMBER = @num)", conn))
        {
            command.Parameters.Add(new MySqlParameter("num", deck.DeckNumber));
            using var results = command.ExecuteReader();
            results.Read();

            bool hasRows = results.HasRows;
            while (hasRows)
            {
                int cardId = results.GetInt32("CARD_NUMBER");
                uint count = results.GetUInt32("COUNT");

                references.Add(((int cardId, int numberInDeck))(cardId, count));

                hasRows = results.Read();
            }

            results.Close();
        }

        conn.Close();
        return references.Select(((int cardId, int count) pair) =>
        {
            Card? card = FindCard(pair.cardId);
            if (card == null) throw new InvalidOperationException($"No card with ID {pair.cardId} found");

            return (card, pair.count);
        });
    }

    public DeckBrowseViewModel()
    {
        using MySqlConnection conn = Database.CreateConnection();
        using (MySqlCommand command = new MySqlCommand("SELECT * FROM DECK", conn))
        {
            using var results = command.ExecuteReader();
            results.Read();
            bool hasRows = results.HasRows;

            List<Deck> decks = new List<Deck>();
            while (hasRows)
            {
                Deck deck = Deck.FromSqlRow(results);
                deck.Cards = FindCardsInDeck(deck);
                decks.Add(deck);

                hasRows = results.Read();
            }

            results.Close();
            Decks = decks;
        }

        conn.Close();
    }

    public IEnumerable<Deck> Decks { get; }
}