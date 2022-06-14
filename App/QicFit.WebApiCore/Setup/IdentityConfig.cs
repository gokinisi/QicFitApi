
using Common.IdentityManagementCore;
using QicFit.Entities.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace QicFit.WebApiCore.Setup
{
    public static class IdentityConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddTransient<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.AddTransient<IdentityErrorDescriber>();

            services.AddTransient<IRoleStore<Role>, RoleStore<Role>>();
            services.AddTransient<IUserStore<User>, UserStore<User, Role, UserRole, UserClaim>>();
            services.AddTransient<UserManager<User>, ApplicationUserManager>();
            services.AddTransient(typeof(RoleManager<Role>));

            var identityBuilder = new IdentityBuilder(typeof(User), typeof(User), services);
            identityBuilder.AddDefaultTokenProviders();
        }
    }
}
