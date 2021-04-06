namespace Penguins_Front_End.Models.ViewModels
{
    /// <summary>
    /// 
    /// UserList View Model
    /// 
    /// </summary>
    public class UserListVM
    {
        //string email of user
        public string Email { get; set; }
        //string username of user
        public string UserName { get; set; }
        //int number of roles of the user
        public int NumberOfRoles { get; set; }
        //role name of user
        public string RoleNames { get; set; }
    }
}