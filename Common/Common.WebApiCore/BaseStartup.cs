
using Common.Services.Infrastructure;
using Common.WebApiCore.Identity;
using Common.WebApiCore.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using AutoMapperConfiguration = AutoMapper.Configuration;

namespace Common.WebApiCore
{
    public abstract class BaseStartup
    {
        protected abstract void ConfigureDependencies(IServiceCollection services);
        protected abstract void ConfigureMapping(AutoMapperConfiguration.MapperConfigurationExpression config);
        protected abstract void ConfigureIdentity(IServiceCollection services);

        protected BaseStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected IConfiguration Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            RegisterIdentity(services);
            services.ConfigureAuth(Configuration);
            RegisterDependencies(services);
            RegisterMapping();

            services.ConfigureSwagger();

            services.ConfigureCors();

            services.AddAuthorization(opt => opt.RegisterPolicies());

            services
                .AddControllers(opt =>
                {
                    opt.UseCentralRoutePrefix(new RouteAttribute("api"));
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, IDataBaseInitializer dataBaseInitializer)
        {
            if (dataBaseInitializer != null)
            {
                dataBaseInitializer.Initialize();
            }

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseMiddleware<ErrorHandlingMiddleware>();

             app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>

            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "QicFit API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            BaseDependenciesConfig.ConfigureDependencies(services);
            ConfigureDependencies(services);
        }

        private void RegisterMapping()
        {
            var config = new AutoMapperConfiguration.MapperConfigurationExpression();
            BaseAutoMapperConfig.Configure(config);
            ConfigureMapping(config);
            AutoMapper.Mapper.Initialize(config);
        }

        private void RegisterIdentity(IServiceCollection services)
        {
            BaseIdentityConfig.Configure(services);
            ConfigureIdentity(services);
        }
    }
}
