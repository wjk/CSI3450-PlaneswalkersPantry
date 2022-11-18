using System.ComponentModel.DataAnnotations;
using System.Text;

using MySqlConnector;

namespace PlaneswalkersPantry.Models;

public class Deck
{
    public static Deck FromSqlRow(MySqlDataReader results)
    {
        Deck deck = new Deck();
        deck.DeckNumber = results.GetInt32("DECK_NUMBER");
        deck.DeckTitle = results.GetString("DECK_TITLE");
        deck.Colors = results.GetString("DECK_COLORS");
        return deck;
    }

    [Required] public int DeckNumber { get; set; }
    [Required] public string DeckTitle { get; set; } = string.Empty;
    public string Colors { get; set; } = string.Empty;

    public IEnumerable<(Card card, int numberInDeck)> Cards { get; set; } = Enumerable.Empty<(Card, int)>();

    public string DisplayColors
    {
        get
        {
            StringBuilder builder = new StringBuilder();
            bool needsComma = false;

            if (Colors.Contains('W'))
            {
                builder.Append("White");
                needsComma = true;
            }

            if (Colors.Contains('U'))
            {
                if (needsComma) builder.Append(", ");
                builder.Append("Blue");
                needsComma = true;
            }

            if (Colors.Contains('B'))
            {
                if (needsComma) builder.Append(", ");
                builder.Append("Black");
                needsComma = true;
            }

            if (Colors.Contains('R'))
            {
                if (needsComma) builder.Append(", ");
                builder.Append("Red");
                needsComma = true;
            }

            if (Colors.Contains('G'))
            {
                if (needsComma) builder.Append(", ");
                builder.Append("Green");
            }

            if (builder.Length == 0) return "(No Color Information)";
            return builder.ToString();
        }
    }
}