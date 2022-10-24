using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PlaneswalkersPantry.Models.ViewModels;

public sealed class NewUserModel
{
    [Required, Display(Name = "User name:")]
    public string UserName { get; set; } = null!;

    [Required, Display(Name = "Password:"), Compare(nameof(Password2))]
    public string Password { get; set; } = null!;

    [Required, Display(Name = "Confirm Password:")]
    public string Password2 { get; set; } = null!;

    [ValidateNever]
    public FormState State { get; set; } = FormState.Initial;

    public enum FormState
    {
        Initial = 0,
        DuplicateUserName
    }
}
