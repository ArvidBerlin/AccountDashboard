namespace Presentation.Models;

public class UsersViewModel
{
    public IEnumerable<UserViewModel> Users { get; set; } = [];
    public AddUserViewModel AddUserViewModel { get; set; } = new AddUserViewModel();
    public EditUserViewModel EditUserViewModel { get; set; } = new EditUserViewModel();
}
