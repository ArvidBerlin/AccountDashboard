using Business.Interfaces;
using Business.Models;
using Domain.Extensions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentation.Controllers;

public class ProjectsController(IProjectService projectService, IClientService clientService, IStatusService statusService, IUserService userService) : Controller
{
    private readonly IProjectService _projectService = projectService;
    private readonly IClientService _clientService = clientService;
    private readonly IStatusService _statusService = statusService;
    private readonly IUserService _userService = userService;

    [Route("admin/projects")]
    public async Task<IActionResult> Index()
    {
        var clients = await GetClientsSelectListAsync();
        var statuses = await GetStatusesSelectListAsync();
        IEnumerable<ProjectViewModel> projects = await GetProjectsAsync();
        var users = await GetUsersSelectListAsync();

        var viewModel = new ProjectsViewModel
        {
            Projects = projects,
            AddProjectViewModel = new AddProjectViewModel() { Clients = clients, Users = users },
            EditProjectViewModel = new EditProjectViewModel() { Clients = clients, Statuses = statuses },
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] AddProjectFormData formData)
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

        var result = await _projectService.CreateProjectAsync(formData);
        if (result.Succeeded)
            return Json(new { success = true });

        return Json(new { success = false, message = result?.Error });
    }

    [HttpGet]
    public async Task<IActionResult> Update(string id)
    {
        var projectResult = await _projectService.GetProjectAsync(id);
        if (!projectResult.Succeeded || projectResult.Result == null)
            return NotFound();

        var project = projectResult.Result;

        var viewModel = new EditProjectViewModel
        {
            Id = project.Id,
            ImageUrl = project.Image,
            ProjectName = project.ProjectName,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            Budget = project.Budget,
            ClientId = project.Client.Id,
            StatusId = project.Status.Id,
            UserId = project.User.Id,

            Clients = await GetClientsSelectListAsync(),
            Users = await GetUsersSelectListAsync(),
            Statuses = await GetStatusesSelectListAsync()
        };

        return PartialView("~/Views/Shared/Partials/Project/_EditProjectModal.cshtml", viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm] EditProjectFormData formData)
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

        var result = await _projectService.UpdateProjectAsync(formData);
        if (result != null && result.Succeeded)
            return Json(new { success = true });

        return Json(new { success = false, message = result?.Error });
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] string id)
    {
        var result = await _projectService.DeleteProjectAsync(id);

        if (result.Succeeded)
        {
            return LocalRedirect("~/admin/projects");
        }
        else
        {
            TempData["ErrorMessage"] = result.Error;
            return LocalRedirect("~/admin/projects");
        }
    }

    private async Task<IEnumerable<SelectListItem>> GetClientsSelectListAsync()
    {
        var result = await _clientService.GetClientsAsync();
        var statusList = result.Result?.Select(s => new SelectListItem
        {
            Value = s.Id,
            Text = s.ClientName
        });

        return statusList!;
    }

    private async Task<IEnumerable<SelectListItem>> GetStatusesSelectListAsync()
    {
        var result = await _statusService.GetStatusesAsync();
        var statusList = result.Result?.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.StatusName
        });

        return statusList!;
    }

    private async Task<IEnumerable<ProjectViewModel>> GetProjectsAsync()
    {
        IEnumerable<Project> projects = [];
        List<ProjectViewModel> projectViewModels = [];
        try
        {
            var projectResult = await _projectService.GetProjectsAsync();
            if (projectResult.Succeeded && projectResult.Result != null)
            {
                projectViewModels = projectResult.Result.Select(project => new ProjectViewModel
                {
                    Id = project.Id,
                    ProjectName = project.ProjectName,
                    Description = project.Description!,
                    ClientName = project.Client?.ClientName ?? "Unknown"
                }).ToList();
            }
        }
        catch (Exception ex)
        {
            projects = [];
        }

        return projectViewModels;
    }

    private async Task<IEnumerable<SelectListItem>> GetUsersSelectListAsync()
    {
        var result = await _userService.GetUsersAsync();
        var statusList = result.Result?.Select(s => new SelectListItem
        {
            Value = s.Id,
            Text = $"{s.FirstName} {s.LastName}",
        });

        return statusList!;
    }
}
