
using AutoMapper.Configuration;
using Common.Services.Infrastructure.MappingProfiles;

namespace Common.WebApiCore
{
    public static class BaseAutoMapperConfig
    {
        public static void Configure(MapperConfigurationExpression config)
        {
            config.AllowNullCollections = false;

            config.AddProfile<SettingsProfile>();
        }
    }
}
