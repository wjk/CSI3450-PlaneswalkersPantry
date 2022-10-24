using System.ComponentModel.DataAnnotations;

namespace PlaneswalkersPantry.Models;

public class LoginModel
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }

    public bool IsInvalid { get; set; } = false;
}
