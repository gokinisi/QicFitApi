
using Common.Services.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Common.WebApiCore
{
    public static class BaseDependenciesConfig
    {
        public static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentContextProvider, CurrentContextProvider>();

            services.AddSingleton<JwtManager>();
        }
    }
}
