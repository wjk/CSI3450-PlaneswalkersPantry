using Microsoft.AspNetCore.Mvc;

using PlaneswalkersPantry.Models.ViewModels;

namespace PlaneswalkersPantry.Controllers;

public class DeckController : Controller
{
    public IActionResult Index()
    {
        return View(new DeckBrowseViewModel());
    }
}
