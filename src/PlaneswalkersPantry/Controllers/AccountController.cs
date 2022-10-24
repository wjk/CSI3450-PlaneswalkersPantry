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
        return View();
    }

    public IActionResult Register(NewUserModel model)
    {
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult CreateUser(NewUserModel model)
    {
        LoginModel model2 = new() { UserName = model.UserName, Password = model.Password };

        PasswordHasher<LoginModel> hasher = new PasswordHasher<LoginModel>();
        var hash = hasher.HashPassword(model2, model2.Password);

        Account? account = Account.LookUp(model.UserName);
        if (account != null)
        {
            model.State = NewUserModel.FormState.DuplicateUserName;
            return RedirectToAction("Register", model);
        }

        account = new() { UserName = model.UserName, HashedPassword = hash, UserType = "NORMAL" };
        account.SaveNew();

        HttpContext.Session.SetString("AuthenticatedUser", account.UserName);
        return LocalRedirect("/Home/Index");
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