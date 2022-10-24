using System.ComponentModel.DataAnnotations;

namespace PlaneswalkersPantry.Models.ViewModels;

public class CardSearchModel
{
    [Required(ErrorMessage = "Please enter a card title.")]
    [Display(Name = "Card Title:")]
    public string? Title { get; set; }
}
