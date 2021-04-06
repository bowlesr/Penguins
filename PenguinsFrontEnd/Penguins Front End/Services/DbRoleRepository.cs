using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Penguins_Front_End.Services
{
    /// <summary>
    /// 
    /// IRoleRepository implementation
    /// 
    /// </summary>
    /// <seealso cref="Penguins_Front_End.Services.IRoleRepository" />
    public class DbRoleRepository : IRoleRepository
    {
        private ApplicationDbContext _db;

        /// <summary>
        /// 
        /// DbRoleRepo constructor
        /// 
        /// </summary>
        /// <param name="db"></param>
        public DbRoleRepository(ApplicationDbContext db) //Inject ApplicationDbContext through the constructor
        {
            _db = db;
        }

        /// <summary>
        /// 
        /// Reads all the roles that has been stored
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<IdentityRole> ReadAll()
        {
            return _db.Roles; //Return the roles from the ApplicationDbContext
        }
    }
}