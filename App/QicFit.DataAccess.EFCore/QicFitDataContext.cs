using Common.DataAccess.EFCore;
using Common.DataAccess.EFCore.Configuration;
using Common.Entities;
using QicFit.Entities;
using QicFit.Entities.System;
using Microsoft.EntityFrameworkCore;

namespace QicFit.DataAccess.EFCore
{
    public class QicFitDataContext : CommonDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutLocation> WorkoutLocations { get; set; }

        public DbSet<LocationWorkoutType> LocationWorkoutTypes { get; set; }
        public DbSet<WorkoutLocationRequirement> WorkoutLocationRequirement { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<UserWorkout> UserWorkouts { get; set; }
        public DbSet<WorkoutType> WorkoutType { get; set; }
        public DbSet<Radius> Radius { get; set; }
        public DbSet<FitnessLevel> FitnessLevel { get; set; }

        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<County> County { get; set; }

        public DbSet<PreNotification> PreNotification { get; set;}
        public DbSet<SystemMessage> SystemMessage { get; set; }

        public DbSet<UserLocation> UserLocations { get; set; }

        public QicFitDataContext(DbContextOptions<QicFitDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new UserClaimConfig());
            modelBuilder.ApplyConfiguration(new SettingsConfig());
            modelBuilder.ApplyConfiguration(new StateConfig());
            modelBuilder.ApplyConfiguration(new CityConfig());
            
            modelBuilder.ApplyConfiguration(new WorkoutConfig());
            modelBuilder.ApplyConfiguration(new WorkoutLocationConfig());
            modelBuilder.ApplyConfiguration(new GenderConfig());
            modelBuilder.ApplyConfiguration(new SystemMessageConfig());
            modelBuilder.ApplyConfiguration(new PreNotificationConfig());
            modelBuilder.ApplyConfiguration(new UserWorkoutConfig());
            modelBuilder.ApplyConfiguration(new FitnessLevelConfig());

            modelBuilder.HasDefaultSchema("QicFit");
        }
    }
}
