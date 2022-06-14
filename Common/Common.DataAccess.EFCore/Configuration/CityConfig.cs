
using Common.DataAccess.EFCore.Configuration.System;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration
{
    public class CityConfig : BaseEntityConfig<City>
    {
        public CityConfig() : base("City")
        { }

        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired();
            builder.Property(obj => obj.Longitude).IsRequired();
            builder.Property(obj => obj.Latitude).IsRequired();

            builder.HasMany(obj => obj.Counties)
            .WithOne(obj => obj.City)
            .HasForeignKey(b => b.CityId);

        }
    }
}