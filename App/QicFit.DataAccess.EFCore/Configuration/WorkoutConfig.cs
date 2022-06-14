using Common.DataAccess.EFCore.Configuration.System;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.DataAccess.EFCore
{
    public class WorkoutConfig : BaseEntityConfig<Workout>
    {
        public WorkoutConfig() : base("Workouts")
        {
        }

        public override void Configure(EntityTypeBuilder<Workout> builder)
        {
            base.Configure(builder);
            builder.Property(obj => obj.Date).IsRequired();
            builder.Property(obj => obj.Time).IsRequired();

        }
    }
}
