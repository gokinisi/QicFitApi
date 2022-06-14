using Common.DataAccess.EFCore.Configuration.System;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QicFit.DataAccess.EFCore
{
    public class LcoationWorkoutTypeConfig : BaseEntityConfig<LocationWorkoutType>
    {
        public LcoationWorkoutTypeConfig() : base("LcoationWorkoutType")
        {

        }

        public override void Configure(EntityTypeBuilder<LocationWorkoutType> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.LocationId).IsRequired();
            builder.Property(obj => obj.WorkoutTypeId).IsRequired();

            builder.HasOne(obj => obj.Location)
              .WithMany(obj => obj.LocationWorkoutType)
              .HasForeignKey(b => b.LocationId);

            builder.HasOne(obj => obj.WorkoutType)
             .WithMany(obj => obj.LocationWorkoutType)
             .HasForeignKey(b => b.WorkoutTypeId);
        }
    }
}
