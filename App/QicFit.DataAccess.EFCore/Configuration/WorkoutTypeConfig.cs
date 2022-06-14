using Common.DataAccess.EFCore.Configuration.System;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QicFit.DataAccess.EFCore
{
    public class WorkoutTypeConfig : BaseEntityConfig<WorkoutType>
    {
        public WorkoutTypeConfig() :base("WorkoutType")
        {
        }

        public override void Configure(EntityTypeBuilder<WorkoutType> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired();
            builder.Property(obj => obj.Order).IsRequired();

            builder.HasMany(obj => obj.Workouts)
             .WithOne(obj => obj.WorkoutType)
             .HasForeignKey(b => b.WorkoutTypeId);

            builder.HasMany(obj => obj.FitnessLevels)
            .WithOne(obj => obj.WorkoutType)
            .HasForeignKey(b => b.WorkoutType);
        }
    }
}
