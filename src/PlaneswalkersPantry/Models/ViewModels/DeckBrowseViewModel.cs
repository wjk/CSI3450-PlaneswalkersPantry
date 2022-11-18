using MySqlConnector;

namespace PlaneswalkersPantry.Models.ViewModels;

public class DeckBrowseViewModel
{
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

        List<(Card, int count)> retval = new List<(Card, int count)>();
        foreach ((int cardId, int count) in references)
        {
            Card? card = Card.Find(cardId);
            if (card == null) throw new InvalidOperationException($"No card with ID {cardId} found");

            retval.Add((card, count));
        }

        return retval;
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
                decks.Add(deck);

                hasRows = results.Read();
            }

            results.Close();
            Decks = decks;
        }

        foreach (Deck deck in Decks)
        {
            deck.Cards = FindCardsInDeck(deck);
        }

        conn.Close();
    }

    public IEnumerable<Deck> Decks { get; }
}