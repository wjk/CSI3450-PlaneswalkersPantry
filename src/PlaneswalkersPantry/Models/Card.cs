using System.ComponentModel.DataAnnotations;

namespace PlaneswalkersPantry.Models;

public class Card
{
    [Required]
    public int CardNumber { get; set; }
    [Required]
    public string? Title { get; set; }
    public string? ManaCost { get; set; }
    public string? RulesText { get; set; }
    public string? FlavorText { get; set; }
    [Required]
    public string? SetCode { get; set; }
    public string? Rarity { get; set; }
    public string? Power { get; set; }
    public string? Toughness { get; set; }
    public string? TypeLine { get; set; }
    [Required]
    public uint NumberOwned { get; set; }
}