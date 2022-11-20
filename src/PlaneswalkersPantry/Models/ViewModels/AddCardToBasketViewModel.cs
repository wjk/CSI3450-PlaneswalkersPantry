namespace PlaneswalkersPantry.Models.ViewModels;

public class AddCardToBasketViewModel
{
    public Card? Card { get; set; }

    public CardSet? CardSet { get; set; }

    public int CardNumber
    {
        get => Card!.CardNumber;
        set => Card = Card.Find(value);
    }

    public int Count { get; set; }
}
