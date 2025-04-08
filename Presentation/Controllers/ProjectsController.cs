using Business.Interfaces;
using Business.Models;
using Domain.Extensions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentation.Controllers;

public class ProjectsController(IProjectService projectService, IClientService clientService, IStatusService statusService) : Controller
{
    private readonly IProjectService _projectService = projectService;
    private readonly IClientService _clientService = clientService;
    private readonly IStatusService _statusService = statusService;

    [Route("admin/projects")]
    public async Task<IActionResult> Index()
    {
        var clients = await GetClientsSelectListAsync();
        var statuses = await GetStatusesSelectListAsync();
        var projects = await GetProjectsAsync();

        var viewModel = new ProjectsViewModel
        {
            Projects = projects,
            AddProjectViewModel = new AddProjectViewModel() { Clients = clients },
            EditProjectViewModel = new EditProjectViewModel() { Clients = clients, Statuses = statuses },
        };

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var viewModel = new AddProjectViewModel
        {
            Clients = await GetClientsSelectListAsync()
        };
        return PartialView("~/Views/Shared/Partials/Project/_AddProjectModal.cshtml", viewModel);
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

            Clients = await GetClientsSelectListAsync(),
            Statuses = await GetStatusesSelectListAsync()
        };

        return PartialView("~/Views/Shared/Partials/Project/_EditProjectModal.cshtml", viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var result = await _projectService.DeleteProjectAsync(id);

        if (result.Succeeded)
        {
            return Json(new { success = true, message = "Project deleted successfully." });
        }
        else
        {
            return Json(new { success = false, message = result.Error });
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

    private async Task<IEnumerable<Project>> GetProjectsAsync()
    {
        IEnumerable<Project> projects = [];
        try
        {
            var projectResult = await _projectService.GetProjectsAsync();
            if (projectResult.Succeeded && projectResult.Result != null)
                projects = projectResult.Result;
        }
        catch (Exception ex)
        {
            projects = [];
        }

        return projects;
    }
}
