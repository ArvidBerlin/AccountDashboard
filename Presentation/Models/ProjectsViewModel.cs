using Business.Models;
using Domain.Models;
using Domain.Responses;

namespace Presentation.Models;

public class ProjectsViewModel
{
    public IEnumerable<ProjectViewModel> Projects { get; set; } = [];
    public AddProjectViewModel AddProjectViewModel { get; set; } = new AddProjectViewModel();
    public EditProjectViewModel EditProjectViewModel { get; set; } = new EditProjectViewModel();
}
