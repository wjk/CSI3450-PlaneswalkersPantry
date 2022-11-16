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

    public IActionResult Search()
    {
        return View(new CardSearchViewModel());
    }

    [HttpPost]
    public IActionResult Search(CardSearchViewModel model)
    {
        throw new NotImplementedException();
    }
}