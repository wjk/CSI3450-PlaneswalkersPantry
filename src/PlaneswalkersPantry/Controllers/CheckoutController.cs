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
        if (userName == null)
        {
            Session.Context.Response.StatusCode = 401;

            RequestErrorViewModel errorViewModel = new RequestErrorViewModel();
            errorViewModel.Message = "You need to be signed in to do that.";
            return View("Error", errorViewModel);
        }

        Checkout? basket = Checkout.GetBasket(userName, false);
        return View(basket);
    }
}
