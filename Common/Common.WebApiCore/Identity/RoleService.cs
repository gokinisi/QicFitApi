
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.WebApiCore.Identity
{
    public class RoleService<TUser, TRole> : IRoleService
        where TUser : Entities.BaseUser, new()
        where TRole : Entities.BaseRole, new()
    {
        protected readonly UserManager<TUser> userManager;
        protected readonly RoleManager<TRole> roleManager;

        public RoleService(UserManager<TUser> userManager, RoleManager<TRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> AssignToRole(int userId, string roleName)
        {
            if (await roleManager.RoleExistsAsync(roleName))
            {
                var user = await userManager.FindByIdAsync(userId.ToString());
                return await userManager.AddToRoleAsync(user, roleName);
            }

            return IdentityResult.Failed(new IdentityError { Description = "Invalid role name" });
        }

        public async Task<IdentityResult> UnassignRole(int userId, string roleName)
        {
            if (await roleManager.RoleExistsAsync(roleName))
            {
                var user = await userManager.FindByIdAsync(userId.ToString());
                return await userManager.RemoveFromRoleAsync(user, roleName);
            }

            return IdentityResult.Failed(new IdentityError { Description = "Invalid role name" });
        }

        public Task<IList<string>> GetRoles(int userId)
        {
            return userManager.GetRolesAsync(new TUser { Id = userId });
        }
    }
}
