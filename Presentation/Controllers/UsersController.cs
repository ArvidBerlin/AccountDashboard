using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class UsersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
