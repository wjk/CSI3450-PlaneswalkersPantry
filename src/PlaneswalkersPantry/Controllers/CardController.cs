using Microsoft.AspNetCore.Mvc;

namespace PlaneswalkersPantry.Controllers;

public class CardController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("SearchForm");
    }

    // GET
    public IActionResult SearchForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult PerformSearch()
    {

    }
}