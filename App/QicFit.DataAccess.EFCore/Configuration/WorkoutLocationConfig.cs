using Common.DataAccess.EFCore.Configuration.System;
using Common.Entities;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.DataAccess.EFCore
{
    public class WorkoutLocationConfig : BaseEntityConfig<WorkoutLocation>
    {
        public WorkoutLocationConfig() : base("WorkoutLocations")
        {
        }

        public override void Configure(EntityTypeBuilder<WorkoutLocation> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired();
            builder.Property(obj => obj.Street).IsRequired();
            builder.Property(obj => obj.ZipCode).IsRequired();
            builder.Property(obj => obj.Longitude).IsRequired();
            builder.Property(obj => obj.Latitude).IsRequired();

            builder.HasMany(obj => obj.Workout)
                .WithOne(obj => obj.WorkoutLocation)
                .HasForeignKey(b => b.WorkoutLocationId);

            builder.HasMany(obj => obj.Requirement)
               .WithOne(obj => obj.WorkoutLocation)
               .HasForeignKey(x => x.WorkoutLocationId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
