using Microsoft.AspNetCore.Mvc;

using MySqlConnector;

using PlaneswalkersPantry.Models;
using PlaneswalkersPantry.Models.ViewModels;

namespace PlaneswalkersPantry.Controllers;

public class CheckoutController : Controller
{
    private readonly SessionAccess Session;

    public CheckoutController(SessionAccess sessionAccess)
    {
        Session = sessionAccess;
    }

    public IActionResult Basket()
    {
        string? userName = Session.AuthenticatedUserName;
        if (userName == null) throw new UnauthorizedAccessException("You need to be logged in to do this");

        Checkout? basket = Checkout.GetBasket(userName, true);
        return View(basket);
    }
}
