using Common.DataAccess.EFCore.Configuration.System;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QicFit.DataAccess.EFCore
{
    public class AgeGroupConfig : BaseEntityConfig<AgeGroup>
    {

        public AgeGroupConfig() : base("AgeGroups")
        {

        }
        public override void Configure(EntityTypeBuilder<AgeGroup> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Range).IsRequired();
            builder.Property(obj => obj.Order).IsRequired();

            builder.HasMany(obj => obj.Workouts)
               .WithOne(obj => obj.AgeGroup)
               .HasForeignKey(b => b.AgeGroupId);
        }
    }
}
