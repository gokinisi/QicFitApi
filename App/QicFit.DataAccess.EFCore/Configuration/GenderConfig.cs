using Common.DataAccess.EFCore.Configuration.System;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QicFit.DataAccess.EFCore
{
    public class GenderConfig : BaseEntityConfig<Gender>
    {
        public GenderConfig() : base("Gender")
        {
        }

        public override void Configure(EntityTypeBuilder<Gender> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired();
            builder.Property(obj => obj.Order).IsRequired();

            builder.HasMany(obj => obj.Workouts)
              .WithOne(obj => obj.Gender)
              .HasForeignKey(b => b.GenderId);

            builder
               .HasMany(obj => obj.Users)
               .WithOne(obj => obj.Gender)
               .HasForeignKey(obj => obj.GenderId);
             }
    }
}
