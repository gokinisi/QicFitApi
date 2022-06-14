
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.WebApiCore
{
    public interface IRoleService
    {
        Task<IdentityResult> AssignToRole(int userId, string roleName);
        Task<IdentityResult> UnassignRole(int userId, string roleName);
        Task<IList<string>> GetRoles(int userId);
    }
}
