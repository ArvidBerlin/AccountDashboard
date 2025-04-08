using Business.Interfaces;
using Business.Models;
using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Security.Claims;

namespace Presentation.Controllers;

public class AuthController(IAuthService authService, INotificationService notificationService, IUserService userService) : Controller
{
    private readonly IAuthService _authService = authService;
    private readonly INotificationService _notificationService = notificationService;
    private readonly IUserService _userService = userService;

    [Route("auth/signup")]
    public IActionResult SignUp(string returnUrl = "~/")
    {
        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "";

        return View();
    }

    [HttpPost]
    [Route("auth/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel, string returnUrl = "~/")
    {
        ViewBag.ErrorMessage = null;

        if (!ModelState.IsValid)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.ErrorMessage = "";
            return View(viewModel);
        }
            
        var signUpFormData = viewModel.MapTo<SignUpFormData>();
        var result = await _authService.SignUpAsync(signUpFormData);
        if (result.Succeeded)
        {
            return RedirectToAction(returnUrl);
        }

        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = result.Error;
        return View(viewModel);
    }

    [Route("auth/signin")]
    public IActionResult SignIn(string returnUrl = "~/")
    {
        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "";

        return View();
    }

    [HttpPost]
    [Route("auth/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel, string returnUrl = "~/")
    {
        if (ModelState.IsValid)
        {
            var signInFormData = viewModel.MapTo<SignInFormData>();
            var authResult = await _authService.SignInAsync(signInFormData);

            if (authResult.Succeeded)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userResult = await _userService.GetUserByIdAsync(userId!);
                var user = userResult.Result;

                if (user != null)
                {
                    var notificationFormData = new NotificationFormData
                    {
                        NotificationTypeId = 1,
                        NotificationTargetId = 1,
                        Message = $"{user.FirstName} {user.LastName} signed in.",
                        Image = user.Image
                    };

                    await _notificationService.AddNotificationAsync(notificationFormData);
                }

                return LocalRedirect(returnUrl);
            }
        }

        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "Unable to login. try another email or password.";
        return View(viewModel);
    }

    [Route("auth/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _authService.SignOutAsync();
        return LocalRedirect("~/");
    }
}
