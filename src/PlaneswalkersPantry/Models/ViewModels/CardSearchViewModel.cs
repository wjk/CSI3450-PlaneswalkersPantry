using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

using MySqlConnector;

namespace PlaneswalkersPantry.Models.ViewModels;

public class CardSearchViewModel
{
    public CardSearchViewModel()
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
    }

    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? SetCode { get; set; } = "***";

    [Required]
    public SearchPredicate Predicate { get; set; } = SearchPredicate.And;

    public IEnumerable<Card>? Results { get; set; }

    [ValidateNever] public IDictionary<string, CardSet> CardSets { get; } = new Dictionary<string, CardSet>();

    public enum SearchPredicate
    {
        And,
        Or
    }

    public IEnumerable<SelectListItem> SetNameOptions
    {
        get
        {
            var values = CardSets.Values.ToList();
            values.Sort((left, right) => left.ReleaseYear.CompareTo(right.ReleaseYear));

            SelectListItem anyItem = new SelectListItem("(Any)", "***");
            return values.Select(set => new SelectListItem(set.SetName, set.SetCode)).Prepend(anyItem);
        }
    }

    public SelectListItem[] SearchPredicateOptions
    {
        get
        {
            var result = new SelectListItem[2];
            result[0] = new SelectListItem
            {
                Text = "Match all of the below criteria", Value = SearchPredicate.And.ToString()
            };
            result[1] = new SelectListItem
            {
                Text = "Match any of the below criteria", Value = SearchPredicate.Or.ToString()
            };
            return result;
        }
    }

    public string SearchPredicateDisplayString
    {
        get
        {
            return Predicate switch
            {
                SearchPredicate.And => "Match all of the below criteria",
                SearchPredicate.Or => "Match any of the below criteria",
                _ => throw new ArgumentException("Invalid CardSearchViewModel.SearchPredicate")
            };
        }
    }
}
