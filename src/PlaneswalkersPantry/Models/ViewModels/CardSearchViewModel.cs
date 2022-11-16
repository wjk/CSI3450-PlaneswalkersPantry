using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

using MySqlConnector;

namespace PlaneswalkersPantry.Models.ViewModels;

public class CardSearchViewModel
{
    public CardSearchViewModel()
    {
        using MySqlConnection conn = Database.CreateConnection();
        using MySqlCommand command = new MySqlCommand("SELECT * FROM CARD_SET;", conn);

        using var results = command.ExecuteReader();
        bool hasRows = results.Read();

        List<(SelectListItem item, int year)> setNameOptions = new List<(SelectListItem, int)>();
        while (hasRows)
        {
            string setCode = results.GetString("SET_CODE");
            string setName = results.GetString("SET_NAME");
            int releaseYear = results.GetInt32("RELEASE_YEAR");

            setNameOptions.Add((new SelectListItem(setName, setCode), releaseYear));

            hasRows = results.Read();
        }

        setNameOptions.Sort((left, right) =>
            left.year.CompareTo(right.year));

        SetNameOptions = setNameOptions.Select(x => x.item).ToArray();
    }

    [Required(ErrorMessage = "Please enter a card title.")]
    [Display(Name = "Card Title:")]
    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? SetCode { get; set; }

    [Required]
    public SearchPredicate Predicate { get; set; } = SearchPredicate.And;

    public enum SearchPredicate
    {
        And,
        Or
    }

    public IEnumerable<SelectListItem> SetNameOptions { get; }

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
