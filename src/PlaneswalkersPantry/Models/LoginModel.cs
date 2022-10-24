using System.ComponentModel.DataAnnotations;

namespace PlaneswalkersPantry.Models;

public class LoginModel
{
    [Display(Name = "User Name:"), Required]
    public string? UserName { get; set; }

    [Display(Name = "Password:"), Required]
    public string? Password { get; set; }

    public bool IsInvalid { get; set; } = false;
}
