
using AutoMapper.Configuration;
using QicFit.Services.Infrastructure.MappingProfiles;

namespace QicFit.WebApiCore.Setup
{
    public static class AutoMapperConfig
    {
        public static void Configure(MapperConfigurationExpression config)
        {
            config.AddProfile<UserProfile>();

            config.AddProfile<WorkoutProfile>();
            config.AddProfile<WorkoutTypeProfile>();
            config.AddProfile<WorkoutLocationProfile>();
            config.AddProfile<WorkoutLocationRequirementProfile>();
            config.AddProfile<UserLocationProfile>();
            config.AddProfile<AgeGroupProfile>();
            config.AddProfile<GenderProfile>();
            config.AddProfile<RadiusProfile>();
            config.AddProfile<UserWorkoutProfile>();
            config.AddProfile<FitnessLevelProfile>();
            config.AddProfile<CityProfile>();
            config.AddProfile<StateProfile>();
            config.AddProfile<SystemMessageProfile>();
        }
    }
}
