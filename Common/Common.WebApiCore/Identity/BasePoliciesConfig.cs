
using Microsoft.AspNetCore.Authorization;

namespace Common.WebApiCore.Identity
{
    public static class BasePoliciesConfig
    {
        public static void RegisterPolicies(this AuthorizationOptions opt)
        {
            opt.AddPolicy("AdminOnly", policy => policy.RequireRole(Roles.Admin));
        }
    }
}
