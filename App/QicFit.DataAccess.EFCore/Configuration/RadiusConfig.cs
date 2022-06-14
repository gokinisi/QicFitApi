using Common.DataAccess.EFCore.Configuration.System;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QicFit.DataAccess.EFCore
{
    public class RadiusConfig : BaseEntityConfig<Radius>
    {
        public RadiusConfig() : base("Radius")
        {

        }

        public override void Configure(EntityTypeBuilder<Radius> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Range).IsRequired();
            builder.Property(obj => obj.Order).IsRequired();

            builder.HasMany(obj => obj.Workouts)
              .WithOne(obj => obj.Radius)
              .HasForeignKey(b => b.RadiusId);


        }
    }
}
