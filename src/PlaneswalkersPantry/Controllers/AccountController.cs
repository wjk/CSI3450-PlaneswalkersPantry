using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using PlaneswalkersPantry.Models;
using PlaneswalkersPantry.Models.ViewModels;

namespace PlaneswalkersPantry.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View(new LoginModel());
    }

    [HttpPost]
    public IActionResult Index(LoginModel model)
    {
        PasswordHasher<LoginModel> hasher = new PasswordHasher<LoginModel>();
        var hash = hasher.HashPassword(model, model.Password);

        Account? account = Account.LookUp(model.UserName!);
        if (account == null)
        {
            model.IsInvalid = true;
            return View(model);
        }

        if (account.HashedPassword == hash)
        {
            HttpContext.Session.SetString("AuthenticatedUser", account.UserName!);
            return LocalRedirect("/Home/Index");
        }
        else
        {
            model.IsInvalid = true;
            return View(model);
        }
    }

    public IActionResult LogOut()
    {
        HttpContext.Session.Remove("AuthenticatedUser");
        return LocalRedirect("/Home/Index");
    }
}