using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Penguins_Front_End.Services
{
    /// <summary>
    /// DbRoleRepository Interface
    /// </summary>
    public interface IRoleRepository
    {
        IQueryable<IdentityRole> ReadAll();
    }
}