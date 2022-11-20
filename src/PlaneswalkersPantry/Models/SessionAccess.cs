namespace PlaneswalkersPantry.Models;

public sealed class SessionAccess
{
    public SessionAccess(IHttpContextAccessor accessor)
    {
        Context = accessor.HttpContext!;
    }

    public HttpContext Context { get; }

    public ISession Session => Context.Session;

    public bool IsSignedIn()
    {
        return Session.GetString("AuthenticatedUser") != null;
    }

    public string? AuthenticatedUserName => Session.GetString("AuthenticatedUser");

    public bool HasUserBasket()
    {
        string? userName = Session.GetString("AuthenticatedUser");
        if (userName == null) return false;

        return Checkout.GetBasket(userName, false) != null;
    }

    public bool HasCheckouts()
    {
        string? userName = Session.GetString("AuthenticatedUser");
        if (userName == null) return false;

        return Checkout.GetCurrentCheckouts(userName).Any();
    }
}