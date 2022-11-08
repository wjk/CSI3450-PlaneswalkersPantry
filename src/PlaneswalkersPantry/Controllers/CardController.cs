using Microsoft.AspNetCore.Mvc;

using PlaneswalkersPantry.Models.ViewModels;

namespace PlaneswalkersPantry.Controllers;

public class CardController : Controller
{
    public IActionResult Index()
    {
        CardBrowseViewModel model = new CardBrowseViewModel();
        return View(model);
    }
}