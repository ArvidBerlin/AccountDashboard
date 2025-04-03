using Business.Models;
using Domain.Models;

namespace Presentation.Models;

public class ProjectsViewModel
{
    public ProjectResult<IEnumerable<Project>> Projects { get; set; } = new ProjectResult<IEnumerable<Project>>();
    public AddProjectFormData AddFormData { get; set; } = new AddProjectFormData();
}
