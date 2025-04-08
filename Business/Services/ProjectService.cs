using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Domain.Extensions;
using Domain.Models;
using Domain.Responses;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, IStatusService statusService, ILocalImageHandler imageHandler) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IStatusService _statusService = statusService;
    private readonly ILocalImageHandler _imageHandler = imageHandler;


    /* 
     Skriv in ImageHandler nånstans inuti CreateProjectAsync:
     
     var imageFileName = await _imageHandler.SaveProjectImageAsync(formData.Image!);

    */


    public async Task<ProjectResult> CreateProjectAsync(AddProjectFormData formData)
    {
        if (formData == null)
            return new ProjectResult { Succeeded = false, StatusCode = 400, Error = "Not all required fields are supplied." };

        var projectEntity = formData.MapTo<ProjectEntity>();
        var statusResult = await _statusService.GetStatusByIdAsync(1);
        var status = statusResult.Result;

        projectEntity.StatusId = status!.Id;

        var result = await _projectRepository.AddAsync(projectEntity);

        return result.Succeeded
            ? new ProjectResult { Succeeded = true, StatusCode = 201 }
            : new ProjectResult { Succeeded = false, StatusCode = result.StatusCode, Error = result.Error };
    }

    public async Task<ProjectResult<IEnumerable<Project>>> GetProjectsAsync()
    {
        var response = await _projectRepository.GetAllAsync
            (
                orderByDescending: true,
                sortBy: s => s.Created,
                where: null,
                take: 0,
                include => include.User,
                include => include.Status,
                include => include.Client
            );

        return new ProjectResult<IEnumerable<Project>> { Succeeded = true, StatusCode = 200, Result = response.Result };
    }

    public async Task<ProjectResult<Project>> GetProjectAsync(string id)
    {
        var response = await _projectRepository.GetAsync
            (
                where: x => x.Id == id,
                include => include.User,
                include => include.Status,
                include => include.Client
            );
        return response.Succeeded
            ? new ProjectResult<Project> { Succeeded = true, StatusCode = 200, Result = response.Result }
            : new ProjectResult<Project> { Succeeded = false, StatusCode = 404, Error = $"Project '{id}' was not found." };
    }

    public async Task<ProjectResult> UpdateProjectAsync(EditProjectFormData formData)
    {
        if (formData == null)
            return new ProjectResult { Succeeded = false, StatusCode = 400, Error = "Not all required fields are supplied." };

        var existingProjectResponse = await _projectRepository.GetAsync
            (
                x => x.Id == formData.Id,
                include => include.Client,
                include => include.Status,
                include => include.User
            );

        if (!existingProjectResponse.Succeeded)
            return new ProjectResult { Succeeded = false, StatusCode = 404, Error = $"Project '{formData.Id}' was not found." };

        var existingProject = existingProjectResponse.Result;
        var updatedProject = formData.MapTo<ProjectEntity>();
        updatedProject.Id = existingProject!.Id;

        if (formData.Image != null || !string.IsNullOrEmpty(formData.ImageUrl))
        {
            updatedProject.Image = formData.ImageUrl;
        }
        else
        {
            updatedProject.Image = existingProject.Image;
        }

        var updateResult = await _projectRepository.UpdateAsync(updatedProject);
        return updateResult.Succeeded
            ? new ProjectResult { Succeeded = true, StatusCode = 200 }
            : new ProjectResult { Succeeded = false, StatusCode = updateResult.StatusCode, Error = updateResult.Error };
    }

    public async Task<ProjectResult> DeleteProjectAsync(string id)
    {
        var projectResponse = await _projectRepository.GetAsync(x => x.Id == id);
        if (!projectResponse.Succeeded)
            return new ProjectResult { Succeeded = false, StatusCode = 404, Error = $"Project '{id}' was not found." };

        var project = projectResponse.Result!.MapTo<ProjectEntity>();

        var deleteResult = await _projectRepository.DeleteAsync(project);
        return deleteResult.Succeeded
            ? new ProjectResult { Succeeded = true, StatusCode = 200 }
            : new ProjectResult { Succeeded = false, StatusCode = deleteResult.StatusCode, Error = deleteResult.Error };
    }
}
