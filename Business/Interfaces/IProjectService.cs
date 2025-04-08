using Business.Models;
using Domain.Models;
using Domain.Responses;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<ProjectResult> CreateProjectAsync(AddProjectFormData formData);
    Task<ProjectResult<Project>> GetProjectAsync(string id);
    Task<ProjectResult<IEnumerable<Project>>> GetProjectsAsync();
    Task<ProjectResult> UpdateProjectAsync(EditProjectFormData formData);
    Task<ProjectResult> DeleteProjectAsync(string id);
}