﻿using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ClientsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
