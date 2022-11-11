using System.ComponentModel.DataAnnotations;

namespace PlaneswalkersPantry.Models.ViewModels;

public class CardSearchViewModel
{
    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? SetName { get; set; }

    [Required]
    public SearchPredicate Predicate { get; set; } = SearchPredicate.And;

    public enum SearchPredicate
    {
        And,
        Or
    }
}