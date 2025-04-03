using Business.Interfaces;
using Domain.Extensions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

public class ProjectsController(IProjectService projectService) : Controller
{
    private readonly IProjectService _projectService = projectService;

    public async Task<IActionResult> Index()
    {
        var viewModel = new ProjectsViewModel
        {
            Projects = await _projectService.GetProjectsAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddProjectViewModel viewModel)
    {
        var addProjectFormData = viewModel.MapTo<AddProjectFormData>();

        var result = await _projectService.CreateProjectAsync(addProjectFormData);
        return Json(new { });
    }

    [HttpPost]
    public IActionResult Update(EditProjectViewModel viewModel)
    {
        return Json(new { });
    }

    [HttpPost]
    public IActionResult Delete(string id)
    {
        return Json(new { });
    }
}
