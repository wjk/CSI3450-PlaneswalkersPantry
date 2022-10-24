using Microsoft.AspNetCore.Identity;

namespace PlaneswalkersPantry.Models;

public sealed class LoginManager
{
    public LoginManager(IHttpContextAccessor accessor)
    {
        this.HttpContext = accessor.HttpContext!;
    }

    private readonly HttpContext HttpContext;

    public bool IsSignedIn => HttpContext.Session.GetString("AuthenticatedUser") != null;
}