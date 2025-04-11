using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Presentation.Controllers;

[Authorize]
public class UsersController(IUserService userService, AppDbContext context) : Controller
{
    private readonly IUserService _userService = userService;
    private readonly AppDbContext _context = context;

    [Route("admin/members")]
    public IActionResult Index()
    {
        var viewModel = new UsersViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] AddUserFormData formData)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value!.Errors.Any())
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return Json(new { success = false, errors });
        }

        var result = await _userService.CreateMemberAsync(formData);
        if (result != null)
            return Json(new { success = true });

        return Json(new { success = false, message = result?.Error });
    }

    [HttpGet]
    public async Task<JsonResult> SearchUsers(string term)
    {
        if (string.IsNullOrEmpty(term))
            return Json(new List<object>());

        var users = await _context.Users
            .Where(x => x.FirstName!.Contains(term) || x.LastName!.Contains(term) || x.Email!.Contains(term))
            .Select(x => new { x.Id, x.Image, FullName = $"{x.FirstName} {x.LastName}" })
            .ToListAsync();

        return Json(users);
    }
}
