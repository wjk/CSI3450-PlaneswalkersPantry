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

    public IActionResult CurrentCheckouts()
    {
        string? userName = Session.AuthenticatedUserName;
        if (userName == null) throw new UnauthorizedAccessException("You need to be logged in to do this");

        var checkouts = Checkout.GetCurrentCheckouts(userName);
        return View(checkouts);
    }

    public IActionResult Basket()
    {
        string? userName = Session.AuthenticatedUserName;
        if (userName == null) throw new UnauthorizedAccessException("You need to be logged in to do this");

        Checkout? basket = Checkout.GetBasket(userName, true);
        return View(basket);
    }

    public IActionResult RemoveFromBasket(int cardNumber)
    {
        string? userName = Session.AuthenticatedUserName;
        if (userName == null) throw new UnauthorizedAccessException("You need to be logged in to do this");

        Checkout? basket = Checkout.GetBasket(userName, true);
        if (basket == null) throw new InvalidOperationException("Could not create basket");

        Card? card = Card.Find(cardNumber);
        if (card == null) throw new InvalidOperationException($"Could not find card with ID {cardNumber}");

        basket.RemoveCard(card);
        return RedirectToAction("Basket");
    }

    public IActionResult PerformCheckout()
    {
        string? userName = Session.AuthenticatedUserName;
        if (userName == null) throw new UnauthorizedAccessException("You need to be logged in to do this");

        Checkout? basket = Checkout.GetBasket(userName, true);
        if (basket == null) throw new InvalidOperationException("Could not create basket");

        if (!basket.CardsInCheckout.Any())
        {
            // TODO: Display a better error here.
            return RedirectToAction("Basket");
        }

        basket.ConfirmCheckout();
        return RedirectToAction("CurrentCheckouts");
    }

    public IActionResult ReturnCheckout(int checkoutNumber)
    {
        string? userName = Session.AuthenticatedUserName;
        if (userName == null) throw new UnauthorizedAccessException("You need to be logged in to do this");

        Checkout? checkout = Checkout.Find(checkoutNumber);
        if (checkout == null) throw new ArgumentException("No checkout found with that checkout number");

        checkout.ReturnCheckout();
        return RedirectToAction("CurrentCheckouts");
    }
}
