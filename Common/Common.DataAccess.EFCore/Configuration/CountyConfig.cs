
using Common.DataAccess.EFCore.Configuration.System;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration
{
    public class CountyConfig : BaseEntityConfig<County>
    {
        public CountyConfig() : base("County")
        { }

        public override void Configure(EntityTypeBuilder<County> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired();
            builder.Property(obj => obj.Longitude).IsRequired();
            builder.Property(obj => obj.Latitude).IsRequired();

        }
    }
}