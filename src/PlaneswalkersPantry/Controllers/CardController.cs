using System.Text;

using Microsoft.AspNetCore.Mvc;

using MySqlConnector;

using PlaneswalkersPantry.Models;
using PlaneswalkersPantry.Models.ViewModels;

namespace PlaneswalkersPantry.Controllers;

public class CardController : Controller
{
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

            model.Results = cards;
        }

        return View(model);
    }
}