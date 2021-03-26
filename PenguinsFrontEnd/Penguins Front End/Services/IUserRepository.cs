using System.Linq;
using System.Threading.Tasks;
using Penguins_Front_End.Models.Entities;

namespace Penguins_Front_End.Services
{
    /// <summary>
    /// DbUserRepository Interface
    /// </summary>
    public interface IUserRepository
    {
        Task<ApplicationUser> ReadAsync(string userName); //Converted from ApplicationUser Read(string userName)
        Task<IQueryable<ApplicationUser>> ReadAllAsync();
        Task<bool> AssignRoleAsync(string userName, string roleName);
    }
}