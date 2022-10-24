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
}