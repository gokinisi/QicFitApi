
using Common.DataAccess.EFCore;
using Common.Services;
using Common.Services.Infrastructure;
using QicFit.DataAccess.EFCore;
using QicFit.DataAccess.EFCore.Repositories;
using QicFit.Entities.System;
using QicFit.Services;
using QicFit.Services.Infrastructure;
using QicFit.Services.Infrastructure.Repositories;
using QicFit.Services.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QicFit.Services.Infrastructure.Services;

namespace QicFit.DIContainerCore
{
    public static class ContainerExtension
    {
        public static void Initialize(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<QicFitDataContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IDataBaseInitializer, DataBaseInitializer>();

            services.AddTransient<IUserService, UserService<User>>();
            services.AddTransient<IUserRepository<User>, UserRepository>();
            services.AddTransient<IIdentityUserRepository<User>, IdentityUserRepository>();
            services.AddTransient<IRoleRepository<Role>, RoleRepository>();
            services.AddTransient<IUserRoleRepository<UserRole>, UserRoleRepository>();
            services.AddTransient<IUserClaimRepository<UserClaim>, UserClaimRepository>();
            services.AddTransient<IUserPhotoRepository, UserPhotoRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<ISystemMessageRepository, SystemMessageRepository>();
            services.AddTransient<IUserLocationRepository, UserLocationRepository>();
            services.AddTransient<IPreNotificationRepository, PreNotificationRepository>();

            services.AddTransient<IWorkoutRepository, WorkoutRepository>();
            services.AddTransient<IWorkoutLocationRepository, WorkoutLocationRepository>();
            services.AddTransient<IWorkoutLocationRequirementRepository, WorkoutLocationRequirementRepository>();
            services.AddTransient<IAgeGroupRepository, AgeGroupRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IRadiusRepository, RadiusRepository>();
            services.AddTransient<IWorkoutTypeRepository, WorkoutTypeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserWorkoutRepository, UserWorkoutRepository>();
            services.AddTransient<IFitnessLevelRepository, FitnessLevelRepository>();

            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<ISettingsRepository, SettingsRepository>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<ISystemMessageService, SystemMessageService>();
            services.AddTransient<IPreNotificationService, PreNotificationService>();

            services.AddTransient<IWorkoutService, WorkoutService>();
            services.AddTransient<IParticipantService, ParticipantService>();
            services.AddTransient<IUserWorkoutService, UserWorkoutService>();
            services.AddTransient<IUserLocationService, UserLocationService>();
            services.AddTransient<IWorkoutTypeService, WorkoutTypeService>();
            services.AddTransient<IWorkoutLocationService, WorkoutLocationService>();
            services.AddTransient<IWorkoutLocationRequirementService, WorkoutLocationRequirementService>();
            services.AddTransient<IAgeGroupService, AgeGroupService>();
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<IRadiusService, RadiusService>();
            services.AddTransient<ILovService, LovService>();
            services.AddTransient<IFitnessLevelService, FitnessLevelService>();
            services.AddTransient<ISupportService, SupportService>();
            services.AddTransient<IUserSupportService, UserSupportService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
