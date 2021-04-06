using System.Linq;
using System.Threading.Tasks;
using Penguins_Front_End.Models.Entities;

namespace Penguins_Front_End.Services
{
    /// <summary>
    /// 
    /// DbUserRepository Interface
    /// 
    /// </summary>
    public interface IUserRepository
    {
        //ReadAsync that will be implemented
        Task<ApplicationUser> ReadAsync(string userName); //Converted from ApplicationUser Read(string userName)
        
        //ReadAllAsync that will be implemented
        Task<IQueryable<ApplicationUser>> ReadAllAsync();

        //AssignRoleAsync method that will be implemented
        Task<bool> AssignRoleAsync(string userName, string roleName);
    }
}
