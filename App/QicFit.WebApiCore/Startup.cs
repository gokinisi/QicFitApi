
using Common.WebApiCore;
using QicFit.WebApiCore.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapperConfiguration = AutoMapper.Configuration;

namespace QicFit.WebApiCore
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration) : base(configuration) { }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
        }

        protected override void ConfigureDependencies(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("localDb");
            DependenciesConfig.ConfigureDependencies(services, connectionString);
        }

        protected override void ConfigureIdentity(IServiceCollection services)
        {
            IdentityConfig.Configure(services);
        }

        protected override void ConfigureMapping(AutoMapperConfiguration.MapperConfigurationExpression config)
        {
            AutoMapperConfig.Configure(config);
        }
    }
}
