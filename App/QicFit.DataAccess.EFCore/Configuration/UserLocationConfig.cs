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
    public class UserLocationConfig : BaseEntityConfig<UserLocation>
    {
        public UserLocationConfig() : base("UserLocation")
        {
        }

        public override void Configure(EntityTypeBuilder<UserLocation> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.UserId).IsRequired();
            builder.Property(obj => obj.StateId).IsRequired();
            builder.Property(obj => obj.CityId).IsRequired();

            builder.HasOne(obj => obj.User)
             .WithMany(obj => obj.UserLocations)
             .HasForeignKey(b => b.UserId);

            builder.HasOne(obj => obj.City)
            .WithMany(obj => obj.UserLocations)
            .HasForeignKey(b => b.CityId);

            builder.HasOne(obj => obj.State)
            .WithMany(obj => obj.UserLocations)
            .HasForeignKey(b => b.StateId);

        }
    }
}

