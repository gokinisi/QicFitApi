
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Common.WebApiCore
{
    public static class BaseIdentityConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 4;
                options.User.RequireUniqueEmail = true;
            });
        }
    }
}
