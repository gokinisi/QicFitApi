
using Common.DataAccess.EFCore.Configuration.System;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration
{
    public class StateConfig : BaseEntityConfig<State>
    {
        public StateConfig() : base("State")
        { }

        public override void Configure(EntityTypeBuilder<State> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired();

            builder.HasMany(obj => obj.City)
             .WithOne(obj => obj.State)
             .HasForeignKey(b => b.StateId);

        }
    }
}