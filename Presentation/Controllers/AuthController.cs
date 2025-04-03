using Business.Interfaces;
using Domain.Extensions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

public class AuthController(IAuthService authService) : Controller
{
    private readonly IAuthService _authService = authService;

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        ViewBag.ErrorMessage = null;

        if (!ModelState.IsValid)
            return View(viewModel);

        var signUpFormData = viewModel.MapTo<SignUpFormData>();
        var result = await _authService.SignUpAsync(signUpFormData);
        if (result.Succeeded)
        {
            return RedirectToAction("SignIn", "Auth");
        }

        ViewBag.ErrorMessage = result.Error;
        return View(viewModel);
    }

    public IActionResult SignIn(string returnUrl = "~/")
    {
        ViewBag.ReturnUrl = returnUrl;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel, string returnUrl = "~/")
    {
        ViewBag.ErrorMessage = null;
        ViewBag.ReturnUrl = returnUrl;

        if (!ModelState.IsValid)
            return View(viewModel);

        var signInFormData = viewModel.MapTo<SignInFormData>();
        var result = await _authService.SignInAsync(signInFormData);
        if (result.Succeeded)
        {
            return LocalRedirect(returnUrl);
        }

        ViewBag.ErrorMessage = result.Error;
        return View(viewModel);
    }

    public new async Task<IActionResult> SignOut()
    {
        await _authService.SignOutAsync();
        return LocalRedirect("~/");
    }
}
