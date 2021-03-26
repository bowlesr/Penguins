namespace Penguins_Front_End.Models.ViewModels
{
    /// <summary>
    /// UserList View Model
    /// </summary>
    public class UserListVM
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public int NumberOfRoles { get; set; }
        public string RoleNames { get; set; }
    }
}