using System.Text;

using Microsoft.AspNetCore.Mvc;

using MySqlConnector;

using PlaneswalkersPantry.Models;
using PlaneswalkersPantry.Models.ViewModels;

namespace PlaneswalkersPantry.Controllers;

public class CardController : Controller
{
    private SessionAccess Session;

    public CardController(SessionAccess session)
    {
        Session = session;
    }

    public IActionResult AddToBasket(int cardNumber)
    {
        AddCardToBasketViewModel viewModel = new AddCardToBasketViewModel();

        Card? card = Card.Find(cardNumber);
        if (card == null) throw new InvalidOperationException($"Card with ID {cardNumber} not found");

        viewModel.Card = card;
        viewModel.Count = 1;
        viewModel.CardSet = CardSet.Find(card.SetCode!);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult AddToBasket(AddCardToBasketViewModel model)
    {
        string? userName = Session.AuthenticatedUserName;
        if (userName == null) throw new UnauthorizedAccessException("You need to be logged in to do this");

        Checkout? basket = Checkout.GetBasket(userName, true);
        if (basket == null) throw new InvalidOperationException("Basket was not created");
        basket.AddCard(model.Card!, (uint)model.Count);

        return LocalRedirect("/Checkout/Basket");
    }

    public IActionResult Search()
    {
        return View(new CardSearchViewModel());
    }

    [HttpPost]
    public IActionResult Search(CardSearchViewModel model)
    {
        using MySqlConnection conn = Database.CreateConnection();
        List<MySqlParameter> parameters = new List<MySqlParameter>();

        StringBuilder query = new StringBuilder();
        query.Append("SELECT * FROM CARD");

        if (!string.IsNullOrWhiteSpace(model.Name) || !string.IsNullOrEmpty(model.Content) || model.SetCode != "***")
        {
            bool needsJoinOp = false;
            string joinOp = model.Predicate switch
            {
                CardSearchViewModel.SearchPredicate.And => " AND ",
                CardSearchViewModel.SearchPredicate.Or => " OR ",
                _ => throw new ArgumentException("Unexpected search predicate")
            };

            query.Append(" WHERE (");

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query.Append("CARD_TITLE LIKE @title");
                parameters.Add(new MySqlParameter("title", $"%{model.Name}%"));
                needsJoinOp = true;
            }

            if (!string.IsNullOrWhiteSpace(model.Content))
            {
                if (needsJoinOp) query.Append(joinOp);

                query.Append("RULES_TEXT LIKE @content");
                parameters.Add(new MySqlParameter("content", $"%{model.Content}%"));
                needsJoinOp = true;
            }

            if (model.SetCode != "***")
            {
                if (needsJoinOp) query.Append(joinOp);

                query.Append("SET_CODE = @set_code");
                parameters.Add(new MySqlParameter("set_code", model.SetCode));
            }

            query.Append(");");
        }

        using (MySqlCommand command = new MySqlCommand(query.ToString(), conn))
        {
            command.Parameters.AddRange(parameters.ToArray());

            using var results = command.ExecuteReader();
            bool hasRows = results.Read();

            List<Card> cards = new List<Card>();
            while (hasRows)
            {
                cards.Add(Card.FromSqlRow(results));
                hasRows = results.Read();
            }

            model.Results = cards.Any() ? cards : Enumerable.Empty<Card>();
        }

        return View(model);
    }
}