using Common.DataAccess.EFCore.Configuration.System;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QicFit.DataAccess.EFCore
{
    public class FitnessLevelConfig : BaseEntityConfig<FitnessLevel>
    {
        public FitnessLevelConfig() : base("FitnessLevel")
        {
        }

        public override void Configure(EntityTypeBuilder<FitnessLevel> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired();
            builder.Property(obj => obj.Order).IsRequired();

            builder.HasMany(obj => obj.Workouts)
              .WithOne(obj => obj.FitnessLevel)
              .HasForeignKey(b => b.FitnessLevelId);
        }
    }
}
