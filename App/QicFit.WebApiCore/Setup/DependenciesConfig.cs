
using Common.WebApiCore;
using Common.WebApiCore.Identity;
using QicFit.DIContainerCore;
using QicFit.Entities.System;
using Microsoft.Extensions.DependencyInjection;

namespace QicFit.WebApiCore.Setup
{
    public class DependenciesConfig
    {
        public static void ConfigureDependencies(IServiceCollection services, string connectionString)
        {
            ContainerExtension.Initialize(services, connectionString);

            services.AddTransient<IAuthenticationService, AuthenticationService<User>>();
            services.AddTransient<IRoleService, RoleService<User, Role>>();
        }
    }
}
