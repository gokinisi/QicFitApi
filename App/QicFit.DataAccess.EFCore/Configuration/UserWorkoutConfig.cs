using Common.DataAccess.EFCore.Configuration.System;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QicFit.DataAccess.EFCore
{
    public class UserWorkoutConfig : BaseEntityConfig<UserWorkout>
    {
        public UserWorkoutConfig() : base("UserWorkouts")
        {

        }

        public override void Configure(EntityTypeBuilder<UserWorkout> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.UserId).IsRequired();
            builder.Property(obj => obj.WorkoutId).IsRequired();

            builder.HasOne(obj => obj.Workout)
              .WithMany(obj => obj.UserWorkout)
              .HasForeignKey(b => b.WorkoutId);

            builder.HasOne(obj => obj.User)
             .WithMany(obj => obj.UserWorkout)
             .HasForeignKey(b => b.UserId);
        }
    }
}
