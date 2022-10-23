using Microsoft.AspNetCore.Mvc;

using PlaneswalkersPantry.Models;

namespace PlaneswalkersPantry.Controllers;

public class CardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Search(CardSearchModel model)
    {
        if (!ModelState.IsValid) return RedirectToAction("Index");

        throw new NotImplementedException();
    }
}